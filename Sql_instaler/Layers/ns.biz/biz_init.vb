Imports ns.utl
Imports ns.ent
Imports ns.map
Public Class biz_init

    Public Sub f_init()
        Dim lo_utl As New ns.biz.biz_Config
        Dim lo_Impersonate As New ns.biz.biz_Impersonate
        ''Dim lo_log As New Log
        Dim ib_Impersonate_Result As Boolean

        Dim io_Enc As New ns.utl.utl_Encriptacion
        ns.utl.utl_Global.Application.as_Encriptado = System.Configuration.ConfigurationManager.AppSettings("encriptado")
        ns.utl.utl_Global.Application.ab_Impersonate = False


        'Revisar el Web.config si los datos están o no encriptados
        'Si no están encriptados, se encriptan y se guardan los cambios en el app.config
        Try
            'Cargar Parámetros No Encriptados
            ns.utl.utl_Global.f_Cargar_Parametros()

            If UCase(ns.utl.utl_Global.Application.as_Encriptado) = "NO" Then
                'Cargar Parámetros a Encriptar                    
                ns.utl.utl_Global.Application.as_Pwd = System.Configuration.ConfigurationManager.AppSettings("password")
                ns.utl.utl_Global.Application.as_WinPwd = System.Configuration.ConfigurationManager.AppSettings("win-password")

                'Encriptar Web.config
                ib_Impersonate_Result = lo_Impersonate.ImpersonateValidUser(ns.utl.utl_Global.Application.as_WinUsu, ns.utl.utl_Global.Application.as_WinDom, ns.utl.utl_Global.Application.as_WinPwd)

                If ib_Impersonate_Result Then
                    lo_utl.m_ModificarCambiarWebConfig(io_Enc.Encrypt(ns.utl.utl_Global.Application.as_Pwd), io_Enc.Encrypt(ns.utl.utl_Global.Application.as_WinPwd))
                    lo_Impersonate.UndoImpersonation()
                Else
                    'Guardar LOG
                    'lo_log.f_GuardarLog(System.Reflection.MethodBase.GetCurrentMethod().Name, "Error de Impersonate. Dominio: " & Application("as_WinDom") & ". Dominio: " & Application("as_WinUsu"))

                End If


            Else
                'Cargar Parámetros Encriptados
                ns.utl.utl_Global.Application.as_Pwd = io_Enc.Decrypt(System.Configuration.ConfigurationManager.AppSettings("password"))
                ns.utl.utl_Global.Application.as_WinPwd = io_Enc.Decrypt(System.Configuration.ConfigurationManager.AppSettings("win-password"))

            End If
        Catch

        End Try

    End Sub

End Class
