Public Class utl_Singleton
    Private _is_Modo As String

    Private Sub New()
        Try
            is_Modo = f_Traer_Modo()
        Catch ex As Exception
            _instancia = Nothing
        End Try

    End Sub

    Private Shared _instancia As utl_Singleton

    Public Shared ReadOnly Property Instancia() As utl_Singleton
        Get
            If _instancia Is Nothing Then
                _instancia = New utl_Singleton
            End If

            Return _instancia
        End Get
    End Property

    Public Property is_Modo() As String
        Get
            Return _is_Modo
        End Get
        Set(ByVal value As String)
            _is_Modo = value
        End Set
    End Property



#Region "Configuración"

    ''' <summary>
    ''' Devuelve la cadena de conexión a partir de los parámetros ingresados en el web.config
    ''' </summary>
    ''' <returns>String</returns>
    ''' <remarks></remarks>
    Private Function f_Traer_Modo() As String
        Dim ls_Modo As String
        Try
            ls_Modo = Me.f_Read_Config("Operacion")

            Return ls_Modo

        Catch ex As Exception
            Return ""
        End Try

    End Function

    ''' <summary>
    ''' Devuelve el valor de una clave del Web.config
    ''' </summary>
    ''' <returns>String</returns>
    ''' <remarks></remarks>
    Private Function f_Read_Config(ByVal p_Key As String) As String

        Dim a As New System.Configuration.AppSettingsReader
        Try
            Return a.GetValue(p_Key, GetType(String))
        Catch ex As Exception
            Return ""
        End Try
    End Function

#End Region

End Class
