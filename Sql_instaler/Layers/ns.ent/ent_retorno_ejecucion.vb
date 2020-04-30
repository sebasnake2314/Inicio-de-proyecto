Public Class ent_retorno_ejecucion
    Inherits ent_retorno

    Private _p_liena_c As String
    Public Property p_liena_c() As String
        Get
            Return _p_liena_c
        End Get
        Set(ByVal value As String)
            _p_liena_c = value
        End Set
    End Property

End Class
