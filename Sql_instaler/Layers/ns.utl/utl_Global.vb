Imports ns.ent
Public Class utl_Global

    Public Shared Application As New ent_global
    Public Shared Sub f_Cargar_Parametros()
        Try
            Application.as_Server = System.Configuration.ConfigurationManager.AppSettings("servidor")
            Application.as_Puerto = System.Configuration.ConfigurationManager.AppSettings("puerto")
            Application.as_DB = System.Configuration.ConfigurationManager.AppSettings("basedatos")

            Application.as_Usu = System.Configuration.ConfigurationManager.AppSettings("usuario")
            'Application("as_Pwd") = System.Configuration.ConfigurationManager.AppSettings("password")

            Application.as_WinDom = System.Configuration.ConfigurationManager.AppSettings("win-dominio")
            Application.as_WinUsu = System.Configuration.ConfigurationManager.AppSettings("win-usuario")
            'Application("as_WinPwd") = System.Configuration.ConfigurationManager.AppSettings("win-password")

            Application.as_file_path_temp = System.Configuration.ConfigurationManager.AppSettings("file_path_temp")
            Application.as_file_path = System.Configuration.ConfigurationManager.AppSettings("file_path")
            Application.as_operacion = System.Configuration.ConfigurationManager.AppSettings("Operacion")

        Catch ex As Exception

        End Try

    End Sub
End Class
