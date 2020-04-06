Public Class ent_consulta_existente


#Region "Variables Privadas"

    Private _p_id_consulta_i As Integer
    Private _p_documento_c As String
    Private _p_inc_pred_corregido_ajustado_c As String
    Private _p_comentario_c As String

#End Region


#Region "Propiedades Publicas"

    Public Property p_id_consulta_i() As Integer
        Get
            Return _p_id_consulta_i
        End Get
        Set(ByVal value As Integer)
            _p_id_consulta_i = value
        End Set
    End Property
    Public Property p_documento_c() As String
        Get
            Return _p_documento_c
        End Get
        Set(ByVal value As String)
            _p_documento_c = value
        End Set
    End Property
    Public Property p_inc_pred_corregido_ajustado() As String
        Get
            Return _p_inc_pred_corregido_ajustado_c
        End Get
        Set(ByVal value As String)
            _p_inc_pred_corregido_ajustado_c = value
        End Set
    End Property
    Public Property p_comentario_c() As String
        Get
            Return _p_comentario_c
        End Get
        Set(ByVal value As String)
            _p_comentario_c = value
        End Set
    End Property

#End Region


End Class
