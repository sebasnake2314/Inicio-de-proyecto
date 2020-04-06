Imports ns.dal
Public Class map_Config

    Public Shared Sub f_clear_string_conection()
        Try
            dal_Singleton.Instancia = Nothing
        Catch ex As Exception

        End Try
    End Sub

End Class
