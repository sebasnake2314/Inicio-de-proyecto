Public Class ent_retorno

    Private _p_desc_error_c As String
    Private _p_cod_error_i As Integer

    Public Property p_cod_error_i() As Integer
        Get
            Return _p_cod_error_i
        End Get
        Set(ByVal value As Integer)
            _p_cod_error_i = value
        End Set
    End Property

    Public Property p_desc_error_c() As String
        Get
            Return _p_desc_error_c
        End Get
        Set(ByVal value As String)
            _p_desc_error_c = value
        End Set
    End Property

End Class
