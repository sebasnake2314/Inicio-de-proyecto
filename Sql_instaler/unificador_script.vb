Imports ns.ent
Imports ns.biz
Imports System.IO
Imports System.ComponentModel
Public Class unificador_script
    Dim io_tipos_pac As New List(Of ent_tipo_paq)
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
        Dim nombre_archivo As String = ""
        Dim ruta As String = ""
        Dim Texto As String = ""
        Dim enca As String = ""
        Dim enca_final As String = ""

        'Dim IdProducto As Integer = 12
        'Dim NombreProducto As String = "Categoria Primera"
        'Dim FProductos As New FrmProductos(IdProducto, NombreProducto)
        'FProductos.Show()

        'Dim directorio As String = txtdirectorio.Text
        'Dim barra_carga As New barra_de_carga

        datos_script_inicial.m_directorio_c = txtdirectorio.Text
        datos_script_inicial.m_nro_paquete_c = txtnropaquete.Text
        datos_script_inicial.m_des_paquete_c = txtdespaquete.Text
        datos_script_inicial.m_separador_b = checkseparador.Checked
        datos_script_inicial.m_anio_c = fechaelegida.Value.Year
        datos_script_inicial.m_mes_c = fechaelegida.Value.Month
        datos_script_inicial.m_dia_c = fechaelegida.Value.Day
        datos_script_inicial.m_paquete_select_c = combotipopack.SelectedItem.ToString
        datos_script_inicial.m_modulo_c = txtmodu.Text
        datos_script_inicial.m_tipos_paq_o = io_tipos_pac

        Dim barra_carga As New barra_de_carga
        barra_carga.ShowDialog()
        barra_carga.Dispose()

        Me.Close()
        'Try
        '    'Obtengo datos fecha actual
        '    Dim dia As String = fechaelegida.Value.Day
        '    Dim mes As String = fechaelegida.Value.Month
        '    Dim año As String = fechaelegida.Value.Year
        '    Dim tipo_paquete As String = combotipopack.SelectedItem.ToString
        '    Dim abre_tipo_paq_c As String = ""

        '    'Busqueda de abreviación del tipo de paquete
        '    For Each paquete As ent_tipo_paq In io_tipos_pac
        '        If paquete.p_des_tipo_paq_c = tipo_paquete Then
        '            abre_tipo_paq_c = paquete.p_abre_tipo_paq_c
        '        End If
        '    Next

        '    'Ruta de donde se cuentra el archivo de encabezado
        '    Dim recursos As String = My.Computer.FileSystem.CurrentDirectory

        '    'Extraigo texto de encabexado
        '    'enca = My.Computer.FileSystem.ReadAllText(My.Computer.FileSystem.CurrentDirectory & "\" & "encabezado.sql")
        '    enca = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\sql_instaler", "encabezado_SQL_Instaler", Nothing)


        '    Dim encabezado As String = enca
        '    Dim arr2 As String()
        '    Dim encabezado_final As String = ""
        '    arr2 = Split(encabezado, "#")
        '    For j As Integer = 0 To arr2.Length - 1
        '        encabezado_final += arr2(j) + vbNewLine
        '    Next


        '    Dim inicio As String = "p" & Trim(txtnropaquete.Text) & " - " & txtmodu.Text

        '    'Modifico variables de encabezado
        '    enca_final = String.Format(encabezado_final, inicio, mes, dia, año, abre_tipo_paq_c & " " & Trim(txtnropaquete.Text) & " - " & txtdespaquete.Text)

        '    'nombre_archivo = Sql_Instaler.grip_nombre_archi.Rows(Sql_Instaler.grip_nombre_archi.SelectedCells.Item(0).RowIndex).Cells(0).Value
        '    ruta = pantalla_principal_sql.txtdirectorio.Text

        '    'Preparo el texto con enzabezado y un salto de linea
        '    Texto = enca_final + vbNewLine

        '    'Recorro el datagripvier para obtener nombre de cada archivo y asi extraer el texto de cada uno
        '    If checkseparador.Checked = True Then

        '        For i As Integer = 0 To pantalla_principal_sql.grip_nombre_archi.Rows.Count - 1

        '            If pantalla_principal_sql.grip_nombre_archi.Rows(i).Cells(1).Value Then
        '                'Obtengo nombre del archivo en fila evaluada
        '                nombre_archivo = pantalla_principal_sql.grip_nombre_archi.Rows(i).Cells(0).Value

        '                'Agrego el texto de archivo .sql con salto de linea
        '                Texto = Texto + My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\sql_instaler", "separador_SQL_Instaler", Nothing) + Environment.NewLine + My.Computer.FileSystem.ReadAllText(ruta & "\" & nombre_archivo & ".sql") + Environment.NewLine
        '            End If

        '        Next

        '    Else

        '        For i As Integer = 0 To pantalla_principal_sql.grip_nombre_archi.Rows.Count - 1

        '            If pantalla_principal_sql.grip_nombre_archi.Rows(i).Cells(1).Value Then
        '                'Obtengo nombre del archivo en fila evaluada
        '                nombre_archivo = pantalla_principal_sql.grip_nombre_archi.Rows(i).Cells(0).Value

        '                'Agrego el texto de archivo .sql con salto de linea
        '                Texto = Texto + My.Computer.FileSystem.ReadAllText(ruta & "\" & nombre_archivo & ".sql") + Environment.NewLine
        '            End If

        '        Next
        '    End If

        '    'Creo el archivo .sql
        '    Dim oSW As New StreamWriter(txtdirectorio.Text & "\Script Inicial Paquete " & Trim(txtnropaquete.Text) & ".sql")

        '    'Edito el contenido del archivo .sql
        '    oSW.WriteLine(Texto)
        '    oSW.Flush()
        '    oSW.Close()

        '    MsgBox("Script Inicial Paquete " & Trim(txtnropaquete.Text) & ".sql, Creado con Éxito.", vbInformation)


        '    For Each control As Control In Me.Controls
        '        'Filtramos solo aquellos de tipo TextBox 
        '        If TypeOf control Is TextBox Then
        '            control.Text = "" ' eliminar el texto  
        '        End If
        '    Next

        '    Me.Close()
        'Catch ex As Exception

        'End Try

    End Sub

    Private Sub unificador_script_Load(sender As Object, e As EventArgs) Handles Me.Load

        Dim lo_biz As New biz_preferencias
        Try
            txtdirectorio.Text = pantalla_principal_sql.txtdirectorio.Text

            io_tipos_pac = lo_biz.f_traer_tipo_paq()

            combotipopack.Items.Clear()

            For i As Integer = 0 To io_tipos_pac.Count - 1

                combotipopack.Items.Add(io_tipos_pac.Item(i).p_des_tipo_paq_c)

            Next

            combotipopack.SelectedIndex = 0

        Catch ex As Exception

        End Try

    End Sub


    Private Sub btncancelar_Click(sender As Object, e As EventArgs) Handles btncancelar.Click
        Try
            Me.Close()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub btndirectorio_Click(sender As Object, e As EventArgs) Handles btndirectorio.Click
        Dim Folder As New FolderBrowserDialog
        Try

            Folder.SelectedPath = txtdirectorio.Text

            If Folder.ShowDialog() = DialogResult.OK Then

                txtdirectorio.Text = IO.Path.GetDirectoryName(Folder.SelectedPath) & "\" & IO.Path.GetFileName(Folder.SelectedPath)

            End If

        Catch ex As Exception

        End Try
    End Sub
End Class