''' <summary>
''' Clase de Excepciones de la capa de Dal
''' </summary>
''' <remarks></remarks>
Public Class exc_dal
    Inherits System.Exception

    Public Sub New(ByVal mensaje As String, ByVal ex As Exception)
        MyBase.New(mensaje, ex)
    End Sub

End Class