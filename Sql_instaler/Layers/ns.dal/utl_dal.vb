Public Class utl_dal
    ''' <summary>
    ''' Devuelve el valor de una clave del Web.config
    ''' </summary>
    ''' <returns>String</returns>
    ''' <remarks></remarks>
    Shared Function f_Read_Config(ByVal p_Key As String) As String

        'Dim a As New System.Configuration.AppSettingsReader
        Dim doc As New System.Xml.XmlDocument
        Try
            'Return a.GetValue(p_Key, GetType(String))


            Dim WebConfig, ls_ret As String
            ls_ret = ""
            WebConfig = System.AppDomain.CurrentDomain.BaseDirectory + "App.config"
            'Cargo el Web.Config
            doc.Load(WebConfig)

            ' Return doc.GetElementsByTagName(p_Key).Item(0).Value = p_Key

            'Reemplazo los valores de las claves del Web.config
            For Each lo_xmlNode As System.Xml.XmlNode In doc.GetElementsByTagName("appSettings").Item(0).ChildNodes
                If Not IsNothing(lo_xmlNode.Attributes) Then
                    If lo_xmlNode.Attributes("key").Value = p_Key Then
                        ls_ret = lo_xmlNode.Attributes("value").Value
                    End If

                End If
            Next

            Return ls_ret
        Catch ex As Exception
            Return ""
        End Try
        If Not IsNothing(doc) Then doc = Nothing
    End Function

    ''' <summary>
    ''' Devuelve el valor de una clave del Web.config
    ''' </summary>
    ''' <returns>String</returns>
    ''' <remarks></remarks>
    Shared Function f_Read_Config(ByVal p_Key As String, ByVal p_Decrypt As Boolean) As String

        Dim a As New System.Configuration.AppSettingsReader
        Try
            If p_Decrypt Then
                Dim oEnc As New ns.utl.utl_Encriptacion
                Return oEnc.Decrypt(f_Read_Config(p_Key))

            Else : Return f_Read_Config(p_Key)
            End If

        Catch ex As Exception
            Return ""
        End Try
    End Function
End Class
