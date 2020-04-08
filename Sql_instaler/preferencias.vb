Imports Microsoft.Win32
Imports ns.biz
Imports ns.ent
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

        Catch ex As Exception

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
End Class