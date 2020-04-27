Imports Sybase.Data.AseClient
Imports Sybase.Data.AseClient.AseDbType
Imports ns.ent
Imports System.IO
Imports ns.dal
Public Class map_ejecucion
    Dim io_Datos As New dal_Conexion
    Public Function f_ejecutar_sql(ByVal p_nombre_archivo As String, ByVal p_ruta As String, ByVal p_nombre_amb_c As String) As ent_retorno
        Dim lo_ret As New ent_retorno
        Dim lo_contenido_sql As String = ""
        Dim lo_cadena_conexion As String = ""
        Dim lo_parametros As New ent_parametros_conex
        Dim lo_map As New map_parametros
        'Dim sql_a_ejecución As String = lo_contenido_sql
        Dim sql_a_ejecución As String = ""
        Dim lo_base As String = ""
        Dim busqueda_linea As String = ""
        Try

            lo_ret.p_cod_error_i = 0
            lo_ret.p_desc_error_c = "Consulta ejecutada con éxito"

            lo_contenido_sql = My.Computer.FileSystem.ReadAllText(p_ruta & "\" & p_nombre_archivo & ".sql")

            lo_parametros = lo_map.f_traer_parametros_de_conexion(p_nombre_amb_c)

            Dim lector As New StreamReader(p_ruta & "\" & p_nombre_archivo & ".sql")

            ' Leer el contenido mientras no se llegue al final
            While lector.Peek() <> -1
                ' Leer una línea del fichero
                Dim linea As String = lector.ReadLine()

                'Si la linea esta vacia
                If String.IsNullOrEmpty(linea) Then
                    Continue While
                End If

                If Trim(linea) = "go" Then
                    linea = linea.Replace("go", "GO")
                End If

                sql_a_ejecución += linea + vbNewLine
            End While
            ' Cerrar el fichero
            lector.Close()

            Dim arr2 As String()
            Dim encabezado_final As String = ""

            'arr2 = Split(sql_a_ejecución, "go")
            arr2 = Split(sql_a_ejecución, "GO")
            For j As Integer = 0 To arr2.Length - 1

                'Divina linea para determinar si tiene un USE 
                Dim arr_base As String()
                'Dim linea_base As String = linea
                arr_base = Split(arr2(j))
                For a As Integer = 0 To arr_base.Length - 1

                    Dim SearchWithinThis As String = arr_base(a)

                    Dim linea_dividida As String()

                    linea_dividida = Split(SearchWithinThis, " ")

                    For u As Integer = 0 To linea_dividida.Length - 1

                        busqueda_linea = linea_dividida(u)

                        If IsNothing(busqueda_linea) Then
                            busqueda_linea = Replace(Replace(busqueda_linea, Chr(10), ""), Chr(13), "")
                            busqueda_linea = UCase(busqueda_linea.ToString)
                        End If

                        If String.IsNullOrEmpty(busqueda_linea) Then
                            Continue For
                        End If

                        If busqueda_linea = "USE" Then
                            lo_base = Replace(Replace(arr_base(1), Chr(10), ""), Chr(13), "")
                            'lo_base = Trim(linea_dividida(1))
                            'Exit For
                        End If

                    Next
                Next

                sql_a_ejecución = arr2(j)
                If Not IsNothing(lo_base) Then
                    lo_cadena_conexion = "Data Source=" + lo_parametros.p_host_c + ";Port=" + lo_parametros.p_puerto_c + ";Initial Catalog=" + lo_base + ";User ID=" + lo_parametros.p_usuario_c + ";Password=" + lo_parametros.p_password_c + ";CharSet=cp1252"
                Else
                    lo_cadena_conexion = "Data Source=" + lo_parametros.p_host_c + ";Port=" + lo_parametros.p_puerto_c + ";User ID=" + lo_parametros.p_usuario_c + ";Password=" + lo_parametros.p_password_c + ";CharSet=cp1252"
                End If

                io_Datos.f_Ejecutar_sql(sql_a_ejecución, lo_cadena_conexion)

            Next

        Catch ex As Exception

            lo_ret.p_cod_error_i = -1
            lo_ret.p_desc_error_c = ex.Message

        End Try

        Return lo_ret
    End Function



End Class
