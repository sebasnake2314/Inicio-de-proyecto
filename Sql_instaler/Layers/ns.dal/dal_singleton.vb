
Public Class dal_Singleton

    Private _is_StringConnection As String

    Private Sub New()
        Try
            is_StringConnection = f_Traer_ConnectionString()
        Catch ex As Exception
            _instancia = Nothing
        End Try

    End Sub

    Private Shared _instancia As dal_Singleton

    Public Shared Property Instancia() As dal_Singleton
        Get
            If _instancia Is Nothing Then
                _instancia = New dal_Singleton
            End If

            Return _instancia
        End Get
        Set(ByVal value As dal_Singleton)
            _instancia = New dal_Singleton
        End Set

    End Property


    Public Property is_StringConnection() As String
        Get
            Return _is_StringConnection
        End Get
        Set(ByVal value As String)
            _is_StringConnection = value
        End Set
    End Property



#Region "Configuración"
    ''' <summary>
    ''' Devuelve la cadena de conexión a partir de los parámetros ingresados en el web.config
    ''' </summary>
    ''' <returns>String</returns>
    ''' <remarks></remarks>
    Private Function f_Traer_ConnectionString() As String
        Dim ls_Usuario As String
        Dim ls_Password As String
        Dim lo_Enc As New ns.utl.utl_Encriptacion
        Try
            '---------------------------------------
            'Debug
            'If ns.utl.utl_Singleton.Instancia.is_Modo = "DEBUG" Then
            '    ns.utl.utl_Log.f_GuardarLog(System.Reflection.MethodBase.GetCurrentMethod().Name, "")
            'End If
            '---------------------------------------

            If utl_dal.f_Read_Config("encriptado") = "SI" Then

                ls_Usuario = utl_dal.f_Read_Config("usuario")
                ls_Password = lo_Enc.Decrypt(utl_dal.f_Read_Config("password"))

                Return f_Traer_ConnectionString(ls_Usuario, ls_Password)
            Else
                ns.utl.utl_Log.f_GuardarLog(System.Reflection.MethodBase.GetCurrentMethod().Name, "El Web.Config no está encriptado")
                Throw New Exception("El Web.Config no está encriptado")
            End If


        Catch ex As Exception
            ns.utl.utl_Log.f_GuardarLog(System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message)
            Return ""
        End Try
    End Function

    ''' <summary>
    ''' Devuelve la cadena de conexión a partir de los parámetros ingresados en el web.config
    ''' </summary>
    ''' <returns>String</returns>
    ''' <remarks></remarks>
    Private Function f_Traer_ConnectionString(ByVal pUsu As String, ByVal pPass As String) As String
        Dim ls_Servidor As String
        Dim ls_Puerto As String
        Dim ls_BaseDatos As String
        Dim lo_Enc As New ns.utl.utl_Encriptacion
        Try
            '---------------------------------------
            'Debug
            'If ns.utl.utl_Singleton.Instancia.is_Modo = "DEBUG" Then
            '    ns.utl.utl_Log.f_GuardarLog(System.Reflection.MethodBase.GetCurrentMethod().Name, "Usuario: " & pUsu)
            'End If
            '---------------------------------------

            ls_BaseDatos = utl_dal.f_Read_Config("basedatos")
            ls_Servidor = utl_dal.f_Read_Config("servidor")
            ls_Puerto = utl_dal.f_Read_Config("puerto")

            Return "Data Source=" + ls_Servidor + ";Port=" + ls_Puerto + ";Initial Catalog=" + ls_BaseDatos + ";User ID=" + pUsu + ";Password=" + pPass + ";CharSet=cp1252"

        Catch ex As Exception
            Return ""
        End Try

    End Function

#End Region

End Class


Public Class dal_Singleton_sqlServer
    Private _is_StringConnection As String
    Private _is_datasource As String
    Private _is_database As String
    Private _is_user As String
    Private _is_password As String

    Private Sub New()
        Try
            is_StringConnection = f_Traer_ConnectionString()
        Catch ex As Exception
            _instancia = Nothing
        End Try

    End Sub

    Private Shared _instancia As dal_Singleton_sqlServer

    Public Shared Property Instancia() As dal_Singleton_sqlServer
        Get
            If _instancia Is Nothing Then
                _instancia = New dal_Singleton_sqlServer
            End If

            Return _instancia
        End Get
        Set(ByVal value As dal_Singleton_sqlServer)
            _instancia = New dal_Singleton_sqlServer
        End Set

    End Property


    Public Property is_StringConnection() As String
        Get
            Return _is_StringConnection
        End Get
        Set(ByVal value As String)
            _is_StringConnection = value
        End Set
    End Property



#Region "Configuración"
    ''' <summary>
    ''' Devuelve la cadena de conexión a SqlServer
    ''' </summary>
    ''' <returns>String</returns>
    ''' <remarks></remarks>
    Private Function f_Traer_ConnectionString() As String
        Dim ls_User As String
        Dim ls_Password As String
        Dim ls_DataBase As String
        Dim ls_Server As String
        Dim lo_Enc As New ns.utl.utl_Encriptacion
        Try
            '---------------------------------------
            'Debug
            'If ns.utl.utl_Singleton.Instancia.is_Modo = "DEBUG" Then
            '    ns.utl.utl_Log.f_GuardarLog(System.Reflection.MethodBase.GetCurrentMethod().Name, "")
            'End If
            '---------------------------------------

            'Obtener parámetros de conexión
            If utl_dal.f_Read_Config("encriptado") = "SI" Then

                ls_Password = lo_Enc.Decrypt(utl_dal.f_Read_Config("sqlserver-password"))
            Else
                ls_Password = utl_dal.f_Read_Config("sqlserver-password")
            End If

            ls_User = utl_dal.f_Read_Config("sqlserver-usuario")
            ls_DataBase = utl_dal.f_Read_Config("sqlserver-basedatos")
            ls_Server = utl_dal.f_Read_Config("sqlserver-servidor")

            Return String.Format("Data Source={0};Initial Catalog={1};User ID={2};Password={3}", ls_Server, ls_DataBase, ls_User, ls_Password)



        Catch ex As Exception
            ns.utl.utl_Log.f_GuardarLog(System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message)
            Return ""
        End Try
    End Function


#End Region

End Class