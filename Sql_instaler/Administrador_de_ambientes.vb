Imports ns.biz
Imports ns.ent
Imports System.IO
Imports System.Runtime.InteropServices
Imports Microsoft.Win32
Imports System.Net
Imports ns.utl
Public Class Administrador_de_ambientes
    Dim io_encriptado_b As Boolean
    Dim io_control_count As Integer
    Private Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click
        Dim lo_biz As New biz_preferencias
        Dim lo_ret As New ent_retorno

        Try

            lo_ret = lo_biz.f_agregar_ambiente(txtnombre.Text, txthost.Text, txtpuerto.Text, txtusuario.Text, txtpassword.Text, io_encriptado_b)

            If lo_ret.p_cod_error_i > 0 Then
                MsgBox(lo_ret.p_desc_error_c, vbInformation, "Éxito")

                preferencias.Comboambientes.Items.Add(txtnombre.Text)
                preferencias.Comboambientes.SelectedItem = txtnombre.Text

                For Each ctrl In Me.Controls
                    If TypeOf ctrl Is TextBox Then ctrl.text = ""
                    If TypeOf ctrl Is ComboBox Then ctrl.check = False
                Next

                preferencias.btnagregaramb.Visible = True
                preferencias.btndropamb.Visible = True
                preferencias.btneditaramb.Visible = True
                Me.Close()
            Else
                MsgBox(lo_ret.p_desc_error_c, vbCritical, "Ocurrio un problema")
            End If

        Catch ex As Exception

        End Try
    End Sub


    Private Sub Checkencrip_CheckedChanged(sender As Object, e As EventArgs) Handles Checkencrip.CheckedChanged
        Try
            If Checkencrip.Checked Then
                io_encriptado_b = True
            Else
                io_encriptado_b = False
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btncancelar_Click(sender As Object, e As EventArgs) Handles btncancelar.Click
        Try

            limpiarFormulario(Me.Controls)

            Me.txtnombre.Select()


            Me.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnclose_Click(sender As Object, e As EventArgs) Handles btnclose.Click
        Try
            Me.Close()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnmini_Click(sender As Object, e As EventArgs) Handles btnmini.Click
        Try
            Me.WindowState = FormWindowState.Minimized
        Catch ex As Exception

        End Try
    End Sub

    Sub limpiarFormulario(controles As Control.ControlCollection)

        For Each control As Control In controles
            If TypeOf control Is TextBox Then
                DirectCast(control, TextBox).Clear()
            ElseIf TypeOf control Is CheckBox Then
                DirectCast(control, CheckBox).Checked = False
            ElseIf TypeOf control Is GroupBox Or TypeOf control Is Panel Then
                limpiarFormulario(control.Controls)
            End If

        Next
    End Sub

    Public Function verificar_campos_text_vacios(controles As Control.ControlCollection) As Integer

        Try

            For Each control As Control In controles
                If TypeOf control Is TextBox Then

                    If control.Name <> "txtnombre" And Trim(control.Text) = "" Then
                        io_control_count += 1
                    End If

                    'DirectCast(control, TextBox).Clear()
                ElseIf TypeOf control Is GroupBox Or TypeOf control Is Panel Then
                    verificar_campos_text_vacios(control.Controls)
                End If

            Next
        Catch ex As Exception

        End Try

        Return io_control_count
    End Function

    Private Sub btntest_Click(sender As Object, e As EventArgs) Handles btntest.Click
        Dim lo_biz As New biz_conexion
        Dim control_campos As Integer
        Dim encrip As New utl_Encriptacion
        Dim pas_encrit_i As String = ""
        Try

            control_campos = verificar_campos_text_vacios(Me.Controls)

            If control_campos = 0 Then

                If Checkencrip.Checked = True Then

                    pas_encrit_i = encrip.Decrypt(txtpassword.Text)
                Else
                    pas_encrit_i = txtpassword.Text

                End If

                lo_biz.f_set_parametros_de_conexión(txtusuario.Text, pas_encrit_i, txthost.Text, txtpuerto.Text)
                NotifyIcon1.ShowBalloonTip(1000, "Sql Instaler", "Test de Conexión con éxito", ToolTipIcon.Info)
                btntest.Image = My.Resources.connect
                btnsave.Image = My.Resources.guardar
                btnsave.Enabled = True

                'io_control_count = 0
            Else

                MsgBox("Faltan campos por completar", vbCritical, "Ocurrio un problema")
                btntest.Image = My.Resources.disconnect
                btnsave.Image = My.Resources.not_save
                btnsave.Enabled = False

            End If
            io_control_count = 0
        Catch ex As Exception
            NotifyIcon1.ShowBalloonTip(1000, "Sql Instaler", "Test de Conexión con problemas", ToolTipIcon.Error)
            btntest.Image = My.Resources.disconnect
            btnsave.Image = My.Resources.not_save
            btnsave.Enabled = False
        End Try
    End Sub
End Class