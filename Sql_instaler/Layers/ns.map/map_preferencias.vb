Imports ns.ent
Imports System.Data.SQLite

Public Class map_preferencias
    Dim DB_Path As String = "Data Source=" & (My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\sql_instaler", "bd_SQL_Instaler", Nothing))
    'Dim DB_Path As String = "Data Source=" & (My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\sql_instaler", "bd_SQL_Instaler", Nothing))
    Public Function f_traer_ambiente() As ent_preferencias
        Dim lo_ret As New ent_preferencias
        Dim TableName As String = "tb_ambientes"

        Try

            lo_ret.p_cod_error_i = 1
            lo_ret.p_desc_error_c = "Se han guardado los datos con éxito"

            'DB_Path = "Data Source=" & System.IO.Directory.GetCurrentDirectory.ToString & "\db.db;"

            Dim SQLiteCon As New SQLiteConnection(DB_Path)
            Dim TableDB As New DataTable

            SQLiteCon.Close()

            Try
                SQLiteCon.Open()
            Catch ex As Exception
                SQLiteCon.Dispose()
                SQLiteCon = Nothing
                lo_ret.p_cod_error_i = -1
                lo_ret.p_desc_error_c = "Problemas al guardar los datos"
                '  MsgBox(ex.Message)
                Exit Function
            End Try

            LoadDB("select amb_nombre_c from " & TableName & "", TableDB, SQLiteCon)

            If TableDB.Rows.Count > 0 Then

                For i As Integer = 0 To TableDB.Rows.Count - 1
                    Dim campo As String = ""
                    campo = TableDB.Rows(i)("amb_nombre_c")
                    lo_ret.p_is_ambiente_o.Add(campo)
                Next
            End If

        Catch ex As Exception
            lo_ret.p_cod_error_i = -1
            lo_ret.p_desc_error_c = "Problemas al guardar los datos"
        End Try

        Return lo_ret
    End Function

    Public Function f_actualizar_preferencias(ByVal p_directorio_c As String, ByVal p_id_ambiente_c As String) As ent_retorno
        Dim lo_ret As New ent_retorno

        Try

            lo_ret.p_cod_error_i = 1
            lo_ret.p_desc_error_c = "Se han guardado los datos con éxito"

            Dim SQLiteCon As New SQLiteConnection(DB_Path)

            Try
                SQLiteCon.Open()
            Catch ex As Exception
                SQLiteCon.Dispose()
                SQLiteCon = Nothing
                lo_ret.p_cod_error_i = -1
                lo_ret.p_desc_error_c = "Problemas al guardar los datos"
                '  MsgBox(ex.Message)
                Exit Function
            End Try

            'Directorio
            Dim TableDB As New DataTable
            Dim sql As String = String.Format("update tb_preferencias set pre_valor_campo_c = '{0}' where pre_campo_c = 'PREFDIRECT'", p_directorio_c)

            Try
                ExecuteNonQuery(sql, SQLiteCon)
            Catch ex As Exception
                lo_ret.p_cod_error_i = -1
                lo_ret.p_desc_error_c = "Problemas al guardar los datos"
            End Try


            sql = ""
            sql = String.Format("update tb_preferencias set pre_valor_campo_c = '{0}' where pre_campo_c = 'PREAMBIENTE'", p_id_ambiente_c)

            Try
                ExecuteNonQuery(sql, SQLiteCon)
            Catch ex As Exception
                lo_ret.p_cod_error_i = -1
                lo_ret.p_desc_error_c = "Problemas al guardar los datos"
            End Try

            SQLiteCon.Close()

        Catch ex As Exception
            Throw ex
        End Try

        Return lo_ret
    End Function

    Public Function f_agregar_ambiente(ByVal p_nombre_base_c As String, ByVal p_host_c As String, ByVal p_puerto_c As String, ByVal p_usuario_c As String, ByVal p_password_c As String, ByVal p_pass_encrip_i As Integer) As ent_preferencias
        Dim lo_ret As New ent_preferencias
        Dim lo_tablas As String = "tb_ambientes"
        Dim lo_dt As New DataTable

        Try
            lo_ret.p_cod_error_i = 1
            lo_ret.p_desc_error_c = "Se han guardado los datos con éxito"

            Dim SQLiteCon As New SQLiteConnection(DB_Path)

            Try
                SQLiteCon.Open()
            Catch ex As Exception
                SQLiteCon.Dispose()
                SQLiteCon = Nothing
                lo_ret.p_cod_error_i = -1
                lo_ret.p_desc_error_c = "Problemas al guardar los datos"
                Return lo_ret
                Exit Function
            End Try

            Try
                Dim dt As New DataTable

                Dim Sql As String = String.Format("select 1 from {0} where amb_nombre_c = '{1}'", lo_tablas, p_nombre_base_c)

                LoadDB(Sql, dt, SQLiteCon)

                If dt.Rows.Count > 0 Then
                    lo_ret.p_cod_error_i = -1
                    lo_ret.p_desc_error_c = "Ya existe un Ambiente con este nombre"
                    Return lo_ret
                    Exit Function
                End If
            Catch ex As Exception

            End Try

            '-------------------------------------------------------------------------------------------------------------------------------------------------

            Try
                Dim TableDB As New DataTable

                Dim sql As String = String.Format("insert into " & lo_tablas & " (amb_nombre_c,amb_ip_c,amd_puerto_c,amb_usuario_c,amb_password_c,amb_pass_encrip_b) values ('{0}','{1}','{2}','{3}','{4}',{5})", p_nombre_base_c, p_host_c, p_puerto_c, p_usuario_c, p_password_c, p_pass_encrip_i)

                ExecuteNonQuery(sql, SQLiteCon)
                'MsgBox("Insert Data successfully")
            Catch ex As Exception
                MsgBox(ex.Message)
                lo_ret.p_cod_error_i = -1
                lo_ret.p_desc_error_c = "Problemas al guardar los datos"
            End Try
        Catch ex As Exception

        End Try

        Return lo_ret
    End Function

    Public Function f_eliminar_ambiente(ByVal p_nombre_amb_c As String) As Integer
        Dim lo_ret As Integer
        Dim lo_sp As String = ""
        Dim lo_tabla As String = "tb_ambientes"
        Try

            Dim SQLiteCon As New SQLiteConnection(DB_Path)

            Try
                SQLiteCon.Open()
            Catch ex As Exception
                SQLiteCon.Dispose()
                SQLiteCon = Nothing
                lo_ret = -1
                Return lo_ret
                Exit Function
            End Try

            'Dim dt As New DataTable
            Try
                Dim Sql As String = String.Format("delete from {0} where amb_nombre_c = '{1}'", lo_tabla, p_nombre_amb_c)

                ExecuteNonQuery(Sql, SQLiteCon)
            Catch ex As Exception
                lo_ret = -1
                Return lo_ret
                Exit Function
            End Try


        Catch ex As Exception
            MsgBox(ex.Message)
            lo_ret = -1
        End Try

        Return lo_ret
    End Function

    Public Function f_traer_tipo_paq() As List(Of ent_tipo_paq)

        Dim lo_ret As New List(Of ent_tipo_paq)

        Try

            Dim SQLiteCon As New SQLiteConnection(DB_Path)

            Try
                SQLiteCon.Open()
            Catch ex As Exception
                SQLiteCon.Dispose()
                SQLiteCon = Nothing
                Return lo_ret
                Exit Function
            End Try

            Dim dt As New DataTable

                Dim Sql As String = String.Format("select * from tb_tipos_paquete")

                LoadDB(Sql, dt, SQLiteCon)

                If dt.Rows.Count > 0 Then

                For i As Integer = 0 To dt.Rows.Count - 1

                    Dim tipo_paquete As New ent_tipo_paq

                    tipo_paquete.p_des_tipo_paq_c = dt.Rows(i)("tp_tipo_paque_c")
                    tipo_paquete.p_abre_tipo_paq_c = dt.Rows(i)("tb_abre_tipo_c")

                    lo_ret.Add(tipo_paquete)
                Next

            End If

        Catch ex As Exception

        End Try

        Return lo_ret
    End Function

    Public Sub crear_tablas()
        Dim Sql As String = ""
        Try

            Dim DB_Path_c As String = "Data Source=" & (My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\sql_instaler", "bd_SQL_Instaler", Nothing))
            Dim SQLiteCon As New SQLiteConnection(DB_Path_c)

            Try
                SQLiteCon.Open()
            Catch ex As Exception
                SQLiteCon.Dispose()
                SQLiteCon = Nothing
                'lo_ret.p_cod_error_i = -1
                'lo_ret.p_desc_error_c = "Problemas al guardar los datos"
                Throw ex
                Exit Sub
            End Try

            Try
                ' Dim Sql As String = String.Format("delete from {0} where amb_nombre_c = '{1}'", lo_tabla, p_nombre_amb_c)

                Sql = "CREATE TABLE 'tb_ambientes' (" _
                    & "'amb_id_i'	INTEGER, " _
                    & "'amb_nombre_c' TEXT, " _
                    & "'amb_ip_c'	TEXT, " _
                    & "'amd_puerto_c'	TEXT, " _
                    & "'amb_usuario_c'	TEXT, " _
                    & "'amb_password_c'	TEXT, " _
                    & "'amb_pass_encrip_b'	INTEGER, " _
                    & "'amb_tipo_bd_c'	TEXT, " _
                    & "PRIMARY KEY('amb_id_i'));"

                ExecuteNonQuery(Sql, SQLiteCon)
            Catch ex As Exception
                Throw ex
            End Try

            Try
                Sql = "CREATE TABLE 'tb_tipos_paquete' (" _
                     & "'tp_tipo_paque_c'	TEXT, " _
                     & "'tb_abre_tipo_c'	TEXT, " _
                     & "PRIMARY KEY('tp_tipo_paque_c'));"

                ExecuteNonQuery(Sql, SQLiteCon)

                'Se agregan los campos a base de datos
                agregar_campos()

                SQLiteCon.Close()
            Catch ex As Exception
                Throw ex
            End Try


        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Public Sub agregar_campos()

        Dim Sql As String = ""
        Try

            Dim DB_Path_c As String = "Data Source=" & (My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\sql_instaler", "bd_SQL_Instaler", Nothing))
            Dim SQLiteCon As New SQLiteConnection(DB_Path_c)

            Try
                SQLiteCon.Open()
            Catch ex As Exception
                SQLiteCon.Dispose()
                SQLiteCon = Nothing
                Throw ex
                Exit Sub
            End Try

            Try
                Sql = "Insert Into tb_tipos_paquete " _
                     & "(tp_tipo_paque_c,tb_abre_tipo_c) " _
                     & "Values('Solicitud','Sol.')"
                ExecuteNonQuery(Sql, SQLiteCon)

                Sql = "Insert Into tb_tipos_paquete " _
                     & "(tp_tipo_paque_c,tb_abre_tipo_c) " _
                     & "Values('Incidente','Inc.')"
                ExecuteNonQuery(Sql, SQLiteCon)


                Sql = "Insert Into tb_tipos_paquete " _
                     & "(tp_tipo_paque_c,tb_abre_tipo_c) " _
                     & "Values('Adenda','Adenda')"
                ExecuteNonQuery(Sql, SQLiteCon)

                SQLiteCon.Close()
            Catch ex As Exception
                Throw ex
            End Try

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function f_comprobar_bd() As ent_retorno
        Dim lo_ret As New ent_retorno
        Dim DB_Path_c As String = "Data Source=" & (My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\sql_instaler", "bd_SQL_Instaler", Nothing))
        Dim SQLiteCon As New SQLiteConnection(DB_Path_c)

        Try
            SQLiteCon.Open()
            lo_ret.p_cod_error_i = 1
            lo_ret.p_desc_error_c = "Conexión con Base local de datos con éxito"
        Catch ex As Exception
            SQLiteCon.Dispose()
            SQLiteCon = Nothing
            lo_ret.p_cod_error_i = 0
            lo_ret.p_desc_error_c = "Problemas con Conexión a Base local de datos"
        End Try
        Return lo_ret
    End Function

    Private Sub LoadDB(ByVal q As String, ByVal tbl As DataTable, ByVal cn As SQLiteConnection)
        Dim SQLiteDA As New SQLiteDataAdapter(q, cn)
        SQLiteDA.Fill(tbl)
        SQLiteDA.Dispose()
        SQLiteDA = Nothing
    End Sub

    Private Sub ExecuteNonQuery(ByVal query As String, ByVal cn As SQLiteConnection)
        Dim SQLiteCM As New SQLiteCommand(query, cn)
        SQLiteCM.ExecuteNonQuery()
        SQLiteCM.Dispose()
        SQLiteCM = Nothing
    End Sub

End Class
