<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Administrador_de_ambientes
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Administrador_de_ambientes))
        Me.Label2 = New System.Windows.Forms.Label()
        Me.titlebar = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Checkencrip = New System.Windows.Forms.CheckBox()
        Me.txtpassword = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtusuario = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtpuerto = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txthost = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtnombre = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.btntest = New System.Windows.Forms.PictureBox()
        Me.btncancelar = New System.Windows.Forms.PictureBox()
        Me.btnsave = New System.Windows.Forms.PictureBox()
        Me.btnmini = New System.Windows.Forms.PictureBox()
        Me.btnclose = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.titlebar.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.btntest, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btncancelar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnsave, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnmini, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnclose, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label2.Location = New System.Drawing.Point(41, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(230, 19)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Administrador de Ambientes"
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
        Me.titlebar.Size = New System.Drawing.Size(366, 47)
        Me.titlebar.TabIndex = 2
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Panel1.Controls.Add(Me.btntest)
        Me.Panel1.Controls.Add(Me.btncancelar)
        Me.Panel1.Controls.Add(Me.btnsave)
        Me.Panel1.Controls.Add(Me.Checkencrip)
        Me.Panel1.Controls.Add(Me.txtpassword)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.txtusuario)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.txtpuerto)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.txthost)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.txtnombre)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(8, 46)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(351, 188)
        Me.Panel1.TabIndex = 3
        '
        'Checkencrip
        '
        Me.Checkencrip.AutoSize = True
        Me.Checkencrip.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Checkencrip.Location = New System.Drawing.Point(9, 136)
        Me.Checkencrip.Name = "Checkencrip"
        Me.Checkencrip.Size = New System.Drawing.Size(126, 17)
        Me.Checkencrip.TabIndex = 40
        Me.Checkencrip.Text = "Password Encriptado"
        Me.Checkencrip.UseVisualStyleBackColor = True
        '
        'txtpassword
        '
        Me.txtpassword.BackColor = System.Drawing.Color.White
        Me.txtpassword.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtpassword.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtpassword.Location = New System.Drawing.Point(72, 111)
        Me.txtpassword.Name = "txtpassword"
        Me.txtpassword.Size = New System.Drawing.Size(274, 19)
        Me.txtpassword.TabIndex = 39
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label6.Location = New System.Drawing.Point(3, 111)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(66, 17)
        Me.Label6.TabIndex = 38
        Me.Label6.Text = "Password:"
        '
        'txtusuario
        '
        Me.txtusuario.BackColor = System.Drawing.Color.White
        Me.txtusuario.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtusuario.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtusuario.Location = New System.Drawing.Point(72, 86)
        Me.txtusuario.Name = "txtusuario"
        Me.txtusuario.Size = New System.Drawing.Size(274, 19)
        Me.txtusuario.TabIndex = 37
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label5.Location = New System.Drawing.Point(15, 86)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(54, 17)
        Me.Label5.TabIndex = 36
        Me.Label5.Text = "Usuario:"
        '
        'txtpuerto
        '
        Me.txtpuerto.BackColor = System.Drawing.Color.White
        Me.txtpuerto.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtpuerto.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtpuerto.Location = New System.Drawing.Point(72, 61)
        Me.txtpuerto.Name = "txtpuerto"
        Me.txtpuerto.Size = New System.Drawing.Size(274, 19)
        Me.txtpuerto.TabIndex = 35
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label4.Location = New System.Drawing.Point(19, 61)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(50, 17)
        Me.Label4.TabIndex = 34
        Me.Label4.Text = "Puerto:"
        '
        'txthost
        '
        Me.txthost.BackColor = System.Drawing.Color.White
        Me.txthost.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txthost.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txthost.Location = New System.Drawing.Point(72, 36)
        Me.txthost.Name = "txthost"
        Me.txthost.Size = New System.Drawing.Size(274, 19)
        Me.txthost.TabIndex = 33
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label3.Location = New System.Drawing.Point(32, 36)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 17)
        Me.Label3.TabIndex = 32
        Me.Label3.Text = "Host:"
        '
        'txtnombre
        '
        Me.txtnombre.BackColor = System.Drawing.Color.White
        Me.txtnombre.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtnombre.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtnombre.Location = New System.Drawing.Point(72, 11)
        Me.txtnombre.Name = "txtnombre"
        Me.txtnombre.Size = New System.Drawing.Size(274, 19)
        Me.txtnombre.TabIndex = 31
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label1.Location = New System.Drawing.Point(12, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 17)
        Me.Label1.TabIndex = 30
        Me.Label1.Text = "Nombre:"
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.Icon = CType(resources.GetObject("NotifyIcon1.Icon"), System.Drawing.Icon)
        Me.NotifyIcon1.Visible = True
        '
        'btntest
        '
        Me.btntest.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btntest.Image = Global.Sql_instaler.My.Resources.Resources.testconect
        Me.btntest.Location = New System.Drawing.Point(236, 154)
        Me.btntest.Name = "btntest"
        Me.btntest.Size = New System.Drawing.Size(33, 31)
        Me.btntest.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.btntest.TabIndex = 43
        Me.btntest.TabStop = False
        Me.ToolTip1.SetToolTip(Me.btntest, "Test de conexión")
        '
        'btncancelar
        '
        Me.btncancelar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btncancelar.Image = Global.Sql_instaler.My.Resources.Resources.cancelar
        Me.btncancelar.Location = New System.Drawing.Point(314, 153)
        Me.btncancelar.Name = "btncancelar"
        Me.btncancelar.Size = New System.Drawing.Size(33, 31)
        Me.btncancelar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.btncancelar.TabIndex = 42
        Me.btncancelar.TabStop = False
        Me.ToolTip1.SetToolTip(Me.btncancelar, "Cancelar")
        '
        'btnsave
        '
        Me.btnsave.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnsave.Enabled = False
        Me.btnsave.Image = Global.Sql_instaler.My.Resources.Resources.not_save
        Me.btnsave.Location = New System.Drawing.Point(275, 153)
        Me.btnsave.Name = "btnsave"
        Me.btnsave.Size = New System.Drawing.Size(33, 31)
        Me.btnsave.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.btnsave.TabIndex = 41
        Me.btnsave.TabStop = False
        Me.ToolTip1.SetToolTip(Me.btnsave, "Guardar")
        '
        'btnmini
        '
        Me.btnmini.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnmini.Image = Global.Sql_instaler.My.Resources.Resources.minimizar
        Me.btnmini.Location = New System.Drawing.Point(290, 9)
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
        Me.btnclose.Location = New System.Drawing.Point(329, 9)
        Me.btnclose.Name = "btnclose"
        Me.btnclose.Size = New System.Drawing.Size(33, 31)
        Me.btnclose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.btnclose.TabIndex = 5
        Me.btnclose.TabStop = False
        Me.ToolTip1.SetToolTip(Me.btnclose, "Cerrar")
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
        'Administrador_de_ambientes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.ClientSize = New System.Drawing.Size(366, 243)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.titlebar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Administrador_de_ambientes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Administrador_de_ambientes"
        Me.titlebar.ResumeLayout(False)
        Me.titlebar.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.btntest, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btncancelar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnsave, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnmini, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnclose, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Label2 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents titlebar As Panel
    Friend WithEvents btnmini As PictureBox
    Friend WithEvents btnclose As PictureBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Checkencrip As CheckBox
    Public WithEvents txtpassword As TextBox
    Friend WithEvents Label6 As Label
    Public WithEvents txtusuario As TextBox
    Friend WithEvents Label5 As Label
    Public WithEvents txtpuerto As TextBox
    Friend WithEvents Label4 As Label
    Public WithEvents txthost As TextBox
    Friend WithEvents Label3 As Label
    Public WithEvents txtnombre As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents btnsave As PictureBox
    Friend WithEvents btncancelar As PictureBox
    Friend WithEvents btntest As PictureBox
    Friend WithEvents NotifyIcon1 As NotifyIcon
    Friend WithEvents ToolTip1 As ToolTip
End Class
