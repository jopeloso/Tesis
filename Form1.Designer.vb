<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim ChartArea2 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series2 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim Series3 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim Series4 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim Series5 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim Title1 As System.Windows.Forms.DataVisualization.Charting.Title = New System.Windows.Forms.DataVisualization.Charting.Title()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.TimerEnvio = New System.Windows.Forms.Timer(Me.components)
        Me.TimerReal = New System.Windows.Forms.Timer(Me.components)
        Me.carpeta = New System.Windows.Forms.FolderBrowserDialog()
        Me.TimerScreen = New System.Windows.Forms.Timer(Me.components)
        Me.Personal = New System.Windows.Forms.TabPage()
        Me.PictureBoxsalirServicio = New System.Windows.Forms.PictureBox()
        Me.PictureBox6 = New System.Windows.Forms.PictureBox()
        Me.DGVLogin = New System.Windows.Forms.DataGridView()
        Me.BotonUsuarios = New System.Windows.Forms.Button()
        Me.BotonIP = New System.Windows.Forms.Button()
        Me.BotonBaseDatos = New System.Windows.Forms.Button()
        Me.BotonCambiarServidor = New System.Windows.Forms.Button()
        Me.PanelStaff = New System.Windows.Forms.Panel()
        Me.RadioButtonActuantes = New System.Windows.Forms.RadioButton()
        Me.RadioButtonMandantes = New System.Windows.Forms.RadioButton()
        Me.RadioButtonTecnicos = New System.Windows.Forms.RadioButton()
        Me.botonProtocolos = New System.Windows.Forms.Button()
        Me.DGVauxiliar = New System.Windows.Forms.DataGridView()
        Me.DefectoActuante = New System.Windows.Forms.CheckBox()
        Me.DefectoMandante = New System.Windows.Forms.CheckBox()
        Me.DefectoTecnico = New System.Windows.Forms.CheckBox()
        Me.botonPlantillas = New System.Windows.Forms.Button()
        Me.activoactuante = New System.Windows.Forms.CheckBox()
        Me.txtApellidoactuante = New System.Windows.Forms.TextBox()
        Me.txtNombreactuante = New System.Windows.Forms.TextBox()
        Me.txtbuscaractuante = New System.Windows.Forms.TextBox()
        Me.txtApellidoMandante = New System.Windows.Forms.TextBox()
        Me.txtNombreMandante = New System.Windows.Forms.TextBox()
        Me.txtbuscarmandante = New System.Windows.Forms.TextBox()
        Me.txtApellidoTecnico = New System.Windows.Forms.TextBox()
        Me.txtNombreTecnico = New System.Windows.Forms.TextBox()
        Me.txtbuscartecnico = New System.Windows.Forms.TextBox()
        Me.LabelNombreActuante = New System.Windows.Forms.Label()
        Me.LabelApellidoActuante = New System.Windows.Forms.Label()
        Me.Editaractuante = New System.Windows.Forms.Button()
        Me.Eliminaractuante = New System.Windows.Forms.Button()
        Me.Insertaractuante = New System.Windows.Forms.Button()
        Me.buscaractuante = New System.Windows.Forms.Button()
        Me.DGVmedicosact = New System.Windows.Forms.DataGridView()
        Me.password = New System.Windows.Forms.Button()
        Me.activomandante = New System.Windows.Forms.CheckBox()
        Me.LabelNombreMandante = New System.Windows.Forms.Label()
        Me.LabelApellidoMandante = New System.Windows.Forms.Label()
        Me.EditarMandante = New System.Windows.Forms.Button()
        Me.EliminarMandante = New System.Windows.Forms.Button()
        Me.InsertarMandante = New System.Windows.Forms.Button()
        Me.BuscarMedMan = New System.Windows.Forms.Button()
        Me.DGVmedicosman = New System.Windows.Forms.DataGridView()
        Me.BotonRutaPDF = New System.Windows.Forms.Button()
        Me.activotecnico = New System.Windows.Forms.CheckBox()
        Me.LabelNombreTecnico = New System.Windows.Forms.Label()
        Me.LabelApellidoTecnico = New System.Windows.Forms.Label()
        Me.EditarTecnico = New System.Windows.Forms.Button()
        Me.EliminarTecnico = New System.Windows.Forms.Button()
        Me.InsertarTecnico = New System.Windows.Forms.Button()
        Me.botonBuscarTecnico = New System.Windows.Forms.Button()
        Me.DGVtecnicos = New System.Windows.Forms.DataGridView()
        Me.TirasECG = New System.Windows.Forms.TabPage()
        Me.iconoImprimirPDF = New System.Windows.Forms.PictureBox()
        Me.iconoGuardarExamen = New System.Windows.Forms.PictureBox()
        Me.botonCancelarEdicionEvento = New System.Windows.Forms.Button()
        Me.botonEditarEvento = New System.Windows.Forms.Button()
        Me.botonanteriorConclusion = New System.Windows.Forms.PictureBox()
        Me.botonBorrarEventos = New System.Windows.Forms.Button()
        Me.PictureBoxsalirTiras = New System.Windows.Forms.PictureBox()
        Me.LabelConclusion = New System.Windows.Forms.Label()
        Me.cbxConclusiones = New System.Windows.Forms.ComboBox()
        Me.conclusiontext = New System.Windows.Forms.TextBox()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.LabeltituloTiras = New System.Windows.Forms.Label()
        Me.ListBoxeventos = New System.Windows.Forms.ListBox()
        Me.ChartEventos = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.Grafico = New System.Windows.Forms.TabPage()
        Me.botonanteriorGrafico = New System.Windows.Forms.PictureBox()
        Me.botonsiguienteGrafico = New System.Windows.Forms.PictureBox()
        Me.PictureBoxsalirgrafico = New System.Windows.Forms.PictureBox()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.Chart1 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.Examen = New System.Windows.Forms.TabPage()
        Me.botonModificarPresion = New System.Windows.Forms.PictureBox()
        Me.iconoRecExamen = New System.Windows.Forms.PictureBox()
        Me.iconoPlayExamen = New System.Windows.Forms.PictureBox()
        Me.LabelPacientedesconectadoExamen = New System.Windows.Forms.Label()
        Me.LabelConexionExamen = New System.Windows.Forms.Label()
        Me.botonanteriorExamen = New System.Windows.Forms.PictureBox()
        Me.botonsiguienteExamen = New System.Windows.Forms.PictureBox()
        Me.botonSiguienteEtapa = New System.Windows.Forms.Button()
        Me.botonTerminarExamen = New System.Windows.Forms.Button()
        Me.PictureBoxsalirexamen = New System.Windows.Forms.PictureBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.PictureBoxECG = New System.Windows.Forms.PictureBox()
        Me.botonDeshacer = New System.Windows.Forms.Button()
        Me.PictureBoxfondosalir3 = New System.Windows.Forms.PictureBox()
        Me.LabelINC = New System.Windows.Forms.Label()
        Me.txtinclinacion = New System.Windows.Forms.TextBox()
        Me.txtdiastolica = New System.Windows.Forms.TextBox()
        Me.txtsistolica = New System.Windows.Forms.TextBox()
        Me.txtFC = New System.Windows.Forms.TextBox()
        Me.TextBoxTiempo = New System.Windows.Forms.TextBox()
        Me.botonPresion = New System.Windows.Forms.Button()
        Me.LabelPD = New System.Windows.Forms.Label()
        Me.LabelPS = New System.Windows.Forms.Label()
        Me.LabelFrecuencia = New System.Windows.Forms.Label()
        Me.LabelTiempo = New System.Windows.Forms.Label()
        Me.DatosExamen = New System.Windows.Forms.DataGridView()
        Me.ColumnaMinutos = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColumnaSintomas = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColumnaFC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColumnPS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColumnPD = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TabPreguntas = New System.Windows.Forms.TabPage()
        Me.iconoRecProtocolos = New System.Windows.Forms.PictureBox()
        Me.iconoPlayProtocolos = New System.Windows.Forms.PictureBox()
        Me.LabelPacientedesconectadoprotocolo = New System.Windows.Forms.Label()
        Me.LabelConexionProtocolo = New System.Windows.Forms.Label()
        Me.botonAnteriorProtocolo = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.tickprotocolo = New System.Windows.Forms.PictureBox()
        Me.PictureBoxSalirProtocolo = New System.Windows.Forms.PictureBox()
        Me.PictureBoxECGProtocolo = New System.Windows.Forms.PictureBox()
        Me.TextINTE9 = New System.Windows.Forms.TextBox()
        Me.TextProtocolo = New System.Windows.Forms.TextBox()
        Me.TextINTE3 = New System.Windows.Forms.TextBox()
        Me.DGVprotocolo = New System.Windows.Forms.DataGridView()
        Me.botonsiguienteprotocolo = New System.Windows.Forms.PictureBox()
        Me.Labelpreg9 = New System.Windows.Forms.Label()
        Me.ComboBoxProtocolo = New System.Windows.Forms.ComboBox()
        Me.LabeltituloPROTO = New System.Windows.Forms.Label()
        Me.Panel10 = New System.Windows.Forms.Panel()
        Me.INTE8SI = New System.Windows.Forms.RadioButton()
        Me.INTE8NO = New System.Windows.Forms.RadioButton()
        Me.Panel9 = New System.Windows.Forms.Panel()
        Me.INTE7SI = New System.Windows.Forms.RadioButton()
        Me.INTE7NO = New System.Windows.Forms.RadioButton()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.INTE6NOSABE = New System.Windows.Forms.RadioButton()
        Me.INTE6SI = New System.Windows.Forms.RadioButton()
        Me.INTE6NO = New System.Windows.Forms.RadioButton()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.INTE5SI = New System.Windows.Forms.RadioButton()
        Me.INTE5NO = New System.Windows.Forms.RadioButton()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.INTE4SI = New System.Windows.Forms.RadioButton()
        Me.INTE4NO = New System.Windows.Forms.RadioButton()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.INTE2SI = New System.Windows.Forms.RadioButton()
        Me.INTE2NO = New System.Windows.Forms.RadioButton()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.INTE1NO = New System.Windows.Forms.RadioButton()
        Me.INTE1SI = New System.Windows.Forms.RadioButton()
        Me.Labelpreg8 = New System.Windows.Forms.Label()
        Me.Labelpreg7 = New System.Windows.Forms.Label()
        Me.Labelpreg6 = New System.Windows.Forms.Label()
        Me.Labelpreg5 = New System.Windows.Forms.Label()
        Me.Labelpreg4 = New System.Windows.Forms.Label()
        Me.Labelpreg3 = New System.Windows.Forms.Label()
        Me.Labelpreg2 = New System.Windows.Forms.Label()
        Me.Labelpreg1 = New System.Windows.Forms.Label()
        Me.LabeltituloINTE = New System.Windows.Forms.Label()
        Me.TabPersonales = New System.Windows.Forms.TabPage()
        Me.iconoRECpaciente = New System.Windows.Forms.PictureBox()
        Me.iconoPlayPaciente = New System.Windows.Forms.PictureBox()
        Me.LabelPacienteDesconectado = New System.Windows.Forms.Label()
        Me.LabelConexionPersonales = New System.Windows.Forms.Label()
        Me.PictureBoxEditarPaciente = New System.Windows.Forms.PictureBox()
        Me.CheckBoxMandanteExterno = New System.Windows.Forms.CheckBox()
        Me.LabeltituloPaciente = New System.Windows.Forms.Label()
        Me.txtfechahoy = New System.Windows.Forms.Label()
        Me.TextRitmo = New System.Windows.Forms.TextBox()
        Me.TextDNI = New System.Windows.Forms.TextBox()
        Me.TextEdad = New System.Windows.Forms.TextBox()
        Me.TextApellido = New System.Windows.Forms.TextBox()
        Me.TextNombre = New System.Windows.Forms.TextBox()
        Me.TextTelefono = New System.Windows.Forms.TextBox()
        Me.TextDomicilio = New System.Windows.Forms.TextBox()
        Me.txtfechaexamen = New System.Windows.Forms.TextBox()
        Me.TextSintoma = New System.Windows.Forms.TextBox()
        Me.LabelRitmo = New System.Windows.Forms.Label()
        Me.PictureBoxECGPaciente = New System.Windows.Forms.PictureBox()
        Me.PictureBoxTuercaFondo = New System.Windows.Forms.PictureBox()
        Me.LabelEdad = New System.Windows.Forms.Label()
        Me.LabelApellido = New System.Windows.Forms.Label()
        Me.Panelsexo = New System.Windows.Forms.Panel()
        Me.botonMsexo = New System.Windows.Forms.RadioButton()
        Me.botonFsexo = New System.Windows.Forms.RadioButton()
        Me.LabelSexo = New System.Windows.Forms.Label()
        Me.LabelDNI = New System.Windows.Forms.Label()
        Me.PanelINT = New System.Windows.Forms.Panel()
        Me.InternadoSI = New System.Windows.Forms.RadioButton()
        Me.InternadoNO = New System.Windows.Forms.RadioButton()
        Me.LabelInternado = New System.Windows.Forms.Label()
        Me.LabelTelefono = New System.Windows.Forms.Label()
        Me.LabelDomicilio = New System.Windows.Forms.Label()
        Me.LabelNombre = New System.Windows.Forms.Label()
        Me.botonbuscarexamen = New System.Windows.Forms.Button()
        Me.botonBuscarpaciente = New System.Windows.Forms.Button()
        Me.botonNuevopaciente = New System.Windows.Forms.Button()
        Me.LabelTitulo = New System.Windows.Forms.Label()
        Me.PictureBoxSalirPaciente = New System.Windows.Forms.PictureBox()
        Me.Labeltecnico = New System.Windows.Forms.Label()
        Me.Labelactuante = New System.Windows.Forms.Label()
        Me.Labelmandante = New System.Windows.Forms.Label()
        Me.tickpersonales = New System.Windows.Forms.PictureBox()
        Me.botonsiguiente = New System.Windows.Forms.PictureBox()
        Me.LabelFecha = New System.Windows.Forms.Label()
        Me.cbxActuante = New System.Windows.Forms.ComboBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.cbxMandante = New System.Windows.Forms.ComboBox()
        Me.cbxTecnico = New System.Windows.Forms.ComboBox()
        Me.LabelTecnicovisible = New System.Windows.Forms.Label()
        Me.LabelActuantevisible = New System.Windows.Forms.Label()
        Me.LabelMandantevisible = New System.Windows.Forms.Label()
        Me.LabelSintoma = New System.Windows.Forms.Label()
        Me.imagenfondo = New System.Windows.Forms.PictureBox()
        Me.TabGeneral = New System.Windows.Forms.TabControl()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.TimerRecepcion = New System.Windows.Forms.Timer(Me.components)
        Me.TimerDisplay = New System.Windows.Forms.Timer(Me.components)
        Me.Personal.SuspendLayout()
        CType(Me.PictureBoxsalirServicio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGVLogin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelStaff.SuspendLayout()
        CType(Me.DGVauxiliar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGVmedicosact, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGVmedicosman, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGVtecnicos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TirasECG.SuspendLayout()
        CType(Me.iconoImprimirPDF, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.iconoGuardarExamen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.botonanteriorConclusion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBoxsalirTiras, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ChartEventos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Grafico.SuspendLayout()
        CType(Me.botonanteriorGrafico, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.botonsiguienteGrafico, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBoxsalirgrafico, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Examen.SuspendLayout()
        CType(Me.botonModificarPresion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.iconoRecExamen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.iconoPlayExamen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.botonanteriorExamen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.botonsiguienteExamen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBoxsalirexamen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBoxECG, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBoxfondosalir3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DatosExamen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPreguntas.SuspendLayout()
        CType(Me.iconoRecProtocolos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.iconoPlayProtocolos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.botonAnteriorProtocolo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tickprotocolo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBoxSalirProtocolo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBoxECGProtocolo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGVprotocolo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.botonsiguienteprotocolo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel10.SuspendLayout()
        Me.Panel9.SuspendLayout()
        Me.Panel8.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.TabPersonales.SuspendLayout()
        CType(Me.iconoRECpaciente, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.iconoPlayPaciente, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBoxEditarPaciente, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBoxECGPaciente, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBoxTuercaFondo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panelsexo.SuspendLayout()
        Me.PanelINT.SuspendLayout()
        CType(Me.PictureBoxSalirPaciente, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tickpersonales, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.botonsiguiente, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.imagenfondo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabGeneral.SuspendLayout()
        Me.SuspendLayout()
        '
        'TimerEnvio
        '
        Me.TimerEnvio.Enabled = True
        Me.TimerEnvio.Interval = 500
        '
        'TimerReal
        '
        Me.TimerReal.Interval = 1000
        '
        'TimerScreen
        '
        Me.TimerScreen.Interval = 1500
        '
        'Personal
        '
        Me.Personal.AccessibleRole = System.Windows.Forms.AccessibleRole.None
        Me.Personal.Controls.Add(Me.PictureBoxsalirServicio)
        Me.Personal.Controls.Add(Me.PictureBox6)
        Me.Personal.Controls.Add(Me.DGVLogin)
        Me.Personal.Controls.Add(Me.BotonUsuarios)
        Me.Personal.Controls.Add(Me.BotonIP)
        Me.Personal.Controls.Add(Me.BotonBaseDatos)
        Me.Personal.Controls.Add(Me.BotonCambiarServidor)
        Me.Personal.Controls.Add(Me.PanelStaff)
        Me.Personal.Controls.Add(Me.botonProtocolos)
        Me.Personal.Controls.Add(Me.DGVauxiliar)
        Me.Personal.Controls.Add(Me.DefectoActuante)
        Me.Personal.Controls.Add(Me.DefectoMandante)
        Me.Personal.Controls.Add(Me.DefectoTecnico)
        Me.Personal.Controls.Add(Me.botonPlantillas)
        Me.Personal.Controls.Add(Me.activoactuante)
        Me.Personal.Controls.Add(Me.txtApellidoactuante)
        Me.Personal.Controls.Add(Me.txtNombreactuante)
        Me.Personal.Controls.Add(Me.txtbuscaractuante)
        Me.Personal.Controls.Add(Me.txtApellidoMandante)
        Me.Personal.Controls.Add(Me.txtNombreMandante)
        Me.Personal.Controls.Add(Me.txtbuscarmandante)
        Me.Personal.Controls.Add(Me.txtApellidoTecnico)
        Me.Personal.Controls.Add(Me.txtNombreTecnico)
        Me.Personal.Controls.Add(Me.txtbuscartecnico)
        Me.Personal.Controls.Add(Me.LabelNombreActuante)
        Me.Personal.Controls.Add(Me.LabelApellidoActuante)
        Me.Personal.Controls.Add(Me.Editaractuante)
        Me.Personal.Controls.Add(Me.Eliminaractuante)
        Me.Personal.Controls.Add(Me.Insertaractuante)
        Me.Personal.Controls.Add(Me.buscaractuante)
        Me.Personal.Controls.Add(Me.DGVmedicosact)
        Me.Personal.Controls.Add(Me.password)
        Me.Personal.Controls.Add(Me.activomandante)
        Me.Personal.Controls.Add(Me.LabelNombreMandante)
        Me.Personal.Controls.Add(Me.LabelApellidoMandante)
        Me.Personal.Controls.Add(Me.EditarMandante)
        Me.Personal.Controls.Add(Me.EliminarMandante)
        Me.Personal.Controls.Add(Me.InsertarMandante)
        Me.Personal.Controls.Add(Me.BuscarMedMan)
        Me.Personal.Controls.Add(Me.DGVmedicosman)
        Me.Personal.Controls.Add(Me.BotonRutaPDF)
        Me.Personal.Controls.Add(Me.activotecnico)
        Me.Personal.Controls.Add(Me.LabelNombreTecnico)
        Me.Personal.Controls.Add(Me.LabelApellidoTecnico)
        Me.Personal.Controls.Add(Me.EditarTecnico)
        Me.Personal.Controls.Add(Me.EliminarTecnico)
        Me.Personal.Controls.Add(Me.InsertarTecnico)
        Me.Personal.Controls.Add(Me.botonBuscarTecnico)
        Me.Personal.Controls.Add(Me.DGVtecnicos)
        Me.Personal.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Personal.Location = New System.Drawing.Point(4, 27)
        Me.Personal.Name = "Personal"
        Me.Personal.Padding = New System.Windows.Forms.Padding(3)
        Me.Personal.Size = New System.Drawing.Size(2017, 1164)
        Me.Personal.TabIndex = 5
        Me.Personal.Text = "  "
        Me.Personal.UseVisualStyleBackColor = True
        '
        'PictureBoxsalirServicio
        '
        Me.PictureBoxsalirServicio.BackColor = System.Drawing.Color.Transparent
        Me.PictureBoxsalirServicio.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBoxsalirServicio.Image = CType(resources.GetObject("PictureBoxsalirServicio.Image"), System.Drawing.Image)
        Me.PictureBoxsalirServicio.Location = New System.Drawing.Point(846, 264)
        Me.PictureBoxsalirServicio.Name = "PictureBoxsalirServicio"
        Me.PictureBoxsalirServicio.Size = New System.Drawing.Size(71, 64)
        Me.PictureBoxsalirServicio.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBoxsalirServicio.TabIndex = 126
        Me.PictureBoxsalirServicio.TabStop = False
        '
        'PictureBox6
        '
        Me.PictureBox6.BackgroundImage = CType(resources.GetObject("PictureBox6.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox6.Location = New System.Drawing.Point(685, 209)
        Me.PictureBox6.Name = "PictureBox6"
        Me.PictureBox6.Size = New System.Drawing.Size(132, 149)
        Me.PictureBox6.TabIndex = 125
        Me.PictureBox6.TabStop = False
        '
        'DGVLogin
        '
        Me.DGVLogin.AllowUserToAddRows = False
        Me.DGVLogin.AllowUserToDeleteRows = False
        Me.DGVLogin.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVLogin.Enabled = False
        Me.DGVLogin.Location = New System.Drawing.Point(923, 570)
        Me.DGVLogin.Name = "DGVLogin"
        Me.DGVLogin.ReadOnly = True
        Me.DGVLogin.RowHeadersVisible = False
        Me.DGVLogin.RowHeadersWidth = 4
        Me.DGVLogin.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.DGVLogin.Size = New System.Drawing.Size(321, 52)
        Me.DGVLogin.TabIndex = 124
        Me.DGVLogin.Visible = False
        '
        'BotonUsuarios
        '
        Me.BotonUsuarios.Location = New System.Drawing.Point(357, 681)
        Me.BotonUsuarios.Name = "BotonUsuarios"
        Me.BotonUsuarios.Size = New System.Drawing.Size(124, 75)
        Me.BotonUsuarios.TabIndex = 123
        Me.BotonUsuarios.Text = "Cambiar Usuarios"
        Me.BotonUsuarios.UseVisualStyleBackColor = True
        '
        'BotonIP
        '
        Me.BotonIP.Location = New System.Drawing.Point(357, 599)
        Me.BotonIP.Name = "BotonIP"
        Me.BotonIP.Size = New System.Drawing.Size(124, 75)
        Me.BotonIP.TabIndex = 122
        Me.BotonIP.Text = "Cambiar IP"
        Me.BotonIP.UseVisualStyleBackColor = True
        '
        'BotonBaseDatos
        '
        Me.BotonBaseDatos.Location = New System.Drawing.Point(357, 518)
        Me.BotonBaseDatos.Name = "BotonBaseDatos"
        Me.BotonBaseDatos.Size = New System.Drawing.Size(124, 75)
        Me.BotonBaseDatos.TabIndex = 121
        Me.BotonBaseDatos.Text = "Reiniciar BD"
        Me.BotonBaseDatos.UseVisualStyleBackColor = True
        '
        'BotonCambiarServidor
        '
        Me.BotonCambiarServidor.Location = New System.Drawing.Point(357, 429)
        Me.BotonCambiarServidor.Name = "BotonCambiarServidor"
        Me.BotonCambiarServidor.Size = New System.Drawing.Size(124, 75)
        Me.BotonCambiarServidor.TabIndex = 120
        Me.BotonCambiarServidor.Text = "Cambiar Servidor"
        Me.BotonCambiarServidor.UseVisualStyleBackColor = True
        '
        'PanelStaff
        '
        Me.PanelStaff.Controls.Add(Me.RadioButtonActuantes)
        Me.PanelStaff.Controls.Add(Me.RadioButtonMandantes)
        Me.PanelStaff.Controls.Add(Me.RadioButtonTecnicos)
        Me.PanelStaff.Location = New System.Drawing.Point(147, 6)
        Me.PanelStaff.Name = "PanelStaff"
        Me.PanelStaff.Size = New System.Drawing.Size(483, 28)
        Me.PanelStaff.TabIndex = 118
        '
        'RadioButtonActuantes
        '
        Me.RadioButtonActuantes.AutoSize = True
        Me.RadioButtonActuantes.Location = New System.Drawing.Point(298, 3)
        Me.RadioButtonActuantes.Name = "RadioButtonActuantes"
        Me.RadioButtonActuantes.Size = New System.Drawing.Size(179, 22)
        Me.RadioButtonActuantes.TabIndex = 2
        Me.RadioButtonActuantes.TabStop = True
        Me.RadioButtonActuantes.Text = "Médicos Actuantes"
        Me.RadioButtonActuantes.UseVisualStyleBackColor = True
        '
        'RadioButtonMandantes
        '
        Me.RadioButtonMandantes.AutoSize = True
        Me.RadioButtonMandantes.Location = New System.Drawing.Point(108, 3)
        Me.RadioButtonMandantes.Name = "RadioButtonMandantes"
        Me.RadioButtonMandantes.Size = New System.Drawing.Size(184, 22)
        Me.RadioButtonMandantes.TabIndex = 1
        Me.RadioButtonMandantes.TabStop = True
        Me.RadioButtonMandantes.Text = "Médicos Mandantes"
        Me.RadioButtonMandantes.UseVisualStyleBackColor = True
        '
        'RadioButtonTecnicos
        '
        Me.RadioButtonTecnicos.AutoSize = True
        Me.RadioButtonTecnicos.Location = New System.Drawing.Point(3, 3)
        Me.RadioButtonTecnicos.Name = "RadioButtonTecnicos"
        Me.RadioButtonTecnicos.Size = New System.Drawing.Size(99, 22)
        Me.RadioButtonTecnicos.TabIndex = 0
        Me.RadioButtonTecnicos.TabStop = True
        Me.RadioButtonTecnicos.Text = "Técnicos"
        Me.RadioButtonTecnicos.UseVisualStyleBackColor = True
        '
        'botonProtocolos
        '
        Me.botonProtocolos.Location = New System.Drawing.Point(19, 609)
        Me.botonProtocolos.Name = "botonProtocolos"
        Me.botonProtocolos.Size = New System.Drawing.Size(124, 75)
        Me.botonProtocolos.TabIndex = 115
        Me.botonProtocolos.Text = "Cambiar Protocolos"
        Me.botonProtocolos.UseVisualStyleBackColor = True
        '
        'DGVauxiliar
        '
        Me.DGVauxiliar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVauxiliar.Enabled = False
        Me.DGVauxiliar.Location = New System.Drawing.Point(296, 771)
        Me.DGVauxiliar.Name = "DGVauxiliar"
        Me.DGVauxiliar.Size = New System.Drawing.Size(240, 43)
        Me.DGVauxiliar.TabIndex = 114
        Me.DGVauxiliar.Visible = False
        '
        'DefectoActuante
        '
        Me.DefectoActuante.AutoSize = True
        Me.DefectoActuante.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.DefectoActuante.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.DefectoActuante.Location = New System.Drawing.Point(1088, 140)
        Me.DefectoActuante.Name = "DefectoActuante"
        Me.DefectoActuante.Size = New System.Drawing.Size(88, 22)
        Me.DefectoActuante.TabIndex = 113
        Me.DefectoActuante.Text = "Defecto"
        Me.DefectoActuante.UseVisualStyleBackColor = True
        Me.DefectoActuante.Visible = False
        '
        'DefectoMandante
        '
        Me.DefectoMandante.AutoSize = True
        Me.DefectoMandante.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.DefectoMandante.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.DefectoMandante.Location = New System.Drawing.Point(606, 140)
        Me.DefectoMandante.Name = "DefectoMandante"
        Me.DefectoMandante.Size = New System.Drawing.Size(88, 22)
        Me.DefectoMandante.TabIndex = 112
        Me.DefectoMandante.Text = "Defecto"
        Me.DefectoMandante.UseVisualStyleBackColor = True
        Me.DefectoMandante.Visible = False
        '
        'DefectoTecnico
        '
        Me.DefectoTecnico.AutoSize = True
        Me.DefectoTecnico.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.DefectoTecnico.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.DefectoTecnico.Location = New System.Drawing.Point(126, 138)
        Me.DefectoTecnico.Name = "DefectoTecnico"
        Me.DefectoTecnico.Size = New System.Drawing.Size(88, 22)
        Me.DefectoTecnico.TabIndex = 111
        Me.DefectoTecnico.Text = "Defecto"
        Me.DefectoTecnico.UseVisualStyleBackColor = True
        '
        'botonPlantillas
        '
        Me.botonPlantillas.Location = New System.Drawing.Point(19, 518)
        Me.botonPlantillas.Name = "botonPlantillas"
        Me.botonPlantillas.Size = New System.Drawing.Size(124, 75)
        Me.botonPlantillas.TabIndex = 110
        Me.botonPlantillas.Text = "Cambiar Plantillas"
        Me.botonPlantillas.UseVisualStyleBackColor = True
        '
        'activoactuante
        '
        Me.activoactuante.AutoSize = True
        Me.activoactuante.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.activoactuante.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.activoactuante.Location = New System.Drawing.Point(982, 140)
        Me.activoactuante.Name = "activoactuante"
        Me.activoactuante.Size = New System.Drawing.Size(76, 22)
        Me.activoactuante.TabIndex = 108
        Me.activoactuante.Text = "Activo"
        Me.activoactuante.UseVisualStyleBackColor = True
        Me.activoactuante.Visible = False
        '
        'txtApellidoactuante
        '
        Me.txtApellidoactuante.Location = New System.Drawing.Point(1058, 106)
        Me.txtApellidoactuante.MaxLength = 29
        Me.txtApellidoactuante.Name = "txtApellidoactuante"
        Me.txtApellidoactuante.Size = New System.Drawing.Size(120, 26)
        Me.txtApellidoactuante.TabIndex = 107
        Me.txtApellidoactuante.Visible = False
        '
        'txtNombreactuante
        '
        Me.txtNombreactuante.Location = New System.Drawing.Point(1058, 69)
        Me.txtNombreactuante.MaxLength = 29
        Me.txtNombreactuante.Name = "txtNombreactuante"
        Me.txtNombreactuante.Size = New System.Drawing.Size(120, 26)
        Me.txtNombreactuante.TabIndex = 104
        Me.txtNombreactuante.Visible = False
        '
        'txtbuscaractuante
        '
        Me.txtbuscaractuante.Location = New System.Drawing.Point(986, 34)
        Me.txtbuscaractuante.Name = "txtbuscaractuante"
        Me.txtbuscaractuante.Size = New System.Drawing.Size(272, 26)
        Me.txtbuscaractuante.TabIndex = 99
        Me.txtbuscaractuante.Visible = False
        '
        'txtApellidoMandante
        '
        Me.txtApellidoMandante.Location = New System.Drawing.Point(576, 106)
        Me.txtApellidoMandante.MaxLength = 29
        Me.txtApellidoMandante.Name = "txtApellidoMandante"
        Me.txtApellidoMandante.Size = New System.Drawing.Size(120, 26)
        Me.txtApellidoMandante.TabIndex = 93
        Me.txtApellidoMandante.Visible = False
        '
        'txtNombreMandante
        '
        Me.txtNombreMandante.Location = New System.Drawing.Point(576, 69)
        Me.txtNombreMandante.MaxLength = 29
        Me.txtNombreMandante.Name = "txtNombreMandante"
        Me.txtNombreMandante.Size = New System.Drawing.Size(120, 26)
        Me.txtNombreMandante.TabIndex = 90
        Me.txtNombreMandante.Visible = False
        '
        'txtbuscarmandante
        '
        Me.txtbuscarmandante.Location = New System.Drawing.Point(504, 34)
        Me.txtbuscarmandante.Name = "txtbuscarmandante"
        Me.txtbuscarmandante.Size = New System.Drawing.Size(272, 26)
        Me.txtbuscarmandante.TabIndex = 85
        Me.txtbuscarmandante.Visible = False
        '
        'txtApellidoTecnico
        '
        Me.txtApellidoTecnico.Location = New System.Drawing.Point(94, 106)
        Me.txtApellidoTecnico.MaxLength = 29
        Me.txtApellidoTecnico.Name = "txtApellidoTecnico"
        Me.txtApellidoTecnico.Size = New System.Drawing.Size(120, 26)
        Me.txtApellidoTecnico.TabIndex = 81
        '
        'txtNombreTecnico
        '
        Me.txtNombreTecnico.Location = New System.Drawing.Point(96, 69)
        Me.txtNombreTecnico.MaxLength = 29
        Me.txtNombreTecnico.Name = "txtNombreTecnico"
        Me.txtNombreTecnico.Size = New System.Drawing.Size(120, 26)
        Me.txtNombreTecnico.TabIndex = 78
        '
        'txtbuscartecnico
        '
        Me.txtbuscartecnico.Location = New System.Drawing.Point(22, 34)
        Me.txtbuscartecnico.Name = "txtbuscartecnico"
        Me.txtbuscartecnico.Size = New System.Drawing.Size(272, 26)
        Me.txtbuscartecnico.TabIndex = 72
        '
        'LabelNombreActuante
        '
        Me.LabelNombreActuante.AutoSize = True
        Me.LabelNombreActuante.Location = New System.Drawing.Point(982, 75)
        Me.LabelNombreActuante.Name = "LabelNombreActuante"
        Me.LabelNombreActuante.Size = New System.Drawing.Size(71, 18)
        Me.LabelNombreActuante.TabIndex = 106
        Me.LabelNombreActuante.Text = "Nombre"
        Me.LabelNombreActuante.Visible = False
        '
        'LabelApellidoActuante
        '
        Me.LabelApellidoActuante.AutoSize = True
        Me.LabelApellidoActuante.Location = New System.Drawing.Point(982, 109)
        Me.LabelApellidoActuante.Name = "LabelApellidoActuante"
        Me.LabelApellidoActuante.Size = New System.Drawing.Size(72, 18)
        Me.LabelApellidoActuante.TabIndex = 105
        Me.LabelApellidoActuante.Text = "Apellido"
        Me.LabelApellidoActuante.Visible = False
        '
        'Editaractuante
        '
        Me.Editaractuante.Location = New System.Drawing.Point(1260, 146)
        Me.Editaractuante.Name = "Editaractuante"
        Me.Editaractuante.Size = New System.Drawing.Size(117, 32)
        Me.Editaractuante.TabIndex = 103
        Me.Editaractuante.Text = "Editar "
        Me.Editaractuante.UseVisualStyleBackColor = True
        Me.Editaractuante.UseWaitCursor = True
        Me.Editaractuante.Visible = False
        '
        'Eliminaractuante
        '
        Me.Eliminaractuante.Location = New System.Drawing.Point(1260, 108)
        Me.Eliminaractuante.Name = "Eliminaractuante"
        Me.Eliminaractuante.Size = New System.Drawing.Size(117, 32)
        Me.Eliminaractuante.TabIndex = 102
        Me.Eliminaractuante.Text = "Eliminar"
        Me.Eliminaractuante.UseVisualStyleBackColor = True
        Me.Eliminaractuante.Visible = False
        '
        'Insertaractuante
        '
        Me.Insertaractuante.Location = New System.Drawing.Point(1260, 70)
        Me.Insertaractuante.Name = "Insertaractuante"
        Me.Insertaractuante.Size = New System.Drawing.Size(117, 32)
        Me.Insertaractuante.TabIndex = 101
        Me.Insertaractuante.Text = "Nuevo"
        Me.Insertaractuante.UseVisualStyleBackColor = True
        Me.Insertaractuante.Visible = False
        '
        'buscaractuante
        '
        Me.buscaractuante.Location = New System.Drawing.Point(1260, 34)
        Me.buscaractuante.Name = "buscaractuante"
        Me.buscaractuante.Size = New System.Drawing.Size(117, 32)
        Me.buscaractuante.TabIndex = 100
        Me.buscaractuante.Text = "Buscar Mandante"
        Me.buscaractuante.UseVisualStyleBackColor = True
        Me.buscaractuante.Visible = False
        '
        'DGVmedicosact
        '
        Me.DGVmedicosact.AllowUserToAddRows = False
        Me.DGVmedicosact.AllowUserToDeleteRows = False
        Me.DGVmedicosact.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVmedicosact.Location = New System.Drawing.Point(982, 185)
        Me.DGVmedicosact.Name = "DGVmedicosact"
        Me.DGVmedicosact.ReadOnly = True
        Me.DGVmedicosact.RowHeadersVisible = False
        Me.DGVmedicosact.RowHeadersWidth = 4
        Me.DGVmedicosact.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.DGVmedicosact.Size = New System.Drawing.Size(436, 143)
        Me.DGVmedicosact.TabIndex = 98
        Me.DGVmedicosact.Visible = False
        '
        'password
        '
        Me.password.Location = New System.Drawing.Point(19, 429)
        Me.password.Name = "password"
        Me.password.Size = New System.Drawing.Size(124, 75)
        Me.password.TabIndex = 95
        Me.password.Text = "Cambiar Contraseña"
        Me.password.UseVisualStyleBackColor = True
        '
        'activomandante
        '
        Me.activomandante.AutoSize = True
        Me.activomandante.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.activomandante.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.activomandante.Location = New System.Drawing.Point(501, 140)
        Me.activomandante.Name = "activomandante"
        Me.activomandante.Size = New System.Drawing.Size(76, 22)
        Me.activomandante.TabIndex = 94
        Me.activomandante.Text = "Activo"
        Me.activomandante.UseVisualStyleBackColor = True
        Me.activomandante.Visible = False
        '
        'LabelNombreMandante
        '
        Me.LabelNombreMandante.AutoSize = True
        Me.LabelNombreMandante.Location = New System.Drawing.Point(501, 75)
        Me.LabelNombreMandante.Name = "LabelNombreMandante"
        Me.LabelNombreMandante.Size = New System.Drawing.Size(71, 18)
        Me.LabelNombreMandante.TabIndex = 92
        Me.LabelNombreMandante.Text = "Nombre"
        Me.LabelNombreMandante.Visible = False
        '
        'LabelApellidoMandante
        '
        Me.LabelApellidoMandante.AutoSize = True
        Me.LabelApellidoMandante.Location = New System.Drawing.Point(501, 109)
        Me.LabelApellidoMandante.Name = "LabelApellidoMandante"
        Me.LabelApellidoMandante.Size = New System.Drawing.Size(72, 18)
        Me.LabelApellidoMandante.TabIndex = 91
        Me.LabelApellidoMandante.Text = "Apellido"
        Me.LabelApellidoMandante.Visible = False
        '
        'EditarMandante
        '
        Me.EditarMandante.Location = New System.Drawing.Point(778, 146)
        Me.EditarMandante.Name = "EditarMandante"
        Me.EditarMandante.Size = New System.Drawing.Size(117, 32)
        Me.EditarMandante.TabIndex = 89
        Me.EditarMandante.Text = "Editar "
        Me.EditarMandante.UseVisualStyleBackColor = True
        Me.EditarMandante.UseWaitCursor = True
        Me.EditarMandante.Visible = False
        '
        'EliminarMandante
        '
        Me.EliminarMandante.Location = New System.Drawing.Point(778, 108)
        Me.EliminarMandante.Name = "EliminarMandante"
        Me.EliminarMandante.Size = New System.Drawing.Size(117, 32)
        Me.EliminarMandante.TabIndex = 88
        Me.EliminarMandante.Text = "Eliminar"
        Me.EliminarMandante.UseVisualStyleBackColor = True
        Me.EliminarMandante.Visible = False
        '
        'InsertarMandante
        '
        Me.InsertarMandante.Location = New System.Drawing.Point(778, 70)
        Me.InsertarMandante.Name = "InsertarMandante"
        Me.InsertarMandante.Size = New System.Drawing.Size(117, 32)
        Me.InsertarMandante.TabIndex = 87
        Me.InsertarMandante.Text = "Nuevo"
        Me.InsertarMandante.UseVisualStyleBackColor = True
        Me.InsertarMandante.Visible = False
        '
        'BuscarMedMan
        '
        Me.BuscarMedMan.Location = New System.Drawing.Point(778, 34)
        Me.BuscarMedMan.Name = "BuscarMedMan"
        Me.BuscarMedMan.Size = New System.Drawing.Size(117, 32)
        Me.BuscarMedMan.TabIndex = 86
        Me.BuscarMedMan.Text = "Buscar Mandante"
        Me.BuscarMedMan.UseVisualStyleBackColor = True
        Me.BuscarMedMan.Visible = False
        '
        'DGVmedicosman
        '
        Me.DGVmedicosman.AllowUserToAddRows = False
        Me.DGVmedicosman.AllowUserToDeleteRows = False
        Me.DGVmedicosman.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVmedicosman.Location = New System.Drawing.Point(549, 399)
        Me.DGVmedicosman.Name = "DGVmedicosman"
        Me.DGVmedicosman.ReadOnly = True
        Me.DGVmedicosman.RowHeadersVisible = False
        Me.DGVmedicosman.RowHeadersWidth = 4
        Me.DGVmedicosman.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.DGVmedicosman.Size = New System.Drawing.Size(466, 143)
        Me.DGVmedicosman.TabIndex = 84
        Me.DGVmedicosman.Visible = False
        '
        'BotonRutaPDF
        '
        Me.BotonRutaPDF.Location = New System.Drawing.Point(19, 348)
        Me.BotonRutaPDF.Name = "BotonRutaPDF"
        Me.BotonRutaPDF.Size = New System.Drawing.Size(124, 75)
        Me.BotonRutaPDF.TabIndex = 83
        Me.BotonRutaPDF.Text = "Ruta PDF"
        Me.BotonRutaPDF.UseVisualStyleBackColor = True
        '
        'activotecnico
        '
        Me.activotecnico.AutoSize = True
        Me.activotecnico.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.activotecnico.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.activotecnico.Location = New System.Drawing.Point(19, 140)
        Me.activotecnico.Name = "activotecnico"
        Me.activotecnico.Size = New System.Drawing.Size(76, 22)
        Me.activotecnico.TabIndex = 82
        Me.activotecnico.Text = "Activo"
        Me.activotecnico.UseVisualStyleBackColor = True
        '
        'LabelNombreTecnico
        '
        Me.LabelNombreTecnico.AutoSize = True
        Me.LabelNombreTecnico.Location = New System.Drawing.Point(19, 75)
        Me.LabelNombreTecnico.Name = "LabelNombreTecnico"
        Me.LabelNombreTecnico.Size = New System.Drawing.Size(71, 18)
        Me.LabelNombreTecnico.TabIndex = 80
        Me.LabelNombreTecnico.Text = "Nombre"
        '
        'LabelApellidoTecnico
        '
        Me.LabelApellidoTecnico.AutoSize = True
        Me.LabelApellidoTecnico.Location = New System.Drawing.Point(19, 109)
        Me.LabelApellidoTecnico.Name = "LabelApellidoTecnico"
        Me.LabelApellidoTecnico.Size = New System.Drawing.Size(72, 18)
        Me.LabelApellidoTecnico.TabIndex = 79
        Me.LabelApellidoTecnico.Text = "Apellido"
        '
        'EditarTecnico
        '
        Me.EditarTecnico.Location = New System.Drawing.Point(296, 146)
        Me.EditarTecnico.Name = "EditarTecnico"
        Me.EditarTecnico.Size = New System.Drawing.Size(117, 32)
        Me.EditarTecnico.TabIndex = 77
        Me.EditarTecnico.Text = "Editar "
        Me.EditarTecnico.UseVisualStyleBackColor = True
        '
        'EliminarTecnico
        '
        Me.EliminarTecnico.Location = New System.Drawing.Point(296, 108)
        Me.EliminarTecnico.Name = "EliminarTecnico"
        Me.EliminarTecnico.Size = New System.Drawing.Size(117, 32)
        Me.EliminarTecnico.TabIndex = 76
        Me.EliminarTecnico.Text = "Eliminar"
        Me.EliminarTecnico.UseVisualStyleBackColor = True
        '
        'InsertarTecnico
        '
        Me.InsertarTecnico.Location = New System.Drawing.Point(296, 70)
        Me.InsertarTecnico.Name = "InsertarTecnico"
        Me.InsertarTecnico.Size = New System.Drawing.Size(117, 32)
        Me.InsertarTecnico.TabIndex = 75
        Me.InsertarTecnico.Text = "Nuevo"
        Me.InsertarTecnico.UseVisualStyleBackColor = True
        '
        'botonBuscarTecnico
        '
        Me.botonBuscarTecnico.Location = New System.Drawing.Point(296, 34)
        Me.botonBuscarTecnico.Name = "botonBuscarTecnico"
        Me.botonBuscarTecnico.Size = New System.Drawing.Size(117, 32)
        Me.botonBuscarTecnico.TabIndex = 74
        Me.botonBuscarTecnico.Text = "Buscar Tecnico"
        Me.botonBuscarTecnico.UseVisualStyleBackColor = True
        '
        'DGVtecnicos
        '
        Me.DGVtecnicos.AllowUserToAddRows = False
        Me.DGVtecnicos.AllowUserToDeleteRows = False
        Me.DGVtecnicos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVtecnicos.Location = New System.Drawing.Point(19, 185)
        Me.DGVtecnicos.Name = "DGVtecnicos"
        Me.DGVtecnicos.ReadOnly = True
        Me.DGVtecnicos.RowHeadersVisible = False
        Me.DGVtecnicos.RowHeadersWidth = 4
        Me.DGVtecnicos.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.DGVtecnicos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGVtecnicos.Size = New System.Drawing.Size(600, 143)
        Me.DGVtecnicos.TabIndex = 71
        '
        'TirasECG
        '
        Me.TirasECG.AutoScroll = True
        Me.TirasECG.Controls.Add(Me.iconoImprimirPDF)
        Me.TirasECG.Controls.Add(Me.iconoGuardarExamen)
        Me.TirasECG.Controls.Add(Me.botonCancelarEdicionEvento)
        Me.TirasECG.Controls.Add(Me.botonEditarEvento)
        Me.TirasECG.Controls.Add(Me.botonanteriorConclusion)
        Me.TirasECG.Controls.Add(Me.botonBorrarEventos)
        Me.TirasECG.Controls.Add(Me.PictureBoxsalirTiras)
        Me.TirasECG.Controls.Add(Me.LabelConclusion)
        Me.TirasECG.Controls.Add(Me.cbxConclusiones)
        Me.TirasECG.Controls.Add(Me.conclusiontext)
        Me.TirasECG.Controls.Add(Me.PictureBox5)
        Me.TirasECG.Controls.Add(Me.LabeltituloTiras)
        Me.TirasECG.Controls.Add(Me.ListBoxeventos)
        Me.TirasECG.Controls.Add(Me.ChartEventos)
        Me.TirasECG.Location = New System.Drawing.Point(4, 27)
        Me.TirasECG.Name = "TirasECG"
        Me.TirasECG.Size = New System.Drawing.Size(2017, 1164)
        Me.TirasECG.TabIndex = 6
        Me.TirasECG.Text = "    Tiras de ECG    "
        Me.TirasECG.UseVisualStyleBackColor = True
        '
        'iconoImprimirPDF
        '
        Me.iconoImprimirPDF.BackColor = System.Drawing.Color.Transparent
        Me.iconoImprimirPDF.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.iconoImprimirPDF.Image = CType(resources.GetObject("iconoImprimirPDF.Image"), System.Drawing.Image)
        Me.iconoImprimirPDF.Location = New System.Drawing.Point(1148, 441)
        Me.iconoImprimirPDF.Name = "iconoImprimirPDF"
        Me.iconoImprimirPDF.Size = New System.Drawing.Size(71, 64)
        Me.iconoImprimirPDF.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.iconoImprimirPDF.TabIndex = 129
        Me.iconoImprimirPDF.TabStop = False
        Me.iconoImprimirPDF.Visible = False
        '
        'iconoGuardarExamen
        '
        Me.iconoGuardarExamen.BackColor = System.Drawing.Color.Transparent
        Me.iconoGuardarExamen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.iconoGuardarExamen.Image = CType(resources.GetObject("iconoGuardarExamen.Image"), System.Drawing.Image)
        Me.iconoGuardarExamen.Location = New System.Drawing.Point(1148, 353)
        Me.iconoGuardarExamen.Name = "iconoGuardarExamen"
        Me.iconoGuardarExamen.Size = New System.Drawing.Size(71, 64)
        Me.iconoGuardarExamen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.iconoGuardarExamen.TabIndex = 128
        Me.iconoGuardarExamen.TabStop = False
        Me.iconoGuardarExamen.Visible = False
        '
        'botonCancelarEdicionEvento
        '
        Me.botonCancelarEdicionEvento.Enabled = False
        Me.botonCancelarEdicionEvento.Font = New System.Drawing.Font("Arial Rounded MT Bold", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.botonCancelarEdicionEvento.Location = New System.Drawing.Point(309, 353)
        Me.botonCancelarEdicionEvento.Name = "botonCancelarEdicionEvento"
        Me.botonCancelarEdicionEvento.Size = New System.Drawing.Size(139, 81)
        Me.botonCancelarEdicionEvento.TabIndex = 127
        Me.botonCancelarEdicionEvento.Text = "Cancelar Edición"
        Me.botonCancelarEdicionEvento.UseVisualStyleBackColor = True
        Me.botonCancelarEdicionEvento.Visible = False
        '
        'botonEditarEvento
        '
        Me.botonEditarEvento.Enabled = False
        Me.botonEditarEvento.Font = New System.Drawing.Font("Arial Rounded MT Bold", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.botonEditarEvento.Location = New System.Drawing.Point(309, 263)
        Me.botonEditarEvento.Name = "botonEditarEvento"
        Me.botonEditarEvento.Size = New System.Drawing.Size(139, 81)
        Me.botonEditarEvento.TabIndex = 126
        Me.botonEditarEvento.Text = "Editar Evento"
        Me.botonEditarEvento.UseVisualStyleBackColor = True
        '
        'botonanteriorConclusion
        '
        Me.botonanteriorConclusion.BackColor = System.Drawing.Color.Transparent
        Me.botonanteriorConclusion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.botonanteriorConclusion.Image = CType(resources.GetObject("botonanteriorConclusion.Image"), System.Drawing.Image)
        Me.botonanteriorConclusion.Location = New System.Drawing.Point(905, 520)
        Me.botonanteriorConclusion.Name = "botonanteriorConclusion"
        Me.botonanteriorConclusion.Size = New System.Drawing.Size(101, 124)
        Me.botonanteriorConclusion.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.botonanteriorConclusion.TabIndex = 125
        Me.botonanteriorConclusion.TabStop = False
        '
        'botonBorrarEventos
        '
        Me.botonBorrarEventos.Font = New System.Drawing.Font("Arial Rounded MT Bold", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.botonBorrarEventos.Location = New System.Drawing.Point(309, 167)
        Me.botonBorrarEventos.Name = "botonBorrarEventos"
        Me.botonBorrarEventos.Size = New System.Drawing.Size(139, 81)
        Me.botonBorrarEventos.TabIndex = 124
        Me.botonBorrarEventos.Text = "Borrar Evento"
        Me.botonBorrarEventos.UseVisualStyleBackColor = True
        '
        'PictureBoxsalirTiras
        '
        Me.PictureBoxsalirTiras.BackColor = System.Drawing.Color.Transparent
        Me.PictureBoxsalirTiras.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBoxsalirTiras.Image = CType(resources.GetObject("PictureBoxsalirTiras.Image"), System.Drawing.Image)
        Me.PictureBoxsalirTiras.Location = New System.Drawing.Point(1148, 245)
        Me.PictureBoxsalirTiras.Name = "PictureBoxsalirTiras"
        Me.PictureBoxsalirTiras.Size = New System.Drawing.Size(71, 64)
        Me.PictureBoxsalirTiras.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBoxsalirTiras.TabIndex = 123
        Me.PictureBoxsalirTiras.TabStop = False
        '
        'LabelConclusion
        '
        Me.LabelConclusion.AutoSize = True
        Me.LabelConclusion.Font = New System.Drawing.Font("Arial Rounded MT Bold", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelConclusion.Location = New System.Drawing.Point(504, 10)
        Me.LabelConclusion.Name = "LabelConclusion"
        Me.LabelConclusion.Size = New System.Drawing.Size(202, 32)
        Me.LabelConclusion.TabIndex = 122
        Me.LabelConclusion.Text = "CONCLUSIÓN"
        '
        'cbxConclusiones
        '
        Me.cbxConclusiones.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxConclusiones.FormattingEnabled = True
        Me.cbxConclusiones.Location = New System.Drawing.Point(509, 295)
        Me.cbxConclusiones.Name = "cbxConclusiones"
        Me.cbxConclusiones.Size = New System.Drawing.Size(229, 26)
        Me.cbxConclusiones.TabIndex = 121
        '
        'conclusiontext
        '
        Me.conclusiontext.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.conclusiontext.Location = New System.Drawing.Point(523, 33)
        Me.conclusiontext.MaxLength = 499
        Me.conclusiontext.Multiline = True
        Me.conclusiontext.Name = "conclusiontext"
        Me.conclusiontext.Size = New System.Drawing.Size(536, 242)
        Me.conclusiontext.TabIndex = 120
        '
        'PictureBox5
        '
        Me.PictureBox5.BackgroundImage = CType(resources.GetObject("PictureBox5.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox5.Location = New System.Drawing.Point(58, 245)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(132, 149)
        Me.PictureBox5.TabIndex = 117
        Me.PictureBox5.TabStop = False
        '
        'LabeltituloTiras
        '
        Me.LabeltituloTiras.AutoSize = True
        Me.LabeltituloTiras.Font = New System.Drawing.Font("Arial Rounded MT Bold", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabeltituloTiras.Location = New System.Drawing.Point(25, 10)
        Me.LabeltituloTiras.Name = "LabeltituloTiras"
        Me.LabeltituloTiras.Size = New System.Drawing.Size(207, 32)
        Me.LabeltituloTiras.TabIndex = 41
        Me.LabeltituloTiras.Text = "TIRAS DE ECG"
        '
        'ListBoxeventos
        '
        Me.ListBoxeventos.Font = New System.Drawing.Font("Arial Rounded MT Bold", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListBoxeventos.FormattingEnabled = True
        Me.ListBoxeventos.ItemHeight = 28
        Me.ListBoxeventos.Location = New System.Drawing.Point(31, 46)
        Me.ListBoxeventos.Name = "ListBoxeventos"
        Me.ListBoxeventos.Size = New System.Drawing.Size(443, 144)
        Me.ListBoxeventos.TabIndex = 17
        '
        'ChartEventos
        '
        Me.ChartEventos.BackColor = System.Drawing.Color.Transparent
        Me.ChartEventos.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.VerticalCenter
        Me.ChartEventos.BackImageTransparentColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.ChartEventos.BorderlineColor = System.Drawing.Color.Black
        Me.ChartEventos.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid
        Me.ChartEventos.BorderSkin.BackColor = System.Drawing.Color.LightSkyBlue
        Me.ChartEventos.BorderSkin.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.Center
        ChartArea1.AxisX.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount
        ChartArea1.AxisX.MajorGrid.Enabled = False
        ChartArea1.AxisX.ScaleView.MinSizeType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number
        ChartArea1.AxisX.ScaleView.Size = 250.0R
        ChartArea1.AxisX.ScaleView.Zoomable = False
        ChartArea1.AxisX.ScrollBar.BackColor = System.Drawing.Color.LightGray
        ChartArea1.AxisX.ScrollBar.ButtonColor = System.Drawing.Color.White
        ChartArea1.AxisX.ScrollBar.ButtonStyle = System.Windows.Forms.DataVisualization.Charting.ScrollBarButtonStyles.SmallScroll
        ChartArea1.AxisX.ScrollBar.IsPositionedInside = False
        ChartArea1.AxisX.ScrollBar.LineColor = System.Drawing.Color.Gray
        ChartArea1.AxisX.TextOrientation = System.Windows.Forms.DataVisualization.Charting.TextOrientation.Horizontal
        ChartArea1.AxisX.Title = "Tiempo [S]"
        ChartArea1.AxisX.TitleFont = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ChartArea1.AxisY.LabelStyle.Enabled = False
        ChartArea1.AxisY.MajorGrid.Enabled = False
        ChartArea1.CursorX.AutoScroll = False
        ChartArea1.CursorX.LineColor = System.Drawing.Color.Transparent
        ChartArea1.Name = "ChartArea1"
        Me.ChartEventos.ChartAreas.Add(ChartArea1)
        Me.ChartEventos.Location = New System.Drawing.Point(31, 254)
        Me.ChartEventos.Name = "ChartEventos"
        Me.ChartEventos.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None
        Series1.ChartArea = "ChartArea1"
        Series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line
        Series1.IsXValueIndexed = True
        Series1.Name = "ECG"
        Series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.[String]
        Me.ChartEventos.Series.Add(Series1)
        Me.ChartEventos.Size = New System.Drawing.Size(860, 180)
        Me.ChartEventos.TabIndex = 13
        Me.ChartEventos.Text = "ChartEventos"
        '
        'Grafico
        '
        Me.Grafico.Controls.Add(Me.botonanteriorGrafico)
        Me.Grafico.Controls.Add(Me.botonsiguienteGrafico)
        Me.Grafico.Controls.Add(Me.PictureBoxsalirgrafico)
        Me.Grafico.Controls.Add(Me.PictureBox4)
        Me.Grafico.Controls.Add(Me.Chart1)
        Me.Grafico.Location = New System.Drawing.Point(4, 27)
        Me.Grafico.Name = "Grafico"
        Me.Grafico.Padding = New System.Windows.Forms.Padding(3)
        Me.Grafico.Size = New System.Drawing.Size(2017, 1164)
        Me.Grafico.TabIndex = 4
        Me.Grafico.Text = "    Gráfico    "
        Me.Grafico.UseVisualStyleBackColor = True
        '
        'botonanteriorGrafico
        '
        Me.botonanteriorGrafico.BackColor = System.Drawing.Color.Transparent
        Me.botonanteriorGrafico.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.botonanteriorGrafico.Image = CType(resources.GetObject("botonanteriorGrafico.Image"), System.Drawing.Image)
        Me.botonanteriorGrafico.Location = New System.Drawing.Point(1120, 367)
        Me.botonanteriorGrafico.Name = "botonanteriorGrafico"
        Me.botonanteriorGrafico.Size = New System.Drawing.Size(101, 124)
        Me.botonanteriorGrafico.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.botonanteriorGrafico.TabIndex = 123
        Me.botonanteriorGrafico.TabStop = False
        '
        'botonsiguienteGrafico
        '
        Me.botonsiguienteGrafico.BackColor = System.Drawing.Color.Transparent
        Me.botonsiguienteGrafico.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.botonsiguienteGrafico.Image = CType(resources.GetObject("botonsiguienteGrafico.Image"), System.Drawing.Image)
        Me.botonsiguienteGrafico.Location = New System.Drawing.Point(1229, 355)
        Me.botonsiguienteGrafico.Name = "botonsiguienteGrafico"
        Me.botonsiguienteGrafico.Size = New System.Drawing.Size(101, 124)
        Me.botonsiguienteGrafico.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.botonsiguienteGrafico.TabIndex = 122
        Me.botonsiguienteGrafico.TabStop = False
        '
        'PictureBoxsalirgrafico
        '
        Me.PictureBoxsalirgrafico.BackColor = System.Drawing.Color.Transparent
        Me.PictureBoxsalirgrafico.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBoxsalirgrafico.Image = CType(resources.GetObject("PictureBoxsalirgrafico.Image"), System.Drawing.Image)
        Me.PictureBoxsalirgrafico.Location = New System.Drawing.Point(1129, 293)
        Me.PictureBoxsalirgrafico.Name = "PictureBoxsalirgrafico"
        Me.PictureBoxsalirgrafico.Size = New System.Drawing.Size(71, 64)
        Me.PictureBoxsalirgrafico.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBoxsalirgrafico.TabIndex = 117
        Me.PictureBoxsalirgrafico.TabStop = False
        '
        'PictureBox4
        '
        Me.PictureBox4.BackgroundImage = CType(resources.GetObject("PictureBox4.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox4.Location = New System.Drawing.Point(834, 472)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(132, 149)
        Me.PictureBox4.TabIndex = 116
        Me.PictureBox4.TabStop = False
        '
        'Chart1
        '
        Me.Chart1.AccessibleName = "grafico"
        ChartArea2.AxisX.TitleFont = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ChartArea2.AxisY.TitleFont = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ChartArea2.AxisY2.TitleFont = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ChartArea2.Name = "Grafico"
        Me.Chart1.ChartAreas.Add(ChartArea2)
        Legend1.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Legend1.IsTextAutoFit = False
        Legend1.Name = "Legend1"
        Me.Chart1.Legends.Add(Legend1)
        Me.Chart1.Location = New System.Drawing.Point(7, 23)
        Me.Chart1.Name = "Chart1"
        Series2.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot
        Series2.BorderWidth = 6
        Series2.ChartArea = "Grafico"
        Series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line
        Series2.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Series2.Legend = "Legend1"
        Series2.Name = "PS"
        Series3.BorderWidth = 7
        Series3.ChartArea = "Grafico"
        Series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline
        Series3.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Series3.Legend = "Legend1"
        Series3.Name = "FC"
        Series3.XValueMember = "t"
        Series3.YValueMembers = "FC"
        Series4.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash
        Series4.BorderWidth = 9
        Series4.ChartArea = "Grafico"
        Series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line
        Series4.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Series4.Legend = "Legend1"
        Series4.Name = "PD"
        Series5.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot
        Series5.BorderWidth = 3
        Series5.ChartArea = "Grafico"
        Series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StepLine
        Series5.Font = New System.Drawing.Font("Arial Rounded MT Bold", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Series5.LabelBorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot
        Series5.Legend = "Legend1"
        Series5.Name = "IN"
        Series5.YAxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Secondary
        Me.Chart1.Series.Add(Series2)
        Me.Chart1.Series.Add(Series3)
        Me.Chart1.Series.Add(Series4)
        Me.Chart1.Series.Add(Series5)
        Me.Chart1.Size = New System.Drawing.Size(1293, 720)
        Me.Chart1.TabIndex = 0
        Me.Chart1.Text = "Grafico"
        Me.Chart1.TextAntiAliasingQuality = System.Windows.Forms.DataVisualization.Charting.TextAntiAliasingQuality.Normal
        Title1.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Title1.Name = "Titulo"
        Title1.Text = "TEST DE MOVIMIENTO OSCILATORIO CORPORAL"
        Me.Chart1.Titles.Add(Title1)
        '
        'Examen
        '
        Me.Examen.Controls.Add(Me.botonModificarPresion)
        Me.Examen.Controls.Add(Me.iconoRecExamen)
        Me.Examen.Controls.Add(Me.iconoPlayExamen)
        Me.Examen.Controls.Add(Me.LabelPacientedesconectadoExamen)
        Me.Examen.Controls.Add(Me.LabelConexionExamen)
        Me.Examen.Controls.Add(Me.botonanteriorExamen)
        Me.Examen.Controls.Add(Me.botonsiguienteExamen)
        Me.Examen.Controls.Add(Me.botonSiguienteEtapa)
        Me.Examen.Controls.Add(Me.botonTerminarExamen)
        Me.Examen.Controls.Add(Me.PictureBoxsalirexamen)
        Me.Examen.Controls.Add(Me.PictureBox3)
        Me.Examen.Controls.Add(Me.PictureBoxECG)
        Me.Examen.Controls.Add(Me.botonDeshacer)
        Me.Examen.Controls.Add(Me.PictureBoxfondosalir3)
        Me.Examen.Controls.Add(Me.LabelINC)
        Me.Examen.Controls.Add(Me.txtinclinacion)
        Me.Examen.Controls.Add(Me.txtdiastolica)
        Me.Examen.Controls.Add(Me.txtsistolica)
        Me.Examen.Controls.Add(Me.txtFC)
        Me.Examen.Controls.Add(Me.TextBoxTiempo)
        Me.Examen.Controls.Add(Me.botonPresion)
        Me.Examen.Controls.Add(Me.LabelPD)
        Me.Examen.Controls.Add(Me.LabelPS)
        Me.Examen.Controls.Add(Me.LabelFrecuencia)
        Me.Examen.Controls.Add(Me.LabelTiempo)
        Me.Examen.Controls.Add(Me.DatosExamen)
        Me.Examen.Location = New System.Drawing.Point(4, 27)
        Me.Examen.Name = "Examen"
        Me.Examen.Padding = New System.Windows.Forms.Padding(3)
        Me.Examen.Size = New System.Drawing.Size(2017, 1164)
        Me.Examen.TabIndex = 3
        Me.Examen.Text = "    Examen    "
        Me.Examen.UseVisualStyleBackColor = True
        '
        'botonModificarPresion
        '
        Me.botonModificarPresion.BackColor = System.Drawing.Color.Transparent
        Me.botonModificarPresion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.botonModificarPresion.Image = CType(resources.GetObject("botonModificarPresion.Image"), System.Drawing.Image)
        Me.botonModificarPresion.Location = New System.Drawing.Point(784, 182)
        Me.botonModificarPresion.Name = "botonModificarPresion"
        Me.botonModificarPresion.Size = New System.Drawing.Size(101, 124)
        Me.botonModificarPresion.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.botonModificarPresion.TabIndex = 128
        Me.botonModificarPresion.TabStop = False
        '
        'iconoRecExamen
        '
        Me.iconoRecExamen.BackColor = System.Drawing.Color.MediumBlue
        Me.iconoRecExamen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.iconoRecExamen.Image = CType(resources.GetObject("iconoRecExamen.Image"), System.Drawing.Image)
        Me.iconoRecExamen.Location = New System.Drawing.Point(529, 682)
        Me.iconoRecExamen.Name = "iconoRecExamen"
        Me.iconoRecExamen.Size = New System.Drawing.Size(71, 64)
        Me.iconoRecExamen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.iconoRecExamen.TabIndex = 127
        Me.iconoRecExamen.TabStop = False
        Me.iconoRecExamen.Tag = "Salir"
        Me.iconoRecExamen.Visible = False
        '
        'iconoPlayExamen
        '
        Me.iconoPlayExamen.BackColor = System.Drawing.Color.MediumBlue
        Me.iconoPlayExamen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.iconoPlayExamen.Image = CType(resources.GetObject("iconoPlayExamen.Image"), System.Drawing.Image)
        Me.iconoPlayExamen.Location = New System.Drawing.Point(529, 610)
        Me.iconoPlayExamen.Name = "iconoPlayExamen"
        Me.iconoPlayExamen.Size = New System.Drawing.Size(71, 64)
        Me.iconoPlayExamen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.iconoPlayExamen.TabIndex = 126
        Me.iconoPlayExamen.TabStop = False
        Me.iconoPlayExamen.Tag = "Salir"
        '
        'LabelPacientedesconectadoExamen
        '
        Me.LabelPacientedesconectadoExamen.BackColor = System.Drawing.Color.GreenYellow
        Me.LabelPacientedesconectadoExamen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LabelPacientedesconectadoExamen.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelPacientedesconectadoExamen.ForeColor = System.Drawing.SystemColors.WindowText
        Me.LabelPacientedesconectadoExamen.Location = New System.Drawing.Point(590, 578)
        Me.LabelPacientedesconectadoExamen.Margin = New System.Windows.Forms.Padding(3)
        Me.LabelPacientedesconectadoExamen.Name = "LabelPacientedesconectadoExamen"
        Me.LabelPacientedesconectadoExamen.Size = New System.Drawing.Size(242, 26)
        Me.LabelPacientedesconectadoExamen.TabIndex = 123
        Me.LabelPacientedesconectadoExamen.Text = "PACIENTE DESCONECTADO"
        Me.LabelPacientedesconectadoExamen.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.LabelPacientedesconectadoExamen.Visible = False
        '
        'LabelConexionExamen
        '
        Me.LabelConexionExamen.BackColor = System.Drawing.Color.LightSteelBlue
        Me.LabelConexionExamen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LabelConexionExamen.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelConexionExamen.Location = New System.Drawing.Point(193, 685)
        Me.LabelConexionExamen.Margin = New System.Windows.Forms.Padding(3)
        Me.LabelConexionExamen.Name = "LabelConexionExamen"
        Me.LabelConexionExamen.Size = New System.Drawing.Size(73, 26)
        Me.LabelConexionExamen.TabIndex = 122
        Me.LabelConexionExamen.Text = "ONLINE"
        Me.LabelConexionExamen.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'botonanteriorExamen
        '
        Me.botonanteriorExamen.BackColor = System.Drawing.Color.Transparent
        Me.botonanteriorExamen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.botonanteriorExamen.Image = CType(resources.GetObject("botonanteriorExamen.Image"), System.Drawing.Image)
        Me.botonanteriorExamen.Location = New System.Drawing.Point(894, 610)
        Me.botonanteriorExamen.Name = "botonanteriorExamen"
        Me.botonanteriorExamen.Size = New System.Drawing.Size(101, 124)
        Me.botonanteriorExamen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.botonanteriorExamen.TabIndex = 121
        Me.botonanteriorExamen.TabStop = False
        '
        'botonsiguienteExamen
        '
        Me.botonsiguienteExamen.BackColor = System.Drawing.Color.Transparent
        Me.botonsiguienteExamen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.botonsiguienteExamen.Image = CType(resources.GetObject("botonsiguienteExamen.Image"), System.Drawing.Image)
        Me.botonsiguienteExamen.Location = New System.Drawing.Point(1003, 598)
        Me.botonsiguienteExamen.Name = "botonsiguienteExamen"
        Me.botonsiguienteExamen.Size = New System.Drawing.Size(101, 124)
        Me.botonsiguienteExamen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.botonsiguienteExamen.TabIndex = 120
        Me.botonsiguienteExamen.TabStop = False
        '
        'botonSiguienteEtapa
        '
        Me.botonSiguienteEtapa.Font = New System.Drawing.Font("Arial Rounded MT Bold", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.botonSiguienteEtapa.Location = New System.Drawing.Point(664, 610)
        Me.botonSiguienteEtapa.Name = "botonSiguienteEtapa"
        Me.botonSiguienteEtapa.Size = New System.Drawing.Size(189, 80)
        Me.botonSiguienteEtapa.TabIndex = 118
        Me.botonSiguienteEtapa.Text = "Terminar Basal"
        Me.botonSiguienteEtapa.UseVisualStyleBackColor = True
        '
        'botonTerminarExamen
        '
        Me.botonTerminarExamen.Font = New System.Drawing.Font("Arial Rounded MT Bold", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.botonTerminarExamen.Location = New System.Drawing.Point(863, 387)
        Me.botonTerminarExamen.Name = "botonTerminarExamen"
        Me.botonTerminarExamen.Size = New System.Drawing.Size(189, 80)
        Me.botonTerminarExamen.TabIndex = 117
        Me.botonTerminarExamen.Text = "Terminar Examen"
        Me.botonTerminarExamen.UseVisualStyleBackColor = True
        '
        'PictureBoxsalirexamen
        '
        Me.PictureBoxsalirexamen.BackColor = System.Drawing.Color.Transparent
        Me.PictureBoxsalirexamen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBoxsalirexamen.Image = CType(resources.GetObject("PictureBoxsalirexamen.Image"), System.Drawing.Image)
        Me.PictureBoxsalirexamen.Location = New System.Drawing.Point(761, 492)
        Me.PictureBoxsalirexamen.Name = "PictureBoxsalirexamen"
        Me.PictureBoxsalirexamen.Size = New System.Drawing.Size(71, 64)
        Me.PictureBoxsalirexamen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBoxsalirexamen.TabIndex = 116
        Me.PictureBoxsalirexamen.TabStop = False
        '
        'PictureBox3
        '
        Me.PictureBox3.BackgroundImage = CType(resources.GetObject("PictureBox3.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox3.Location = New System.Drawing.Point(590, 379)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(132, 149)
        Me.PictureBox3.TabIndex = 115
        Me.PictureBox3.TabStop = False
        '
        'PictureBoxECG
        '
        Me.PictureBoxECG.BackColor = System.Drawing.Color.MediumBlue
        Me.PictureBoxECG.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBoxECG.Location = New System.Drawing.Point(63, 521)
        Me.PictureBoxECG.Name = "PictureBoxECG"
        Me.PictureBoxECG.Size = New System.Drawing.Size(460, 114)
        Me.PictureBoxECG.TabIndex = 111
        Me.PictureBoxECG.TabStop = False
        '
        'botonDeshacer
        '
        Me.botonDeshacer.Font = New System.Drawing.Font("Arial Rounded MT Bold", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.botonDeshacer.Location = New System.Drawing.Point(863, 301)
        Me.botonDeshacer.Name = "botonDeshacer"
        Me.botonDeshacer.Size = New System.Drawing.Size(189, 80)
        Me.botonDeshacer.TabIndex = 107
        Me.botonDeshacer.Text = "Deshacer cambios"
        Me.botonDeshacer.UseVisualStyleBackColor = True
        '
        'PictureBoxfondosalir3
        '
        Me.PictureBoxfondosalir3.BackColor = System.Drawing.Color.LightGray
        Me.PictureBoxfondosalir3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBoxfondosalir3.Location = New System.Drawing.Point(1315, 712)
        Me.PictureBoxfondosalir3.Name = "PictureBoxfondosalir3"
        Me.PictureBoxfondosalir3.Size = New System.Drawing.Size(93, 92)
        Me.PictureBoxfondosalir3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBoxfondosalir3.TabIndex = 106
        Me.PictureBoxfondosalir3.TabStop = False
        Me.PictureBoxfondosalir3.Visible = False
        '
        'LabelINC
        '
        Me.LabelINC.BackColor = System.Drawing.Color.Gainsboro
        Me.LabelINC.Font = New System.Drawing.Font("Arial Rounded MT Bold", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelINC.Location = New System.Drawing.Point(888, 481)
        Me.LabelINC.Name = "LabelINC"
        Me.LabelINC.Size = New System.Drawing.Size(164, 32)
        Me.LabelINC.TabIndex = 19
        Me.LabelINC.Text = "/ °"
        Me.LabelINC.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtinclinacion
        '
        Me.txtinclinacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtinclinacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 50.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtinclinacion.ForeColor = System.Drawing.SystemColors.MenuHighlight
        Me.txtinclinacion.Location = New System.Drawing.Point(894, 526)
        Me.txtinclinacion.Multiline = True
        Me.txtinclinacion.Name = "txtinclinacion"
        Me.txtinclinacion.ReadOnly = True
        Me.txtinclinacion.Size = New System.Drawing.Size(155, 109)
        Me.txtinclinacion.TabIndex = 18
        Me.txtinclinacion.Text = "---"
        Me.txtinclinacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtdiastolica
        '
        Me.txtdiastolica.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtdiastolica.Font = New System.Drawing.Font("Microsoft Sans Serif", 50.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtdiastolica.ForeColor = System.Drawing.SystemColors.MenuHighlight
        Me.txtdiastolica.Location = New System.Drawing.Point(1076, 596)
        Me.txtdiastolica.Multiline = True
        Me.txtdiastolica.Name = "txtdiastolica"
        Me.txtdiastolica.ReadOnly = True
        Me.txtdiastolica.Size = New System.Drawing.Size(332, 109)
        Me.txtdiastolica.TabIndex = 16
        Me.txtdiastolica.Text = "---"
        Me.txtdiastolica.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtsistolica
        '
        Me.txtsistolica.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtsistolica.Font = New System.Drawing.Font("Microsoft Sans Serif", 50.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtsistolica.ForeColor = System.Drawing.SystemColors.MenuHighlight
        Me.txtsistolica.Location = New System.Drawing.Point(1076, 418)
        Me.txtsistolica.Multiline = True
        Me.txtsistolica.Name = "txtsistolica"
        Me.txtsistolica.ReadOnly = True
        Me.txtsistolica.Size = New System.Drawing.Size(332, 109)
        Me.txtsistolica.TabIndex = 14
        Me.txtsistolica.Text = "---"
        Me.txtsistolica.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtFC
        '
        Me.txtFC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFC.Font = New System.Drawing.Font("Microsoft Sans Serif", 60.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFC.ForeColor = System.Drawing.SystemColors.MenuHighlight
        Me.txtFC.Location = New System.Drawing.Point(1076, 236)
        Me.txtFC.Multiline = True
        Me.txtFC.Name = "txtFC"
        Me.txtFC.ReadOnly = True
        Me.txtFC.Size = New System.Drawing.Size(332, 109)
        Me.txtFC.TabIndex = 12
        Me.txtFC.Text = "---"
        Me.txtFC.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBoxTiempo
        '
        Me.TextBoxTiempo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBoxTiempo.Font = New System.Drawing.Font("Microsoft Sans Serif", 60.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxTiempo.ForeColor = System.Drawing.SystemColors.MenuHighlight
        Me.TextBoxTiempo.Location = New System.Drawing.Point(1076, 50)
        Me.TextBoxTiempo.Multiline = True
        Me.TextBoxTiempo.Name = "TextBoxTiempo"
        Me.TextBoxTiempo.ReadOnly = True
        Me.TextBoxTiempo.Size = New System.Drawing.Size(332, 109)
        Me.TextBoxTiempo.TabIndex = 9
        Me.TextBoxTiempo.Text = "00:00"
        Me.TextBoxTiempo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'botonPresion
        '
        Me.botonPresion.Enabled = False
        Me.botonPresion.Font = New System.Drawing.Font("Arial Rounded MT Bold", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.botonPresion.Location = New System.Drawing.Point(863, 96)
        Me.botonPresion.Name = "botonPresion"
        Me.botonPresion.Size = New System.Drawing.Size(189, 80)
        Me.botonPresion.TabIndex = 17
        Me.botonPresion.Text = "Modificar Presión"
        Me.botonPresion.UseVisualStyleBackColor = True
        '
        'LabelPD
        '
        Me.LabelPD.BackColor = System.Drawing.Color.Gainsboro
        Me.LabelPD.Font = New System.Drawing.Font("Arial Rounded MT Bold", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelPD.Location = New System.Drawing.Point(1070, 541)
        Me.LabelPD.Name = "LabelPD"
        Me.LabelPD.Size = New System.Drawing.Size(260, 32)
        Me.LabelPD.TabIndex = 15
        Me.LabelPD.Text = "PD [mmHg]"
        Me.LabelPD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LabelPS
        '
        Me.LabelPS.BackColor = System.Drawing.Color.Gainsboro
        Me.LabelPS.Font = New System.Drawing.Font("Arial Rounded MT Bold", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelPS.Location = New System.Drawing.Point(1070, 362)
        Me.LabelPS.Name = "LabelPS"
        Me.LabelPS.Size = New System.Drawing.Size(242, 32)
        Me.LabelPS.TabIndex = 13
        Me.LabelPS.Text = "PS [mmHg]"
        Me.LabelPS.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LabelFrecuencia
        '
        Me.LabelFrecuencia.BackColor = System.Drawing.Color.LightSteelBlue
        Me.LabelFrecuencia.Font = New System.Drawing.Font("Arial Rounded MT Bold", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelFrecuencia.Location = New System.Drawing.Point(1070, 180)
        Me.LabelFrecuencia.Name = "LabelFrecuencia"
        Me.LabelFrecuencia.Size = New System.Drawing.Size(297, 32)
        Me.LabelFrecuencia.TabIndex = 11
        Me.LabelFrecuencia.Text = "FC [LPM]"
        Me.LabelFrecuencia.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LabelTiempo
        '
        Me.LabelTiempo.BackColor = System.Drawing.Color.AliceBlue
        Me.LabelTiempo.Font = New System.Drawing.Font("Arial Rounded MT Bold", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelTiempo.Location = New System.Drawing.Point(1070, 3)
        Me.LabelTiempo.Name = "LabelTiempo"
        Me.LabelTiempo.Size = New System.Drawing.Size(120, 32)
        Me.LabelTiempo.TabIndex = 10
        Me.LabelTiempo.Text = "Basal:"
        Me.LabelTiempo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'DatosExamen
        '
        Me.DatosExamen.AllowUserToAddRows = False
        Me.DatosExamen.AllowUserToDeleteRows = False
        Me.DatosExamen.AllowUserToResizeColumns = False
        Me.DatosExamen.AllowUserToResizeRows = False
        Me.DatosExamen.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader
        Me.DatosExamen.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders
        Me.DatosExamen.BackgroundColor = System.Drawing.SystemColors.ButtonFace
        Me.DatosExamen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DatosExamen.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColumnaMinutos, Me.ColumnaSintomas, Me.ColumnaFC, Me.ColumnPS, Me.ColumnPD})
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DatosExamen.DefaultCellStyle = DataGridViewCellStyle1
        Me.DatosExamen.Location = New System.Drawing.Point(0, 0)
        Me.DatosExamen.Name = "DatosExamen"
        Me.DatosExamen.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.DatosExamen.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.DatosExamen.Size = New System.Drawing.Size(778, 459)
        Me.DatosExamen.TabIndex = 2
        '
        'ColumnaMinutos
        '
        Me.ColumnaMinutos.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.ColumnaMinutos.HeaderText = "Minutos"
        Me.ColumnaMinutos.Name = "ColumnaMinutos"
        Me.ColumnaMinutos.Width = 90
        '
        'ColumnaSintomas
        '
        Me.ColumnaSintomas.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.ColumnaSintomas.HeaderText = "Síntomas"
        Me.ColumnaSintomas.Name = "ColumnaSintomas"
        Me.ColumnaSintomas.Width = 107
        '
        'ColumnaFC
        '
        Me.ColumnaFC.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.ColumnaFC.HeaderText = "Frec.Card. (LPM)"
        Me.ColumnaFC.Name = "ColumnaFC"
        Me.ColumnaFC.Width = 180
        '
        'ColumnPS
        '
        Me.ColumnPS.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.ColumnPS.HeaderText = "P. Sist. (mmHg)"
        Me.ColumnPS.Name = "ColumnPS"
        Me.ColumnPS.Width = 180
        '
        'ColumnPD
        '
        Me.ColumnPD.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.ColumnPD.HeaderText = "P. Diast. (mmHg)"
        Me.ColumnPD.Name = "ColumnPD"
        Me.ColumnPD.Width = 180
        '
        'TabPreguntas
        '
        Me.TabPreguntas.Controls.Add(Me.iconoRecProtocolos)
        Me.TabPreguntas.Controls.Add(Me.iconoPlayProtocolos)
        Me.TabPreguntas.Controls.Add(Me.LabelPacientedesconectadoprotocolo)
        Me.TabPreguntas.Controls.Add(Me.LabelConexionProtocolo)
        Me.TabPreguntas.Controls.Add(Me.botonAnteriorProtocolo)
        Me.TabPreguntas.Controls.Add(Me.PictureBox2)
        Me.TabPreguntas.Controls.Add(Me.tickprotocolo)
        Me.TabPreguntas.Controls.Add(Me.PictureBoxSalirProtocolo)
        Me.TabPreguntas.Controls.Add(Me.PictureBoxECGProtocolo)
        Me.TabPreguntas.Controls.Add(Me.TextINTE9)
        Me.TabPreguntas.Controls.Add(Me.TextProtocolo)
        Me.TabPreguntas.Controls.Add(Me.TextINTE3)
        Me.TabPreguntas.Controls.Add(Me.DGVprotocolo)
        Me.TabPreguntas.Controls.Add(Me.botonsiguienteprotocolo)
        Me.TabPreguntas.Controls.Add(Me.Labelpreg9)
        Me.TabPreguntas.Controls.Add(Me.ComboBoxProtocolo)
        Me.TabPreguntas.Controls.Add(Me.LabeltituloPROTO)
        Me.TabPreguntas.Controls.Add(Me.Panel10)
        Me.TabPreguntas.Controls.Add(Me.Panel9)
        Me.TabPreguntas.Controls.Add(Me.Panel8)
        Me.TabPreguntas.Controls.Add(Me.Panel7)
        Me.TabPreguntas.Controls.Add(Me.Panel6)
        Me.TabPreguntas.Controls.Add(Me.Panel5)
        Me.TabPreguntas.Controls.Add(Me.Panel4)
        Me.TabPreguntas.Controls.Add(Me.Labelpreg8)
        Me.TabPreguntas.Controls.Add(Me.Labelpreg7)
        Me.TabPreguntas.Controls.Add(Me.Labelpreg6)
        Me.TabPreguntas.Controls.Add(Me.Labelpreg5)
        Me.TabPreguntas.Controls.Add(Me.Labelpreg4)
        Me.TabPreguntas.Controls.Add(Me.Labelpreg3)
        Me.TabPreguntas.Controls.Add(Me.Labelpreg2)
        Me.TabPreguntas.Controls.Add(Me.Labelpreg1)
        Me.TabPreguntas.Controls.Add(Me.LabeltituloINTE)
        Me.TabPreguntas.Location = New System.Drawing.Point(4, 27)
        Me.TabPreguntas.Name = "TabPreguntas"
        Me.TabPreguntas.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPreguntas.Size = New System.Drawing.Size(2017, 1164)
        Me.TabPreguntas.TabIndex = 1
        Me.TabPreguntas.Text = "    Interrogatorio y Protocolo    "
        Me.TabPreguntas.UseVisualStyleBackColor = True
        '
        'iconoRecProtocolos
        '
        Me.iconoRecProtocolos.BackColor = System.Drawing.Color.MediumBlue
        Me.iconoRecProtocolos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.iconoRecProtocolos.Image = CType(resources.GetObject("iconoRecProtocolos.Image"), System.Drawing.Image)
        Me.iconoRecProtocolos.Location = New System.Drawing.Point(1214, 517)
        Me.iconoRecProtocolos.Name = "iconoRecProtocolos"
        Me.iconoRecProtocolos.Size = New System.Drawing.Size(71, 64)
        Me.iconoRecProtocolos.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.iconoRecProtocolos.TabIndex = 125
        Me.iconoRecProtocolos.TabStop = False
        Me.iconoRecProtocolos.Tag = "Salir"
        Me.iconoRecProtocolos.Visible = False
        '
        'iconoPlayProtocolos
        '
        Me.iconoPlayProtocolos.BackColor = System.Drawing.Color.MediumBlue
        Me.iconoPlayProtocolos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.iconoPlayProtocolos.Image = CType(resources.GetObject("iconoPlayProtocolos.Image"), System.Drawing.Image)
        Me.iconoPlayProtocolos.Location = New System.Drawing.Point(1214, 445)
        Me.iconoPlayProtocolos.Name = "iconoPlayProtocolos"
        Me.iconoPlayProtocolos.Size = New System.Drawing.Size(71, 64)
        Me.iconoPlayProtocolos.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.iconoPlayProtocolos.TabIndex = 124
        Me.iconoPlayProtocolos.TabStop = False
        Me.iconoPlayProtocolos.Tag = "Salir"
        '
        'LabelPacientedesconectadoprotocolo
        '
        Me.LabelPacientedesconectadoprotocolo.BackColor = System.Drawing.Color.GreenYellow
        Me.LabelPacientedesconectadoprotocolo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LabelPacientedesconectadoprotocolo.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelPacientedesconectadoprotocolo.ForeColor = System.Drawing.SystemColors.WindowText
        Me.LabelPacientedesconectadoprotocolo.Location = New System.Drawing.Point(834, 569)
        Me.LabelPacientedesconectadoprotocolo.Margin = New System.Windows.Forms.Padding(3)
        Me.LabelPacientedesconectadoprotocolo.Name = "LabelPacientedesconectadoprotocolo"
        Me.LabelPacientedesconectadoprotocolo.Size = New System.Drawing.Size(242, 26)
        Me.LabelPacientedesconectadoprotocolo.TabIndex = 122
        Me.LabelPacientedesconectadoprotocolo.Text = "PACIENTE DESCONECTADO"
        Me.LabelPacientedesconectadoprotocolo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.LabelPacientedesconectadoprotocolo.Visible = False
        '
        'LabelConexionProtocolo
        '
        Me.LabelConexionProtocolo.BackColor = System.Drawing.Color.LightSteelBlue
        Me.LabelConexionProtocolo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LabelConexionProtocolo.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelConexionProtocolo.Location = New System.Drawing.Point(427, 680)
        Me.LabelConexionProtocolo.Margin = New System.Windows.Forms.Padding(3)
        Me.LabelConexionProtocolo.Name = "LabelConexionProtocolo"
        Me.LabelConexionProtocolo.Size = New System.Drawing.Size(73, 26)
        Me.LabelConexionProtocolo.TabIndex = 121
        Me.LabelConexionProtocolo.Text = "ONLINE"
        Me.LabelConexionProtocolo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'botonAnteriorProtocolo
        '
        Me.botonAnteriorProtocolo.BackColor = System.Drawing.Color.Transparent
        Me.botonAnteriorProtocolo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.botonAnteriorProtocolo.Image = CType(resources.GetObject("botonAnteriorProtocolo.Image"), System.Drawing.Image)
        Me.botonAnteriorProtocolo.Location = New System.Drawing.Point(711, 519)
        Me.botonAnteriorProtocolo.Name = "botonAnteriorProtocolo"
        Me.botonAnteriorProtocolo.Size = New System.Drawing.Size(101, 124)
        Me.botonAnteriorProtocolo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.botonAnteriorProtocolo.TabIndex = 115
        Me.botonAnteriorProtocolo.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.BackgroundImage = CType(resources.GetObject("PictureBox2.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox2.Location = New System.Drawing.Point(886, 331)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(272, 222)
        Me.PictureBox2.TabIndex = 114
        Me.PictureBox2.TabStop = False
        '
        'tickprotocolo
        '
        Me.tickprotocolo.BackColor = System.Drawing.Color.Transparent
        Me.tickprotocolo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.tickprotocolo.Image = CType(resources.GetObject("tickprotocolo.Image"), System.Drawing.Image)
        Me.tickprotocolo.Location = New System.Drawing.Point(822, 572)
        Me.tickprotocolo.Name = "tickprotocolo"
        Me.tickprotocolo.Size = New System.Drawing.Size(255, 178)
        Me.tickprotocolo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.tickprotocolo.TabIndex = 99
        Me.tickprotocolo.TabStop = False
        Me.tickprotocolo.Visible = False
        '
        'PictureBoxSalirProtocolo
        '
        Me.PictureBoxSalirProtocolo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBoxSalirProtocolo.Enabled = False
        Me.PictureBoxSalirProtocolo.Image = CType(resources.GetObject("PictureBoxSalirProtocolo.Image"), System.Drawing.Image)
        Me.PictureBoxSalirProtocolo.Location = New System.Drawing.Point(748, 385)
        Me.PictureBoxSalirProtocolo.Name = "PictureBoxSalirProtocolo"
        Me.PictureBoxSalirProtocolo.Size = New System.Drawing.Size(71, 64)
        Me.PictureBoxSalirProtocolo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBoxSalirProtocolo.TabIndex = 103
        Me.PictureBoxSalirProtocolo.TabStop = False
        '
        'PictureBoxECGProtocolo
        '
        Me.PictureBoxECGProtocolo.BackColor = System.Drawing.Color.MediumBlue
        Me.PictureBoxECGProtocolo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBoxECGProtocolo.Location = New System.Drawing.Point(22, 648)
        Me.PictureBoxECGProtocolo.Name = "PictureBoxECGProtocolo"
        Me.PictureBoxECGProtocolo.Size = New System.Drawing.Size(214, 44)
        Me.PictureBoxECGProtocolo.TabIndex = 113
        Me.PictureBoxECGProtocolo.TabStop = False
        '
        'TextINTE9
        '
        Me.TextINTE9.Enabled = False
        Me.TextINTE9.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextINTE9.Location = New System.Drawing.Point(22, 578)
        Me.TextINTE9.Multiline = True
        Me.TextINTE9.Name = "TextINTE9"
        Me.TextINTE9.Size = New System.Drawing.Size(400, 36)
        Me.TextINTE9.TabIndex = 8
        '
        'TextProtocolo
        '
        Me.TextProtocolo.Enabled = False
        Me.TextProtocolo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextProtocolo.Location = New System.Drawing.Point(702, 109)
        Me.TextProtocolo.MaxLength = 349
        Me.TextProtocolo.Multiline = True
        Me.TextProtocolo.Name = "TextProtocolo"
        Me.TextProtocolo.ReadOnly = True
        Me.TextProtocolo.Size = New System.Drawing.Size(343, 325)
        Me.TextProtocolo.TabIndex = 10
        '
        'TextINTE3
        '
        Me.TextINTE3.Enabled = False
        Me.TextINTE3.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextINTE3.Location = New System.Drawing.Point(162, 172)
        Me.TextINTE3.Multiline = True
        Me.TextINTE3.Name = "TextINTE3"
        Me.TextINTE3.Size = New System.Drawing.Size(400, 36)
        Me.TextINTE3.TabIndex = 2
        '
        'DGVprotocolo
        '
        Me.DGVprotocolo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVprotocolo.Enabled = False
        Me.DGVprotocolo.Location = New System.Drawing.Point(25, 728)
        Me.DGVprotocolo.Name = "DGVprotocolo"
        Me.DGVprotocolo.Size = New System.Drawing.Size(101, 28)
        Me.DGVprotocolo.TabIndex = 105
        Me.DGVprotocolo.Visible = False
        '
        'botonsiguienteprotocolo
        '
        Me.botonsiguienteprotocolo.BackColor = System.Drawing.Color.Transparent
        Me.botonsiguienteprotocolo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.botonsiguienteprotocolo.Enabled = False
        Me.botonsiguienteprotocolo.Image = CType(resources.GetObject("botonsiguienteprotocolo.Image"), System.Drawing.Image)
        Me.botonsiguienteprotocolo.Location = New System.Drawing.Point(1124, 625)
        Me.botonsiguienteprotocolo.Name = "botonsiguienteprotocolo"
        Me.botonsiguienteprotocolo.Size = New System.Drawing.Size(101, 124)
        Me.botonsiguienteprotocolo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.botonsiguienteprotocolo.TabIndex = 98
        Me.botonsiguienteprotocolo.TabStop = False
        '
        'Labelpreg9
        '
        Me.Labelpreg9.AutoSize = True
        Me.Labelpreg9.Location = New System.Drawing.Point(24, 551)
        Me.Labelpreg9.Name = "Labelpreg9"
        Me.Labelpreg9.Size = New System.Drawing.Size(96, 18)
        Me.Labelpreg9.TabIndex = 88
        Me.Labelpreg9.Text = "9-¿Cuáles?"
        '
        'ComboBoxProtocolo
        '
        Me.ComboBoxProtocolo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxProtocolo.Enabled = False
        Me.ComboBoxProtocolo.FormattingEnabled = True
        Me.ComboBoxProtocolo.Items.AddRange(New Object() {"1-Estándar", "2-Intensificado"})
        Me.ComboBoxProtocolo.Location = New System.Drawing.Point(711, 71)
        Me.ComboBoxProtocolo.Name = "ComboBoxProtocolo"
        Me.ComboBoxProtocolo.Size = New System.Drawing.Size(121, 26)
        Me.ComboBoxProtocolo.TabIndex = 9
        '
        'LabeltituloPROTO
        '
        Me.LabeltituloPROTO.AutoSize = True
        Me.LabeltituloPROTO.Font = New System.Drawing.Font("Arial Rounded MT Bold", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabeltituloPROTO.Location = New System.Drawing.Point(696, 16)
        Me.LabeltituloPROTO.Name = "LabeltituloPROTO"
        Me.LabeltituloPROTO.Size = New System.Drawing.Size(189, 32)
        Me.LabeltituloPROTO.TabIndex = 85
        Me.LabeltituloPROTO.Text = "PROTOCOLO"
        '
        'Panel10
        '
        Me.Panel10.Controls.Add(Me.INTE8SI)
        Me.Panel10.Controls.Add(Me.INTE8NO)
        Me.Panel10.Enabled = False
        Me.Panel10.Location = New System.Drawing.Point(437, 468)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(135, 41)
        Me.Panel10.TabIndex = 7
        '
        'INTE8SI
        '
        Me.INTE8SI.Appearance = System.Windows.Forms.Appearance.Button
        Me.INTE8SI.AutoSize = True
        Me.INTE8SI.Location = New System.Drawing.Point(3, 5)
        Me.INTE8SI.Name = "INTE8SI"
        Me.INTE8SI.Size = New System.Drawing.Size(33, 28)
        Me.INTE8SI.TabIndex = 0
        Me.INTE8SI.TabStop = True
        Me.INTE8SI.Text = "Sí"
        Me.INTE8SI.UseVisualStyleBackColor = True
        '
        'INTE8NO
        '
        Me.INTE8NO.Appearance = System.Windows.Forms.Appearance.Button
        Me.INTE8NO.AutoSize = True
        Me.INTE8NO.Location = New System.Drawing.Point(51, 5)
        Me.INTE8NO.Name = "INTE8NO"
        Me.INTE8NO.Size = New System.Drawing.Size(40, 28)
        Me.INTE8NO.TabIndex = 1
        Me.INTE8NO.TabStop = True
        Me.INTE8NO.Text = "No"
        Me.INTE8NO.UseVisualStyleBackColor = True
        '
        'Panel9
        '
        Me.Panel9.Controls.Add(Me.INTE7SI)
        Me.Panel9.Controls.Add(Me.INTE7NO)
        Me.Panel9.Enabled = False
        Me.Panel9.Location = New System.Drawing.Point(401, 406)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(136, 39)
        Me.Panel9.TabIndex = 6
        '
        'INTE7SI
        '
        Me.INTE7SI.Appearance = System.Windows.Forms.Appearance.Button
        Me.INTE7SI.AutoSize = True
        Me.INTE7SI.Location = New System.Drawing.Point(3, 5)
        Me.INTE7SI.Name = "INTE7SI"
        Me.INTE7SI.Size = New System.Drawing.Size(33, 28)
        Me.INTE7SI.TabIndex = 0
        Me.INTE7SI.TabStop = True
        Me.INTE7SI.Text = "Sí"
        Me.INTE7SI.UseVisualStyleBackColor = True
        '
        'INTE7NO
        '
        Me.INTE7NO.Appearance = System.Windows.Forms.Appearance.Button
        Me.INTE7NO.AutoSize = True
        Me.INTE7NO.Location = New System.Drawing.Point(51, 5)
        Me.INTE7NO.Name = "INTE7NO"
        Me.INTE7NO.Size = New System.Drawing.Size(40, 28)
        Me.INTE7NO.TabIndex = 1
        Me.INTE7NO.TabStop = True
        Me.INTE7NO.Text = "No"
        Me.INTE7NO.UseVisualStyleBackColor = True
        '
        'Panel8
        '
        Me.Panel8.Controls.Add(Me.INTE6NOSABE)
        Me.Panel8.Controls.Add(Me.INTE6SI)
        Me.Panel8.Controls.Add(Me.INTE6NO)
        Me.Panel8.Enabled = False
        Me.Panel8.Location = New System.Drawing.Point(282, 347)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(225, 43)
        Me.Panel8.TabIndex = 5
        '
        'INTE6NOSABE
        '
        Me.INTE6NOSABE.Appearance = System.Windows.Forms.Appearance.Button
        Me.INTE6NOSABE.AutoSize = True
        Me.INTE6NOSABE.Location = New System.Drawing.Point(99, 5)
        Me.INTE6NOSABE.Name = "INTE6NOSABE"
        Me.INTE6NOSABE.Size = New System.Drawing.Size(85, 28)
        Me.INTE6NOSABE.TabIndex = 2
        Me.INTE6NOSABE.TabStop = True
        Me.INTE6NOSABE.Text = "No Sabe"
        Me.INTE6NOSABE.UseVisualStyleBackColor = True
        '
        'INTE6SI
        '
        Me.INTE6SI.Appearance = System.Windows.Forms.Appearance.Button
        Me.INTE6SI.AutoSize = True
        Me.INTE6SI.Location = New System.Drawing.Point(3, 5)
        Me.INTE6SI.Name = "INTE6SI"
        Me.INTE6SI.Size = New System.Drawing.Size(33, 28)
        Me.INTE6SI.TabIndex = 0
        Me.INTE6SI.TabStop = True
        Me.INTE6SI.Text = "Sí"
        Me.INTE6SI.UseVisualStyleBackColor = True
        '
        'INTE6NO
        '
        Me.INTE6NO.Appearance = System.Windows.Forms.Appearance.Button
        Me.INTE6NO.AutoSize = True
        Me.INTE6NO.Location = New System.Drawing.Point(51, 5)
        Me.INTE6NO.Name = "INTE6NO"
        Me.INTE6NO.Size = New System.Drawing.Size(40, 28)
        Me.INTE6NO.TabIndex = 1
        Me.INTE6NO.TabStop = True
        Me.INTE6NO.Text = "No"
        Me.INTE6NO.UseVisualStyleBackColor = True
        '
        'Panel7
        '
        Me.Panel7.Controls.Add(Me.INTE5SI)
        Me.Panel7.Controls.Add(Me.INTE5NO)
        Me.Panel7.Enabled = False
        Me.Panel7.Location = New System.Drawing.Point(544, 286)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(120, 36)
        Me.Panel7.TabIndex = 4
        '
        'INTE5SI
        '
        Me.INTE5SI.Appearance = System.Windows.Forms.Appearance.Button
        Me.INTE5SI.AutoSize = True
        Me.INTE5SI.Location = New System.Drawing.Point(3, 5)
        Me.INTE5SI.Name = "INTE5SI"
        Me.INTE5SI.Size = New System.Drawing.Size(33, 28)
        Me.INTE5SI.TabIndex = 0
        Me.INTE5SI.TabStop = True
        Me.INTE5SI.Text = "Sí"
        Me.INTE5SI.UseVisualStyleBackColor = True
        '
        'INTE5NO
        '
        Me.INTE5NO.Appearance = System.Windows.Forms.Appearance.Button
        Me.INTE5NO.AutoSize = True
        Me.INTE5NO.Location = New System.Drawing.Point(51, 5)
        Me.INTE5NO.Name = "INTE5NO"
        Me.INTE5NO.Size = New System.Drawing.Size(40, 28)
        Me.INTE5NO.TabIndex = 1
        Me.INTE5NO.TabStop = True
        Me.INTE5NO.Text = "No"
        Me.INTE5NO.UseVisualStyleBackColor = True
        '
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.INTE4SI)
        Me.Panel6.Controls.Add(Me.INTE4NO)
        Me.Panel6.Enabled = False
        Me.Panel6.Location = New System.Drawing.Point(424, 244)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(135, 41)
        Me.Panel6.TabIndex = 3
        '
        'INTE4SI
        '
        Me.INTE4SI.Appearance = System.Windows.Forms.Appearance.Button
        Me.INTE4SI.AutoSize = True
        Me.INTE4SI.Location = New System.Drawing.Point(3, 5)
        Me.INTE4SI.Name = "INTE4SI"
        Me.INTE4SI.Size = New System.Drawing.Size(33, 28)
        Me.INTE4SI.TabIndex = 0
        Me.INTE4SI.TabStop = True
        Me.INTE4SI.Text = "Sí"
        Me.INTE4SI.UseVisualStyleBackColor = True
        '
        'INTE4NO
        '
        Me.INTE4NO.Appearance = System.Windows.Forms.Appearance.Button
        Me.INTE4NO.AutoSize = True
        Me.INTE4NO.Location = New System.Drawing.Point(51, 5)
        Me.INTE4NO.Name = "INTE4NO"
        Me.INTE4NO.Size = New System.Drawing.Size(40, 28)
        Me.INTE4NO.TabIndex = 1
        Me.INTE4NO.TabStop = True
        Me.INTE4NO.Text = "No"
        Me.INTE4NO.UseVisualStyleBackColor = True
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.INTE2SI)
        Me.Panel5.Controls.Add(Me.INTE2NO)
        Me.Panel5.Enabled = False
        Me.Panel5.Location = New System.Drawing.Point(470, 117)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(111, 36)
        Me.Panel5.TabIndex = 1
        '
        'INTE2SI
        '
        Me.INTE2SI.Appearance = System.Windows.Forms.Appearance.Button
        Me.INTE2SI.AutoSize = True
        Me.INTE2SI.Location = New System.Drawing.Point(3, 5)
        Me.INTE2SI.Name = "INTE2SI"
        Me.INTE2SI.Size = New System.Drawing.Size(33, 28)
        Me.INTE2SI.TabIndex = 0
        Me.INTE2SI.TabStop = True
        Me.INTE2SI.Text = "Sí"
        Me.INTE2SI.UseVisualStyleBackColor = True
        '
        'INTE2NO
        '
        Me.INTE2NO.Appearance = System.Windows.Forms.Appearance.Button
        Me.INTE2NO.AutoSize = True
        Me.INTE2NO.Location = New System.Drawing.Point(51, 5)
        Me.INTE2NO.Name = "INTE2NO"
        Me.INTE2NO.Size = New System.Drawing.Size(40, 28)
        Me.INTE2NO.TabIndex = 1
        Me.INTE2NO.TabStop = True
        Me.INTE2NO.Text = "No"
        Me.INTE2NO.UseVisualStyleBackColor = True
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.INTE1NO)
        Me.Panel4.Controls.Add(Me.INTE1SI)
        Me.Panel4.Enabled = False
        Me.Panel4.Location = New System.Drawing.Point(405, 57)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(95, 37)
        Me.Panel4.TabIndex = 0
        '
        'INTE1NO
        '
        Me.INTE1NO.Appearance = System.Windows.Forms.Appearance.Button
        Me.INTE1NO.AutoSize = True
        Me.INTE1NO.Location = New System.Drawing.Point(51, 5)
        Me.INTE1NO.Name = "INTE1NO"
        Me.INTE1NO.Size = New System.Drawing.Size(40, 28)
        Me.INTE1NO.TabIndex = 1
        Me.INTE1NO.TabStop = True
        Me.INTE1NO.Text = "No"
        Me.INTE1NO.UseVisualStyleBackColor = True
        '
        'INTE1SI
        '
        Me.INTE1SI.Appearance = System.Windows.Forms.Appearance.Button
        Me.INTE1SI.AutoSize = True
        Me.INTE1SI.Location = New System.Drawing.Point(3, 5)
        Me.INTE1SI.Name = "INTE1SI"
        Me.INTE1SI.Size = New System.Drawing.Size(33, 28)
        Me.INTE1SI.TabIndex = 0
        Me.INTE1SI.TabStop = True
        Me.INTE1SI.Text = "Sí"
        Me.INTE1SI.UseVisualStyleBackColor = True
        '
        'Labelpreg8
        '
        Me.Labelpreg8.AutoSize = True
        Me.Labelpreg8.Location = New System.Drawing.Point(22, 479)
        Me.Labelpreg8.Name = "Labelpreg8"
        Me.Labelpreg8.Size = New System.Drawing.Size(305, 18)
        Me.Labelpreg8.TabIndex = 48
        Me.Labelpreg8.Text = "8-¿Está tomando alguna medicación?"
        '
        'Labelpreg7
        '
        Me.Labelpreg7.AutoSize = True
        Me.Labelpreg7.Location = New System.Drawing.Point(24, 410)
        Me.Labelpreg7.Name = "Labelpreg7"
        Me.Labelpreg7.Size = New System.Drawing.Size(281, 18)
        Me.Labelpreg7.TabIndex = 47
        Me.Labelpreg7.Text = "7-¿Tuvo incontinencia de esfínter?"
        '
        'Labelpreg6
        '
        Me.Labelpreg6.AutoSize = True
        Me.Labelpreg6.Location = New System.Drawing.Point(24, 347)
        Me.Labelpreg6.Name = "Labelpreg6"
        Me.Labelpreg6.Size = New System.Drawing.Size(189, 18)
        Me.Labelpreg6.TabIndex = 46
        Me.Labelpreg6.Text = "6-¿Tuvo convulsiones?"
        '
        'Labelpreg5
        '
        Me.Labelpreg5.AutoSize = True
        Me.Labelpreg5.Location = New System.Drawing.Point(26, 297)
        Me.Labelpreg5.Name = "Labelpreg5"
        Me.Labelpreg5.Size = New System.Drawing.Size(403, 18)
        Me.Labelpreg5.TabIndex = 45
        Me.Labelpreg5.Text = "5-¿El desmayo fue presenciado por algún testigo?"
        '
        'Labelpreg4
        '
        Me.Labelpreg4.AutoSize = True
        Me.Labelpreg4.Location = New System.Drawing.Point(24, 244)
        Me.Labelpreg4.Name = "Labelpreg4"
        Me.Labelpreg4.Size = New System.Drawing.Size(303, 18)
        Me.Labelpreg4.TabIndex = 44
        Me.Labelpreg4.Text = "4-¿Alguna vez se golpeó seriamente?"
        '
        'Labelpreg3
        '
        Me.Labelpreg3.AutoSize = True
        Me.Labelpreg3.Location = New System.Drawing.Point(24, 171)
        Me.Labelpreg3.Name = "Labelpreg3"
        Me.Labelpreg3.Size = New System.Drawing.Size(96, 18)
        Me.Labelpreg3.TabIndex = 43
        Me.Labelpreg3.Text = "3-¿Cuáles?"
        '
        'Labelpreg2
        '
        Me.Labelpreg2.AutoSize = True
        Me.Labelpreg2.Location = New System.Drawing.Point(24, 121)
        Me.Labelpreg2.Name = "Labelpreg2"
        Me.Labelpreg2.Size = New System.Drawing.Size(343, 18)
        Me.Labelpreg2.TabIndex = 42
        Me.Labelpreg2.Text = "2-¿Tuvo algún síntoma previo al desmayo?"
        '
        'Labelpreg1
        '
        Me.Labelpreg1.AutoSize = True
        Me.Labelpreg1.Location = New System.Drawing.Point(24, 71)
        Me.Labelpreg1.Name = "Labelpreg1"
        Me.Labelpreg1.Size = New System.Drawing.Size(290, 18)
        Me.Labelpreg1.TabIndex = 41
        Me.Labelpreg1.Text = "1-¿Tuvo algún episodio de síncope?"
        '
        'LabeltituloINTE
        '
        Me.LabeltituloINTE.AutoSize = True
        Me.LabeltituloINTE.Font = New System.Drawing.Font("Arial Rounded MT Bold", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabeltituloINTE.Location = New System.Drawing.Point(21, 16)
        Me.LabeltituloINTE.Name = "LabeltituloINTE"
        Me.LabeltituloINTE.Size = New System.Drawing.Size(264, 32)
        Me.LabeltituloINTE.TabIndex = 40
        Me.LabeltituloINTE.Text = "INTERROGATORIO"
        '
        'TabPersonales
        '
        Me.TabPersonales.AutoScroll = True
        Me.TabPersonales.BackColor = System.Drawing.Color.White
        Me.TabPersonales.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.TabPersonales.Controls.Add(Me.iconoRECpaciente)
        Me.TabPersonales.Controls.Add(Me.iconoPlayPaciente)
        Me.TabPersonales.Controls.Add(Me.LabelPacienteDesconectado)
        Me.TabPersonales.Controls.Add(Me.LabelConexionPersonales)
        Me.TabPersonales.Controls.Add(Me.PictureBoxEditarPaciente)
        Me.TabPersonales.Controls.Add(Me.CheckBoxMandanteExterno)
        Me.TabPersonales.Controls.Add(Me.LabeltituloPaciente)
        Me.TabPersonales.Controls.Add(Me.txtfechahoy)
        Me.TabPersonales.Controls.Add(Me.TextRitmo)
        Me.TabPersonales.Controls.Add(Me.TextDNI)
        Me.TabPersonales.Controls.Add(Me.TextEdad)
        Me.TabPersonales.Controls.Add(Me.TextApellido)
        Me.TabPersonales.Controls.Add(Me.TextNombre)
        Me.TabPersonales.Controls.Add(Me.TextTelefono)
        Me.TabPersonales.Controls.Add(Me.TextDomicilio)
        Me.TabPersonales.Controls.Add(Me.txtfechaexamen)
        Me.TabPersonales.Controls.Add(Me.TextSintoma)
        Me.TabPersonales.Controls.Add(Me.LabelRitmo)
        Me.TabPersonales.Controls.Add(Me.PictureBoxECGPaciente)
        Me.TabPersonales.Controls.Add(Me.PictureBoxTuercaFondo)
        Me.TabPersonales.Controls.Add(Me.LabelEdad)
        Me.TabPersonales.Controls.Add(Me.LabelApellido)
        Me.TabPersonales.Controls.Add(Me.Panelsexo)
        Me.TabPersonales.Controls.Add(Me.LabelSexo)
        Me.TabPersonales.Controls.Add(Me.LabelDNI)
        Me.TabPersonales.Controls.Add(Me.PanelINT)
        Me.TabPersonales.Controls.Add(Me.LabelInternado)
        Me.TabPersonales.Controls.Add(Me.LabelTelefono)
        Me.TabPersonales.Controls.Add(Me.LabelDomicilio)
        Me.TabPersonales.Controls.Add(Me.LabelNombre)
        Me.TabPersonales.Controls.Add(Me.botonbuscarexamen)
        Me.TabPersonales.Controls.Add(Me.botonBuscarpaciente)
        Me.TabPersonales.Controls.Add(Me.botonNuevopaciente)
        Me.TabPersonales.Controls.Add(Me.LabelTitulo)
        Me.TabPersonales.Controls.Add(Me.PictureBoxSalirPaciente)
        Me.TabPersonales.Controls.Add(Me.Labeltecnico)
        Me.TabPersonales.Controls.Add(Me.Labelactuante)
        Me.TabPersonales.Controls.Add(Me.Labelmandante)
        Me.TabPersonales.Controls.Add(Me.tickpersonales)
        Me.TabPersonales.Controls.Add(Me.botonsiguiente)
        Me.TabPersonales.Controls.Add(Me.LabelFecha)
        Me.TabPersonales.Controls.Add(Me.cbxActuante)
        Me.TabPersonales.Controls.Add(Me.PictureBox1)
        Me.TabPersonales.Controls.Add(Me.cbxMandante)
        Me.TabPersonales.Controls.Add(Me.cbxTecnico)
        Me.TabPersonales.Controls.Add(Me.LabelTecnicovisible)
        Me.TabPersonales.Controls.Add(Me.LabelActuantevisible)
        Me.TabPersonales.Controls.Add(Me.LabelMandantevisible)
        Me.TabPersonales.Controls.Add(Me.LabelSintoma)
        Me.TabPersonales.Controls.Add(Me.imagenfondo)
        Me.TabPersonales.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPersonales.Location = New System.Drawing.Point(4, 27)
        Me.TabPersonales.Name = "TabPersonales"
        Me.TabPersonales.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPersonales.Size = New System.Drawing.Size(2017, 1164)
        Me.TabPersonales.TabIndex = 0
        Me.TabPersonales.Text = "    Datos Paciente y Personal    "
        '
        'iconoRECpaciente
        '
        Me.iconoRECpaciente.BackColor = System.Drawing.Color.MediumBlue
        Me.iconoRECpaciente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.iconoRECpaciente.Image = CType(resources.GetObject("iconoRECpaciente.Image"), System.Drawing.Image)
        Me.iconoRECpaciente.Location = New System.Drawing.Point(1239, 605)
        Me.iconoRECpaciente.Name = "iconoRECpaciente"
        Me.iconoRECpaciente.Size = New System.Drawing.Size(71, 64)
        Me.iconoRECpaciente.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.iconoRECpaciente.TabIndex = 123
        Me.iconoRECpaciente.TabStop = False
        Me.iconoRECpaciente.Tag = "Salir"
        Me.iconoRECpaciente.Visible = False
        '
        'iconoPlayPaciente
        '
        Me.iconoPlayPaciente.BackColor = System.Drawing.Color.MediumBlue
        Me.iconoPlayPaciente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.iconoPlayPaciente.Image = CType(resources.GetObject("iconoPlayPaciente.Image"), System.Drawing.Image)
        Me.iconoPlayPaciente.Location = New System.Drawing.Point(1239, 533)
        Me.iconoPlayPaciente.Name = "iconoPlayPaciente"
        Me.iconoPlayPaciente.Size = New System.Drawing.Size(71, 64)
        Me.iconoPlayPaciente.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.iconoPlayPaciente.TabIndex = 122
        Me.iconoPlayPaciente.TabStop = False
        Me.iconoPlayPaciente.Tag = "Salir"
        '
        'LabelPacienteDesconectado
        '
        Me.LabelPacienteDesconectado.BackColor = System.Drawing.Color.GreenYellow
        Me.LabelPacienteDesconectado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LabelPacienteDesconectado.Enabled = False
        Me.LabelPacienteDesconectado.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelPacienteDesconectado.ForeColor = System.Drawing.SystemColors.WindowText
        Me.LabelPacienteDesconectado.Location = New System.Drawing.Point(845, 680)
        Me.LabelPacienteDesconectado.Margin = New System.Windows.Forms.Padding(3)
        Me.LabelPacienteDesconectado.Name = "LabelPacienteDesconectado"
        Me.LabelPacienteDesconectado.Size = New System.Drawing.Size(242, 26)
        Me.LabelPacienteDesconectado.TabIndex = 121
        Me.LabelPacienteDesconectado.Text = "PACIENTE DESCONECTADO"
        Me.LabelPacienteDesconectado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.LabelPacienteDesconectado.Visible = False
        '
        'LabelConexionPersonales
        '
        Me.LabelConexionPersonales.BackColor = System.Drawing.Color.LightSteelBlue
        Me.LabelConexionPersonales.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LabelConexionPersonales.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelConexionPersonales.Location = New System.Drawing.Point(1123, 680)
        Me.LabelConexionPersonales.Margin = New System.Windows.Forms.Padding(3)
        Me.LabelConexionPersonales.Name = "LabelConexionPersonales"
        Me.LabelConexionPersonales.Size = New System.Drawing.Size(73, 26)
        Me.LabelConexionPersonales.TabIndex = 120
        Me.LabelConexionPersonales.Text = "ONLINE"
        Me.LabelConexionPersonales.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PictureBoxEditarPaciente
        '
        Me.PictureBoxEditarPaciente.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.PictureBoxEditarPaciente.BackColor = System.Drawing.Color.Transparent
        Me.PictureBoxEditarPaciente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBoxEditarPaciente.Image = CType(resources.GetObject("PictureBoxEditarPaciente.Image"), System.Drawing.Image)
        Me.PictureBoxEditarPaciente.Location = New System.Drawing.Point(1148, 381)
        Me.PictureBoxEditarPaciente.Name = "PictureBoxEditarPaciente"
        Me.PictureBoxEditarPaciente.Size = New System.Drawing.Size(146, 103)
        Me.PictureBoxEditarPaciente.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBoxEditarPaciente.TabIndex = 118
        Me.PictureBoxEditarPaciente.TabStop = False
        Me.PictureBoxEditarPaciente.Visible = False
        '
        'CheckBoxMandanteExterno
        '
        Me.CheckBoxMandanteExterno.AutoSize = True
        Me.CheckBoxMandanteExterno.Location = New System.Drawing.Point(328, 87)
        Me.CheckBoxMandanteExterno.Name = "CheckBoxMandanteExterno"
        Me.CheckBoxMandanteExterno.Size = New System.Drawing.Size(15, 14)
        Me.CheckBoxMandanteExterno.TabIndex = 116
        Me.CheckBoxMandanteExterno.UseVisualStyleBackColor = True
        '
        'LabeltituloPaciente
        '
        Me.LabeltituloPaciente.AutoSize = True
        Me.LabeltituloPaciente.Font = New System.Drawing.Font("Arial Rounded MT Bold", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabeltituloPaciente.Location = New System.Drawing.Point(347, 197)
        Me.LabeltituloPaciente.Name = "LabeltituloPaciente"
        Me.LabeltituloPaciente.Size = New System.Drawing.Size(256, 32)
        Me.LabeltituloPaciente.TabIndex = 115
        Me.LabeltituloPaciente.Text = "DATOS PACIENTE"
        '
        'txtfechahoy
        '
        Me.txtfechahoy.AutoSize = True
        Me.txtfechahoy.BackColor = System.Drawing.Color.Transparent
        Me.txtfechahoy.Font = New System.Drawing.Font("Arial Rounded MT Bold", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtfechahoy.Location = New System.Drawing.Point(1274, 18)
        Me.txtfechahoy.Name = "txtfechahoy"
        Me.txtfechahoy.Size = New System.Drawing.Size(0, 24)
        Me.txtfechahoy.TabIndex = 113
        '
        'TextRitmo
        '
        Me.TextRitmo.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextRitmo.Location = New System.Drawing.Point(139, 393)
        Me.TextRitmo.Multiline = True
        Me.TextRitmo.Name = "TextRitmo"
        Me.TextRitmo.Size = New System.Drawing.Size(228, 123)
        Me.TextRitmo.TabIndex = 6
        Me.TextRitmo.Text = "SINUSAL"
        '
        'TextDNI
        '
        Me.TextDNI.Enabled = False
        Me.TextDNI.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextDNI.Location = New System.Drawing.Point(790, 331)
        Me.TextDNI.Name = "TextDNI"
        Me.TextDNI.Size = New System.Drawing.Size(136, 26)
        Me.TextDNI.TabIndex = 2
        '
        'TextEdad
        '
        Me.TextEdad.Enabled = False
        Me.TextEdad.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextEdad.Location = New System.Drawing.Point(790, 264)
        Me.TextEdad.Name = "TextEdad"
        Me.TextEdad.Size = New System.Drawing.Size(67, 26)
        Me.TextEdad.TabIndex = 3
        '
        'TextApellido
        '
        Me.TextApellido.Enabled = False
        Me.TextApellido.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextApellido.Location = New System.Drawing.Point(456, 264)
        Me.TextApellido.MaxLength = 29
        Me.TextApellido.Name = "TextApellido"
        Me.TextApellido.Size = New System.Drawing.Size(270, 26)
        Me.TextApellido.TabIndex = 1
        '
        'TextNombre
        '
        Me.TextNombre.Enabled = False
        Me.TextNombre.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextNombre.Location = New System.Drawing.Point(92, 264)
        Me.TextNombre.MaxLength = 29
        Me.TextNombre.Name = "TextNombre"
        Me.TextNombre.Size = New System.Drawing.Size(270, 26)
        Me.TextNombre.TabIndex = 0
        '
        'TextTelefono
        '
        Me.TextTelefono.Enabled = False
        Me.TextTelefono.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextTelefono.Location = New System.Drawing.Point(456, 334)
        Me.TextTelefono.Name = "TextTelefono"
        Me.TextTelefono.Size = New System.Drawing.Size(270, 26)
        Me.TextTelefono.TabIndex = 5
        '
        'TextDomicilio
        '
        Me.TextDomicilio.Enabled = False
        Me.TextDomicilio.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextDomicilio.Location = New System.Drawing.Point(98, 334)
        Me.TextDomicilio.MaxLength = 39
        Me.TextDomicilio.Name = "TextDomicilio"
        Me.TextDomicilio.Size = New System.Drawing.Size(270, 26)
        Me.TextDomicilio.TabIndex = 4
        '
        'txtfechaexamen
        '
        Me.txtfechaexamen.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtfechaexamen.Location = New System.Drawing.Point(1053, 398)
        Me.txtfechaexamen.Name = "txtfechaexamen"
        Me.txtfechaexamen.Size = New System.Drawing.Size(124, 26)
        Me.txtfechaexamen.TabIndex = 8
        '
        'TextSintoma
        '
        Me.TextSintoma.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextSintoma.Location = New System.Drawing.Point(538, 397)
        Me.TextSintoma.Multiline = True
        Me.TextSintoma.Name = "TextSintoma"
        Me.TextSintoma.Size = New System.Drawing.Size(345, 118)
        Me.TextSintoma.TabIndex = 7
        Me.TextSintoma.Text = "SINCOPE"
        '
        'LabelRitmo
        '
        Me.LabelRitmo.AutoSize = True
        Me.LabelRitmo.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelRitmo.Location = New System.Drawing.Point(14, 398)
        Me.LabelRitmo.Name = "LabelRitmo"
        Me.LabelRitmo.Size = New System.Drawing.Size(128, 18)
        Me.LabelRitmo.TabIndex = 55
        Me.LabelRitmo.Text = "Ritmo de Base:"
        '
        'PictureBoxECGPaciente
        '
        Me.PictureBoxECGPaciente.BackColor = System.Drawing.Color.MediumBlue
        Me.PictureBoxECGPaciente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBoxECGPaciente.Location = New System.Drawing.Point(17, 693)
        Me.PictureBoxECGPaciente.Name = "PictureBoxECGPaciente"
        Me.PictureBoxECGPaciente.Size = New System.Drawing.Size(214, 44)
        Me.PictureBoxECGPaciente.TabIndex = 112
        Me.PictureBoxECGPaciente.TabStop = False
        '
        'PictureBoxTuercaFondo
        '
        Me.PictureBoxTuercaFondo.BackColor = System.Drawing.Color.Transparent
        Me.PictureBoxTuercaFondo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBoxTuercaFondo.Image = CType(resources.GetObject("PictureBoxTuercaFondo.Image"), System.Drawing.Image)
        Me.PictureBoxTuercaFondo.InitialImage = Nothing
        Me.PictureBoxTuercaFondo.Location = New System.Drawing.Point(1059, 247)
        Me.PictureBoxTuercaFondo.Name = "PictureBoxTuercaFondo"
        Me.PictureBoxTuercaFondo.Size = New System.Drawing.Size(74, 61)
        Me.PictureBoxTuercaFondo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBoxTuercaFondo.TabIndex = 107
        Me.PictureBoxTuercaFondo.TabStop = False
        '
        'LabelEdad
        '
        Me.LabelEdad.AutoSize = True
        Me.LabelEdad.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelEdad.Location = New System.Drawing.Point(740, 267)
        Me.LabelEdad.Name = "LabelEdad"
        Me.LabelEdad.Size = New System.Drawing.Size(54, 18)
        Me.LabelEdad.TabIndex = 42
        Me.LabelEdad.Text = "Edad:"
        '
        'LabelApellido
        '
        Me.LabelApellido.AutoSize = True
        Me.LabelApellido.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelApellido.Location = New System.Drawing.Point(374, 267)
        Me.LabelApellido.Name = "LabelApellido"
        Me.LabelApellido.Size = New System.Drawing.Size(77, 18)
        Me.LabelApellido.TabIndex = 41
        Me.LabelApellido.Text = "Apellido:"
        '
        'Panelsexo
        '
        Me.Panelsexo.Controls.Add(Me.botonMsexo)
        Me.Panelsexo.Controls.Add(Me.botonFsexo)
        Me.Panelsexo.Enabled = False
        Me.Panelsexo.Location = New System.Drawing.Point(790, 293)
        Me.Panelsexo.Name = "Panelsexo"
        Me.Panelsexo.Size = New System.Drawing.Size(136, 32)
        Me.Panelsexo.TabIndex = 2
        '
        'botonMsexo
        '
        Me.botonMsexo.Appearance = System.Windows.Forms.Appearance.Button
        Me.botonMsexo.AutoSize = True
        Me.botonMsexo.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.botonMsexo.Location = New System.Drawing.Point(8, 3)
        Me.botonMsexo.Name = "botonMsexo"
        Me.botonMsexo.Size = New System.Drawing.Size(65, 28)
        Me.botonMsexo.TabIndex = 0
        Me.botonMsexo.TabStop = True
        Me.botonMsexo.Text = "Masc."
        Me.botonMsexo.UseVisualStyleBackColor = True
        '
        'botonFsexo
        '
        Me.botonFsexo.Appearance = System.Windows.Forms.Appearance.Button
        Me.botonFsexo.AutoSize = True
        Me.botonFsexo.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.botonFsexo.Location = New System.Drawing.Point(76, 3)
        Me.botonFsexo.Name = "botonFsexo"
        Me.botonFsexo.Size = New System.Drawing.Size(57, 28)
        Me.botonFsexo.TabIndex = 1
        Me.botonFsexo.TabStop = True
        Me.botonFsexo.Text = "Fem."
        Me.botonFsexo.UseVisualStyleBackColor = True
        '
        'LabelSexo
        '
        Me.LabelSexo.AutoSize = True
        Me.LabelSexo.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelSexo.Location = New System.Drawing.Point(740, 301)
        Me.LabelSexo.Name = "LabelSexo"
        Me.LabelSexo.Size = New System.Drawing.Size(52, 18)
        Me.LabelSexo.TabIndex = 90
        Me.LabelSexo.Text = "Sexo:"
        '
        'LabelDNI
        '
        Me.LabelDNI.AutoSize = True
        Me.LabelDNI.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelDNI.Location = New System.Drawing.Point(740, 334)
        Me.LabelDNI.Name = "LabelDNI"
        Me.LabelDNI.Size = New System.Drawing.Size(42, 18)
        Me.LabelDNI.TabIndex = 88
        Me.LabelDNI.Text = "DNI:"
        '
        'PanelINT
        '
        Me.PanelINT.Controls.Add(Me.InternadoSI)
        Me.PanelINT.Controls.Add(Me.InternadoNO)
        Me.PanelINT.Enabled = False
        Me.PanelINT.Location = New System.Drawing.Point(111, 293)
        Me.PanelINT.Name = "PanelINT"
        Me.PanelINT.Size = New System.Drawing.Size(94, 35)
        Me.PanelINT.TabIndex = 78
        '
        'InternadoSI
        '
        Me.InternadoSI.Appearance = System.Windows.Forms.Appearance.Button
        Me.InternadoSI.AutoSize = True
        Me.InternadoSI.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InternadoSI.Location = New System.Drawing.Point(3, 5)
        Me.InternadoSI.Name = "InternadoSI"
        Me.InternadoSI.Size = New System.Drawing.Size(33, 28)
        Me.InternadoSI.TabIndex = 0
        Me.InternadoSI.TabStop = True
        Me.InternadoSI.Text = "Sí"
        Me.InternadoSI.UseVisualStyleBackColor = True
        '
        'InternadoNO
        '
        Me.InternadoNO.Appearance = System.Windows.Forms.Appearance.Button
        Me.InternadoNO.AutoSize = True
        Me.InternadoNO.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InternadoNO.Location = New System.Drawing.Point(45, 5)
        Me.InternadoNO.Name = "InternadoNO"
        Me.InternadoNO.Size = New System.Drawing.Size(40, 28)
        Me.InternadoNO.TabIndex = 1
        Me.InternadoNO.TabStop = True
        Me.InternadoNO.Text = "No"
        Me.InternadoNO.UseVisualStyleBackColor = True
        '
        'LabelInternado
        '
        Me.LabelInternado.AutoSize = True
        Me.LabelInternado.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelInternado.Location = New System.Drawing.Point(14, 301)
        Me.LabelInternado.Name = "LabelInternado"
        Me.LabelInternado.Size = New System.Drawing.Size(91, 18)
        Me.LabelInternado.TabIndex = 52
        Me.LabelInternado.Text = "Internado:"
        '
        'LabelTelefono
        '
        Me.LabelTelefono.AutoSize = True
        Me.LabelTelefono.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelTelefono.Location = New System.Drawing.Point(374, 336)
        Me.LabelTelefono.Name = "LabelTelefono"
        Me.LabelTelefono.Size = New System.Drawing.Size(82, 18)
        Me.LabelTelefono.TabIndex = 49
        Me.LabelTelefono.Text = "Teléfono:"
        '
        'LabelDomicilio
        '
        Me.LabelDomicilio.AutoSize = True
        Me.LabelDomicilio.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelDomicilio.Location = New System.Drawing.Point(14, 336)
        Me.LabelDomicilio.Name = "LabelDomicilio"
        Me.LabelDomicilio.Size = New System.Drawing.Size(85, 18)
        Me.LabelDomicilio.TabIndex = 48
        Me.LabelDomicilio.Text = "Domicilio:"
        '
        'LabelNombre
        '
        Me.LabelNombre.AutoSize = True
        Me.LabelNombre.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelNombre.Location = New System.Drawing.Point(14, 267)
        Me.LabelNombre.Name = "LabelNombre"
        Me.LabelNombre.Size = New System.Drawing.Size(76, 18)
        Me.LabelNombre.TabIndex = 40
        Me.LabelNombre.Text = "Nombre:"
        '
        'botonbuscarexamen
        '
        Me.botonbuscarexamen.Location = New System.Drawing.Point(980, 134)
        Me.botonbuscarexamen.Name = "botonbuscarexamen"
        Me.botonbuscarexamen.Size = New System.Drawing.Size(214, 57)
        Me.botonbuscarexamen.TabIndex = 86
        Me.botonbuscarexamen.Text = "Buscar Examen"
        Me.botonbuscarexamen.UseVisualStyleBackColor = True
        '
        'botonBuscarpaciente
        '
        Me.botonBuscarpaciente.Location = New System.Drawing.Point(742, 134)
        Me.botonBuscarpaciente.Name = "botonBuscarpaciente"
        Me.botonBuscarpaciente.Size = New System.Drawing.Size(214, 57)
        Me.botonBuscarpaciente.TabIndex = 85
        Me.botonBuscarpaciente.Text = "Buscar Paciente"
        Me.botonBuscarpaciente.UseVisualStyleBackColor = True
        '
        'botonNuevopaciente
        '
        Me.botonNuevopaciente.AutoSize = True
        Me.botonNuevopaciente.Location = New System.Drawing.Point(486, 134)
        Me.botonNuevopaciente.Name = "botonNuevopaciente"
        Me.botonNuevopaciente.Size = New System.Drawing.Size(214, 57)
        Me.botonNuevopaciente.TabIndex = 84
        Me.botonNuevopaciente.Text = "Nuevo Paciente"
        Me.botonNuevopaciente.UseVisualStyleBackColor = True
        '
        'LabelTitulo
        '
        Me.LabelTitulo.AutoSize = True
        Me.LabelTitulo.BackColor = System.Drawing.Color.Transparent
        Me.LabelTitulo.Font = New System.Drawing.Font("Corbel", 28.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelTitulo.Location = New System.Drawing.Point(486, 72)
        Me.LabelTitulo.Name = "LabelTitulo"
        Me.LabelTitulo.Size = New System.Drawing.Size(824, 46)
        Me.LabelTitulo.TabIndex = 44
        Me.LabelTitulo.Text = "TEST DE MOVIMIENTO OSCILATORIO CORPORAL"
        Me.LabelTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PictureBoxSalirPaciente
        '
        Me.PictureBoxSalirPaciente.BackColor = System.Drawing.Color.Transparent
        Me.PictureBoxSalirPaciente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBoxSalirPaciente.Image = CType(resources.GetObject("PictureBoxSalirPaciente.Image"), System.Drawing.Image)
        Me.PictureBoxSalirPaciente.Location = New System.Drawing.Point(1163, 257)
        Me.PictureBoxSalirPaciente.Name = "PictureBoxSalirPaciente"
        Me.PictureBoxSalirPaciente.Size = New System.Drawing.Size(71, 64)
        Me.PictureBoxSalirPaciente.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBoxSalirPaciente.TabIndex = 101
        Me.PictureBoxSalirPaciente.TabStop = False
        Me.PictureBoxSalirPaciente.Tag = "Salir"
        '
        'Labeltecnico
        '
        Me.Labeltecnico.AutoSize = True
        Me.Labeltecnico.Font = New System.Drawing.Font("Arial Narrow", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Labeltecnico.ForeColor = System.Drawing.Color.Red
        Me.Labeltecnico.Location = New System.Drawing.Point(442, 646)
        Me.Labeltecnico.Name = "Labeltecnico"
        Me.Labeltecnico.Size = New System.Drawing.Size(201, 20)
        Me.Labeltecnico.TabIndex = 100
        Me.Labeltecnico.Text = "*este técnico se encuentra inactivo"
        Me.Labeltecnico.Visible = False
        '
        'Labelactuante
        '
        Me.Labelactuante.AutoSize = True
        Me.Labelactuante.Font = New System.Drawing.Font("Arial Narrow", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Labelactuante.ForeColor = System.Drawing.Color.Red
        Me.Labelactuante.Location = New System.Drawing.Point(442, 590)
        Me.Labelactuante.Name = "Labelactuante"
        Me.Labelactuante.Size = New System.Drawing.Size(202, 20)
        Me.Labelactuante.TabIndex = 99
        Me.Labelactuante.Text = "*este médico se encuentra inactivo"
        Me.Labelactuante.Visible = False
        '
        'Labelmandante
        '
        Me.Labelmandante.AutoSize = True
        Me.Labelmandante.Font = New System.Drawing.Font("Arial Narrow", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Labelmandante.ForeColor = System.Drawing.Color.Red
        Me.Labelmandante.Location = New System.Drawing.Point(442, 536)
        Me.Labelmandante.Name = "Labelmandante"
        Me.Labelmandante.Size = New System.Drawing.Size(202, 20)
        Me.Labelmandante.TabIndex = 98
        Me.Labelmandante.Text = "*este médico se encuentra inactivo"
        Me.Labelmandante.Visible = False
        '
        'tickpersonales
        '
        Me.tickpersonales.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.tickpersonales.BackColor = System.Drawing.Color.Transparent
        Me.tickpersonales.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.tickpersonales.Image = CType(resources.GetObject("tickpersonales.Image"), System.Drawing.Image)
        Me.tickpersonales.Location = New System.Drawing.Point(845, 471)
        Me.tickpersonales.Name = "tickpersonales"
        Me.tickpersonales.Size = New System.Drawing.Size(255, 178)
        Me.tickpersonales.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.tickpersonales.TabIndex = 97
        Me.tickpersonales.TabStop = False
        Me.tickpersonales.Visible = False
        '
        'botonsiguiente
        '
        Me.botonsiguiente.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.botonsiguiente.BackColor = System.Drawing.Color.Transparent
        Me.botonsiguiente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.botonsiguiente.Image = CType(resources.GetObject("botonsiguiente.Image"), System.Drawing.Image)
        Me.botonsiguiente.Location = New System.Drawing.Point(1051, 509)
        Me.botonsiguiente.Name = "botonsiguiente"
        Me.botonsiguiente.Size = New System.Drawing.Size(181, 135)
        Me.botonsiguiente.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.botonsiguiente.TabIndex = 96
        Me.botonsiguiente.TabStop = False
        '
        'LabelFecha
        '
        Me.LabelFecha.AutoSize = True
        Me.LabelFecha.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelFecha.Location = New System.Drawing.Point(890, 401)
        Me.LabelFecha.Name = "LabelFecha"
        Me.LabelFecha.Size = New System.Drawing.Size(71, 18)
        Me.LabelFecha.TabIndex = 94
        Me.LabelFecha.Text = "Fec. Ex:"
        '
        'cbxActuante
        '
        Me.cbxActuante.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxActuante.FormattingEnabled = True
        Me.cbxActuante.Location = New System.Drawing.Point(183, 587)
        Me.cbxActuante.Name = "cbxActuante"
        Me.cbxActuante.Size = New System.Drawing.Size(229, 26)
        Me.cbxActuante.TabIndex = 10
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImage = CType(resources.GetObject("PictureBox1.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox1.Location = New System.Drawing.Point(17, 18)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(272, 222)
        Me.PictureBox1.TabIndex = 83
        Me.PictureBox1.TabStop = False
        '
        'cbxMandante
        '
        Me.cbxMandante.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxMandante.FormattingEnabled = True
        Me.cbxMandante.Location = New System.Drawing.Point(183, 533)
        Me.cbxMandante.MaxLength = 29
        Me.cbxMandante.Name = "cbxMandante"
        Me.cbxMandante.Size = New System.Drawing.Size(229, 26)
        Me.cbxMandante.TabIndex = 9
        '
        'cbxTecnico
        '
        Me.cbxTecnico.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxTecnico.FormattingEnabled = True
        Me.cbxTecnico.Location = New System.Drawing.Point(183, 643)
        Me.cbxTecnico.Name = "cbxTecnico"
        Me.cbxTecnico.Size = New System.Drawing.Size(229, 26)
        Me.cbxTecnico.TabIndex = 11
        '
        'LabelTecnicovisible
        '
        Me.LabelTecnicovisible.AutoSize = True
        Me.LabelTecnicovisible.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelTecnicovisible.Location = New System.Drawing.Point(14, 646)
        Me.LabelTecnicovisible.Name = "LabelTecnicovisible"
        Me.LabelTecnicovisible.Size = New System.Drawing.Size(153, 18)
        Me.LabelTecnicovisible.TabIndex = 61
        Me.LabelTecnicovisible.Text = "Técnico actuante:"
        '
        'LabelActuantevisible
        '
        Me.LabelActuantevisible.AutoSize = True
        Me.LabelActuantevisible.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelActuantevisible.Location = New System.Drawing.Point(14, 590)
        Me.LabelActuantevisible.Name = "LabelActuantevisible"
        Me.LabelActuantevisible.Size = New System.Drawing.Size(146, 18)
        Me.LabelActuantevisible.TabIndex = 60
        Me.LabelActuantevisible.Text = "Médico actuante:"
        '
        'LabelMandantevisible
        '
        Me.LabelMandantevisible.AutoSize = True
        Me.LabelMandantevisible.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelMandantevisible.Location = New System.Drawing.Point(14, 536)
        Me.LabelMandantevisible.Name = "LabelMandantevisible"
        Me.LabelMandantevisible.Size = New System.Drawing.Size(154, 18)
        Me.LabelMandantevisible.TabIndex = 59
        Me.LabelMandantevisible.Text = "Médico mandante:"
        '
        'LabelSintoma
        '
        Me.LabelSintoma.AutoSize = True
        Me.LabelSintoma.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelSintoma.Location = New System.Drawing.Point(374, 398)
        Me.LabelSintoma.Name = "LabelSintoma"
        Me.LabelSintoma.Size = New System.Drawing.Size(166, 18)
        Me.LabelSintoma.TabIndex = 56
        Me.LabelSintoma.Text = "Síntoma de ingreso:"
        '
        'imagenfondo
        '
        Me.imagenfondo.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.imagenfondo.BackColor = System.Drawing.Color.Transparent
        Me.imagenfondo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.imagenfondo.Image = CType(resources.GetObject("imagenfondo.Image"), System.Drawing.Image)
        Me.imagenfondo.Location = New System.Drawing.Point(597, 231)
        Me.imagenfondo.Margin = New System.Windows.Forms.Padding(2)
        Me.imagenfondo.Name = "imagenfondo"
        Me.imagenfondo.Size = New System.Drawing.Size(616, 569)
        Me.imagenfondo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.imagenfondo.TabIndex = 114
        Me.imagenfondo.TabStop = False
        '
        'TabGeneral
        '
        Me.TabGeneral.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabGeneral.Controls.Add(Me.TabPersonales)
        Me.TabGeneral.Controls.Add(Me.TabPreguntas)
        Me.TabGeneral.Controls.Add(Me.Examen)
        Me.TabGeneral.Controls.Add(Me.Grafico)
        Me.TabGeneral.Controls.Add(Me.TirasECG)
        Me.TabGeneral.Controls.Add(Me.Personal)
        Me.TabGeneral.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabGeneral.ItemSize = New System.Drawing.Size(235, 23)
        Me.TabGeneral.Location = New System.Drawing.Point(1, 1)
        Me.TabGeneral.Multiline = True
        Me.TabGeneral.Name = "TabGeneral"
        Me.TabGeneral.SelectedIndex = 0
        Me.TabGeneral.Size = New System.Drawing.Size(2025, 1195)
        Me.TabGeneral.TabIndex = 0
        '
        'TimerRecepcion
        '
        Me.TimerRecepcion.Enabled = True
        Me.TimerRecepcion.Interval = 240
        '
        'TimerDisplay
        '
        Me.TimerDisplay.Enabled = True
        Me.TimerDisplay.Interval = 80
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.AutoScrollMargin = New System.Drawing.Size(5, 5)
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1183, 709)
        Me.Controls.Add(Me.TabGeneral)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form1"
        Me.Text = "Tilt Test"
        Me.Personal.ResumeLayout(False)
        Me.Personal.PerformLayout()
        CType(Me.PictureBoxsalirServicio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGVLogin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelStaff.ResumeLayout(False)
        Me.PanelStaff.PerformLayout()
        CType(Me.DGVauxiliar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGVmedicosact, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGVmedicosman, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGVtecnicos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TirasECG.ResumeLayout(False)
        Me.TirasECG.PerformLayout()
        CType(Me.iconoImprimirPDF, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.iconoGuardarExamen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.botonanteriorConclusion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBoxsalirTiras, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ChartEventos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Grafico.ResumeLayout(False)
        CType(Me.botonanteriorGrafico, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.botonsiguienteGrafico, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBoxsalirgrafico, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Examen.ResumeLayout(False)
        Me.Examen.PerformLayout()
        CType(Me.botonModificarPresion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.iconoRecExamen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.iconoPlayExamen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.botonanteriorExamen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.botonsiguienteExamen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBoxsalirexamen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBoxECG, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBoxfondosalir3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DatosExamen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPreguntas.ResumeLayout(False)
        Me.TabPreguntas.PerformLayout()
        CType(Me.iconoRecProtocolos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.iconoPlayProtocolos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.botonAnteriorProtocolo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tickprotocolo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBoxSalirProtocolo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBoxECGProtocolo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGVprotocolo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.botonsiguienteprotocolo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel10.ResumeLayout(False)
        Me.Panel10.PerformLayout()
        Me.Panel9.ResumeLayout(False)
        Me.Panel9.PerformLayout()
        Me.Panel8.ResumeLayout(False)
        Me.Panel8.PerformLayout()
        Me.Panel7.ResumeLayout(False)
        Me.Panel7.PerformLayout()
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.TabPersonales.ResumeLayout(False)
        Me.TabPersonales.PerformLayout()
        CType(Me.iconoRECpaciente, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.iconoPlayPaciente, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBoxEditarPaciente, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBoxECGPaciente, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBoxTuercaFondo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panelsexo.ResumeLayout(False)
        Me.Panelsexo.PerformLayout()
        Me.PanelINT.ResumeLayout(False)
        Me.PanelINT.PerformLayout()
        CType(Me.PictureBoxSalirPaciente, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tickpersonales, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.botonsiguiente, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imagenfondo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabGeneral.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Public WithEvents TimerEnvio As System.Windows.Forms.Timer
    Friend WithEvents TimerReal As System.Windows.Forms.Timer
    Friend WithEvents carpeta As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents TimerScreen As System.Windows.Forms.Timer
    Friend WithEvents Personal As System.Windows.Forms.TabPage
    Friend WithEvents DGVLogin As System.Windows.Forms.DataGridView
    Friend WithEvents BotonUsuarios As System.Windows.Forms.Button
    Friend WithEvents BotonIP As System.Windows.Forms.Button
    Friend WithEvents BotonBaseDatos As System.Windows.Forms.Button
    Friend WithEvents BotonCambiarServidor As System.Windows.Forms.Button
    Friend WithEvents PanelStaff As System.Windows.Forms.Panel
    Friend WithEvents RadioButtonActuantes As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButtonMandantes As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButtonTecnicos As System.Windows.Forms.RadioButton
    Friend WithEvents botonProtocolos As System.Windows.Forms.Button
    Friend WithEvents DGVauxiliar As System.Windows.Forms.DataGridView
    Friend WithEvents DefectoActuante As System.Windows.Forms.CheckBox
    Friend WithEvents DefectoMandante As System.Windows.Forms.CheckBox
    Friend WithEvents DefectoTecnico As System.Windows.Forms.CheckBox
    Friend WithEvents botonPlantillas As System.Windows.Forms.Button
    Friend WithEvents activoactuante As System.Windows.Forms.CheckBox
    Friend WithEvents txtApellidoactuante As System.Windows.Forms.TextBox
    Friend WithEvents txtNombreactuante As System.Windows.Forms.TextBox
    Friend WithEvents txtbuscaractuante As System.Windows.Forms.TextBox
    Friend WithEvents txtApellidoMandante As System.Windows.Forms.TextBox
    Friend WithEvents txtNombreMandante As System.Windows.Forms.TextBox
    Friend WithEvents txtbuscarmandante As System.Windows.Forms.TextBox
    Friend WithEvents txtApellidoTecnico As System.Windows.Forms.TextBox
    Friend WithEvents txtNombreTecnico As System.Windows.Forms.TextBox
    Friend WithEvents txtbuscartecnico As System.Windows.Forms.TextBox
    Friend WithEvents LabelNombreActuante As System.Windows.Forms.Label
    Friend WithEvents LabelApellidoActuante As System.Windows.Forms.Label
    Friend WithEvents Editaractuante As System.Windows.Forms.Button
    Friend WithEvents Eliminaractuante As System.Windows.Forms.Button
    Friend WithEvents Insertaractuante As System.Windows.Forms.Button
    Friend WithEvents buscaractuante As System.Windows.Forms.Button
    Friend WithEvents DGVmedicosact As System.Windows.Forms.DataGridView
    Friend WithEvents password As System.Windows.Forms.Button
    Friend WithEvents activomandante As System.Windows.Forms.CheckBox
    Friend WithEvents LabelNombreMandante As System.Windows.Forms.Label
    Friend WithEvents LabelApellidoMandante As System.Windows.Forms.Label
    Friend WithEvents EditarMandante As System.Windows.Forms.Button
    Friend WithEvents EliminarMandante As System.Windows.Forms.Button
    Friend WithEvents InsertarMandante As System.Windows.Forms.Button
    Friend WithEvents BuscarMedMan As System.Windows.Forms.Button
    Friend WithEvents DGVmedicosman As System.Windows.Forms.DataGridView
    Friend WithEvents BotonRutaPDF As System.Windows.Forms.Button
    Friend WithEvents activotecnico As System.Windows.Forms.CheckBox
    Friend WithEvents LabelNombreTecnico As System.Windows.Forms.Label
    Friend WithEvents LabelApellidoTecnico As System.Windows.Forms.Label
    Friend WithEvents EditarTecnico As System.Windows.Forms.Button
    Friend WithEvents EliminarTecnico As System.Windows.Forms.Button
    Friend WithEvents InsertarTecnico As System.Windows.Forms.Button
    Friend WithEvents botonBuscarTecnico As System.Windows.Forms.Button
    Friend WithEvents DGVtecnicos As System.Windows.Forms.DataGridView
    Friend WithEvents TirasECG As System.Windows.Forms.TabPage
    Friend WithEvents LabelConclusion As System.Windows.Forms.Label
    Friend WithEvents cbxConclusiones As System.Windows.Forms.ComboBox
    Friend WithEvents conclusiontext As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents LabeltituloTiras As System.Windows.Forms.Label
    Friend WithEvents ListBoxeventos As System.Windows.Forms.ListBox
    Friend WithEvents ChartEventos As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents Grafico As System.Windows.Forms.TabPage
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Public WithEvents Chart1 As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents Examen As System.Windows.Forms.TabPage
    Friend WithEvents PictureBoxsalirexamen As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBoxECG As System.Windows.Forms.PictureBox
    Friend WithEvents botonDeshacer As System.Windows.Forms.Button
    Friend WithEvents PictureBoxfondosalir3 As System.Windows.Forms.PictureBox
    Friend WithEvents LabelINC As System.Windows.Forms.Label
    Friend WithEvents txtinclinacion As System.Windows.Forms.TextBox
    Friend WithEvents txtdiastolica As System.Windows.Forms.TextBox
    Friend WithEvents txtsistolica As System.Windows.Forms.TextBox
    Friend WithEvents txtFC As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxTiempo As System.Windows.Forms.TextBox
    Friend WithEvents botonPresion As System.Windows.Forms.Button
    Friend WithEvents LabelPD As System.Windows.Forms.Label
    Friend WithEvents LabelPS As System.Windows.Forms.Label
    Friend WithEvents LabelFrecuencia As System.Windows.Forms.Label
    Friend WithEvents LabelTiempo As System.Windows.Forms.Label
    Friend WithEvents DatosExamen As System.Windows.Forms.DataGridView
    Friend WithEvents TabPreguntas As System.Windows.Forms.TabPage
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents tickprotocolo As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBoxSalirProtocolo As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBoxECGProtocolo As System.Windows.Forms.PictureBox
    Friend WithEvents TextINTE9 As System.Windows.Forms.TextBox
    Friend WithEvents TextProtocolo As System.Windows.Forms.TextBox
    Friend WithEvents TextINTE3 As System.Windows.Forms.TextBox
    Friend WithEvents DGVprotocolo As System.Windows.Forms.DataGridView
    Friend WithEvents botonsiguienteprotocolo As System.Windows.Forms.PictureBox
    Friend WithEvents Labelpreg9 As System.Windows.Forms.Label
    Friend WithEvents ComboBoxProtocolo As System.Windows.Forms.ComboBox
    Friend WithEvents LabeltituloPROTO As System.Windows.Forms.Label
    Friend WithEvents Panel10 As System.Windows.Forms.Panel
    Friend WithEvents INTE8SI As System.Windows.Forms.RadioButton
    Friend WithEvents INTE8NO As System.Windows.Forms.RadioButton
    Friend WithEvents Panel9 As System.Windows.Forms.Panel
    Friend WithEvents INTE7SI As System.Windows.Forms.RadioButton
    Friend WithEvents INTE7NO As System.Windows.Forms.RadioButton
    Friend WithEvents Panel8 As System.Windows.Forms.Panel
    Friend WithEvents INTE6NOSABE As System.Windows.Forms.RadioButton
    Friend WithEvents INTE6SI As System.Windows.Forms.RadioButton
    Friend WithEvents INTE6NO As System.Windows.Forms.RadioButton
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents INTE5SI As System.Windows.Forms.RadioButton
    Friend WithEvents INTE5NO As System.Windows.Forms.RadioButton
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents INTE4SI As System.Windows.Forms.RadioButton
    Friend WithEvents INTE4NO As System.Windows.Forms.RadioButton
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents INTE2SI As System.Windows.Forms.RadioButton
    Friend WithEvents INTE2NO As System.Windows.Forms.RadioButton
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents INTE1NO As System.Windows.Forms.RadioButton
    Friend WithEvents INTE1SI As System.Windows.Forms.RadioButton
    Friend WithEvents Labelpreg8 As System.Windows.Forms.Label
    Friend WithEvents Labelpreg7 As System.Windows.Forms.Label
    Friend WithEvents Labelpreg6 As System.Windows.Forms.Label
    Friend WithEvents Labelpreg5 As System.Windows.Forms.Label
    Friend WithEvents Labelpreg4 As System.Windows.Forms.Label
    Friend WithEvents Labelpreg3 As System.Windows.Forms.Label
    Friend WithEvents Labelpreg2 As System.Windows.Forms.Label
    Friend WithEvents Labelpreg1 As System.Windows.Forms.Label
    Friend WithEvents LabeltituloINTE As System.Windows.Forms.Label
    Public WithEvents TabPersonales As System.Windows.Forms.TabPage
    Friend WithEvents LabeltituloPaciente As System.Windows.Forms.Label
    Friend WithEvents txtfechahoy As System.Windows.Forms.Label
    Friend WithEvents TextRitmo As System.Windows.Forms.TextBox
    Friend WithEvents TextDNI As System.Windows.Forms.TextBox
    Friend WithEvents TextEdad As System.Windows.Forms.TextBox
    Friend WithEvents TextApellido As System.Windows.Forms.TextBox
    Friend WithEvents TextNombre As System.Windows.Forms.TextBox
    Friend WithEvents TextTelefono As System.Windows.Forms.TextBox
    Friend WithEvents TextDomicilio As System.Windows.Forms.TextBox
    Friend WithEvents txtfechaexamen As System.Windows.Forms.TextBox
    Friend WithEvents TextSintoma As System.Windows.Forms.TextBox
    Friend WithEvents LabelRitmo As System.Windows.Forms.Label
    Friend WithEvents PictureBoxECGPaciente As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBoxTuercaFondo As System.Windows.Forms.PictureBox
    Friend WithEvents LabelEdad As System.Windows.Forms.Label
    Friend WithEvents LabelApellido As System.Windows.Forms.Label
    Friend WithEvents Panelsexo As System.Windows.Forms.Panel
    Friend WithEvents botonMsexo As System.Windows.Forms.RadioButton
    Friend WithEvents botonFsexo As System.Windows.Forms.RadioButton
    Friend WithEvents LabelSexo As System.Windows.Forms.Label
    Friend WithEvents LabelDNI As System.Windows.Forms.Label
    Friend WithEvents PanelINT As System.Windows.Forms.Panel
    Friend WithEvents InternadoSI As System.Windows.Forms.RadioButton
    Friend WithEvents InternadoNO As System.Windows.Forms.RadioButton
    Friend WithEvents LabelInternado As System.Windows.Forms.Label
    Friend WithEvents LabelTelefono As System.Windows.Forms.Label
    Friend WithEvents LabelDomicilio As System.Windows.Forms.Label
    Friend WithEvents LabelNombre As System.Windows.Forms.Label
    Friend WithEvents botonbuscarexamen As System.Windows.Forms.Button
    Friend WithEvents botonBuscarpaciente As System.Windows.Forms.Button
    Friend WithEvents botonNuevopaciente As System.Windows.Forms.Button
    Friend WithEvents LabelTitulo As System.Windows.Forms.Label
    Friend WithEvents PictureBoxSalirPaciente As System.Windows.Forms.PictureBox
    Friend WithEvents Labeltecnico As System.Windows.Forms.Label
    Friend WithEvents Labelactuante As System.Windows.Forms.Label
    Friend WithEvents Labelmandante As System.Windows.Forms.Label
    Friend WithEvents tickpersonales As System.Windows.Forms.PictureBox
    Friend WithEvents botonsiguiente As System.Windows.Forms.PictureBox
    Friend WithEvents LabelFecha As System.Windows.Forms.Label
    Friend WithEvents cbxActuante As System.Windows.Forms.ComboBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents cbxTecnico As System.Windows.Forms.ComboBox
    Friend WithEvents LabelTecnicovisible As System.Windows.Forms.Label
    Friend WithEvents LabelActuantevisible As System.Windows.Forms.Label
    Friend WithEvents LabelMandantevisible As System.Windows.Forms.Label
    Friend WithEvents LabelSintoma As System.Windows.Forms.Label
    Friend WithEvents imagenfondo As System.Windows.Forms.PictureBox
    Public WithEvents TabGeneral As System.Windows.Forms.TabControl
    Friend WithEvents PictureBoxsalirgrafico As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox6 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBoxsalirServicio As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBoxsalirTiras As System.Windows.Forms.PictureBox
    Friend WithEvents CheckBoxMandanteExterno As System.Windows.Forms.CheckBox
    Public WithEvents cbxMandante As System.Windows.Forms.ComboBox
    Friend WithEvents botonBorrarEventos As System.Windows.Forms.Button
    Friend WithEvents botonTerminarExamen As System.Windows.Forms.Button
    Friend WithEvents botonSiguienteEtapa As System.Windows.Forms.Button
    Friend WithEvents PictureBoxEditarPaciente As System.Windows.Forms.PictureBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents botonAnteriorProtocolo As System.Windows.Forms.PictureBox
    Friend WithEvents botonanteriorExamen As System.Windows.Forms.PictureBox
    Friend WithEvents botonsiguienteExamen As System.Windows.Forms.PictureBox
    Friend WithEvents botonanteriorGrafico As System.Windows.Forms.PictureBox
    Friend WithEvents botonsiguienteGrafico As System.Windows.Forms.PictureBox
    Friend WithEvents botonanteriorConclusion As System.Windows.Forms.PictureBox
    Friend WithEvents TimerRecepcion As System.Windows.Forms.Timer
    Friend WithEvents TimerDisplay As System.Windows.Forms.Timer
    Friend WithEvents LabelConexionPersonales As System.Windows.Forms.Label
    Friend WithEvents LabelConexionProtocolo As System.Windows.Forms.Label
    Friend WithEvents LabelConexionExamen As System.Windows.Forms.Label
    Friend WithEvents botonEditarEvento As System.Windows.Forms.Button
    Friend WithEvents LabelPacienteDesconectado As System.Windows.Forms.Label
    Friend WithEvents LabelPacientedesconectadoprotocolo As System.Windows.Forms.Label
    Friend WithEvents LabelPacientedesconectadoExamen As System.Windows.Forms.Label
    Friend WithEvents botonCancelarEdicionEvento As System.Windows.Forms.Button
    Friend WithEvents iconoGuardarExamen As System.Windows.Forms.PictureBox
    Friend WithEvents iconoImprimirPDF As System.Windows.Forms.PictureBox
    Friend WithEvents iconoPlayPaciente As System.Windows.Forms.PictureBox
    Friend WithEvents iconoRECpaciente As System.Windows.Forms.PictureBox
    Friend WithEvents iconoRecExamen As System.Windows.Forms.PictureBox
    Friend WithEvents iconoPlayExamen As System.Windows.Forms.PictureBox
    Friend WithEvents iconoRecProtocolos As System.Windows.Forms.PictureBox
    Friend WithEvents iconoPlayProtocolos As System.Windows.Forms.PictureBox
    Friend WithEvents botonModificarPresion As System.Windows.Forms.PictureBox
    Friend WithEvents ColumnaMinutos As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColumnaSintomas As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColumnaFC As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColumnPS As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColumnPD As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
