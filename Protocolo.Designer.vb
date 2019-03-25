<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Protocolo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Protocolo))
        Me.EditarProtocolo = New System.Windows.Forms.Button()
        Me.EliminarProtocolo = New System.Windows.Forms.Button()
        Me.NuevoProtocolo = New System.Windows.Forms.Button()
        Me.cbxProto = New System.Windows.Forms.ComboBox()
        Me.LabelDur = New System.Windows.Forms.Label()
        Me.LabelInc = New System.Windows.Forms.Label()
        Me.LabelBasal = New System.Windows.Forms.Label()
        Me.LabelE1 = New System.Windows.Forms.Label()
        Me.txtDuracionBasal = New System.Windows.Forms.TextBox()
        Me.txtInclinacionBasal = New System.Windows.Forms.TextBox()
        Me.txtDuracionE1 = New System.Windows.Forms.TextBox()
        Me.txtDuracionE2 = New System.Windows.Forms.TextBox()
        Me.txtDuracionE3 = New System.Windows.Forms.TextBox()
        Me.txtInclinacionE1 = New System.Windows.Forms.TextBox()
        Me.txtInclinacionE2 = New System.Windows.Forms.TextBox()
        Me.txtInclinacionE3 = New System.Windows.Forms.TextBox()
        Me.txtDescripcion = New System.Windows.Forms.TextBox()
        Me.LabelE2 = New System.Windows.Forms.Label()
        Me.LabelE3 = New System.Windows.Forms.Label()
        Me.DGVprotocolos = New System.Windows.Forms.DataGridView()
        CType(Me.DGVprotocolos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'EditarProtocolo
        '
        Me.EditarProtocolo.Enabled = False
        Me.EditarProtocolo.Location = New System.Drawing.Point(13, 151)
        Me.EditarProtocolo.Margin = New System.Windows.Forms.Padding(4)
        Me.EditarProtocolo.Name = "EditarProtocolo"
        Me.EditarProtocolo.Size = New System.Drawing.Size(194, 45)
        Me.EditarProtocolo.TabIndex = 80
        Me.EditarProtocolo.Text = "Editar "
        Me.EditarProtocolo.UseVisualStyleBackColor = True
        '
        'EliminarProtocolo
        '
        Me.EliminarProtocolo.Enabled = False
        Me.EliminarProtocolo.Location = New System.Drawing.Point(13, 94)
        Me.EliminarProtocolo.Margin = New System.Windows.Forms.Padding(4)
        Me.EliminarProtocolo.Name = "EliminarProtocolo"
        Me.EliminarProtocolo.Size = New System.Drawing.Size(194, 45)
        Me.EliminarProtocolo.TabIndex = 79
        Me.EliminarProtocolo.Text = "Eliminar"
        Me.EliminarProtocolo.UseVisualStyleBackColor = True
        '
        'NuevoProtocolo
        '
        Me.NuevoProtocolo.Location = New System.Drawing.Point(13, 45)
        Me.NuevoProtocolo.Margin = New System.Windows.Forms.Padding(4)
        Me.NuevoProtocolo.Name = "NuevoProtocolo"
        Me.NuevoProtocolo.Size = New System.Drawing.Size(194, 45)
        Me.NuevoProtocolo.TabIndex = 78
        Me.NuevoProtocolo.Text = "Nuevo"
        Me.NuevoProtocolo.UseVisualStyleBackColor = True
        '
        'cbxProto
        '
        Me.cbxProto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxProto.FormattingEnabled = True
        Me.cbxProto.Location = New System.Drawing.Point(12, 17)
        Me.cbxProto.Name = "cbxProto"
        Me.cbxProto.Size = New System.Drawing.Size(194, 26)
        Me.cbxProto.TabIndex = 81
        '
        'LabelDur
        '
        Me.LabelDur.AutoSize = True
        Me.LabelDur.Location = New System.Drawing.Point(458, 29)
        Me.LabelDur.Name = "LabelDur"
        Me.LabelDur.Size = New System.Drawing.Size(81, 18)
        Me.LabelDur.TabIndex = 82
        Me.LabelDur.Text = "Duración"
        '
        'LabelInc
        '
        Me.LabelInc.AutoSize = True
        Me.LabelInc.Location = New System.Drawing.Point(647, 29)
        Me.LabelInc.Name = "LabelInc"
        Me.LabelInc.Size = New System.Drawing.Size(95, 18)
        Me.LabelInc.TabIndex = 83
        Me.LabelInc.Text = "Inclinación"
        '
        'LabelBasal
        '
        Me.LabelBasal.AutoSize = True
        Me.LabelBasal.Location = New System.Drawing.Point(351, 56)
        Me.LabelBasal.Name = "LabelBasal"
        Me.LabelBasal.Size = New System.Drawing.Size(53, 18)
        Me.LabelBasal.TabIndex = 84
        Me.LabelBasal.Text = "Basal"
        '
        'LabelE1
        '
        Me.LabelE1.AutoSize = True
        Me.LabelE1.Location = New System.Drawing.Point(351, 102)
        Me.LabelE1.Name = "LabelE1"
        Me.LabelE1.Size = New System.Drawing.Size(69, 18)
        Me.LabelE1.TabIndex = 85
        Me.LabelE1.Text = "Etapa 1"
        '
        'txtDuracionBasal
        '
        Me.txtDuracionBasal.Enabled = False
        Me.txtDuracionBasal.Location = New System.Drawing.Point(461, 56)
        Me.txtDuracionBasal.Name = "txtDuracionBasal"
        Me.txtDuracionBasal.Size = New System.Drawing.Size(100, 26)
        Me.txtDuracionBasal.TabIndex = 88
        '
        'txtInclinacionBasal
        '
        Me.txtInclinacionBasal.Enabled = False
        Me.txtInclinacionBasal.Location = New System.Drawing.Point(650, 56)
        Me.txtInclinacionBasal.Name = "txtInclinacionBasal"
        Me.txtInclinacionBasal.Size = New System.Drawing.Size(100, 26)
        Me.txtInclinacionBasal.TabIndex = 89
        '
        'txtDuracionE1
        '
        Me.txtDuracionE1.Enabled = False
        Me.txtDuracionE1.Location = New System.Drawing.Point(461, 94)
        Me.txtDuracionE1.Name = "txtDuracionE1"
        Me.txtDuracionE1.Size = New System.Drawing.Size(100, 26)
        Me.txtDuracionE1.TabIndex = 90
        '
        'txtDuracionE2
        '
        Me.txtDuracionE2.Enabled = False
        Me.txtDuracionE2.Location = New System.Drawing.Point(461, 132)
        Me.txtDuracionE2.Name = "txtDuracionE2"
        Me.txtDuracionE2.Size = New System.Drawing.Size(100, 26)
        Me.txtDuracionE2.TabIndex = 91
        '
        'txtDuracionE3
        '
        Me.txtDuracionE3.Enabled = False
        Me.txtDuracionE3.Location = New System.Drawing.Point(461, 170)
        Me.txtDuracionE3.Name = "txtDuracionE3"
        Me.txtDuracionE3.Size = New System.Drawing.Size(100, 26)
        Me.txtDuracionE3.TabIndex = 92
        '
        'txtInclinacionE1
        '
        Me.txtInclinacionE1.Enabled = False
        Me.txtInclinacionE1.Location = New System.Drawing.Point(650, 94)
        Me.txtInclinacionE1.Name = "txtInclinacionE1"
        Me.txtInclinacionE1.Size = New System.Drawing.Size(100, 26)
        Me.txtInclinacionE1.TabIndex = 93
        '
        'txtInclinacionE2
        '
        Me.txtInclinacionE2.Enabled = False
        Me.txtInclinacionE2.Location = New System.Drawing.Point(650, 132)
        Me.txtInclinacionE2.Name = "txtInclinacionE2"
        Me.txtInclinacionE2.Size = New System.Drawing.Size(100, 26)
        Me.txtInclinacionE2.TabIndex = 94
        '
        'txtInclinacionE3
        '
        Me.txtInclinacionE3.Enabled = False
        Me.txtInclinacionE3.Location = New System.Drawing.Point(650, 170)
        Me.txtInclinacionE3.Name = "txtInclinacionE3"
        Me.txtInclinacionE3.Size = New System.Drawing.Size(100, 26)
        Me.txtInclinacionE3.TabIndex = 95
        '
        'txtDescripcion
        '
        Me.txtDescripcion.Location = New System.Drawing.Point(13, 255)
        Me.txtDescripcion.MaxLength = 349
        Me.txtDescripcion.Multiline = True
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(791, 196)
        Me.txtDescripcion.TabIndex = 98
        '
        'LabelE2
        '
        Me.LabelE2.AutoSize = True
        Me.LabelE2.Location = New System.Drawing.Point(351, 140)
        Me.LabelE2.Name = "LabelE2"
        Me.LabelE2.Size = New System.Drawing.Size(69, 18)
        Me.LabelE2.TabIndex = 99
        Me.LabelE2.Text = "Etapa 2"
        '
        'LabelE3
        '
        Me.LabelE3.AutoSize = True
        Me.LabelE3.Location = New System.Drawing.Point(351, 178)
        Me.LabelE3.Name = "LabelE3"
        Me.LabelE3.Size = New System.Drawing.Size(69, 18)
        Me.LabelE3.TabIndex = 100
        Me.LabelE3.Text = "Etapa 3"
        '
        'DGVprotocolos
        '
        Me.DGVprotocolos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVprotocolos.Enabled = False
        Me.DGVprotocolos.Location = New System.Drawing.Point(264, 206)
        Me.DGVprotocolos.Name = "DGVprotocolos"
        Me.DGVprotocolos.Size = New System.Drawing.Size(84, 30)
        Me.DGVprotocolos.TabIndex = 101
        Me.DGVprotocolos.Visible = False
        '
        'Protocolo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.ClientSize = New System.Drawing.Size(816, 463)
        Me.Controls.Add(Me.DGVprotocolos)
        Me.Controls.Add(Me.LabelE3)
        Me.Controls.Add(Me.LabelE2)
        Me.Controls.Add(Me.txtDescripcion)
        Me.Controls.Add(Me.txtInclinacionE3)
        Me.Controls.Add(Me.txtInclinacionE2)
        Me.Controls.Add(Me.txtInclinacionE1)
        Me.Controls.Add(Me.txtDuracionE3)
        Me.Controls.Add(Me.txtDuracionE2)
        Me.Controls.Add(Me.txtDuracionE1)
        Me.Controls.Add(Me.txtInclinacionBasal)
        Me.Controls.Add(Me.txtDuracionBasal)
        Me.Controls.Add(Me.LabelE1)
        Me.Controls.Add(Me.LabelBasal)
        Me.Controls.Add(Me.LabelInc)
        Me.Controls.Add(Me.LabelDur)
        Me.Controls.Add(Me.cbxProto)
        Me.Controls.Add(Me.EditarProtocolo)
        Me.Controls.Add(Me.EliminarProtocolo)
        Me.Controls.Add(Me.NuevoProtocolo)
        Me.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Protocolo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Protocolo"
        CType(Me.DGVprotocolos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents EditarProtocolo As System.Windows.Forms.Button
    Friend WithEvents EliminarProtocolo As System.Windows.Forms.Button
    Friend WithEvents NuevoProtocolo As System.Windows.Forms.Button
    Friend WithEvents cbxProto As System.Windows.Forms.ComboBox
    Friend WithEvents LabelDur As System.Windows.Forms.Label
    Friend WithEvents LabelInc As System.Windows.Forms.Label
    Friend WithEvents LabelBasal As System.Windows.Forms.Label
    Friend WithEvents LabelE1 As System.Windows.Forms.Label
    Friend WithEvents txtDuracionBasal As System.Windows.Forms.TextBox
    Friend WithEvents txtInclinacionBasal As System.Windows.Forms.TextBox
    Friend WithEvents txtDuracionE1 As System.Windows.Forms.TextBox
    Friend WithEvents txtDuracionE2 As System.Windows.Forms.TextBox
    Friend WithEvents txtDuracionE3 As System.Windows.Forms.TextBox
    Friend WithEvents txtInclinacionE1 As System.Windows.Forms.TextBox
    Friend WithEvents txtInclinacionE2 As System.Windows.Forms.TextBox
    Friend WithEvents txtInclinacionE3 As System.Windows.Forms.TextBox
    Friend WithEvents txtDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents LabelE2 As System.Windows.Forms.Label
    Friend WithEvents LabelE3 As System.Windows.Forms.Label
    Friend WithEvents DGVprotocolos As System.Windows.Forms.DataGridView
End Class
