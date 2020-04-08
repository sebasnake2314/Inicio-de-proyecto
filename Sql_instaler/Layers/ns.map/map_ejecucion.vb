Imports Sybase.Data.AseClient
Imports Sybase.Data.AseClient.AseDbType
Imports ns.ent
Imports System.IO
Imports ns.dal
Public Class map_ejecucion
    Dim io_Datos As New dal_Conexion
    Public Function f_ejecutar_sql(ByVal p_nombre_archivo As String, ByVal p_ruta As String, ByVal p_nombre_amb_c As String) As ent_retorno
        Dim lo_ret As New ent_retorno
        Dim lo_contenido_sql As String = ""
        Dim lo_cadena_conexion As String = ""
        Dim lo_parametros As New ent_parametros_conex
        Dim lo_map As New map_parametros
        Try

            lo_ret.p_cod_error_i = 0
            lo_ret.p_desc_error_c = "Consulta ejecutada con éxito"

            lo_contenido_sql = My.Computer.FileSystem.ReadAllText(p_ruta & "\" & p_nombre_archivo & ".sql")

            lo_parametros = lo_map.f_traer_parametros_de_conexion(p_nombre_amb_c)

            lo_cadena_conexion = "Data Source=" + lo_parametros.p_host_c + ";Port=" + lo_parametros.p_puerto_c + ";User ID=" + lo_parametros.p_usuario_c + ";Password=" + lo_parametros.p_password_c + ";CharSet=cp1252"

            io_Datos.f_Ejecutar_sql(lo_contenido_sql, lo_cadena_conexion)


        Catch ex As Exception

            lo_ret.p_cod_error_i = -1
            lo_ret.p_desc_error_c = "Problemas al ejecutar la consulta"

        End Try

        Return lo_ret
    End Function

End Class
