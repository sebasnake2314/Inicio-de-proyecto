Imports ns.ent
Imports ns.map
Public Class biz_preferencias
    Dim io_map As New map_preferencias
    Public Function f_actualizar_preferencias(ByVal p_directorio_c As String, ByVal p_id_ambiente_c As String) As ent_retorno
        Dim lo_ret As New ent_retorno
        Try
            lo_ret = io_map.f_actualizar_preferencias(p_directorio_c, p_id_ambiente_c)
        Catch ex As Exception

        End Try

        Return lo_ret
    End Function

    Public Function f_traer_ambiente() As ent_preferencias
        Dim lo_ret As New ent_preferencias
        Try
            lo_ret = io_map.f_traer_ambiente()
        Catch ex As Exception

        End Try

        Return lo_ret
    End Function

    Public Function f_agregar_ambiente(ByVal p_nombre_base_c As String, ByVal p_host_c As String, ByVal p_puerto_c As String, ByVal p_usuario_c As String, ByVal p_password_c As String, ByVal p_pass_encrip_b As Boolean) As ent_retorno
        Dim lo_ret As New ent_retorno

        Try
            If p_pass_encrip_b = True Then
                p_pass_encrip_b = 1
            Else
                p_pass_encrip_b = 0
            End If

            lo_ret = io_map.f_agregar_ambiente(p_nombre_base_c, p_host_c, p_puerto_c, p_usuario_c, p_password_c, p_pass_encrip_b)

        Catch ex As Exception

        End Try

        Return lo_ret
    End Function

    Public Function f_eliminar_ambiente(ByVal p_nombre_amb_c As String) As Integer
        Dim lo_ret As New Integer
        Dim lo_map As New map_preferencias
        Try

            lo_ret = lo_map.f_eliminar_ambiente(p_nombre_amb_c)

        Catch ex As Exception

        End Try
        Return lo_ret
    End Function

    Public Function f_traer_tipo_paq() As List(Of ent_tipo_paq)
        Dim lo_ret As New List(Of ent_tipo_paq)
        Dim lo_map As New map_preferencias
        Try
            lo_ret = lo_map.f_traer_tipo_paq()
        Catch ex As Exception
            Throw ex
        End Try

        Return lo_ret
    End Function

    Public Sub crear_tablas()
        Dim lo_map As New map_preferencias
        Try
            lo_map.crear_tablas()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class
