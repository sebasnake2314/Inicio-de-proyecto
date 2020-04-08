Public Class ent_parametros_conex

#Region "Variable privadas"
    Private _p_nombre_amb_c As String
    Private _p_usuario_c As String
    Private _p_password_c As String
    Private _p_host_c As String
    Private _p_puerto_c As String
    Private _p_es_encrip_i As String
#End Region

#Region "Variable publicas"
    Public Property p_nombre_amb_c() As String
        Get
            Return _p_nombre_amb_c
        End Get
        Set(ByVal value As String)
            _p_nombre_amb_c = value
        End Set
    End Property
    Public Property p_usuario_c() As String
        Get
            Return _p_usuario_c
        End Get
        Set(ByVal value As String)
            _p_usuario_c = value
        End Set
    End Property
    Public Property p_password_c() As String
        Get
            Return _p_password_c
        End Get
        Set(ByVal value As String)
            _p_password_c = value
        End Set
    End Property
    Public Property p_host_c() As String
        Get
            Return _p_host_c
        End Get
        Set(ByVal value As String)
            _p_host_c = value
        End Set
    End Property
    Public Property p_puerto_c() As String
        Get
            Return _p_puerto_c
        End Get
        Set(ByVal value As String)
            _p_puerto_c = value
        End Set
    End Property
    Public Property p_es_encrip_i() As String
        Get
            Return _p_es_encrip_i
        End Get
        Set(ByVal value As String)
            _p_es_encrip_i = value
        End Set
    End Property
#End Region

End Class
