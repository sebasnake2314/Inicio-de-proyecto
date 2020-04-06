Public Class ent_parametro


#Region "Variables Privadas"

    Private _p_codigo_c As String
    Private _p_valor_c As String
    Private _p_descripcion_c As String

#End Region


#Region "Propiedades Publicas"

    Public Property p_codigo_c() As String
        Get
            Return _p_codigo_c
        End Get
        Set(ByVal value As String)
            _p_codigo_c = value
        End Set
    End Property
    Public Property p_valor_c() As String
        Get
            Return _p_valor_c
        End Get
        Set(ByVal value As String)
            _p_valor_c = value
        End Set
    End Property
    Public Property p_descripcion_c() As String
        Get
            Return _p_descripcion_c
        End Get
        Set(ByVal value As String)
            _p_descripcion_c = value
        End Set
    End Property

#End Region


End Class
