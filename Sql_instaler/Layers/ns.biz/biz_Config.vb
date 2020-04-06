Imports ns.map
Public Class biz_Config


#Region "Propiedades"

    Private _is_StringConnection As String
    Public Property is_StringConnection() As String
        Get
            Return _is_StringConnection
        End Get
        Set(ByVal value As String)
            _is_StringConnection = value
        End Set
    End Property

#End Region


#Region "Configuración"

    ''' <summary>
    ''' Encripta los parámetros del Web.Config
    ''' </summary>
    ''' <param name="pPwd"></param>
    ''' <param name="pWinPwd"></param>
    ''' <remarks></remarks>
    Public Sub m_ModificarCambiarWebConfig(ByVal pPwd As String, ByVal pWinPwd As String)
        Try
            '---------------------------------------
            'Debug
            If ns.utl.utl_Singleton.Instancia.is_Modo = "DEBUG" Then
                ns.utl.utl_Log.f_GuardarLog(System.Reflection.MethodBase.GetCurrentMethod().Name, "**** - ****")
            End If
            '---------------------------------------

            Dim XmlDocument, doc As New System.Xml.XmlDocument
            Dim WebConfig As String = System.AppDomain.CurrentDomain.BaseDirectory + "app.config"
            'Cargo el Web.Config
            doc.Load(WebConfig)

            'Reemplazo los valores de las claves del Web.config
            For Each lo_xmlNode As System.Xml.XmlNode In doc.GetElementsByTagName("appSettings").Item(0).ChildNodes
                If Not IsNothing(lo_xmlNode.Attributes) Then
                    Select Case lo_xmlNode.Attributes("key").Value
                        Case "encriptado"
                            lo_xmlNode.Attributes("value").Value = "SI"

                        Case "password"
                            lo_xmlNode.Attributes("value").Value = pPwd

                        Case "win-password"
                            lo_xmlNode.Attributes("value").Value = pWinPwd
                    End Select
                End If
            Next

            'Cuardo el Web.config
            doc.Save(WebConfig)
            map_config.f_clear_string_conection()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#End Region


End Class
