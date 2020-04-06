Imports Microsoft.VisualBasic

Public Class dal_Parametro

    'Variables privadas
    Private _Nombre As String
    Private _Valor As String

    'Propiedades públicas
    Public Property Nombre() As String
        Get
            Return _Nombre
        End Get
        Set(ByVal value As String)
            _Nombre = value
        End Set
    End Property

    Public Property Valor() As String
        Get
            Return _Valor
        End Get
        Set(ByVal value As String)
            _Valor = value
        End Set
    End Property
End Class
