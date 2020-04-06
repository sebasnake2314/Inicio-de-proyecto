Public Class ent_bases

#Region "Variable Publicas"

    Public _p_bases_o As List(Of String)

#End Region

#Region "Variables Privadas"

    Private Property p_bases_o() As List(Of String)
        Get
            Return _p_bases_o
        End Get
        Set(ByVal value As List(Of String))
            _p_bases_o = value
        End Set
    End Property

#End Region




End Class
