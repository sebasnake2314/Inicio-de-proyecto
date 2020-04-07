Imports ns.biz
Imports ns.ent
Public Class Administrador_de_ambientes
    Dim io_encriptado_b As Boolean
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

End Class