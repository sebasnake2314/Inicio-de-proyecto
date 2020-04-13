Imports System.Runtime.InteropServices
Imports Microsoft.Win32
Imports System.IO
Imports Finisar.SQLite
Imports ns.biz
Imports ns.ent

Public Class pantalla_principal_sql
    Dim lo_ret_conex As New ent_retorno
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
        Dim lo_biz As New biz_preferencias
        Dim lo_ret As New ent_preferencias

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
                    btnunificar.Visible = False
                    lbamb.Visible = False
                    Comboambientes.Visible = False
                    btnejecutarsql.Visible = False
                Else

                    lbcantarch.Text = lista_archivos_sql.Count
                    'Agrego lista de archivos a ListView
                    For Each items As String In lista_archivos_sql
                        grip_nombre_archi.Rows.Add(items)

                    Next

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
                    'Comboambientes.Visible = True
                    btnejecutarsql.Visible = True
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

#Region "Funciones para creación de base de datos"

    Public Sub creacionbd()

        Dim lo_biz As New biz_preferencias
        Dim lo_ret As New ent_retorno
        Dim count_veri As Integer = 0
        Try

            If IsNothing(My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\sql_instaler", "bd_SQL_Instaler", Nothing)) Or My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\sql_instaler", "bd_SQL_Instaler", Nothing) = "" Then
                MsgBox("Debe seleccionar la una ubicación para el archivo de almacenamiento de datos", vbInformation)
                f_crear_bd_auto()

                lo_ret_conex = lo_biz.f_comprobar_bd()
                NotifyIcon1.ShowBalloonTip(1000, "Sql Instaler", lo_ret_conex.p_desc_error_c, ToolTipIcon.None)
                btn_conex.Image = My.Resources.connect
                mensajetooltip(ToolTip, btn_conex, lo_ret_conex.p_desc_error_c)

            Else

                'Compruebo existencia de pase de datos en agregado en ruta registry
                lo_ret_conex = lo_biz.f_comprobar_bd()

                If lo_ret_conex.p_cod_error_i = 0 Then

                    If MsgBox(lo_ret_conex.p_desc_error_c & "No se puede encontrar la base de datos en la ruta actual " & My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\sql_instaler", "bd_SQL_Instaler", Nothing) & ". ¿Desea selecionar de forma manual ubicación de base de datos?", vbInformation + vbYesNo, "Atención") = vbYes Then
                        f_crear_bd_manual()
                        count_veri = 1
                    Else
                        f_crear_bd_auto()
                        count_veri = 1
                    End If

                Else

                    NotifyIcon1.ShowBalloonTip(1000, "Sql Instaler", lo_ret_conex.p_desc_error_c, ToolTipIcon.None)
                    btn_conex.Image = My.Resources.connect
                    mensajetooltip(ToolTip, btn_conex, lo_ret_conex.p_desc_error_c)

                End If

                If count_veri = 1 Then
                    lo_ret_conex = lo_biz.f_comprobar_bd()
                    If lo_ret_conex.p_cod_error_i = 1 Then
                        NotifyIcon1.ShowBalloonTip(1000, "Sql Instaler", lo_ret_conex.p_desc_error_c, ToolTipIcon.None)
                        btn_conex.Image = My.Resources.connect
                        mensajetooltip(ToolTip, btn_conex, lo_ret_conex.p_desc_error_c)
                    Else
                        NotifyIcon1.ShowBalloonTip(1000, "Sql Instaler", lo_ret_conex.p_desc_error_c, ToolTipIcon.Error)
                        btn_conex.Image = My.Resources.disconnect
                        mensajetooltip(ToolTip, btn_conex, lo_ret_conex.p_desc_error_c)
                    End If

                    NotifyIcon1.Dispose()

                End If
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
        Folder.SelectedPath = System.IO.Directory.GetCurrentDirectory.ToString()
        Dim seleciono As Integer
        Try

            While seleciono = 0

                If Folder.ShowDialog() = DialogResult.OK Then

                    'Creo carpeta
                    carpeta = IO.Path.GetDirectoryName(Folder.SelectedPath) & "\" & IO.Path.GetFileName(Folder.SelectedPath) & "\sql_instaler"
                    My.Computer.FileSystem.CreateDirectory(carpeta)

                    'Directorio Completo con creación con base de datos
                    path = IO.Path.GetDirectoryName(Folder.SelectedPath) & "\" & IO.Path.GetFileName(Folder.SelectedPath) & "\sql_instaler" & "\db.db"

                    'Creación de archivo de base de datos.
                    Dim fs As FileStream = File.Create(path)
                    fs.Close()

                    Registry.SetValue("HKEY_CURRENT_USER\Software\sql_instaler", "bd_SQL_Instaler", path)
                    'Inserto tablas y campos en base de datos
                    crear_tablas()
                    seleciono = 1
                Else

                    MsgBox("No selecciono ninguna carpeta, Debe seleccionar", vbInformation)

                End If

            End While

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

                If grip_nombre_archi.Rows(i).Cells(1).Value = True And grip_nombre_archi.Rows(i).Cells(3).Value = 1 Then
                    coun = +1
                ElseIf grip_nombre_archi.Rows(i).Cells(1).Value = True And grip_nombre_archi.Rows(i).Cells(3).Value = 0 Or grip_nombre_archi.Rows(i).Cells(1).Value = True And grip_nombre_archi.Rows(i).Cells(3).Value = Nothing Then
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
                ' unificador_script.ShowDialog()

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
        Dim lo_ret_ejecucion As New ent_retorno
        Dim nombre_archivo As String = ""
        Dim grid As DataGridView = CType(sender, DataGridView)
        Dim columnName As String = grip_nombre_archi.Columns(e.ColumnIndex).Name

        Try

            If grip_nombre_archi.CurrentRow Is Nothing Then
                btnbajar.Visible = False
                btnsubir.Visible = False
                btneditar.Visible = False
                btnabrirarchivo.Visible = False
                btnunificar.Visible = False
            Else

                fila_archivo = grip_nombre_archi.SelectedCells.Item(0).RowIndex

                If columnName = "selecionar" Then

                    For i As Integer = 0 To grip_nombre_archi.Rows.Count - 1

                        If grip_nombre_archi.Rows(i).Selected = True Then

                            lo_check = grip_nombre_archi.Rows(fila_archivo).Cells(1).Value

                            If lo_check = False Then

                                grip_nombre_archi.Rows(fila_archivo).Cells(1).Value = True

                            Else
                                grip_nombre_archi.Rows(fila_archivo).Cells(1).Value = False

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

                            grip_nombre_archi.Rows(fila_archivo).Cells(2).Value = My.Resources.cargando_sql_pequeno

                            lo_ret_ejecucion = lo_biz.f_ejecutar_sql(nombre_archivo, txtdirectorio.Text, Comboambientes.SelectedItem.ToString())

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

                If grip_nombre_archi.Rows(i).Cells(1).Value Then

                    nombre_archivo = grip_nombre_archi.Rows(i).Cells(0).Value

                    lo_ret_ejecucion = lo_biz.f_ejecutar_sql(nombre_archivo, txtdirectorio.Text, Comboambientes.SelectedItem.ToString())

                    If lo_ret_ejecucion.p_cod_error_i = 0 Then
                        grip_nombre_archi.Rows(i).Cells(2).Value = My.Resources.sql_exito_pequeno
                        grip_nombre_archi.Rows(i).Cells(3).Value = 1
                    Else
                        grip_nombre_archi.Rows(i).Cells(2).Value = My.Resources.sql_error_pequeno
                        grip_nombre_archi.Rows(i).Cells(3).Value = 0
                        MsgBox("Ocurrio un problema en ejecución: " & lo_ret_ejecucion.p_cod_error_i & " " & lo_ret_ejecucion.p_desc_error_c, vbCritical, "Atención")
                        Exit Sub
                    End If

                End If

            Next


        Catch ex As Exception

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

#End Region

End Class
