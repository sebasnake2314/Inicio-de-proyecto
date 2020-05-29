Imports System.Runtime.InteropServices
Imports Microsoft.Win32
Imports System.IO
Imports ns.biz
Imports ns.ent
Imports System.Text

Public Class pantalla_principal_sql
    Dim lo_ret_conex As New ent_retorno
    Dim lista_subitems As New List(Of String)

    Private Sub btnclose_Click(sender As Object, e As EventArgs) Handles btnclose.Click

        Try

            If MsgBox("¿Desea cerrar al aplicación por completo?", vbInformation + vbYesNo, "Cerrando aplicación") = vbNo Then

                MsgBox("La aplicación fue enviada a segundo plano", vbInformation, "Sql Instaler")

                'Limpio el contexmenu
                ContextMenuStrip1.Items.Clear()
                'Agrego un items mas a contextmenu
                Dim submenu, salir, abrir As New ToolStripMenuItem()
                AddHandler abrir.Click, AddressOf lP_subejecutar
                AddHandler salir.Click, AddressOf lP_subejecutar
                ' todos.Text = "Todos"
                'submenu.DropDownItems.Add(todos)

                salir.Text = "Salir"
                abrir.Text = "Abrir"

                If lista_subitems.Count > 0 Then
                    submenu.Text = "Ejecutar"
                    For Each items As String In lista_subitems
                        ' Dim archivos As New ToolStripMenuItem()
                        ' archivos.Text = items

                        Dim archivos As New ToolStripMenuItem()
                        AddHandler archivos.Click, AddressOf lP_subejecutar

                        'If submenu.DropDownItems.Count = 0 Then
                        '    Dim todos As New ToolStripMenuItem()
                        '    AddHandler todos.Click, AddressOf lP_subejecutar
                        '    todos.Text = "Todos"
                        '    submenu.DropDownItems.Add(todos)
                        'End If
                        archivos.Text = items
                        submenu.DropDownItems.Add(archivos)
                    Next
                    ContextMenuStrip1.Items.Add(abrir)
                    ContextMenuStrip1.Items.Add(submenu)
                    ContextMenuStrip1.Items.Add(salir)
                Else

                    ContextMenuStrip1.Items.Add(abrir)
                    ContextMenuStrip1.Items.Add(salir)
                End If

                NotifyIcon1.ShowBalloonTip(3000, "Sql instaler", "SQL instaler en segundo plano", ToolTipIcon.Info)
                NotifyIcon1.BalloonTipTitle = "Sql Instaler"
                NotifyIcon1.BalloonTipText = "Se encuentra en segundo plano"
                NotifyIcon1.Text = "Sql Instaler"
                Me.NotifyIcon1.Visible = True
                Me.Hide()
            Else
                Me.Close()
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub lP_subejecutar(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Try

            Dim lo_ret_ejecucion As New ent_retorno
            Dim lo_biz As New biz_ejecucion
            Dim texto As String = ""
            Dim fila_archivo As Integer = 0
            texto = sender.ToString

            Select Case sender.ToString
                Case "Abrir"
                    Me.Show()
                Case "Salir"
                    Me.Close()
                Case Else

                    If File.Exists(txtdirectorio.Text & "\" & texto & ".sql") Then

                        For Each r As DataGridViewRow In grip_nombre_archi.Rows
                            'en cells() coloco la columna que quiero validar si es igual a la condicion
                            If r.Cells(0).Value = sender.ToString Then
                                fila_archivo = r.Cells(0).RowIndex
                                Exit For
                            End If
                        Next

                        grip_nombre_archi.Rows(fila_archivo).Cells(2).Value = My.Resources.cargando_sql_pequeno

                        lo_ret_ejecucion = lo_biz.f_ejecutar_sql(sender.ToString, txtdirectorio.Text, Comboambientes.SelectedItem.ToString())

                        If lo_ret_ejecucion.p_cod_error_i = 0 Then
                            grip_nombre_archi.Rows(fila_archivo).Cells(2).Value = My.Resources.sql_exito_pequeno
                            grip_nombre_archi.Rows(fila_archivo).Cells(3).Value = 1
                            MsgBox("Ejecución sin errores", vbInformation, "Exito")
                        Else
                            grip_nombre_archi.Rows(fila_archivo).Cells(2).Value = My.Resources.sql_error_pequeno
                            grip_nombre_archi.Rows(fila_archivo).Cells(3).Value = 0
                            MsgBox("Ocurrio un problema en ejecución: " & lo_ret_ejecucion.p_cod_error_i & " " & lo_ret_ejecucion.p_desc_error_c, vbCritical, "Atención")

                        End If

                    Else
                        MsgBox("No se pudo ejecutar el archivo .Sql, no se encuentra en la ruta señalada", vbCritical, "Atención")
                    End If

            End Select


            'If sender.ToString <> "Todos" Then

            '    'lo_ret_ejecucion = lo_biz.f_ejecutar_sql(sender.ToString, txtdirectorio.Text, Comboambientes.SelectedItem.ToString())

            '    If File.Exists(txtdirectorio.Text & "\" & texto & ".sql") Then

            '        For Each r As DataGridViewRow In grip_nombre_archi.Rows
            '            'en cells() coloco la columna que quiero validar si es igual a la condicion
            '            If r.Cells(0).Value = sender.ToString Then
            '                fila_archivo = r.Cells(0).RowIndex
            '                Exit For
            '            End If
            '        Next

            '        grip_nombre_archi.Rows(fila_archivo).Cells(2).Value = My.Resources.cargando_sql_pequeno

            '        lo_ret_ejecucion = lo_biz.f_ejecutar_sql(sender.ToString, txtdirectorio.Text, Comboambientes.SelectedItem.ToString())

            '        If lo_ret_ejecucion.p_cod_error_i = 0 Then
            '            grip_nombre_archi.Rows(fila_archivo).Cells(2).Value = My.Resources.sql_exito_pequeno
            '            grip_nombre_archi.Rows(fila_archivo).Cells(3).Value = 1
            '            MsgBox("Ejecución sin errores", vbInformation, "Exito")
            '        Else
            '            grip_nombre_archi.Rows(fila_archivo).Cells(2).Value = My.Resources.sql_error_pequeno
            '            grip_nombre_archi.Rows(fila_archivo).Cells(3).Value = 0
            '            MsgBox("Ocurrio un problema en ejecución: " & lo_ret_ejecucion.p_cod_error_i & " " & lo_ret_ejecucion.p_desc_error_c, vbCritical, "Atención")

            '        End If

            '    Else
            '        MsgBox("No se pudo ejecutar el archivo .Sql, no se encuentra en la ruta señalada", vbCritical, "Atención")
            '    End If

            'End If


        Catch ex As Exception
            MsgBox(ex, vbCritical)
        End Try

    End Sub


    Private Sub btnmini_Click(sender As Object, e As EventArgs) Handles btnmini.Click
        Try
            Me.WindowState = FormWindowState.Minimized
        Catch ex As Exception

        End Try
    End Sub

    Public Function DetectEncodingFromBom(data() As Byte) As Encoding
        Return Encoding.GetEncodings().
           Select(Function(info) info.GetEncoding()).
           FirstOrDefault(Function(enc) DataStartsWithBom(data, enc))
    End Function

    Private Function DataStartsWithBom(data() As Byte, enc As Encoding) As Boolean
        Dim bom() As Byte = enc.GetPreamble()
        If bom.Length <> 0 Then
            Return data.
               Zip(bom, Function(x, y) x = y).
               All(Function(x) x)
        Else
            Return False
        End If
    End Function


    Private Sub btnselecdirectorio_Click(sender As Object, e As EventArgs) Handles btnselecdirectorio.Click

        Dim Folder As New FolderBrowserDialog
        Dim lista_archivos_sql As New List(Of String)
        Dim cantidad_archivos_sql As Integer = 0
        Dim lo_biz As New biz_preferencias
        Dim lo_ret As New ent_preferencias
        Dim fileCreatedDate As New DateTime
        Dim contador_archivos As Integer = 0
        Try

            'Limpio lista de archivos
            lista_subitems.Clear()

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
                    lista_subitems.Add(archivo)
                    lista_archivos_sql.Add(archivo)

                    Dim direct As String = ""
                    direct = txtdirectorio.Text & "\" & archivo & ".sql"

                    fileCreatedDate = File.GetLastWriteTime(direct)
                    'Convert.ToString(fileCreatedDate)
                    grip_nombre_archi.Rows.Add(archivo)
                    grip_nombre_archi.Rows(contador_archivos).Cells("fecha_archivo").Value = fileCreatedDate.ToString("dd/MM/yyyy H:mm:ss")
                    contador_archivos += 1
                    lbcantarch.Text = contador_archivos

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
                    btnunificar.Visible = False
                    lbamb.Visible = False
                    Comboambientes.Visible = False
                    btnejecutarsql.Visible = False
                    tabladecontrol.Visible = False
                    txtdirectorio.Visible = False
                    btnabrirdirectorio.Visible = False
                    btnorder.Visible = False

                Else

                    lbcantarch.Text = lista_archivos_sql.Count
                    'Agrego lista de archivos a ListView
                    'For Each items As String In lista_archivos_sql
                    '    grip_nombre_archi.Rows.Add(items)
                    '    'grip_nombre_archi.Rows(fila_archivo).Cells(2).Value = My.Resources.cargando_sql_pequeno
                    'Next

                    Try

                        lo_ret = lo_biz.f_traer_ambiente()
                        Comboambientes.Items.Clear()

                        For i As Integer = 0 To lo_ret.p_is_ambiente_o.Count - 1
                            Comboambientes.Items.Add(lo_ret.p_is_ambiente_o.Item(i))
                        Next

                        If Comboambientes.Items.Count > 0 Then
                            Comboambientes.Visible = True
                            Comboambientes.SelectedItem = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\sql_instaler", "Ambiente_Prefencia_SQL_Instal", Nothing)

                        End If

                    Catch ex As Exception

                    End Try

                    grip_nombre_archi.Visible = True
                    Label3.Visible = True
                    lbcantarch.Visible = True
                    btnsubir.Visible = True
                    btnbajar.Visible = True
                    btneditar.Visible = True
                    btnselecionartodo.Visible = True
                    btnabrirarchivo.Visible = True
                    btnactualizar.Visible = True
                    btnunificar.Visible = True
                    lbamb.Visible = True
                    btnejecutarsql.Visible = True
                    tabladecontrol.Visible = True
                    txtdirectorio.Visible = True
                    btnabrirdirectorio.Visible = True
                    btnorder.Visible = True
                    Dim nombre_archivo_sql As String = grip_nombre_archi.Rows(0).Cells(0).Value

                    llenar_contenedor_texto(nombre_archivo_sql)

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
                btnunificar.Visible = False
                lbamb.Visible = False
                Comboambientes.Visible = False
                btnejecutarsql.Visible = False
                tabladecontrol.Visible = False
                txtdirectorio.Visible = False
                btnabrirdirectorio.Visible = False
                btnorder.Visible = False
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

    Private Sub pantalla_principal_sql_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim encabezado As New encabezado

        Try
            'Encabezado y separado
            If IsNothing(My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\sql_instaler", "encabezado_SQL_Instaler", Nothing)) Or My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\sql_instaler", "encabezado_SQL_Instaler", Nothing) = "" Then
                Registry.SetValue("HKEY_CURRENT_USER\Software\sql_instaler", "encabezado_SQL_Instaler", encabezado.crear_encabezado)
            End If

            If IsNothing(My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\sql_instaler", "separador_SQL_Instaler", Nothing)) Or My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\sql_instaler", "separador_SQL_Instaler", Nothing) = "" Then
                Registry.SetValue("HKEY_CURRENT_USER\Software\sql_instaler", "separador_SQL_Instaler", encabezado.crear_separador)
            End If

            creacionbd()

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

                lo_check = grip_nombre_archi.Rows(i).Cells(2).Value

                If lo_check = False Then

                    grip_nombre_archi.Rows(i).Cells(2).Value = True
                Else
                    grip_nombre_archi.Rows(i).Cells(2).Value = False
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


    Private Sub PreferenciasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PreferenciasToolStripMenuItem.Click
        Dim lo_biz As New biz_preferencias
        Dim lo_ret As New ent_preferencias

        Try
            preferencias.ShowDialog()

            lo_ret = lo_biz.f_traer_ambiente()

            Comboambientes.Items.Clear()


            For i As Integer = 0 To lo_ret.p_is_ambiente_o.Count - 1
                Comboambientes.Items.Add(lo_ret.p_is_ambiente_o.Item(i))
            Next


            Comboambientes.SelectedItem = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\sql_instaler", "Ambiente_Prefencia_SQL_Instal", Nothing)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub btnunificar_Click(sender As Object, e As EventArgs) Handles btnunificar.Click

        Dim coun As Integer = 0
        Dim coun_neg As Integer = 0
        Try

            For i As Integer = 0 To grip_nombre_archi.Rows.Count - 1

                If grip_nombre_archi.Rows(i).Cells(2).Value = True And grip_nombre_archi.Rows(i).Cells(4).Value = 1 Then
                    coun = +1
                ElseIf grip_nombre_archi.Rows(i).Cells(2).Value = True And grip_nombre_archi.Rows(i).Cells(4).Value = 0 Or grip_nombre_archi.Rows(i).Cells(2).Value = True And grip_nombre_archi.Rows(i).Cells(4).Value = Nothing Then
                    coun = +1
                    coun_neg = +1
                End If
            Next

            If coun_neg > 0 Then
                If MsgBox("Hay archivos que no ejecutaron o tuvieron problemas de ejecución. ¿Esta seguir en seguir con la operación?", vbYesNo) = vbNo Then
                    Exit Sub
                End If
            End If

            If coun > 0 Then

                Dim Form_unificador As New unificador_script
                Form_unificador.ShowDialog()
                Form_unificador.Dispose()

                btnactualizar_Click(Nothing, Nothing)

            Else
                MsgBox("Debe de elegir aun que sea un archivo para poder crear un Srcip Unificado", vbCritical, "Atención")
            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub grip_nombre_archi_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles grip_nombre_archi.CellClick

        Dim fila_archivo As Integer = 0
        Dim lo_check As Boolean
        Dim lo_biz As New biz_ejecucion
        'Dim lo_ret_ejecucion As New ent_retorno
        Dim lo_ret_ejecucion As New ent_retorno_ejecucion
        Dim nombre_archivo As String = ""
        Dim grid As DataGridView = CType(sender, DataGridView)
        Try

            Dim columnName As String = grip_nombre_archi.Columns(e.ColumnIndex).Name

            If grip_nombre_archi.CurrentRow Is Nothing Then
                btnbajar.Visible = False
                btnsubir.Visible = False
                btneditar.Visible = False
                btnabrirarchivo.Visible = False
                btnunificar.Visible = False
            Else


                'Cargo contenedor de texto con contenido del archivo sql
                fila_archivo = grip_nombre_archi.SelectedCells.Item(0).RowIndex

                Dim nombre_archivo_sql As String = grip_nombre_archi.Rows(fila_archivo).Cells(0).Value

                llenar_contenedor_texto(nombre_archivo_sql)

                If columnName = "selecionar" Then

                    For i As Integer = 0 To grip_nombre_archi.Rows.Count - 1

                        If grip_nombre_archi.Rows(i).Selected = True Then

                            lo_check = grip_nombre_archi.Rows(fila_archivo).Cells(2).Value

                            If lo_check = False Then

                                grip_nombre_archi.Rows(fila_archivo).Cells(2).Value = True

                            Else
                                grip_nombre_archi.Rows(fila_archivo).Cells(2).Value = False

                            End If
                        Else
                        End If
                    Next

                ElseIf columnName = "ejecucion_sql" Then

                    If Comboambientes.Items.Count = 0 Then
                        MsgBox("Debe selecionar un ambiente para poder ejecutar un SQL", vbInformation, "Atención")
                    Else

                        nombre_archivo = grip_nombre_archi.Rows(fila_archivo).Cells(0).Value

                        If File.Exists(txtdirectorio.Text & "\" & nombre_archivo & ".sql") Then

                            grip_nombre_archi.Rows(fila_archivo).Cells(3).Value = My.Resources.cargando_sql_pequeno

                            lo_ret_ejecucion = lo_biz.f_ejecutar_sql(nombre_archivo, txtdirectorio.Text, Comboambientes.SelectedItem.ToString())

                            If lo_ret_ejecucion.p_cod_error_i = 0 Then
                                grip_nombre_archi.Rows(fila_archivo).Cells(3).Value = My.Resources.sql_exito_pequeno
                                grip_nombre_archi.Rows(fila_archivo).Cells(4).Value = 1
                                MsgBox("Ejecución sin errores", vbInformation, "Exito")
                            Else
                                grip_nombre_archi.Rows(fila_archivo).Cells(3).Value = My.Resources.sql_error_pequeno
                                grip_nombre_archi.Rows(fila_archivo).Cells(4).Value = 0
                                MsgBox("Ocurrio un problema en ejecución: " & lo_ret_ejecucion.p_cod_error_i & " " & lo_ret_ejecucion.p_desc_error_c, vbCritical, "Atención")
                                tabladecontrol.SelectedIndex = 1
                                cuadrodetexto.SelectedText = lo_ret_ejecucion.p_liena_c
                                cuadrodetexto.Find(lo_ret_ejecucion.p_liena_c)

                            End If

                        Else
                            MsgBox("No se pudo ejecutar el archivo .Sql, no se encuentra en la ruta señalada", vbCritical, "Atención")
                        End If

                    End If

                End If

                btnbajar.Visible = True
                btnsubir.Visible = True
                btneditar.Visible = True
                btnabrirarchivo.Visible = True
                btnunificar.Visible = True
            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnejecutarsql_Click(sender As Object, e As EventArgs) Handles btnejecutarsql.Click
        Dim nombre_archivo As String = ""
        Dim lo_biz As New biz_ejecucion
        Dim lo_ret_ejecucion As New ent_retorno
        Dim ejec As String = ""
        Try

            For i As Integer = 0 To grip_nombre_archi.Rows.Count - 1

                If grip_nombre_archi.Rows(i).Cells(2).Value Then

                    nombre_archivo = grip_nombre_archi.Rows(i).Cells(0).Value

                    grip_nombre_archi.Rows(i).Cells(3).Value = My.Resources.cargando_sql_pequeno

                    lo_ret_ejecucion = lo_biz.f_ejecutar_sql(nombre_archivo, txtdirectorio.Text, Comboambientes.SelectedItem.ToString())

                    If lo_ret_ejecucion.p_cod_error_i = 0 Then
                        grip_nombre_archi.Rows(i).Cells(3).Value = My.Resources.sql_exito_pequeno
                        grip_nombre_archi.Rows(i).Cells(4).Value = 1
                    Else
                        grip_nombre_archi.Rows(i).Cells(3).Value = My.Resources.sql_error_pequeno
                        grip_nombre_archi.Rows(i).Cells(4).Value = 0
                        MsgBox("Ocurrio un problema en ejecución: " & lo_ret_ejecucion.p_cod_error_i & " " & lo_ret_ejecucion.p_desc_error_c, vbCritical, "Atención")
                        Exit Sub
                    End If

                End If

            Next

            MsgBox("Todos los script se ejecutaron con éxito", vbInformation, "Éxito")

        Catch ex As Exception

        End Try
    End Sub

#End Region

#Region "Funciones para creación de base de datos"

    Public Sub creacionbd()

        Dim lo_biz As New biz_preferencias
        Dim lo_ret As New ent_retorno
        Dim count_veri As Integer = 0
        Dim Directorio As String = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\sql_instaler", "bd_SQL_Instaler", Nothing)

        Try

            If IsNothing(My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\sql_instaler", "bd_SQL_Instaler", Nothing)) Or My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\sql_instaler", "bd_SQL_Instaler", Nothing) = "" Then
                'MsgBox("Debe seleccionar la una ubicación para el archivo de almacenamiento de datos", vbInformation)
                f_crear_bd_auto()

                lo_ret_conex = lo_biz.f_comprobar_bd()
                NotifyIcon1.ShowBalloonTip(1000, "Sql Instaler", lo_ret_conex.p_desc_error_c, ToolTipIcon.Info)
                btn_conex.Image = My.Resources.connect
                mensajetooltip(ToolTip, btn_conex, lo_ret_conex.p_desc_error_c)

            Else

                'En caso de no existir el archivo .db en la ruta del registry se crea una nueva
                If File.Exists(Directorio & "\db.db") = False Then
                    f_crear_bd_auto()
                End If

                'Compruebo existencia de pase de datos en agregado en ruta registry
                lo_ret_conex = lo_biz.f_comprobar_bd()

                If lo_ret_conex.p_cod_error_i = 0 Then


                    NotifyIcon1.ShowBalloonTip(600, "Sql Instaler", lo_ret_conex.p_desc_error_c, ToolTipIcon.Error)
                    btn_conex.Image = My.Resources.disconnect
                    mensajetooltip(ToolTip, btn_conex, lo_ret_conex.p_desc_error_c)

                    'If MsgBox(lo_ret_conex.p_desc_error_c & "No se puede encontrar la base de datos en la ruta actual " & My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\sql_instaler", "bd_SQL_Instaler", Nothing) & ". ¿Desea selecionar de forma manual ubicación de base de datos?", vbInformation + vbYesNo, "Atención") = vbYes Then
                    'f_crear_bd_manual()
                    'count_veri = 1
                    'Else
                    'f_crear_bd_auto()
                    'count_veri = 1
                    'End If

                Else

                    'NotifyIcon1.ShowBalloonTip(600, "Sql Instaler", lo_ret_conex.p_desc_error_c, ToolTipIcon.Info)
                    btn_conex.Image = My.Resources.connect
                    'mensajetooltip(ToolTip, btn_conex, lo_ret_conex.p_desc_error_c)

                End If

                'If count_veri = 1 Then
                '    lo_ret_conex = lo_biz.f_comprobar_bd()
                '    If lo_ret_conex.p_cod_error_i = 1 Then
                '        NotifyIcon1.ShowBalloonTip(600, "Sql Instaler", lo_ret_conex.p_desc_error_c, ToolTipIcon.None)
                '        btn_conex.Image = My.Resources.connect
                '        mensajetooltip(ToolTip, btn_conex, lo_ret_conex.p_desc_error_c)

                '    Else
                '        NotifyIcon1.ShowBalloonTip(600, "Sql Instaler", lo_ret_conex.p_desc_error_c, ToolTipIcon.Error)
                '        btn_conex.Image = My.Resources.disconnect
                '        mensajetooltip(ToolTip, btn_conex, lo_ret_conex.p_desc_error_c)

                '    End If

                'NotifyIcon1.Dispose()
                ' NotifyIcon1.Visible = False
                'End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical)
        End Try

    End Sub

    Public Sub crear_tablas()
        Dim lo_biz As New biz_preferencias
        Try
            lo_biz.crear_tablas()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub f_crear_bd_manual()
        Dim Folder As New FolderBrowserDialog
        Dim path As String = ""
        Dim carpeta As String = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\sql_instaler", "bd_SQL_Instaler", Nothing)
        Dim carpeta2 As String = System.IO.Directory.GetCurrentDirectory.ToString()

        Try


            'Busqueda de ruta de carpeta donde se encuentran los archivos .aspx
            Dim directorio As String = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\sql_instaler", "bd_SQL_Instaler", Nothing)
            Dim arr2 As String()
            Dim count As Integer
            Dim direct_part As String = ""
            Dim direct_busqueda As String = ""
            arr2 = Split(directorio, Chr(92))
            count = arr2.Count
            For j As Integer = 0 To arr2.Length

                direct_part += arr2(j) + Chr(92)

                If Directory.Exists(direct_part) Then

                    direct_busqueda += arr2(j) + Chr(92)

                Else
                    Exit For
                End If
            Next


            Folder.SelectedPath = direct_busqueda

            If Folder.ShowDialog() = DialogResult.OK Then

                If File.Exists(IO.Path.GetDirectoryName(Folder.SelectedPath) & "\" & IO.Path.GetFileName(Folder.SelectedPath) & "\sql_instaler" & "\db.db") Then
                    If MsgBox("Actualmente en la ruta selecionada existe una base datos. ¿Desea utilizarla?", vbInformation + vbYesNo, "Atención") = vbYes Then
                        Registry.SetValue("HKEY_CURRENT_USER\Software\sql_instaler", "bd_SQL_Instaler", path)
                    Else
                        MsgBox("¿Desea usar esta base de datos? ", vbInformation)
                        If DialogResult = DialogResult.Yes Then
                            f_crear_bd_auto()
                        End If
                    End If

                Else

                    If MsgBox("No se encontro ninguna base de datos en carpeta selecionada. ¿Desea crearla?", vbYesNo) = vbYes Then
                        f_crear_bd_auto()
                    End If

                End If
            Else
                MsgBox("Debe selecionar una carpeta", vbInformation)
            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub f_crear_bd_auto()
        Dim Folder As New FolderBrowserDialog
        Dim path As String = ""
        Dim carpeta As String = ""
        'Folder.SelectedPath = System.IO.Directory.GetCurrentDirectory.ToString()

        Folder.SelectedPath = My.Computer.FileSystem.SpecialDirectories.MyDocuments

        Dim seleciono As Integer
        Try

            'While seleciono = 0

            'If Folder.ShowDialog() = DialogResult.OK Then

            'Creo carpeta
            'carpeta = IO.Path.GetDirectoryName(Folder.SelectedPath) & "\" & IO.Path.GetFileName(Folder.SelectedPath) & "\sql_instaler"
            carpeta = IO.Path.GetDirectoryName(My.Computer.FileSystem.SpecialDirectories.MyDocuments) & "\" & IO.Path.GetFileName(Folder.SelectedPath) & "\sql_instaler"

            My.Computer.FileSystem.CreateDirectory(carpeta)

            'Directorio Completo con creación con base de datos
            path = IO.Path.GetDirectoryName(Folder.SelectedPath) & "\" & IO.Path.GetFileName(Folder.SelectedPath) & "\sql_instaler" & "\db.db"

            'Creación de archivo de base de datos.
            Dim fs As FileStream = File.Create(path)
            fs.Close()

            Registry.SetValue("HKEY_CURRENT_USER\Software\sql_instaler", "bd_SQL_Instaler", carpeta)
            'Inserto tablas y campos en base de datos
            crear_tablas()
            seleciono = 1
            'Else

            ' MsgBox("No selecciono ninguna carpeta, Debe seleccionar", vbInformation)

            ' End If

            'End While

        Catch ex As Exception
            MsgBox(ex, vbCritical)
        End Try

    End Sub

#End Region

#Region "Tooltip botones"
    Sub mensajetooltip(ByVal globo As ToolTip, ByVal boton As PictureBox, ByVal mensaje As String)
        globo.RemoveAll()
        globo.SetToolTip(boton, mensaje)
        globo.InitialDelay = 100
        globo.IsBalloon = False
    End Sub
    Private Sub btnselecdirectorio_MouseEnter(sender As Object, e As EventArgs) Handles btnselecdirectorio.MouseEnter
        mensajetooltip(ToolTip, btnselecdirectorio, "Selecionar una carpeta")
    End Sub
    Private Sub btnabrirdirectorio_MouseEnter(sender As Object, e As EventArgs) Handles btnabrirdirectorio.MouseEnter
        mensajetooltip(ToolTip, btnabrirdirectorio, "Abrir directorio")
    End Sub

    Private Sub btnsubir_MouseEnter(sender As Object, e As EventArgs) Handles btnsubir.MouseEnter
        mensajetooltip(ToolTip, btnsubir, "Subir")
    End Sub
    Private Sub btnsubir_MouseHover(sender As Object, e As EventArgs) Handles btnsubir.MouseHover
        Me.btnsubir.BorderStyle = BorderStyle.Fixed3D
    End Sub
    Private Sub btnsubir_MouseLeave(sender As Object, e As EventArgs) Handles btnsubir.MouseLeave
        Me.btnsubir.BorderStyle = BorderStyle.None
    End Sub
    Private Sub btnbajar_MouseEnter(sender As Object, e As EventArgs) Handles btnbajar.MouseEnter
        mensajetooltip(ToolTip, btnbajar, "Bajar")
    End Sub
    Private Sub btnselecionartodo_MouseEnter(sender As Object, e As EventArgs) Handles btnselecionartodo.MouseEnter
        mensajetooltip(ToolTip, btnselecionartodo, "Seleccionar todo")
    End Sub
    Private Sub btnactualizar_MouseEnter(sender As Object, e As EventArgs) Handles btnactualizar.MouseEnter
        mensajetooltip(ToolTip, btnactualizar, "Actualizar")
    End Sub
    Private Sub btneditar_MouseEnter(sender As Object, e As EventArgs) Handles btneditar.MouseEnter
        mensajetooltip(ToolTip, btneditar, "Editar nombre de archivo")
    End Sub
    'Private Sub btneditar_MouseHover(sender As Object, e As EventArgs) Handles btneditar.MouseHover
    '    Me.btneditar.BorderStyle = BorderStyle.Fixed3D
    'End Sub
    Private Sub btneditar_MouseLeave(sender As Object, e As EventArgs) Handles btneditar.MouseLeave
        Me.btneditar.BorderStyle = BorderStyle.None
    End Sub
    Private Sub btnabrirarchivo_MouseEnter(sender As Object, e As EventArgs) Handles btnabrirarchivo.MouseEnter
        mensajetooltip(ToolTip, btnabrirarchivo, "Mirar archivo")
    End Sub
    Private Sub btn_conex_MouseEnter(sender As Object, e As EventArgs) Handles btn_conex.MouseEnter
        mensajetooltip(ToolTip, btn_conex, lo_ret_conex.p_desc_error_c)
    End Sub
    Private Sub btnclose_MouseEnter(sender As Object, e As EventArgs) Handles btnclose.MouseEnter
        mensajetooltip(ToolTip, btnclose, "Cerrar")
    End Sub
    Private Sub btnmini_MouseEnter(sender As Object, e As EventArgs) Handles btnmini.MouseEnter
        mensajetooltip(ToolTip, btnmini, "Minimizar")
    End Sub
    Private Sub btnunificar_MouseEnter(sender As Object, e As EventArgs) Handles btnunificar.MouseEnter
        mensajetooltip(ToolTip, btnunificar, "Crear script Unificado")
    End Sub
    Private Sub btnejecutarsql_MouseEnter(sender As Object, e As EventArgs) Handles btnejecutarsql.MouseEnter
        mensajetooltip(ToolTip, btnejecutarsql, "Ejecutar SQL selecionados")
    End Sub
    Private Sub SalirToolStripMenuItem1_Click(sender As Object, e As EventArgs)
        NotifyIcon1.Dispose()
        Me.Close()
    End Sub
    Private Sub MaximizarToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Me.Show()
    End Sub
    Private Sub NotifyIcon1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles NotifyIcon1.MouseDoubleClick
        Me.Show()
    End Sub

#End Region

    Public Sub llenar_contenedor_texto(ByVal p_nombre_archivo)
        Dim lo_contenido_sql As String
        'Dim lector As New StreamReader
        Dim sql As String = ""
        Dim Nombre_archivo As String = ""
        Try

            Nombre_archivo = p_nombre_archivo
            'ruta = txtdirectorio.Text

            ' Dim lector As New StreamReader(ruta & "\" & p_nombre_archivo & ".sql")

            'lector = txtdirectorio.Text & "\" & p_nombre_archivo & ".sql"

            lo_contenido_sql = My.Computer.FileSystem.ReadAllText(txtdirectorio.Text & "\" & p_nombre_archivo & ".sql")

            ' lo_contenido_sql = My.Computer.FileSystem.ReadAllText(txtdirectorio.Text & "\" & p_nombre_archivo & ".sql")
            Nombre_archivo = txtdirectorio.Text & "\" & p_nombre_archivo & ".sql"



            'Dim lector As String = My.Computer.FileSystem.ReadAllText(txtdirectorio.Text & "\" & p_nombre_archivo & ".sql")
            'Dim ANSI As New StreamReader(Nombre_archivo)
            ' Dim ANSI As New StreamReader((txtdirectorio.Text & "\" & p_nombre_archivo & ".sql"), Encoding.Unicode)


            Dim sFile As String = txtdirectorio.Text & "\" & p_nombre_archivo & ".sql"
            Dim sFileText As String



            Dim srStreamReader As New StreamReader(sFile, Encoding.Default)
            sFileText = srStreamReader.ReadToEnd()


            cuadrodetexto.Text = sFileText


            srStreamReader.Close()

            'Dim swStreamWriter As TextWriter = New StreamWriter(sFile & ".new")
            'swStreamWriter.Write(sFileText)
            'swStreamWriter.Close()

            ' Dim ANSI As New StreamReader(My.Computer.FileSystem.ReadAllText(txtdirectorio.Text & "\" & p_nombre_archivo & ".sql"))

            'Dim b As String = "AaáÁäÄñÑ"
            'Dim bytes As Byte()
            'bytes = System.Text.Encoding.GetEncoding(1145).GetBytes(My.Computer.FileSystem.ReadAllText(txtdirectorio.Text & "\" & p_nombre_archivo & ".sql"))
            'Dim a As String = System.Text.Encoding.GetEncoding(1145).GetString(bytes)



            'Dim bytes As Byte() = System.Text.Encoding.UTF8.GetBytes(My.Computer.FileSystem.ReadAllText(txtdirectorio.Text & "\" & p_nombre_archivo & ".sql"))
            'Dim a As String = System.Text.Encoding.ASCII.GetString(bytes)

            'lo_contenido_sql = a

            'cuadrodetexto.Text = lo_contenido_sql


        Catch ex As Exception

        End Try

    End Sub


End Class
