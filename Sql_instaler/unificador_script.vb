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
        datos_script_inicial.m_nro_sol_inc_ade_c = txtnro.Text
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