Imports System.Net
Imports System.Net.Cache
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports System.Xml
Imports Microsoft.VisualBasic.ApplicationServices
Imports Microsoft.Win32

Module App

    Public xmlDoc As XmlDocument
    Public TabDatabase As TabPage
    Public TabKey As TabPage
    Public TabPartyPath As TabPage
    Public fKey As Integer


    Public Sub Main()

        'сохраним закладки во временных объектах
        'TabDatabase = Nothing
        'TabKey = Nothing
        'TabPartyPath = Nothing
        'сохранить закладки конфигураций БД и ключа
        TabDatabase = MainForm.TabControl1.TabPages.Item(1)
        TabKey = MainForm.TabControl1.TabPages.Item(2)
        TabPartyPath = MainForm.TabControl1.TabPages.Item(3)
        'и отключим их при старте
        fKey = 1
        ShowHideTab()

        'загрузим файл конфигурации
        xmlDoc = New XmlDocument()
        Try
            xmlDoc.Load(My.Resources.xmlFileName)
        Catch ex As System.IO.FileNotFoundException
            'если файла конфигураций нет - создать заготовку xml
            xmlDoc.LoadXml(My.Resources.xmlStr)
        End Try

        'установим визуальные стили XP
        Application.EnableVisualStyles()
        Application.DoEvents()

        'прочтем путь по умолчанию из реестра если значение не присвоено (чистая конфигурация)
        Dim rk As Microsoft.Win32.RegistryKey
        If xmlDoc.SelectSingleNode("//Default/PartyPath").InnerText = "" Then
            rk = Microsoft.Win32.Registry.ClassesRoot.CreateSubKey("ODMA32\PartyArc")
            xmlDoc.SelectSingleNode("//Default/PartyPath").InnerText = My.Computer.FileSystem.GetParentPath(CStr(rk.GetValue("", "No Value")))
            rk.Close() ' закрываешь реестр после записи
        End If

        'прочтем dsn odbs32 (поскольку Лоция x862) для postgres для локального и системного юзера из реестра
        'System DSNs can be found in the registry keys
        'DSNs for 64-bit drivers: HKEY_LOCAL_MACHINE\SOFTWARE\Odbc\Odbc.INI\Odbc Data Sources
        'DSNs for 32-bit drivers: HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\Odbc\Odbc.INI\Odbc Data Sources
        'And User DSNs can be found in
        'HKEY_CURRENT_USER\ SOFTWARE \ Odbc \ Odbc.INI
        Dim dsnNames As New List(Of String)
        MainForm.dCbODBCName.DataSource = Nothing
        MainForm.dCbODBCName.Items.Clear()
        For Each reg As Microsoft.Win32.RegistryKey In {
            Registry.LocalMachine.OpenSubKey("SOFTWARE\WOW6432Node\Odbc\Odbc.INI\Odbc Data Sources"),
            Registry.CurrentUser.OpenSubKey("SOFTWARE\Odbc\Odbc.INI\Odbc Data Sources")
            }
            If reg IsNot Nothing Then
                For Each dsn As String In reg.GetValueNames
                    '  If InStr(UCase(CStr(reg.GetValue(dsn))), UCase("postgre")) > 0 Then
                    dsnNames.Add(dsn)
                    'End If
                Next
            End If
        Next
        MainForm.dCbODBCName.DataSource = dsnNames

        'начнем
        InitTabAccount()
        MainForm.aTbPassword.Text = WrapperStr("//Default/Password", "", 0)

        MainForm.Size = New System.Drawing.Size(375, 204)
        MainForm.Icon = My.Resources.Test
        MainForm.ShowDialog()                          'отобразить главную форму

    End Sub

    Sub ShowHideTab()
        With MainForm
            If fKey = 1 Then
                .TabControl1.TabPages.RemoveAt(3)
                .TabControl1.TabPages.RemoveAt(2)
                .TabControl1.TabPages.RemoveAt(1)
                .Label11.Text = "Press F1 to help"
                .aBtExit.Visible = False
                .aBtOpen.Visible = False
            Else
                If Not TabDatabase Is Nothing Then .TabControl1.TabPages.Insert(1, TabDatabase)
                If Not TabKey Is Nothing Then .TabControl1.TabPages.Insert(2, TabKey)
                If Not TabPartyPath Is Nothing Then .TabControl1.TabPages.Insert(3, TabPartyPath)
                .Label11.Text = "Save and"
                InitTabAccount() 'инициализация закладки Account  
            End If
        End With
    End Sub
    'Расшифровать строку
    Function WrapperStr(ByVal tStr As String, ByVal vStr As String, ByVal Mode As Integer) As String
        Dim Ret As String = ""
        Dim wrapper As New Simple3Des(My.Application.Info.CompanyName)

        Select Case Mode
            Case 0
                Dim vWrapperStr As String = xmlDoc.SelectSingleNode(tStr).InnerText
                If vWrapperStr <> "" Then
                    Try
                        Ret = wrapper.DecryptData(vWrapperStr)
                    Catch ex As System.Security.Cryptography.CryptographicException
                        MessageBox.Show("Данные не могут быть расшифрованы с указанным ключем", "Защита логина/пароля", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Ret = ""
                    End Try
                End If
            Case 1
                xmlDoc.SelectSingleNode(tStr).InnerText = wrapper.EncryptData(vStr)
        End Select
        Return Ret
    End Function

    '-----------------------------------------------------------------------------------------------------------
    'Функции закладки Account
    '-----------------------------------------------------------------------------------------------------------
    'инициализация закладки Account    
    Sub InitTabAccount()
        Dim Nodes As XmlNodeList
        Dim Node As XmlNode
        Dim vDatabase, vKey As String

        'конфигурация Database
        MainForm.aCbDatabase.Items.Clear()
        If Not xmlDoc Is Nothing Then
            Nodes = xmlDoc.SelectNodes("//Servers/Server")
            If Not Nodes Is Nothing Then
                For Each Node In Nodes
                    MainForm.aCbDatabase.Items.Add(Node.Attributes("Desc").Value)
                Next
            End If
        End If
        'значение по умолчанию если есть
        vDatabase = xmlDoc.SelectSingleNode("//Default/Database").InnerText
        If vDatabase <> "" Then
            MainForm.aCbDatabase.Text = vDatabase
        Else
            If MainForm.aCbDatabase.Items.Count = 0 Then
                MainForm.aCbDatabase.Text = ""
            Else
                MainForm.aCbDatabase.SelectedIndex = 0
                SetIntegratedFromAutoLogon()
            End If
        End If

        'конфигурация Key
        MainForm.aCbKey.Items.Clear()
        If Not xmlDoc Is Nothing Then
            Nodes = xmlDoc.SelectNodes("//Keys/Key")
            If Not Nodes Is Nothing Then
                For Each Node In Nodes
                    MainForm.aCbKey.Items.Add(Node.Attributes("Desc").Value)
                Next
            End If
        End If
        'значение по умолчанию если есть 
        vKey = xmlDoc.SelectSingleNode("//Default/Key").InnerText
        If vKey <> "" Then
            MainForm.aCbKey.Text = vKey
        Else
            If MainForm.aCbKey.Items.Count = 0 Then
                MainForm.aCbKey.Text = ""
            Else
                MainForm.aCbKey.SelectedIndex = 0 '= MainForm.aCbKey.Items(0).ToString
            End If
        End If

        'конфигурация Login
        MainForm.aTbUserID.Text = WrapperStr("//Default/UserID", "", 0)

        'конфигурация Integrated Password
        If xmlDoc.SelectSingleNode("//Default/Integrated").InnerText = "1" Then
            MainForm.aChbAutoLogon.Checked = True
        Else
            MainForm.aChbAutoLogon.Checked = False
        End If

        MainForm.aShowBtExitConnect()
    End Sub

    'установить флаг Integrated в соответствии с AutoLogon
    Sub SetIntegratedFromAutoLogon()
        'Dim Node As XmlNode

        'Node = xmlDoc.SelectSingleNode("//Servers/Server[@Desc='" & Form.aCbDatabase.Text & "']")
        'If Not Node Is Nothing Then
        '    If Node.SelectSingleNode("AutoLogon").InnerText = "1" Then
        '        Form.aChbAutoLogon.Checked = True
        '    Else
        '        Form.aChbAutoLogon.Checked = False
        '    End If
        'End If
    End Sub
    '-----------------------------------------------------------------------------------------------------------
    'Функции закладки Database
    '-----------------------------------------------------------------------------------------------------------
    'инициализация закладки Database   
    Sub InitTabDatabase()
        Dim Nodes As XmlNodeList
        Dim Node As XmlNode

        MainForm.dCbDesc.Items.Clear()
        If Not xmlDoc Is Nothing Then
            Nodes = xmlDoc.SelectNodes("//Servers/Server")
            If Not Nodes Is Nothing Then
                For Each Node In Nodes '.childNodes
                    MainForm.dCbDesc.Items.Add(Node.Attributes("Desc").Value)
                Next
            End If
        End If

        'значения по умолчанию
        If MainForm.dCbDesc.Items.Count = 0 Then
            MainForm.dCbDesc.Text = ""
            MainForm.dCbServerType.Text = "Microsoft SQL Server"
            MainForm.dTbConnectionString.Text = ""
            MainForm.dTbDatabaseName.Text = ""
            MainForm.dTbParameters.Text = ""
            MainForm.dChbAutoLogon.Checked = False
        Else
            MainForm.dCbDesc.Text = xmlDoc.SelectSingleNode("//Default/Database").InnerText
        End If
        MainForm.dShowBtSaveDel()
    End Sub

    'прочитать выбранную секцию инициализации
    Sub ReadSectionDatabase()
        If MainForm.dCbDesc.Items.Count <> 0 Then
            With xmlDoc.SelectSingleNode("//Servers/Server[@Desc='" & MainForm.dCbDesc.Text & "']")
                MainForm.dCbServerType.Text = .SelectSingleNode("ServerType").InnerText
                MainForm.dCbOracalDrv.Text = .SelectSingleNode("OracalDrv").InnerText
                MainForm.dCbPostgreDrv.Text = .SelectSingleNode("PostgreDrv").InnerText
                MainForm.dCbSybaseDrv.Text = .SelectSingleNode("SybaseDrv").InnerText
                MainForm.dCbODBCName.Text = .SelectSingleNode("ODBCName").InnerText
                MainForm.dTbConnectionString.Text = .SelectSingleNode("ConnectionString").InnerText
                MainForm.dTbServerName.Text = .SelectSingleNode("ServerName").InnerText
                MainForm.dTbDatabaseName.Text = .SelectSingleNode("DataBaseName").InnerText
                MainForm.dTbParameters.Text = .SelectSingleNode("ExtParam").InnerText
                If .SelectSingleNode("AutoLogon").InnerText = "1" Then
                    MainForm.dChbAutoLogon.Checked = True
                Else
                    MainForm.dChbAutoLogon.Checked = False
                End If
                MainForm.aTbUserID.Text = .SelectSingleNode("UserID").InnerText
                MainForm.aTbPassword.Text = .SelectSingleNode("Password").InnerText
                If .SelectSingleNode("Integrated").InnerText = "1" Then
                    MainForm.aChbAutoLogon.Checked = True
                Else
                    MainForm.aChbAutoLogon.Checked = False
                End If
            End With
        Else
            MainForm.dCbServerType.Text = "Microsoft SQL Server"
            MainForm.dTbConnectionString.Text = ""
            MainForm.dTbDatabaseName.Text = ""
            MainForm.dTbParameters.Text = ""
            MainForm.dChbAutoLogon.Checked = False
            MainForm.aTbUserID.Text = ""
            MainForm.aTbPassword.Text = ""
            MainForm.aChbAutoLogon.Checked = False
        End If
        MainForm.dbTabFormUpdate()
        MainForm.dShowBtSaveDel()
    End Sub

    'добавить новую секцию конфигурации
    Sub AddSectionDatabase()
        Dim Node As XmlNode

        If Trim(MainForm.dCbDesc.Text) <> "" Then
            Node = xmlDoc.SelectSingleNode("//Servers/Server[@Desc='" & Trim(MainForm.dCbDesc.Text) & "']")
            If Node Is Nothing Then
                CreateSectionDatabase()
                Node = xmlDoc.SelectSingleNode("//Servers/Server[@Desc='" & Trim(MainForm.dCbDesc.Text) & "']")
            End If
            Node.SelectSingleNode("ServerType").InnerText = MainForm.dCbServerType.Text
            Node.SelectSingleNode("OracalDrv").InnerText = MainForm.dCbOracalDrv.Text
            Node.SelectSingleNode("PostgreDrv").InnerText = MainForm.dCbPostgreDrv.Text
            Node.SelectSingleNode("SybaseDrv").InnerText = MainForm.dCbSybaseDrv.Text
            Node.SelectSingleNode("ODBCName").InnerText = MainForm.dCbODBCName.Text
            Node.SelectSingleNode("ConnectionString").InnerText = MainForm.dTbConnectionString.Text
            Node.SelectSingleNode("ServerName").InnerText = MainForm.dTbServerName.Text
            Node.SelectSingleNode("DataBaseName").InnerText = MainForm.dTbDatabaseName.Text
            Node.SelectSingleNode("ExtParam").InnerText = Trim(MainForm.dTbParameters.Text)
            If MainForm.dChbAutoLogon.Checked Then
                Node.SelectSingleNode("AutoLogon").InnerText = "1"
            Else
                Node.SelectSingleNode("AutoLogon").InnerText = "0"
            End If
        End If
        If Not xmlDoc.SelectSingleNode("//Servers/Server[@Desc='" & Trim(MainForm.dCbDesc.Text) & "']") Is Nothing Then InitTabDatabase()
        xmlDoc.Save(My.Resources.xmlFileName)    'Сохраним данные
    End Sub

    'создать пустую секцию конфигурации
    Sub CreateSectionDatabase()
        Dim Node, nNode As XmlNode

        Node = xmlDoc.SelectSingleNode("//Servers").AppendChild(xmlDoc.CreateElement("Server"))
        Dim attr As XmlAttribute = xmlDoc.CreateAttribute("Desc")
        attr.Value = Trim(MainForm.dCbDesc.Text)
        Node.Attributes.Append(attr)
        nNode = Node.AppendChild(xmlDoc.CreateElement("ServerType"))
        nNode = Node.AppendChild(xmlDoc.CreateElement("OracalDrv"))
        nNode = Node.AppendChild(xmlDoc.CreateElement("PostgreDrv"))
        nNode = Node.AppendChild(xmlDoc.CreateElement("SybaseDrv"))
        nNode = Node.AppendChild(xmlDoc.CreateElement("ODBCName"))
        nNode = Node.AppendChild(xmlDoc.CreateElement("ConnectionString"))
        nNode = Node.AppendChild(xmlDoc.CreateElement("ServerName"))
        nNode = Node.AppendChild(xmlDoc.CreateElement("DataBaseName"))
        nNode = Node.AppendChild(xmlDoc.CreateElement("ExtParam"))
        nNode = Node.AppendChild(xmlDoc.CreateElement("AutoLogon"))

        nNode = Node.AppendChild(xmlDoc.CreateElement("UserID"))
        nNode = Node.AppendChild(xmlDoc.CreateElement("Password"))
        nNode = Node.AppendChild(xmlDoc.CreateElement("Integrated"))
    End Sub

    'удалить существующую секцию конфигурации
    Sub DeleteSectionDatabase()
        Dim Node As XmlNode

        If Trim(MainForm.dCbDesc.Text) <> "" Then
            Node = xmlDoc.SelectSingleNode("//Servers/Server[@Desc='" & Trim(MainForm.dCbDesc.Text) & "']")
            If Not Node Is Nothing Then
                Node.ParentNode.RemoveChild(Node)
                xmlDoc.SelectSingleNode("//Default/Database").InnerText = ""
                xmlDoc.SelectSingleNode("//Default/Key").InnerText = ""
                InitTabDatabase()
                xmlDoc.Save(My.Resources.xmlFileName)    'Сохраним данные
            End If
        End If
    End Sub

    '-----------------------------------------------------------------------------------------------------------
    'Функции закладки Key
    '-----------------------------------------------------------------------------------------------------------
    'инициализация закладки Key   
    Sub InitTabKey()
        Dim Nodes As XmlNodeList
        Dim Node As XmlNode

        MainForm.kCbDesc.Items.Clear()
        If Not xmlDoc Is Nothing Then
            Nodes = xmlDoc.SelectNodes("//Keys/Key")
            If Not Nodes Is Nothing Then
                For Each Node In Nodes
                    MainForm.kCbDesc.Items.Add(Node.Attributes("Desc").Value)
                Next
            End If
        End If

        'значения по умолчанию
        If MainForm.kCbDesc.Items.Count = 0 Then
            MainForm.kCbDesc.Text = ""
            MainForm.kTbIp_name.Text = ""
            MainForm.kChbSearch.Checked = True
        Else
            MainForm.kCbDesc.Text = xmlDoc.SelectSingleNode("//Default/Key").InnerText
        End If
        MainForm.kShowBtSaveDel()
    End Sub

    'прочитать выбранную секцию инициализации
    Sub ReadSectionKey()
        If MainForm.kCbDesc.Items.Count <> 0 Then
            With xmlDoc.SelectSingleNode("//Keys/Key[@Desc='" & MainForm.kCbDesc.Text & "']")
                MainForm.kTbIp_name.Text = .SelectSingleNode("IpName").InnerText
                If .SelectSingleNode("LocalKey").InnerText = "1" Then
                    MainForm.aChbLocalKey.Checked = True
                Else
                    MainForm.aChbLocalKey.Checked = False
                End If
                If .SelectSingleNode("IpSearch").InnerText = "1" Then
                    MainForm.kChbSearch.Checked = True
                Else
                    MainForm.kChbSearch.Checked = False
                End If
            End With
        Else
            MainForm.kTbIp_name.Text = ""
            MainForm.kChbSearch.Checked = True
            MainForm.aChbLocalKey.Checked = True
        End If
        MainForm.kShowBtSaveDel()
    End Sub

    'добавить новую секцию конфигурации
    Sub AddSectionKey()
        Dim Node As XmlNode

        If Trim(MainForm.kCbDesc.Text) <> "" Then
            Node = xmlDoc.SelectSingleNode("//Keys/Key[@Desc='" & Trim(MainForm.kCbDesc.Text) & "']")
            If Node Is Nothing Then
                CreateSectionKey()
                Node = xmlDoc.SelectSingleNode("//Keys/Key[@Desc='" & Trim(MainForm.kCbDesc.Text) & "']")
            End If
            If MainForm.aChbLocalKey.Checked Then
                Node.SelectSingleNode("LocalKey").InnerText = "1"
            Else
                Node.SelectSingleNode("LocalKey").InnerText = "0"
            End If
            Node.SelectSingleNode("IpName").InnerText = MainForm.kTbIp_name.Text
            If MainForm.kChbSearch.Checked Then
                Node.SelectSingleNode("IpSearch").InnerText = "1"
            Else
                Node.SelectSingleNode("IpSearch").InnerText = "0"
            End If
        End If
        If Not xmlDoc.SelectSingleNode("//Keys/Key[@Desc='" & Trim(MainForm.kCbDesc.Text) & "']") Is Nothing Then InitTabKey()
        xmlDoc.Save(My.Resources.xmlFileName)    'Сохраним данные
    End Sub
    'создать пустую секцию конфигурации
    Sub CreateSectionKey()
        Dim Node, nNode As XmlNode
        Node = xmlDoc.SelectSingleNode("//Keys").AppendChild(xmlDoc.CreateElement("Key"))
        Dim attr As XmlAttribute = xmlDoc.CreateAttribute("Desc")
        attr.Value = Trim(MainForm.kCbDesc.Text)
        Node.Attributes.Append(attr)
        nNode = Node.AppendChild(xmlDoc.CreateElement("IpName"))
        nNode.InnerText = MainForm.kTbIp_name.Text
        nNode = Node.AppendChild(xmlDoc.CreateElement("IpSearch"))
        If MainForm.kChbSearch.Checked Then
            nNode.InnerText = "1"
        Else
            nNode.InnerText = "0"
        End If
        nNode = Node.AppendChild(xmlDoc.CreateElement("LocalKey"))
        If MainForm.aChbLocalKey.Checked Then
            nNode.InnerText = "1"
        Else
            nNode.InnerText = "0"
        End If
    End Sub

    'удалить существующую секцию конфигурации
    Sub DelListKey()
        Dim Node As XmlNode
        If Trim(MainForm.kCbDesc.Text) <> "" Then
            Node = xmlDoc.SelectSingleNode("//Keys/Key[@Desc='" & Trim(MainForm.kCbDesc.Text) & "']")
            If Not Node Is Nothing Then
                Node.ParentNode.RemoveChild(Node)       'удалить секцию
                xmlDoc.SelectSingleNode("//Default/Database").InnerText = ""
                xmlDoc.SelectSingleNode("//Default/Key").InnerText = ""
                InitTabKey()
                xmlDoc.Save(My.Resources.xmlFileName)    'Сохраним данные
            End If
        End If
    End Sub

    '-----------------------------------------------------------------------------------------------------------
    'Функции закладки PartyPath
    '-----------------------------------------------------------------------------------------------------------
    'инициализация закладки Key   
    Sub InitTabPartyPath()
        Dim Node As XmlNode

        MainForm.pRbRegistry.Checked = True

        MainForm.pCbPartyPath.Items.Clear()
        Node = xmlDoc.SelectSingleNode("//Default/PartyPath")
        If Not Node Is Nothing Then
            MainForm.pCbPartyPath.Items.Add(Node.InnerText)
        End If

        'значения по умолчанию
        If MainForm.pCbPartyPath.Items.Count = 0 Then
            MainForm.pCbPartyPath.Text = ""
        Else
            MainForm.pCbPartyPath.SelectedIndex = 0
        End If
        MainForm.pShowBtSetGet()
        '        GetFindParty()
    End Sub

    Sub GetFindParty()
        With MainForm
            If .pBtSet.Text = "&Get" Then
                .Cursor = Cursors.WaitCursor
                .pCbPartyPath.Items.Clear()
                If .pRbRegistry.Checked Then
                    Dim rk As Microsoft.Win32.RegistryKey
                    rk = Microsoft.Win32.Registry.ClassesRoot.CreateSubKey("ODMA32\PartyArc")
                    .pCbPartyPath.Items.Add(My.Computer.FileSystem.GetParentPath(CStr(rk.GetValue("", "No Value"))))
                    rk.Close()
                End If

                If .pRbProgramFiles.Checked Then
                    Try
                        For Each foundFile As String In My.Computer.FileSystem.GetFiles(My.Computer.FileSystem.SpecialDirectories.ProgramFiles, FileIO.SearchOption.SearchAllSubDirectories, "partyp.exe")
                            .pCbPartyPath.Items.Add(My.Computer.FileSystem.GetParentPath(foundFile))
                        Next
                    Catch ex As Exception
                    End Try
                End If

                If .pRbFolder.Checked Then
                    Dim folderName As String
                    .OpenPartyPath.InitialDirectory = Environment.SpecialFolder.MyComputer.ToString
                    Dim result As DialogResult = .OpenPartyPath.ShowDialog()

                    If (result = DialogResult.OK) Then
                        folderName = .OpenPartyPath.FileName '.SelectedPath
                        If Trim(folderName) <> "" Then
                            .pCbPartyPath.Items.Add(My.Computer.FileSystem.GetParentPath(folderName))
                        End If
                    End If
                End If

                If .pCbPartyPath.Items.Count <> 0 Then
                    .pCbPartyPath.SelectedIndex = 0
                    .pBtSet.Text = "&Save"
                End If
                .Cursor = Cursors.Arrow
            Else
                xmlDoc.SelectSingleNode("//Default/PartyPath").InnerText = .pCbPartyPath.Text
                xmlDoc.Save(My.Resources.xmlFileName)    'Сохраним данные
            End If
        End With
    End Sub

    '-----------------------------------------------------------------------------------------------------------
    'сохранить текущую секцию конфигурации
    Sub xmlSave()
        Dim Node As XmlNode
        xmlDoc.SelectSingleNode("//Default/Database").InnerText = MainForm.aCbDatabase.Text
        xmlDoc.SelectSingleNode("//Default/Key").InnerText = MainForm.aCbKey.Text

        'для секции default
        If MainForm.aChbAutoLogon.Checked Then
            xmlDoc.SelectSingleNode("//Default/Integrated").InnerText = "1"
        Else
            xmlDoc.SelectSingleNode("//Default/Integrated").InnerText = "0"
        End If

        'зашифровать логин и пароль
        WrapperStr("//Default/UserID", MainForm.aTbUserID.Text, 1)
        WrapperStr("//Default/Password", MainForm.aTbPassword.Text, 1)

        'для секции текущей настройки DataBase
        Node = xmlDoc.SelectSingleNode("//Servers/Server[@Desc='" & Trim(MainForm.aCbDatabase.Text) & "']")
        Node.SelectSingleNode("UserID").InnerText = xmlDoc.SelectSingleNode("//Default/UserID").InnerText
        Node.SelectSingleNode("Password").InnerText = xmlDoc.SelectSingleNode("//Default/Password").InnerText
        Node.SelectSingleNode("Integrated").InnerText = xmlDoc.SelectSingleNode("//Default/Integrated").InnerText

        xmlDoc.Save(My.Resources.xmlFileName)    'Сохраним данные
    End Sub

    'обновить записи в реестре
    Sub SetReg()
        Dim rk As Microsoft.Win32.RegistryKey
        '\HKEY_CURRENT_USER\Software\LotsiaSoft\PartY\WS.INI\DataBase
        'см help lotsia поиск по WS.INI
        rk = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\LotsiaSoft\PartY\WS.INI\DataBase")
        With xmlDoc.SelectSingleNode("//Servers/Server[@Desc='" & MainForm.aCbDatabase.Text & "']")
            Select Case .SelectSingleNode("ServerType").InnerText
                Case "Microsoft SQL Server"
                    If CStr(rk.GetValue("AutoLogon")) <> .SelectSingleNode("AutoLogon").InnerText Then rk.SetValue("AutoLogon", .SelectSingleNode("AutoLogon").InnerText)
                    If CStr(rk.GetValue("DataBase")) <> .SelectSingleNode("DataBaseName").InnerText Then rk.SetValue("DataBase", .SelectSingleNode("DataBaseName").InnerText)
                    If CStr(rk.GetValue("DBMS")) <> "MSSQL" Then rk.SetValue("DBMS", "MSSQL")
                    If CStr(rk.GetValue("DBParm")) <> .SelectSingleNode("ExtParam").InnerText Then rk.SetValue("DBParm", .SelectSingleNode("ExtParam").InnerText)
                    If CStr(rk.GetValue("Server")) <> .SelectSingleNode("ServerName").InnerText Then rk.SetValue("Server", .SelectSingleNode("ServerName").InnerText)
                Case "Oracle"
                    If CStr(rk.GetValue("AutoLogon")) <> .SelectSingleNode("AutoLogon").InnerText Then rk.SetValue("AutoLogon", .SelectSingleNode("AutoLogon").InnerText)
                    If CStr(rk.GetValue("DataBase")) <> .SelectSingleNode("DataBaseName").InnerText Then rk.SetValue("DataBase", .SelectSingleNode("DataBaseName").InnerText)
                    If CStr(rk.GetValue("DBMS")) <> "ORACLE" Then rk.SetValue("DBMS", "ORACLE")
                    If CStr(rk.GetValue("DBParm")) <> .SelectSingleNode("ExtParam").InnerText Then rk.SetValue("DBParm", .SelectSingleNode("ExtParam").InnerText)
                    If CStr(rk.GetValue("Server")) <> .SelectSingleNode("ConnectionString").InnerText Then rk.SetValue("Server", .SelectSingleNode("ConnectionString").InnerText)
                    Select Case .SelectSingleNode("ODBCName").InnerText
                        Case "Oracle 8/8i"
                            If CStr(rk.GetValue("OraDrv")) <> "O84" Then rk.SetValue("OraDrv", "O84")
                        Case "Oracle 9.0.1"
                            If CStr(rk.GetValue("OraDrv")) <> "O90" Then rk.SetValue("OraDrv", "O90")
                        Case "Oracle 9i"
                            If CStr(rk.GetValue("OraDrv")) <> "O90" Then rk.SetValue("OraDrv", "O90")
                        Case "Oracle 10g"
                            If CStr(rk.GetValue("OraDrv")) <> "O10" Then rk.SetValue("OraDrv", "O10")
                        Case "Oracle 11g"
                            If CStr(rk.GetValue("OraDrv")) <> "ORA" Then rk.SetValue("OraDrv", "ORA")
                    End Select
                Case "PostgreSQL"
                    If CStr(rk.GetValue("AutoLogon")) <> .SelectSingleNode("AutoLogon").InnerText Then rk.SetValue("AutoLogon", .SelectSingleNode("AutoLogon").InnerText)
                    If CStr(rk.GetValue("DBParm")) <> .SelectSingleNode("ExtParam").InnerText Then rk.SetValue("DBParm", .SelectSingleNode("ExtParam").InnerText)
                    If .SelectSingleNode("PostgreDrv").InnerText = "PostgreSQL (ODBC)" Then
                        If CStr(rk.GetValue("DataBase")) <> "" Then rk.SetValue("DataBase", "")
                        If CStr(rk.GetValue("DBMS")) <> "PGSQL" Then rk.SetValue("DBMS", "PGSQL")
                        If CStr(rk.GetValue("DSN")) <> .SelectSingleNode("ODBCName").InnerText Then rk.SetValue("DSN", .SelectSingleNode("ODBCName").InnerText)
                    Else
                        If CStr(rk.GetValue("DataBase")) <> .SelectSingleNode("DataBaseName").InnerText Then rk.SetValue("DataBase", .SelectSingleNode("DataBaseName").InnerText)
                        If CStr(rk.GetValue("DBMS")) <> "PGSQL;PGU" Then rk.SetValue("DBMS", "PGSQL;PGU")
                        If CStr(rk.GetValue("Server")) <> .SelectSingleNode("ServerName").InnerText Then rk.SetValue("Server", .SelectSingleNode("ServerName").InnerText)
                    End If
                Case "Sybase Sql Anywhere"
                    If CStr(rk.GetValue("AutoLogon")) <> .SelectSingleNode("AutoLogon").InnerText Then rk.SetValue("AutoLogon", .SelectSingleNode("AutoLogon").InnerText)
                    If CStr(rk.GetValue("DBParm")) <> .SelectSingleNode("ExtParam").InnerText Then rk.SetValue("DBParm", .SelectSingleNode("ExtParam").InnerText)
                    If .SelectSingleNode("SybaseDRV").InnerText = "Sybase SQL Anywhere (ODBC)" Then
                        If CStr(rk.GetValue("DataBase")) <> "" Then rk.SetValue("DataBase", "")
                        If CStr(rk.GetValue("DBMS")) <> "SQLANY" Then rk.SetValue("DBMS", "SQLANY")
                        If CStr(rk.GetValue("DSN")) <> .SelectSingleNode("ODBCName").InnerText Then rk.SetValue("DSN", .SelectSingleNode("ODBCName").InnerText)
                    Else
                        Select Case .SelectSingleNode("SybaseDRV").InnerText
                            Case "Sybase SQL Anywhere 5.0"
                                If CStr(rk.GetValue("DBMS")) <> "SQLANY;5" Then rk.SetValue("DBMS", "SQLANY;5")
                            Case "Adaptive Server Anywhere 6.0"
                                If CStr(rk.GetValue("DBMS")) <> "SQLANY;6" Then rk.SetValue("DBMS", "SQLANY;6")
                            Case "Adaptive Server Anywhere 7.0"
                                If CStr(rk.GetValue("DBMS")) <> "SQLANY;7" Then rk.SetValue("DBMS", "SQLANY;7")
                            Case "Adaptive Server Anywhere 8.0"
                                If CStr(rk.GetValue("DBMS")) <> "SQLANY;8" Then rk.SetValue("DBMS", "SQLANY;8")
                            Case "Adaptive Server Anywhere 9.0"
                                If CStr(rk.GetValue("DBMS")) <> "SQLANY;9" Then rk.SetValue("DBMS", "SQLANY;9")
                            Case "SQL Anywhere 10"
                                If CStr(rk.GetValue("DBMS")) <> "SQLANY;10" Then rk.SetValue("DBMS", "SQLANY;10")
                            Case "SQL Anywhere 11"
                                If CStr(rk.GetValue("DBMS")) <> "SQLANY;11" Then rk.SetValue("DBMS", "SQLANY;11")
                            Case "SQL Anywhere 12"
                                If CStr(rk.GetValue("DBMS")) <> "SQLANY;12" Then rk.SetValue("DBMS", "SQLANY;12")
                            Case "SQL Anywhere 16"
                                If CStr(rk.GetValue("DBMS")) <> "SQLANY;16" Then rk.SetValue("DBMS", "SQLANY;16")
                            Case "SQL Anywhere 17"
                                If CStr(rk.GetValue("DBMS")) <> "SQLANY;17" Then rk.SetValue("DBMS", "SQLANY;17")
                        End Select
                        If CStr(rk.GetValue("DataBase")) <> .SelectSingleNode("DataBaseName").InnerText Then rk.SetValue("DataBase", .SelectSingleNode("DataBaseName").InnerText)
                        If CStr(rk.GetValue("Server")) <> .SelectSingleNode("ServerName").InnerText Then rk.SetValue("Server", .SelectSingleNode("ServerName").InnerText)
                    End If
            End Select

        End With
        With xmlDoc.SelectSingleNode("//Default")
            If CStr(rk.GetValue("Integrated")) <> .SelectSingleNode("Integrated").InnerText Then rk.SetValue("Integrated", .SelectSingleNode("Integrated").InnerText)
            If CStr(rk.GetValue("UserID")) <> MainForm.aTbUserID.Text Then rk.SetValue("UserID", MainForm.aTbUserID.Text)
        End With
        rk.Close() ' закрываешь реестр после записи 
    End Sub

    'проверить пути расположения ключа приложения
    Function CheckPath() As String
        Dim Path As String = xmlDoc.SelectSingleNode("//Default/PartyPath").InnerText
        Dim IPName As String = xmlDoc.SelectSingleNode("//Keys/Key[@Desc='" & MainForm.aCbKey.Text & "']/IpName").InnerText
        Dim msg As String = ""

        MainForm.Cursor = Cursors.WaitCursor

        If Not My.Computer.FileSystem.FileExists(Path & "\partyp.exe") Then
            'msg = msg & "Исполняемый файл приложения Lotsia PDM Plus" & vbCrLf & _
            '                                                                                    "  - " & Path & "\partyp.exe" & vbCrLf & _
            '                                                                                    "недоступен" & vbCrLf
            Dim rk As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.ClassesRoot.CreateSubKey("ODMA32\PartyArc")
            Dim pth As String = My.Computer.FileSystem.GetParentPath(CStr(rk.GetValue("", "No Value")))
            If pth.Length > 0 And My.Computer.FileSystem.FileExists(pth & "\partyp.exe") Then
                Dim Result As DialogResult = MessageBox.Show("Путь к исполняемому файлу приложения Lotsia PDM Plus" & vbCrLf &
                                                              "  - " & Path & "\partyp.exe" & vbCrLf &
                                                              "указанный в настройках приложения - не найден" & vbCrLf & vbCrLf &
                                                              "Но в системном реестре обнаружен альтернативный путь" & vbCrLf &
                                                              "  - " & pth & "\partyp.exe" & vbCrLf &
                                                              "-----------------------------------------" & vbCrLf &
                                                              "хотите использовать его по умолчанию?",
                                                              "Проверка конфигурации", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                If Result = System.Windows.Forms.DialogResult.Yes Then
                    xmlDoc.SelectSingleNode("//Default/PartyPath").InnerText = pth
                    xmlDoc.Save(My.Resources.xmlFileName)    'Сохраним данные
                    Path = xmlDoc.SelectSingleNode("//Default/PartyPath").InnerText
                End If
            Else
                MessageBox.Show("Путь к исполняемому файлу приложения Lotsia PDM Plus" & vbCrLf &
                                "  - " & Path & "\partyp.exe" & vbCrLf &
                                "указанный в настройках приложения - не найден" & vbCrLf & vbCrLf &
                                "К сожалению в системном реестре также не обнаружено ссылок на ПО Lotsia PDM Plus" & vbCrLf & vbCrLf &
                                "Подключение с указанными настроками - НЕВОЗМОЖНО.",
                                "Проверка конфигурации", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If


        'проверка ключа если он локальный
        If xmlDoc.SelectSingleNode("//Keys/Key[@Desc='" & MainForm.aCbKey.Text & "']/LocalKey").InnerText = "1" Then

            If Not My.Computer.FileSystem.FileExists(Path & "\gnclient.ini") Then msg = msg & "Конфигурационный файл ключа аппаратной защиты" & vbCrLf &
                                                                                            "  - " & Path & "\gnclient.ini" & vbCrLf &
                                                                                            "недоступен" & vbCrLf
            If Not My.Computer.Network.IsAvailable Then
                msg = msg & "К сожалению, в данный момент времени" & vbCrLf &
                                                                  "Сеть" & vbCrLf &
                                                                  "недоступна" & vbCrLf
            Else
                Try
                    If My.Computer.Network.Ping(IPName, 700) Then
                        msg = msg & ""
                    End If
                Catch ex As System.Net.NetworkInformation.PingException
                    msg = msg & "Путь к ключу аппаратной защиты" & vbCrLf &
                                  "  - \\" & IPName & vbCrLf &
                                  "недоступен (Недопустимый URL/Host Name - адрес)" & vbCrLf
                Catch ex As InvalidOperationException
                    msg = msg & "Путь к ключу аппаратной защиты" & vbCrLf &
                                  "  - \\" & IPName & vbCrLf &
                                  "недоступен (Отсутствует сетевое подключение)" & vbCrLf
                End Try
            End If
        End If

        If Len(msg) > 0 Then msg = msg & "-----------------------------------------" & vbCrLf &
                                     "Выйти из приложения?"
        MainForm.Cursor = Cursors.Arrow
        Return msg
    End Function

    Sub RunLotsiaPDMExit(ByVal Mode As Integer)
        Dim msg As String = CheckPath()

        If msg = "" Then
            xmlSave()               'сохранить текущую секцию конфигурации
            SetReg()                'обновить записи в реестре
            'проверка ключа если он локальный
            If xmlDoc.SelectSingleNode("//Keys/Key[@Desc='" & MainForm.aCbKey.Text & "']/LocalKey").InnerText = "1" Then
                SetGuardant()           'обновить секцию файла ключа
            End If
            Select Case Mode
                Case 0              'сохранить и выйти
                Case 1
                    LotsiaRun(0)    'сохранить и открыть LotsiaPDM Plus без параметров
                Case 2
                    LotsiaRun(1)    'сохранить и запустить LotsiaPDM Plus с параметрами
            End Select
            DelObject()
            Application.Exit()
        Else
            Dim Result As DialogResult = MessageBox.Show(msg, "Проверка конфигурации", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
            If Result = System.Windows.Forms.DialogResult.Yes Then
                'Dim Result As MsgBoxResult = MsgBox(msg, MsgBoxStyle.DefaultButton2 Or MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNo, "Проверка конфигурации")
                'If Result = MsgBoxResult.Yes Then
                DelObject()
                Application.Exit()
            End If
        End If

    End Sub


    'обновить секцию файла ключа
    Sub SetGuardant()
        Dim IpName, IpSearch As String
        Dim Node As XmlNode

        Node = xmlDoc.SelectSingleNode("//Keys/Key[@Desc='" & MainForm.aCbKey.Text & "']")
        IpName = Trim(Node.SelectSingleNode("IpName").InnerText)
        If Trim(Node.SelectSingleNode("IpSearch").InnerText) = "1" Then
            IpSearch = "ON"
        Else
            IpSearch = "OFF"
        End If

        'редактировать ini guardant в Programm Files
        Dim objIniFile As New IniFile(xmlDoc.SelectSingleNode("//Default/PartyPath").InnerText & "\gnclient.ini")
        If objIniFile.GetString("SERVER", "IP_NAME", "") <> IpName Then
            objIniFile.WriteString("SERVER", "IP_NAME", IpName)
        End If
        If objIniFile.GetString("SERVER", "SEARCH", "") <> IpSearch Then
            objIniFile.WriteString("SERVER", "SEARCH", IpSearch)
        End If
    End Sub

    'Запустить LotsiaPDM Plus с параметрами
    Sub LotsiaRun(ByVal mode As Integer)
        Dim path As String

        path = xmlDoc.SelectSingleNode("//Default/PartyPath").InnerText & "\"
        If mode = 0 Then
            path = path & "partyp.EXE"
        Else
            '    path = path & "partyp.EXE -uid=" & Trim(MainForm.aTbUserID.Text) & " -pwd=" & Trim(MainForm.aTbPassword.Text) '& " -max"
            path = """" & path & "partyp.EXE"" -uid=" & Trim(MainForm.aTbUserID.Text) & " -pwd=" & Trim(MainForm.aTbPassword.Text) '& " -max" 
        End If
        Dim procID As Integer = Shell(CStr(path), AppWinStyle.NormalFocus) ')Hide) '.NormalNoFocus) 
        '        Dim procID As Integer = Shell(CStr(path), AppWinStyle.NormalFocus, True, 1)
        '  MsgBox(procID)

    End Sub

    Sub DelObject()
        If Not xmlDoc Is Nothing Then xmlDoc = Nothing
        If Not TabDatabase Is Nothing Then TabDatabase = Nothing
        If Not TabKey Is Nothing Then TabKey = Nothing
        If Not TabPartyPath Is Nothing Then TabPartyPath = Nothing
    End Sub

End Module