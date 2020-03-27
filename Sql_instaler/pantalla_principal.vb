Imports System.Runtime.InteropServices
Imports Microsoft.Win32
Public Class pantalla_principal_sql
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

    Private Sub btnselecdirectorio_Click(sender As Object, e As EventArgs) Handles btnselecdirectorio.Click

        Dim Folder As New FolderBrowserDialog
        Dim lista_archivos_sql As New List(Of String)
        Dim cantidad_archivos_sql As Integer = 0

        Try

            Folder.SelectedPath = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\sql_instaler", "Directorio_Prefencia_SQL_Instal", Nothing)

            If Folder.ShowDialog() = DialogResult.OK Then

                Registry.SetValue("HKEY_CURRENT_USER\Software\sql_instaler", "Directorio_Prefencia_SQL_Instal", IO.Path.GetDirectoryName(Folder.SelectedPath) & "\" & IO.Path.GetFileName(Folder.SelectedPath))

                grip_nombre_archi.Rows.Clear()

                txtdirectorio.Text = IO.Path.GetDirectoryName(Folder.SelectedPath) & "\" & IO.Path.GetFileName(Folder.SelectedPath)

                For Each archivo As String In My.Computer.FileSystem.GetFiles(txtdirectorio.Text, FileIO.SearchOption.SearchTopLevelOnly, "*.sql")
                    Dim arr As String()
                    arr = Split(archivo, ".")
                    arr = Split(arr(arr.Length - 2), Chr(92))
                    archivo = arr(arr.Length - 1)

                    lista_archivos_sql.Add(archivo)
                Next

                If lista_archivos_sql.Count = 0 Then
                    MsgBox("No se encontro ningun archivo con extension .SQL", vbInformation, "Atención")

                    txtdirectorio.Clear()
                    grip_nombre_archi.Visible = False
                    Label3.Visible = False
                    btnsubir.Visible = False
                    btnbajar.Visible = False
                    btneditar.Visible = False
                    btnselecionartodo.Visible = False
                    btnabrirarchivo.Visible = False
                    btnactualizar.Visible = False

                Else
                    lbcantarch.Text = lista_archivos_sql.Count
                    'Agrego lista de archivos a ListView
                    For Each items As String In lista_archivos_sql

                        grip_nombre_archi.Rows.Add(items)

                    Next

                    grip_nombre_archi.Visible = True
                    Label3.Visible = True
                    lbcantarch.Visible = True
                    btnsubir.Visible = True
                    btnbajar.Visible = True
                    btneditar.Visible = True
                    btnselecionartodo.Visible = True
                    btnabrirarchivo.Visible = True
                    btnactualizar.Visible = True
                End If

            Else
                'Al no selecionar un archivo muestro mensaje y coloco invisible ciertos elementos.
                MsgBox("Debe selecionar una carptera", vbExclamation, "Atención")
                grip_nombre_archi.Rows.Clear()
                grip_nombre_archi.Visible = False
                txtdirectorio.Clear()
                Label3.Visible = False
                lbcantarch.Visible = False
                btnsubir.Visible = False
                btnbajar.Visible = False
                btneditar.Visible = False
                btnselecionartodo.Visible = False
                btnabrirarchivo.Visible = False
                btnactualizar.Visible = False
            End If

        Catch ex As Exception
            MsgBox("Ocurrio un problema", vbCritical, "Error")
        End Try

    End Sub



    Private Sub btneditar_Click(sender As Object, e As EventArgs) Handles btneditar.Click
        Try

            Dim Nombre_archivo As String = ""
            Dim fila_archivo As Integer = 0

            fila_archivo = grip_nombre_archi.SelectedCells.Item(0).RowIndex

            Nombre_archivo = grip_nombre_archi.Rows(fila_archivo).Cells(0).Value

            editar_nombre_archivo.txtnombrar.Text = Nombre_archivo
            editar_nombre_archivo.txtnombrar.SelectionLength = editar_nombre_archivo.txtnombrar.Text.Length
            editar_nombre_archivo.ShowDialog()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnabrirdirectorio_Click(sender As Object, e As EventArgs) Handles btnabrirdirectorio.Click
        Try
            Process.Start(txtdirectorio.Text)
        Catch ex As Exception
        End Try
    End Sub

#Region "Drag Form"
    <DllImport("user32.DLL", EntryPoint:="ReleaseCapture")>
    Private Shared Sub RealeaseCapture()
    End Sub
    <DllImport("user32.DLL", EntryPoint:="SendMessage")>
    Private Shared Sub SendMessage(hWnd As IntPtr, wMsg As Integer, wParam As Integer, IParam As Integer)
    End Sub
    Private Sub titlebar_MouseMove(sender As Object, e As MouseEventArgs) Handles titlebar.MouseMove
        RealeaseCapture()
        SendMessage(Me.Handle, &H112&, &HF012&, 0)
    End Sub

    Private Sub grip_nombre_archi_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles grip_nombre_archi.CellContentDoubleClick
        Try
            Dim Nombre_archivo As String = ""
            Dim fila_archivo As Integer = 0

            fila_archivo = grip_nombre_archi.SelectedCells.Item(0).RowIndex

            Nombre_archivo = grip_nombre_archi.Rows(fila_archivo).Cells(0).Value

            editar_nombre_archivo.txtnombrar.Text = Nombre_archivo
            editar_nombre_archivo.ShowDialog()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnsubir_Click(sender As Object, e As EventArgs) Handles btnsubir.Click
        Try

            If (Me.grip_nombre_archi.SelectedCells.Count > 0 And Me.grip_nombre_archi.CurrentCell.RowIndex <> 0) Then

                Dim curr_index As Integer = Me.grip_nombre_archi.CurrentCell.RowIndex

                Dim curr_col_index As Integer = Me.grip_nombre_archi.CurrentCell.ColumnIndex

                Dim curr_row As DataGridViewRow = Me.grip_nombre_archi.CurrentRow

                Me.grip_nombre_archi.Rows.Remove(curr_row)

                Me.grip_nombre_archi.Rows.Insert(curr_index - 1, curr_row)

                Me.grip_nombre_archi.CurrentCell = Me.grip_nombre_archi(curr_col_index, curr_index - 1)

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnbajar_Click(sender As Object, e As EventArgs) Handles btnbajar.Click
        Try
            Dim filas As Integer = 0

            filas = grip_nombre_archi.Rows.Count

            If (Me.grip_nombre_archi.SelectedCells.Count > 0) Then

                Dim curr_index As Integer = Me.grip_nombre_archi.CurrentCell.RowIndex

                Dim curr_col_index As Integer = Me.grip_nombre_archi.CurrentCell.ColumnIndex

                Dim curr_row As DataGridViewRow = Me.grip_nombre_archi.CurrentRow

                If filas <> (curr_index + 1) Then

                    Me.grip_nombre_archi.Rows.Remove(curr_row)

                    Me.grip_nombre_archi.Rows.Insert(curr_index + 1, curr_row)

                    Me.grip_nombre_archi.CurrentCell = Me.grip_nombre_archi(curr_col_index, curr_index + 1)

                End If

            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnselecionartodo_Click(sender As Object, e As EventArgs) Handles btnselecionartodo.Click
        Dim lo_check As Boolean
        Try
            For i As Integer = 0 To grip_nombre_archi.Rows.Count - 1

                lo_check = grip_nombre_archi.Rows(i).Cells(1).Value

                If lo_check = False Then

                    grip_nombre_archi.Rows(i).Cells(1).Value = True
                Else
                    grip_nombre_archi.Rows(i).Cells(1).Value = False
                End If

            Next

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnabrirarchivo_Click(sender As Object, e As EventArgs) Handles btnabrirarchivo.Click
        Dim Nombre_archivo As String = ""
        Try
            Nombre_archivo = grip_nombre_archi.Rows(grip_nombre_archi.SelectedCells.Item(0).RowIndex).Cells(0).Value

            If grip_nombre_archi.Rows.Count > 0 Then

                Process.Start(txtdirectorio.Text & "\" & Nombre_archivo & ".sql")

            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnactualizar_Click(sender As Object, e As EventArgs) Handles btnactualizar.Click
        Dim Folder As New FolderBrowserDialog
        Dim lista_archivos_sql As New List(Of String)
        Dim cantidad_archivos_sql As Integer = 0
        Dim coun As Integer = 0
        Try

            grip_nombre_archi.Rows.Clear()

            For Each archivo As String In My.Computer.FileSystem.GetFiles(txtdirectorio.Text, FileIO.SearchOption.SearchTopLevelOnly, "*.sql")
                Dim arr As String()
                arr = Split(archivo, ".")
                arr = Split(arr(arr.Length - 2), Chr(92))
                archivo = arr(arr.Length - 1)


                grip_nombre_archi.Rows.Add(archivo)

                coun += 1
            Next

            lbcantarch.Text = coun

        Catch ex As Exception

        End Try
    End Sub

    Private Sub SalirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalirToolStripMenuItem.Click
        Try
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub

#End Region

End Class
