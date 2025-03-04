Imports System.Runtime.CompilerServices
Imports Microsoft.SqlServer

Public Class MainForm

    'нажатия кнопок F1 F2
    Private Sub MainForm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Dim myAL As New ArrayList()
        Select Case e.KeyCode
            Case Keys.F1
                AboutBox.ShowDialog()
            Case Keys.F2
                If fKey = 1 Then
                    fKey = 0
                Else
                    fKey = 1
                End If
                ShowHideTab()
            Case Keys.Escape
                Application.Exit()
        End Select
    End Sub
    Private Sub TabControl1_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TabControl1.MouseClick
        Select Case e.Button
            Case Windows.Forms.MouseButtons.Right
                If fKey = 1 Then
                    fKey = 0
                Else
                    fKey = 1
                End If
                ShowHideTab()
        End Select
    End Sub

    'Переход по закладкам
    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        Select Case TabControl1.SelectedIndex
            Case 0
                InitTabAccount() 'инициализация закладки Account   
                Size = New System.Drawing.Size(375, 204)
            Case 1
                InitTabDatabase() 'инициализация закладки Database
                '                Size = New System.Drawing.Size(382, 267)
                Size = New System.Drawing.Size(375, 255) '+10
                Height = 265
            Case 2
                InitTabKey() 'инициализация закладки Key   
                Size = New System.Drawing.Size(375, 175) '+10
                Height = 185
            Case 3
                InitTabPartyPath() 'инициализация закладки Key   
                Size = New System.Drawing.Size(375, 133)
                Height = 133
        End Select
    End Sub

    '-----------------------------------------------------------------------------------------------------------
    'Функции закладки Account
    '-----------------------------------------------------------------------------------------------------------
    Private Sub aCbDatabase_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles aCbDatabase.SelectedValueChanged
        xmlDoc.SelectSingleNode("//Default/Database").InnerText = aCbDatabase.Text
        'SetIntegratedFromAutoLogon()

        'конфигурация Login
        aTbUserID.Text = WrapperStr("//Servers/Server[@Desc='" & aCbDatabase.Text & "']/UserID", "", 0)
        aTbPassword.Text = WrapperStr("//Servers/Server[@Desc='" & aCbDatabase.Text & "']/Password", "", 0)
        'конфигурация Integrated Password
        If xmlDoc.SelectSingleNode("//Servers/Server[@Desc='" & aCbDatabase.Text & "']/Integrated").InnerText = "1" Then
            aChbAutoLogon.Checked = True
        Else
            aChbAutoLogon.Checked = False
        End If
        '        aTbPassword.Text = ""
    End Sub
    Private Sub aCbDatabase_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles aCbDatabase.TextChanged
        aShowBtExitConnect()
    End Sub
    Private Sub aCbKey_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles aCbKey.SelectedValueChanged
        xmlDoc.SelectSingleNode("//Default/Key").InnerText = aCbKey.Text
        aTbPassword.Text = ""
    End Sub
    Private Sub aCbKey_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles aCbKey.TextChanged
        aShowBtExitConnect()
    End Sub
    Private Sub aTbUserID_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles aTbUserID.TextChanged
        aTbPassword.Text = ""
        aShowBtExitConnect()
    End Sub
    Private Sub aTbPassword_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles aTbPassword.TextChanged
        aShowBtExitConnect()
    End Sub
    Private Sub aChbAutoLogon_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles aChbAutoLogon.CheckedChanged
        If aChbAutoLogon.Checked Then
            aTbUserID.Enabled = False
            aTbPassword.Enabled = False
        Else
            aTbUserID.Enabled = True
            aTbPassword.Enabled = True
        End If
    End Sub

    Sub aShowBtExitConnect() 'скрыть/показать кнопки закладки
        If xmlDoc.SelectSingleNode("//Default/PartyPath").InnerText <> "" And Trim(aCbDatabase.Text) <> "" And Trim(aCbKey.Text) <> "" And Trim(aTbUserID.Text) <> "" And Trim(aTbPassword.Text) <> "" Then
            aBtConnect.Visible = True
            If fKey = 0 Then
                aBtExit.Visible = True
                aBtOpen.Visible = True
                'Label11.Visible = True
                Label11.Text = "Save and"
            End If
        Else

            aBtConnect.Visible = False
            If fKey = 0 Then
                aBtExit.Visible = False
                aBtOpen.Visible = False
                'Label11.Visible = False
                Label11.Text = "Press F1 to help"
            End If
        End If
    End Sub
    Private Sub aBtExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles aBtExit.Click
        RunLotsiaPDMExit(0)
    End Sub
    Private Sub aBtOpen_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles aBtOpen.Click
        RunLotsiaPDMExit(1)
    End Sub
    Private Sub aBtConnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles aBtConnect.Click
        RunLotsiaPDMExit(2)
    End Sub

    '-----------------------------------------------------------------------------------------------------------
    'Функции закладки Database
    '-----------------------------------------------------------------------------------------------------------
    Private Sub dCbDesc_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dCbDesc.SelectedValueChanged
        ReadSectionDatabase() 'прочитать выбранную секцию инициализации
    End Sub


    Private Sub dCbDesc_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dCbDesc.TextChanged
        dShowBtSaveDel()
    End Sub

    Sub dShowBtSaveDel() 'скрыть/показать кнопки закладки
        '       If Trim(ComboBox3.Text) <> "" And Trim(TextBox3.Text) <> "" And Trim(TextBox4.Text) <> "" Then
        If Trim(dCbDesc.Text) <> "" Then 'And Trim(dTbServer.Text) <> "" Then
            dBtSave.Visible = True
        Else
            dBtSave.Visible = False
        End If
        If Trim(dCbDesc.Text) <> "" And Not xmlDoc.SelectSingleNode("//Servers/Server[@Desc='" & Trim(dCbDesc.Text) & "']") Is Nothing Then
            dBtDel.Visible = True
        Else
            dBtDel.Visible = False
        End If
    End Sub
    Private Sub dBtSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles dBtSave.Click
        AddSectionDatabase() 'добавить новую секцию конфигурации
    End Sub
    Private Sub dBtDel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles dBtDel.Click
        DeleteSectionDatabase() 'удалить существующую секцию конфигурации
    End Sub

    '-----------------------------------------------------------------------------------------------------------
    'Функции закладки Key
    '-----------------------------------------------------------------------------------------------------------
    Private Sub kCbDesc_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles kCbDesc.SelectedValueChanged
        ReadSectionKey() 'прочитать выбранную секцию инициализации
    End Sub
    Private Sub kCbDesc_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles kCbDesc.TextChanged
        kShowBtSaveDel()
    End Sub

    Sub kShowBtSaveDel() 'скрыть/показать кнопки закладки
        If Trim(kCbDesc.Text) <> "" Then ' And Trim(kTbIp_name.Text) <> "" Then
            kBtSave.Visible = True
        Else
            kBtSave.Visible = False
        End If
        If Trim(kCbDesc.Text) <> "" And Not xmlDoc.SelectSingleNode("//Keys/Key[@Desc='" & Trim(kCbDesc.Text) & "']") Is Nothing Then
            kBtDel.Visible = True
        Else
            kBtDel.Visible = False
        End If
    End Sub
    Private Sub kBtSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles kBtSave.Click
        AddSectionKey() 'добавить новую секцию конфигурации
    End Sub
    Private Sub kBtDel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles kBtDel.Click
        DelListKey() 'удалить существующую секцию конфигурации
    End Sub
    '-----------------------------------------------------------------------------------------------------------
    'Функции закладки PartyPath
    '-----------------------------------------------------------------------------------------------------------
    Private Sub pCbPartyPath_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles pCbPartyPath.SelectedValueChanged
        'If pCbPartyPath.Items.Count = 0 Then
        '    pBtSet.Visible = True
        'Else
        '    If Trim(pCbPartyPath.Text) = "" Then
        '        pBtSet.Visible = True
        '    Else
        '        If xmlDoc.SelectSingleNode("//Default/PartyPath").InnerText <> pCbPartyPath.Text Then
        '            pBtSet.Visible = False
        '        Else
        '            pBtSet.Visible = True
        '        End If
        '    End If
        'End If
    End Sub
    Private Sub pBtFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pBtSet.Click
        GetFindParty()
    End Sub
    Private Sub pRbRegistry_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles pRbRegistry.CheckedChanged
        pBtSet.Text = "&Get"
        '     pCbPartyPath.Text = ""
        pCbPartyPath.Items.Clear()
    End Sub
    Private Sub pRbProgramFiles_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles pRbProgramFiles.CheckedChanged
        pBtSet.Text = "&Get"
        '   pCbPartyPath.Text = ""
        pCbPartyPath.Items.Clear()
    End Sub

    Private Sub pRbFolder_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles pRbFolder.CheckedChanged
        pBtSet.Text = "&Get"
        pCbPartyPath.Items.Clear()
    End Sub

    Sub pShowBtSetGet() 'скрыть/показать кнопки закладки
        If pCbPartyPath.Text = "" Then
            pBtSet.Text = "&Get"
        Else
            pBtSet.Text = "&Save"
        End If
    End Sub

    Private Sub dCbPostgreDrv_SelectedValueChanged(sender As Object, e As EventArgs) Handles dCbPostgreDrv.SelectedValueChanged
        dbTabFormUpdate()
    End Sub
    Sub dbTabFormUpdate()
        'перерисовать интерфейс выбора базы по настройкам
        If (dCbServerType.Text = "PostgreSQL" And dCbPostgreDrv.Text = "PostgreSQL (ODBC)") Or (dCbServerType.Text = "Sybase SQL Anywhere" And dCbSybaseDrv.Text = "Sybase SQL Anywhere (ODBC)") Then
            '...
            dCbODBCName.Visible = True
            dTbConnectionString.Visible = False
            lbDriverSource.Visible = True
            '...
            lbServereName.Visible = False
            dTbServerName.Visible = False
            lbDatabaseName.Visible = False
            dTbDatabaseName.Visible = False
        Else
            '...
            dCbODBCName.Visible = False
            dTbConnectionString.Visible = False
            lbDriverSource.Visible = False
            '...
            lbServereName.Visible = True
            dTbServerName.Visible = True
            lbDatabaseName.Visible = True
            dTbDatabaseName.Visible = True
        End If

    End Sub

    Private Sub dCbSybaseDrv_SelectedValueChanged(sender As Object, e As EventArgs) Handles dCbSybaseDrv.SelectedValueChanged
        dbTabFormUpdate()
    End Sub
    '-----------------------------------------------------------------------------------------------------------
    Private Sub aChbLocalKey_CheckedChanged(sender As Object, e As EventArgs) Handles aChbLocalKey.CheckedChanged
        'использовать локальные настройки ключа или настройки из бд 
        If aChbLocalKey.Checked Then
            kTbIp_name.Enabled = True
            kChbSearch.Enabled = True
        Else
            kTbIp_name.Enabled = False
            kChbSearch.Enabled = False
        End If
    End Sub

    Private Sub dCbServerType_SelectedValueChanged(sender As Object, e As EventArgs) Handles dCbServerType.SelectedValueChanged
        Select Case dCbServerType.Text                'провайдер
            Case "Microsoft SQL Server"
                '...
                lbDriverName.Visible = False
                lbDriverSource.Visible = False
                '...
                lbDriverSource.Visible = False
                dCbOracalDrv.Visible = False
                dCbPostgreDrv.Visible = False
                dCbSybaseDrv.Visible = False
                '...
                lbServereName.Visible = True
                dTbServerName.Visible = True
                lbDatabaseName.Visible = True
                dTbDatabaseName.Visible = True
            Case "Oracle"
                '...
                lbDriverName.Visible = True
                dCbServerType.Visible = True
                '...
                lbDriverSource.Visible = True
                lbDriverSource.Text = "Connecting String"
                '...
                dCbODBCName.Visible = False
                dTbConnectionString.Visible = True
                dCbOracalDrv.Visible = True
                dCbOracalDrv.Text = "Oracle 8, 8i"
                dCbPostgreDrv.Visible = False
                dCbSybaseDrv.Visible = False
                '...
                lbServereName.Visible = False
                dTbServerName.Visible = False
                lbDatabaseName.Visible = False
                dTbDatabaseName.Visible = False
            Case "PostgreSQL"
                '...
                lbDriverName.Visible = True
                dCbServerType.Visible = True
                '...
                'lbDriverSource.Visible = True
                lbDriverSource.Text = "ODBC Source"
                '...
                '   dCbODBCName.Visible = True
                ' dTbConnectionString.Visible = False
                dCbOracalDrv.Visible = False
                dCbPostgreDrv.Visible = True
                dCbPostgreDrv.Text = "PostgreSQL Unicode"
                dCbSybaseDrv.Visible = False
                '...
                '               lbServereName.Visible = False
                '               dTbServerName.Visible = False
                '               lbDatabaseName.Visible = False
                '               dTbDatabaseName.Visible = False
                dbTabFormUpdate()
            Case "Sybase SQL Anywhere"
                '...
                lbDriverName.Visible = True
                dCbServerType.Visible = True
                '...
                'lbDriverSource.Visible = True
                lbDriverSource.Text = "ODBC Source"
                '...
                dCbOracalDrv.Visible = False
                dCbPostgreDrv.Visible = False
                dCbSybaseDrv.Visible = True
                dCbSybaseDrv.Text = "Sybase SQL Anywhere (ODBC)"
                '...
                ' lbServereName.Visible = False
                ' dTbServerName.Visible = False
                ' lbDatabaseName.Visible = False
                ' dTbDatabaseName.Visible = False
                dbTabFormUpdate()

        End Select

    End Sub


End Class

