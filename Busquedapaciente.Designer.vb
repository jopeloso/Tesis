<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Busquedapaciente
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Busquedapaciente))
        Me.txtbuscarpaciente = New System.Windows.Forms.TextBox()
        Me.botonbuscarpaciente = New System.Windows.Forms.Button()
        Me.DGVpacientes = New System.Windows.Forms.DataGridView()
        Me.botonseleccionarpaciente = New System.Windows.Forms.Button()
        Me.botoneliminarpaciente = New System.Windows.Forms.Button()
        Me.LabelTituloBuscarPaciente = New System.Windows.Forms.Label()
        CType(Me.DGVpacientes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtbuscarpaciente
        '
        Me.txtbuscarpaciente.Location = New System.Drawing.Point(20, 17)
        Me.txtbuscarpaciente.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.txtbuscarpaciente.Name = "txtbuscarpaciente"
        Me.txtbuscarpaciente.Size = New System.Drawing.Size(266, 26)
        Me.txtbuscarpaciente.TabIndex = 0
        '
        'botonbuscarpaciente
        '
        Me.botonbuscarpaciente.Location = New System.Drawing.Point(296, 3)
        Me.botonbuscarpaciente.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.botonbuscarpaciente.Name = "botonbuscarpaciente"
        Me.botonbuscarpaciente.Size = New System.Drawing.Size(220, 40)
        Me.botonbuscarpaciente.TabIndex = 1
        Me.botonbuscarpaciente.Text = "Buscar"
        Me.botonbuscarpaciente.UseVisualStyleBackColor = True
        '
        'DGVpacientes
        '
        Me.DGVpacientes.AllowUserToAddRows = False
        Me.DGVpacientes.AllowUserToDeleteRows = False
        Me.DGVpacientes.AllowUserToResizeColumns = False
        Me.DGVpacientes.AllowUserToResizeRows = False
        Me.DGVpacientes.BackgroundColor = System.Drawing.SystemColors.ControlLight
        Me.DGVpacientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGVpacientes.DefaultCellStyle = DataGridViewCellStyle1
        Me.DGVpacientes.Location = New System.Drawing.Point(20, 80)
        Me.DGVpacientes.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.DGVpacientes.MultiSelect = False
        Me.DGVpacientes.Name = "DGVpacientes"
        Me.DGVpacientes.ReadOnly = True
        Me.DGVpacientes.RowHeadersVisible = False
        Me.DGVpacientes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.DGVpacientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGVpacientes.Size = New System.Drawing.Size(966, 312)
        Me.DGVpacientes.TabIndex = 2
        '
        'botonseleccionarpaciente
        '
        Me.botonseleccionarpaciente.Location = New System.Drawing.Point(536, 3)
        Me.botonseleccionarpaciente.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.botonseleccionarpaciente.Name = "botonseleccionarpaciente"
        Me.botonseleccionarpaciente.Size = New System.Drawing.Size(220, 40)
        Me.botonseleccionarpaciente.TabIndex = 3
        Me.botonseleccionarpaciente.Text = "Seleccionar"
        Me.botonseleccionarpaciente.UseVisualStyleBackColor = True
        '
        'botoneliminarpaciente
        '
        Me.botoneliminarpaciente.Enabled = False
        Me.botoneliminarpaciente.Location = New System.Drawing.Point(766, 3)
        Me.botoneliminarpaciente.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.botoneliminarpaciente.Name = "botoneliminarpaciente"
        Me.botoneliminarpaciente.Size = New System.Drawing.Size(220, 40)
        Me.botoneliminarpaciente.TabIndex = 4
        Me.botoneliminarpaciente.Text = "Eliminar"
        Me.botoneliminarpaciente.UseVisualStyleBackColor = True
        '
        'LabelTituloBuscarPaciente
        '
        Me.LabelTituloBuscarPaciente.AutoSize = True
        Me.LabelTituloBuscarPaciente.Font = New System.Drawing.Font("Arial Rounded MT Bold", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelTituloBuscarPaciente.Location = New System.Drawing.Point(776, 455)
        Me.LabelTituloBuscarPaciente.Name = "LabelTituloBuscarPaciente"
        Me.LabelTituloBuscarPaciente.Size = New System.Drawing.Size(277, 32)
        Me.LabelTituloBuscarPaciente.TabIndex = 117
        Me.LabelTituloBuscarPaciente.Text = "BUSCAR PACIENTE"
        '
        'Busquedapaciente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.ClientSize = New System.Drawing.Size(1111, 558)
        Me.Controls.Add(Me.LabelTituloBuscarPaciente)
        Me.Controls.Add(Me.botoneliminarpaciente)
        Me.Controls.Add(Me.botonseleccionarpaciente)
        Me.Controls.Add(Me.DGVpacientes)
        Me.Controls.Add(Me.botonbuscarpaciente)
        Me.Controls.Add(Me.txtbuscarpaciente)
        Me.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Busquedapaciente"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Buscar Paciente"
        CType(Me.DGVpacientes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtbuscarpaciente As System.Windows.Forms.TextBox
    Friend WithEvents botonbuscarpaciente As System.Windows.Forms.Button
    Friend WithEvents DGVpacientes As System.Windows.Forms.DataGridView
    Friend WithEvents botonseleccionarpaciente As System.Windows.Forms.Button
    Friend WithEvents botoneliminarpaciente As System.Windows.Forms.Button
    Friend WithEvents LabelTituloBuscarPaciente As System.Windows.Forms.Label
End Class
