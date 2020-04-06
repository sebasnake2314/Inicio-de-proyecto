Public Class ent_tipo_paq
    Private _p_des_tipo_paq_c As String
    Private _p_abre_tipo_paq_c As String

    Public Property p_des_tipo_paq_c() As String
        Get
            Return _p_des_tipo_paq_c
        End Get
        Set(ByVal value As String)
            _p_des_tipo_paq_c = value
        End Set
    End Property

    Public Property p_abre_tipo_paq_c() As String
        Get
            Return _p_abre_tipo_paq_c
        End Get
        Set(ByVal value As String)
            _p_abre_tipo_paq_c = value
        End Set
    End Property

End Class
