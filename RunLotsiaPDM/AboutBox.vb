Imports System.Net

Public NotInheritable Class AboutBox

    Private Sub AboutBox1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Установить заголовок формы.
        Dim ApplicationTitle As String
        If My.Application.Info.Title <> "" Then
            ApplicationTitle = My.Application.Info.Title
        Else
            ApplicationTitle = System.IO.Path.GetFileNameWithoutExtension(My.Application.Info.AssemblyName)
        End If
        Me.Text = String.Format("О программе {0}", ApplicationTitle)
        ' Инициализировать текст, отображаемый в окне "О программе".
        ' TODO: настроить сведения о сборке приложения в области "Приложение" диалогового окна 

        '    свойств проекта (в меню "Проект").
        Me.LabelProductName.Text = My.Application.Info.ProductName & ". " & _
                                   String.Format("Версия {0}", My.Application.Info.Version.ToString) & ". " & _
                                   My.Application.Info.Copyright
        'Me.LabelCompanyName.Text = "Форум по семейству систем PLM/PDM/TDM/ERP/Workflow"
        Me.LinkLabel1.Text = My.Application.Info.CompanyName
        Me.LinkLabel2.Text = "Форум по семейству систем PLM/PDM/TDM/ERP/Workflow"
        Me.Label1.Text = "Александр; СК"

        Me.TextBoxDescription.Text = My.Application.Info.Description & vbCrLf & vbCrLf &
           "предназначен для работы с ПО LotsiaPDMPlus версии 4.хх и выше" & vbCrLf &
           " - хранящей конфигурационные данные LotsiaPDMPlus в реестре HKEY_CURRENT_USER\Software\LotsiaSoft\PartY\WS.INI\DataBase\" & vbCrLf &
           "(существование отдельного файла ws.ini в данном случае недопустимо, поскольку он имеет приоритет по настройкам перед реестром)" & vbCrLf &
           " - и использующей ключ аппаратной защиты компании Guardant с конфигурационным файлом gnclient.ini расположенном в каталоге с исполняемым файлом LotsiaPDMPlus (partyp.exe) или без файла gnclient.ini с нвстройками ключа непосредственно в БД" & vbCrLf & vbCrLf &
           "поддерживает 'горячие' клавиши:" & vbCrLf &
           " F1     - справка" & vbCrLf &
           " F2     - редактирование конфигураций" & vbCrLf &
           " Enter  - соединение с БД по конфигурации указанной на закладке Account" & vbCrLf &
           " Esc    - выход из программы без сохранения параметров" & vbCrLf & vbCrLf &
           "Закладка Account:" & vbCrLf &
           " (пользовательские настройки, используются ранее сохраненные значения и значения по умолчанию)" & vbCrLf &
           " - Выбор из списка доступных конфигураций для БД и ключа аппаратной защиты" & vbCrLf &
           " - Ввод логина и пароля или использование интегрированных значений" & vbCrLf &
           " - При наличии/установке всех значений:" & vbCrLf &
           "    * Путь к каталогу с исполняемым файлом программы и ключа" & vbCrLf &
           "    * Конфигурация БД" & vbCrLf &
           "    * Конфигурация ключа аппаратной защиты" & vbCrLf &
           "    * Логин" & vbCrLf &
           "    * Пароль" & vbCrLf &
           "    по кнопке Connect - запуск Lotsia PDM Plus в режиме cmd (:\>partyp.exe с параметрами)" & vbCrLf &
           "    с сохранением текущих настроек:" & vbCrLf &
           "        * в конфигурационном файле " & My.Resources.xmlFileName & " в секции Default" & vbCrLf &
           "        * в системном реестре (логин, флаг Integrated)" & vbCrLf &
           "        ** опционально - в конфигурационном файле ключа gnclient.ini - ключи IP_Name, Search" & vbCrLf & vbCrLf &
           " Кнопка F2 или правая кнопка мыши - включение/выключение режима редактирования конфигураций" & vbCrLf &
           " (административные настройки, создание/удаление конфигураций для БД и ключа аппаратной защиты)" & vbCrLf & vbCrLf &
           "Закладка Account:" & vbCrLf &
           "(дополнительно к базовым параметрам):" & vbCrLf &
           " - Кнопка Exit (сохранение текущих значений в файле конфигурации, реестре, файле ключа и выход из программы)" & vbCrLf &
           " - Кнопка Open (сохранение текущих значений в файле конфигурации, реестре, файле ключа и запуск Lotsia PDM Plus в режиме cmd (:\>partyp.exe без параметров))" & vbCrLf & vbCrLf &
           "Закладка Lotsia Database:" & vbCrLf &
           " Создание/Удаление конфигураций для БД Лоции в конфигурационном файле " & My.Resources.xmlFileName & vbCrLf &
           " (полное дублирование окна настроек Lotsia PDM Plus... насколько это возможно ;-) за исключением раздела ODBS -не на чем было отладить)" & vbCrLf &
           " - Кнопка Save (создание/обновление новой/существующей конфигурации) - введите наименование в поле Description" & vbCrLf &
           "     * в случае если конфигурация с данным именем присутствует в конфигурационном файле - она будет обновлена" & vbCrLf &
           "     * в случае если конфигурация с данным именем отсутствует в конфигурационном файле - она будет создана" & vbCrLf &
           "     * в случае использования источников ODBC - выводятся все зарегистрированные в системе DSN (без фильтрации по типу поставщика PostreSQL, Sybase и т.д.)" & vbCrLf &
           "       - DSN for 64-bit drivers: HKEY_LOCAL_MACHINE\SOFTWARE\Odbc\Odbc.INI\Odbc Data Sources" & vbCrLf &
           "       - DSN for 32-bit drivers: HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\Odbc\Odbc.INI\Odbc Data Sources" & vbCrLf &
           " - Кнопка Del (удаление существующей конфигурации)" & vbCrLf &
           "     * доступна, если конфигурация с данным именем присутствует в конфигурационном файле" & vbCrLf & vbCrLf &
           "Закладка Guardant Key:" & vbCrLf &
           " Создание/Удаление конфигураций для ключа аппаратной защиты Guardant в файле " & My.Resources.xmlFileName & vbCrLf &
           " - Кнопка Save (создание/обновление новой/существующей конфигурации) - введите наименование в поле Description" & vbCrLf &
           "     * в случае если конфигурация с данным именем присутствует в конфигурационном файле - она будет обновлена" & vbCrLf &
           "     * в случае если конфигурация с данным именем отсутствует в конфигурационном файле - она будет создана" & vbCrLf &
           "     * в случае если используются настройки ключа в БД - настройки данного раздела игнорируются" & vbCrLf &
           " - Кнопка Del (удаление существующей конфигурации)" & vbCrLf &
           "     * доступна, если конфигурация с данным именем присутствует в конфигурационном файле" & vbCrLf & vbCrLf &
           "Закладка PartyPath:" & vbCrLf &
           " Выбор пути расположения исполняемого файла прогаммы Lotsia PDM Plus и конфигурационного файла ключа аппаратной защиты" & vbCrLf &
           " - Кнопка Get в комбинации с переключателем" & vbCrLf &
           "     * Registry - читает путь из реестра HKEY_CLASSES_ROOT\ODMA32\PartyArc" & vbCrLf &
           "     * ProgramFiles (32/64) - ищет путь в 32 разрядном каталогае %Programm Files%" & vbCrLf &
           "     * Folder - позволяет выбрать путь вручную" & vbCrLf &
           " - Кнопка Save (сохранение существующего пути в файле " & My.Resources.xmlFileName & " )" & vbCrLf & vbCrLf &
           "ps" & vbCrLf &
           "в случае отсутствия конфигурационного файла (в случае его использования)" & My.Resources.xmlFileName & " - он будет создан автоматически, в каталоге расположения программы, при первом сохранении параметров"
    End Sub

    Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OKButton.Click
        Me.Close()
    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        ' Specify that the link was visited.
        Me.LinkLabel1.LinkVisited = True
        ' Navigate to a URL.
        System.Diagnostics.Process.Start(My.Resources.webRIC)

    End Sub

    Private Sub LinkLabel2_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        ' Specify that the link was visited.
        Me.LinkLabel2.LinkVisited = True
        ' Navigate to a URL.
        System.Diagnostics.Process.Start(My.Resources.webForum)
    End Sub
End Class
