Imports ns.map
Imports ns.ent
Public Class biz_ejecucion

    Public Function f_ejecutar_sql(ByVal p_nombre_archivo As String, ByVal p_ruta As String, ByVal p_nombre_amb_c As String) As ent_retorno
        Dim lo_ret As New ent_retorno
        Dim lo_map As New map_ejecucion
        Try

            lo_ret = lo_map.f_ejecutar_sql(p_nombre_archivo, p_ruta, p_nombre_amb_c)

        Catch ex As Exception
            lo_ret.p_cod_error_i = -2
            lo_ret.p_desc_error_c = "Ocurrio un problema"
        End Try

        Return lo_ret
    End Function

End Class
