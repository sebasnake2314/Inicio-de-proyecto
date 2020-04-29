Imports ns.dal
Imports ns.ent
Imports System.Data.SQLite
Imports ns.utl
Public Class map_parametros
    Dim DB_Path As String = "Data Source=" & (My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\sql_instaler", "bd_SQL_Instaler", Nothing)) & "\db.db"
    Public Sub f_set_parametros_de_conexión(ByVal p_usuario As String, ByVal p_password As String, ByVal p_hots As String, ByVal p_puerto As String)
        Dim lo_cadena_conexion As String = ""
        Dim lo_dal As New dal_Conexion
        Try
            'lo_cadena_conexion = "Data Source=" + p_hots + ";Port=" + p_puerto + ";Initial Catalog=" + ls_BaseDatos + ";User ID=" + p_usuario + ";Password=" + p_password + ";CharSet=cp1252"
            lo_cadena_conexion = "Data Source=" + p_hots + ";Port=" + p_puerto + ";User ID=" + p_usuario + ";Password=" + p_password + ";CharSet=cp1252"

            lo_dal.f_probar_conexion(lo_cadena_conexion)

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Public Function f_traer_parametros_de_conexion(ByVal p_nombre_ambiente As String) As ent_parametros_conex
        Dim lo_ret As New ent_parametros_conex
        Dim lo_tabla As String = "tb_ambientes"
        Dim SQLiteCon As New SQLiteConnection(DB_Path)
        Dim TableDB As New DataTable
        Dim encrip As New utl_Encriptacion
        Try

            Dim dt As New DataTable

            Dim Sql As String = String.Format("select * from {0} where amb_nombre_c = '{1}'", lo_tabla, p_nombre_ambiente)

            SQLiteCon.Open()

                LoadDB(Sql, dt, SQLiteCon)

            If dt.Rows.Count > 0 Then

                lo_ret.p_host_c = dt.Rows(0)("amb_ip_c")
                lo_ret.p_puerto_c = dt.Rows(0)("amd_puerto_c")
                lo_ret.p_usuario_c = dt.Rows(0)("amb_usuario_c")
                lo_ret.p_password_c = dt.Rows(0)("amb_password_c")
                lo_ret.p_es_encrip_i = dt.Rows(0)("amb_pass_encrip_b")

            End If

            If lo_ret.p_es_encrip_i = 1 Then
                lo_ret.p_password_c = encrip.Decrypt(lo_ret.p_password_c)
            End If

        Catch ex As Exception
            SQLiteCon.Dispose()
            SQLiteCon = Nothing
            MsgBox(ex.Message)
        End Try

        Return lo_ret
    End Function

    Private Sub LoadDB(ByVal q As String, ByVal tbl As DataTable, ByVal cn As SQLiteConnection)
        Dim SQLiteDA As New SQLiteDataAdapter(q, cn)
        SQLiteDA.Fill(tbl)
        SQLiteDA.Dispose()
        SQLiteDA = Nothing
    End Sub

End Class
