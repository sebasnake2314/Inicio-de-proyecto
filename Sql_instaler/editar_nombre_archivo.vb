Imports System.IO
Public Class editar_nombre_archivo
    Dim vi_directorio_c As String = ""
    Dim vi_nombre_archivo_ori As String = ""
    Dim vi_itemnum_i As Integer = 0
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

    Private Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click
        Dim dir As New DirectoryInfo(vi_directorio_c)
        Dim fiArr As FileInfo() = dir.GetFiles()
        Dim f As FileInfo

        Try

            For Each f In fiArr
                Dim fileword As String = (f.Name)

                If fileword = vi_nombre_archivo_ori Then

                    Dim TestString As String = fileword
                    Dim newName As String = Replace(TestString, vi_nombre_archivo_ori, txtnombrar.Text & ".sql")

                    'Reemplazo nombre de archivo
                    System.IO.File.Move(vi_directorio_c & "\" & fileword, vi_directorio_c & "\" & newName)

                    'Actualizo listview en form sql_instaler
                    pantalla_principal_sql.grip_nombre_archi.Rows(vi_itemnum_i).Cells(0).Value = txtnombrar.Text

                    Me.Close()
                    Exit Sub
                End If

            Next f

        Catch ex As Exception
            MsgBox("Problema con el cambio de nombre de archivo", vbCritical)
            Me.Close()
        End Try
    End Sub

    Private Sub editar_nombre_archivo_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            vi_nombre_archivo_ori = txtnombrar.Text & ".sql"
            vi_directorio_c = pantalla_principal_sql.txtdirectorio.Text
            vi_itemnum_i = pantalla_principal_sql.grip_nombre_archi.CurrentCell.RowIndex
            txtnombrar.SelectionStart = 0
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btncancelar_Click(sender As Object, e As EventArgs) Handles btncancelar.Click
        Try
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub


End Class