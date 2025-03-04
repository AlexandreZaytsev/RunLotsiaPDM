<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
    Inherits System.Windows.Forms.Form

    'Форма переопределяет dispose для очистки списка компонентов.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Является обязательной для конструктора форм Windows Forms
    Private components As System.ComponentModel.IContainer

    'Примечание: следующая процедура является обязательной для конструктора форм Windows Forms
    'Для ее изменения используйте конструктор форм Windows Form.  
    'Не изменяйте ее в редакторе исходного кода.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.aBtOpen = New System.Windows.Forms.Button()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.aBtExit = New System.Windows.Forms.Button()
        Me.aChbAutoLogon = New System.Windows.Forms.CheckBox()
        Me.aBtConnect = New System.Windows.Forms.Button()
        Me.aTbPassword = New System.Windows.Forms.TextBox()
        Me.aTbUserID = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.aCbKey = New System.Windows.Forms.ComboBox()
        Me.aCbDatabase = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.dCbDesc = New System.Windows.Forms.ComboBox()
        Me.dBtSave = New System.Windows.Forms.Button()
        Me.dBtDel = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.dTbDatabaseName = New System.Windows.Forms.TextBox()
        Me.dCbServerType = New System.Windows.Forms.ComboBox()
        Me.dLbExtParameters = New System.Windows.Forms.Label()
        Me.dTbServerName = New System.Windows.Forms.TextBox()
        Me.lbDriverSource = New System.Windows.Forms.Label()
        Me.dCbPostgreDrv = New System.Windows.Forms.ComboBox()
        Me.lbDatabaseName = New System.Windows.Forms.Label()
        Me.lbDriverName = New System.Windows.Forms.Label()
        Me.dCbOracalDrv = New System.Windows.Forms.ComboBox()
        Me.dTbConnectionString = New System.Windows.Forms.TextBox()
        Me.dChbAutoLogon = New System.Windows.Forms.CheckBox()
        Me.dCbSybaseDrv = New System.Windows.Forms.ComboBox()
        Me.lbServereName = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.dTbParameters = New System.Windows.Forms.TextBox()
        Me.dCbODBCName = New System.Windows.Forms.ComboBox()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.aChbLocalKey = New System.Windows.Forms.CheckBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.kCbDesc = New System.Windows.Forms.ComboBox()
        Me.kBtSave = New System.Windows.Forms.Button()
        Me.kBtDel = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.kChbSearch = New System.Windows.Forms.CheckBox()
        Me.kTbIp_name = New System.Windows.Forms.TextBox()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.pRbFolder = New System.Windows.Forms.RadioButton()
        Me.pRbProgramFiles = New System.Windows.Forms.RadioButton()
        Me.pRbRegistry = New System.Windows.Forms.RadioButton()
        Me.pBtSet = New System.Windows.Forms.Button()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.pCbPartyPath = New System.Windows.Forms.ComboBox()
        Me.OpenPartyPath = New System.Windows.Forms.OpenFileDialog()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.HotTrack = True
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(359, 236)
        Me.TabControl1.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.SystemColors.Control
        Me.TabPage1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.TabPage1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TabPage1.Controls.Add(Me.aBtOpen)
        Me.TabPage1.Controls.Add(Me.Label11)
        Me.TabPage1.Controls.Add(Me.aBtExit)
        Me.TabPage1.Controls.Add(Me.aChbAutoLogon)
        Me.TabPage1.Controls.Add(Me.aBtConnect)
        Me.TabPage1.Controls.Add(Me.aTbPassword)
        Me.TabPage1.Controls.Add(Me.aTbUserID)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.GroupBox3)
        Me.TabPage1.Controls.Add(Me.GroupBox4)
        Me.TabPage1.ImageKey = "(отсутствует)"
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(351, 210)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Account"
        '
        'aBtOpen
        '
        Me.aBtOpen.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.aBtOpen.Location = New System.Drawing.Point(181, 110)
        Me.aBtOpen.Name = "aBtOpen"
        Me.aBtOpen.Size = New System.Drawing.Size(78, 24)
        Me.aBtOpen.TabIndex = 7
        Me.aBtOpen.Text = "&Open"
        Me.aBtOpen.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(10, 115)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(53, 13)
        Me.Label11.TabIndex = 14
        Me.Label11.Text = "Save and"
        '
        'aBtExit
        '
        Me.aBtExit.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.aBtExit.Location = New System.Drawing.Point(97, 110)
        Me.aBtExit.Name = "aBtExit"
        Me.aBtExit.Size = New System.Drawing.Size(78, 24)
        Me.aBtExit.TabIndex = 6
        Me.aBtExit.Text = "&Exit"
        Me.aBtExit.UseVisualStyleBackColor = True
        '
        'aChbAutoLogon
        '
        Me.aChbAutoLogon.AutoSize = True
        Me.aChbAutoLogon.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.aChbAutoLogon.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.aChbAutoLogon.Location = New System.Drawing.Point(208, 64)
        Me.aChbAutoLogon.Name = "aChbAutoLogon"
        Me.aChbAutoLogon.Size = New System.Drawing.Size(131, 18)
        Me.aChbAutoLogon.TabIndex = 3
        Me.aChbAutoLogon.Text = "Use Integrated Login"
        Me.aChbAutoLogon.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.aChbAutoLogon.UseVisualStyleBackColor = True
        '
        'aBtConnect
        '
        Me.aBtConnect.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.aBtConnect.Location = New System.Drawing.Point(265, 110)
        Me.aBtConnect.Name = "aBtConnect"
        Me.aBtConnect.Size = New System.Drawing.Size(78, 24)
        Me.aBtConnect.TabIndex = 0
        Me.aBtConnect.Text = "&Connect"
        Me.aBtConnect.UseVisualStyleBackColor = True
        '
        'aTbPassword
        '
        Me.aTbPassword.Location = New System.Drawing.Point(227, 83)
        Me.aTbPassword.Name = "aTbPassword"
        Me.aTbPassword.Size = New System.Drawing.Size(112, 20)
        Me.aTbPassword.TabIndex = 5
        Me.aTbPassword.UseSystemPasswordChar = True
        '
        'aTbUserID
        '
        Me.aTbUserID.Location = New System.Drawing.Point(65, 83)
        Me.aTbUserID.Name = "aTbUserID"
        Me.aTbUserID.Size = New System.Drawing.Size(97, 20)
        Me.aTbUserID.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(10, 83)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(33, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Login"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.GroupBox3.Location = New System.Drawing.Point(3, 67)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(341, 42)
        Me.GroupBox3.TabIndex = 11
        Me.GroupBox3.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(165, 19)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(53, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Password"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.aCbKey)
        Me.GroupBox4.Controls.Add(Me.aCbDatabase)
        Me.GroupBox4.Controls.Add(Me.Label1)
        Me.GroupBox4.Controls.Add(Me.Label2)
        Me.GroupBox4.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.GroupBox4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.GroupBox4.Location = New System.Drawing.Point(3, 0)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(341, 63)
        Me.GroupBox4.TabIndex = 1
        Me.GroupBox4.TabStop = False
        '
        'aCbKey
        '
        Me.aCbKey.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.aCbKey.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.aCbKey.FormattingEnabled = True
        Me.aCbKey.Location = New System.Drawing.Point(62, 36)
        Me.aCbKey.Name = "aCbKey"
        Me.aCbKey.Size = New System.Drawing.Size(275, 21)
        Me.aCbKey.TabIndex = 2
        '
        'aCbDatabase
        '
        Me.aCbDatabase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.aCbDatabase.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.aCbDatabase.FormattingEnabled = True
        Me.aCbDatabase.Location = New System.Drawing.Point(62, 11)
        Me.aCbDatabase.Name = "aCbDatabase"
        Me.aCbDatabase.Size = New System.Drawing.Size(275, 21)
        Me.aCbDatabase.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Database"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(7, 39)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(25, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Key"
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.SystemColors.Control
        Me.TabPage2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.TabPage2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TabPage2.Controls.Add(Me.Label5)
        Me.TabPage2.Controls.Add(Me.dCbDesc)
        Me.TabPage2.Controls.Add(Me.dBtSave)
        Me.TabPage2.Controls.Add(Me.dBtDel)
        Me.TabPage2.Controls.Add(Me.GroupBox1)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(351, 210)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Lotsia Database"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(10, 9)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(89, 13)
        Me.Label5.TabIndex = 21
        Me.Label5.Text = "Description name"
        '
        'dCbDesc
        '
        Me.dCbDesc.FormattingEnabled = True
        Me.dCbDesc.Location = New System.Drawing.Point(109, 6)
        Me.dCbDesc.Name = "dCbDesc"
        Me.dCbDesc.Size = New System.Drawing.Size(229, 21)
        Me.dCbDesc.TabIndex = 9
        '
        'dBtSave
        '
        Me.dBtSave.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.dBtSave.Location = New System.Drawing.Point(265, 171)
        Me.dBtSave.Name = "dBtSave"
        Me.dBtSave.Size = New System.Drawing.Size(78, 24)
        Me.dBtSave.TabIndex = 12
        Me.dBtSave.Text = "&Save"
        Me.dBtSave.UseVisualStyleBackColor = True
        '
        'dBtDel
        '
        Me.dBtDel.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.dBtDel.Location = New System.Drawing.Point(181, 171)
        Me.dBtDel.Name = "dBtDel"
        Me.dBtDel.Size = New System.Drawing.Size(78, 24)
        Me.dBtDel.TabIndex = 11
        Me.dBtDel.Text = "&Del"
        Me.dBtDel.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox1.Controls.Add(Me.dTbDatabaseName)
        Me.GroupBox1.Controls.Add(Me.dCbServerType)
        Me.GroupBox1.Controls.Add(Me.dLbExtParameters)
        Me.GroupBox1.Controls.Add(Me.dTbServerName)
        Me.GroupBox1.Controls.Add(Me.lbDriverSource)
        Me.GroupBox1.Controls.Add(Me.dCbPostgreDrv)
        Me.GroupBox1.Controls.Add(Me.lbDatabaseName)
        Me.GroupBox1.Controls.Add(Me.lbDriverName)
        Me.GroupBox1.Controls.Add(Me.dCbOracalDrv)
        Me.GroupBox1.Controls.Add(Me.dTbConnectionString)
        Me.GroupBox1.Controls.Add(Me.dChbAutoLogon)
        Me.GroupBox1.Controls.Add(Me.dCbSybaseDrv)
        Me.GroupBox1.Controls.Add(Me.lbServereName)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.dTbParameters)
        Me.GroupBox1.Controls.Add(Me.dCbODBCName)
        Me.GroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.GroupBox1.Location = New System.Drawing.Point(2, 25)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(341, 146)
        Me.GroupBox1.TabIndex = 10
        Me.GroupBox1.TabStop = False
        '
        'dTbDatabaseName
        '
        Me.dTbDatabaseName.Location = New System.Drawing.Point(107, 75)
        Me.dTbDatabaseName.Name = "dTbDatabaseName"
        Me.dTbDatabaseName.Size = New System.Drawing.Size(229, 20)
        Me.dTbDatabaseName.TabIndex = 4
        '
        'dCbServerType
        '
        Me.dCbServerType.BackColor = System.Drawing.SystemColors.Window
        Me.dCbServerType.DisplayMember = "Microsoft SQL Server"
        Me.dCbServerType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.dCbServerType.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.dCbServerType.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.dCbServerType.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.dCbServerType.FormattingEnabled = True
        Me.dCbServerType.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.dCbServerType.Items.AddRange(New Object() {"Microsoft SQL Server", "Oracle", "PostgreSQL", "Sybase SQL Anywhere"})
        Me.dCbServerType.Location = New System.Drawing.Point(107, 6)
        Me.dCbServerType.Name = "dCbServerType"
        Me.dCbServerType.Size = New System.Drawing.Size(229, 21)
        Me.dCbServerType.TabIndex = 1
        Me.ToolTip1.SetToolTip(Me.dCbServerType, "поставщик данных")
        '
        'dLbExtParameters
        '
        Me.dLbExtParameters.AutoSize = True
        Me.dLbExtParameters.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.dLbExtParameters.Location = New System.Drawing.Point(8, 99)
        Me.dLbExtParameters.Name = "dLbExtParameters"
        Me.dLbExtParameters.Size = New System.Drawing.Size(92, 13)
        Me.dLbExtParameters.TabIndex = 18
        Me.dLbExtParameters.Text = "Ext Parameters"
        '
        'dTbServerName
        '
        Me.dTbServerName.Location = New System.Drawing.Point(107, 52)
        Me.dTbServerName.Name = "dTbServerName"
        Me.dTbServerName.Size = New System.Drawing.Size(229, 20)
        Me.dTbServerName.TabIndex = 16
        '
        'lbDriverSource
        '
        Me.lbDriverSource.AutoSize = True
        Me.lbDriverSource.Location = New System.Drawing.Point(8, 54)
        Me.lbDriverSource.Name = "lbDriverSource"
        Me.lbDriverSource.Size = New System.Drawing.Size(16, 13)
        Me.lbDriverSource.TabIndex = 15
        Me.lbDriverSource.Text = "..."
        '
        'dCbPostgreDrv
        '
        Me.dCbPostgreDrv.AutoCompleteCustomSource.AddRange(New String() {"PostgreSQL (ODBC)", "PostgreSQL Unicode"})
        Me.dCbPostgreDrv.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.dCbPostgreDrv.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.dCbPostgreDrv.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.dCbPostgreDrv.FormattingEnabled = True
        Me.dCbPostgreDrv.Items.AddRange(New Object() {"PostgreSQL (ODBC)", "PostgreSQL Unicode"})
        Me.dCbPostgreDrv.Location = New System.Drawing.Point(107, 28)
        Me.dCbPostgreDrv.Name = "dCbPostgreDrv"
        Me.dCbPostgreDrv.Size = New System.Drawing.Size(229, 21)
        Me.dCbPostgreDrv.TabIndex = 19
        Me.ToolTip1.SetToolTip(Me.dCbPostgreDrv, "тип драйвера Postgre")
        '
        'lbDatabaseName
        '
        Me.lbDatabaseName.AutoSize = True
        Me.lbDatabaseName.Location = New System.Drawing.Point(8, 78)
        Me.lbDatabaseName.Name = "lbDatabaseName"
        Me.lbDatabaseName.Size = New System.Drawing.Size(84, 13)
        Me.lbDatabaseName.TabIndex = 15
        Me.lbDatabaseName.Text = "Database Name"
        '
        'lbDriverName
        '
        Me.lbDriverName.AutoSize = True
        Me.lbDriverName.Location = New System.Drawing.Point(8, 32)
        Me.lbDriverName.Name = "lbDriverName"
        Me.lbDriverName.Size = New System.Drawing.Size(73, 13)
        Me.lbDriverName.TabIndex = 17
        Me.lbDriverName.Text = "Driver Version"
        '
        'dCbOracalDrv
        '
        Me.dCbOracalDrv.AutoCompleteCustomSource.AddRange(New String() {"Oracle 8/8i", "Oracle 9.0.1"})
        Me.dCbOracalDrv.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.dCbOracalDrv.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.dCbOracalDrv.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.dCbOracalDrv.FormattingEnabled = True
        Me.dCbOracalDrv.Items.AddRange(New Object() {"Oracle 8/8i", "Oracle 9.0.1", "Oracle 9i", "Oracle 10g", "Oracle 11g"})
        Me.dCbOracalDrv.Location = New System.Drawing.Point(107, 28)
        Me.dCbOracalDrv.Name = "dCbOracalDrv"
        Me.dCbOracalDrv.Size = New System.Drawing.Size(229, 21)
        Me.dCbOracalDrv.TabIndex = 2
        Me.ToolTip1.SetToolTip(Me.dCbOracalDrv, "тип драйвера Oracal")
        '
        'dTbConnectionString
        '
        Me.dTbConnectionString.Location = New System.Drawing.Point(107, 52)
        Me.dTbConnectionString.Name = "dTbConnectionString"
        Me.dTbConnectionString.Size = New System.Drawing.Size(229, 20)
        Me.dTbConnectionString.TabIndex = 3
        Me.ToolTip1.SetToolTip(Me.dTbConnectionString, "строка соединения")
        '
        'dChbAutoLogon
        '
        Me.dChbAutoLogon.AutoSize = True
        Me.dChbAutoLogon.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.dChbAutoLogon.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.dChbAutoLogon.Location = New System.Drawing.Point(93, 117)
        Me.dChbAutoLogon.Name = "dChbAutoLogon"
        Me.dChbAutoLogon.Size = New System.Drawing.Size(243, 18)
        Me.dChbAutoLogon.TabIndex = 6
        Me.dChbAutoLogon.Text = "No request the password (Use Windows NT)"
        Me.dChbAutoLogon.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.dChbAutoLogon, "Не запрашивать пароль (входить автоматически)")
        Me.dChbAutoLogon.UseVisualStyleBackColor = True
        '
        'dCbSybaseDrv
        '
        Me.dCbSybaseDrv.AutoCompleteCustomSource.AddRange(New String() {"Sybase SQL Anywhere (ODBC)", "Sybase SQL Anywhere 5.0", "Adaptive Server Anywhere 6.0", "Adaptive Server Anywhere 7.0", "Adaptive Server Anywhere 8.0", "Adaptive Server Anywhere 9.0", "SQL Anywhere 10"})
        Me.dCbSybaseDrv.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.dCbSybaseDrv.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.dCbSybaseDrv.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.dCbSybaseDrv.FormattingEnabled = True
        Me.dCbSybaseDrv.Items.AddRange(New Object() {"Sybase SQL Anywhere (ODBC)", "Sybase SQL Anywhere 5.0", "Adaptive Server Anywhere 6.0", "Adaptive Server Anywhere 7.0", "Adaptive Server Anywhere 8.0", "Adaptive Server Anywhere 9.0", "SQL Anywhere 10", "SQL Anywhere 11", "SQL Anywhere 12", "SQL Anywhere 16", "SQL Anywhere 17"})
        Me.dCbSybaseDrv.Location = New System.Drawing.Point(107, 28)
        Me.dCbSybaseDrv.Name = "dCbSybaseDrv"
        Me.dCbSybaseDrv.Size = New System.Drawing.Size(229, 21)
        Me.dCbSybaseDrv.TabIndex = 2
        Me.ToolTip1.SetToolTip(Me.dCbSybaseDrv, "тип драйвера Sybase")
        '
        'lbServereName
        '
        Me.lbServereName.AutoSize = True
        Me.lbServereName.Location = New System.Drawing.Point(8, 55)
        Me.lbServereName.Name = "lbServereName"
        Me.lbServereName.Size = New System.Drawing.Size(94, 13)
        Me.lbServereName.TabIndex = 17
        Me.lbServereName.Text = "Server Name or IP"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label8.Location = New System.Drawing.Point(8, 9)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(72, 13)
        Me.Label8.TabIndex = 12
        Me.Label8.Text = "Server type"
        '
        'dTbParameters
        '
        Me.dTbParameters.Location = New System.Drawing.Point(107, 96)
        Me.dTbParameters.Name = "dTbParameters"
        Me.dTbParameters.Size = New System.Drawing.Size(229, 20)
        Me.dTbParameters.TabIndex = 5
        '
        'dCbODBCName
        '
        Me.dCbODBCName.FormattingEnabled = True
        Me.dCbODBCName.Location = New System.Drawing.Point(107, 52)
        Me.dCbODBCName.Name = "dCbODBCName"
        Me.dCbODBCName.Size = New System.Drawing.Size(229, 21)
        Me.dCbODBCName.TabIndex = 3
        Me.ToolTip1.SetToolTip(Me.dCbODBCName, "ODBC источник данных")
        '
        'TabPage3
        '
        Me.TabPage3.BackColor = System.Drawing.SystemColors.Control
        Me.TabPage3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.TabPage3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TabPage3.Controls.Add(Me.aChbLocalKey)
        Me.TabPage3.Controls.Add(Me.Label10)
        Me.TabPage3.Controls.Add(Me.kCbDesc)
        Me.TabPage3.Controls.Add(Me.kBtSave)
        Me.TabPage3.Controls.Add(Me.kBtDel)
        Me.TabPage3.Controls.Add(Me.GroupBox2)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(351, 210)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Guardant Key"
        '
        'aChbLocalKey
        '
        Me.aChbLocalKey.AutoSize = True
        Me.aChbLocalKey.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.aChbLocalKey.Checked = True
        Me.aChbLocalKey.CheckState = System.Windows.Forms.CheckState.Checked
        Me.aChbLocalKey.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.aChbLocalKey.Location = New System.Drawing.Point(204, 29)
        Me.aChbLocalKey.Name = "aChbLocalKey"
        Me.aChbLocalKey.Size = New System.Drawing.Size(133, 18)
        Me.aChbLocalKey.TabIndex = 27
        Me.aChbLocalKey.Text = "Use Local gnclient.ini"
        Me.aChbLocalKey.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.aChbLocalKey, "Использовать локальный файл ключа или настройки из БД")
        Me.aChbLocalKey.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(10, 9)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(89, 13)
        Me.Label10.TabIndex = 26
        Me.Label10.Text = "Description name"
        '
        'kCbDesc
        '
        Me.kCbDesc.FormattingEnabled = True
        Me.kCbDesc.Location = New System.Drawing.Point(109, 6)
        Me.kCbDesc.Name = "kCbDesc"
        Me.kCbDesc.Size = New System.Drawing.Size(229, 21)
        Me.kCbDesc.TabIndex = 13
        '
        'kBtSave
        '
        Me.kBtSave.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.kBtSave.Location = New System.Drawing.Point(265, 91)
        Me.kBtSave.Name = "kBtSave"
        Me.kBtSave.Size = New System.Drawing.Size(78, 24)
        Me.kBtSave.TabIndex = 16
        Me.kBtSave.Text = "&Save"
        Me.kBtSave.UseVisualStyleBackColor = True
        '
        'kBtDel
        '
        Me.kBtDel.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.kBtDel.Location = New System.Drawing.Point(181, 91)
        Me.kBtDel.Name = "kBtDel"
        Me.kBtDel.Size = New System.Drawing.Size(78, 24)
        Me.kBtDel.TabIndex = 15
        Me.kBtDel.Text = "&Del"
        Me.kBtDel.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.kChbSearch)
        Me.GroupBox2.Controls.Add(Me.kTbIp_name)
        Me.GroupBox2.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.GroupBox2.Location = New System.Drawing.Point(3, 31)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(341, 59)
        Me.GroupBox2.TabIndex = 14
        Me.GroupBox2.TabStop = False
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(7, 19)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(94, 13)
        Me.Label14.TabIndex = 4
        Me.Label14.Text = "Server Name or IP"
        '
        'kChbSearch
        '
        Me.kChbSearch.AutoSize = True
        Me.kChbSearch.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.kChbSearch.Location = New System.Drawing.Point(10, 39)
        Me.kChbSearch.Name = "kChbSearch"
        Me.kChbSearch.Size = New System.Drawing.Size(203, 18)
        Me.kChbSearch.TabIndex = 2
        Me.kChbSearch.Text = "Broadcasting search (ON by default)"
        Me.kChbSearch.UseVisualStyleBackColor = True
        '
        'kTbIp_name
        '
        Me.kTbIp_name.Location = New System.Drawing.Point(106, 16)
        Me.kTbIp_name.Name = "kTbIp_name"
        Me.kTbIp_name.Size = New System.Drawing.Size(229, 20)
        Me.kTbIp_name.TabIndex = 1
        '
        'TabPage4
        '
        Me.TabPage4.BackColor = System.Drawing.SystemColors.Control
        Me.TabPage4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.TabPage4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TabPage4.Controls.Add(Me.pRbFolder)
        Me.TabPage4.Controls.Add(Me.pRbProgramFiles)
        Me.TabPage4.Controls.Add(Me.pRbRegistry)
        Me.TabPage4.Controls.Add(Me.pBtSet)
        Me.TabPage4.Controls.Add(Me.GroupBox5)
        Me.TabPage4.Location = New System.Drawing.Point(4, 22)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Size = New System.Drawing.Size(351, 210)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "PartyPath"
        '
        'pRbFolder
        '
        Me.pRbFolder.AutoSize = True
        Me.pRbFolder.Location = New System.Drawing.Point(208, 43)
        Me.pRbFolder.Name = "pRbFolder"
        Me.pRbFolder.Size = New System.Drawing.Size(54, 17)
        Me.pRbFolder.TabIndex = 20
        Me.pRbFolder.Text = "Folder"
        Me.pRbFolder.UseVisualStyleBackColor = True
        '
        'pRbProgramFiles
        '
        Me.pRbProgramFiles.AutoSize = True
        Me.pRbProgramFiles.Location = New System.Drawing.Point(77, 43)
        Me.pRbProgramFiles.Name = "pRbProgramFiles"
        Me.pRbProgramFiles.Size = New System.Drawing.Size(123, 17)
        Me.pRbProgramFiles.TabIndex = 19
        Me.pRbProgramFiles.Text = "ProgramFiles (32/64)"
        Me.pRbProgramFiles.UseVisualStyleBackColor = True
        '
        'pRbRegistry
        '
        Me.pRbRegistry.AutoSize = True
        Me.pRbRegistry.Checked = True
        Me.pRbRegistry.Location = New System.Drawing.Point(8, 43)
        Me.pRbRegistry.Name = "pRbRegistry"
        Me.pRbRegistry.Size = New System.Drawing.Size(63, 17)
        Me.pRbRegistry.TabIndex = 18
        Me.pRbRegistry.TabStop = True
        Me.pRbRegistry.Text = "Registry"
        Me.pRbRegistry.UseVisualStyleBackColor = True
        '
        'pBtSet
        '
        Me.pBtSet.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.pBtSet.Location = New System.Drawing.Point(265, 39)
        Me.pBtSet.Name = "pBtSet"
        Me.pBtSet.Size = New System.Drawing.Size(78, 24)
        Me.pBtSet.TabIndex = 17
        Me.pBtSet.Text = "&Get"
        Me.pBtSet.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.pCbPartyPath)
        Me.GroupBox5.Location = New System.Drawing.Point(3, 0)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(341, 39)
        Me.GroupBox5.TabIndex = 0
        Me.GroupBox5.TabStop = False
        '
        'pCbPartyPath
        '
        Me.pCbPartyPath.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pCbPartyPath.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.pCbPartyPath.FormattingEnabled = True
        Me.pCbPartyPath.Location = New System.Drawing.Point(3, 11)
        Me.pCbPartyPath.Name = "pCbPartyPath"
        Me.pCbPartyPath.Size = New System.Drawing.Size(333, 21)
        Me.pCbPartyPath.TabIndex = 0
        '
        'OpenPartyPath
        '
        Me.OpenPartyPath.DefaultExt = "exe"
        Me.OpenPartyPath.Filter = "Party file|Partyp.exe"
        Me.OpenPartyPath.Title = "Укажите месторасположение исполняемого файла Partyp.exe"
        '
        'MainForm
        '
        Me.AcceptButton = Me.aBtConnect
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ClientSize = New System.Drawing.Size(359, 236)
        Me.Controls.Add(Me.TabControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "MainForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Config and Run Lotsia PDM"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.TabPage4.ResumeLayout(False)
        Me.TabPage4.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents aTbPassword As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents aTbUserID As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents aCbKey As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents aCbDatabase As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dCbDesc As System.Windows.Forms.ComboBox
    Friend WithEvents dTbConnectionString As System.Windows.Forms.TextBox
    Friend WithEvents dBtSave As System.Windows.Forms.Button
    Friend WithEvents dBtDel As System.Windows.Forms.Button
    Friend WithEvents dCbServerType As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents dChbAutoLogon As System.Windows.Forms.CheckBox
    Friend WithEvents dCbOracalDrv As System.Windows.Forms.ComboBox
    Friend WithEvents dCbSybaseDrv As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dLbExtParameters As System.Windows.Forms.Label
    Friend WithEvents lbDatabaseName As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents kCbDesc As System.Windows.Forms.ComboBox
    Friend WithEvents kBtSave As System.Windows.Forms.Button
    Friend WithEvents kBtDel As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents kChbSearch As System.Windows.Forms.CheckBox
    Friend WithEvents kTbIp_name As System.Windows.Forms.TextBox
    Friend WithEvents aChbAutoLogon As System.Windows.Forms.CheckBox
    Friend WithEvents aBtConnect As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents aBtExit As System.Windows.Forms.Button
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents dTbDatabaseName As System.Windows.Forms.TextBox
    Friend WithEvents dTbParameters As System.Windows.Forms.TextBox
    Friend WithEvents dCbODBCName As System.Windows.Forms.ComboBox
    Friend WithEvents aBtOpen As System.Windows.Forms.Button
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents pCbPartyPath As System.Windows.Forms.ComboBox
    Friend WithEvents pBtSet As System.Windows.Forms.Button
    Friend WithEvents pRbFolder As System.Windows.Forms.RadioButton
    Friend WithEvents pRbProgramFiles As System.Windows.Forms.RadioButton
    Friend WithEvents pRbRegistry As System.Windows.Forms.RadioButton
    Friend WithEvents OpenPartyPath As System.Windows.Forms.OpenFileDialog
    Friend WithEvents dCbPostgreDrv As ComboBox
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents dTbServerName As TextBox
    Friend WithEvents lbServereName As Label
    Friend WithEvents lbDriverName As Label
    Friend WithEvents lbDriverSource As Label
    Friend WithEvents aChbLocalKey As CheckBox
End Class
