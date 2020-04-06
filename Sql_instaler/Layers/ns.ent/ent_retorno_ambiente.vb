Public Class ent_retorno_ambiente

    Inherits ent_retorno

    Private _p_id_ambiente_i As Integer
    Private _p_des_ambiente_c As String

    Public Property p_id_ambiente_i() As Integer
        Get
            Return _p_id_ambiente_i
        End Get
        Set(ByVal value As Integer)
            _p_id_ambiente_i = value
        End Set
    End Property

    Public Property p_des_ambiente_c() As String
        Get
            Return _p_des_ambiente_c
        End Get
        Set(ByVal value As String)
            _p_des_ambiente_c = value
        End Set
    End Property

End Class
