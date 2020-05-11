Imports Microsoft.Win32
Imports ns.biz
Imports ns.ent
Imports Microsoft.Win32.Registry
Imports System.IO
Public Class preferencias
    Private Sub btnmini_Click(sender As Object, e As EventArgs) Handles btnmini.Click
        Try
            Me.WindowState = FormWindowState.Minimized
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnclose_Click(sender As Object, e As EventArgs) Handles btnclose.Click
        Try
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btncancelar_Click(sender As Object, e As EventArgs) Handles btncancelar.Click
        Try
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click
        Dim lo_amb As String = ""
        Try

            If IsNothing(Comboambientes.SelectedItem) Then
                lo_amb = ""
            Else
                lo_amb = Comboambientes.SelectedItem.ToString
            End If
            Registry.SetValue("HKEY_CURRENT_USER\Software\sql_instaler", "Ambiente_Prefencia_SQL_Instal", lo_amb)

            'Inicio con windows
            If CheckBox1.Checked = True Then
                start_Up(True)
            Else
                start_Up(False)
            End If

            'Guarda directorio de base de datos 
            Registry.SetValue("HKEY_CURRENT_USER\Software\sql_instaler", "bd_SQL_Instaler", txtubibd.Text)

            Me.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnagregaramb_Click(sender As Object, e As EventArgs) Handles btnagregaramb.Click
        Try
            'Administrador_de_ambientes.ShowDialog()

            Dim Form_administrador_amb As New Administrador_de_ambientes
            Form_administrador_amb.ShowDialog()
            Form_administrador_amb.Dispose()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub preferencias_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim lo_biz As New biz_preferencias
        Dim lo_ret As New ent_preferencias
        'inicio con windows
        'Registry
        Const CLAVE As String = "SOFTWARE\Microsoft\Windows\CurrentVersion\Run"
        'ProductName : el nombre del programa.  
        Dim subClave As String = Application.ProductName.ToString
        Dim Registro As RegistryKey = CurrentUser.CreateSubKey(CLAVE, RegistryKeyPermissionCheck.ReadWriteSubTree)
        Try

            lo_ret = lo_biz.f_traer_ambiente()

            Comboambientes.Items.Clear()

            For i As Integer = 0 To lo_ret.p_is_ambiente_o.Count - 1
                Comboambientes.Items.Add(lo_ret.p_is_ambiente_o.Item(i))
            Next

            Comboambientes.SelectedItem = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\sql_instaler", "Ambiente_Prefencia_SQL_Instal", Nothing)

            If Comboambientes.Items.Count > 0 Then

                btneditaramb.Visible = True
                btndropamb.Visible = True

            Else

                btneditaramb.Visible = False
                btndropamb.Visible = False

            End If

            Comboambientes.TabStop = False

            'Check de inicio de windows
            If IsNothing(My.Computer.Registry.GetValue(Registro.Name, subClave, Nothing)) Then
                CheckBox1.Checked = False
            Else
                CheckBox1.Checked = True
            End If

            'Texbox de ubicación de base de datos
            txtubibd.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\sql_instaler", "bd_SQL_Instaler", Nothing)

        Catch ex As Exception
            MsgBox(ex, vbCritical)
        End Try
    End Sub

    Private Sub btndropamb_Click(sender As Object, e As EventArgs) Handles btndropamb.Click
        Dim lo_biz As New biz_preferencias
        Dim lo_ret As Integer = 0

        Try

            If MsgBox("¿Esta seguro de eliminar este ambiente?", vbInformation + vbYesNo, "Atención") = DialogResult.Yes Then
                lo_ret = lo_biz.f_eliminar_ambiente(Comboambientes.SelectedItem.ToString)

                If lo_ret >= 0 Then

                    MsgBox("Se realizo al eliminicación del ambientes con éxito", vbInformation, "Éxito")
                    Dim amb As New ent_preferencias

                    Comboambientes.Items.Clear()

                    amb = lo_biz.f_traer_ambiente()

                    For i As Integer = 0 To amb.p_is_ambiente_o.Count - 1
                        Comboambientes.Items.Add(amb.p_is_ambiente_o.Item(i))
                    Next

                    Registry.SetValue("HKEY_CURRENT_USER\Software\sql_instaler", "Ambiente_Prefencia_SQL_Instal", "")
                    Comboambientes.SelectedItem = Nothing

                    If Comboambientes.Items.Count > 0 Then
                        Comboambientes.SelectedIndex = 0
                    Else
                        Comboambientes.SelectedItem = Nothing
                    End If

                Else
                    MsgBox("Ocurrio un problema al eleminiar el ambiente", vbCritical, "Ocurrio un problema")
                End If
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub start_Up(ByVal bCrear As Boolean)

        ' clave del registro para   
        ' colocar el path del ejecutable para iniciar con windows  
        Const CLAVE As String = "SOFTWARE\Microsoft\Windows\CurrentVersion\Run"

        'ProductName : el nombre del programa.  
        Dim subClave As String = Application.ProductName.ToString
        ' Mensaje para retornar el resultado  
        Dim msg As String = ""

        Try
            ' Abre la clave del usuario actual (CurrentUser) para poder extablecer el dato  
            ' si la clave CurrentVersion\Run no existe la crea  
            Dim Registro As RegistryKey = CurrentUser.CreateSubKey(CLAVE, RegistryKeyPermissionCheck.ReadWriteSubTree)

            With Registro

                ' Registry.SetValue("HKEY_CURRENT_USER\Software\sql_instaler", "Ambiente_Prefencia_SQL_Instal", "")

                .OpenSubKey(CLAVE, True)

                Select Case bCrear
                    ' Crear  
                    ''''''''''''''''''''''  
                    Case True
                        ' Escribe el path con SetValue   
                        'Valores : ProductName el nombre del programa y ExecutablePath : la ruta del exe  
                        .SetValue(subClave,
                                  Application.ExecutablePath.ToString)

                        Registry.SetValue(CLAVE, subClave, "")

                       ' Return "Ok .. clave añadida"
                        ' Eliminar  
                        ''''''''''''''''''''''  
                        'Elimina la entrada con DeleteValue  
                    Case False
                        If .GetValue(subClave, "").ToString <> "" Then
                            .DeleteValue(subClave) ' eliminar  
                            ' msg = "Ok .. clave eliminada"
                        Else

                            ' msg = "No se eliminó , por que el programa" &
                            '  " no iniciaba con windows"
                        End If
                End Select
            End With
            ' Error  
            ''''''''''''''''''''''  
        Catch ex As Exception
            'msg = ex.Message.ToString
        End Try
        'retorno  
        'Return msg
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Dim Folder As New FolderBrowserDialog
        Dim lo_directorio_actual As String = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\sql_instaler", "bd_SQL_Instaler", Nothing)
        Dim lo_directorio_final As String = ""
        Dim lo_biz As New biz_preferencias
        Dim lo_ret_conex As New ent_retorno
        Try

            Folder.SelectedPath = lo_directorio_actual
            If Folder.ShowDialog() = DialogResult.OK Then
                lo_directorio_final = IO.Path.GetDirectoryName(Folder.SelectedPath) & "\" & IO.Path.GetFileName(Folder.SelectedPath)
                If lo_directorio_actual <> lo_directorio_final Then
                    If File.Exists(lo_directorio_final & "\db.db") Then
                        lo_ret_conex = lo_biz.f_comprobar_bd
                        If lo_ret_conex.p_cod_error_i = 0 Then
                            MsgBox("Problema con la Base selecionada", vbCritical, "Ocurrio un problema")
                        Else
                            txtubibd.Text = lo_directorio_final
                        End If
                    Else
                        MsgBox("No se pudo encontrar ninguna base compatible en la carpeta selecionada", vbCritical, "Ocurrio un problema")
                    End If
                End If
            End If

        Catch ex As Exception
            MsgBox(ex, vbCritical)
        End Try

    End Sub

End Class