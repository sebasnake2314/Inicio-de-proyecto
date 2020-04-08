Imports ns.map
Public Class biz_conexion

    Public Sub f_set_parametros_de_conexión(ByVal p_usuario As String, ByVal p_password As String, ByVal p_hots As String, ByVal p_puerto As String)
        Dim lo_map As New map_parametros
        Try

            lo_map.f_set_parametros_de_conexión(p_usuario, p_password, p_hots, p_puerto)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub


End Class
