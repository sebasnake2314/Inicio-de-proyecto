Public Class ent_preferencias
    Inherits ent_retorno

    Private _p_is_ambiente_o As New List(Of String)
    Public Property p_is_ambiente_o() As List(Of String)
        Get
            Return _p_is_ambiente_o
        End Get
        Set(ByVal value As List(Of String))
            _p_is_ambiente_o = value
        End Set
    End Property

End Class
