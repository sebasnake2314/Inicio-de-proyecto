<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class pantalla_principal_sql
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(pantalla_principal_sql))
        Me.titlebar = New System.Windows.Forms.Panel()
        Me.btnmini = New System.Windows.Forms.PictureBox()
        Me.btnclose = New System.Windows.Forms.PictureBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnabrirdirectorio = New System.Windows.Forms.PictureBox()
        Me.btnselecdirectorio = New System.Windows.Forms.PictureBox()
        Me.btnbajar = New System.Windows.Forms.PictureBox()
        Me.btnsubir = New System.Windows.Forms.PictureBox()
        Me.btnselecionartodo = New System.Windows.Forms.PictureBox()
        Me.btneditar = New System.Windows.Forms.PictureBox()
        Me.btnabrirarchivo = New System.Windows.Forms.PictureBox()
        Me.btnactualizar = New System.Windows.Forms.PictureBox()
        Me.btnunificar = New System.Windows.Forms.PictureBox()
        Me.btnejecutarsql = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtdirectorio = New System.Windows.Forms.TextBox()
        Me.lbcantarch = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ArchivoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PreferenciasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SalirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.DataGridViewImageColumn1 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.btn_conex = New System.Windows.Forms.PictureBox()
        Me.tabladecontrol = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.lbconex = New System.Windows.Forms.Label()
        Me.grip_nombre_archi = New System.Windows.Forms.DataGridView()
        Me.nombre_archivo_sql = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.selecionar = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.ejecucion_sql = New System.Windows.Forms.DataGridViewImageColumn()
        Me.ejecucion_exitosa = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.cuadrodetexto = New System.Windows.Forms.RichTextBox()
        Me.lbamb = New System.Windows.Forms.Label()
        Me.Comboambientes = New System.Windows.Forms.ComboBox()
        Me.titlebar.SuspendLayout()
        CType(Me.btnmini, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnclose, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnabrirdirectorio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnselecdirectorio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnbajar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnsubir, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnselecionartodo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btneditar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnabrirarchivo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnactualizar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnunificar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnejecutarsql, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.btn_conex, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabladecontrol.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.grip_nombre_archi, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        Me.SuspendLayout()
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
        Me.titlebar.Size = New System.Drawing.Size(558, 47)
        Me.titlebar.TabIndex = 0
        '
        'btnmini
        '
        Me.btnmini.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnmini.Image = Global.Sql_instaler.My.Resources.Resources.minimizar
        Me.btnmini.Location = New System.Drawing.Point(483, 9)
        Me.btnmini.Name = "btnmini"
        Me.btnmini.Size = New System.Drawing.Size(33, 31)
        Me.btnmini.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.btnmini.TabIndex = 6
        Me.btnmini.TabStop = False
        Me.ToolTip.SetToolTip(Me.btnmini, "Minimizar")
        '
        'btnclose
        '
        Me.btnclose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnclose.Image = Global.Sql_instaler.My.Resources.Resources.close
        Me.btnclose.Location = New System.Drawing.Point(522, 9)
        Me.btnclose.Name = "btnclose"
        Me.btnclose.Size = New System.Drawing.Size(33, 31)
        Me.btnclose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.btnclose.TabIndex = 5
        Me.btnclose.TabStop = False
        Me.ToolTip.SetToolTip(Me.btnclose, "Cerrar")
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label2.Location = New System.Drawing.Point(41, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(90, 19)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Sql Instaler"
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
        'btnabrirdirectorio
        '
        Me.btnabrirdirectorio.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnabrirdirectorio.Image = Global.Sql_instaler.My.Resources.Resources.abrir_carpeta
        Me.btnabrirdirectorio.Location = New System.Drawing.Point(504, 118)
        Me.btnabrirdirectorio.Name = "btnabrirdirectorio"
        Me.btnabrirdirectorio.Size = New System.Drawing.Size(28, 27)
        Me.btnabrirdirectorio.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.btnabrirdirectorio.TabIndex = 21
        Me.btnabrirdirectorio.TabStop = False
        Me.ToolTip.SetToolTip(Me.btnabrirdirectorio, "Selecionar una carpeta")
        '
        'btnselecdirectorio
        '
        Me.btnselecdirectorio.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnselecdirectorio.Image = Global.Sql_instaler.My.Resources.Resources.select_folder
        Me.btnselecdirectorio.Location = New System.Drawing.Point(203, 87)
        Me.btnselecdirectorio.Name = "btnselecdirectorio"
        Me.btnselecdirectorio.Size = New System.Drawing.Size(28, 27)
        Me.btnselecdirectorio.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.btnselecdirectorio.TabIndex = 7
        Me.btnselecdirectorio.TabStop = False
        Me.ToolTip.SetToolTip(Me.btnselecdirectorio, "Selecionar una carpeta")
        '
        'btnbajar
        '
        Me.btnbajar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnbajar.Image = Global.Sql_instaler.My.Resources.Resources.bajar
        Me.btnbajar.Location = New System.Drawing.Point(492, 210)
        Me.btnbajar.Name = "btnbajar"
        Me.btnbajar.Size = New System.Drawing.Size(24, 22)
        Me.btnbajar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.btnbajar.TabIndex = 19
        Me.btnbajar.TabStop = False
        Me.ToolTip.SetToolTip(Me.btnbajar, "Bajar archivo")
        Me.btnbajar.Visible = False
        '
        'btnsubir
        '
        Me.btnsubir.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnsubir.Image = Global.Sql_instaler.My.Resources.Resources.subir
        Me.btnsubir.Location = New System.Drawing.Point(466, 210)
        Me.btnsubir.Name = "btnsubir"
        Me.btnsubir.Size = New System.Drawing.Size(24, 22)
        Me.btnsubir.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.btnsubir.TabIndex = 20
        Me.btnsubir.TabStop = False
        Me.ToolTip.SetToolTip(Me.btnsubir, "Subir Archivo")
        Me.btnsubir.Visible = False
        '
        'btnselecionartodo
        '
        Me.btnselecionartodo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnselecionartodo.Image = Global.Sql_instaler.My.Resources.Resources.select_all
        Me.btnselecionartodo.Location = New System.Drawing.Point(518, 210)
        Me.btnselecionartodo.Name = "btnselecionartodo"
        Me.btnselecionartodo.Size = New System.Drawing.Size(24, 22)
        Me.btnselecionartodo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.btnselecionartodo.TabIndex = 22
        Me.btnselecionartodo.TabStop = False
        Me.ToolTip.SetToolTip(Me.btnselecionartodo, "Seleccionar todo")
        Me.btnselecionartodo.Visible = False
        '
        'btneditar
        '
        Me.btneditar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btneditar.Image = Global.Sql_instaler.My.Resources.Resources.script_editar
        Me.btneditar.Location = New System.Drawing.Point(104, 210)
        Me.btneditar.Name = "btneditar"
        Me.btneditar.Size = New System.Drawing.Size(24, 22)
        Me.btneditar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.btneditar.TabIndex = 23
        Me.btneditar.TabStop = False
        Me.ToolTip.SetToolTip(Me.btneditar, "Editar nombre de archivo")
        Me.btneditar.Visible = False
        '
        'btnabrirarchivo
        '
        Me.btnabrirarchivo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnabrirarchivo.Image = Global.Sql_instaler.My.Resources.Resources.mirar_archivo
        Me.btnabrirarchivo.Location = New System.Drawing.Point(74, 210)
        Me.btnabrirarchivo.Name = "btnabrirarchivo"
        Me.btnabrirarchivo.Size = New System.Drawing.Size(24, 22)
        Me.btnabrirarchivo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.btnabrirarchivo.TabIndex = 24
        Me.btnabrirarchivo.TabStop = False
        Me.ToolTip.SetToolTip(Me.btnabrirarchivo, "Mirar achivo")
        Me.btnabrirarchivo.Visible = False
        '
        'btnactualizar
        '
        Me.btnactualizar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnactualizar.Image = Global.Sql_instaler.My.Resources.Resources.actualizar
        Me.btnactualizar.Location = New System.Drawing.Point(134, 210)
        Me.btnactualizar.Name = "btnactualizar"
        Me.btnactualizar.Size = New System.Drawing.Size(24, 22)
        Me.btnactualizar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.btnactualizar.TabIndex = 25
        Me.btnactualizar.TabStop = False
        Me.ToolTip.SetToolTip(Me.btnactualizar, "Actualizar")
        Me.btnactualizar.Visible = False
        '
        'btnunificar
        '
        Me.btnunificar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnunificar.Image = Global.Sql_instaler.My.Resources.Resources.unificar_scripts
        Me.btnunificar.Location = New System.Drawing.Point(17, 210)
        Me.btnunificar.Name = "btnunificar"
        Me.btnunificar.Size = New System.Drawing.Size(24, 22)
        Me.btnunificar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.btnunificar.TabIndex = 26
        Me.btnunificar.TabStop = False
        Me.ToolTip.SetToolTip(Me.btnunificar, "Unificar Script seleccionado/s")
        Me.btnunificar.Visible = False
        '
        'btnejecutarsql
        '
        Me.btnejecutarsql.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnejecutarsql.Image = Global.Sql_instaler.My.Resources.Resources.ejecutar_consulta
        Me.btnejecutarsql.Location = New System.Drawing.Point(45, 210)
        Me.btnejecutarsql.Name = "btnejecutarsql"
        Me.btnejecutarsql.Size = New System.Drawing.Size(24, 22)
        Me.btnejecutarsql.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.btnejecutarsql.TabIndex = 32
        Me.btnejecutarsql.TabStop = False
        Me.ToolTip.SetToolTip(Me.btnejecutarsql, "Mirar achivo")
        Me.btnejecutarsql.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label1.Location = New System.Drawing.Point(12, 91)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(193, 21)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Seleciona una carpeta:"
        '
        'txtdirectorio
        '
        Me.txtdirectorio.BackColor = System.Drawing.Color.White
        Me.txtdirectorio.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtdirectorio.Location = New System.Drawing.Point(12, 122)
        Me.txtdirectorio.Name = "txtdirectorio"
        Me.txtdirectorio.ReadOnly = True
        Me.txtdirectorio.Size = New System.Drawing.Size(486, 20)
        Me.txtdirectorio.TabIndex = 9
        '
        'lbcantarch
        '
        Me.lbcantarch.AutoSize = True
        Me.lbcantarch.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbcantarch.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lbcantarch.Location = New System.Drawing.Point(203, 145)
        Me.lbcantarch.Name = "lbcantarch"
        Me.lbcantarch.Size = New System.Drawing.Size(0, 16)
        Me.lbcantarch.TabIndex = 11
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label3.Location = New System.Drawing.Point(13, 145)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(193, 17)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Cant. archivos encontrados:"
        Me.Label3.Visible = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.MenuStrip1)
        Me.Panel1.Location = New System.Drawing.Point(0, 46)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(558, 23)
        Me.Panel1.TabIndex = 27
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ArchivoToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(558, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ArchivoToolStripMenuItem
        '
        Me.ArchivoToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PreferenciasToolStripMenuItem, Me.SalirToolStripMenuItem})
        Me.ArchivoToolStripMenuItem.Name = "ArchivoToolStripMenuItem"
        Me.ArchivoToolStripMenuItem.Size = New System.Drawing.Size(60, 20)
        Me.ArchivoToolStripMenuItem.Text = "Archivo"
        '
        'PreferenciasToolStripMenuItem
        '
        Me.PreferenciasToolStripMenuItem.Name = "PreferenciasToolStripMenuItem"
        Me.PreferenciasToolStripMenuItem.Size = New System.Drawing.Size(138, 22)
        Me.PreferenciasToolStripMenuItem.Text = "Preferencias"
        '
        'SalirToolStripMenuItem
        '
        Me.SalirToolStripMenuItem.Name = "SalirToolStripMenuItem"
        Me.SalirToolStripMenuItem.Size = New System.Drawing.Size(138, 22)
        Me.SalirToolStripMenuItem.Text = "Salir"
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.ContextMenuStrip = Me.ContextMenuStrip1
        Me.NotifyIcon1.Icon = CType(resources.GetObject("NotifyIcon1.Icon"), System.Drawing.Icon)
        Me.NotifyIcon1.Text = "Sql instaler"
        Me.NotifyIcon1.Visible = True
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(61, 4)
        '
        'DataGridViewImageColumn1
        '
        Me.DataGridViewImageColumn1.HeaderText = "Ejecución"
        Me.DataGridViewImageColumn1.Image = Global.Sql_instaler.My.Resources.Resources.exec_sql_pequeno
        Me.DataGridViewImageColumn1.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch
        Me.DataGridViewImageColumn1.Name = "DataGridViewImageColumn1"
        Me.DataGridViewImageColumn1.ReadOnly = True
        Me.DataGridViewImageColumn1.ToolTipText = "Click para ejecutar sql en ambiente"
        Me.DataGridViewImageColumn1.Width = 80
        '
        'btn_conex
        '
        Me.btn_conex.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_conex.Image = Global.Sql_instaler.My.Resources.Resources.disconnect
        Me.btn_conex.Location = New System.Drawing.Point(522, 454)
        Me.btn_conex.Name = "btn_conex"
        Me.btn_conex.Size = New System.Drawing.Size(24, 22)
        Me.btn_conex.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.btn_conex.TabIndex = 28
        Me.btn_conex.TabStop = False
        '
        'tabladecontrol
        '
        Me.tabladecontrol.Controls.Add(Me.TabPage1)
        Me.tabladecontrol.Controls.Add(Me.TabPage2)
        Me.tabladecontrol.Location = New System.Drawing.Point(16, 238)
        Me.tabladecontrol.Name = "tabladecontrol"
        Me.tabladecontrol.SelectedIndex = 0
        Me.tabladecontrol.Size = New System.Drawing.Size(530, 210)
        Me.tabladecontrol.TabIndex = 33
        Me.tabladecontrol.Visible = False
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.lbconex)
        Me.TabPage1.Controls.Add(Me.grip_nombre_archi)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(522, 184)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Lista de archivos"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'lbconex
        '
        Me.lbconex.AutoSize = True
        Me.lbconex.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbconex.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lbconex.Location = New System.Drawing.Point(286, 166)
        Me.lbconex.Name = "lbconex"
        Me.lbconex.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lbconex.Size = New System.Drawing.Size(0, 16)
        Me.lbconex.TabIndex = 31
        Me.lbconex.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'grip_nombre_archi
        '
        Me.grip_nombre_archi.AllowUserToAddRows = False
        Me.grip_nombre_archi.AllowUserToDeleteRows = False
        Me.grip_nombre_archi.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.grip_nombre_archi.BackgroundColor = System.Drawing.Color.White
        Me.grip_nombre_archi.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.grip_nombre_archi.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken
        Me.grip_nombre_archi.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.grip_nombre_archi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grip_nombre_archi.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.nombre_archivo_sql, Me.selecionar, Me.ejecucion_sql, Me.ejecucion_exitosa})
        Me.grip_nombre_archi.GridColor = System.Drawing.Color.FromArgb(CType(CType(4, Byte), Integer), CType(CType(15, Byte), Integer), CType(CType(21, Byte), Integer))
        Me.grip_nombre_archi.Location = New System.Drawing.Point(-3, -2)
        Me.grip_nombre_archi.Name = "grip_nombre_archi"
        Me.grip_nombre_archi.ReadOnly = True
        Me.grip_nombre_archi.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.grip_nombre_archi.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grip_nombre_archi.Size = New System.Drawing.Size(528, 186)
        Me.grip_nombre_archi.TabIndex = 30
        Me.grip_nombre_archi.Visible = False
        '
        'nombre_archivo_sql
        '
        Me.nombre_archivo_sql.HeaderText = "Nombre Archivo"
        Me.nombre_archivo_sql.Name = "nombre_archivo_sql"
        Me.nombre_archivo_sql.ReadOnly = True
        Me.nombre_archivo_sql.Width = 307
        '
        'selecionar
        '
        Me.selecionar.HeaderText = "Seleccionar"
        Me.selecionar.Name = "selecionar"
        Me.selecionar.ReadOnly = True
        Me.selecionar.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.selecionar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.selecionar.Width = 105
        '
        'ejecucion_sql
        '
        Me.ejecucion_sql.HeaderText = "Ejecución"
        Me.ejecucion_sql.Image = Global.Sql_instaler.My.Resources.Resources.exec_sql_pequeno
        Me.ejecucion_sql.Name = "ejecucion_sql"
        Me.ejecucion_sql.ReadOnly = True
        Me.ejecucion_sql.ToolTipText = "Click para ejecutar sql en ambiente"
        Me.ejecucion_sql.Width = 80
        '
        'ejecucion_exitosa
        '
        Me.ejecucion_exitosa.HeaderText = "eject"
        Me.ejecucion_exitosa.Name = "ejecucion_exitosa"
        Me.ejecucion_exitosa.ReadOnly = True
        Me.ejecucion_exitosa.Visible = False
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.cuadrodetexto)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(522, 184)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Vista Previa"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'cuadrodetexto
        '
        Me.cuadrodetexto.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cuadrodetexto.Location = New System.Drawing.Point(-3, 0)
        Me.cuadrodetexto.Name = "cuadrodetexto"
        Me.cuadrodetexto.ReadOnly = True
        Me.cuadrodetexto.Size = New System.Drawing.Size(525, 184)
        Me.cuadrodetexto.TabIndex = 0
        Me.cuadrodetexto.Text = ""
        '
        'lbamb
        '
        Me.lbamb.AutoSize = True
        Me.lbamb.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbamb.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lbamb.Location = New System.Drawing.Point(17, 189)
        Me.lbamb.Name = "lbamb"
        Me.lbamb.Size = New System.Drawing.Size(177, 17)
        Me.lbamb.TabIndex = 30
        Me.lbamb.Text = "Ambiente para ejecución:"
        Me.lbamb.Visible = False
        '
        'Comboambientes
        '
        Me.Comboambientes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Comboambientes.FormattingEnabled = True
        Me.Comboambientes.Location = New System.Drawing.Point(195, 187)
        Me.Comboambientes.Name = "Comboambientes"
        Me.Comboambientes.Size = New System.Drawing.Size(198, 21)
        Me.Comboambientes.TabIndex = 31
        Me.Comboambientes.Visible = False
        '
        'pantalla_principal_sql
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ClientSize = New System.Drawing.Size(558, 482)
        Me.Controls.Add(Me.tabladecontrol)
        Me.Controls.Add(Me.btnejecutarsql)
        Me.Controls.Add(Me.Comboambientes)
        Me.Controls.Add(Me.lbamb)
        Me.Controls.Add(Me.btn_conex)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnunificar)
        Me.Controls.Add(Me.btnactualizar)
        Me.Controls.Add(Me.btnabrirarchivo)
        Me.Controls.Add(Me.btneditar)
        Me.Controls.Add(Me.btnselecionartodo)
        Me.Controls.Add(Me.btnabrirdirectorio)
        Me.Controls.Add(Me.btnsubir)
        Me.Controls.Add(Me.btnbajar)
        Me.Controls.Add(Me.lbcantarch)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtdirectorio)
        Me.Controls.Add(Me.btnselecdirectorio)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.titlebar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "pantalla_principal_sql"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pantalla Principal Sql Instaler"
        Me.ToolTip.SetToolTip(Me, "Abrir directorio")
        Me.titlebar.ResumeLayout(False)
        Me.titlebar.PerformLayout()
        CType(Me.btnmini, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnclose, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnabrirdirectorio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnselecdirectorio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnbajar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnsubir, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnselecionartodo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btneditar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnabrirarchivo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnactualizar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnunificar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnejecutarsql, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.btn_conex, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabladecontrol.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        CType(Me.grip_nombre_archi, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents titlebar As Panel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents btnmini As PictureBox
    Friend WithEvents btnclose As PictureBox
    Friend WithEvents Label2 As Label
    Friend WithEvents ToolTip As ToolTip
    Friend WithEvents Label1 As Label
    Friend WithEvents btnselecdirectorio As PictureBox
    Public WithEvents txtdirectorio As TextBox
    Friend WithEvents lbcantarch As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents btnabrirdirectorio As PictureBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents ArchivoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SalirToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents btn_conex As PictureBox
    Friend WithEvents NotifyIcon1 As NotifyIcon
    Friend WithEvents PreferenciasToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DataGridViewImageColumn1 As DataGridViewImageColumn
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents tabladecontrol As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents lbconex As Label
    Friend WithEvents grip_nombre_archi As DataGridView
    Friend WithEvents nombre_archivo_sql As DataGridViewTextBoxColumn
    Friend WithEvents selecionar As DataGridViewCheckBoxColumn
    Friend WithEvents ejecucion_sql As DataGridViewImageColumn
    Friend WithEvents ejecucion_exitosa As DataGridViewTextBoxColumn
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents btnbajar As PictureBox
    Friend WithEvents btnsubir As PictureBox
    Friend WithEvents btnselecionartodo As PictureBox
    Friend WithEvents btneditar As PictureBox
    Friend WithEvents btnabrirarchivo As PictureBox
    Friend WithEvents btnactualizar As PictureBox
    Friend WithEvents btnunificar As PictureBox
    Friend WithEvents lbamb As Label
    Friend WithEvents Comboambientes As ComboBox
    Friend WithEvents btnejecutarsql As PictureBox
    Friend WithEvents cuadrodetexto As RichTextBox
End Class
