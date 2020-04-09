<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class unificador_script
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(unificador_script))
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.titlebar = New System.Windows.Forms.Panel()
        Me.btnmini = New System.Windows.Forms.PictureBox()
        Me.btnclose = New System.Windows.Forms.PictureBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btndirectorio = New System.Windows.Forms.PictureBox()
        Me.btncancelar = New System.Windows.Forms.PictureBox()
        Me.btnsave = New System.Windows.Forms.PictureBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.checkseparador = New System.Windows.Forms.CheckBox()
        Me.txtdespaquete = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtmodu = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.fechaelegida = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtdirectorio = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.combotipopack = New System.Windows.Forms.ComboBox()
        Me.txtnropaquete = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.titlebar.SuspendLayout()
        CType(Me.btnmini, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnclose, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.btndirectorio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btncancelar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnsave, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label2.Location = New System.Drawing.Point(41, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(164, 19)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Unificardor de Script"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Sql_instaler.My.Resources.Resources.sql_instaler1
        Me.PictureBox1.Location = New System.Drawing.Point(8, 9)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(30, 31)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        '
        'titlebar
        '
        Me.titlebar.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.titlebar.Controls.Add(Me.btnmini)
        Me.titlebar.Controls.Add(Me.btnclose)
        Me.titlebar.Controls.Add(Me.Label2)
        Me.titlebar.Controls.Add(Me.PictureBox1)
        Me.titlebar.Dock = System.Windows.Forms.DockStyle.Top
        Me.titlebar.Location = New System.Drawing.Point(0, 0)
        Me.titlebar.Name = "titlebar"
        Me.titlebar.Size = New System.Drawing.Size(442, 47)
        Me.titlebar.TabIndex = 0
        '
        'btnmini
        '
        Me.btnmini.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnmini.Image = Global.Sql_instaler.My.Resources.Resources.minimizar
        Me.btnmini.Location = New System.Drawing.Point(368, 9)
        Me.btnmini.Name = "btnmini"
        Me.btnmini.Size = New System.Drawing.Size(33, 31)
        Me.btnmini.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.btnmini.TabIndex = 6
        Me.btnmini.TabStop = False
        Me.ToolTip1.SetToolTip(Me.btnmini, "Minimizar")
        '
        'btnclose
        '
        Me.btnclose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnclose.Image = Global.Sql_instaler.My.Resources.Resources.close
        Me.btnclose.Location = New System.Drawing.Point(407, 9)
        Me.btnclose.Name = "btnclose"
        Me.btnclose.Size = New System.Drawing.Size(33, 31)
        Me.btnclose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.btnclose.TabIndex = 5
        Me.btnclose.TabStop = False
        Me.ToolTip1.SetToolTip(Me.btnclose, "Cerrar")
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Panel1.Controls.Add(Me.btndirectorio)
        Me.Panel1.Controls.Add(Me.btncancelar)
        Me.Panel1.Controls.Add(Me.btnsave)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.checkseparador)
        Me.Panel1.Controls.Add(Me.txtdespaquete)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.txtmodu)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.fechaelegida)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.txtdirectorio)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.combotipopack)
        Me.Panel1.Controls.Add(Me.txtnropaquete)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Location = New System.Drawing.Point(5, 46)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(431, 246)
        Me.Panel1.TabIndex = 0
        '
        'btndirectorio
        '
        Me.btndirectorio.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btndirectorio.Image = Global.Sql_instaler.My.Resources.Resources.select_folder
        Me.btndirectorio.Location = New System.Drawing.Point(389, 88)
        Me.btndirectorio.Name = "btndirectorio"
        Me.btndirectorio.Size = New System.Drawing.Size(22, 19)
        Me.btndirectorio.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.btndirectorio.TabIndex = 47
        Me.btndirectorio.TabStop = False
        Me.ToolTip1.SetToolTip(Me.btndirectorio, "Selecionar ruta para creación de archivo sql")
        '
        'btncancelar
        '
        Me.btncancelar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btncancelar.Image = Global.Sql_instaler.My.Resources.Resources.cancelar
        Me.btncancelar.Location = New System.Drawing.Point(386, 206)
        Me.btncancelar.Name = "btncancelar"
        Me.btncancelar.Size = New System.Drawing.Size(33, 31)
        Me.btncancelar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.btncancelar.TabIndex = 46
        Me.btncancelar.TabStop = False
        Me.ToolTip1.SetToolTip(Me.btncancelar, "Cancelar")
        '
        'btnsave
        '
        Me.btnsave.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnsave.Image = Global.Sql_instaler.My.Resources.Resources.unificar_scripts
        Me.btnsave.Location = New System.Drawing.Point(347, 206)
        Me.btnsave.Name = "btnsave"
        Me.btnsave.Size = New System.Drawing.Size(33, 31)
        Me.btnsave.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.btnsave.TabIndex = 45
        Me.btnsave.TabStop = False
        Me.ToolTip1.SetToolTip(Me.btnsave, "Crear script unificado")
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label8.Location = New System.Drawing.Point(18, 163)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(126, 17)
        Me.Label8.TabIndex = 44
        Me.Label8.Text = "Agregar Separador:"
        '
        'checkseparador
        '
        Me.checkseparador.AutoSize = True
        Me.checkseparador.Location = New System.Drawing.Point(155, 164)
        Me.checkseparador.Name = "checkseparador"
        Me.checkseparador.Size = New System.Drawing.Size(15, 14)
        Me.checkseparador.TabIndex = 7
        Me.checkseparador.UseVisualStyleBackColor = True
        '
        'txtdespaquete
        '
        Me.txtdespaquete.BackColor = System.Drawing.Color.White
        Me.txtdespaquete.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtdespaquete.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.txtdespaquete.Location = New System.Drawing.Point(155, 138)
        Me.txtdespaquete.Name = "txtdespaquete"
        Me.txtdespaquete.Size = New System.Drawing.Size(248, 19)
        Me.txtdespaquete.TabIndex = 6
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label7.Location = New System.Drawing.Point(54, 138)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(90, 17)
        Me.Label7.TabIndex = 41
        Me.Label7.Text = "Des. Paquete:"
        '
        'txtmodu
        '
        Me.txtmodu.BackColor = System.Drawing.Color.White
        Me.txtmodu.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtmodu.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.txtmodu.Location = New System.Drawing.Point(155, 63)
        Me.txtmodu.Name = "txtmodu"
        Me.txtmodu.Size = New System.Drawing.Size(248, 19)
        Me.txtmodu.TabIndex = 3
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label6.Location = New System.Drawing.Point(8, 63)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(136, 17)
        Me.Label6.TabIndex = 39
        Me.Label6.Text = "Modulo/s afectado/s:"
        '
        'fechaelegida
        '
        Me.fechaelegida.CalendarForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.fechaelegida.CalendarMonthBackground = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(46, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.fechaelegida.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fechaelegida.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.fechaelegida.Location = New System.Drawing.Point(155, 113)
        Me.fechaelegida.Name = "fechaelegida"
        Me.fechaelegida.Size = New System.Drawing.Size(75, 19)
        Me.fechaelegida.TabIndex = 5
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label5.Location = New System.Drawing.Point(44, 113)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(105, 17)
        Me.Label5.TabIndex = 37
        Me.Label5.Text = "Fecha a asignar:"
        '
        'txtdirectorio
        '
        Me.txtdirectorio.BackColor = System.Drawing.Color.White
        Me.txtdirectorio.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtdirectorio.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.txtdirectorio.Location = New System.Drawing.Point(155, 88)
        Me.txtdirectorio.Name = "txtdirectorio"
        Me.txtdirectorio.Size = New System.Drawing.Size(234, 19)
        Me.txtdirectorio.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label1.Location = New System.Drawing.Point(30, 88)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(114, 17)
        Me.Label1.TabIndex = 34
        Me.Label1.Text = "Ruta de creación:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label4.Location = New System.Drawing.Point(55, 13)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(89, 17)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Tipo Paquete:"
        '
        'combotipopack
        '
        Me.combotipopack.BackColor = System.Drawing.Color.White
        Me.combotipopack.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.combotipopack.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.combotipopack.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.combotipopack.FormattingEnabled = True
        Me.combotipopack.Location = New System.Drawing.Point(155, 10)
        Me.combotipopack.Name = "combotipopack"
        Me.combotipopack.Size = New System.Drawing.Size(121, 21)
        Me.combotipopack.TabIndex = 1
        Me.combotipopack.Tag = "Solicitud"
        '
        'txtnropaquete
        '
        Me.txtnropaquete.BackColor = System.Drawing.Color.White
        Me.txtnropaquete.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtnropaquete.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.txtnropaquete.Location = New System.Drawing.Point(155, 37)
        Me.txtnropaquete.Name = "txtnropaquete"
        Me.txtnropaquete.Size = New System.Drawing.Size(75, 19)
        Me.txtnropaquete.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label3.Location = New System.Drawing.Point(55, 37)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(89, 17)
        Me.Label3.TabIndex = 30
        Me.Label3.Text = "Nro. Paquete:"
        '
        'unificador_script
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.ClientSize = New System.Drawing.Size(442, 298)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.titlebar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "unificador_script"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "unificador_script"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.titlebar.ResumeLayout(False)
        Me.titlebar.PerformLayout()
        CType(Me.btnmini, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnclose, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.btndirectorio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btncancelar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnsave, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Label2 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents titlebar As Panel
    Friend WithEvents btnmini As PictureBox
    Friend WithEvents btnclose As PictureBox
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label8 As Label
    Friend WithEvents checkseparador As CheckBox
    Public WithEvents txtdespaquete As TextBox
    Friend WithEvents Label7 As Label
    Public WithEvents txtmodu As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents fechaelegida As DateTimePicker
    Friend WithEvents Label5 As Label
    Public WithEvents txtdirectorio As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents combotipopack As ComboBox
    Public WithEvents txtnropaquete As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents btncancelar As PictureBox
    Friend WithEvents btnsave As PictureBox
    Friend WithEvents btndirectorio As PictureBox
End Class
