<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Usuarios
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Usuarios))
        Me.LabelNombreTecnico = New System.Windows.Forms.Label()
        Me.LabelApellidoTecnico = New System.Windows.Forms.Label()
        Me.botoneliminarUsuario = New System.Windows.Forms.Button()
        Me.botoneditarUsuario = New System.Windows.Forms.Button()
        Me.botonNuevoUsuario = New System.Windows.Forms.Button()
        Me.DGVUsuarios = New System.Windows.Forms.DataGridView()
        CType(Me.DGVUsuarios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LabelNombreTecnico
        '
        Me.LabelNombreTecnico.AutoSize = True
        Me.LabelNombreTecnico.Location = New System.Drawing.Point(-85, 46)
        Me.LabelNombreTecnico.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.LabelNombreTecnico.Name = "LabelNombreTecnico"
        Me.LabelNombreTecnico.Size = New System.Drawing.Size(71, 18)
        Me.LabelNombreTecnico.TabIndex = 90
        Me.LabelNombreTecnico.Text = "Nombre"
        '
        'LabelApellidoTecnico
        '
        Me.LabelApellidoTecnico.AutoSize = True
        Me.LabelApellidoTecnico.Location = New System.Drawing.Point(-85, 93)
        Me.LabelApellidoTecnico.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.LabelApellidoTecnico.Name = "LabelApellidoTecnico"
        Me.LabelApellidoTecnico.Size = New System.Drawing.Size(72, 18)
        Me.LabelApellidoTecnico.TabIndex = 89
        Me.LabelApellidoTecnico.Text = "Apellido"
        '
        'botoneliminarUsuario
        '
        Me.botoneliminarUsuario.Enabled = False
        Me.botoneliminarUsuario.Location = New System.Drawing.Point(667, 17)
        Me.botoneliminarUsuario.Margin = New System.Windows.Forms.Padding(13, 8, 13, 8)
        Me.botoneliminarUsuario.Name = "botoneliminarUsuario"
        Me.botoneliminarUsuario.Size = New System.Drawing.Size(220, 40)
        Me.botoneliminarUsuario.TabIndex = 93
        Me.botoneliminarUsuario.Text = "Eliminar"
        Me.botoneliminarUsuario.UseVisualStyleBackColor = True
        '
        'botoneditarUsuario
        '
        Me.botoneditarUsuario.Enabled = False
        Me.botoneditarUsuario.Location = New System.Drawing.Point(437, 17)
        Me.botoneditarUsuario.Margin = New System.Windows.Forms.Padding(13, 8, 13, 8)
        Me.botoneditarUsuario.Name = "botoneditarUsuario"
        Me.botoneditarUsuario.Size = New System.Drawing.Size(220, 40)
        Me.botoneditarUsuario.TabIndex = 92
        Me.botoneditarUsuario.Text = "Editar"
        Me.botoneditarUsuario.UseVisualStyleBackColor = True
        '
        'botonNuevoUsuario
        '
        Me.botonNuevoUsuario.Location = New System.Drawing.Point(22, 17)
        Me.botonNuevoUsuario.Margin = New System.Windows.Forms.Padding(13, 8, 13, 8)
        Me.botonNuevoUsuario.Name = "botonNuevoUsuario"
        Me.botonNuevoUsuario.Size = New System.Drawing.Size(220, 40)
        Me.botonNuevoUsuario.TabIndex = 91
        Me.botonNuevoUsuario.Text = "Nuevo"
        Me.botonNuevoUsuario.UseVisualStyleBackColor = True
        '
        'DGVUsuarios
        '
        Me.DGVUsuarios.AllowUserToAddRows = False
        Me.DGVUsuarios.AllowUserToDeleteRows = False
        Me.DGVUsuarios.AllowUserToResizeColumns = False
        Me.DGVUsuarios.AllowUserToResizeRows = False
        Me.DGVUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVUsuarios.Location = New System.Drawing.Point(210, 137)
        Me.DGVUsuarios.Name = "DGVUsuarios"
        Me.DGVUsuarios.RowHeadersVisible = False
        Me.DGVUsuarios.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.DGVUsuarios.Size = New System.Drawing.Size(240, 150)
        Me.DGVUsuarios.TabIndex = 94
        '
        'Usuarios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.ClientSize = New System.Drawing.Size(816, 463)
        Me.Controls.Add(Me.DGVUsuarios)
        Me.Controls.Add(Me.botoneliminarUsuario)
        Me.Controls.Add(Me.botoneditarUsuario)
        Me.Controls.Add(Me.botonNuevoUsuario)
        Me.Controls.Add(Me.LabelNombreTecnico)
        Me.Controls.Add(Me.LabelApellidoTecnico)
        Me.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Usuarios"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Usuarios"
        CType(Me.DGVUsuarios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LabelNombreTecnico As System.Windows.Forms.Label
    Friend WithEvents LabelApellidoTecnico As System.Windows.Forms.Label
    Friend WithEvents botoneliminarUsuario As System.Windows.Forms.Button
    Friend WithEvents botoneditarUsuario As System.Windows.Forms.Button
    Friend WithEvents botonNuevoUsuario As System.Windows.Forms.Button
    Friend WithEvents DGVUsuarios As System.Windows.Forms.DataGridView
End Class
