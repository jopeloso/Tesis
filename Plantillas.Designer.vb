<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Plantillas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Plantillas))
        Me.botoneliminarplantilla = New System.Windows.Forms.Button()
        Me.botonseditarplantilla = New System.Windows.Forms.Button()
        Me.botonNuevaplantilla = New System.Windows.Forms.Button()
        Me.cbxConclusiones = New System.Windows.Forms.ComboBox()
        Me.conclusiontext = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'botoneliminarplantilla
        '
        Me.botoneliminarplantilla.Enabled = False
        Me.botoneliminarplantilla.Location = New System.Drawing.Point(721, 17)
        Me.botoneliminarplantilla.Margin = New System.Windows.Forms.Padding(13, 8, 13, 8)
        Me.botoneliminarplantilla.Name = "botoneliminarplantilla"
        Me.botoneliminarplantilla.Size = New System.Drawing.Size(220, 40)
        Me.botoneliminarplantilla.TabIndex = 12
        Me.botoneliminarplantilla.Text = "Eliminar"
        Me.botoneliminarplantilla.UseVisualStyleBackColor = True
        '
        'botonseditarplantilla
        '
        Me.botonseditarplantilla.Enabled = False
        Me.botonseditarplantilla.Location = New System.Drawing.Point(491, 17)
        Me.botonseditarplantilla.Margin = New System.Windows.Forms.Padding(13, 8, 13, 8)
        Me.botonseditarplantilla.Name = "botonseditarplantilla"
        Me.botonseditarplantilla.Size = New System.Drawing.Size(220, 40)
        Me.botonseditarplantilla.TabIndex = 11
        Me.botonseditarplantilla.Text = "Editar"
        Me.botonseditarplantilla.UseVisualStyleBackColor = True
        '
        'botonNuevaplantilla
        '
        Me.botonNuevaplantilla.Location = New System.Drawing.Point(264, 17)
        Me.botonNuevaplantilla.Margin = New System.Windows.Forms.Padding(13, 8, 13, 8)
        Me.botonNuevaplantilla.Name = "botonNuevaplantilla"
        Me.botonNuevaplantilla.Size = New System.Drawing.Size(220, 40)
        Me.botonNuevaplantilla.TabIndex = 10
        Me.botonNuevaplantilla.Text = "Nueva"
        Me.botonNuevaplantilla.UseVisualStyleBackColor = True
        '
        'cbxConclusiones
        '
        Me.cbxConclusiones.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxConclusiones.FormattingEnabled = True
        Me.cbxConclusiones.Location = New System.Drawing.Point(12, 17)
        Me.cbxConclusiones.Name = "cbxConclusiones"
        Me.cbxConclusiones.Size = New System.Drawing.Size(229, 26)
        Me.cbxConclusiones.TabIndex = 84
        '
        'conclusiontext
        '
        Me.conclusiontext.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.conclusiontext.Location = New System.Drawing.Point(264, 84)
        Me.conclusiontext.MaxLength = 499
        Me.conclusiontext.Multiline = True
        Me.conclusiontext.Name = "conclusiontext"
        Me.conclusiontext.ReadOnly = True
        Me.conclusiontext.Size = New System.Drawing.Size(536, 242)
        Me.conclusiontext.TabIndex = 85
        '
        'Plantillas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.ClientSize = New System.Drawing.Size(961, 426)
        Me.Controls.Add(Me.conclusiontext)
        Me.Controls.Add(Me.cbxConclusiones)
        Me.Controls.Add(Me.botoneliminarplantilla)
        Me.Controls.Add(Me.botonseditarplantilla)
        Me.Controls.Add(Me.botonNuevaplantilla)
        Me.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Plantillas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Plantillas"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents botoneliminarplantilla As System.Windows.Forms.Button
    Friend WithEvents botonseditarplantilla As System.Windows.Forms.Button
    Friend WithEvents botonNuevaplantilla As System.Windows.Forms.Button
    Friend WithEvents cbxConclusiones As System.Windows.Forms.ComboBox
    Friend WithEvents conclusiontext As System.Windows.Forms.TextBox
End Class
