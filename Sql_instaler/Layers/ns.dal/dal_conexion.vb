Imports Sybase.Data.AseClient
Imports System.Data.SqlClient
Imports System.Data.SqlDbType
Imports Sybase.Data.AseClient.AseDbType
Imports ns.dal
Imports System.Data
Imports ns.ent
Public Class dal_Conexion

#Region " Variables "

    Private is_ConnectionString As String
    Private ib_dbConnection As AseConnection
    Private is_Usuario As String
    Private is_Password As String
    Private lb_mantener_conexion As Boolean = false

    Enum Direccion
        Input = 0
        Output = 1
    End Enum

#End Region

#Region " Propiedades "

    Public Property Usuario() As String
        Get
            Usuario = is_Usuario
        End Get
        Set(ByVal value As String)
            is_Usuario = value
        End Set
    End Property
    Public Property Password() As String
        Get
            Password = is_Password
        End Get
        Set(ByVal value As String)
            is_Password = value
        End Set
    End Property

#End Region

#Region "Patrón Singleton"

    ''' <summary>
    '''  Al instanciar esta clase se asinga el string de conexión
    '''  Lo toma del web.config.
    '''  </summary>
    ''' <remarks></remarks>
    Public Sub New()
        Try
            is_ConnectionString = dal_Singleton.Instancia.is_StringConnection

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#End Region

#Region " Metodos "

    ''' <summary>
    '''  Abre la conexión a la Base de datos
    '''  </summary>
    ''' <remarks></remarks>
    Private Sub f_Abrir()

        Try
            '---------------------------------------
            'Debug
            'If ns.utl.utl_Singleton.Instancia.is_Modo = "DEBUG" Then
            '    ns.utl.utl_Log.f_GuardarLog(System.Reflection.MethodBase.GetCurrentMethod().Name, "")
            'End If
            '---------------------------------------
            If lb_mantener_conexion = False Then
                ib_dbConnection = New AseConnection
                ib_dbConnection.ConnectionString = is_ConnectionString
                ib_dbConnection.Open()
            End If
            If lb_mantener_conexion = True Then
                If Not (ib_dbConnection.State = ConnectionState.Open) Then
                    ib_dbConnection = New AseConnection
                    ib_dbConnection.ConnectionString = is_ConnectionString
                    ib_dbConnection.Open()
                End If
            End If



        Catch ex As Exception
            'ns.utl.utl_Log.f_GuardarLog(System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message)
            Throw ex
        End Try
    End Sub

    ''' <summary>
    '''  Cierra la conexión a la Base de datos
    '''  </summary>
    ''' <remarks></remarks>
    Private Sub f_Cerrar()
        Try
            '---------------------------------------
            'Debug
            'If ns.utl.utl_Singleton.Instancia.is_Modo = "DEBUG" Then
            '    ns.utl.utl_Log.f_GuardarLog(System.Reflection.MethodBase.GetCurrentMethod().Name, "")
            'End If
            '---------------------------------------
            If lb_mantener_conexion = False Then
                ib_dbConnection.Close()
            End If

        Catch ex As Exception
            'ns.utl.utl_Log.f_GuardarLog(System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message)
            Throw ex
        End Try
    End Sub

    ''' <summary>
    ''' Ejecuta un stored procedure con el nombre y parametros pasados como argumento.
    ''' Se utiliza para los Sp utilizados para interactuar con las tablas
    ''' </summary>
    ''' <param name="p_SP">Nombre del StoredProcedure</param>
    ''' <param name="p_ArrParametros">Arreglo de parametros</param>
    ''' <returns>Retorna el resultado en un DataTable</returns>
    ''' <remarks></remarks>
    Public Function f_Ejecutar(ByVal p_SP As String, ByVal p_ArrParametros() As AseParameter) As DataTable

        Dim lo_Cmd As New AseCommand
        Dim lo_DT As New Data.DataTable
        Dim lo_DA As New AseDataAdapter
        Try
            '---------------------------------------
            'Debug
            'If ns.utl.utl_Singleton.Instancia.is_Modo = "DEBUG" Then
            '    ns.utl.utl_Log.f_GuardarLog(System.Reflection.MethodBase.GetCurrentMethod().Name, "SP: " & p_SP)
            'End If
            '---------------------------------------

            f_Abrir()
            lo_Cmd.Connection = ib_dbConnection
            lo_Cmd.CommandText = p_SP
            lo_Cmd.CommandType = CommandType.StoredProcedure
            If Not (p_ArrParametros Is Nothing) Then
                lo_Cmd.Parameters.AddRange(p_ArrParametros)
            End If

            'Se llena el datatable
            lo_DA.SelectCommand = lo_Cmd
            lo_DA.Fill(lo_DT)


        Catch sqlEx As AseException
            'Controlo algun error de Sql
            'ns.utl.utl_Log.f_GuardarLog(System.Reflection.MethodBase.GetCurrentMethod().Name, sqlEx.Message)
            Throw sqlEx
        Catch ex As Exception
            ' ns.utl.utl_Log.f_GuardarLog(System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message)
            Throw ex
        Finally
            'Si no está cerrada, Cierro la conexión
            If (ib_dbConnection.State = ConnectionState.Open) Then f_Cerrar()
        End Try

        Return lo_DT
    End Function

    ''' <summary>
    ''' Ejecuta un stored procedure con el nombre y parametros pasados como argumento.
    ''' Se utiliza para los Sp utilizados para interactuar con las tablas
    ''' </summary>
    ''' <param name="p_SP">Nombre del StoredProcedure</param>
    ''' <param name="p_ArrParametros">Arreglo de parametros</param>
    ''' <returns>Retorna el resultado en un DataTable</returns>
    ''' <remarks></remarks>
    Public Function f_Ejecutar_DT_output(ByVal p_SP As String, ByVal p_ArrParametros() As AseParameter) As DataTable

        Dim lo_Cmd As New AseCommand
        Dim lo_DT As New Data.DataTable
        Dim lo_DA As New AseDataAdapter
        Try
            '---------------------------------------
            'Debug
            'If ns.utl.utl_Singleton.Instancia.is_Modo = "DEBUG" Then
            '    ns.utl.utl_Log.f_GuardarLog(System.Reflection.MethodBase.GetCurrentMethod().Name, "SP: " & p_SP)
            'End If
            '---------------------------------------

            f_Abrir()
            lo_Cmd.Connection = ib_dbConnection
            lo_Cmd.CommandText = p_SP
            lo_Cmd.CommandType = CommandType.StoredProcedure
            lo_Cmd.NamedParameters = False
            If Not (p_ArrParametros Is Nothing) Then
                'lo_Cmd.Parameters.AddRange(p_ArrParametros)
                For i As Integer = 0 To p_ArrParametros.Length - 1
                    lo_Cmd.Parameters.Add(p_ArrParametros(i))
                Next

            End If

            'Retorno del SP
            'Dim retValue As New AseParameter("@retValue", AseDbType.Integer)
            'retValue.Direction = ParameterDirection.ReturnValue
            'lo_Cmd.Parameters.Add(retValue)

            'Se llena el datatable
            lo_DA.SelectCommand = lo_Cmd
            lo_DA.Fill(lo_DT)

            'lo_Cmd.ExecuteReader()


        Catch sqlEx As AseException
            'Controlo algun error de Sql
            'ns.utl.utl_Log.f_GuardarLog(System.Reflection.MethodBase.GetCurrentMethod().Name, sqlEx.Message)
            Throw sqlEx
        Catch ex As Exception
            'ns.utl.utl_Log.f_GuardarLog(System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message)
            Throw ex
        Finally
            'Si no está cerrada, Cierro la conexión
            If (ib_dbConnection.State = ConnectionState.Open) Then f_Cerrar()
        End Try

        Return lo_DT
    End Function

    ''' <summary>
    ''' Ejecuta un stored procedure con el nombre y parametros pasados como argumento.
    ''' Se utiliza para los Sp utilizados para interactuar con las tablas
    ''' </summary>
    ''' <param name="p_SP"></param>
    ''' <param name="p_Parametros"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function f_Ejecutar(ByVal p_SP As String, ByVal p_Parametros As List(Of dal_Parametro)) As DataTable

        Dim lo_Cmd As New AseCommand
        Dim lo_DT As New Data.DataTable
        Dim lo_DA As New AseDataAdapter
        Try
            '---------------------------------------
            'Debug
            'If ns.utl.utl_Singleton.Instancia.is_Modo = "DEBUG" Then
            '    ns.utl.utl_Log.f_GuardarLog(System.Reflection.MethodBase.GetCurrentMethod().Name, "SP: " & p_SP)
            'End If
            '---------------------------------------

            f_Abrir()
            lo_Cmd.Connection = ib_dbConnection
            lo_Cmd.CommandText = p_SP
            lo_Cmd.CommandType = CommandType.StoredProcedure
            AseCommandBuilder.DeriveParameters(lo_Cmd)
            If Not (p_Parametros Is Nothing) Then
                For Each lo_param As dal_Parametro In p_Parametros
                    For Each lo_AseParam As AseParameter In lo_Cmd.Parameters
                        If lo_AseParam.ParameterName = "@" + lo_param.Nombre Then
                            lo_AseParam.Value = lo_param.Valor
                        End If
                    Next
                Next
            End If

            'Se llena el datatable
            lo_DA.SelectCommand = lo_Cmd
            lo_DA.Fill(lo_DT)

        Catch sqlEx As AseException
            'Controlo algun error de Sql
            'ns.utl.utl_Log.f_GuardarLog(System.Reflection.MethodBase.GetCurrentMethod().Name, sqlEx.Message)
            Throw sqlEx
        Catch ex As Exception
            'ns.utl.utl_Log.f_GuardarLog(System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message)
            Throw ex
        Finally
            'Si no está cerrada, Cierro la conexión
            If (ib_dbConnection.State = ConnectionState.Open) Then f_Cerrar()
        End Try

        Return lo_DT
    End Function

    ''' <summary>
    ''' Ejecuta una consulta SQL.
    ''' </summary>
    ''' <param name="p_SQL">consulta SQL</param>
    ''' <returns>Retorna el resultado en un DataTable</returns>
    ''' <remarks></remarks>
    Public Function f_Ejecutar(ByVal p_SQL As String) As DataTable

        Dim lo_Cmd As New AseCommand
        Dim lo_DT As New Data.DataTable
        Dim lo_DA As New AseDataAdapter
        Try
            '---------------------------------------
            'Debug
            'If ns.utl.utl_Singleton.Instancia.is_Modo = "DEBUG" Then
            '    ns.utl.utl_Log.f_GuardarLog(System.Reflection.MethodBase.GetCurrentMethod().Name, "SQL: " & p_SQL)
            'End If
            '---------------------------------------

            f_Abrir()
            lo_Cmd.Connection = ib_dbConnection
            lo_Cmd.CommandText = p_SQL
            lo_Cmd.CommandType = CommandType.Text

            'Se llena el datatable
            lo_DA.SelectCommand = lo_Cmd
            lo_DA.Fill(lo_DT)

        Catch sqlEx As AseException
            'Controlo algun error de Sql
            'ns.utl.utl_Log.f_GuardarLog(System.Reflection.MethodBase.GetCurrentMethod().Name, sqlEx.Message)
            Throw sqlEx
        Catch ex As Exception
            'ns.utl.utl_Log.f_GuardarLog(System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message)
            Throw ex
        Finally
            'Si no está cerrada, Cierro la conexión
            If (ib_dbConnection.State = ConnectionState.Open) Then f_Cerrar()
        End Try

        Return lo_DT
    End Function

    ''' <summary>
    ''' Funcion que devuelve SqlParameter utilizado por el Mapper para crear cada parametro del Sp a ejecutar
    ''' </summary>
    ''' <param name="Nombre">Nombre del parámetro</param>
    ''' <param name="Tipo">Tipo sql</param>
    ''' <param name="Valor">Valor asignado</param>
    ''' <remarks>Retrona el parámetro en formato SqlParameter</remarks>
    Public Function f_CrearParametro(ByVal Nombre As String, ByVal Tipo As AseDbType, ByVal Valor As Object) As AseParameter
        Try
            ''---------------------------------------
            ''Debug
            'If ns.utl.utl_Singleton.Instancia.is_Modo = "DEBUG" Then
            '    ns.utl.utl_Log.f_GuardarLog(System.Reflection.MethodBase.GetCurrentMethod().Name, param.ParameterName)
            'End If
            ''---------------------------------------

            Dim param As New AseParameter()
            param = Me.f_CrearParametro(Nombre, Tipo, Valor, Direccion.Input)

            Return param

        Catch ex As Exception
            'ns.utl.utl_Log.f_GuardarLog(System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message)
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Funcion que devuelve SqlParameter utilizado por el Mapper para crear cada parametro del Sp a ejecutar
    ''' </summary>
    ''' <param name="Nombre">Nombre del parámetro</param>
    ''' <param name="Tipo">Tipo sql</param>
    ''' <param name="Valor">Valor asignado</param>
    ''' <remarks>Retrona el parámetro en formato SqlParameter</remarks>
    Public Function f_CrearParametro(ByVal Nombre As String, ByVal Tipo As AseDbType, ByVal Valor As Object, ByVal Direccion As Direccion) As AseParameter
        Try
            ''---------------------------------------
            ''Debug
            'If ns.utl.utl_Singleton.Instancia.is_Modo = "DEBUG" Then
            '    ns.utl.utl_Log.f_GuardarLog(System.Reflection.MethodBase.GetCurrentMethod().Name, param.ParameterName)
            'End If
            ''---------------------------------------

            Dim param As New AseParameter()
            param.ParameterName = Nombre
            param.AseDbType = Tipo
            If Valor Is Nothing Then
                param.Value = DBNull.Value
            Else
                If Tipo = AseDbType.VarChar And Valor.ToString().Length = 0 Then
                    param.Value = DBNull.Value
                Else
                    If Tipo = AseDbType.DateTime Then
                        If CDate(Valor).ToShortDateString = "01/01/0001" Then
                            param.Value = DBNull.Value
                        Else
                            param.Value = Valor
                        End If
                    Else
                        param.Value = Valor
                    End If
                End If
            End If


            Select Case Direccion
                Case Direccion.Output
                    param.Direction = ParameterDirection.Output

                Case Direccion.Input
                    param.Direction = ParameterDirection.Input
            End Select

            Return param

        Catch ex As Exception
            'ns.utl.utl_Log.f_GuardarLog(System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message)
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Controla y limpia los nulos de la base de datos
    ''' </summary>
    ''' <param name="p_Obj"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function f_ControlNull(ByVal p_Obj As Object) As Object
        If IsDBNull(p_Obj) Then
            Return Nothing
        Else
            Return p_Obj
        End If
    End Function

    Public Sub f_Ini_Transaccion()
        'Inicializa una transaccion

        Try
            If lb_mantener_conexion = False Then
                lb_mantener_conexion = True
                ib_dbConnection = New AseConnection
                ib_dbConnection.ConnectionString = is_ConnectionString
                ib_dbConnection.Open()
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub f_Fin_Transaccion()
        'Finaliza una transaccion
        Try
            If lb_mantener_conexion = True Then
                lb_mantener_conexion = False
                f_Cerrar()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub f_probar_conexion(ByVal p_cadena_conexion As String)

        Try
            '---------------------------------------
            'Debug
            'If ns.utl.utl_Singleton.Instancia.is_Modo = "DEBUG" Then
            '    ns.utl.utl_Log.f_GuardarLog(System.Reflection.MethodBase.GetCurrentMethod().Name, "")
            'End If
            '---------------------------------------
            If lb_mantener_conexion = False Then
                ib_dbConnection = New AseConnection
                ib_dbConnection.ConnectionString = p_cadena_conexion
                ib_dbConnection.Open()
            End If
            If lb_mantener_conexion = True Then
                If Not (ib_dbConnection.State = ConnectionState.Open) Then
                    ib_dbConnection = New AseConnection
                    ib_dbConnection.ConnectionString = is_ConnectionString
                    ib_dbConnection.Open()
                End If
            End If



        Catch ex As Exception
            'ns.utl.utl_Log.f_GuardarLog(System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message)
            Throw ex
        End Try


    End Sub


    Public Function f_Ejecutar_sql(ByVal p_SQL As String, ByVal p_cadena_conexion As String) As DataTable

        Dim lo_Cmd As New AseCommand
        Dim lo_DT As New Data.DataTable
        Dim lo_DA As New AseDataAdapter
        Try
            '---------------------------------------
            'Debug
            'If ns.utl.utl_Singleton.Instancia.is_Modo = "DEBUG" Then
            '    ns.utl.utl_Log.f_GuardarLog(System.Reflection.MethodBase.GetCurrentMethod().Name, "SQL: " & p_SQL)
            'End If
            '---------------------------------------

            f_Abrir_sql(p_cadena_conexion)
            lo_Cmd.Connection = ib_dbConnection
            lo_Cmd.CommandText = p_SQL
            lo_Cmd.CommandType = CommandType.Text

            'Se llena el datatable
            lo_DA.SelectCommand = lo_Cmd
            lo_DA.Fill(lo_DT)

        Catch sqlEx As AseException
            'Controlo algun error de Sql
            'ns.utl.utl_Log.f_GuardarLog(System.Reflection.MethodBase.GetCurrentMethod().Name, sqlEx.Message)
            Throw sqlEx
        Catch ex As Exception
            'ns.utl.utl_Log.f_GuardarLog(System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message)
            Throw ex
        Finally
            'Si no está cerrada, Cierro la conexión
            If (ib_dbConnection.State = ConnectionState.Open) Then f_Cerrar()
        End Try

        Return lo_DT
    End Function

    Private Sub f_Abrir_sql(ByVal p_cadena_conex As String)

        Try
            '---------------------------------------
            'Debug
            'If ns.utl.utl_Singleton.Instancia.is_Modo = "DEBUG" Then
            '    ns.utl.utl_Log.f_GuardarLog(System.Reflection.MethodBase.GetCurrentMethod().Name, "")
            'End If
            '---------------------------------------
            If lb_mantener_conexion = False Then
                ib_dbConnection = New AseConnection
                ib_dbConnection.ConnectionString = p_cadena_conex
                ib_dbConnection.Open()
            End If
            If lb_mantener_conexion = True Then
                If Not (ib_dbConnection.State = ConnectionState.Open) Then
                    ib_dbConnection = New AseConnection
                    ib_dbConnection.ConnectionString = is_ConnectionString
                    ib_dbConnection.Open()
                End If
            End If



        Catch ex As Exception
            'ns.utl.utl_Log.f_GuardarLog(System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message)
            Throw ex
        End Try
    End Sub


#End Region

End Class

Public Class dal_SqlServer

#Region " Variables "

    Private is_ConnectionString As String
    Private ib_dbConnection As Data.SqlClient.SqlConnection
    Private is_DataSource As String
    Private is_Database As String
    Private is_Usuario As String
    Private is_Password As String

    Enum Direccion
        Input = 0
        Output = 1
    End Enum

#End Region


#Region " Propiedades "

    Public Property DataSource() As String
        Get
            Return is_DataSource
        End Get
        Set(ByVal value As String)
            is_DataSource = value
        End Set
    End Property

    Public Property Database() As String
        Get
            Return is_Database
        End Get
        Set(ByVal value As String)
            is_Database = value
        End Set
    End Property

    Public Property Usuario() As String
        Get
            Return is_Usuario
        End Get
        Set(ByVal value As String)
            is_Usuario = value
        End Set
    End Property

    Public Property Password() As String
        Get
            Return is_Password
        End Get
        Set(ByVal value As String)
            is_Password = value
        End Set
    End Property

#End Region


#Region "Patrón Singleton"
    ''' <summary>
    '''  Al instanciar esta clase se asinga el string de conexión
    '''  Lo toma del web.config.
    '''  </summary>
    ''' <remarks></remarks>
    Public Sub New()
        Try
            is_ConnectionString = dal_Singleton_sqlServer.Instancia.is_StringConnection

        Catch ex As Exception
            Throw ex
        End Try
    End Sub



#End Region


#Region " Metodos "

    ''' <summary>
    '''  Abre la conexión a la Base de datos
    '''  </summary>
    ''' <remarks></remarks>
    Private Sub f_Abrir()

        Try
            '---------------------------------------
            'Debug
            'If ns.utl.utl_Singleton.Instancia.is_Modo = "DEBUG" Then
            '    ns.utl.utl_Log.f_GuardarLog(System.Reflection.MethodBase.GetCurrentMethod().Name, "")
            'End If
            '---------------------------------------

            ib_dbConnection = New SqlConnection
            'ib_dbConnection.ConnectionString = String.Format("Data Source={0};Initial Catalog={1};User ID={2};Password={3}", is_DataSource, is_Database, is_Usuario, is_Password)
            ib_dbConnection.ConnectionString = is_ConnectionString
            ib_dbConnection.Open()

        Catch ex As Exception
            ns.utl.utl_Log.f_GuardarLog(System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message)
            Throw ex
        End Try
    End Sub

    ''' <summary>
    '''  Cierra la conexión a la Base de datos
    '''  </summary>
    ''' <remarks></remarks>
    Private Sub f_Cerrar()
        Try
            '---------------------------------------
            'Debug
            'If ns.utl.utl_Singleton.Instancia.is_Modo = "DEBUG" Then
            '    ns.utl.utl_Log.f_GuardarLog(System.Reflection.MethodBase.GetCurrentMethod().Name, "")
            'End If
            '---------------------------------------

            ib_dbConnection.Close()

        Catch ex As Exception
            ns.utl.utl_Log.f_GuardarLog(System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message)
            Throw ex
        End Try
    End Sub

    ''' <summary>
    ''' Ejecuta un stored procedure con el nombre y parametros pasados como argumento.
    ''' Se utiliza para los Sp utilizados para interactuar con las tablas
    ''' </summary>
    ''' <param name="p_SP">Nombre del StoredProcedure</param>
    ''' <param name="p_ArrParametros">Arreglo de parametros</param>
    ''' <returns>Retorna el resultado en un DataTable</returns>
    ''' <remarks></remarks>
    Public Function f_Ejecutar(ByVal p_SP As String, ByVal p_ArrParametros() As SqlParameter) As DataTable

        Dim lo_Cmd As New SqlCommand
        Dim lo_DT As New Data.DataTable
        Dim lo_DA As New SqlDataAdapter
        Try
            '---------------------------------------
            'Debug
            'If ns.utl.utl_Singleton.Instancia.is_Modo = "DEBUG" Then
            '    ns.utl.utl_Log.f_GuardarLog(System.Reflection.MethodBase.GetCurrentMethod().Name, "SP: " & p_SP)
            'End If
            '---------------------------------------

            f_Abrir()
            lo_Cmd.Connection = ib_dbConnection
            lo_Cmd.CommandText = p_SP
            lo_Cmd.CommandType = CommandType.StoredProcedure
            'lo_Cmd.NamedParameters = False
            If Not (p_ArrParametros Is Nothing) Then
                'lo_Cmd.Parameters.AddRange(p_ArrParametros)
                For i As Integer = 0 To p_ArrParametros.Length - 1
                    lo_Cmd.Parameters.Add(p_ArrParametros(i))
                Next

            End If

            'Retorno del SP
            'Dim retValue As New AseParameter("@retValue", AseDbType.Integer)
            'retValue.Direction = ParameterDirection.ReturnValue
            'lo_Cmd.Parameters.Add(retValue)

            'Se llena el datatable
            lo_DA.SelectCommand = lo_Cmd
            lo_DA.Fill(lo_DT)

            'lo_Cmd.ExecuteNonQuery()




        Catch sqlEx As SqlException
            'Controlo algun error de Sql
            'ns.utl.utl_Log.f_GuardarLog(System.Reflection.MethodBase.GetCurrentMethod().Name, sqlEx.Message)
            Throw sqlEx
        Catch ex As Exception
            ns.utl.utl_Log.f_GuardarLog(System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message)
            Throw ex
        Finally
            'Si no está cerrada, Cierro la conexión
            If (ib_dbConnection.State = ConnectionState.Open) Then f_Cerrar()
        End Try

        Return lo_DT
    End Function

    ''' <summary>
    ''' Ejecuta un stored procedure con el nombre y parametros pasados como argumento.
    ''' Se utiliza para los Sp utilizados para interactuar con las tablas
    ''' </summary>
    ''' <param name="p_SP"></param>
    ''' <param name="p_Parametros"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function f_Ejecutar(ByVal p_SP As String, ByVal p_Parametros As List(Of dal_Parametro)) As DataTable

        Dim lo_Cmd As New SqlCommand
        Dim lo_DT As New Data.DataTable
        Dim lo_DA As New SqlDataAdapter
        Try
            '---------------------------------------
            'Debug
            'If ns.utl.utl_Singleton.Instancia.is_Modo = "DEBUG" Then
            '    ns.utl.utl_Log.f_GuardarLog(System.Reflection.MethodBase.GetCurrentMethod().Name, "SP: " & p_SP)
            'End If
            '---------------------------------------

            f_Abrir()
            lo_Cmd.Connection = ib_dbConnection
            lo_Cmd.CommandText = p_SP
            lo_Cmd.CommandType = CommandType.StoredProcedure
            SqlCommandBuilder.DeriveParameters(lo_Cmd)
            If Not (p_Parametros Is Nothing) Then
                For Each lo_param As dal_Parametro In p_Parametros
                    For Each lo_SqlParam As SqlParameter In lo_Cmd.Parameters
                        If lo_SqlParam.ParameterName = "@" + lo_param.Nombre Then
                            lo_SqlParam.Value = lo_param.Valor
                        End If
                    Next
                Next
            End If

            'Se llena el datatable
            lo_DA.SelectCommand = lo_Cmd
            lo_DA.Fill(lo_DT)

        Catch sqlEx As SqlException
            'Controlo algun error de Sql
            ns.utl.utl_Log.f_GuardarLog(System.Reflection.MethodBase.GetCurrentMethod().Name, sqlEx.Message)
            Throw sqlEx
        Catch ex As Exception
            ns.utl.utl_Log.f_GuardarLog(System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message)
            Throw ex
        Finally
            'Si no está cerrada, Cierro la conexión
            If (ib_dbConnection.State = ConnectionState.Open) Then f_Cerrar()
        End Try

        Return lo_DT
    End Function

    ''' <summary>
    ''' Ejecuta una consulta SQL.
    ''' </summary>
    ''' <param name="p_SQL">consulta SQL</param>
    ''' <returns>Retorna el resultado en un DataTable</returns>
    ''' <remarks></remarks>
    Public Function f_Ejecutar(ByVal p_SQL As String) As DataTable

        Dim lo_Cmd As New SqlCommand
        Dim lo_DT As New Data.DataTable
        Dim lo_DA As New SqlDataAdapter
        Try
            '---------------------------------------
            'Debug
            'If ns.utl.utl_Singleton.Instancia.is_Modo = "DEBUG" Then
            '    ns.utl.utl_Log.f_GuardarLog(System.Reflection.MethodBase.GetCurrentMethod().Name, "SQL: " & p_SQL)
            'End If
            '---------------------------------------

            f_Abrir()
            lo_Cmd.Connection = ib_dbConnection
            lo_Cmd.CommandText = p_SQL
            lo_Cmd.CommandType = CommandType.Text

            'Se llena el datatable
            lo_DA.SelectCommand = lo_Cmd
            lo_DA.Fill(lo_DT)

        Catch sqlEx As SqlException
            'Controlo algun error de Sql
            ns.utl.utl_Log.f_GuardarLog("DAL SQLServer - sqlEx - " + System.Reflection.MethodBase.GetCurrentMethod().Name, sqlEx.Message + " - " + p_SQL)
            Throw sqlEx
        Catch ex As Exception
            ns.utl.utl_Log.f_GuardarLog("DAL SQLServer - Ex - " + System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message + " - " + p_SQL)
            Throw ex
        Finally
            'Si no está cerrada, Cierro la conexión
            If (ib_dbConnection.State = ConnectionState.Open) Then f_Cerrar()
        End Try

        Return lo_DT
    End Function

    ''' <summary>
    ''' Funcion que devuelve SqlParameter utilizado por el Mapper para crear cada parametro del Sp a ejecutar
    ''' </summary>
    ''' <param name="Nombre">Nombre del parámetro</param>
    ''' <param name="Tipo">Tipo sql</param>
    ''' <param name="Valor">Valor asignado</param>
    ''' <remarks>Retrona el parámetro en formato SqlParameter</remarks>
    Public Function f_CrearParametro(ByVal Nombre As String, ByVal Tipo As SqlDbType, ByVal Valor As Object) As SqlParameter
        Try
            ''---------------------------------------
            ''Debug
            'If ns.utl.utl_Singleton.Instancia.is_Modo = "DEBUG" Then
            '    ns.utl.utl_Log.f_GuardarLog(System.Reflection.MethodBase.GetCurrentMethod().Name, param.ParameterName)
            'End If
            ''---------------------------------------

            Dim param As New SqlParameter()
            param = Me.f_CrearParametro(Nombre, Tipo, Valor, Direccion.Input)

            Return param

        Catch ex As Exception
            ns.utl.utl_Log.f_GuardarLog(System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message)
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Funcion que devuelve SqlParameter utilizado por el Mapper para crear cada parametro del Sp a ejecutar
    ''' </summary>
    ''' <param name="Nombre">Nombre del parámetro</param>
    ''' <param name="Tipo">Tipo sql</param>
    ''' <param name="Valor">Valor asignado</param>
    ''' <remarks>Retrona el parámetro en formato SqlParameter</remarks>
    Public Function f_CrearParametro(ByVal Nombre As String, ByVal Tipo As SqlDbType, ByVal Valor As Object, ByVal Direccion As Direccion) As SqlParameter
        Try
            ''---------------------------------------
            ''Debug
            'If ns.utl.utl_Singleton.Instancia.is_Modo = "DEBUG" Then
            '    ns.utl.utl_Log.f_GuardarLog(System.Reflection.MethodBase.GetCurrentMethod().Name, param.ParameterName)
            'End If
            ''---------------------------------------

            Dim param As New SqlParameter()
            param.ParameterName = Nombre
            param.SqlDbType = Tipo
            If Valor Is Nothing Then
                param.Value = DBNull.Value
            Else
                If Tipo = SqlDbType.VarChar And Valor.ToString().Length = 0 Then
                    param.Value = DBNull.Value
                Else
                    If Tipo = SqlDbType.DateTime Then
                        If CDate(Valor).ToShortDateString = "01/01/0001" Then
                            param.Value = DBNull.Value
                        Else
                            param.Value = Valor
                        End If
                    Else
                        param.Value = Valor
                    End If
                End If
            End If


            Select Case Direccion
                Case Direccion.Output
                    param.Direction = ParameterDirection.Output

                Case Direccion.Input
                    param.Direction = ParameterDirection.Input
            End Select

            Return param

        Catch ex As Exception
            ns.utl.utl_Log.f_GuardarLog(System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message)
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Controla y limpia los nulos de la base de datos
    ''' </summary>
    ''' <param name="p_Obj"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function f_ControlNull(ByVal p_Obj As Object) As Object
        If IsDBNull(p_Obj) Then
            Return Nothing
        Else
            Return p_Obj
        End If
    End Function


    Public Function f_Ini_Transaccion() As Boolean
        'Inicializa una transaccion
        Dim lb_retorno As Boolean
        Try
            lb_retorno = True
        Catch ex As Exception
            Throw ex
        End Try

        Return lb_retorno
    End Function

    Public Function f_Fin_Transaccion() As Boolean
        'Finaliza una transaccion
        Dim lb_retorno As Boolean
        Try
            lb_retorno = True
        Catch ex As Exception
            Throw ex
        End Try

        Return lb_retorno
    End Function

#End Region


End Class
