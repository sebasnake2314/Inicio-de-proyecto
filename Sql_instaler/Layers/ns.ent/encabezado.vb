Public Class encabezado

    Public Function crear_encabezado() As String
        Dim lo_ret As String = ""
        Try

            lo_ret = "USE tcacdb #" _
                   & "GO #" _
                   & "/*=====================================================*/ #" _
                   & "print 	'------ Insert en Tabla tb_aps_versiones ------' #" _
                   & "GO #" _
                   & "/*=====================================================*/ #" _
                   & "INSERT INTO tb_aps_versiones #" _
                   & "SELECT 'paquete', '{0}' , convert(datetime,'{1}/{2}/{3}') , '{4}' , NULL, NULL #" _
                   & "GO"

        Catch ex As Exception
            Throw ex
        End Try
        Return lo_ret
    End Function

    Public Function crear_separador() As String
        Dim lo_ret As String = ""
        Try

            lo_ret = "-----------------------------------------------------------------------------------------------------------------------"

        Catch ex As Exception
            Throw ex
        End Try
        Return lo_ret
    End Function

End Class
