<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Busquedaexamen
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Busquedaexamen))
        Me.botoneliminarexamen = New System.Windows.Forms.Button()
        Me.botonseleccionarexamen = New System.Windows.Forms.Button()
        Me.DGVexamen = New System.Windows.Forms.DataGridView()
        Me.botonbuscarexamen = New System.Windows.Forms.Button()
        Me.txtbuscarexamen = New System.Windows.Forms.TextBox()
        Me.DGVpacientesnovisible = New System.Windows.Forms.DataGridView()
        Me.LabelTituloBuscarExamen = New System.Windows.Forms.Label()
        CType(Me.DGVexamen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGVpacientesnovisible, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'botoneliminarexamen
        '
        Me.botoneliminarexamen.Enabled = False
        Me.botoneliminarexamen.Location = New System.Drawing.Point(766, 3)
        Me.botoneliminarexamen.Margin = New System.Windows.Forms.Padding(8, 6, 8, 6)
        Me.botoneliminarexamen.Name = "botoneliminarexamen"
        Me.botoneliminarexamen.Size = New System.Drawing.Size(220, 40)
        Me.botoneliminarexamen.TabIndex = 9
        Me.botoneliminarexamen.Text = "Eliminar"
        Me.botoneliminarexamen.UseVisualStyleBackColor = True
        '
        'botonseleccionarexamen
        '
        Me.botonseleccionarexamen.Location = New System.Drawing.Point(536, 3)
        Me.botonseleccionarexamen.Margin = New System.Windows.Forms.Padding(8, 6, 8, 6)
        Me.botonseleccionarexamen.Name = "botonseleccionarexamen"
        Me.botonseleccionarexamen.Size = New System.Drawing.Size(220, 40)
        Me.botonseleccionarexamen.TabIndex = 8
        Me.botonseleccionarexamen.Text = "Seleccionar"
        Me.botonseleccionarexamen.UseVisualStyleBackColor = True
        '
        'DGVexamen
        '
        Me.DGVexamen.AllowUserToAddRows = False
        Me.DGVexamen.AllowUserToDeleteRows = False
        Me.DGVexamen.AllowUserToResizeColumns = False
        Me.DGVexamen.AllowUserToResizeRows = False
        Me.DGVexamen.BackgroundColor = System.Drawing.SystemColors.ControlLight
        Me.DGVexamen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGVexamen.DefaultCellStyle = DataGridViewCellStyle1
        Me.DGVexamen.Location = New System.Drawing.Point(20, 80)
        Me.DGVexamen.Margin = New System.Windows.Forms.Padding(8, 6, 8, 6)
        Me.DGVexamen.MultiSelect = False
        Me.DGVexamen.Name = "DGVexamen"
        Me.DGVexamen.ReadOnly = True
        Me.DGVexamen.RowHeadersVisible = False
        Me.DGVexamen.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.DGVexamen.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGVexamen.Size = New System.Drawing.Size(966, 312)
        Me.DGVexamen.TabIndex = 7
        '
        'botonbuscarexamen
        '
        Me.botonbuscarexamen.Location = New System.Drawing.Point(296, 3)
        Me.botonbuscarexamen.Margin = New System.Windows.Forms.Padding(8, 6, 8, 6)
        Me.botonbuscarexamen.Name = "botonbuscarexamen"
        Me.botonbuscarexamen.Size = New System.Drawing.Size(220, 40)
        Me.botonbuscarexamen.TabIndex = 6
        Me.botonbuscarexamen.Text = "Buscar"
        Me.botonbuscarexamen.UseVisualStyleBackColor = True
        '
        'txtbuscarexamen
        '
        Me.txtbuscarexamen.Location = New System.Drawing.Point(20, 17)
        Me.txtbuscarexamen.Margin = New System.Windows.Forms.Padding(8, 6, 8, 6)
        Me.txtbuscarexamen.Name = "txtbuscarexamen"
        Me.txtbuscarexamen.Size = New System.Drawing.Size(266, 26)
        Me.txtbuscarexamen.TabIndex = 5
        '
        'DGVpacientesnovisible
        '
        Me.DGVpacientesnovisible.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVpacientesnovisible.Enabled = False
        Me.DGVpacientesnovisible.Location = New System.Drawing.Point(80, 401)
        Me.DGVpacientesnovisible.Name = "DGVpacientesnovisible"
        Me.DGVpacientesnovisible.Size = New System.Drawing.Size(686, 150)
        Me.DGVpacientesnovisible.TabIndex = 10
        Me.DGVpacientesnovisible.Visible = False
        '
        'LabelTituloBuscarExamen
        '
        Me.LabelTituloBuscarExamen.AutoSize = True
        Me.LabelTituloBuscarExamen.Font = New System.Drawing.Font("Arial Rounded MT Bold", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelTituloBuscarExamen.Location = New System.Drawing.Point(791, 439)
        Me.LabelTituloBuscarExamen.Name = "LabelTituloBuscarExamen"
        Me.LabelTituloBuscarExamen.Size = New System.Drawing.Size(252, 32)
        Me.LabelTituloBuscarExamen.TabIndex = 116
        Me.LabelTituloBuscarExamen.Text = "BUSCAR EXAMEN"
        '
        'Busquedaexamen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.ClientSize = New System.Drawing.Size(1105, 558)
        Me.Controls.Add(Me.LabelTituloBuscarExamen)
        Me.Controls.Add(Me.DGVpacientesnovisible)
        Me.Controls.Add(Me.botoneliminarexamen)
        Me.Controls.Add(Me.botonseleccionarexamen)
        Me.Controls.Add(Me.DGVexamen)
        Me.Controls.Add(Me.botonbuscarexamen)
        Me.Controls.Add(Me.txtbuscarexamen)
        Me.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Busquedaexamen"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Buscar Examen"
        CType(Me.DGVexamen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGVpacientesnovisible, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents botoneliminarexamen As System.Windows.Forms.Button
    Friend WithEvents botonseleccionarexamen As System.Windows.Forms.Button
    Friend WithEvents DGVexamen As System.Windows.Forms.DataGridView
    Friend WithEvents botonbuscarexamen As System.Windows.Forms.Button
    Friend WithEvents txtbuscarexamen As System.Windows.Forms.TextBox
    Friend WithEvents DGVpacientesnovisible As System.Windows.Forms.DataGridView
    Friend WithEvents LabelTituloBuscarExamen As System.Windows.Forms.Label
End Class
