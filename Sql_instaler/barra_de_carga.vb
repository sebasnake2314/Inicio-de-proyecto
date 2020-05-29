Imports ns.ent
Imports System.IO
Imports ns.biz
Imports System.ComponentModel
Imports System.Text
Public Class barra_de_carga
    Dim io_tipos_pac As New List(Of ent_tipo_paq)

    Private Sub barra_de_carga_Load(sender As Object, e As EventArgs) Handles Me.Load

    End Sub

    Private Sub barra_de_carga_Shown(sender As Object, e As EventArgs) Handles Me.Shown

        Dim nombre_archivo As String = ""
        Dim ruta As String = ""
        Dim Texto As String = ""
        Dim enca As String = ""
        Dim enca_final As String = ""
        Dim div_barra As Double = 0

        Try
            'Dim tipo_paquete As String = unificador_script.combotipopack.SelectedValue.ToString
            Dim tipo_paquete As String = datos_script_inicial.m_paquete_select_c
            Dim abre_tipo_paq_c As String = ""

            'Busqueda de abreviación del tipo de paquete
            For Each paquete As ent_tipo_paq In datos_script_inicial.m_tipos_paq_o
                If paquete.p_des_tipo_paq_c = tipo_paquete Then
                    abre_tipo_paq_c = paquete.p_abre_tipo_paq_c
                End If
            Next

            'Ruta de donde se cuentra el archivo de encabezado
            Dim recursos As String = My.Computer.FileSystem.CurrentDirectory
            enca = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\sql_instaler", "encabezado_SQL_Instaler", Nothing)


            Dim encabezado As String = enca
            Dim arr2 As String()
            Dim encabezado_final As String = ""
            arr2 = Split(encabezado, "#")
            For j As Integer = 0 To arr2.Length - 1
                encabezado_final += arr2(j) + vbNewLine
            Next


            Dim inicio As String = "p" & Trim(datos_script_inicial.m_nro_paquete_c) & " - " & datos_script_inicial.m_modulo_c


            'Modifico variables de encabezado
            enca_final = String.Format(encabezado_final, inicio, datos_script_inicial.m_mes_c, datos_script_inicial.m_dia_c, datos_script_inicial.m_anio_c, abre_tipo_paq_c & " " & Trim(datos_script_inicial.m_nro_sol_inc_ade_c) & " - " & datos_script_inicial.m_des_paquete_c)

            'nombre_archivo = Sql_Instaler.grip_nombre_archi.Rows(Sql_Instaler.grip_nombre_archi.SelectedCells.Item(0).RowIndex).Cells(0).Value
            'ruta = datos_script_inicial.m_directorio_c
            ruta = pantalla_principal_sql.txtdirectorio.Text
            'Preparo el texto con enzabezado y un salto de linea
            Texto = enca_final + vbNewLine


            'Recorro el datagripvier para obtener nombre de cada archivo y asi extraer el texto de cada uno
            Dim count_check As Integer = 0
            For i As Integer = 0 To pantalla_principal_sql.grip_nombre_archi.Rows.Count - 1

                If pantalla_principal_sql.grip_nombre_archi.Rows(i).Cells(2).Value Then

                    count_check += 1

                End If

            Next

            Dim d As Decimal = count_check + 1
            Dim r As Decimal = Math.Ceiling(d * 100D) / 100D


            div_barra = count_check + 1
            div_barra = 100 / div_barra
            div_barra = Math.Ceiling(div_barra)

            'Inicio de armar texto de archivo
            For i As Integer = 0 To pantalla_principal_sql.grip_nombre_archi.Rows.Count - 1

                If pantalla_principal_sql.grip_nombre_archi.Rows(i).Cells(2).Value Then
                    'Obtengo nombre del archivo en fila evaluada
                    nombre_archivo = pantalla_principal_sql.grip_nombre_archi.Rows(i).Cells(0).Value

                    If File.Exists(pantalla_principal_sql.txtdirectorio.Text & "\" & nombre_archivo & ".sql") Then
                        Dim sql As String = ""
                        'Agrego el texto de archivo .sql con salto de linea
                        If datos_script_inicial.m_separador_b = False Then
                            sql = vbNewLine + My.Computer.FileSystem.ReadAllText(ruta & "\" & nombre_archivo & ".sql", Encoding.Default) + Environment.NewLine
                        Else
                            sql = vbNewLine + My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\sql_instaler", "separador_SQL_Instaler", Nothing) + Environment.NewLine + My.Computer.FileSystem.ReadAllText(ruta & "\" & nombre_archivo & ".sql", Encoding.Default) + Environment.NewLine
                        End If

                        Texto = String.Format(Texto + "{0}", sql)

                    Else

                        If MsgBox("Hubo un problema con el archivo " & nombre_archivo & ".sql. ¿Desea continuar con el script inicial sin este archivo?.", vbInformation + vbYesNo, "Atención") = vbNo Then
                            Me.Close()
                            Exit Sub
                        End If
                    End If

                End If


                Label2.Text = ProgressBar1.Value & (" %")

                If ProgressBar1.Value >= 90 Then
                    Label1.Visible = True
                End If

                ProgressBar1.Increment(div_barra)

            Next





            'If datos_script_inicial.m_separador_b = False Then ------------------------------------------------------------------------------

            '    For i As Integer = 0 To pantalla_principal_sql.grip_nombre_archi.Rows.Count - 1

            '        If pantalla_principal_sql.grip_nombre_archi.Rows(i).Cells(1).Value Then
            '            'Obtengo nombre del archivo en fila evaluada
            '            nombre_archivo = pantalla_principal_sql.grip_nombre_archi.Rows(i).Cells(0).Value

            '            If File.Exists(pantalla_principal_sql.txtdirectorio.Text & "\" & nombre_archivo & ".sql") Then
            '                Dim sql As String = ""
            '                'Agrego el texto de archivo .sql con salto de linea
            '                sql = vbNewLine + My.Computer.FileSystem.ReadAllText(ruta & "\" & nombre_archivo & ".sql") + Environment.NewLine

            '                Texto = String.Format(Texto + "{0}", sql)

            '            Else

            '                If MsgBox("Hubo un problema con el archivo " & nombre_archivo & ".sql. ¿Desea continuar con el script inicial sin este archivo?.", vbInformation + vbYesNo, "Atención") = vbNo Then
            '                    Me.Close()
            '                    Exit Sub
            '                End If
            '            End If

            '        End If


            '        Label2.Text = ProgressBar1.Value & (" %")

            '        If ProgressBar1.Value >= 90 Then
            '            Label1.Visible = True
            '        End If

            '        ProgressBar1.Increment(div_barra)

            '    Next

            'Else

            '    For i As Integer = 0 To pantalla_principal_sql.grip_nombre_archi.Rows.Count - 1

            '        If pantalla_principal_sql.grip_nombre_archi.Rows(i).Cells(1).Value Then
            '            'Obtengo nombre del archivo en fila evaluada
            '            nombre_archivo = pantalla_principal_sql.grip_nombre_archi.Rows(i).Cells(0).Value

            '            If File.Exists(pantalla_principal_sql.txtdirectorio.Text & "\" & nombre_archivo & ".sql") = True Then
            '                Dim sql As String = ""
            '                'Agrego el texto de archivo .sql con salto de linea
            '                sql = vbNewLine + My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\sql_instaler", "separador_SQL_Instaler", Nothing) + Environment.NewLine + My.Computer.FileSystem.ReadAllText(ruta & "\" & nombre_archivo & ".sql") + Environment.NewLine
            '                Texto = String.Format(Texto + "{0}", sql)
            '            Else

            '                If MsgBox("Hubo un problema con el archivo " & nombre_archivo & ".sql. ¿Desea continuar con el script inicial sin este archivo?.", vbInformation + vbYesNo, "Atención") = vbNo Then
            '                    Me.Close()
            '                    Exit Sub
            '                End If
            '            End If

            '            'Agrego el texto de archivo .sql con salto de linea
            '            Texto = Texto + My.Computer.FileSystem.ReadAllText(ruta & "\" & nombre_archivo & ".sql") + Environment.NewLine
            '        End If


            '        Label2.Text = ProgressBar1.Value & (" %")
            '        ProgressBar1.Increment(div_barra)

            '        If ProgressBar1.Value >= 90 Then
            '            Label1.Visible = True
            '        End If


            '    Next
            'End If


            'Creo el archivo .sql
            'Dim directorio As String = unificador_script.txtdirectorio.Text
            'Dim nro_paquete As String = unificador_script.txtnropaquete.Text
            Dim oSW As New StreamWriter(datos_script_inicial.m_directorio_c & "\Script Inicial Paquete " & Trim(datos_script_inicial.m_nro_paquete_c) & ".sql", False, Encoding.Default)

            'Edito el contenido del archivo .sql
            oSW.WriteLine(Texto, Encoding.Default)
            oSW.Flush()
            oSW.Close()

            ProgressBar1.Increment(div_barra)
            Label2.Text = ProgressBar1.Value & (" %")

            'Barra de carga ---------------------------------------------------------------------
            'ProgressBar1.Increment(1)

            'If ProgressBar1.Value = 90 Then
            '    Label1.Visible = True
            'End If

            If ProgressBar1.Value >= 99 Then
                MsgBox("Script Inicial Paquete " & Trim(datos_script_inicial.m_nro_paquete_c) & ".sql, Creado con Éxito.", vbInformation)
                Me.Close()
            End If

            'Barra de carga ---------------------------------------------------------------------

        Catch ex As Exception

        End Try
    End Sub

End Class