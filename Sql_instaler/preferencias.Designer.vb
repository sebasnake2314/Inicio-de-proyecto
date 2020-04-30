<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class preferencias
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(preferencias))
        Me.Label2 = New System.Windows.Forms.Label()
        Me.titlebar = New System.Windows.Forms.Panel()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.Comboambientes = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtubibd = New System.Windows.Forms.TextBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.btncancelar = New System.Windows.Forms.PictureBox()
        Me.btnsave = New System.Windows.Forms.PictureBox()
        Me.btneditaramb = New System.Windows.Forms.PictureBox()
        Me.btndropamb = New System.Windows.Forms.PictureBox()
        Me.btnagregaramb = New System.Windows.Forms.PictureBox()
        Me.btnmini = New System.Windows.Forms.PictureBox()
        Me.btnclose = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.titlebar.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btncancelar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnsave, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btneditaramb, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btndropamb, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnagregaramb, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.Label2.Size = New System.Drawing.Size(103, 19)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Preferencias"
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
        Me.titlebar.Size = New System.Drawing.Size(589, 47)
        Me.titlebar.TabIndex = 1
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Panel1.Controls.Add(Me.PictureBox2)
        Me.Panel1.Controls.Add(Me.txtubibd)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.CheckBox1)
        Me.Panel1.Controls.Add(Me.btncancelar)
        Me.Panel1.Controls.Add(Me.btnsave)
        Me.Panel1.Controls.Add(Me.btneditaramb)
        Me.Panel1.Controls.Add(Me.btndropamb)
        Me.Panel1.Controls.Add(Me.btnagregaramb)
        Me.Panel1.Controls.Add(Me.Comboambientes)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Location = New System.Drawing.Point(8, 53)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(574, 174)
        Me.Panel1.TabIndex = 2
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox1.Location = New System.Drawing.Point(33, 42)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.CheckBox1.Size = New System.Drawing.Size(161, 21)
        Me.CheckBox1.TabIndex = 32
        Me.CheckBox1.Text = ":Iniciar con Windows"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'Comboambientes
        '
        Me.Comboambientes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Comboambientes.FormattingEnabled = True
        Me.Comboambientes.Location = New System.Drawing.Point(176, 15)
        Me.Comboambientes.Name = "Comboambientes"
        Me.Comboambientes.Size = New System.Drawing.Size(298, 21)
        Me.Comboambientes.TabIndex = 12
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label3.Location = New System.Drawing.Point(5, 17)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(170, 17)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Ambiente de instalación:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label1.Location = New System.Drawing.Point(19, 72)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(156, 17)
        Me.Label1.TabIndex = 33
        Me.Label1.Text = "Base de configuración:"
        '
        'txtubibd
        '
        Me.txtubibd.BackColor = System.Drawing.Color.White
        Me.txtubibd.Enabled = False
        Me.txtubibd.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtubibd.Location = New System.Drawing.Point(176, 71)
        Me.txtubibd.Name = "txtubibd"
        Me.txtubibd.ReadOnly = True
        Me.txtubibd.Size = New System.Drawing.Size(298, 20)
        Me.txtubibd.TabIndex = 34
        '
        'PictureBox2
        '
        Me.PictureBox2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox2.Image = Global.Sql_instaler.My.Resources.Resources.editar
        Me.PictureBox2.Location = New System.Drawing.Point(479, 69)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(24, 22)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 35
        Me.PictureBox2.TabStop = False
        Me.ToolTip1.SetToolTip(Me.PictureBox2, "Cambiar ubicación")
        '
        'btncancelar
        '
        Me.btncancelar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btncancelar.Image = Global.Sql_instaler.My.Resources.Resources.cancelar
        Me.btncancelar.Location = New System.Drawing.Point(531, 137)
        Me.btncancelar.Name = "btncancelar"
        Me.btncancelar.Size = New System.Drawing.Size(33, 31)
        Me.btncancelar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.btncancelar.TabIndex = 30
        Me.btncancelar.TabStop = False
        Me.ToolTip1.SetToolTip(Me.btncancelar, "Cancelar")
        '
        'btnsave
        '
        Me.btnsave.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnsave.Image = Global.Sql_instaler.My.Resources.Resources.guardar
        Me.btnsave.Location = New System.Drawing.Point(492, 137)
        Me.btnsave.Name = "btnsave"
        Me.btnsave.Size = New System.Drawing.Size(33, 31)
        Me.btnsave.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.btnsave.TabIndex = 29
        Me.btnsave.TabStop = False
        Me.ToolTip1.SetToolTip(Me.btnsave, "Guardar cambios")
        '
        'btneditaramb
        '
        Me.btneditaramb.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btneditaramb.Image = Global.Sql_instaler.My.Resources.Resources.database
        Me.btneditaramb.Location = New System.Drawing.Point(540, 15)
        Me.btneditaramb.Name = "btneditaramb"
        Me.btneditaramb.Size = New System.Drawing.Size(24, 22)
        Me.btneditaramb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.btneditaramb.TabIndex = 28
        Me.btneditaramb.TabStop = False
        Me.ToolTip1.SetToolTip(Me.btneditaramb, "Modificar ambiente")
        Me.btneditaramb.Visible = False
        '
        'btndropamb
        '
        Me.btndropamb.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btndropamb.Image = Global.Sql_instaler.My.Resources.Resources.databasedrop
        Me.btndropamb.Location = New System.Drawing.Point(510, 15)
        Me.btndropamb.Name = "btndropamb"
        Me.btndropamb.Size = New System.Drawing.Size(24, 22)
        Me.btndropamb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.btndropamb.TabIndex = 27
        Me.btndropamb.TabStop = False
        Me.ToolTip1.SetToolTip(Me.btndropamb, "Eliminar ambiente")
        Me.btndropamb.Visible = False
        '
        'btnagregaramb
        '
        Me.btnagregaramb.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnagregaramb.Image = Global.Sql_instaler.My.Resources.Resources.databaseadd
        Me.btnagregaramb.Location = New System.Drawing.Point(480, 15)
        Me.btnagregaramb.Name = "btnagregaramb"
        Me.btnagregaramb.Size = New System.Drawing.Size(24, 22)
        Me.btnagregaramb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.btnagregaramb.TabIndex = 26
        Me.btnagregaramb.TabStop = False
        Me.ToolTip1.SetToolTip(Me.btnagregaramb, "Agregar nuevo ambiente")
        '
        'btnmini
        '
        Me.btnmini.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnmini.Image = Global.Sql_instaler.My.Resources.Resources.minimizar
        Me.btnmini.Location = New System.Drawing.Point(514, 9)
        Me.btnmini.Name = "btnmini"
        Me.btnmini.Size = New System.Drawing.Size(33, 31)
        Me.btnmini.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.btnmini.TabIndex = 6
        Me.btnmini.TabStop = False
        '
        'btnclose
        '
        Me.btnclose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnclose.Image = Global.Sql_instaler.My.Resources.Resources.close
        Me.btnclose.Location = New System.Drawing.Point(553, 9)
        Me.btnclose.Name = "btnclose"
        Me.btnclose.Size = New System.Drawing.Size(33, 31)
        Me.btnclose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.btnclose.TabIndex = 5
        Me.btnclose.TabStop = False
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
        'preferencias
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.ClientSize = New System.Drawing.Size(589, 233)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.titlebar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "preferencias"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Preferencias"
        Me.titlebar.ResumeLayout(False)
        Me.titlebar.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btncancelar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnsave, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btneditaramb, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btndropamb, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnagregaramb, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents Comboambientes As ComboBox
    Friend WithEvents btnagregaramb As PictureBox
    Friend WithEvents btneditaramb As PictureBox
    Friend WithEvents btndropamb As PictureBox
    Friend WithEvents btncancelar As PictureBox
    Friend WithEvents btnsave As PictureBox
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents Label1 As Label
    Public WithEvents txtubibd As TextBox
    Friend WithEvents PictureBox2 As PictureBox
End Class
