Public Class utl_Log

#Region "Tipos"
    Enum TipoLog
        [Error] = 1
        Exito = 2
    End Enum

#End Region

    ''' <summary>
    ''' Guarda en archivo de log
    ''' </summary>
    ''' <param name="p_Funcion"></param>
    ''' <param name="p_ErrorDesc"></param>
    ''' <remarks></remarks>
    Public Shared Function f_GuardarLog(ByVal p_Funcion As String, ByVal p_ErrorDesc As String) As Boolean
        Try
            f_GuardarLog(p_Funcion, p_ErrorDesc, TipoLog.Error)

        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function

    ''' <summary>
    ''' Guarda en archivo de log
    ''' </summary>
    ''' <param name="p_Funcion"></param>
    ''' <param name="p_ErrorDesc"></param>
    ''' <remarks></remarks>
    Public Shared Function f_GuardarLog(ByVal p_Funcion As String, ByVal p_ErrorDesc As String, ByVal p_Tipo As TipoLog) As Boolean
        Try
            Dim ls_log_path As String = System.Configuration.ConfigurationManager.AppSettings("LogFile")
            Dim Archivo As String = ls_log_path + String.Format("{0}_Log.txt", DateTime.Now.ToString("yyyyMMdd"))

            Dim lo_sw As New System.IO.StreamWriter(Archivo, True)
            Select Case p_Tipo
                Case TipoLog.Error

                    If ns.utl.utl_Singleton.Instancia.is_Modo = "DEBUG" Then
                        lo_sw.WriteLine(CStr(System.DateTime.Now) & "	DEBUG Función: " & p_Funcion & "	" & p_ErrorDesc)
                    Else
                        lo_sw.WriteLine(CStr(System.DateTime.Now) & "	Función: " & p_Funcion & "	" & p_ErrorDesc)
                    End If

                Case TipoLog.Exito
                    lo_sw.WriteLine(CStr(System.DateTime.Now) & "	Exito - Función: " & p_Funcion & "	" & p_ErrorDesc)
            End Select
            lo_sw.Close()

        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function

End Class
