'--------------------IMPORTACION DE BIBLIOTECAS----------------------------------------

'
Imports iTextSharp.text.pdf  'PDF 
Imports iTextSharp.text 'PDF
Imports System.IO 'IN OUT
Imports System.IO.Ports ' IN OUT
Imports System.ComponentModel
Imports System.Math ' OPERACIONES
Imports System.Data.SqlClient ' CLIENTE SQL PARA CONEXIO A BASE DE DATOS
Imports System.Windows.Forms.CommonDialog
Imports System.Drawing.Graphics ' IMPRESION DE GRAFICO
Imports System.Net.Sockets ' COMUNICACION ARDUINO
Imports System.Text
Imports System.Windows.Forms.DataVisualization.Charting


Public Class Form1

    '-----------------------VARIABLES GLOBALES---------------------------------    
    'COMUNICACIONES
    'INSTACION UN CLIENTE TCP Y STREAM DE RED
    Dim clientSocket As New System.Net.Sockets.TcpClient()
    Dim serverStream As NetworkStream

    'VECTORES DE DATOS FISIOLOGICOS Y TIEMPO 
    'PRUEBA DE 100 CADA VECTOR POR LAS DUDAS
    Dim FC(100) As Integer
    Dim PS(100) As Integer
    Dim PD(100) As Integer
    Dim INC(100) As Integer
    'pongamos a tiempo como string en lugar de integer de manera tal de poner basal y recuperacion en lugar de los numeros
    Dim tiempo(101) As String

    Dim contador As Integer = 0
    Dim aux_filas_datagrid As Integer ' AUXILIAR QUE USO PARA INCREMENTAR LAS FILAS DEL DATAGRIDVIEW DEL EXAMEN

    'PasswordP es donde cargo la contraseña de los usuarios, ahora por defecto pongo admin en caso que no se puedan cargar los usuarios
    Public passwordP As String = "admin"

    'CONTRASEÑA AUXILIAR PARA USAR CON EL OTRO FORM
    Public pass_aux As String = ""

    'MANEJO DE FECHAS DE EXAMEN Y FECHA ACTUAL
    Dim regDate As Date = Date.Now()
    Dim strDate As String = regDate.ToString("MM\/dd\/yyyy")
    Dim dia As String = regDate.Day.ToString()
    Dim mes As String = regDate.Month.ToString()
    Dim anio As String = regDate.Year.ToString()

    Public fecha_examen As Date

    'auxiliares de cronometro - estas variables globales son las que llevan el tiempo del examen
    Dim unisegundos As Integer = 0
    Dim decsegundos As Integer = 0
    Dim uniminutos As Integer = 0
    Dim decminutos As Integer = 0

    'variables globales, frecuencia no se esta utilizando, el dato se guarda en el txt de frecuencia directamente
    Dim sistolica As Integer = 0
    Dim diastolica As Integer = 0
    Dim frecuencia As Integer = 0

    'auxiliar que sirve para dar permisos de las pestañas
    Dim estado_pestañas As Integer = 1

    'leo en el auxiliar el string connection de la base de datos SQL
    Dim aux_sql As Array = File.ReadAllLines(direccion_txt & "conexionSQL.txt")
    Public aux_conexion_sql As String = aux_sql(0)

    'DECLARO MI OBJETO QUE SERA MI CONEXION A LA BASE DE DATOS 
    '----------
    'Public SQL As New SQLControl(aux_conexion_sql)
    Public SQL As New SQLControl

    'VARIABLES AUXILIARES PARA CONFIRMAR SI ES PACIENTE NUEVO O VIEJO
    Public paciente_nuevo As Boolean = False
    Public paciente_ingresado As Boolean = False
    Public examen_abierto As Boolean = False

    Public ventana_inicial As Boolean = True

    'ruta donde se guardara el pdf - se carga de una tabla de la base de datos
    Dim rutaPDF As String = ""

    'fecha de hoy
    Dim todaysdate As String = String.Format("{0:dd/MM/yyyy}", DateTime.Now)

    'asi estaba hasta el 29 de septiembre
    'Dim fechahoy As Date = DateTime.Now

    Dim fechahoy As Date = DateTime.Today

    Dim aux_datos As String = ""

    'en este string guardamos el ecg separado por saltos de linea
    Public aux_datos_ecg As String = ""
    Dim contador_ecg As ULong = 0
    Dim contador_ecg2 As ULong = 0

    'auxiliar contador de tiras de ecg
    Dim contador_tiras As Integer = 0

    'variables para deshacer cambio manuales
    'AL FINAL SERIAN MAS QUE 124 YA QUE EL NUMERO TOTAL DE MINUTOS PUEDE SER MAYOR A 30
    Dim originales(124) As String  ' 124 seria el caso extremo en que cambio de forma manual TODAS LAS CELDAS POSIBLES
    Dim columnas(124) As Integer
    Dim filas(124) As Integer
    Dim contador_cambios As Integer = 0

    Dim deshacer_estado As Boolean = False

    'variables para la adaptación de la aplicación a distintas resoluciones. 
    Public screenWidth As Integer = Screen.PrimaryScreen.Bounds.Width
    Public screenHeight As Integer = Screen.PrimaryScreen.Bounds.Height

    'variables para el archivo txt temporal donde se va a guardar de manera online los datos del examen
    'esta hecho para que sea de manera dinamica, se guarda el txt en la carpeta donde este corriendo la aplicacion
    Public direccion_txt As String = My.Application.Info.DirectoryPath ' aca guardo la dirección de la carpeta donde corre la aplicación


    'VARIABLES PARA LA DETERMINACION DEL PROTOCOLO SELECCIONADO, ES DECIR DURACION E INCLINACION DE CADA ETAPA: BASAL, ETAPA 1, ETAPA 2 Y ETAPA 3 
    Dim DUR_basal As Integer
    Dim INC_basal As Integer
    Dim DUR_etapa1 As Integer
    Dim INC_etapa1 As Integer
    Dim DUR_etapa2 As Integer
    Dim INC_etapa2 As Integer
    Dim DUR_etapa3 As Integer
    Dim INC_etapa3 As Integer
    Dim DUR_Final As Integer     'lo uso para fijarme cuanto va a durar el examen

    Dim minuto_sincope As Integer ' seria el minuto en que ocurrio el sincope al paciente

    Dim inclinacion_objetivo As Integer ' la inclinacion deseada que envio hacia el YUN
    Dim estado_basal As Boolean = False ' de estado para saber en que etapa estoy
    Dim estado_etapa1 As Boolean = False
    Dim estado_etapa2 As Boolean = False
    Dim estado_etapa3 As Boolean = False

    Dim estado_recuperacion As Boolean = False

    Dim eventos As String = "" 'por ahora eventos sirve como registro para string unicamente - candidato a volar

    Dim aux_eventos() As String     'hay que fijarse si ambos de estos se utiliza
    Dim auxiliar_eventos() As String
    Dim ventana As Integer = 300 ' ventana determina el ancho de la tira de ECG que veo
    Dim evento_iniciado As Boolean = False 'para saber cuando va a ser un iniciar evento y cuando terminar evento
    Dim contador_eventos As Integer = 0  'contador de eventos (por ahora solo manuales

    'ARREGLO EVENTOS GUARDABA TIEMPO INICIO Y FINAL COMO UN STRING, DESPEUS HABIA QUE PROCESARLO
    Dim stopW_eventos(3, 10) As String

    Dim arreglo_eventos_hora(10) As String

    'AHORA USAMOS DOS ARRAYS DE ENTEROS PARA GUARDAR POR SEPARADO TIEMPO INICIO  TIEMPO FINAL
    Dim inicio_evento(10) As Integer
    Dim fin_evento(10) As Integer

    'ACA GUARDAMOS LOS TIEMPOS DE RELOJ O USUARIO A LOS QUE CORRESPONDE EL EVENTO
    Dim inicio_Ereloj(10) As Date
    Dim fin_Ereloj(10) As Date

    'array de edicion de eventos , guardo contador inicial y final, indice de evento que estoy editando y tiempo incial y final
    Dim eventos_editados(5, 10) As String
    Dim contador_eventos_editados As Integer = 0

    'backup del evento editado
    Dim backup_editados(5, 10)

    Dim momento_cero As Integer

    'punto seleccionado del chart eventos
    Dim HTR As DataVisualization.Charting.HitTestResult
    Dim punto_chart As DataVisualization.Charting.DataPoint

    Dim Punto_entero As Integer

    'booleano para marcar inicio y final de la edicion
    Dim editando_eventos As Boolean = False

    'ACA GUARDO QUE TIPO DE EVENTO QUE ES CADA UNO, PRE-EXAMEN, BASAL, ETAPA 1,2,3 O RECUPERACION
    Dim tipos_eventos(10) As String

    Dim indice_evento As Integer 'array global para coincidir el numero de elemento de la list box sobre le cual se hace doble click con el evento correspondiente

    Dim examen_iniciado As Boolean = False ' estado para indicar si el examen ha sido iniciado 
    Dim examen_en_pausa As Boolean = False ' para unificar las funciones de iniciar y pausar el examen

    Public tiras_aux As String = ""

    Dim service_tuerca As Boolean = False

    Public estado_mandante_externo = False

    Public estado_editando_paciente_viejo = False

    'VARIABLES GRAFICAS PARA EL DISPLAY DE ECG - HABRIA QUE CAMBIAR LOS NOMBRES
    Dim bmpfondo As Drawing.Bitmap
    'auxiliares para el ECG en vivo
    Dim BMP2 As Drawing.Bitmap
    Dim GFX2 As Graphics

    Dim BMP_A4 As Drawing.Bitmap

    Dim hojaA4 As New Document(PageSize.A4)

    Dim ancho_papel As Integer = hojaA4.PageSize.Width



    Dim BMP_print As Drawing.Bitmap
    Dim GFX_print As Graphics


    'pinceles para usar
    Dim pincel_cuadrada As Pen = New Pen(Color.GreenYellow, 1.2)


    Dim rec_visible As Boolean = False

    'variables aritmeticas para el display
    'el contador recorre el ancho del display
    Dim contador_display As Integer = 0
    Dim Xinicial_display As Integer = 0
    Dim Yinicial_display As Integer = 0
    Dim ancho_display As Integer = 0
    Dim offset_display As Integer = 0




    'variables para imprimir en el informe en PDF
    Dim contador_display_print As Integer = 0
    Dim contador_rectangullos As Integer = 0
    Dim ancho_display_print As Integer = 0
    Dim xfinal As Integer = 0

    'la funcion cuadrada para mostrar en caso que no haya nada coenctado, hay que corregirla, o borrarla, 
    'se puede usar la triangular en su lugar, ya que el monitor envia una cuadrada si no hay paciente conectado
    Dim cuadrada(100) As Integer
    Dim bul_display As Boolean = False
    Dim bul_display_2 As Boolean = False
    Dim bul_display_mayor As Boolean = False

    'variables para procesar los datos recibidos de ecg
    'antes estaba -50 y 200
    Dim datos_minimo As Integer = -200
    Dim datos_maximo As Integer = 500
    Dim altura_display As Integer

    Dim datos_transformados As Integer

    Dim edicion_personales As Boolean = False
    Dim edicion_protocolo As Boolean = False

    Dim auxiliar_dni_edicion As String = ""

    'booleanos de etapas de examen
    Public estado_conexion As Boolean = False ' este no es de etapas sino de hay conexion al arduino o no
    Public CNX As Boolean = False

    Public estado_datos As Boolean = False
    Dim estado_protocolo As Boolean = False
    Dim estado_examen_ahora As Boolean = False
    Public estado_examen_viejo As Boolean = False
    Public estado_examen_terminado As Boolean = False


    Public estado_examen_viejo_recuperado As Boolean = False

    Public estado_login As Boolean = False
    Public nivel_login As Integer = 0

    Public pass_correcta As Boolean = False

    Public actividad_del_tecnico = True
    Public actividad_del_mandante = True
    Public actividad_del_actuante = True

    Public IPadres As String = ""

    'creo el string del archivo y lo abro
    Dim FILE_GENERAL As String = direccion_txt & "\GENERAL.txt"
    Dim FILE_ECG As String = direccion_txt & "\ECG.txt"
    Dim FILE_EVENTO As String = direccion_txt & "\EVENTO.txt"

    Dim escritor_general As System.IO.StreamWriter
    Dim lector_general As System.IO.StreamReader
    Dim escritor_ecg As System.IO.StreamWriter
    Dim lector_ecg As System.IO.StreamReader
    Dim escritor_evento As System.IO.StreamWriter
    Dim lector_evento As System.IO.StreamReader


    Dim editando_tecnico As Boolean = False
    Dim editando_mandante As Boolean = False
    Dim editando_actuante As Boolean = False

    Dim nuevo_tecnico As Boolean = False
    Dim nuevo_mandante As Boolean = False
    Dim nuevo_actuante As Boolean = False

    Dim contador_eje_temporal As Integer = 0
    Dim contador_ECG_nuevo As Integer = 0

    Dim promedio_por_paquete As Integer = 0


    Dim tiempo_paquetes(2, 10) As Long


    Dim contador_desconexion As Integer = 0

    Dim buffer_ECG As New Queue(Of Integer)
    Dim cant_buffer As Integer


    Dim reloj_global As New Stopwatch

    Dim tiempo_inicio_evento As Long
    Dim tiempo_final_evento As Long

    'string que utilizo para fijarme en que parte del examen recuperado quede
    Dim estado_recuperar As String

    Dim pestaña_actual As Integer = 0

    '----------------FORM LOAD - LO QUE SUCEDE CUANDO EMPIEZA A COMPILAR EL PROGRAMA---------------------
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'RELOJ GLOBAL, INICIA CUANDO SE INICIA EL PROGRAMA. HAY QUE REINICIARLO LUEGO DE CADA EXAMEN Y LUEGO DE CIERTO TIEMPO PARA EVITAR OVERFLOATS
        reloj_global.Start()
        'INICIO EL TIMER ENCARGADO DE LA COMUNICACION CON EL ARDUINO
        TimerEnvio.Enabled = True

        IsMdiContainer = True 'indica que el FORM1 puede contener a otros formularios como "hijo"

        'CARGO EL STRING DE CONEXXION SQL PARA CONECTARSE A LA BASE DE DATOS
        Dim aux_sql As Array = File.ReadAllLines(direccion_txt & "\conexionSQL.txt")
        aux_conexion_sql = aux_sql(0)

        Try
            'asi estaba antes
            'Dim SQL As New SqlConnection(aux_conexion_sql)
            SQL = New SQLControl(aux_conexion_sql)

            'Dim SQL As New SqlConnection
        Catch ex As SqlException
            'Dim SQL As New SqlConnection
            MsgBox("NO se pudo conectar al servidor SQL!")
        End Try

        'cargar la fecha de hoy
        txtfechahoy.Text = todaysdate

        'CARGO LAS GRILLAS CON LAS TABLAS DE LA BASE DE DATOS - COMO ASI TAMBIEN COMBOBOX DONDE SEA NECESARIO
        ' STAFF : TECNICO - MEDICOS MANDANTES - MEDICOS ACTUANTES
        Loadgrilla("Tecnicos", DGVtecnicos)
        Loadcombobox(cbxTecnico, "Tecnicos")
        Loadgrilla("Mandantes", DGVmedicosman)
        Loadcombobox(cbxMandante, "Mandantes")
        Loadgrilla("Actuantes", DGVmedicosact)
        Loadcombobox(cbxActuante, "Actuantes")
        'ORDENO LA POSICION Y TAMAÑO DE TODOS LOS OBJETOS DEL FORMULARIO PRINCIPAL
        Ordenar_TODO()

        'AUXILIAR - UNA VEZ CARGADA PONGO LOS VALORES DE CONTRASEÑA , RUTA DE PDF E IP adress DONDE CORRESPONDEN
        Loadgrilla("Auxiliar", DGVauxiliar)
        'CARGO LA DIRECCION IP DONDE ME VOY A CONECTAR CON EL ARDUINO
        IPadres = DGVauxiliar.Item(3, 0).Value.ToString().Trim()

        'GO_Inicio DEJA LOS BOTONES EN EL ESTADO DE INICIO- 
        GO_Inicio()
        'VARIABLE AUXILIAR DE CONEXION AL ARDUINO
        Dim auxiliar_cone As Boolean
        'PRUEBO HACER UN PING A LA DIRECCION IP DEL ARDUINO
        Try
            auxiliar_cone = My.Computer.Network.Ping(IPadres, 2500)
            ' auxiliar_cone = My.Computer.Network.Ping("192.168.1.101", 2500)
        Catch ex As Exception
            MsgBox("No hay ninguna conexion de red", MsgBoxStyle.Exclamation, "Tilt Test")
        End Try
        'SI EL PING RESPONDIO BIEN, INTENTO CONECTARME AL ARDUINO
        If auxiliar_cone Then

            estado_conexion = True
            CNX = True
            Try
                clientSocket.Connect(IPadres, 255) ' TRATO DE CONECTARME, SI NO PUEDO LE DIGO AL USUARIO QUE VERIFIQUE LA DIRECCION IP,
            Catch ex As Exception                   'YA QUE EL PING HABIA RESPONDIDO ORIGINALMENTE
                MsgBox("Verifique la direccion IP!")
                estado_conexion = False
                'MODIFICO LOS LABEL DE ESTADO DE CONEXION
                LabelConexionPersonales.Text = "OFFLINE"
                LabelConexionPersonales.BackColor = Color.Tomato
                LabelConexionProtocolo.Text = "OFFLINE"
                LabelConexionProtocolo.BackColor = Color.Tomato
                LabelConexionExamen.Text = "OFFLINE"
                LabelConexionExamen.BackColor = Color.Tomato

            End Try

        Else
            If MsgBox("No se ha podido conectar al arduino. Desea ingresar en el modo offline?", MsgBoxStyle.YesNo, "SIN CONEXIÓN") = MsgBoxResult.Yes Then
                estado_conexion = False
                LabelConexionPersonales.Text = "OFFLINE"
                LabelConexionPersonales.BackColor = Color.Tomato
                LabelConexionProtocolo.Text = "OFFLINE"
                LabelConexionProtocolo.BackColor = Color.Tomato
                LabelConexionExamen.Text = "OFFLINE"
                LabelConexionExamen.BackColor = Color.Tomato
                'SI EL PING NO RESPONDIO , DIGO QUE NO SE PUDO CONECTAR NOMAS
            Else
                Me.Close() ' SI NO QUIEREN ENTRAR EN MODO OFFLINE , CIERRO EL PROGRAMA
                Exit Sub
            End If
        End If

        'ahora hay que poner los valores en contraseña y ruta, SI NO HAY NADA PONGO UN VALOR ESTATICO
        Try
            rutaPDF = DGVauxiliar.Item(1, 0).Value.ToString().Trim()
        Catch ex As Exception
            rutaPDF = "C:\" ' COLOCO CARPETA C, PODRIAMOS BUSCAR EL ESCRITORIO DE LA PC ACTUAL POR DEFECTO
        End Try

        Try
            passwordP = DGVauxiliar.Item(2, 0).Value.ToString().Trim()
        Catch ex As Exception
            passwordP = "admin" ' COLOCO ADMIN POR DEFECTO EN CASO QUE NO SE PUEDA CARGAR CONTRASEÑA DE LA BASE DE DATOS
        End Try

        'CARGO LA COMBOBOX DE PLANTILLAS
        Loadcomboboxplantilla(cbxConclusiones, "Plantillas")
        'PROTOCOLOS - Y LUEGO SU COMBOBOX
        Loadgrilla("Protocolos", DGVprotocolo)
        Loadcomboboxprotocolo(ComboBoxProtocolo, "Protocolos")
        'para que la columna de minutos no se pueda cambiar
        DatosExamen.Columns("ColumnaMinutos").ReadOnly = True ' LA COLUMNA MINUTOS NO SE PUEDE CAMBIAR

        'INICIALIZO EL VECTOR TIEMPO, A FUTURO QUIZAS DEPENDERÍA DEL PROTOCOLO, QUIZAS PARA SIMPLIFICAR
        ' HACER QUE SOLO SE PUEDAN PROTOCOLOS DE 30 MINS
        For i As Integer = 0 To 30
            tiempo(i) = i
        Next
        'oculto la ventana para PERSONAL Y SERVICIO TECNICO
        Personal.Hide()
        'FORMATO DEL GRAPHIC CHART 1 - EL QUE HACE EL GRAFICO PRINCIPAL
        Chart1.ChartAreas(0).AxisY.Title = "Frecuencia Cardíaca [LPM] / Presión Arterial [mmHg]"
        Chart1.ChartAreas(0).AxisY2.Enabled = DataVisualization.Charting.AxisEnabled.True
        Chart1.ChartAreas(0).AxisY2.Title = "Inclinación [°]"
        ' Chart1.ChartAreas(0).AxisY2.LabelStyle.Font = Drawing.Font.("")
        Chart1.ChartAreas(0).AxisX.Minimum = 0
        'FORMATO DEL CHART DE EVENTOS
        ChartEventos.ChartAreas(0).AxisX.Title = "Tiempo [min:seg]"
        ChartEventos.ChartAreas(0).CursorX.AutoScroll = True
        ChartEventos.ChartAreas(0).AxisX.Interval = 50

        'ARRANCO CON EL RADIO BUTTON DE TECNICOS CLICKEADO EN SERVICIO
        RadioButtonTecnicos.Checked = True
        'CONFIGURO EL BIT DRAWING MAP
        BMP2 = New Drawing.Bitmap(PictureBoxECG.Width, PictureBoxECG.Height)
        GFX2 = Graphics.FromImage(BMP2)
        'Dim aux_entero As Integer = BMP2.Width / 2
        Dim aux_entero As Integer = BMP2.Width / 1

        'PROBAMOS CON ANCHO DEL A4 
        BMP_print = New Drawing.Bitmap(1751, 301)
        BMP_A4 = New Drawing.Bitmap(ancho_papel, PictureBoxECG.Height)
        Dim anchura As Integer = Convert.ToInt16(ancho_papel * 0.9)
        ' BMP_print = New Drawing.Bitmap(anchura, PictureBoxECG.Height)
        GFX_print = Graphics.FromImage(BMP_print)
        'CREO UNA FUNCION CUADRADA PARA MOSTRAR EN LA VENTANA DE ECG EN CASO DE QUE NO HAYA SEÑAL
        For i As Integer = 0 To 12
            cuadrada(i) = 40
        Next
        For i As Integer = 13 To 25
            cuadrada(i) = -40
        Next
        'OFFSET DE LA SEÑAL DE ECG
        offset_display = PictureBoxECG.Height * 0.5
        Yinicial_display = offset_display

        'INICIO EL TIMER DE LA PANTALLA, MIDE VARIAS COSAS: DESCONEXION AL ARDUINO, CAMBIO DE PANTALLA Y MAS
        TimerScreen.Enabled = True

        'hay que leerlo solo si el login es exitoso!
        nivel_login = Login.nivel_login
        chequear_accesos()
        'leo los txt para ver si hay algun estudio que se haya interrumpido y hay que recuperar
        leer_txt()
        Ordenar_TODO() ' ORDENO DE NUEVO
        'INICIO LOS TIMER ENVIO, RECEPCION Y SCREEN 
        TimerEnvio.Enabled = True  'NO HABIA ARRANCADO ANTES?
        TimerRecepcion.Enabled = True
        TimerScreen.Enabled = True  'NO HABIA ARRANCADO ANTES?
        'TIMER DEL TIEMPO REAL EN LA PARTE DE EXAMEN
        TimerDisplay.Enabled = True

        '  orden_tabulacion_inicio()

    End Sub

    'EVENTO: CAMBIA EL INDICE DE LA COMBOBOX DE PROTOCOLOS - BUSCA EL PROTOCOLO EN LA BASE DE DATOS Y LO CARGA EN LAS VARIABLES LOCALES
    Private Sub ComboBoxProtocolo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxProtocolo.SelectedIndexChanged
        Dim protocoloNombre As String = ComboBoxProtocolo.Text
        SQL.AddParam("@nombreprotocolo", protocoloNombre)
        SQL.ExecQuery("SELECT Descripcion From Protocolos WHERE Nombre=@nombreprotocolo;")
        If SQL.HasException(True) Then Exit Sub
        For Each r As DataRow In SQL.DBDT.Rows
            Dim a0 As String = r("Descripcion")
            TextProtocolo.Text = a0
        Next

        SQL.AddParam("@nombreprotocolo", protocoloNombre)
        SQL.ExecQuery("SELECT DuracionBasal , InclinacionBasal , DUracionE1, InclinacionE1 , DUracionE2, InclinacionE2 ,DUracionE3, InclinacionE3  From Protocolos WHERE Nombre=@nombreprotocolo;")
        If SQL.HasException(True) Then Exit Sub
        For Each r As DataRow In SQL.DBDT.Rows

            DUR_basal = r("DuracionBasal")
            INC_basal = r("InclinacionBasal")
            DUR_etapa1 = r("DuracionE1")
            INC_etapa1 = r("InclinacionE1")

            Try
                DUR_etapa2 = r("DuracionE2")
            Catch ex As Exception
                DUR_etapa2 = 0
            End Try

            Try
                INC_etapa2 = r("InclinacionE2")
            Catch ex As Exception
                INC_etapa2 = 0
            End Try

            Try
                DUR_etapa3 = r("DuracionE3")
            Catch ex As Exception
                DUR_etapa3 = 0
            End Try

            Try
                INC_etapa3 = r("InclinacionE3")
            Catch ex As Exception
                INC_etapa3 = 0
            End Try

        Next

        DUR_Final = DUR_etapa1 + DUR_etapa2 + DUR_etapa3
    End Sub

    'SUBRUTINA INICIAR EXAMEN EN LA ETAPA BASAL
    Sub Iniciar_examen_en_basal()
        If examen_iniciado = False Then
            'botonECG.Enabled = True 'HABILITO BOTON DE TIRAS DE ECG
            DatosExamen.Columns("ColumnaMinutos").ReadOnly = True ' LA COLUMNA MINUTOS NO SE PUEDE CAMBIAR
            'SI NO SE INGRESO UN PACIENTE NO SE PUEDE INICIAR- UN POCO REDUNDANTE
            If paciente_ingresado = False Then
                MsgBox("No se ha ingresado un paciente!")
                Exit Sub
            End If
            'HABILITO OTROS BOTONES DEL EXAMEN
            'botonPresion.Enabled = True
            'VARIABLE AUXILIAR- PODRIA PONERLE UN NOMBRE MAS DESCRIPTIVO
            aux_filas_datagrid = 0

            'CAMBIO EL TEXTO DEL BOTON DE "INICIAR EXAMEN" A "INICIADO"
            LabelTiempo.Text = "Basal:"
            '  IniciarExamen.Text = "Iniciado"
            txtsistolica.Text = "---" 'sistolica  ' MUESTRO LOS VALORES DE PRESION 
            txtdiastolica.Text = "---" 'diastolica
            'ACTIVO EL TIMER REAL DEL EXAMEN
            TimerReal.Enabled = True

            'FALTARIA QUE EN UN LUGAR DIGA QUE ES LA ETAPA BASAL, SE ACA O EN EL TIMER, DEPENDE DESPUES DE TODO DE LA ETAPA Y ESO DEPENDE DEL PROTOCOLO ELEGIDO
            'INDICO QUE PASAMOS A LA ETAPA BASAL
            estado_basal = True
            ' Labeletapa.Text = "Basal"
            inclinacion_objetivo = INC_basal

            Try
                Enviar_INO(inclinacion_objetivo)
            Catch ex As Exception

            End Try
            'HABILITO BOTONES DE PRESION
            botonPresion.Enabled = True
            botonModificarPresion.Enabled = True
            botonModificarPresion.Visible = True
            'INDICO ESTADO DE EXAMEN INICIADO COMO TRUE
            examen_iniciado = True
            'HABILITO BOTON DE TERMINAR EXAMEN
            botonTerminarExamen.Enabled = False
            botonTerminarExamen.Visible = False
            'HABILITO BOTON DE TERMINAR BASAL
            botonSiguienteEtapa.Enabled = True
            botonSiguienteEtapa.Visible = True
        End If
    End Sub

    'EVENTO: TICK DEL TimerECG: ENVIA PETICION DE ECG AL ARDUINO
    Private Sub TimerEnvio_Tick(sender As Object, e As EventArgs) Handles TimerEnvio.Tick
        If estado_conexion = True Then
            Try
                EnviarDatos("CNX")
            Catch ex As Exception

            End Try
        End If
    End Sub

    'SUBRUTINA QUE IMPRIME EL PDF DEL EXAMEN
    Sub Imprimir_PDF()
        'COMO LA SUBRUTINA PUEDE DEMORAR Y CAUSAR UNA DESCONEXION, ENVIO CONFIRMACION DE CONEXIO ANTES DE EMPEZARLA
        Try
            EnviarDatos("CNX")
        Catch ex As Exception
        End Try
        'GUARDO LA IMAGEN DEL CHART1 QUE TIENE MIS DATOS- la modifico para que sea en la misma carpeta que el pdf
        Try
            Chart1.SaveImage(rutaPDF & "\examen.png", System.Drawing.Imaging.ImageFormat.Png)
        Catch ex As Exception
            MsgBox("problema con ubicacion del .png")
        End Try

        'TabGeneral.SelectedTab = TabPersonales
        Dim bmp_personales As New Bitmap(870, 485) ' LO USO????

        TabGeneral.DrawToBitmap(bmp_personales, Me.DisplayRectangle) ' LO USO???

        ' bmp_personales.Save("C:\Users\Facundo\Desktop\Favaloro\T T T T\TiltTest\personales.png", System.Drawing.Imaging.ImageFormat.Png)
        'CREO UN DOCUMENTO PDF CON TAMAÑO A4
        Dim PDFdoc As New Document(PageSize.A4)
        'ANCHO Y ALTO DEL PAPEL A4
        Dim ancho_papel_local As Integer = PDFdoc.PageSize.Width
        Dim alto_papel As Integer = PDFdoc.PageSize.Height
        'este es el original que funcionaba
        'Dim PDFWrite As PdfWriter = PdfWriter.GetInstance(PDFdoc, New FileStream("C:\Users\Facundo\Desktop\Favaloro\T T T T\TiltTest\Tilt Test-" & TextNombre.Text & " " & TextApellido.Text & " " & dia & "-" & mes & "-" & anio & ".pdf", FileMode.Create))

        'DATOS DE LA FECHA 
        Dim dia_ex As String = fecha_examen.Day
        Dim mes_ex As String = fecha_examen.Month
        Dim anio_ex As String = fecha_examen.Year

        '  Dim PDFWrite As PdfWriter = PdfWriter.GetInstance(PDFdoc, New FileStream(rutaPDF & "\" & TextNombre.Text.Trim() & " " & TextApellido.Text.Trim() & " " & dia & "-" & mes & "-" & anio & ".pdf", FileMode.Create))
        'CREO UN ARCHIVO PDF QUE TIENE LA RUTA INDICADA EN LA BASE DE DATOS Y ARMO EL NOMBRE DEL MISMO CON LOS DATOS DEL EXAMEN
        Try
            Dim PDFWrite As PdfWriter = PdfWriter.GetInstance(PDFdoc, New FileStream(rutaPDF & "\" & TextNombre.Text.Trim() & " " & TextApellido.Text.Trim() & " " & dia_ex & "-" & mes_ex & "-" & anio_ex & ".pdf", FileMode.Create))
        Catch ex As Exception
            MsgBox("PEDF abierto")
            Exit Sub
        End Try
        'NUEVAMENTE ENVIO DATOS DE CONEXION AL ARDUINO PARA EVITAR DESCONEXION POR LA DEMORA
        Try
            EnviarDatos("CNX")
        Catch ex As Exception

        End Try
        'ABRO EL DOCUMENTO PDF
        PDFdoc.Open()
        'CREO UN NUEVO PARRAFO
        Dim para As New Paragraph("", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 22, iTextSharp.text.Font.NORMAL))
        para.Alignment = 1
        PDFdoc.Add(para)
        'CREO IMAGEN CON EL ICONO DE FAVALORO
        Dim icono As Image = Image.GetInstance(direccion_txt & "\iconofavaloro.png")
        icono.ScalePercent(50.0F) ' CONFIGURO EL TAMAÑO DEL ICONO
        icono.ScaleToFit(250.0F, 250.0F)
        PDFdoc.Add(icono) ' AÑADO EL ICONO AL PDF

        'NUEVO PARRAFO PARA EL TITULO
        para = New Paragraph("Examen de Movimiento Oscilatorio Corporal" & vbCrLf & vbCrLf)
        para.Alignment = 1
        para.Font.Size = 22
        para.Font.SetStyle(FontFactory.COURIER_BOLD)
        PDFdoc.Add(para) ' CONFIGURO Y AÑADIO EL PARRAFO

        '--------------------------------------------------
        'CREO UNA TABLA INVISIBLE PARA PONER LOS DATOS PERSONALES DEL EXAMEN EN TRES COLUMNAS
        Dim tabla As New PdfPTable(3)
        tabla.DefaultCell.Border = Rectangle.NO_BORDER
        tabla.HorizontalAlignment = 1
        Dim anchos(2) As Single
        anchos(0) = (ancho_papel_local - PDFdoc.RightMargin - PDFdoc.LeftMargin) / 2.6 ' CONFIGURO LOS MARGENES DE LA MISMA
        anchos(1) = (ancho_papel_local - PDFdoc.RightMargin - PDFdoc.LeftMargin) / 2.6
        anchos(2) = (ancho_papel_local - PDFdoc.RightMargin - PDFdoc.LeftMargin) / 2.6
        tabla.WidthPercentage = 100 'ANCHO DE LA TABLA

        'CREO UNA CELDA PARA INCLUIR EL TITULO DEL EXAMEN, LA MISMA CELDA OCUPAR MAS DE UNA COLUMNA
        Dim celda As New PdfPCell(New Phrase("Examen de Movimiento Oscilatorio Corporal")) ' ARRIBA PONGO EL TITULO, NUNCA IMPRIMO LA CELDA EN EL PDF CON EL TITULO
        celda.Rowspan = 2
        celda.Colspan = 1
        celda.HorizontalAlignment = 0
        '0=izq 1=centro 2=derecha
        celda.FixedHeight = 20
        celda.Border = Rectangle.NO_BORDER

        'REDEFINO LA MISMA CELDA PARA IMPRIMIR OTROS TEXTOS
        celda = New PdfPCell(New Phrase("Nombre: " & TextNombre.Text.Trim()))
        celda.Border = Rectangle.NO_BORDER
        celda.Rowspan = 2
        celda.Colspan = 1
        celda.HorizontalAlignment = 0
        celda.FixedHeight = 20
        tabla.AddCell(celda)    ' AÑADIO LA CELDA A LA TABLA
        'REDEFINO LA MISMA CELDA PARA IMPRIMIR OTRO TEXTO
        celda = New PdfPCell(New Phrase("Apellido: " & TextApellido.Text.Trim()))
        celda.Border = Rectangle.NO_BORDER
        celda.Rowspan = 2
        celda.Colspan = 1
        celda.HorizontalAlignment = 0
        celda.FixedHeight = 20
        tabla.AddCell(celda)
        'REDEFINO CELDA
        celda = New PdfPCell(New Phrase("Edad: " & TextEdad.Text.Trim()))
        celda.Border = Rectangle.NO_BORDER
        celda.Rowspan = 2
        celda.Colspan = 1
        celda.HorizontalAlignment = 0
        celda.FixedHeight = 20
        tabla.AddCell(celda)
        'REDEFINO CELDA
        celda = New PdfPCell(New Phrase("DNI: " & TextDNI.Text.Trim()))
        celda.Border = Rectangle.NO_BORDER
        celda.Rowspan = 2
        celda.Colspan = 1
        celda.HorizontalAlignment = 0
        celda.FixedHeight = 20
        tabla.AddCell(celda)
        'REDEFINO CELDA
        celda = New PdfPCell(New Phrase("Domicilio: " & TextDomicilio.Text.Trim()))
        celda.Border = Rectangle.NO_BORDER
        celda.Rowspan = 2
        celda.Colspan = 1
        celda.HorizontalAlignment = 0
        celda.FixedHeight = 20
        tabla.AddCell(celda)
        'REDEFINO CELDA
        celda = New PdfPCell(New Phrase("Teléfono: " & TextTelefono.Text.Trim()))
        celda.Border = Rectangle.NO_BORDER
        celda.Rowspan = 2
        celda.Colspan = 1
        celda.HorizontalAlignment = 0
        celda.FixedHeight = 20
        tabla.AddCell(celda)
        'TRANSFORMO LA LOGICA BINARIA DEL SEXO EN TEXTO Y REDEFINO CELDA
        Dim sex As String = ""
        If botonMsexo.Checked = True Then sex = "Masculino"
        If botonFsexo.Checked = True Then sex = "Femenino"
        celda = New PdfPCell(New Phrase("Sexo: " & sex))
        celda.Border = Rectangle.NO_BORDER
        celda.Rowspan = 2
        celda.Colspan = 1
        celda.HorizontalAlignment = 0
        celda.FixedHeight = 20
        celda.Rowspan = 2
        celda.Colspan = 1
        celda.HorizontalAlignment = 0
        celda.FixedHeight = 20
        tabla.AddCell(celda)
        'IDEM PARA INTERNACION
        Dim inter As String = ""
        If InternadoSI.Checked = True Then inter = "Si"
        If InternadoNO.Checked = True Then inter = "No"
        celda = New PdfPCell(New Phrase("Internado: " & inter))
        celda.Border = Rectangle.NO_BORDER
        celda.Rowspan = 2
        celda.Colspan = 1
        celda.HorizontalAlignment = 0
        celda.FixedHeight = 20
        tabla.AddCell(celda)
        'REDEFINO CELDA
        celda = New PdfPCell(New Phrase("Fecha: " & txtfechaexamen.Text.Trim()))
        celda.Border = Rectangle.NO_BORDER
        celda.Rowspan = 2
        celda.Colspan = 1
        celda.HorizontalAlignment = 0
        celda.FixedHeight = 20
        tabla.AddCell(celda)
        'LUEGO DE METER TODAS LAS CELDAS, IMPRIMO LA TABLA EN EL PDF
        PDFdoc.Add(tabla)

        'AÑADIO UN PARRAFO VACIO PARA ESPACIAR
        para = New Paragraph("  ", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18, iTextSharp.text.Font.NORMAL))
        para.Alignment = 1
        PDFdoc.Add(para)

        'HAGO OTRA TABLA    PARA RITMO DE BASE, SINTOMAS Y PERSONAL MEDICO
        Dim tabla2 As New PdfPTable(2)
        tabla.DefaultCell.Border = Rectangle.NO_BORDER
        tabla.HorizontalAlignment = 1
        Dim anchos2(1) As Single
        anchos2(0) = (ancho_papel_local - PDFdoc.RightMargin - PDFdoc.LeftMargin) / 1.8
        anchos2(1) = (ancho_papel_local - PDFdoc.RightMargin - PDFdoc.LeftMargin) / 1.8
        tabla2.WidthPercentage = 100
        Dim celda2 As New PdfPCell(New Phrase("Examen de Movimiento Oscilatorio Corporal"))
        celda2.Rowspan = 2
        celda2.Colspan = 1
        celda2.HorizontalAlignment = 0
        '0=izq 1=centro 2=derecha
        celda2.FixedHeight = 20
        celda2.Border = Rectangle.NO_BORDER
        'REDEFINO CELDA
        celda2 = New PdfPCell(New Phrase("Ritmo de Base: " & TextRitmo.Text.Trim()))
        celda2.Border = Rectangle.NO_BORDER
        celda2.Rowspan = 2
        celda2.Colspan = 1
        celda2.HorizontalAlignment = 0
        celda2.FixedHeight = 20
        tabla2.AddCell(celda2)
        'REDEFINO CELDA
        celda2 = New PdfPCell(New Phrase("Síntoma de Ingreso: " & TextSintoma.Text.Trim()))
        celda2.Border = Rectangle.NO_BORDER
        celda2.Rowspan = 2
        celda2.Colspan = 1
        celda2.HorizontalAlignment = 0
        celda2.FixedHeight = 20
        tabla2.AddCell(celda2)
        'LOGICA PARA PASAR PERSONAL MANDANTE A TEXTO
        Dim aux_personal As String = cbxMandante.Text.Trim()
        If estado_mandante_externo = False Then
            aux_personal = aux_personal.Substring(3)
        End If
        celda2 = New PdfPCell(New Phrase("Médico Mandante: " & aux_personal))
        celda2.Border = Rectangle.NO_BORDER
        celda2.Rowspan = 2
        celda2.Colspan = 1
        celda2.HorizontalAlignment = 0
        celda2.FixedHeight = 20
        tabla2.AddCell(celda2)
        'AHORA INGRESO ACTUANTE
        aux_personal = cbxActuante.Text.Trim()
        aux_personal = aux_personal.Substring(3)
        celda2 = New PdfPCell(New Phrase("Médico Actuante: " & aux_personal))
        celda2.Border = Rectangle.NO_BORDER
        celda2.Rowspan = 2
        celda2.Colspan = 1
        celda2.HorizontalAlignment = 0
        celda2.FixedHeight = 20
        tabla2.AddCell(celda2)
        'AHORA INGRESO TECNICO
        aux_personal = cbxTecnico.Text.Trim()
        aux_personal = aux_personal.Substring(3)
        celda2 = New PdfPCell(New Phrase("Técnico: " & aux_personal))
        celda2.Border = Rectangle.NO_BORDER
        celda2.Rowspan = 2
        celda2.Colspan = 1
        celda2.HorizontalAlignment = 0
        celda2.FixedHeight = 20
        tabla2.AddCell(celda2)
        'ESPACIO EN BLANCO
        celda2 = New PdfPCell(New Phrase(" "))
        celda2.Border = Rectangle.NO_BORDER
        celda2.Rowspan = 2
        celda2.Colspan = 1
        celda2.HorizontalAlignment = 0
        celda2.FixedHeight = 20
        tabla2.AddCell(celda2)
        'AÑADIO LA SEGUNDA TABLA AL PDF
        PDFdoc.Add(tabla2)

        '--------------------
        'AGREGO TITULO DE INTERROGATORIO
        para = New Paragraph("Interrogatorio" & vbCrLf)
        para.Alignment = 1
        para.Font.Size = 18
        para.Font.SetStyle(FontFactory.HELVETICA_BOLD)
        PDFdoc.Add(para)
        'PREUGNTA UNO
        If (INTE1SI.Checked = True) Then
            para = New Paragraph("1-¿Tuvo algún episodio de Síncope? : Si" & vbCrLf)
            para.Alignment = 0
            para.Font.Size = 13
            para.Font.SetStyle(FontFactory.HELVETICA)
            PDFdoc.Add(para)
        Else
            If (INTE1NO.Checked = True) Then
                para = New Paragraph("1-¿Tuvo algún episodio de Síncope? : No" & vbCrLf)
                para.Alignment = 0
                para.Font.Size = 13
                para.Font.SetStyle(FontFactory.HELVETICA)
                PDFdoc.Add(para)
            End If
        End If
        'PREGUNTA DOS
        If (INTE2SI.Checked = True) Then
            para = New Paragraph("2-¿Tuvo algún síntoma previo al desmayo? : Si" & vbCrLf)
            para.Alignment = 0
            para.Font.Size = 13
            para.Font.SetStyle(FontFactory.HELVETICA)
            PDFdoc.Add(para)
        Else
            If (INTE2NO.Checked = True) Then
                para = New Paragraph("2-¿Tuvo algún síntoma previo al desmayo? : No" & vbCrLf)
                para.Alignment = 0
                para.Font.Size = 13
                para.Font.SetStyle(FontFactory.HELVETICA)
                PDFdoc.Add(para)
            End If
        End If
        'PREGUNTA 3
        If (INTE2SI.Checked = True) Then
            para = New Paragraph("3-¿Cuáles? : " & TextINTE3.Text & vbCrLf)
            para.Alignment = 0
            para.Font.Size = 13
            para.Font.SetStyle(FontFactory.HELVETICA)
            PDFdoc.Add(para)
        Else
            If (INTE2NO.Checked = True) Then
                para = New Paragraph("3-¿Cuáles? :------ " & vbCrLf)
                para.Alignment = 0
                para.Font.Size = 13
                para.Font.SetStyle(FontFactory.HELVETICA)
                PDFdoc.Add(para)
            End If
        End If
        'PREGUNTA 4
        If (INTE4SI.Checked = True) Then
            para = New Paragraph("4-¿Alguna vez se golpeó seriamente? : Si" & vbCrLf)
            para.Alignment = 0
            para.Font.Size = 13
            para.Font.SetStyle(FontFactory.HELVETICA)
            PDFdoc.Add(para)
        Else
            If (INTE4NO.Checked = True) Then
                para = New Paragraph("4-¿Alguna vez se golpeó seriamente? : No" & vbCrLf)
                para.Alignment = 0
                para.Font.Size = 13
                para.Font.SetStyle(FontFactory.HELVETICA)
                PDFdoc.Add(para)
            End If
        End If
        'PREGUNTA 5
        If (INTE5SI.Checked = True) Then
            para = New Paragraph("5-¿El desmayo fue presenciado por algún testigo? : Si" & vbCrLf)
            para.Alignment = 0
            para.Font.Size = 13
            para.Font.SetStyle(FontFactory.HELVETICA)
            PDFdoc.Add(para)
        Else
            If (INTE5NO.Checked = True) Then
                para = New Paragraph("5-¿El desmayo fue presenciado por algún testigo? : No" & vbCrLf)
                para.Alignment = 0
                para.Font.Size = 13
                para.Font.SetStyle(FontFactory.HELVETICA)
                PDFdoc.Add(para)
            End If
        End If
        'PREGUNTA 6
        If (INTE6SI.Checked = True) Then
            para = New Paragraph("6-¿Tuvo convulsiones? : Si" & vbCrLf)
            para.Alignment = 0
            para.Font.Size = 13
            para.Font.SetStyle(FontFactory.HELVETICA)
            PDFdoc.Add(para)
        Else
            If (INTE6NO.Checked = True) Then
                para = New Paragraph("6-¿Tuvo convulsiones? : No" & vbCrLf)
                para.Alignment = 0
                para.Font.Size = 13
                para.Font.SetStyle(FontFactory.HELVETICA)
                PDFdoc.Add(para)
            Else
                If (INTE6NOSABE.Checked = True) Then
                    para = New Paragraph("6-¿Tuvo convulsiones? : No sabe" & vbCrLf)
                    para.Alignment = 0
                    para.Font.Size = 13
                    para.Font.SetStyle(FontFactory.HELVETICA)
                    PDFdoc.Add(para)
                End If
            End If
        End If
        'PREGUNTA 7
        If (INTE7SI.Checked = True) Then
            para = New Paragraph("7-¿Tuvo incontinencia de esfínter? : Si" & vbCrLf)
            para.Alignment = 0
            para.Font.Size = 13
            para.Font.SetStyle(FontFactory.HELVETICA)
            PDFdoc.Add(para)
        Else
            If (INTE7NO.Checked = True) Then
                para = New Paragraph("7-¿Tuvo incontinencia de esfínter? : No" & vbCrLf)
                para.Alignment = 0
                para.Font.Size = 13
                para.Font.SetStyle(FontFactory.HELVETICA)
                PDFdoc.Add(para)
            End If
        End If
        'PREGUNTA 8
        If (INTE8SI.Checked = True) Then
            para = New Paragraph("8-¿Está recibiendo alguna medicación? : Si" & vbCrLf)
            para.Alignment = 0
            para.Font.Size = 13
            para.Font.SetStyle(FontFactory.HELVETICA)
            PDFdoc.Add(para)
        Else
            If (INTE8NO.Checked = True) Then
                para = New Paragraph("8-¿Está recibiendo alguna medicación? : No" & vbCrLf)
                para.Alignment = 0
                para.Font.Size = 13
                para.Font.SetStyle(FontFactory.HELVETICA)
                PDFdoc.Add(para)
            End If
        End If
        'PREGUNTA 9
        If (INTE8SI.Checked = True) Then
            para = New Paragraph("9-¿Cuáles? : " & TextINTE9.Text & vbCrLf)
            para.Alignment = 0
            para.Font.Size = 13
            para.Font.SetStyle(FontFactory.HELVETICA)
            PDFdoc.Add(para)
        Else
            If (INTE8NO.Checked = True) Then
                para = New Paragraph("9-¿Cuáles? :------ " & vbCrLf)
                para.Alignment = 0
                para.Font.Size = 13
                para.Font.SetStyle(FontFactory.HELVETICA)
                PDFdoc.Add(para)
            End If
        End If
        'AGREGO LA PARTE DE PROTOCOLO - PRIMERO TITULO
        para = New Paragraph("Protocolo" & vbCrLf)
        para.Alignment = 1
        para.Font.Size = 18
        para.Font.SetStyle(FontFactory.HELVETICA)
        PDFdoc.Add(para)
        'AGREGO EL TEXTO DEL PROTOCOLO
        para = New Paragraph(TextProtocolo.Text & vbCrLf & vbCrLf)
        para.Alignment = 0
        para.Font.Size = 13
        para.Font.SetStyle(FontFactory.HELVETICA)
        PDFdoc.Add(para)
        'AGREGO EL TITULO DE CONCLUSION
        para = New Paragraph("Conclusión" & vbCrLf)
        para.Alignment = 1
        para.Font.Size = 18
        para.Font.SetStyle(FontFactory.HELVETICA)
        PDFdoc.Add(para)
        'AGREGO EL TEXTO DE CONCLUSION
        para = New Paragraph(conclusiontext.Text & vbCrLf & vbCrLf)
        para.Alignment = 0
        para.Font.Size = 13
        para.Font.SetStyle(FontFactory.HELVETICA)
        PDFdoc.Add(para)

        'ENVIO DATOS DE CONEXION PARA EVITAR DESCONEXION POR DEMASIADO TIEMPO TRANSCURRIDO
        Try
            EnviarDatos("CNX")
        Catch ex As Exception

        End Try
        'CREO UNA NUEVA PAGINA EN EL PDF
        PDFdoc.NewPage()
        'CREO UNA TABLA DE CINCO COLUMNAS PARA LOS DATOS DEL EXAMEN
        Dim table As New PdfPTable(5)
        Dim cell As New PdfPCell(New Phrase("Examen de Movimiento Oscilatorio Corporal"))
        table.SetWidths({40.0F, 70.0F, 60.0F, 60.0F, 60.0F})
        cell.Colspan = 5
        cell.HorizontalAlignment = 1
        '0=izq 1=centro 2=derecha
        table.AddCell(cell)
        'AÑADIO TITULOS A LAS COLUMNAS
        table.AddCell("Minutos")
        table.AddCell("Síntomas")
        table.AddCell("Frecuencia" & vbCrLf & "Cardíaca" & vbCrLf & "(LPM)")
        table.AddCell("Tensión" & vbCrLf & "Sistólica " & vbCrLf & "(mmHg)")
        table.AddCell("Tensión" & vbCrLf & "Diastólica" & vbCrLf & "(mmHg)")
        'INGRESO LOS DATOS DEL EXAMEN
        Try
            'POR CADA FILA DE LA TABLA INGRESO LOS DATOS DE TODAS LAS COLUMNAS
            For k As Integer = 0 To (DatosExamen.RowCount - 1)
                'COL 1
                cell = New PdfPCell(New Phrase(DatosExamen.Rows(k).Cells(0).Value.ToString().Trim()))
                cell.HorizontalAlignment = 1
                table.AddCell(cell)
                'COL2
                cell = New PdfPCell(New Phrase(DatosExamen.Rows(k).Cells(1).Value.ToString().Trim()))
                cell.HorizontalAlignment = 1
                table.AddCell(cell)
                'COL3
                cell = New PdfPCell(New Phrase(DatosExamen.Rows(k).Cells(2).Value.ToString().Trim()))
                cell.HorizontalAlignment = 1
                table.AddCell(cell)
                'COL4
                cell = New PdfPCell(New Phrase(DatosExamen.Rows(k).Cells(3).Value.ToString().Trim()))
                cell.HorizontalAlignment = 1
                table.AddCell(cell)
                'COL5
                cell = New PdfPCell(New Phrase(DatosExamen.Rows(k).Cells(4).Value.ToString().Trim()))
                cell.HorizontalAlignment = 1
                table.AddCell(cell)
            Next
        Catch ex As Exception
            MsgBox("No hay datos")
        End Try
        'AÑADIO LA TABLA DE DATOS AL PDF
        PDFdoc.Add(table)
        'CREO UNA NUEVA PAGINA
        PDFdoc.NewPage()
        'CREO UNA IMAGEN QUE CONTENGA LA IMAGEN DEL GRAFICO DEL EXAMEN
        Dim img As Image = Image.GetInstance(rutaPDF & "\examen.png")
        'ROTO NOVENTA GRADOS
        img.Rotation = PI * 0.5
        '65parece bien
        img.ScalePercent(65)
        'AÑADIO LA IMAGEN
        PDFdoc.Add(img)
        'FUNCION DE CONEXION
        Try
            EnviarDatos("CNX")
        Catch ex As Exception

        End Try
        '--------------------------------AHORA LA PAGINA DE TIRAS
        If contador_eventos > 0 Then
            'SI HUBO EVENTOS,CREO UNA NUEVA PAGINA
            PDFdoc.NewPage()
            'PARRAFO DEL TITULO
            para = New Paragraph("Tiras de ECG" & vbCrLf)
            para.Alignment = 1
            para.Font.Size = 18
            para.Font.SetStyle(FontFactory.HELVETICA)
            PDFdoc.Add(para)
            'AUXILIAR DONDE GUARDO LOS NOMBRES DE LOS EVENTOS
            Dim aux_lista_eventos() As String = Split(eventos, vbCrLf)
            'aca abajo tengo el ecg crudo
            Dim auxiliar() As String = aux_datos_ecg.Split(vbCrLf)
            'PARA CADA EVENTO EN LA LISTA
            For i As Integer = 0 To contador_eventos - 1
                'FUNCION DE CONEXION
                Try
                    EnviarDatos("CNX")
                Catch ex As Exception

                End Try
                'AUXILIAR PARA AGARRAR EL PASO DE MUESTREO
                Dim paso As Integer = stopW_eventos(2, i)
                'primero pongo el titulo del evento
                para = New Paragraph(aux_lista_eventos(i) & vbCrLf)
                para.Alignment = 0
                para.Font.Size = 13
                para.Font.SetStyle(FontFactory.HELVETICA)
                PDFdoc.Add(para)

                'ahora hay que imprimir el chart
                'IMPRIMO EL FONDO DEL RECTANGULO
                GFX_print.FillRectangle(Brushes.White, 0, 0, BMP_print.Width, BMP_print.Height)

                Dim apen As Pen = New Pen(Color.FromArgb(255, 192, 192))
                apen.Width = 0.5F ' antes

                'estaba en 10 y 10 probemos con 8 y 9 
                'IMPRIMO LAS LINEAS FINAS DE LA GRILLA
                For l As Integer = 9 To BMP_print.Width Step 10
                    GFX_print.DrawLine(apen, 0, l, BMP_print.Width, l)
                    GFX_print.DrawLine(apen, l, 0, l, BMP_print.Height)
                Next

                apen.Color = Color.Red
                apen.Width = 1.0F ' antes
                'IMPRIMO LAS LINEAS GRUESAS DE LA GRILLA
                For l As Integer = 0 To BMP_print.Width Step 50
                    GFX_print.DrawLine(apen, 0, l, BMP_print.Width, l)
                    GFX_print.DrawLine(apen, l, 0, l, BMP_print.Height)
                Next
                'GUARDO LA IMAGEN
                BMP_print.Save(rutaPDF & "\prueba_bmp.png", System.Drawing.Imaging.ImageFormat.Png)

                'LA ABRO EN UNA VARIABLE
                Dim imagen_tira3 As Image = Image.GetInstance(rutaPDF & "\prueba_bmp.png")

                'IMPRIMO LOS DATOS DE ECG DEL EVENTO
                Xinicial_display = 0
                xfinal = 0
                contador_display_print = 0
                contador_rectangullos = 1

                For k As Integer = inicio_evento(i) To fin_evento(i)

                    If contador_display_print >= ancho_display_print Then

                        'contador_display_print = 0
                        'SI ME PASO DEL FINAL DE LINEA, CREO UNA NUEVA IMAGEN, CADA LINEA DE ECG ES UNA IMAGEN DISTINTA
                        BMP_print.Save(rutaPDF & "\prueba_bmp.png", System.Drawing.Imaging.ImageFormat.Png)
                        Dim imagen_tira2 As Image = Image.GetInstance(rutaPDF & "\prueba_bmp.png")
                        imagen_tira2.ScalePercent(30)
                        'AÑADIO LA IMAGEN AL PDF
                        PDFdoc.Add(imagen_tira2)
                        'LLENO RECTANGULO BLANCO
                        GFX_print.FillRectangle(Brushes.White, 0, 0, BMP_print.Width, BMP_print.Height)

                        'IMPRIMO GRILLA FINA Y LUEGO GRUESA
                        apen = New Pen(Color.FromArgb(255, 192, 192))
                        apen.Width = 0.5F ' antes
                        'estaba en 10 y 10 probemos con 8 y 9 
                        For l As Integer = 9 To BMP_print.Width Step 10
                            GFX_print.DrawLine(apen, 0, l, BMP_print.Width, l)
                            GFX_print.DrawLine(apen, l, 0, l, BMP_print.Height)
                        Next
                        'GRUESA
                        apen.Color = Color.Red
                        apen.Width = 1.0F ' antes
                        For l As Integer = 0 To BMP_print.Width Step 50
                            GFX_print.DrawLine(Pens.Red, 0, l, BMP_print.Width, l)
                            GFX_print.DrawLine(Pens.Red, l, 0, l, BMP_print.Height)
                        Next
                    End If
                    'ACTUALIZAR DISPLAY 3 , IMPRIME EL ECG SOBRE EL BPM 
                    actualizar_display_3(auxiliar(k), k - inicio_evento(i), paso)
                Next

                BMP_print.Save(rutaPDF & "\prueba_bmp.png", System.Drawing.Imaging.ImageFormat.Png)
                Dim imagen_tira4 As Image = Image.GetInstance(rutaPDF & "\prueba_bmp.png")
                imagen_tira4.ScalePercent(30)
                PDFdoc.Add(imagen_tira4)
            Next
        End If
        PDFdoc.Close()
        'BORRO LAS IMAGENES QUE CREE EN LA CARPETA DE INFORME PARA USAR DE MANERA AUXILIAR
        System.IO.File.Delete(rutaPDF & "\examen.png")
        System.IO.File.Delete(rutaPDF & "\prueba_bmp.png")
        ' System.IO.File.Delete(rutaPDF & "\tira.png")
        'ABRO EL PDF EN EL VISOR ACROBAT
        System.Diagnostics.Process.Start(rutaPDF & "\" & TextNombre.Text.Trim() & " " & TextApellido.Text.Trim() & " " & dia_ex & "-" & mes_ex & "-" & anio_ex & ".pdf")
    End Sub

    'EVENTO:CAMBIA EL ESTADO DEL CHECKBOX DE INTERNADO SI
    Private Sub InternadoSI_CheckedChanged(sender As Object, e As EventArgs) Handles InternadoSI.CheckedChanged
        'TextDomicilio.Enabled = False
        'TextTelefono.Enabled = False
    End Sub

    ''EVENTO:CAMBIA EL ESTADO DEL CHECKBOX DE INTERNADO NO
    Private Sub InternadoNO_CheckedChanged(sender As Object, e As EventArgs) Handles InternadoNO.CheckedChanged
        'TextDomicilio.Enabled = True
        'TextTelefono.Enabled = True
    End Sub

    'LOS PANELES SON LOS CUADRADITOS INVISIBLES QUE LIMITAN LOS TEXTOS A UN CONTEXTO DADO, DE MANERA TAL QUE HAY SOLO UNO TILDADO EN ESE GRUPO
    Private Sub Panel5_Paint(sender As Object, e As PaintEventArgs) Handles Panel5.Paint
        If (INTE2NO.Checked = True) Then
            TextINTE3.ReadOnly = True
            TextINTE3.Clear()
        End If
        If (INTE2SI.Checked = True) Then
            TextINTE3.ReadOnly = False
        End If
    End Sub
    'PANEL
    Private Sub Panel10_Paint(sender As Object, e As PaintEventArgs) Handles Panel10.Paint
        If (INTE8NO.Checked = True) Then
            TextINTE9.ReadOnly = True
            TextINTE9.Clear()
        End If
        If (INTE8SI.Checked = True) Then
            TextINTE9.ReadOnly = False
        End If
    End Sub

    'EVENTO: TICK DEL TimerReal:lleva la cuenta del reloj en tiempo real del estudio
    Private Sub TimerReal_Tick(sender As Object, e As EventArgs) Handles TimerReal.Tick

        'SI ESTOY EN EL ESTADO BASAL, NO INGRESO DATOS EN LA FILAS SINO HASTA CUANDO TERMINA
        If estado_basal = True Then
            'SI SUPERE LA DURACION DE BASAL, LA TERMINO Y TOMO LAS ACCIONES CORRESPONDIENTES
            If uniminutos + decminutos >= DUR_basal Then

                'INDICO QUE SE TERMINO ESA ETAPA Y SE INICIO LA ETAPA 1
                estado_basal = False
                estado_etapa1 = True
                'ACTUALIZO LA INCLINACION OBJETIVO A LA DE LA ETAPA 1
                inclinacion_objetivo = INC_etapa1
                'AQUI TERMINA LA ETAPA BASAL POR LO QUE DEBO GUARDAR LAS MEDICIONES EN LA TABLA
                'AGREGO LOS VALORES INGRESADOS POR EL USUARIO A LOS VECTORES DE PRESION
                PS(aux_filas_datagrid) = sistolica
                PD(aux_filas_datagrid) = diastolica
                INC(aux_filas_datagrid) = inclinacion_objetivo
                'SI NO HAY DATO DE FC , SE GUARDA UN CERO
                Try
                    FC(aux_filas_datagrid) = txtFC.Text
                Catch ex As Exception
                    FC(aux_filas_datagrid) = 0
                End Try
                'este va a ser el minuto cero, deberia decir BASAL en lugar de cero, probamos
                Try
                    tiempo(aux_filas_datagrid) = "BASAL"
                Catch ex As Exception
                    tiempo(aux_filas_datagrid) = 0
                End Try

                'LUEGO LOS INGRESO EN EL CHART1 LO QUE VA AL PDF
                Chart1.Series("FC").Points.AddXY(tiempo(aux_filas_datagrid), FC(aux_filas_datagrid))
                Chart1.Series("PS").Points.AddXY(tiempo(aux_filas_datagrid), PS(aux_filas_datagrid))
                Chart1.Series("PD").Points.AddXY(tiempo(aux_filas_datagrid), PD(aux_filas_datagrid))
                Chart1.Series("IN").Points.AddXY(tiempo(aux_filas_datagrid), INC(aux_filas_datagrid))



                'GUARDO LOS DATOS EN UNA FILA DEL DATAGRID
                DatosExamen.Rows.Add(tiempo(aux_filas_datagrid), "BASAL", FC(aux_filas_datagrid), PS(aux_filas_datagrid), PD(aux_filas_datagrid))
                'contador = contador + 1
                'GUARDO LOS DATOS EN EL ARCHIVO DE RECUPERACION
                escritor_general.Write("DATOS-TABLA-EXAMEN" & vbCrLf)
                escritor_general.Write(DatosExamen.Rows(0).Cells(0).Value.ToString() & vbCrLf)
                escritor_general.Write(DatosExamen.Rows(0).Cells(1).Value.ToString() & vbCrLf)
                escritor_general.Write(DatosExamen.Rows(0).Cells(2).Value.ToString() & vbCrLf)
                escritor_general.Write(DatosExamen.Rows(0).Cells(3).Value.ToString() & vbCrLf)
                escritor_general.Write(DatosExamen.Rows(0).Cells(4).Value.ToString() & vbCrLf)
                'INCREMENTO EL AUXILIAR QUE ENUMERA LAS FILAS
                aux_filas_datagrid = aux_filas_datagrid + 1
                'ENVIO AL ARDUINO LA INCLINACION OBJETIVO
                Try
                    Enviar_INO(inclinacion_objetivo)
                Catch ex As Exception
                    MsgBox("Fallo en comunicación. Subir/Bajar la camilla de manera manual.")
                End Try

                'CAMBIO EL TEXTO DEL CLOCK A ETAPA 1
                LabelTiempo.Text = "Etapa 1:"
                'REINICIO EL CLOCK
                unisegundos = 0
                decsegundos = 0
                uniminutos = 0
                decminutos = 0
                'ACTUALIZO EL TEXBOX QUE MUESTRA EL TIEMPO
                TextBoxTiempo.Text = decminutos & uniminutos & ":" & decsegundos & unisegundos
                'HABILITO EL BOTON DESHACER
                botonDeshacer.Enabled = True
                botonDeshacer.Visible = True
                'HABILITO EL BOTON SIGUIENTE ETAPA
                botonSiguienteEtapa.Enabled = False
                botonSiguienteEtapa.Visible = False
                'HABILITO BOTON TERMINAR EXAMEN
                botonTerminarExamen.Enabled = True
                botonTerminarExamen.Visible = True

            End If
        End If

        'SI NO ESTOY EN BASAL O RECUPERACION AUN ASI AUMENTO UN SEGUNDO
        unisegundos = unisegundos + 1

        'SI ESTOY EN RECUPERACIÓN CONTINUO POR ACA LA TABLA
        If estado_recuperacion = True Then
            'SUMO UN SEGUNDO
            'unisegundos = unisegundos + 1
            'MsgBox("paso el true")
            'SI ESTABA EN EL SEGUNDO NUEVE, LO PONGO EN CERO Y SUMO UNO AL DECIMAL DE LOS SEGUNDOS
            If unisegundos > 9 Then
                ' MsgBox("paso el 9")
                unisegundos = 0
                decsegundos = decsegundos + 1
                'SI ESTABA EN EL SEGUNDO 59, PONGO EL DECIMAL DE SEGUNDOS EN CERO Y SUMO UN MINUTO 
                If decsegundos > 5 Then
                    decsegundos = 0
                    uniminutos = uniminutos + 1

                    'SI SE CUMPLIERON LOS CINCOS MINUTOS DE LA RECUPERACION, TERMINO EL EXAMEN
                    If uniminutos = 5 Then
                        Terminar_Examen()
                    End If

                    'CUANDO TERMINA UN MINUTO, LLENAMOS UNA FILA CON DATOS
                    'DATO DEL MINUTO ACTUAL
                    tiempo(aux_filas_datagrid) = uniminutos + decminutos * 10
                    'DATOS DE LA FC , SI NO RECIBI NADA DEL ARDUINO SE PONE CERO POR DEFECTO
                    Try
                        FC(aux_filas_datagrid) = txtFC.Text
                    Catch ex As Exception
                        FC(aux_filas_datagrid) = 0
                    End Try
                    'DATOS DE PRESION E INCLINACIÓN, NO VALIDO LA INCLINACION YA QUE SE GUARDA LA INCLINACION OBJETIVO NO LA REAL
                    PD(aux_filas_datagrid) = diastolica
                    PS(aux_filas_datagrid) = sistolica
                    INC(aux_filas_datagrid) = inclinacion_objetivo
                    'AÑADO UN NUEVO DATO EN TODAS LAS SERIES DEL GRAFICO  tiempo(aux_filas_datagrid) + minuto_sincope

                    '  MsgBox("hola")
                    Chart1.Series("FC").Points.AddXY(tiempo(aux_filas_datagrid) + minuto_sincope, FC(aux_filas_datagrid))
                    Chart1.Series("PS").Points.AddXY(tiempo(aux_filas_datagrid) + minuto_sincope, PS(aux_filas_datagrid))
                    Chart1.Series("PD").Points.AddXY(tiempo(aux_filas_datagrid) + minuto_sincope, PD(aux_filas_datagrid))
                    Chart1.Series("IN").Points.AddXY(tiempo(aux_filas_datagrid) + minuto_sincope, INC(aux_filas_datagrid))

                    Chart1.Series("FC").Points(tiempo(aux_filas_datagrid) + minuto_sincope).AxisLabel = (tiempo(aux_filas_datagrid))

                    'AÑADO FILA A LA GRILLA 
                    DatosExamen.Rows.Add(tiempo(aux_filas_datagrid), "", FC(aux_filas_datagrid), PS(aux_filas_datagrid), PD(aux_filas_datagrid))

                    'ESCRIBO LOS DATOS DE TODAS LAS SERIES EN EL ARCHIVO DE RECUPERACION
                    escritor_general.Write("DATOS-TABLA-EXAMEN" & vbCrLf)
                    escritor_general.Write(DatosExamen.Rows(aux_filas_datagrid).Cells(0).Value.ToString() & vbCrLf)
                    escritor_general.Write(DatosExamen.Rows(aux_filas_datagrid).Cells(1).Value.ToString() & vbCrLf)
                    escritor_general.Write(DatosExamen.Rows(aux_filas_datagrid).Cells(2).Value.ToString() & vbCrLf)
                    escritor_general.Write(DatosExamen.Rows(aux_filas_datagrid).Cells(3).Value.ToString() & vbCrLf)
                    escritor_general.Write(DatosExamen.Rows(aux_filas_datagrid).Cells(4).Value.ToString() & vbCrLf)

                    'AUMENTO EL CONTADOR- QUE NO SE PARA QUE SE USA
                    contador = contador + 1
                    'AUMENTO EL CONTADOR DE LAS FILAS DE LA DATAGRID
                    'NO DEBERIA AUMENTAR AUN
                    aux_filas_datagrid = aux_filas_datagrid + 1

                    Exit Sub
                End If
            End If
        End If

      
        'MISMA LOGICA DEL RELOJ QUE ANTES
        If unisegundos > 9 Then
            unisegundos = 0
            decsegundos = decsegundos + 1
            If decsegundos > 5 Then
                decsegundos = 0
                uniminutos = uniminutos + 1
                'SI NO ESTOY EN BASAL, TENGO QUE AGREGAR FILAS A LA GRILLA
                If estado_basal = False Then
                    'PASO LOS DATOS LUEGO DE UN MINUTO
                    tiempo(aux_filas_datagrid) = uniminutos + decminutos * 10
                    'SI NO HAY FC, SE PONE CERO
                    Try
                        FC(aux_filas_datagrid) = txtFC.Text
                    Catch ex As Exception
                        FC(aux_filas_datagrid) = 0
                    End Try
                    'PASO PRESION E INCLINACION
                    PD(aux_filas_datagrid) = diastolica
                    PS(aux_filas_datagrid) = sistolica
                    INC(aux_filas_datagrid) = inclinacion_objetivo
                    'AÑADO DATOS DE LAS SERIES AL GRAFICO
                    Chart1.Series("FC").Points.AddXY(tiempo(aux_filas_datagrid), FC(aux_filas_datagrid))
                    Chart1.Series("PS").Points.AddXY(tiempo(aux_filas_datagrid), PS(aux_filas_datagrid))
                    Chart1.Series("PD").Points.AddXY(tiempo(aux_filas_datagrid), PD(aux_filas_datagrid))
                    Chart1.Series("IN").Points.AddXY(tiempo(aux_filas_datagrid), INC(aux_filas_datagrid))
                    'AÑADO FILA A LA GRILLA 
                    DatosExamen.Rows.Add(tiempo(aux_filas_datagrid), "", FC(aux_filas_datagrid), PS(aux_filas_datagrid), PD(aux_filas_datagrid))
                    'GUARDO LOS DATOS EN EL ARCHIVO DE RECUPERACION
                    escritor_general.Write("DATOS-TABLA-EXAMEN" & vbCrLf)
                    escritor_general.Write(DatosExamen.Rows(aux_filas_datagrid).Cells(0).Value.ToString() & vbCrLf)
                    escritor_general.Write(DatosExamen.Rows(aux_filas_datagrid).Cells(1).Value.ToString() & vbCrLf)
                    escritor_general.Write(DatosExamen.Rows(aux_filas_datagrid).Cells(2).Value.ToString() & vbCrLf)
                    escritor_general.Write(DatosExamen.Rows(aux_filas_datagrid).Cells(3).Value.ToString() & vbCrLf)
                    escritor_general.Write(DatosExamen.Rows(aux_filas_datagrid).Cells(4).Value.ToString() & vbCrLf)
                    'AUMENTO EL CONTADOR DE LAS FILAS DE LA GRILLA
                    contador = contador + 1
                    aux_filas_datagrid = aux_filas_datagrid + 1
                End If
                'REVISO EN QUE ETAPA ESTOY,1 ,2 ,3 ETC
               
                If estado_etapa1 = True Then

                    Dim asl As Integer = uniminutos + decminutos
                    If (asl) > 8 Then

                        'MsgBox("hola")
                        ' Dim asl As Integer = uniminutos + decminutos
                    End If

                    If asl >= DUR_etapa1 Then
                        'ahora salgo de la etapa 1 a la etapa 2
                        estado_etapa1 = False
                        estado_etapa2 = True
                        inclinacion_objetivo = INC_etapa2
                        ' textboxINO.Text = inclinacion_objetivo
                        ' Labeletapa.Text = "Etapa 2"
                        LabelTiempo.Text = "Etapa 2:"
                    End If

                    If uniminutos + decminutos >= DUR_etapa1 Then
                        'ahora salgo de la etapa 1 a la etapa 2
                        estado_etapa1 = False
                        estado_etapa2 = True
                        inclinacion_objetivo = INC_etapa2
                        ' textboxINO.Text = inclinacion_objetivo
                        Try
                            Enviar_INO(inclinacion_objetivo)
                        Catch ex As Exception

                        End Try

                        ' Labeletapa.Text = "Etapa 2"
                        LabelTiempo.Text = "Etapa 2:"
                    End If

                End If

                If estado_etapa2 = True Then

                    If uniminutos + decminutos >= DUR_etapa2 + DUR_etapa1 Then
                        'ahora salgo de la etapa 1 a la etapa 2
                        estado_etapa2 = False
                        estado_etapa3 = True
                        inclinacion_objetivo = INC_etapa3
                        '  textboxINO.Text = inclinacion_objetivo
                        Try
                            Enviar_INO(inclinacion_objetivo)
                        Catch ex As Exception

                        End Try
                        LabelTiempo.Text = "Etapa 3:"
                    End If

                End If


                If uniminutos > 9 Then
                    uniminutos = 0
                    decminutos = decminutos + 1
                End If
            End If
        End If
        'MUESTRO EL TIEMPO ACTUAL - FALTARIA LA LOGICA DE BASAL Y DEMASES
        TextBoxTiempo.Text = decminutos & uniminutos & ":" & decsegundos & unisegundos
        'SI LLEGO AL MINUTO 31 LO DETENGO

        'antes estaba en 31 ahora lo dejo en DUR_final
        If (aux_filas_datagrid = DUR_Final + 1) Then
            TimerReal.Enabled = False
            MsgBox("Examen terminado!")
            inclinacion_objetivo = 0
            Try
                Enviar_INO(inclinacion_objetivo)
            Catch ex As Exception

            End Try


            Terminar_Examen()


            'DetenerExamen.Enabled = False
        End If
    End Sub

    'SUBRUTINA: CARGA UNA TABLA EN UN GRILLA PARA VER SUS DATOS
    Public Sub Loadgrilla(table As String, grid As DataGridView, Optional Query As String = "")
        If Query = "" Then
            SQL.ExecQuery("SELECT * FROM " & table & ";")
        Else
            SQL.ExecQuery(Query)
        End If
        'error handling 
        If SQL.HasException(True) Then Exit Sub
        grid.DataSource = SQL.DBDT
    End Sub

    'SUBRUTINA: CARGA UNA COMBOBOXDEL STAFF (TECNICO O MEDICO) CON UNA TABLA DE LA BASE DE DATOS
    Public Sub Loadcombobox(combo As ComboBox, tabla As String)
        'refresco el contenido de la combobox
        Dim indice_defecto As Integer = 0
        Dim defecto_encontrado As Boolean = False
        combo.Items.Clear()
        'ejecuto la query
        SQL.ExecQuery("SELECT * From " & tabla & ";")
        If SQL.HasException(True) Then Exit Sub
        'loop row & sumar al combobox

        For Each r As DataRow In SQL.DBDT.Rows
            Dim name As String
            Dim a0 As String = r("Id")
            Dim a1 As String = r("Apellido")
            Dim a2 As String = r("Nombre")
            a1 = a1.Trim()
            a2 = a2.Trim()
            name = a0 & "- " & a1 & ", " & a2
            Dim actividad As Boolean
            Dim defec As Boolean
            actividad = r("activo")
            defec = r("defecto")
            'si el tecnico/medico esta activo lo incluyo en la combobox
            If actividad = True Then
                combo.Items.Add(name)

                'ahora me fijo si es por defecto
                If defecto_encontrado = False Then

                    If defec = True Then
                        defecto_encontrado = True
                        combo.SelectedIndex = indice_defecto
                    End If
                    indice_defecto = indice_defecto + 1
                End If
            End If
        Next
    End Sub

    'ESTA FUNCION BUSCA ALGUIEN DEL STAFF Y LO MUESTRA EN LA GRILLA
    Public Sub Buscarpersonal(busqueda As TextBox, tabla As String, grilla As DataGridView)
        If busqueda.Text = "" Then
            Loadgrilla(tabla, grilla, "SELECT * FROM " & tabla)
            'Busquedaexamen.Loadgrilla_examen(tabla, grilla, "")
            Exit Sub
        End If
        SQL.AddParam("@item", "%" & busqueda.Text & "%")
        Loadgrilla(tabla, grilla, "SELECT * FROM " & tabla & " WHERE Nombre LIKE @item OR Apellido LIKE @item")
    End Sub

    'FUNCION UTILIZADA PARA EDITAR CAMPOS EN UNA TABLA- PODRIA NECESITAR LOGICA PARA EDITAR LOS CAMPOS COMPARTIDOS EN MAS DE UNA TABLA
    Private Sub EditarTabla(nombre As TextBox, apellido As TextBox, activo As CheckBox, defecto As CheckBox, grilla As DataGridView, tabla As String, combo As ComboBox)
        Dim estado As String
        Dim pordefecto As String
        If activo.Checked = True Then
            estado = "Activo"
        Else
            estado = "Inactivo"
        End If

        If defecto.Checked = True Then
            pordefecto = "Si"
        Else
            pordefecto = "No"
        End If

        If MsgBox("Esta seguro de actualizar los siguientes datos?" & vbCrLf & _
                   "Nombre: " & nombre.Text & vbCrLf & _
                   "Apellido: " & apellido.Text & vbCrLf & _
                   "Estado: " & estado & vbCrLf & _
                   "Por defecto: " & pordefecto, MsgBoxStyle.YesNo, "Editar") = MsgBoxResult.Yes Then
            Dim i As Integer = grilla.CurrentCell.RowIndex
            Dim id As Integer = grilla.Item(0, i).Value
            SQL.AddParam("@id", id)
            SQL.AddParam("@nombre", nombre.Text)
            SQL.AddParam("@apellido", apellido.Text)
            SQL.AddParam("@activo", activo.Checked)
            SQL.AddParam("@defecto", defecto.Checked)
            SQL.ExecQuery("UPDATE " & tabla & " SET Nombre =@nombre, Apellido=@apellido , activo=@activo, defecto=@defecto WHERE Id= @id;")
            If SQL.HasException(True) Then Exit Sub
        End If
        Loadcombobox(combo, tabla)
        Loadgrilla(tabla, grilla)
    End Sub

    'FUNCION UTILIZADA PARA BORRAR CAMPOS EN UNA TABLA - LA LOGICA PARA EVITAR BORRAR CAMPOS QUE ESTAN EN MAS DE UNA TABLA ESTA EN LA FUNCION QUE UTILIZA A ESTA
    Private Sub Borrar_Campo(nombre As TextBox, apellido As TextBox, grilla As DataGridView, tabla As String, combo As ComboBox)
        If MsgBox("Esta seguro que quiere borrar el siguiente campo?" & vbCrLf & _
                   "Nombre: " & nombre.Text & vbCrLf & _
                   "Apellido: " & apellido.Text, MsgBoxStyle.YesNo, "title") = MsgBoxResult.Yes Then
            Dim i As Integer = grilla.CurrentCell.RowIndex
            Dim id As Integer = grilla.Item(0, i).Value
            SQL.AddParam("@id", id)
            SQL.ExecQuery("DELETE  from " & tabla & " WHERE Id= @id;")
            If SQL.HasException(True) Then Exit Sub
        End If
        Loadcombobox(combo, tabla)
        Loadgrilla(tabla, grilla)
    End Sub

    'BOTON PARA BUSCAR TECNICO SEGUN EL NOMBRE
    Private Sub botonBuscarTecnico_Click(sender As Object, e As EventArgs) Handles botonBuscarTecnico.Click
        If editando_tecnico = True Then
            Exit Sub
        End If
        Buscarpersonal(txtbuscartecnico, "Tecnicos", DGVtecnicos)
    End Sub

    'EVENTOS DE CLICK SOBRE UNA GRILLA. LOGRA POBLAR LOS CUADROS DE TEXTO CON LOS DATOS DE LA FILA SELECCIONADA
    Private Sub DGVtecnicos_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGVtecnicos.CellClick
        Dim i As Integer = DGVtecnicos.CurrentCell.RowIndex
        txtNombreTecnico.Text = DGVtecnicos.Item(1, i).Value.ToString().Trim()
        txtApellidoTecnico.Text = DGVtecnicos.Item(2, i).Value.ToString().Trim()
        activotecnico.Checked = DGVtecnicos.Item(3, i).Value
        DefectoTecnico.Checked = DGVtecnicos.Item(4, i).Value
    End Sub
    'EVENTOS DE CLICK SOBRE UNA GRILLA. LOGRA POBLAR LOS CUADROS DE TEXTO CON LOS DATOS DE LA FILA SELECCIONADA
    Private Sub DGVmedicosman_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGVmedicosman.CellClick
        Dim i As Integer = DGVmedicosman.CurrentCell.RowIndex
        txtNombreMandante.Text = DGVmedicosman.Item(1, i).Value.ToString().Trim()
        txtApellidoMandante.Text = DGVmedicosman.Item(2, i).Value.ToString().Trim()
        activomandante.Checked = DGVmedicosman.Item(3, i).Value
        DefectoMandante.Checked = DGVmedicosman.Item(4, i).Value
    End Sub
    'EVENTOS DE CLICK SOBRE UNA GRILLA. LOGRA POBLAR LOS CUADROS DE TEXTO CON LOS DATOS DE LA FILA SELECCIONADA
    Private Sub DGVmedicosact_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGVmedicosact.CellClick
        Dim i As Integer = DGVmedicosact.CurrentCell.RowIndex
        txtNombreactuante.Text = DGVmedicosact.Item(1, i).Value.ToString().Trim()
        txtApellidoactuante.Text = DGVmedicosact.Item(2, i).Value.ToString().Trim()
        activoactuante.Checked = DGVmedicosact.Item(3, i).Value
        DefectoActuante.Checked = DGVmedicosact.Item(4, i).Value
    End Sub

    ' FUNCION QUE RECIBE PARAMETROS Y PUEDE INSERTAR DATOS EN LAS TABLAS TECNICO Y MEDICOS
    Private Sub InsertarPersonal(nombre As TextBox, apellido As TextBox, activo As CheckBox, defecto As CheckBox, tabla As String, combo As ComboBox, grilla As DataGridView)
        If String.IsNullOrWhiteSpace(nombre.Text) Or String.IsNullOrWhiteSpace(apellido.Text) Then
            MsgBox("No puede agregar campos vacios")
            Exit Sub
        End If
        SQL.AddParam("@nombre", nombre.Text)
        SQL.AddParam("@apellido", apellido.Text)
        SQL.AddParam("@activo", activo.Checked)
        SQL.AddParam("@defecto", defecto.Checked)
        SQL.ExecQuery("INSERT INTO " & tabla & "(Nombre, Apellido, activo, defecto) VALUES (@nombre, @apellido, @activo, @defecto);")
        If SQL.HasException(True) Then Exit Sub
        MsgBox("Se ha agregado al nuevo personal")
        Loadcombobox(combo, tabla)
        Loadgrilla(tabla, grilla)
        nombre.Clear()
        apellido.Clear()
        activo.Checked = False
    End Sub

    'FUNCION QUE INSERTA UN PACIENTE 
    Private Sub InsertarPaciente(nombre As TextBox, apellido As TextBox, edad As TextBox, domicilio As TextBox, telefono As TextBox, dni As TextBox, sexo As String)
        Dim aux_sexo As Boolean
        If String.IsNullOrWhiteSpace(nombre.Text) Or String.IsNullOrWhiteSpace(apellido.Text) Or String.IsNullOrWhiteSpace(dni.Text) Then
            MsgBox("Los campos Nombre, Apellido y DNI son obligatorios!")
            Exit Sub
        End If

        SQL.AddParam("@nombre", nombre.Text)
        SQL.AddParam("@apellido", apellido.Text)
        SQL.AddParam("@domicilio", domicilio.Text)
        SQL.AddParam("@telefono", telefono.Text)
        SQL.AddParam("@edad", edad.Text)
        SQL.AddParam("@dni", dni.Text)

        If sexo = "M" Then aux_sexo = True
        If sexo = "F" Then aux_sexo = False
        SQL.AddParam("@sexo", aux_sexo)
        SQL.ExecQuery("INSERT INTO Pacientes (DNI,Nombre, Apellido, Edad, Domicilio, Telefono, Sexo) VALUES (@dni, @nombre, @apellido, @edad, @domicilio, @telefono, @sexo);")
        If SQL.HasException(True) Then Exit Sub

        MsgBox("Se ha guardado el paciente en la base de datos", MsgBoxStyle.Information, "Tilt Test")

        TextNombre.Enabled = True
        TextNombre.ReadOnly = True
        TextApellido.Enabled = True
        TextApellido.ReadOnly = True
        TextEdad.Enabled = True
        TextEdad.ReadOnly = True
        TextDNI.Enabled = True
        TextDNI.ReadOnly = True
        'cbxSexo.Enabled = False
        TextDomicilio.Enabled = True
        TextDomicilio.ReadOnly = True
        TextTelefono.Enabled = True
        TextTelefono.ReadOnly = True
        'Panelsexo.readonly = True
    End Sub

    'CHECKEADORES DE TEXTOS PARA LA HORA DE INSERTAR CAMPOS Y EVITAR STRINGS VACIOS
    Private Sub txtNombreTecnico_TextChanged(sender As Object, e As EventArgs) Handles txtNombreTecnico.TextChanged, txtApellidoTecnico.TextChanged
        'validación básica
        If Not String.IsNullOrWhiteSpace(txtNombreTecnico.Text) AndAlso Not String.IsNullOrWhiteSpace(txtApellidoTecnico.Text) Then
            InsertarTecnico.Enabled = True
        End If
    End Sub
    'VALIDACION DE NOMBRES 
    Private Sub txtNombreMandante_TextChanged(sender As Object, e As EventArgs) Handles txtNombreMandante.TextChanged, txtApellidoMandante.TextChanged
        'validación básica
        If Not String.IsNullOrWhiteSpace(txtNombreMandante.Text) AndAlso Not String.IsNullOrWhiteSpace(txtApellidoMandante.Text) Then
            InsertarMandante.Enabled = True
        End If
    End Sub
    'VALIDACION DE NOMBRES
    Private Sub txtNombreactuante_TextChanged(sender As Object, e As EventArgs) Handles txtNombreactuante.TextChanged, txtApellidoactuante.TextChanged
        'validación básica
        If Not String.IsNullOrWhiteSpace(txtNombreactuante.Text) AndAlso Not String.IsNullOrWhiteSpace(txtApellidoactuante.Text) Then
            Insertaractuante.Enabled = True
        End If
    End Sub

    '   boton que INSERTA TECNICOS
    Private Sub InsertarTecnico_Click(sender As Object, e As EventArgs) Handles InsertarTecnico.Click
        If editando_tecnico = True Then
            Exit Sub
        End If

        If nuevo_tecnico = False Then
            InsertarTecnico.Text = "Insertar"
            txtNombreTecnico.ReadOnly = False
            txtNombreTecnico.Text = ""
            txtApellidoTecnico.ReadOnly = False
            txtApellidoTecnico.Text = ""
            activotecnico.Enabled = True
            activotecnico.Checked = False
            DefectoTecnico.Enabled = True
            DefectoTecnico.Checked = False
            nuevo_tecnico = True

            Exit Sub
        End If

        If nuevo_tecnico = True Then
            If String.IsNullOrWhiteSpace(txtNombreTecnico.Text) Or String.IsNullOrWhiteSpace(txtApellidoTecnico.Text) Then
                MsgBox("No puede agregar campos vacios", MsgBoxStyle.Exclamation, "Nuevo Técnico")
                Exit Sub
            End If

            InsertarPersonal(txtNombreTecnico, txtApellidoTecnico, activotecnico, DefectoTecnico, "Tecnicos", cbxTecnico, DGVtecnicos)
            InsertarTecnico.Text = "Nuevo"
            txtNombreTecnico.ReadOnly = True
            txtNombreTecnico.Text = ""
            txtApellidoTecnico.ReadOnly = True
            txtApellidoTecnico.Text = ""
            activotecnico.Enabled = False
            activotecnico.Checked = False
            DefectoTecnico.Enabled = False
            DefectoTecnico.Checked = False
            nuevo_tecnico = False
        End If
    End Sub

    'BOTON QUE EDITA TECNICOS
    Private Sub EditarTecnico_Click(sender As Object, e As EventArgs) Handles EditarTecnico.Click

        If nuevo_tecnico = True Then
            Exit Sub
        End If

        If editando_tecnico = False Then
            txtNombreTecnico.ReadOnly = False
            txtApellidoTecnico.ReadOnly = False
            activotecnico.Enabled = True
            DefectoTecnico.Enabled = True
            EditarTecnico.Text = "Guardar"
            editando_tecnico = True
            Exit Sub
        End If

        If editando_tecnico = True Then

            If String.IsNullOrWhiteSpace(txtNombreTecnico.Text) Or String.IsNullOrWhiteSpace(txtApellidoTecnico.Text) Then
                MsgBox("No puede guardar un campos vacio", MsgBoxStyle.Exclamation, "Editar Técnico")
                Exit Sub
            End If

            EditarTabla(txtNombreTecnico, txtApellidoTecnico, activotecnico, DefectoTecnico, DGVtecnicos, "Tecnicos", cbxTecnico)
            txtNombreTecnico.ReadOnly = True
            txtApellidoTecnico.ReadOnly = True
            activotecnico.Enabled = False
            DefectoTecnico.Enabled = False
            EditarTecnico.Text = "Editar"
            editando_tecnico = False
        End If
    End Sub

    'BOTON QUE ELIMINA TECNICOS
    Private Sub EliminarTecnico_Click(sender As Object, e As EventArgs) Handles EliminarTecnico.Click
        If nuevo_tecnico = True Then
            Exit Sub
        End If

        If editando_tecnico = True Then
            Exit Sub
        End If

        Dim i As Integer = DGVtecnicos.CurrentCell.RowIndex
        Dim id As Integer = DGVtecnicos.Item(0, i).Value
        SQL.AddParam("@idtecnico", id)
        SQL.ExecQuery("SELECT * from Examen  WHERE IdTecnico= @idtecnico;")
        If SQL.HasException(True) Then Exit Sub
        If SQL.DBDT.Rows.Count <> 0 Then
            MsgBox("No se puede eliminar al tecnico seleccionado ya que esta asociado a un examen en la base de datos", MsgBoxStyle.Information, "Error")
            Exit Sub
        End If
        Borrar_Campo(txtNombreTecnico, txtApellidoTecnico, DGVtecnicos, "Tecnicos", cbxTecnico)

        txtNombreTecnico.Clear()
        txtApellidoTecnico.Clear()
        cbxTecnico.SelectedIndex = -1
        activotecnico.Checked = False
        DefectoTecnico.Checked = False

    End Sub

    'CAMBIA LA CARPETA DONDE SE GUARDARA EL PDF - HAY QUE AGREGAR LA LOGICA DE LA TABLA DE LA BASE DE DATOS
    Private Sub RutaPDF_Click(sender As Object, e As EventArgs) Handles BotonRutaPDF.Click
        carpeta.ShowDialog()
        rutaPDF = carpeta.SelectedPath
        'ahora cambiar la de la base de datos
        SQL.AddParam("@ruta", rutaPDF)
        SQL.ExecQuery("UPDATE Auxiliar SET ruta=@ruta  WHERE Id= 1;")
        If SQL.HasException(True) Then Exit Sub
    End Sub

    '-----FUNCIONES PARA MEDICO MANDANTE------------
    'BUSCA UN MEDICO POR NOMBRE- DEBERIA INLCUIR POR APELLIDO E ID
    Private Sub Buscar_mandante(sender As Object, e As EventArgs) Handles BuscarMedMan.Click
        If editando_mandante = True Then
            Exit Sub
        End If
        Buscarpersonal(txtbuscarmandante, "Mandantes", DGVmedicosman)
    End Sub
    'INSERTA MEDICO MANDANTE
    Private Sub InsertarMandante_Click(sender As Object, e As EventArgs) Handles InsertarMandante.Click
        If editando_mandante = True Then
            Exit Sub
        End If

        If nuevo_mandante = False Then
            InsertarMandante.Text = "Insertar"
            txtNombreMandante.ReadOnly = False
            txtNombreMandante.Text = ""
            txtApellidoMandante.ReadOnly = False
            txtApellidoMandante.Text = ""
            activomandante.Enabled = True
            activomandante.Checked = False
            DefectoMandante.Enabled = True
            DefectoMandante.Checked = False
            nuevo_mandante = True
            Exit Sub
        End If

        If nuevo_mandante = True Then

            If String.IsNullOrWhiteSpace(txtNombreMandante.Text) Or String.IsNullOrWhiteSpace(txtApellidoMandante.Text) Then
                MsgBox("No puede agregar campos vacios", MsgBoxStyle.Exclamation, "Nuevo Médico Mandante")
                Exit Sub
            End If

            InsertarPersonal(txtNombreMandante, txtApellidoMandante, activomandante, DefectoMandante, "Mandantes", cbxMandante, DGVmedicosman)

            InsertarMandante.Text = "Nuevo"
            txtNombreMandante.ReadOnly = True
            txtNombreMandante.Text = ""
            txtApellidoMandante.ReadOnly = True
            txtApellidoMandante.Text = ""
            activomandante.Enabled = False
            activomandante.Checked = False
            DefectoMandante.Enabled = False
            DefectoMandante.Checked = False
            nuevo_mandante = False

        End If

    End Sub
    'BOTON QUE EDITA MEDICO MANDANTE - PODRIA NECESITAR LOGICA QUE ACTUALICE TODOS LOS EXAMENES HECHOS POR DICHO MEDICO
    Private Sub EditarMandante_Click(sender As Object, e As EventArgs) Handles EditarMandante.Click

        If nuevo_mandante = True Then
            Exit Sub
        End If

        If editando_mandante = False Then
            txtNombreMandante.ReadOnly = False
            txtApellidoMandante.ReadOnly = False
            activomandante.Enabled = True
            DefectoMandante.Enabled = True
            EditarMandante.Text = "Guardar"
            editando_mandante = True
            Exit Sub
        End If

        If editando_mandante = True Then
            If String.IsNullOrWhiteSpace(txtNombreMandante.Text) Or String.IsNullOrWhiteSpace(txtApellidoMandante.Text) Then
                MsgBox("No puede guardar un campos vacio", MsgBoxStyle.Exclamation, "Editar Médico Mandante")
                Exit Sub
            End If

            EditarTabla(txtNombreMandante, txtApellidoMandante, activomandante, DefectoMandante, DGVmedicosman, "Mandantes", cbxMandante)
            txtNombreMandante.ReadOnly = True
            txtApellidoMandante.ReadOnly = True
            activomandante.Enabled = False
            DefectoMandante.Enabled = False
            EditarMandante.Text = "Editar"
            editando_mandante = False
        End If
    End Sub
    'BOTON QUE ELIMINA UN MEDICO MANDANTE - FALTA LOGICA PARA EVITAR ELIMINAR MEDICOS ASOCIADOS A UN CAMPO EN LA TABLA EXAMENES
    Private Sub EliminarMandante_Click(sender As Object, e As EventArgs) Handles EliminarMandante.Click

        If editando_mandante = True Then
            Exit Sub
        End If

        If nuevo_mandante = True Then
            Exit Sub
        End If

        Dim i As Integer = DGVmedicosman.CurrentCell.RowIndex
        Dim id As Integer = DGVmedicosman.Item(0, i).Value
        SQL.AddParam("@idmandante", id)
        SQL.ExecQuery("SELECT * from Examen  WHERE IdMandante= @idmandante;")
        If SQL.HasException(True) Then Exit Sub
        If SQL.DBDT.Rows.Count <> 0 Then
            MsgBox("No se puede eliminar al medico seleccionado ya que esta asociado a un examen en la base de datos", MsgBoxStyle.Information, "Error")
            Exit Sub
        End If
        Borrar_Campo(txtNombreMandante, txtApellidoMandante, DGVmedicosman, "Mandantes", cbxMandante)

        txtNombreMandante.Clear()
        txtApellidoMandante.Clear()
        cbxMandante.SelectedIndex = -1
        activomandante.Checked = False
        DefectoMandante.Checked = False
    End Sub

    '-----FUNCIONES PARA MEDICO ACTUANTE------
    'BUSCA UN MEDICO POR NOMBRE- DEBERIA INLCUIR POR APELLIDO E ID
    Private Sub Buscar_actuante(sender As Object, e As EventArgs) Handles buscaractuante.Click
        If editando_actuante = True Then
            Exit Sub
        End If
        Buscarpersonal(txtbuscaractuante, "Actuantes", DGVmedicosact)
    End Sub
    'INSERTA MEDICO actuante
    Private Sub Insertaractuante_Click(sender As Object, e As EventArgs) Handles Insertaractuante.Click
        If editando_actuante = True Then
            Exit Sub
        End If

        If nuevo_actuante = False Then
            Insertaractuante.Text = "Insertar"
            txtNombreactuante.ReadOnly = False
            txtNombreactuante.Text = ""
            txtApellidoactuante.ReadOnly = False
            txtApellidoactuante.Text = ""
            activoactuante.Enabled = True
            activoactuante.Checked = False
            DefectoActuante.Enabled = True
            DefectoActuante.Checked = False
            nuevo_actuante = True
            Exit Sub
        End If

        If nuevo_actuante = True Then
            If String.IsNullOrWhiteSpace(txtNombreactuante.Text) Or String.IsNullOrWhiteSpace(txtApellidoactuante.Text) Then
                MsgBox("No puede agregar campos vacios", MsgBoxStyle.Exclamation, "Nuevo Médico Actuante")
                Exit Sub
            End If

            InsertarPersonal(txtNombreactuante, txtApellidoactuante, activoactuante, DefectoActuante, "Actuantes", cbxActuante, DGVmedicosact)
            Insertaractuante.Text = "Nuevo"
            txtNombreactuante.ReadOnly = True
            txtNombreactuante.Text = ""
            txtApellidoactuante.ReadOnly = True
            txtApellidoactuante.Text = ""
            activoactuante.Enabled = False
            activoactuante.Checked = False
            DefectoActuante.Enabled = False
            DefectoActuante.Checked = False
            nuevo_actuante = False

        End If

    End Sub
    'BOTON QUE EDITA MEDICO actuante - PODRIA NECESITAR LOGICA QUE ACTUALICE TODOS LOS EXAMENES HECHOS POR DICHO MEDICO
    Private Sub Editaractuante_Click(sender As Object, e As EventArgs) Handles Editaractuante.Click

        If nuevo_actuante = True Then
            Exit Sub
        End If

        If editando_actuante = False Then
            txtNombreactuante.ReadOnly = False
            txtApellidoactuante.ReadOnly = False
            activoactuante.Enabled = True
            DefectoActuante.Enabled = True
            Editaractuante.Text = "Guardar"
            editando_actuante = True
            Exit Sub
        End If

        If editando_actuante = True Then
            If String.IsNullOrWhiteSpace(txtNombreactuante.Text) Or String.IsNullOrWhiteSpace(txtApellidoactuante.Text) Then
                MsgBox("No puede guardar un campos vacio", MsgBoxStyle.Exclamation, "Editar Médico Actuante")
                Exit Sub
            End If

            EditarTabla(txtNombreactuante, txtApellidoactuante, activoactuante, DefectoActuante, DGVmedicosact, "Actuantes", cbxActuante)
            txtNombreactuante.ReadOnly = True
            txtApellidoactuante.ReadOnly = True
            activoactuante.Enabled = False
            DefectoActuante.Enabled = False
            Editaractuante.Text = "Editar"
            editando_actuante = False
        End If

    End Sub

    'BOTONO QUE ELIMINA UN MEDICO actuante 
    Private Sub Eliminaractuante_Click(sender As Object, e As EventArgs) Handles Eliminaractuante.Click

        If editando_actuante = True Then
            Exit Sub
        End If

        If nuevo_actuante = True Then
            Exit Sub
        End If

        Dim i As Integer = DGVmedicosact.CurrentCell.RowIndex
        Dim id As Integer = DGVmedicosact.Item(0, i).Value
        SQL.AddParam("@idactuante", id)
        SQL.ExecQuery("SELECT * from Examen  WHERE IdActuante= @idactuante;")
        If SQL.HasException(True) Then Exit Sub
        If SQL.DBDT.Rows.Count <> 0 Then
            MsgBox("No se puede eliminar al medico seleccionado ya que esta asociado a un examen en la base de datos", MsgBoxStyle.Information, "Error")
            Exit Sub
        End If
        Borrar_Campo(txtNombreactuante, txtApellidoactuante, DGVmedicosact, "Actuantes", cbxActuante)
        txtNombreactuante.Clear()
        txtApellidoactuante.Clear()
        cbxActuante.SelectedIndex = -1
        activoactuante.Checked = False
        DefectoActuante.Checked = False
    End Sub

    'BOTON DE CAMBIO DE CONTRASEÑA 
    Private Sub password_Click(sender As Object, e As EventArgs) Handles password.Click
        Dim pass_aux As String = ""
        Dim pass_new As String = ""
        Dim pass_new2 As String = ""
        Try
            pass_aux = InputBox("Ingrese la contraseña anterior:")
        Catch ex As Exception

        End Try

        If pass_aux = passwordP Then

            pass_new = InputBox("Ingrese la nueva contraseña:")

            If pass_new = "" Then Exit Sub

            pass_new2 = InputBox("Confirme la nueva contraseña:")

            If pass_new2 = "" Then Exit Sub

            If pass_new = pass_new2 Then

                passwordP = pass_new

                'ahora cambiar la de la base de datos
                SQL.AddParam("@contraseña", passwordP)
                SQL.ExecQuery("UPDATE Auxiliar SET contraseña=@contraseña  WHERE Id= 1;")
                If SQL.HasException(True) Then Exit Sub


                MsgBox("Contraseña cambiada!", MsgBoxStyle.OkOnly)
                pass_aux = ""
                pass_new = ""
                pass_new2 = ""
            Else
                MsgBox("No coinciden las contraseñas!", MsgBoxStyle.OkOnly)
                pass_aux = ""
                pass_new = ""
                pass_new2 = ""
            End If

        Else
            MsgBox("Contraseña incorrecta!", MsgBoxStyle.OkOnly)

        End If
    End Sub

    'BOTONO PARA MODIFICAR LAS MEDICIONES DE PRESION QUE SE IRAN AÑADIENDO
    Private Sub botonPresion_Click(sender As Object, e As EventArgs) Handles botonPresion.Click
        Ingresar_medicion_presion()
    End Sub

    'FUNCION PARA AÑADIR LOS DATOS DEL EXAMEN AL CAMPO EN VARCHARMAX
    Private Sub guardar_datos()

        If INTE1SI.Checked = True Then
            aux_datos = "1" & vbCrLf
        Else
            If INTE1NO.Checked = True Then
                aux_datos = "2" & vbCrLf
            Else
                aux_datos = "4" & vbCrLf
            End If
        End If

        If INTE2SI.Checked = True Then
            aux_datos = aux_datos & "1" & vbCrLf
        Else
            If INTE2NO.Checked = True Then
                aux_datos = aux_datos & "2" & vbCrLf
            Else
                aux_datos = aux_datos & "4" & vbCrLf
            End If
        End If

        If String.IsNullOrWhiteSpace(TextINTE3.Text) Then
            aux_datos = aux_datos & "4" & vbCrLf
        Else
            aux_datos = aux_datos & TextINTE3.Text & vbCrLf
        End If

        If INTE4SI.Checked = True Then
            aux_datos = aux_datos & "1" & vbCrLf
        Else
            If INTE4NO.Checked = True Then
                aux_datos = aux_datos & "2" & vbCrLf
            Else
                aux_datos = aux_datos & "4" & vbCrLf
            End If
        End If

        If INTE5SI.Checked = True Then
            aux_datos = aux_datos & "1" & vbCrLf
        Else
            If INTE5NO.Checked = True Then
                aux_datos = aux_datos & "2" & vbCrLf
            Else
                aux_datos = aux_datos & "4" & vbCrLf
            End If
        End If

        If INTE6SI.Checked = True Then
            aux_datos = aux_datos & "1" & vbCrLf
        Else
            If INTE6NO.Checked = True Then
                aux_datos = aux_datos & "2" & vbCrLf
            Else
                If INTE6NOSABE.Checked = True Then
                    aux_datos = aux_datos & "3" & vbCrLf
                Else
                    aux_datos = aux_datos & "4" & vbCrLf
                End If
            End If
        End If

        If INTE7SI.Checked = True Then
            aux_datos = aux_datos & "1" & vbCrLf
        Else
            If INTE7NO.Checked = True Then
                aux_datos = aux_datos & "2" & vbCrLf
            Else
                aux_datos = aux_datos & "4" & vbCrLf
            End If
        End If

        If INTE8SI.Checked = True Then
            aux_datos = aux_datos & "1" & vbCrLf
        Else
            If INTE8NO.Checked = True Then
                aux_datos = aux_datos & "2" & vbCrLf
            Else
                aux_datos = aux_datos & "4" & vbCrLf
            End If
        End If

        If String.IsNullOrWhiteSpace(TextINTE9.Text) Then
            aux_datos = aux_datos & "4" & vbCrLf
        Else
            aux_datos = aux_datos & TextINTE9.Text & vbCrLf
        End If

        If String.IsNullOrWhiteSpace(ComboBoxProtocolo.Text) Then
            aux_datos = aux_datos & "4" & vbCrLf
        Else

            ' Dim aux_proto As String = ComboBoxProtocolo.Text.Substring(0, 1)
            ' aux_datos = aux_datos & ComboBoxProtocolo.Text.Substring(0, 1) & vbCrLf
            aux_datos = aux_datos & ComboBoxProtocolo.Text & vbCrLf
        End If


        'LA CANTIDAD DE DATOS GUARDADOS PODRIA DEPENDER DEL PROTOCOLO?
        'deberia guardar hasta la cantidad de filas del datosexamen menos uno
        For i As Integer = 0 To DatosExamen.RowCount - 1
            Try
                aux_datos = aux_datos & DatosExamen.Rows(i).Cells(0).Value & vbCrLf
                aux_datos = aux_datos & DatosExamen.Rows(i).Cells(1).Value & vbCrLf
                aux_datos = aux_datos & DatosExamen.Rows(i).Cells(2).Value & vbCrLf
                aux_datos = aux_datos & DatosExamen.Rows(i).Cells(3).Value & vbCrLf
                aux_datos = aux_datos & DatosExamen.Rows(i).Cells(4).Value & vbCrLf
            Catch ex As Exception

                Exit For


            End Try

        Next

    End Sub

    'FUNCION QUE PUEBLA LA DATA GRID Y ELGRAFICO CON DATOS DE UN EXAMEN VIEJO, FALTA ASOCIARLE LA PARTE DE BUSQUEDA DE EXAMEN
    Public Sub abrir_datos(datos As String)
        
        Dim lista() As String = datos.Split(vbCrLf)
        Dim aux As String
        aux = lista(0)
        If lista(0) = 1 Then INTE1SI.Checked = True
        If lista(0) = 2 Then INTE1NO.Checked = True

        aux = lista(1)
        If lista(1) = 1 Then INTE2SI.Checked = True
        If lista(1) = 2 Then INTE2NO.Checked = True

        aux = lista(2)
        If lista(2) = "4" Then
            TextINTE3.Text = ""
        Else
            TextINTE3.Text = lista(2)
        End If

        aux = lista(3)
        If lista(3) = 1 Then INTE4SI.Checked = True
        If lista(3) = 2 Then INTE4NO.Checked = True

        aux = lista(4)
        If lista(4) = 1 Then INTE5SI.Checked = True
        If lista(4) = 2 Then INTE5NO.Checked = True

        aux = lista(5)
        If lista(5) = 1 Then INTE6SI.Checked = True
        If lista(5) = 2 Then INTE6NO.Checked = True
        If lista(5) = 4 Then INTE6NOSABE.Checked = True

        aux = lista(6)
        If lista(6) = 1 Then INTE7SI.Checked = True
        If lista(6) = 2 Then INTE7NO.Checked = True

        aux = lista(7)
        If lista(7) = 1 Then INTE8SI.Checked = True
        If lista(7) = 2 Then INTE8NO.Checked = True

        aux = lista(8)
        If lista(8) = "4" Then
            TextINTE9.Text = ""
        Else
            TextINTE9.Text = lista(8)
        End If

        Dim aux_protocolo As String

        'aca tengo que hacer la logica de recibir el nombre del protocolo y buscarlo en la base de datos
        'si existe lo elijo

        For k As Integer = 0 To (ComboBoxProtocolo.Items.Count - 1)

            aux_protocolo = ComboBoxProtocolo.Items(k).ToString
            Dim aux_filas_datagrid As String = aux_protocolo.ToString()

            Try
                'Dim aux3 As String = lista(9)
            Catch ex As Exception
                ' Dim aux3 As Integer = 0
            End Try

            Dim aux3 As String = lista(9).Trim()

            'ACA ABRIA EL PROTOCOLO ANTES DE QUE ESTE INTEGRADO A LA BASE DE DATOS
            If aux_filas_datagrid = aux3 Then
                ComboBoxProtocolo.SelectedIndex = k
                Exit For
            End If

        Next

        'faltaria colorear las columnas de sintomas que contengan algo a rojo!!!!
        'antes era del 0 al 30
        For i As Integer = 10 To 150 Step 5
            Try
                DatosExamen.Rows.Add(lista(i), lista(i + 1), lista(i + 2), lista(i + 3), lista(i + 4))

                Chart1.Series("FC").Points.AddXY(lista(i), lista(i + 2))

                Chart1.Series("PS").Points.AddXY(lista(i), lista(i + 3))

                Chart1.Series("PD").Points.AddXY(lista(i), lista(i + 4))

                'aca me fijo si el sintoma escrito se pasa de la celda

            Catch ex As Exception
                Exit For
            End Try
        Next
        'luego que los abre , reviso el datagridview para adaptar aquella fila donde haya ingresado sintomas y pongo el wrapmode on
        For j As Integer = 0 To DatosExamen.RowCount - 1
            Dim auxi As String = DatosExamen.Item(1, j).Value.ToString

            If Not String.IsNullOrWhiteSpace(auxi) Then

                DatosExamen.Rows(j).DefaultCellStyle.WrapMode = DataGridViewTriState.True
            End If
        Next
        'ahora tengo que abrir los eventos 
        'primero meter el ecg en un array

    End Sub

    'BOTON BUSCAR PACIENTE  - ME LLEVA AL FORMULARIO DE PACIENTE
    Private Sub botonBuscarpaciente_Click(sender As Object, e As EventArgs) Handles botonBuscarpaciente.Click
        Busquedapaciente.Show()
        Busquedapaciente.BringToFront()
        TabGeneral.SendToBack()
    End Sub

    'BOTON NUEVO PACIENTE
    Private Sub botonNuevopaciente_Click(sender As Object, e As EventArgs) Handles botonNuevopaciente.Click
        GO_NuevoPaciente()
    End Sub

    'BOTON PARA PASAR A LA SIGUIENTE ETAPA DEL ESTUDIO
    Private Sub botonsiguiente_Click(sender As Object, e As EventArgs) Handles botonsiguiente.Click

        If estado_editando_paciente_viejo = True Then

            tabpersonales_editada()
            estado_editando_paciente_viejo = False
            PictureBoxEditarPaciente.BackColor = Color.Transparent

            Exit Sub
        End If

        If edicion_personales = True Then
            tabpersonales_editada()
            Exit Sub
        End If

        If estado_datos = True Then
            TabGeneral.SelectedIndex = 1
            Exit Sub
        End If

        If String.IsNullOrWhiteSpace(TextNombre.Text) Or String.IsNullOrWhiteSpace(TextApellido.Text) Or String.IsNullOrWhiteSpace(TextEdad.Text) Or String.IsNullOrWhiteSpace(TextDNI.Text) Or String.IsNullOrWhiteSpace(cbxTecnico.Text) Or String.IsNullOrWhiteSpace(cbxActuante.Text) Or String.IsNullOrWhiteSpace(cbxMandante.Text) Then
            MsgBox("No se puede iniciar el estudio" & vbCrLf & "1-Los datos Nombre, Apellido , Edad y DNI son obligatorios!" & vbCrLf & "2-Debe seleccionar técnico y médicos! ", MsgBoxStyle.Exclamation, "Imposible iniciar examen")
            Exit Sub
        End If

        Dim aux_sex As String = ""
        If botonMsexo.Checked = True Then aux_sex = "M" 'antes decia Masculino entero
        If botonFsexo.Checked = True Then aux_sex = "F" 'antes decia femenino entero
        If paciente_nuevo = True Then

            If revisar_dni_unico() = False Then
                Exit Sub
            End If

            'meter paciente nuevo a la base de datos
            If MsgBox("Se añadira al siguiente paciente a la base de datos:" & vbCrLf & _
                      "Nombre: " & TextNombre.Text & vbCrLf & _
                      "Apellido: " & TextApellido.Text & vbCrLf & _
                      "Edad: " & TextEdad.Text & vbCrLf & _
                       "DNI: " & TextDNI.Text & vbCrLf & _
                        "Sexo: " & aux_sex & vbCrLf & _
                      "Domicilio: " & TextDomicilio.Text & vbCrLf & _
                      "Telefono: " & TextTelefono.Text, MsgBoxStyle.OkCancel, "Nuevo Paciente") = MsgBoxResult.Ok Then
                InsertarPaciente(TextNombre, TextApellido, TextEdad, TextDomicilio, TextTelefono, TextDNI, aux_sex)
                txtfechaexamen.Text = todaysdate
                fecha_examen = todaysdate
                paciente_ingresado = True

                estado_pestañas = 2
                tabpersonalesterminada()

                escritor_general.Write("DATOS-PACIENTE" & vbCrLf)
                escritor_general.Write(TextDNI.Text & vbCrLf)


                If (InternadoSI.Checked = True) Then
                    escritor_general.Write("SI" & vbCrLf)
                Else
                    If (InternadoNO.Checked = True) Then
                        escritor_general.Write("NO" & vbCrLf)
                    Else
                        escritor_general.Write("" & vbCrLf)
                    End If

                End If
                'ahora guardo ritmo de base, sintomas de ingreso y el staff
                escritor_general.Write(TextRitmo.Text & vbCrLf)
                escritor_general.Write(TextSintoma.Text & vbCrLf)
                escritor_general.Write(txtfechaexamen.Text & vbCrLf)

                If (estado_mandante_externo = True) Then
                    escritor_general.Write("SI" & vbCrLf)
                Else
                    escritor_general.Write("NO" & vbCrLf)
                End If

                escritor_general.Write(cbxMandante.Text & vbCrLf)
                escritor_general.Write(cbxActuante.Text & vbCrLf)
                escritor_general.Write(cbxTecnico.Text & vbCrLf)
                estado_recuperar = "DATOS-PACIENTE-Pasado"
                ComboBoxProtocolo.SelectedIndex = 0

            Else
                paciente_nuevo = False
                Exit Sub
            End If
        Else
            If MsgBox("Se realizara el estudio al siguiente paciente:" & vbCrLf & _
               "Nombre: " & TextNombre.Text & vbCrLf & _
               "Apellido: " & TextApellido.Text & vbCrLf & _
               "Edad: " & TextEdad.Text & vbCrLf & _
                "DNI: " & TextDNI.Text & vbCrLf & _
                 "Sexo: " & aux_sex & vbCrLf & _
               "Domicilio: " & TextDomicilio.Text & vbCrLf & _
               "Telefono: " & TextTelefono.Text, MsgBoxStyle.OkCancel, "Siguiente") = MsgBoxResult.Ok Then

                paciente_ingresado = True
                txtfechaexamen.Text = todaysdate
                fecha_examen = todaysdate
                'ACA IRIA LA PARTE DE CONFIRMAR AL PACIENTE COMO PARTE DEL EXAMEN
                'estado_protocolo = True
                estado_pestañas = 2
                tabpersonalesterminada()
                PictureBoxSalirProtocolo.Visible = True
                PictureBoxSalirProtocolo.Enabled = True

                'imprimo el dni del paciente, de manera tal que al abrir un estudio recuperado pueda poner al paciente que habia
                escritor_general.Write("DATOS-PACIENTE" & vbCrLf)
                escritor_general.Write(TextDNI.Text & vbCrLf)

                If (InternadoSI.Checked = True) Then
                    escritor_general.Write("SI" & vbCrLf)
                Else
                    If (InternadoNO.Checked = True) Then
                        escritor_general.Write("NO" & vbCrLf)
                    Else
                        escritor_general.Write("" & vbCrLf)
                    End If
                End If

                'ahora guardo ritmo de base, sintomas de ingreso y el staff
                escritor_general.Write(TextRitmo.Text & vbCrLf)
                escritor_general.Write(TextSintoma.Text & vbCrLf)
                escritor_general.Write(txtfechaexamen.Text & vbCrLf)

                If (CheckBoxMandanteExterno.Checked = True) Then
                    escritor_general.Write("SI" & vbCrLf)
                Else
                    escritor_general.Write("NO" & vbCrLf)
                End If

                escritor_general.Write(cbxMandante.Text & vbCrLf)
                escritor_general.Write(cbxActuante.Text & vbCrLf)
                escritor_general.Write(cbxTecnico.Text & vbCrLf)
                estado_recuperar = "DATOS-PACIENTE-Pasado"
                ComboBoxProtocolo.SelectedIndex = 0
            Else

                Exit Sub
            End If
        End If
    End Sub

    'EVENTO MOUSE SOBRE BOTON SIGUIENTE
    Private Sub botonsiguiente_MouseEnter(sender As Object, e As EventArgs) Handles botonsiguiente.MouseEnter
        botonsiguiente.BackColor = Color.LightGray
    End Sub

    'EVENTO MOUSE SALE DEL BOTONO SIGUIENTE
    Private Sub botonsiguiente_MouseLeave(sender As Object, e As EventArgs) Handles botonsiguiente.MouseLeave
        botonsiguiente.BackColor = Color.Transparent
    End Sub

    'DEJA LA TAB PERSONALES INHABILITADA UNA VEZ QUE SE PASA A LA SIGUIENTE ETAPA
    Public Sub tabpersonalesterminada()
        TextNombre.Enabled = True
        TextNombre.ReadOnly = True
        TextApellido.Enabled = True
        TextApellido.ReadOnly = True
        TextEdad.Enabled = True
        TextEdad.ReadOnly = True
        TextDNI.Enabled = True
        TextDNI.ReadOnly = True
        TextDomicilio.Enabled = True
        TextDomicilio.ReadOnly = True
        TextTelefono.Enabled = True
        TextTelefono.ReadOnly = True

        TextRitmo.Enabled = True
        TextRitmo.ReadOnly = True
        TextSintoma.Enabled = True
        TextSintoma.ReadOnly = True
        txtfechaexamen.Enabled = True
        txtfechaexamen.ReadOnly = True

        cbxMandante.Enabled = False
        cbxActuante.Enabled = False
        cbxTecnico.Enabled = False

        CheckBoxMandanteExterno.Enabled = False

        Panelsexo.Enabled = False
        PanelINT.Enabled = False

        tickpersonales.Visible = True

        If edicion_personales = False Then
            habilitarprotocolo()
        End If

        PictureBoxEditarPaciente.Enabled = False
        PictureBoxEditarPaciente.Visible = False

        estado_datos = True
        TabGeneral.SelectedIndex = 1
        TabPersonales.Text = "   Datos Paciente " & ChrW(&H2714) & "  "
    End Sub

    'esto deja todo listo para la proxima vez que se llame a la funcion GO_nuevo paciente/ viejo paciente/ examen viejo
    Public Sub tabpersonalesreiniciada()
        TextNombre.Enabled = False
        TextNombre.ReadOnly = False
        TextNombre.Clear()
        TextApellido.Enabled = False
        TextApellido.ReadOnly = False
        TextApellido.Clear()
        TextEdad.Enabled = False
        TextEdad.ReadOnly = False
        TextEdad.Clear()
        TextDNI.Enabled = False
        TextDNI.ReadOnly = False
        TextDNI.Clear()
        TextDomicilio.Enabled = False
        TextDomicilio.ReadOnly = False
        TextDomicilio.Clear()
        TextTelefono.Enabled = False
        TextTelefono.ReadOnly = False
        TextTelefono.Clear()

        TextRitmo.Enabled = False
        TextRitmo.ReadOnly = False
        TextRitmo.Clear()
        TextSintoma.Enabled = False
        TextSintoma.ReadOnly = False
        TextSintoma.Clear()
        txtfechaexamen.Enabled = False
        txtfechaexamen.ReadOnly = False

        cbxMandante.Enabled = True
        cbxActuante.Enabled = True
        cbxTecnico.Enabled = True

        Panelsexo.Enabled = True
        PanelINT.Enabled = True
        botonMsexo.Checked = False
        botonFsexo.Checked = False
        tickpersonales.Visible = False
        botonsiguiente.Visible = True
        botonsiguiente.Enabled = True
    End Sub
    'HABILITA PESTAÑA PROTOCOLOS
    Public Sub habilitarprotocolo()
        Panel4.Enabled = True
        Panel5.Enabled = True
        Panel6.Enabled = True
        Panel7.Enabled = True
        Panel8.Enabled = True
        Panel9.Enabled = True
        Panel10.Enabled = True

        TextINTE3.Enabled = True
        TextINTE9.Enabled = True

        TextProtocolo.Enabled = True
        ComboBoxProtocolo.Enabled = True
        botonsiguienteprotocolo.Enabled = True
        botonsiguienteprotocolo.Visible = True
        botonsiguienteprotocolo.BackColor = Color.Transparent

        botonAnteriorProtocolo.Enabled = True
        botonAnteriorProtocolo.Visible = True


        PictureBoxSalirProtocolo.Visible = True
        PictureBoxSalirProtocolo.Enabled = True

        Dim e As EventArgs = AcceptButton

        ComboBoxProtocolo.SelectedIndex = 0
        ComboBoxProtocolo_SelectedIndexChanged(ComboBoxProtocolo, e)
        'AHORA SE PONE EN TRUE REDCIEN CUANDO SE TERMINAAAA
        estado_protocolo = False
        TabPreguntas.Text = "    Interrogatorio y Protocolo    "
        orden_tabulacion_protocolo()
        'aca arranco a pedir datos----------------------------
        Try
            EnviarDatos("CAL")
        Catch ex As Exception

        End Try

    End Sub
    'DESHABILITA PESTAÑA PROTOCOLOS
    Public Sub protocoloterminado()
        Panel4.Enabled = False
        Panel5.Enabled = False
        Panel6.Enabled = False
        Panel7.Enabled = False
        Panel8.Enabled = False
        Panel9.Enabled = False
        Panel10.Enabled = False

        TextINTE3.Enabled = False
        TextINTE9.Enabled = False

        TextINTE3.ReadOnly = True
        TextINTE9.ReadOnly = True

        TextProtocolo.Enabled = False
        ComboBoxProtocolo.Enabled = False
        tickprotocolo.Visible = True
        tickprotocolo.Enabled = True
        '   IniciarExamen.Enabled = True
        'TabGeneral.SelectedIndex = 2

        'UNA VEZ QUE TERMINA PROTOCOLO LO INDICO CON EL TRUE DE LA VARIABLE DE ESTADO
        estado_protocolo = True
        estado_examen_ahora = True


        '  botonsiguienteprotocolo.BackColor = Color.DimGray
        ' botonsiguienteprotocolo.Enabled = 
        TabGeneral.SelectedIndex = 2

        TabPreguntas.Text = "   Interrogatorio y Protocolo " & ChrW(&H2714) & "  "

        Examen.Text = "    Examen    "
        Grafico.Text = "   Gráfico    "
        TirasECG.Text = "   Tiras y Conclusión    "
    End Sub
    'BOTON PARA PASAR DE PROTOCOLOS A EXAMEN
    Private Sub botonsiguienteprotocolo_Click(sender As Object, e As EventArgs) Handles botonsiguienteprotocolo.Click
        If edicion_protocolo = True Then
            tabprotocoloseditada()
            Exit Sub
        End If

        If estado_protocolo = True Then
            TabGeneral.SelectedIndex = 2
            Exit Sub
        End If

        If MsgBox("Dar por terminado el protocolo e iniciar el examen?", MsgBoxStyle.YesNo, "Siguiente") = MsgBoxResult.No Then
            Exit Sub
        Else
            esconder_respuestas_no_elegidas()
            protocoloterminado()
            'GUARDO LAS RESPUESTAS DE PROTOCOLO EN EL ARCHIVO DE RECUPERACION
            escritor_general.Write("DATOS-PROTOCOLO" & vbCrLf)
            'PREG 1
            If INTE1SI.Checked = True Then
                escritor_general.Write("SI" & vbCrLf)
            Else
                'antes aca le ponia no derecho
                If INTE1NO.Checked = True Then
                    escritor_general.Write("NO" & vbCrLf)
                Else
                    escritor_general.Write("  " & vbCrLf)
                End If
            End If
            'PREG2
            If INTE2SI.Checked = True Then
                escritor_general.Write("SI" & vbCrLf)
            Else
                If INTE2NO.Checked = True Then
                    escritor_general.Write("NO" & vbCrLf)
                Else
                    escritor_general.Write("  " & vbCrLf)
                End If
            End If
            'PREG3
            escritor_general.Write(TextINTE3.Text & vbCrLf)
            'PREG4
            If INTE4SI.Checked = True Then
                escritor_general.Write("SI" & vbCrLf)
            Else
                If INTE4NO.Checked = True Then
                    escritor_general.Write("NO" & vbCrLf)
                Else
                    escritor_general.Write("  " & vbCrLf)
                End If
            End If
            'PREG5
            If INTE5SI.Checked = True Then
                escritor_general.Write("SI" & vbCrLf)
            Else
                If INTE5NO.Checked = True Then
                    escritor_general.Write("NO" & vbCrLf)
                Else
                    escritor_general.Write("  " & vbCrLf)
                End If
            End If
            'PREG6
            If INTE6SI.Checked = True Then
                escritor_general.Write("SI" & vbCrLf)
            Else
                If INTE6NO.Checked = True Then
                    escritor_general.Write("NO" & vbCrLf)
                Else
                    If INTE6NOSABE.Checked = True Then
                        escritor_general.Write("NOSABE" & vbCrLf)
                    Else
                        escritor_general.Write("  " & vbCrLf)
                    End If
                End If
            End If
            'PREG 7
            If INTE7SI.Checked = True Then
                escritor_general.Write("SI" & vbCrLf)
            Else
                If INTE7NO.Checked = True Then
                    escritor_general.Write("NO" & vbCrLf)
                Else
                    escritor_general.Write("  " & vbCrLf)
                End If

            End If
            'PREG 8
            If INTE8SI.Checked = True Then
                escritor_general.Write("SI" & vbCrLf)
            Else
                If INTE8NO.Checked = True Then
                    escritor_general.Write("NO" & vbCrLf)
                Else
                    escritor_general.Write("  " & vbCrLf)
                End If
            End If
            'PREG 9
            escritor_general.Write(TextINTE9.Text & vbCrLf)

            'imprimo el nombre del protocolo en lugar de su descripcion
            escritor_general.Write(ComboBoxProtocolo.Text & vbCrLf)

            'aca arranco a pedir datos----------------------------
            Try
                EnviarDatos("CAL")
            Catch ex As Exception

            End Try
            habilitar_examen_ahora()
            Iniciar_examen_en_basal()
        End If
    End Sub

    'SUBRUTINA QUE GUARDA EL EXAMEN EN LA BASE DE DATOS
    Sub guardar_examen()
        guardar_datos()
        Dim aux_internado As Boolean
        Dim aux_tecnico As Integer
        Dim aux_mandante As Integer
        Dim aux_actuante As Integer
        aux_tecnico = Convert.ToInt32(cbxTecnico.Text.Substring(0, 1))
        Try
            aux_mandante = Convert.ToInt32(cbxMandante.Text.Substring(0, 1))
        Catch ex As Exception
            aux_mandante = 0
        End Try
        aux_actuante = Convert.ToInt32(cbxActuante.Text.Substring(0, 1))
        guardar_tiras()
        Dim ver_aux As String = aux_datos_ecg
        'ahora creo la lista de parametros SQL
        SQL.AddParam("@dni", TextDNI.Text)
        SQL.AddParam("@nombre", TextNombre.Text)
        SQL.AddParam("@apellido", TextApellido.Text)
        'hay que pasar fecha como fecha no como texto
        SQL.AddParam("@fecha", fechahoy)
        SQL.AddParam("@idtecnico", aux_tecnico)
        SQL.AddParam("@idmandante", aux_mandante)
        SQL.AddParam("@idactuante", aux_actuante)
        SQL.AddParam("@datos", aux_datos)
        SQL.AddParam("@sintomas", TextSintoma.Text)
        SQL.AddParam("@ritmo", TextRitmo.Text)
        SQL.AddParam("@ECG", ver_aux)
        SQL.AddParam("@Tiras", tiras_aux)
        SQL.AddParam("@conclusion", conclusiontext.Text)
        If InternadoSI.Checked = True Then aux_internado = True
        If InternadoNO.Checked = True Then aux_internado = False
        SQL.AddParam("@internado", aux_internado)

        If aux_mandante = 0 Then
            SQL.AddParam("@externo", cbxMandante.Text)
        Else

            SQL.AddParam("@externo", "")
        End If
        SQL.ExecQuery("INSERT INTO Examen (DNIpaciente, NombrePaciente, ApellidoPaciente, Fecha, IdTecnico, IdMandante, IdActuante, Sintomas, Ritmo, internado, Datos,Tiras, Conclusion, ECG , MandanteExterno) VALUES (@dni, @nombre, @apellido, @fecha, @idtecnico, @idmandante, @idactuante, @sintomas, @ritmo, @internado, @datos,@tiras, @conclusion, @ECG , @externo);")
        SQL.AddParam("@ECG2", aux_datos_ecg)
        SQL.AddParam("@dni", TextDNI.Text)
        SQL.AddParam("@fecha", fechahoy)
        SQL.ExecQuery("UPDATE Examen SET ECG =@ECG2 WHERE DNIpaciente = @dni AND Fecha= @fecha;")
        If SQL.HasException(True) Then Exit Sub
        MsgBox("Se ha guardado el examen!")
        escritor_general.Write("BIEN-GUARDADO")
        escritor_ecg.Write("BIEN-GUARDADO")
        escritor_evento.Write("BIEN-GUARDADO")
        Salir_Examen()
        GO_Inicio()
    End Sub


    'SI CAMBIA ALGO DEL DATA GRID DEJO EL COLOR ROJO
    Public Sub DatosExamen_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles DatosExamen.CellValueChanged
        If deshacer_estado = True Then
            Exit Sub
        End If
        'aca va a haber que tener en cuenta cuando el cambio proviene de un recupero de archivo temporal
        Try
            DatosExamen.Item(columnas(contador_cambios - 1), filas(contador_cambios - 1)).Style.BackColor = Color.Red
            'aca guardo ante un cambio de celda en el txt temporal
            'primero un codigo para reconocer que se viene un cambio manual
            ' luego la columna y fila donde se hizo dicho cambio manual
            'por ultimo archivo el nuevo valor
            escritor_general.Write("ROJOROJOROJO35126793" & vbCrLf)
            escritor_general.Write(columnas(contador_cambios - 1) & vbCrLf)
            escritor_general.Write(filas(contador_cambios - 1) & vbCrLf)
            escritor_general.Write(DatosExamen.Item(columnas(contador_cambios - 1), filas(contador_cambios - 1)).Value.ToString() & vbCrLf)
            'ademas de guardarlo y cambiar el color de la celda- tengo que dejar con modo wrap on
            DatosExamen.Rows(filas(contador_cambios - 1)).DefaultCellStyle.WrapMode = DataGridViewTriState.True
        Catch ex As Exception

        End Try

        Try
            'si no saco todo y los vuelvo a poner
            For k As Integer = 0 To Chart1.Series("FC").Points.Count - 1
                Chart1.Series("FC").Points.RemoveAt(0)
                Chart1.Series("PD").Points.RemoveAt(0)
                Chart1.Series("PS").Points.RemoveAt(0)
            Next
            For j As Integer = 0 To aux_filas_datagrid - 1
                Chart1.Series("FC").Points.AddXY(tiempo(j), FC(j))
                Chart1.Series("PS").Points.AddXY(tiempo(j), PS(j))
                Chart1.Series("PD").Points.AddXY(tiempo(j), PD(j))
                For u As Integer = 0 To contador_cambios - 1
                    If j = filas(u) Then
                        ' aca hay que ver columna es
                        Select Case columnas(u)

                            Case 2
                                Chart1.Series("FC").Points.RemoveAt(j)
                                Chart1.Series("FC").Points.AddXY(tiempo(j), DatosExamen.Item(columnas(u), filas(u)).Value)

                            Case 3
                                Chart1.Series("PS").Points.RemoveAt(j)
                                Chart1.Series("PS").Points.AddXY(tiempo(j), DatosExamen.Item(columnas(u), filas(u)).Value)

                            Case 4
                                Chart1.Series("PD").Points.RemoveAt(j)
                                Chart1.Series("PD").Points.AddXY(tiempo(j), DatosExamen.Item(columnas(u), filas(u)).Value)

                        End Select
                    End If
                Next
            Next
        Catch ex As Exception
        End Try
    End Sub

    'BOTON QUE ME LLEVA AL FORMULARIO DE BUSCAR EXAMENES
    Private Sub botonbuscarexamen_Click(sender As Object, e As EventArgs) Handles botonbuscarexamen.Click
        Busquedaexamen.Show()
        Busquedaexamen.BringToFront()
        TabGeneral.SendToBack()
    End Sub

    'BOTON QUE LLEVA AL FORMULARIO DE 
    Private Sub botonPlantillas_Click(sender As Object, e As EventArgs) Handles botonPlantillas.Click
        Plantillas.Show()
        Plantillas.BringToFront()
        TabGeneral.SendToBack()
    End Sub

    'CARGAR EL COMBO BOX DE PLANTILLA
    Public Sub Loadcomboboxplantilla(combo As ComboBox, tabla As String)
        'refresco el contenido de la combobox
        combo.Items.Clear()
        'ejecuto la query
        SQL.ExecQuery("SELECT * From Plantillas;")
        If SQL.HasException(True) Then Exit Sub
        'loop row & sumar al combobox
        For Each r As DataRow In SQL.DBDT.Rows
            Dim a0 As String = r("Nombre")
            combo.Items.Add(a0)
        Next
    End Sub

    'CARGAR EL COMBO BOX DE PROTOCOLO   
    Public Sub Loadcomboboxprotocolo(combo As ComboBox, tabla As String)
        'refresco el contenido de la combobox
        combo.Items.Clear()
        'ejecuto la query
        SQL.ExecQuery("SELECT * From Protocolos;")
        If SQL.HasException(True) Then Exit Sub
        'loop row & sumar al combobox
        For Each r As DataRow In SQL.DBDT.Rows
            Dim a0 As String = r("Nombre")
            a0 = a0.Trim()
            combo.Items.Add(a0)
        Next
        ' combo.SelectedIndex = 0
    End Sub

    'EVENTO EL COMBO BOX DE CONCLUSIONES CAMBIA
    Private Sub cbxConclusiones_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxConclusiones.SelectedIndexChanged
        Dim plantillaNombre As String = cbxConclusiones.Text
        SQL.AddParam("@nombreplantilla", plantillaNombre)
        SQL.ExecQuery("SELECT Texto From Plantillas WHERE Nombre=@nombreplantilla;")
        If SQL.HasException(True) Then Exit Sub
        For Each r As DataRow In SQL.DBDT.Rows
            Dim a0 As String = r("Texto")
            conclusiontext.Text = a0.Trim()
        Next
    End Sub

    'boton que esta en la primer pestaña, se activa cuando el examen no esta en blanco completo - 
    Private Sub PictureBoxSalirPaciente_Click(sender As Object, e As EventArgs) Handles PictureBoxSalirPaciente.Click
        If estado_examen_viejo = True Then
            Salir_Examen()
            GO_Inicio()
            Exit Sub
        End If
        If MsgBox("Esta seguro que desea salir del examena actual? Los datos no guardados se perderán.", MsgBoxStyle.YesNo, "Salir Examen") = MsgBoxResult.Yes Then
            Salir_Examen()
            GO_Inicio()
        End If
    End Sub

    'rutina que cierra y deja todo en blanco <------- FALTA TERMINARLA
    Private Sub Salir_Examen()
        Try
            Enviar_INO("0")
        Catch ex As Exception

        End Try
        If evento_iniciado = True Then
            Iniciar_terminar_eventos()
        End If
        'primero limpio los datos del paciente y dejo las cosas disabled
        TextNombre.Enabled = False
        TextNombre.ReadOnly = True
        TextNombre.Clear()
        TextApellido.Enabled = False
        TextApellido.ReadOnly = True
        TextApellido.Clear()
        TextDNI.Enabled = False
        TextDNI.ReadOnly = True
        TextDNI.Clear()
        TextEdad.Enabled = False
        TextEdad.ReadOnly = True
        TextEdad.Clear()
        TextDomicilio.Enabled = False
        TextDomicilio.ReadOnly = True
        TextDomicilio.Clear()
        TextTelefono.Enabled = False
        TextTelefono.ReadOnly = True
        TextTelefono.Clear()
        Panelsexo.Enabled = False
        botonMsexo.Checked = False
        botonFsexo.Checked = False
        paciente_nuevo = False
        'ahora los datos relativos al examen
        PanelINT.Enabled = True
        InternadoSI.Checked = False
        InternadoNO.Checked = False
        TextSintoma.Enabled = True
        TextSintoma.ReadOnly = False
        TextSintoma.Clear()
        TextRitmo.Enabled = True
        TextRitmo.ReadOnly = False
        TextRitmo.Clear()
        txtfechaexamen.Clear()
        txtfechaexamen.Enabled = True
        cbxMandante.ResetText()
        cbxMandante.SelectedIndex = -1
        cbxMandante.Enabled = True
        Labelmandante.Visible = False
        cbxActuante.ResetText()
        cbxActuante.SelectedIndex = -1
        cbxActuante.Enabled = True
        Labelactuante.Visible = False
        cbxTecnico.ResetText()
        cbxTecnico.SelectedIndex = -1
        cbxTecnico.Enabled = True
        Labeltecnico.Visible = False
        tickpersonales.Visible = False
        botonsiguiente.Enabled = True
        '--------------------hasta aca se limpio la pestaña de paciente y staff
        ' falta limpiar las pestañas que quedan
        'limpiar protocolo
        Panel4.Enabled = False
        INTE1SI.Checked = False
        INTE1NO.Checked = False
        Panel5.Enabled = False
        INTE2SI.Checked = False
        INTE2NO.Checked = False
        TextINTE3.Text = ""
        TextINTE3.Enabled = False
        Panel6.Enabled = False
        INTE4SI.Checked = False
        INTE4NO.Checked = False
        Panel7.Enabled = False
        INTE5SI.Checked = False
        INTE5NO.Checked = False
        Panel8.Enabled = False
        INTE6SI.Checked = False
        INTE6NO.Checked = False
        INTE6NOSABE.Checked = False
        Panel9.Enabled = False
        INTE7SI.Checked = False
        INTE7NO.Checked = False
        Panel10.Enabled = False
        INTE8SI.Checked = False
        INTE8NO.Checked = False
        TextINTE9.Enabled = False
        TextINTE9.Text = ""
        ComboBoxProtocolo.SelectedIndex = 0
        TextProtocolo.Text = ""
        'hasta aca esta interrogatorio y protocolo
        'ahora hay que vaciar datagrid y graphic chart
        DatosExamen.Rows.Clear()
        Chart1.Series("FC").Points.Clear()
        Chart1.Series("PS").Points.Clear()
        Chart1.Series("PD").Points.Clear()
        'AHORA LIMPIO LAS CONCLUSIONES
        cbxConclusiones.SelectedIndex = -1
        conclusiontext.Text = ""
        'ahora tengo que dejar en blanco los txt
        'podria cerrarlos y volverlos a abrir
        escritor_general.Close()
        escritor_general = New StreamWriter(FILE_GENERAL)
        escritor_ecg.Close()
        escritor_ecg = New StreamWriter(FILE_ECG)
        escritor_evento.Close()
        escritor_evento = New StreamWriter(FILE_EVENTO)
        'apagar timers
        TimerReal.Enabled = False
        TimerEnvio.Enabled = True
        unisegundos = 0
        decsegundos = 0
        uniminutos = 0
        decminutos = 0
        TextBoxTiempo.Text = decminutos & uniminutos & ":" & decsegundos & unisegundos
        estado_basal = False
        estado_etapa1 = False
        estado_etapa2 = False
        estado_etapa3 = False
        estado_recuperacion = False
        botonPresion.Enabled = False
        botonModificarPresion.Enabled = False
        botonModificarPresion.Visible = False
        iconoPlayPaciente.Enabled = True
        iconoPlayProtocolos.Enabled = True
        iconoPlayExamen.Enabled = True
        botonTerminarExamen.Enabled = False
        botonSiguienteEtapa.Enabled = False
        iconoImprimirPDF.Enabled = False
        iconoImprimirPDF.Visible = False
        iconoGuardarExamen.Enabled = False
        iconoGuardarExamen.Visible = False
        botonEditarEvento.Enabled = False
        botonCancelarEdicionEvento.Enabled = False
        botonCancelarEdicionEvento.Visible = False
        botonTerminarExamen.Text = "Iniciar Recuperación"
        sistolica = 0
        diastolica = 0
        txtsistolica.Text = "---"
        txtdiastolica.Text = "---"
        ListBoxeventos.Items.Clear()
        contador_display = 0
        contador_cambios = 0
        contador_display_print = 0
        contador_ECG_nuevo = 0
        contador_ecg2 = 0
        contador_eventos = 0
        contador_tiras = 0
        eventos = ""

        For i As Integer = 0 To inicio_Ereloj.Count - 1
            inicio_Ereloj(i) = Nothing
        Next

        For i As Integer = 0 To inicio_evento.Count - 1
            inicio_evento(i) = Nothing
        Next

        For i As Integer = 0 To fin_Ereloj.Count - 1
            fin_Ereloj(i) = Nothing
        Next

        For i As Integer = 0 To fin_evento.Count - 1
            fin_evento(i) = Nothing
        Next

        For i As Integer = 0 To inicio_evento.Count - 1
            stopW_eventos(0, i) = Nothing
            stopW_eventos(1, i) = Nothing
            stopW_eventos(2, i) = Nothing
        Next

        limpiar_eventos()

        'pongo los estados a false
        paciente_ingresado = False
        paciente_nuevo = False
        examen_abierto = False
        examen_en_pausa = False
        service_tuerca = False
        edicion_personales = False
        edicion_protocolo = False
        editando_eventos = False
        examen_iniciado = False
        ventana_inicial = True
        estado_datos = False
        estado_protocolo = False
        estado_examen_ahora = False
        estado_examen_viejo = False
        estado_examen_viejo_recuperado = False
        estado_mandante_externo = False
        estado_examen_terminado = False
        TabGeneral.SelectedIndex = 0
        estado_editando_paciente_viejo = False
        edicion_personales = False
        tickpersonales.BackColor = Color.Transparent
        PictureBoxEditarPaciente.BackColor = Color.Transparent
        'reseteo el stopwatch para que no haga overflow, cambio hecho en junio
        '  reloj_global.Reset()
        'LO COMENTO PORQUE SALTO UN ERROR
    End Sub

    'EVENTO SALIR DE ARRIBA DEL BOTON SALIR
    Private Sub PictureBoxSalirPaciente_MouseEnter(sender As Object, e As EventArgs) Handles PictureBoxSalirPaciente.MouseEnter
        PictureBoxSalirPaciente.BackColor = Color.LightGray
    End Sub

    'funcion pedir datos
    Function EnviarDatos(pedido As String)
        'creo la instancia de un stream para la comunicación
        Dim serverStream As NetworkStream = clientSocket.GetStream()
        'el outstream es por donde envio data al arduino, le paso el string "pedido" y lo envia
        Dim outStream As Byte() = System.Text.Encoding.ASCII.GetBytes(pedido)
        'write escribe el outsream en el arduino
        serverStream.Write(outStream, 0, 3)
        'flush limpia lo que queda en el stream para dejarlo en limpio para recibir data 
        serverStream.Flush()
        Return "--"
    End Function
    'FUNCION ENVIAR INCLINACION
    Function Enviar_INO(inclinacion As String)
        'creo la instancia de un stream para la comunicación
        Dim datos As String = "INO"
        datos = datos + inclinacion
        datos = datos + "*"
        Dim serverStream As NetworkStream = clientSocket.GetStream()
        'el outstream es por donde envio data al arduino, le paso el string "pedido" y lo envia
        Dim outStream As Byte() = System.Text.Encoding.ASCII.GetBytes(datos)
        serverStream.Write(outStream, 0, datos.Length)
        'flush limpia lo que queda en el stream para dejarlo en limpio para recibir data 
        serverStream.Flush()
        Return 0
    End Function

    'EVENTOS DE ENTRAR Y SALIR DEL BOTON DE SALIR EXAMEN
    Private Sub Paciente_MouseLeave(sender As Object, e As EventArgs) Handles PictureBoxSalirPaciente.MouseLeave
        ' PictureBoxfondosalir.Visible = False
        PictureBoxSalirPaciente.BackColor = Color.Transparent
    End Sub
    'EVENTO DE MOUSE ENTER EN PICTURE BOX
    Private Sub PictureBoxSalirProtocolo_MouseEnter(sender As Object, e As EventArgs) Handles PictureBoxSalirProtocolo.MouseEnter
        PictureBoxSalirProtocolo.BackColor = Color.LightGray
    End Sub
    'EVENTO DE MOUSE SALIENDO DEL PICTURE BOX
    Private Sub PictureBoxSalirProtocolo_MouseLeave(sender As Object, e As EventArgs) Handles PictureBoxSalirProtocolo.MouseLeave
        PictureBoxSalirProtocolo.BackColor = Color.Transparent
    End Sub
    'EVENT CLICK EN PICTURE BOX SALIR 
    Private Sub PictureBoxSalirProtocolo_Click(sender As Object, e As EventArgs) Handles PictureBoxSalirProtocolo.Click
        If estado_examen_viejo = True Then
            Salir_Examen()
            GO_Inicio()
            Exit Sub
        End If

        If MsgBox("Esta seguro que desea salir del examena actual? Los datos no guardados se perderán.", MsgBoxStyle.YesNo, "Salir Examen") = MsgBoxResult.Yes Then
            Salir_Examen()
            GO_Inicio()
        End If
    End Sub
    'SUBRUTINA PARA DESHACER CAMBIOS MANUALES EN LA TABLA
    Private Sub botonDeshacer_Click(sender As Object, e As EventArgs) Handles botonDeshacer.Click
        deshacer_estado = True
        For i As Integer = 0 To (contador_cambios - 1)
            DatosExamen.Item(columnas(i), filas(i)).Value = originales(i).ToString()
            DatosExamen.Item(columnas(i), filas(i)).Style.BackColor = Color.White
            escritor_general.Write("ROJOROJOROJO35126793" & vbCrLf)
            escritor_general.Write(columnas(i) & vbCrLf)
            escritor_general.Write(filas(i) & vbCrLf)
            escritor_general.Write(DatosExamen.Item(columnas(i), filas(i)).Value.ToString() & vbCrLf)
            'ademas de guardarlo y cambiar el color de la celda- tengo que dejar con modo wrap on
            DatosExamen.Rows(filas(i)).DefaultCellStyle.WrapMode = DataGridViewTriState.True
        Next

        'si no saco todo y los vuelvo a poner
        For k As Integer = 0 To Chart1.Series("FC").Points.Count - 1
            Chart1.Series("FC").Points.RemoveAt(0)
            Chart1.Series("PS").Points.RemoveAt(0)
            Chart1.Series("PD").Points.RemoveAt(0)
        Next

        For j As Integer = 0 To aux_filas_datagrid - 1
            Chart1.Series("FC").Points.AddXY(tiempo(j), FC(j))
            Chart1.Series("PS").Points.AddXY(tiempo(j), PS(j))
            Chart1.Series("PD").Points.AddXY(tiempo(j), PD(j))
        Next
        deshacer_estado = False
    End Sub
    'SUBRUTINA EN CASO DE EVENTO DE EDICION DE CELDAS
    Private Sub DatosExamen_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles DatosExamen.CellBeginEdit
        Try
            originales(contador_cambios) = DatosExamen.CurrentCell.Value
            filas(contador_cambios) = DatosExamen.CurrentRow.Index
            columnas(contador_cambios) = DatosExamen.CurrentCell.ColumnIndex
            contador_cambios = contador_cambios + 1
        Catch ex As Exception

        End Try

    End Sub
    'VALIDACION DE CAMBIOS MANUALES EN CELDAS
    Private Sub DatosExamen_CellValidating(sender As Object, e As DataGridViewCellValidatingEventArgs) Handles DatosExamen.CellValidating
        If DatosExamen.CurrentCell.ColumnIndex > 1 Then
            If Not IsNumeric(e.FormattedValue) Then
                e.Cancel = True
            End If
        End If
    End Sub
    'BOTON IR A PROTOCOLOS EN SERVICIO TENCICO
    Private Sub botonProtocolos_Click(sender As Object, e As EventArgs) Handles botonProtocolos.Click
        Protocolo.Show()
        Protocolo.BringToFront()
        TabGeneral.SendToBack()
    End Sub
    '
    Private Sub scrollecg_Scroll(sender As Object, e As ScrollEventArgs)

        'Dim paso As Integer = stopW_eventos(2, indice_evento)

        'Dim offset As Integer = (inicio_Ereloj(indice_evento).Second + inicio_Ereloj(indice_evento).Minute * 60) + scrollecg.Value * paso / 1000



        '' aca estaba hasta "TO ventana"
        'For i As Integer = 0 To ChartEventos.Series("ECG").Points.Count - 1
        '    Try
        '        ChartEventos.Series("ECG").Points.RemoveAt(0)
        '    Catch ex As Exception

        '    End Try
        'Next


        '' Dim index As Integer = 

        'ChartEventos.ChartAreas("ChartArea1").AxisX.Interval = 29

        'For i As Integer = scrollecg.Value + inicio_evento(indice_evento) To scrollecg.Value + inicio_evento(indice_evento) + ventana
        '    Try
        '        'ChartEventos.Series("ECG").Points.AddY(auxiliar_eventos(i))

        '        If editando_eventos = True Then

        '            If i > eventos_editados(1, contador_eventos_editados - 1) Then
        '                If i < scrollecg.Value + inicio_evento(indice_evento) + Punto_entero Then

        '                    ChartEventos.Series("ECG").Points.AddXY(paso * (i - scrollecg.Value - inicio_evento(indice_evento)) / 1000 + offset, auxiliar_eventos(i))

        '                    ChartEventos.Series("ECG").Points(ChartEventos.Series("ECG").Points.Count - 1).Color = Color.Red

        '                    ' ChartEventos.Series("ECG").Points(ChartEventos.Series("ECG").Points.Count - 1).MarkerColor = Color.Red

        '                Else

        '                    ChartEventos.Series("ECG").Points.AddXY(paso * (i - scrollecg.Value - inicio_evento(indice_evento)) / 1000 + offset, auxiliar_eventos(i))


        '                End If

        '            Else

        '                ChartEventos.Series("ECG").Points.AddXY(paso * (i - scrollecg.Value - inicio_evento(indice_evento)) / 1000 + offset, auxiliar_eventos(i))

        '            End If


        '        Else

        '            ChartEventos.Series("ECG").Points.AddXY((paso * (i - scrollecg.Value - inicio_evento(indice_evento)) / 1000) + offset, auxiliar_eventos(i))


        '        End If


        '        '  ChartEventos.Series("ECG").Points.AddXY(paso * (i - scrollecg.Value - inicio_evento(indice_evento)), auxiliar_eventos(i))
        '    Catch ex As Exception
        '        MsgBox("excepion añadir punto cuando cambio scroll")
        '        scrollecg.Value = scrollecg.Minimum
        '        Exit For
        '    End Try
        '    ' ChartECG.Series("ECG").Points.AddY(auxiliar_eventos(i))
        'Next






    End Sub
    'EVENTO DOBLE CLICK SOBRE UN EVENTO EN LA LISTA
    Private Sub ListBoxeventos_DoubleClick(sender As Object, e As EventArgs) Handles ListBoxeventos.DoubleClick
        'cuando haga doble click sobre un elemento debo mostrar el evento en la ventana
        Mostrar_ventana(ListBoxeventos.SelectedIndex)
    End Sub

    'parecida al boton mostar- esta sub rutina es llamada por otra funcion
    Private Sub Mostrar_ventana(indice As Integer)

        'vemos lo del offset a ver si funciona
        Dim offset As Integer = (inicio_Ereloj(indice).Second + inicio_Ereloj(indice).Minute * 60)

        ' Dim paso As Integer = eje_temporal(indice)
        Dim paso As Integer = stopW_eventos(2, indice)

        'ventana es el string que tiene contador inicial y final separado por un "*"
        ' en eventos se guarda el tiempo
        ' Dim aux() As String = eventos.Split(vbCrLf)
        indice_evento = indice
        'ahora ventana deberia tener los tiempos inicio y final
        ' Dim aux() As String = data_evento.Split("*")
        ' en auxiliar tengo los datos de ecg
        Dim auxiliar() As String = aux_datos_ecg.Split(vbCrLf)
        'aux_eventos = aux
        auxiliar_eventos = auxiliar

        For i As Integer = 0 To ChartEventos.Series("ECG").Points.Count - 1
            ChartEventos.Series("ECG").Points.RemoveAt(0)
        Next



        'pongo el offset 
        '  ChartEventos.ChartAreas(0).AxisX.Minimum = offset
        'ChartEventos.ChartAreas("ChartArea1").AxisX.Minimum = offset
        'ChartEventos.ChartAreas("ChartArea1").AxisX.IntervalOffset = offset


        '   Dim valor_X As Integer = paso * (i - inicio_evento(indice)) / 1000

        '  Dim debug As String = auxiliar(300)

        ' ChartEventos.ChartAreas("ChartArea1").AxisX.Interval = 29

        Dim auxi2 As Integer = (1000 \ paso) + 1

        ChartEventos.ChartAreas(0).AxisX.Interval = auxi2

        ChartEventos.ChartAreas(0).AxisX.ScrollBar.ButtonStyle = ScrollBarButtonStyles.SmallScroll

        Dim auxi As Integer
        Dim minuto As String
        Dim segundo As String
        Dim milis As Single
        Dim contador As Long

        For i As Integer = inicio_evento(indice) To fin_evento(indice)
            '     Try

            '   ChartEventos.Series("ECG").Points.AddY(auxiliar(i))

            milis = paso * (i - inicio_evento(indice))

            auxi = (paso * (i - inicio_evento(indice)) / 1000) + offset

            minuto = auxi \ 60

            contador = contador + milis

            segundo = auxi Mod 60


            'If (contador / 1000) - segundo >= 1 Then

            '    If minuto < 10 Then

            '        If segundo < 10 Then
            '            ChartEventos.Series("ECG").Points.AddXY("0" & minuto & ":0" & segundo, auxiliar(i))
            '        Else
            '            ChartEventos.Series("ECG").Points.AddXY("0" & minuto & ":" & segundo, auxiliar(i))

            '        End If
            '    Else

            '        If segundo < 10 Then
            '            ChartEventos.Series("ECG").Points.AddXY(minuto & ":0" & segundo, auxiliar(i))
            '        Else
            '            ChartEventos.Series("ECG").Points.AddXY(minuto & ":" & segundo, auxiliar(i))

            '        End If

            '    End If



            '    ' ChartEventos.Series("ECG").Points.AddXY(minuto & ":" & segundo, auxiliar(i))
            'Else

            '    If contador = 0 Then

            '        If minuto < 10 Then

            '            If segundo < 10 Then
            '                ChartEventos.Series("ECG").Points.AddXY("0" & minuto & ":0" & segundo, auxiliar(i))
            '            Else
            '                ChartEventos.Series("ECG").Points.AddXY("0" & minuto & ":" & segundo, auxiliar(i))

            '            End If
            '        Else

            '            If segundo < 10 Then
            '                ChartEventos.Series("ECG").Points.AddXY(minuto & ":0" & segundo, auxiliar(i))
            '            Else
            '                ChartEventos.Series("ECG").Points.AddXY(minuto & ":" & segundo, auxiliar(i))

            '            End If

            '        End If

            '        ' ChartEventos.Series("ECG").Points.AddXY(minuto & ":" & segundo, auxiliar(i))
            '    Else


            '        ChartEventos.Series("ECG").Points.AddY(auxiliar(i))
            '    End If
            ' ChartEventos.Series("ECG").Points.AddY(auxiliar(i))

            '  End If



            If minuto < 10 Then

                If segundo < 10 Then
                    ChartEventos.Series("ECG").Points.AddXY("0" & minuto & ":0" & segundo, auxiliar(i))
                Else
                    ChartEventos.Series("ECG").Points.AddXY("0" & minuto & ":" & segundo, auxiliar(i))

                End If
            Else

                If segundo < 10 Then
                    ChartEventos.Series("ECG").Points.AddXY(minuto & ":0" & segundo, auxiliar(i))
                Else
                    ChartEventos.Series("ECG").Points.AddXY(minuto & ":" & segundo, auxiliar(i))

                End If

            End If




            'ChartEventos.Series("ECG").Points.AddXY((paso * (i - inicio_evento(indice)) / 1000) + offset, auxiliar(i))



            '----------------------------------------------------------------------------

            'Catch ex As Exception
            '    MsgBox("hola- excepcion funcion mostrar ventana. menos puntos que ancho de ventana")
            '    Exit Sub
            'End Try




            '----------------------------------------------------------------------------------------





            ' ChartECG.Series("ECG").Points.AddY(auxiliar(i))
        Next
        'Dim aux As Date
        '' Dim aux_filas_datagridAs DateAndTime
        ''     aux = aux.AddHours(-12)
        'Dim minuto As String
        'Dim segundo As String

        'For i As Integer = inicio_evento(indice) To fin_evento(indice)
        '    Try

        '        aux = aux.AddMilliseconds(((paso * (i - inicio_evento(indice)))))
        '        minuto = aux.Minute.ToString()
        '        segundo = aux.Second.ToString()
        '        ' ChartEventos.Series("ECG").Points.AddXY((paso * (i - inicio_evento(indice)) / 1000) + offset, auxiliar(i))
        '        'aux = aux.AddMilliseconds(paso)
        '        ChartEventos.Series("ECG").Points.AddXY(minuto & ":" & segundo, auxiliar(i))
        '    Catch ex As Exception
        '        MsgBox("hola- excepcion funcion mostrar ventana. menos puntos que ancho de ventana")
        '    End Try

        'Next



    End Sub

    'esconde la interfaz de datos de paciente y demas para cuando todavia no apretamos ningun boton
    Public Sub Esconder_Datos()

        For Each Control In TabPersonales.Controls
            Control.visible = False
            Control.enabled = False
        Next

        LabelTitulo.Visible = True
        PictureBox1.Visible = True
        botonbuscarexamen.Visible = True
        botonBuscarpaciente.Visible = True
        botonNuevopaciente.Visible = True
        txtfechahoy.Visible = True

        LabelTitulo.Enabled = True
        PictureBox1.Enabled = True
        botonbuscarexamen.Enabled = True
        botonBuscarpaciente.Enabled = True
        botonNuevopaciente.Enabled = True
        txtfechahoy.Enabled = True

        'ButtonMostrar.Enabled = True
        'ButtonMostrar.Visible = True


        'ahora posiciono los botones en el medio de la pantalla y redimensiono

        botonNuevopaciente.Location = New Point(screenWidth * 0.25 - (botonNuevopaciente.Width / 2), screenHeight * 0.5)
        botonBuscarpaciente.Location = New Point(screenWidth * 0.5 - (botonBuscarpaciente.Width / 2), screenHeight * 0.5)
        botonbuscarexamen.Location = New Point(screenWidth * 0.75 - (botonbuscarexamen.Width / 2), screenHeight * 0.5)

        ' PictureBoxTuerca.Enabled = True
        PictureBoxTuercaFondo.Enabled = True

        ' PictureBoxTuerca.Visible = True
        PictureBoxTuercaFondo.Visible = True
        'botonsiguiente.Visible = True
        'botonsiguiente.Enabled = False
        LabelConexionPersonales.Visible = True
        LabelConexionPersonales.Enabled = True
        'PictureBoxfondosalir.Visible = True
        PictureBoxSalirPaciente.Visible = True
        PictureBoxSalirPaciente.Enabled = False


        ' PictureBoxTuercaFondo.BackColor = Color.White
        botonsiguiente.BackColor = Color.DimGray
        ' LabelConexionPersonales.BackColor = Color.White
        'PictureBoxfondosalir.BackColor = Color.DimGray
        PictureBoxSalirPaciente.BackColor = Color.Transparent
        'PictureBoxTuercaFondo.BackColor = Color.LightSteelBlue
        PictureBoxTuercaFondo.BackColor = Color.Transparent

        imagenfondo.Visible = True
        hideTabs(TabGeneral)

        'botonsiguiente.Image.Dispose()



    End Sub

    'NOS MANDA A LA PESTAÑA DE SERVICIO TECNICO
    Private Sub Entrar_servicioTEC()
        TabGeneral.SelectTab(6)
    End Sub

    'ESCONDE LAS PESTAÑAS
    Public Sub hideTabs(ByVal TC As TabControl)
        TC.Region = New Region(New RectangleF(TC.TabPages(0).Left, TC.TabPages(0).Top, TC.TabPages(0).Width, TC.TabPages(0).Height))
    End Sub

    'MUESTRA LAS PESTA{AS
    Public Sub MostrarTabs(ByVal TC As TabControl)
        TC.Region = New Region(New RectangleF(Me.Left, Me.Top, Me.Width, Me.Height))
    End Sub


    Public Sub guardar_tiras()
        'tengo que guardar los tiempo de inicio y final de cada evento y ademas fijare que tipo de evento, como asi tambien el tiempo " real"
        ' puedo guardor los datos separados por guiones y los eventos separaados por¨asteriscos

        'FALTARIA AGREGAR LA DATA ALMACENADA EN EL ARRAY QUE GUARDA QUE TIPO DE EVENTO ES CADA UNO
        Dim buffer As String

        For i As Integer = 0 To contador_eventos - 1

            buffer = inicio_evento(i) & "-" & fin_evento(i) & "-" & inicio_Ereloj(i) & "-" & fin_Ereloj(i) & "-" & stopW_eventos(0, i) & "-" & stopW_eventos(1, i) & "-" & tipos_eventos(i) & "-" & stopW_eventos(2, i) & "*"

            tiras_aux = tiras_aux & buffer
        Next

    End Sub



    Private Sub TimerScreen_Tick(sender As Object, e As EventArgs) Handles TimerScreen.Tick


        Dim nueva_width As Integer = Screen.FromRectangle(Me.Bounds).WorkingArea.Width
        Dim nueva_heigth As Integer = Screen.FromRectangle(Me.Bounds).WorkingArea.Height


        If nueva_width <> screenWidth Or nueva_heigth <> screenHeight Then

            Ordenar_TODO()


            MostrarTabs(TabGeneral)

            If ventana_inicial = True Then
                Esconder_Datos()
            End If

            ordenar_grillas_staff()

            'If Me.WindowState = FormWindowState.Minimized Then
            'Else
            Me.WindowState = FormWindowState.Maximized
            'End If

        End If

        If estado_conexion = False Then Exit Sub

        ' Dim auxiliar_cone As Boolean 


        'CAMBIAMOS LA CANTIDAD DE DESCONEXIONES A 1

        If CNX = False And contador_desconexion >= 3 Then
            estado_conexion = False

            LabelConexionPersonales.Text = "OFFLINE"
            LabelConexionPersonales.BackColor = Color.Tomato
            LabelConexionProtocolo.Text = "OFFLINE"
            LabelConexionProtocolo.BackColor = Color.Tomato
            LabelConexionExamen.Text = "OFFLINE"
            LabelConexionExamen.BackColor = Color.Tomato

            clientSocket.Close()

            MsgBox("Se ha perdido la conexión al arduino!", MsgBoxStyle.Exclamation, "SIN CONEXIÓN")

        End If



        Try
            'auxiliar_cone = My.Computer.Network.Ping(IPadres, 3500)
        Catch ex As Exception

        End Try



        'If auxiliar_cone Then

        'Else
        '    estado_conexion = False
        '    MsgBox("Se ha perdido la conexión al arduino!")
        '    LabelConexionPersonales.Text = "OFFLINE"
        '    LabelConexionPersonales.BackColor = Color.Tomato
        '    LabelConexionProtocolo.Text = "OFFLINE"
        '    LabelConexionProtocolo.BackColor = Color.Tomato
        '    LabelConexionExamen.Text = "OFFLINE"
        '    LabelConexionExamen.BackColor = Color.Tomato

        '    clientSocket.Close()



        'End If
        If estado_conexion = True Then
            CNX = False
            contador_desconexion = contador_desconexion + 1
        End If

    End Sub

    Private Sub Form1_SizeChanged(sender As Object, e As EventArgs) Handles MyBase.SizeChanged

        If Me.WindowState = FormWindowState.Minimized Then
            ' MsgBox("minimizado")

        Else
            Ordenar_TODO()
        End If

        ' Ordenar_TODO()


        If ventana_inicial = True Then
            Esconder_Datos()
        End If

    End Sub

    'CAMBIO EN RADIO BUTTON TECNICOS
    Private Sub RadioButtonTecnicos_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonTecnicos.CheckedChanged

        If sender.checked = False Then
            txtbuscartecnico.Visible = False
            txtbuscartecnico.Enabled = False
            txtNombreTecnico.Visible = False
            txtNombreTecnico.Enabled = False
            txtApellidoTecnico.Visible = False
            txtApellidoTecnico.Enabled = False
            activotecnico.Visible = False
            activotecnico.Enabled = False
            DefectoTecnico.Visible = False
            DefectoTecnico.Enabled = False
            botonBuscarTecnico.Visible = False
            botonBuscarTecnico.Enabled = False
            InsertarTecnico.Visible = False
            InsertarTecnico.Enabled = False
            EditarTecnico.Visible = False
            EditarTecnico.Enabled = False
            EliminarTecnico.Visible = False
            EliminarTecnico.Enabled = False

            DGVtecnicos.Visible = False
            DGVtecnicos.Enabled = False
        End If

        If sender.checked = True Then
            txtbuscartecnico.Visible = True
            txtbuscartecnico.Enabled = True
            txtNombreTecnico.Visible = True
            txtNombreTecnico.Enabled = True
            txtApellidoTecnico.Visible = True
            txtApellidoTecnico.Enabled = True
            activotecnico.Visible = True
            ' activotecnico.Enabled = True ' el enabled lo saco para que editar lo habilite
            DefectoTecnico.Visible = True
            ' DefectoTecnico.Enabled = True ' idem aca
            botonBuscarTecnico.Visible = True
            botonBuscarTecnico.Enabled = True
            InsertarTecnico.Visible = True
            InsertarTecnico.Enabled = True
            EditarTecnico.Visible = True
            EditarTecnico.Enabled = True
            EliminarTecnico.Visible = True
            EliminarTecnico.Enabled = True

            DGVtecnicos.Visible = True
            DGVtecnicos.Enabled = True
        End If


    End Sub
    'CAMBIO EN RADIO BUTTON
    Private Sub RadioButtonMandantes_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonMandantes.CheckedChanged

        If sender.checked = False Then
            txtbuscarmandante.Visible = False
            txtbuscarmandante.Enabled = False
            txtNombreMandante.Visible = False
            txtNombreMandante.Enabled = False
            txtApellidoMandante.Visible = False
            txtApellidoMandante.Enabled = False
            activomandante.Visible = False
            activomandante.Enabled = False
            DefectoMandante.Visible = False
            DefectoMandante.Enabled = False
            BuscarMedMan.Visible = False
            BuscarMedMan.Enabled = False
            InsertarMandante.Visible = False
            InsertarMandante.Enabled = False
            EditarMandante.Visible = False
            EditarMandante.Enabled = False
            EliminarMandante.Visible = False
            EliminarMandante.Enabled = False

            DGVmedicosman.Visible = False
            DGVmedicosman.Enabled = False
        End If

        If sender.checked = True Then
            txtbuscarmandante.Visible = True
            txtbuscarmandante.Enabled = True
            txtNombreMandante.Visible = True
            txtNombreMandante.Enabled = True
            txtApellidoMandante.Visible = True
            txtApellidoMandante.Enabled = True
            activomandante.Visible = True
            ' activomandante.Enabled = True
            DefectoMandante.Visible = True
            ' DefectoMandante.Enabled = True
            BuscarMedMan.Visible = True
            BuscarMedMan.Enabled = True
            InsertarMandante.Visible = True
            InsertarMandante.Enabled = True
            EditarMandante.Visible = True
            EditarMandante.Enabled = True
            EliminarMandante.Visible = True
            EliminarMandante.Enabled = True

            DGVmedicosman.Visible = True
            DGVmedicosman.Enabled = True
        End If


    End Sub
    'CAMBIO EN RADIO BUTTON
    Private Sub RadioButtonActuantes_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonActuantes.CheckedChanged

        If sender.checked = False Then
            txtbuscaractuante.Visible = False
            txtbuscaractuante.Enabled = False
            txtNombreactuante.Visible = False
            txtNombreactuante.Enabled = False
            txtApellidoactuante.Visible = False
            txtApellidoactuante.Enabled = False
            activoactuante.Visible = False
            activoactuante.Enabled = False
            DefectoActuante.Visible = False
            DefectoActuante.Enabled = False
            buscaractuante.Visible = False
            buscaractuante.Enabled = False
            Insertaractuante.Visible = False
            Insertaractuante.Enabled = False
            Editaractuante.Visible = False
            Editaractuante.Enabled = False
            Eliminaractuante.Visible = False
            Eliminaractuante.Enabled = False

            DGVmedicosact.Visible = False
            DGVmedicosact.Enabled = False
        End If

        If sender.checked = True Then
            txtbuscaractuante.Visible = True
            txtbuscaractuante.Enabled = True
            txtNombreactuante.Visible = True
            txtNombreactuante.Enabled = True
            txtApellidoactuante.Visible = True
            txtApellidoactuante.Enabled = True
            activoactuante.Visible = True
            '  activoactuante.Enabled = True
            DefectoActuante.Visible = True
            ' DefectoActuante.Enabled = True
            buscaractuante.Visible = True
            buscaractuante.Enabled = True
            Insertaractuante.Visible = True
            Insertaractuante.Enabled = True
            Editaractuante.Visible = True
            Editaractuante.Enabled = True
            Eliminaractuante.Visible = True
            Eliminaractuante.Enabled = True

            DGVmedicosact.Visible = True
            DGVmedicosact.Enabled = True
        End If


    End Sub

    'ORDENAR GRILLA
    Private Sub ordenar_grillas_staff()

        Dim min As DataGridViewColumn = DGVtecnicos.Columns(0)
        'primero estaba en 30 ahora lo pongo en 0
        'min.Width = 30
        min.Width = 30

        min = DGVtecnicos.Columns(3)
        ' min.Width = 65
        min.Width = 0
        min = DGVtecnicos.Columns(4)
        min.Width = 0
        'min.Width = 73

        For i As Integer = 1 To 2
            min = DGVtecnicos.Columns(i)
            ' min.Width = (DGVtecnicos.Width - DGVtecnicos.Columns(3).Width - DGVtecnicos.Columns(4).Width - DGVtecnicos.Columns(0).Width) / 2

            min.Width = (DGVtecnicos.Width - DGVtecnicos.Columns(0).Width) / 2
        Next


        min = DGVmedicosman.Columns(0)
        min.Width = 30

        min = DGVmedicosman.Columns(3)
        'min.Width = 65
        min.Width = 0
        min = DGVmedicosman.Columns(4)
        'min.Width = 73
        min.Width = 0

        For i As Integer = 1 To 2
            min = DGVmedicosman.Columns(i)
            ' min.Width = (DGVmedicosman.Width - DGVmedicosman.Columns(3).Width - DGVmedicosman.Columns(4).Width - DGVmedicosman.Columns(0).Width) / 2
            min.Width = (DGVtecnicos.Width - DGVtecnicos.Columns(0).Width) / 2
        Next


        min = DGVmedicosact.Columns(0)
        min.Width = 30

        min = DGVmedicosact.Columns(3)
        ' min.Width = 65
        min.Width = 0
        min = DGVmedicosact.Columns(4)
        'min.Width = 73
        min.Width = 0

        For i As Integer = 1 To 2
            min = DGVmedicosact.Columns(i)
            ' min.Width = (DGVmedicosact.Width - DGVmedicosact.Columns(3).Width - DGVmedicosact.Columns(4).Width - DGVmedicosact.Columns(0).Width) / 2
            min.Width = (DGVtecnicos.Width - DGVtecnicos.Columns(0).Width) / 2
        Next


    End Sub


    Sub Ir_a_Service()

        Personal.Hide()
        If TabGeneral.SelectedIndex = 5 Then
            Contraseña.Show()
            Contraseña.BringToFront()
            TabGeneral.SendToBack()

            'aprovecho aca para ordenar el staff
            ordenar_grillas_staff()

        End If

    End Sub

    'EVENTO DE INGRESO DE MOUSE AL ICONO
    Private Sub PictureBoxTuercaFondo_MouseEnter(sender As Object, e As EventArgs) Handles PictureBoxTuercaFondo.MouseEnter
        PictureBoxTuercaFondo.BackColor = Color.LightGray
    End Sub
    'EVENTO DE MOUSE SALIENDO
    Private Sub PictureBoxTuercaFondo_MouseLeave(sender As Object, e As EventArgs) Handles PictureBoxTuercaFondo.MouseLeave
        'PictureBoxTuercaFondo.BackColor = Color.LightSteelBlue
        PictureBoxTuercaFondo.BackColor = Color.Transparent
    End Sub
    'EVNETO CLICK EN LA TUERCA
    Private Sub PictureBoxTuercaFondo_Click(sender As Object, e As EventArgs) Handles PictureBoxTuercaFondo.Click

        service_tuerca = True
        TabGeneral.SelectedIndex = 5

        Ir_a_Service()
    End Sub

    Sub listar_eventos()

        ListBoxeventos.Items.Clear()

        ' aca separo los eventos en cada uno
        Dim array_eventos() As String = Split(eventos, vbCrLf)


        For i As Integer = 0 To contador_eventos - 1
            Dim auxi2 As String = i + 1
            Dim auxiliar As String = auxi2 & array_eventos(i)
            ListBoxeventos.Items.Add(auxiliar)
        Next

    End Sub

    Sub actualizar_display(datos As Integer)

        If contador_display >= ancho_display Then

            contador_display = 0
            '   GFX2.FillRectangle(Brushes.CadetBlue, 0, 0, 50, BMP2.Height)
            GFX2.FillRectangle(Brushes.MediumBlue, 0, 0, 50, BMP2.Height)
            'Exit Sub
        End If

        'If contador_display >= ancho_display - 300 Then


        '    ' GFX2.DrawRectangle(Pens.Red, 0, 0, 200, BMP2.Height)
        '    GFX2.FillRectangle(Brushes.Red, 0, 0, 200, BMP2.Height)
        'End If



        'ahora tengo que hacer una transformación lineal a los datos

        datos_transformados = datos * (altura_display / (datos_minimo - datos_maximo)) - datos_maximo * (altura_display / (datos_minimo - datos_maximo))


        'tomo los datos de ECG del momento y lo pongo en el display
        'xinicial es el tiempo anterior , x final seria el tiempo actual
        Xinicial_display = contador_display
        contador_display = contador_display + 1

        ' GFX2.DrawLine(Pens.YellowGreen, Xinicial_display, Yinicial_display, contador_display, offset_display - datos_transformados)

        GFX2.DrawLine(Pens.YellowGreen, Xinicial_display, Yinicial_display, contador_display, datos_transformados)

        '  GFX2.DrawRectangle(Pens.White, Xinicial_display + 20, 0, 10, BMP2.Height)

        'GFX2.FillRectangle(Brushes.CadetBlue, Xinicial_display + 50, 0, 50, BMP2.Height)
        GFX2.FillRectangle(Brushes.MediumBlue, Xinicial_display + 50, 0, 50, BMP2.Height)

        ' Yinicial_display = offset_display - datos_transformados

        Yinicial_display = datos_transformados

        PictureBoxECG.Image = BMP2
        PictureBoxECGPaciente.Image = BMP2
        PictureBoxECGProtocolo.Image = BMP2

    End Sub

    'Parece que actualizardisplay 2 es para el ecg de verdad

    Sub actualizar_display_2(datos As Integer)

        If contador_display >= ancho_display Then

            contador_display = 0
            ' GFX2.FillRectangle(Brushes.CadetBlue, 0, 0, 50, BMP2.Height)
            GFX2.FillRectangle(Brushes.MediumBlue, 0, 0, 50, BMP2.Height)
            'Exit Sub
        End If

        'If contador_display >= ancho_display - 300 Then


        '    ' GFX2.DrawRectangle(Pens.Red, 0, 0, 200, BMP2.Height)
        '    GFX2.FillRectangle(Brushes.Red, 0, 0, 200, BMP2.Height)
        'End If


        'AJUSTE AUTOMATICO DE MAXIMOS Y MINIMOS QUE POR AHORA NO USAMOS

        'If datos <= datos_minimo Then
        '    datos_minimo = datos - 60
        'End If

        'If datos >= datos_maximo Then
        '    datos_maximo = datos + 10
        'End If

       

        'ahora tengo que hacer una transformación lineal a los datos

        datos_transformados = datos * (altura_display / (datos_minimo - datos_maximo)) - datos_maximo * (altura_display / (datos_minimo - datos_maximo))

        ' datos_transformados = datos_transformados * -1
        '   datos_transformados = datos_transformados + 100

        'tomo los datos de ECG del momento y lo pongo en el display
        'xinicial es el tiempo anterior , x final seria el tiempo actual
        Xinicial_display = contador_display
        contador_display = contador_display + 2

        ' GFX2.DrawLine(Pens.YellowGreen, Xinicial_display, Yinicial_display, contador_display, offset_display - datos_transformados)
        Dim pincel As Pen = New Pen(Color.YellowGreen)
        pincel.Width = 2.0F

        GFX2.DrawLine(pincel, Xinicial_display, Yinicial_display, contador_display, datos_transformados)


        ' GFX2.DrawLine(pincel_cuadrada, Xinicial_display, Yinicial_display, contador_display, datos_transformados)



        '  GFX2.DrawRectangle(Pens.White, Xinicial_display + 20, 0, 10, BMP2.Height)

        'GFX2.FillRectangle(Brushes.CadetBlue, Xinicial_display + 50, 0, 50, BMP2.Height)
        GFX2.FillRectangle(Brushes.MediumBlue, Xinicial_display + 50, 0, 50, BMP2.Height)

        ' Yinicial_display = offset_display - datos_transformados

        Yinicial_display = datos_transformados

        PictureBoxECG.Image = BMP2
        PictureBoxECGPaciente.Image = BMP2
        PictureBoxECGProtocolo.Image = BMP2


        '        If (datos_maximo - datos) > datos_maximo * 0.2 Then
        'datos_maximo = datos_maximo - 10
        'End If

    End Sub


    'PARECE QUE ESTE LA SUBRUTINA FINAL DE ACTUALIZAR DISPLAY
    'probemos aca la cosa adaptativa

    Sub actualizar_display_varios(datos As Integer, pincel As Pen)

        If contador_display >= ancho_display Then

            contador_display = 0
            'GFX2.FillRectangle(Brushes.PowderBlue, 0, 0, 50, BMP2.Height)
            'GFX2.FillRectangle(Brushes.RoyalBlue, 0, 0, 50, BMP2.Height)
            GFX2.FillRectangle(Brushes.MediumBlue, 0, 0, 50, BMP2.Height)
            'Exit Sub
        End If

        'If contador_display >= ancho_display - 300 Then


        '    ' GFX2.DrawRectangle(Pens.Red, 0, 0, 200, BMP2.Height)
        '    GFX2.FillRectangle(Brushes.Red, 0, 0, 200, BMP2.Height)
        'End If

        If datos <= datos_minimo Then
            datos_minimo = datos - 20
        End If

        If datos >= datos_maximo Then
            datos_maximo = datos + 20
        End If


        'ahora tengo que hacer una transformación lineal a los datos

        datos_transformados = datos * (altura_display / (datos_minimo - datos_maximo)) - datos_maximo * (altura_display / (datos_minimo - datos_maximo))

        ' datos_transformados = datos_transformados * -1
        '   datos_transformados = datos_transformados + 100

        'tomo los datos de ECG del momento y lo pongo en el display
        'xinicial es el tiempo anterior , x final seria el tiempo actual
        Xinicial_display = contador_display
        contador_display = contador_display + 2

        ' GFX2.DrawLine(Pens.YellowGreen, Xinicial_display, Yinicial_display, contador_display, offset_display - datos_transformados)


        GFX2.DrawLine(pincel, Xinicial_display, Yinicial_display, contador_display, datos_transformados)


        ' GFX2.DrawLine(pincel_cuadrada, Xinicial_display, Yinicial_display, contador_display, datos_transformados)



        '  GFX2.DrawRectangle(Pens.White, Xinicial_display + 20, 0, 10, BMP2.Height)

        GFX2.FillRectangle(Brushes.MediumBlue, Xinicial_display + 50, 0, 50, BMP2.Height)

        ' Yinicial_display = offset_display - datos_transformados

        Yinicial_display = datos_transformados

        PictureBoxECG.Image = BMP2
        PictureBoxECGPaciente.Image = BMP2
        PictureBoxECGProtocolo.Image = BMP2

    End Sub





    Sub actualizar_display_3(datos As Integer, indice As Integer, paso As Integer)
        Xinicial_display = xfinal
        xfinal = ((paso * indice) / 3.9)


        'If xfinal >= ancho_display_print * contador_display_print Then
        '    contador_display_print = contador_display_print + 1
        '    ' GFX2.FillRectangle(Brushes.LightGray, 0, 0, 50, BMP_print.Height)
        '    'Exit Sub
        'End If



        If contador_display_print >= ancho_display_print Then
            contador_display_print = 0
            contador_rectangullos = contador_rectangullos + 1
            ' GFX2.FillRectangle(Brushes.LightGray, 0, 0, 50, BMP_print.Height)
            'Exit Sub
        End If



        'ahora tengo que hacer una transformación lineal a los datos

        datos_transformados = datos * (altura_display / (datos_minimo - datos_maximo)) - datos_maximo * (altura_display / (datos_minimo - datos_maximo))

        'tomo los datos de ECG del momento y lo pongo en el display
        'xinicial es el tiempo anterior , x final seria el tiempo actual


        '  Xinicial_display = contador_display_print

        ' contador_display_print = contador_display_print + 2


        contador_display_print = contador_display_print + (xfinal - Xinicial_display)


        ' contador_display_print = (paso * indice) / 4


        ' GFX2.DrawLine(Pens.YellowGreen, Xinicial_display, Yinicial_display, contador_display, offset_display - datos_transformados)
        'antes estaba orangered
        'black
        Dim apen As Pen = New Pen(Color.Black)
        apen.Width = 2.0F ' antes era 10

        GFX_print.DrawLine(apen, Xinicial_display - (ancho_display_print * (contador_rectangullos - 1)), Yinicial_display, xfinal - (ancho_display_print * (contador_rectangullos - 1)), datos_transformados)

        '  GFX2.DrawRectangle(Pens.White, Xinicial_display + 20, 0, 10, BMP2.Height)

        '   GFX_print.FillRectangle(Brushes.LightGray, Xinicial_display + 50, 0, 50, BMP_print.Height)

        ' Yinicial_display = offset_display - datos_transformados

        Yinicial_display = datos_transformados

        'PictureBoxECG.Image = BMP2
        'PictureBoxECGPaciente.Image = BMP2
        'PictureBoxECGProtocolo.Image = BMP2

    End Sub


    Sub actualizar_display_A4(datos As Integer)

        If contador_display_print >= ancho_papel Then

            contador_display_print = 0
            ' GFX2.FillRectangle(Brushes.LightGray, 0, 0, 50, BMP_print.Height)
            'Exit Sub
        End If





        'ahora tengo que hacer una transformación lineal a los datos

        datos_transformados = datos * (altura_display / (datos_minimo - datos_maximo)) - datos_maximo * (altura_display / (datos_minimo - datos_maximo))


        'tomo los datos de ECG del momento y lo pongo en el display
        'xinicial es el tiempo anterior , x final seria el tiempo actual
        Xinicial_display = contador_display_print
        contador_display_print = contador_display_print + 2

        ' GFX2.DrawLine(Pens.YellowGreen, Xinicial_display, Yinicial_display, contador_display, offset_display - datos_transformados)

        Dim apen As Pen = New Pen(Color.OrangeRed)
        apen.Width = 2.0F ' antes era 10

        GFX_print.DrawLine(apen, Xinicial_display, Yinicial_display, contador_display_print, datos_transformados)

        '  GFX2.DrawRectangle(Pens.White, Xinicial_display + 20, 0, 10, BMP2.Height)



        '   GFX_print.FillRectangle(Brushes.LightGray, Xinicial_display + 50, 0, 50, BMP_print.Height)




        ' Yinicial_display = offset_display - datos_transformados

        Yinicial_display = datos_transformados

        'PictureBoxECG.Image = BMP2
        'PictureBoxECGPaciente.Image = BMP2
        'PictureBoxECGProtocolo.Image = BMP2

    End Sub



    Sub dibujar_grilla()

        For i As Integer = 20 To PictureBoxECG.Height Step 20
            GFX2.DrawLine(Pens.White, 0, i, PictureBoxECG.Width, i)


        Next
        For i As Integer = 20 To PictureBoxECG.Width Step 20
            GFX2.DrawLine(Pens.White, 0, i, PictureBoxECG.Width, i)
            GFX2.DrawLine(Pens.White, i, 0, i, PictureBoxECG.Height)

        Next



        PictureBoxECG.Image = BMP2



    End Sub



    Public Sub Ordenar_TODO()

        Personal.BackgroundImage = Nothing

        Me.MaximumSize = Screen.FromRectangle(Me.Bounds).WorkingArea.Size
        Me.WindowState = FormWindowState.Maximized


        Dim ALTO As Integer = Me.Height
        Dim ancho As Integer = Me.Width

        Dim altoWS As Integer = Screen.FromRectangle(Me.Bounds).WorkingArea.Height
        Dim anchoWS As Integer = Screen.FromRectangle(Me.Bounds).WorkingArea.Width


        screenWidth = anchoWS
        screenHeight = altoWS

        'poner aplicacion en full screen - esto esta bien lo que hay que cambiar es el tamaño dentro del form
        Me.WindowState = FormWindowState.Maximized

        Me.Width = screenWidth
        'la de abajo es la que acaba de agregar
        ' Me.Height = screenHeight

        TabGeneral.Width = screenWidth
        TabGeneral.Height = screenHeight

        TabPersonales.Width = screenWidth
        TabPersonales.Height = screenHeight


        PictureBox1.Width = screenWidth * 0.1
        PictureBox1.Location = New Point(screenWidth * 0.02, 0.05)

        'PictureBox1.Location = New Point(screenWidth * 0.02, screenHeight * 0.05)

        'botonsiguiente.Height = screenHeight * 0.2045
        'botonsiguiente.Width = screenWidth * 0.1502


        ' Labelpreg5.Text = "¿Alguien presenció el desmayo?"
        Labelpreg5.Text = "5-¿Hubo testigos del desmayo?"


        PictureBoxSalirPaciente.Height = PictureBox1.Height * 0.45
        PictureBoxSalirPaciente.Width = PictureBox1.Width * 0.6


        PictureBoxSalirPaciente.Location = New Point(screenWidth * 0.95 - PictureBoxSalirPaciente.Width * 0.7 + 25, LabelTitulo.Location.Y * 0.35)


        botonsiguiente.Height = PictureBoxSalirPaciente.Width
        botonsiguiente.Width = PictureBoxSalirPaciente.Width



        'PictureBoxfondosalir.Height = PictureBoxSalirPaciente.Height * 1.2
        'PictureBoxfondosalir.Width = PictureBoxSalirPaciente.Width * 1.2


        'PictureBoxfondosalir.Height = botonsiguiente.Height * 0.5





        'txtConexion.Width = botonsiguiente.Width '+ PictureBoxfondosalir.Width

        '  txtConexion.Location = New Point(PictureBoxSalirPaciente.Location.X + PictureBoxSalirPaciente.Width - txtConexion.Width, screenHeight * 0.9 - txtConexion.Height)


        'ACAAAAA RECIEN COMENTE SAN LORENZO
        'botonsiguiente.Location = New Point(PictureBoxSalirPaciente.Location.X + PictureBoxSalirPaciente.Width - botonsiguiente.Width, screenHeight * 0.9 - txtConexion.Height - botonsiguiente.Height)

        'PictureBoxSalirPaciente.Location = New Point(screenWidth * 0.95 - PictureBoxSalirPaciente.Width, LabelTitulo.Location.Y)




        LabelConexionPersonales.Location = New Point(PictureBoxSalirPaciente.Location.X + PictureBoxSalirPaciente.Width - LabelConexionPersonales.Width, LabelConexionPersonales.Location.Y)

        PictureBoxTuercaFondo.Width = PictureBoxSalirPaciente.Height
        PictureBoxTuercaFondo.Height = PictureBoxSalirPaciente.Height

        PictureBoxTuercaFondo.Location = New Point(PictureBoxSalirPaciente.Location.X * 0.99, PictureBoxSalirPaciente.Location.Y)
        'PictureBoxTuercaFondo.Width = PictureBox1.Width * 0.65
        'PictureBoxTuercaFondo.Height = PictureBox1.Height * 0.45
        ''PictureBoxTuercaFondo.Location = New Point(txtConexion.Location.X + txtConexion.Width - PictureBoxTuercaFondo.Width, PictureBoxSalirPaciente.Location.Y)





        'PictureBoxfondosalir.Location = New Point(screenWidth * 0.95 - PictureBoxSalirPaciente.Width, botonsiguiente.Location.Y + botonsiguiente.Height - PictureBoxfondosalir.Height)


        'al dia 30 de septiembre labeltitulo estaba en su posicion a mano (486;72)

        LabelTitulo.Width = screenWidth * 0.619
        LabelTitulo.Height = screenHeight * 0.046

        LabelTitulo.Text = "TEST DE MOVIMIENTO" + vbCrLf + "OSCILATORIO CORPORAL"

        Dim w As Single = LabelTitulo.Width
        Dim h As Single = LabelTitulo.Height

        Dim tamanio As Single


        tamanio = screenWidth * 0.025
        LabelTitulo.Font = New System.Drawing.Font(LabelTitulo.Font.Name, tamanio, LabelTitulo.Font.Style)


        PictureBoxECGPaciente.Width = screenWidth * 0.6

        PictureBoxECGProtocolo.Width = PictureBoxECGPaciente.Width

        PictureBoxECG.Width = PictureBoxECGPaciente.Width

        LabelTitulo.Location = New Point(screenWidth * 0.5 - LabelTitulo.Width * 0.5, 72)
        ' aca arranca nombre


        'todo esta basado en el nombre, al comienzo era screenheight*0.263
        'en lugar de +15 pongo +20

        LabeltituloPaciente.Location = New Point(screenWidth * 0.15, 36)
        '
        LabeltituloINTE.Location = New Point(screenWidth * 0.15, 36)


        'originalmente labelnombre arrancaba en screenheight * 0.143

        LabelNombre.Location = New Point(PictureBox1.Location.X + PictureBox1.Width * 1.3, LabeltituloPaciente.Location.Y + LabeltituloPaciente.Height + 25)
        LabelApellido.Location = New Point(LabelNombre.Location.X, LabelNombre.Location.Y + LabelNombre.Height + 30)
        LabelDNI.Location = New Point(LabelNombre.Location.X, LabelApellido.Location.Y + LabelNombre.Height + 30)
        LabelEdad.Location = New Point(LabelNombre.Location.X, LabelDNI.Location.Y + LabelNombre.Height + 30)
        LabelSexo.Location = New Point(LabelNombre.Location.X, LabelEdad.Location.Y + LabelNombre.Height + 30)
        LabelInternado.Location = New Point(LabelNombre.Location.X, LabelSexo.Location.Y + LabelNombre.Height + 30)
        LabelDomicilio.Location = New Point(LabelNombre.Location.X, LabelInternado.Location.Y + LabelNombre.Height + 30)
        LabelTelefono.Location = New Point(LabelNombre.Location.X, LabelDomicilio.Location.Y + LabelNombre.Height + 30)

        TextNombre.Location = New Point(LabelInternado.Location.X + LabelInternado.Width, LabelNombre.Location.Y)
        TextApellido.Location = New Point(TextNombre.Location.X, LabelApellido.Location.Y)
        TextDNI.Location = New Point(TextNombre.Location.X, LabelDNI.Location.Y)
        TextEdad.Location = New Point(TextNombre.Location.X, LabelEdad.Location.Y)
        Panelsexo.Location = New Point(TextNombre.Location.X, LabelSexo.Location.Y - 5)
        PanelINT.Location = New Point(TextNombre.Location.X, LabelInternado.Location.Y - 5)
        TextDomicilio.Location = New Point(TextNombre.Location.X, LabelDomicilio.Location.Y)
        TextTelefono.Location = New Point(TextNombre.Location.X, LabelTelefono.Location.Y)





        TextRitmo.Width = TextNombre.Width
        TextRitmo.Height = TextNombre.Height
        TextSintoma.Width = TextNombre.Width
        TextSintoma.Height = TextNombre.Height


        'aca esta medio raro , oprque la ubicacion de labelritmo depende de text protocolo si el mismo no fue definido todavia?

        'en lugar de la parte derecha por protocolo, uso la de ecg picturebox
        LabelRitmo.Location = New Point(PictureBoxECGPaciente.Location.X + PictureBoxECGPaciente.Width - LabelSintoma.Width - TextSintoma.Width, LabelNombre.Location.Y)





        'LabelRitmo.Location = New Point(TextNombre.Location.X + TextNombre.Width + 10, LabelNombre.Location.Y)
        'LabelSintoma.Location = New Point(TextNombre.Location.X + TextNombre.Width + 10, LabelApellido.Location.Y)
        'LabelFecha.Location = New Point(LabelSintoma.Location.X, LabelDNI.Location.Y)


        'TextRitmo.Location = New Point(LabelRitmo.Location.X + LabelSintoma.Width, LabelRitmo.Location.Y)
        'TextSintoma.Location = New Point(LabelSintoma.Location.X + LabelSintoma.Width, LabelSintoma.Location.Y)
        'txtfechaexamen.Location = New Point(TextSintoma.Location.X, LabelFecha.Location.Y)



        LabelSintoma.Location = New Point(LabelRitmo.Location.X, LabelApellido.Location.Y)
        LabelFecha.Location = New Point(LabelSintoma.Location.X, LabelDNI.Location.Y)


        TextRitmo.Location = New Point(LabelRitmo.Location.X + LabelSintoma.Width, LabelRitmo.Location.Y)
        TextSintoma.Location = New Point(LabelSintoma.Location.X + LabelSintoma.Width, LabelSintoma.Location.Y)
        txtfechaexamen.Location = New Point(TextSintoma.Location.X, LabelFecha.Location.Y)






        LabelMandantevisible.Location = New Point(LabelSintoma.Location.X, LabelEdad.Location.Y)

        LabelActuantevisible.Location = New Point(LabelSintoma.Location.X, LabelSexo.Location.Y)

        LabelTecnicovisible.Location = New Point(LabelSintoma.Location.X, LabelInternado.Location.Y)


        cbxMandante.Location = New Point(TextSintoma.Location.X, LabelMandantevisible.Location.Y)

        cbxActuante.Location = New Point(TextSintoma.Location.X, LabelActuantevisible.Location.Y)

        cbxTecnico.Location = New Point(TextSintoma.Location.X, LabelTecnicovisible.Location.Y)

        Labelmandante.Location = New Point(cbxMandante.Location.X + cbxMandante.Width + 20, LabelMandantevisible.Location.Y)

        Labelactuante.Location = New Point(cbxMandante.Location.X + cbxMandante.Width + 20, LabelActuantevisible.Location.Y)

        Labeltecnico.Location = New Point(cbxMandante.Location.X + cbxMandante.Width + 20, LabelTecnicovisible.Location.Y)



        CheckBoxMandanteExterno.Location = New Point(cbxMandante.Location.X + cbxMandante.Width + 5, cbxMandante.Location.Y)



        Dim limite As Integer = LabelTitulo.Location.X + LabelTitulo.Width

        If limite > Me.Width Then

            LabelTitulo.Text = "TEST DE MOVIMIENTO" + vbCrLf + "OSCILATORIO CORPORAL"

        End If


        PictureBoxEditarPaciente.Width = PictureBoxSalirPaciente.Width
        PictureBoxEditarPaciente.Height = PictureBoxSalirPaciente.Width


        PictureBoxEditarPaciente.Location = New Point(PictureBoxSalirPaciente.Location.X, PictureBoxSalirPaciente.Location.Y + PictureBoxSalirPaciente.Height + 10)


        tickpersonales.Width = PictureBoxEditarPaciente.Width
        tickpersonales.Height = PictureBoxEditarPaciente.Height
        tickpersonales.Location = New Point(PictureBoxEditarPaciente.Location.X, PictureBoxEditarPaciente.Location.Y)


        botonsiguiente.Location = New Point(PictureBoxSalirPaciente.Location.X, PictureBoxSalirPaciente.Location.Y + PictureBoxSalirPaciente.Height * 2 + 11)

        LabelPacienteDesconectado.Location = New Point(PictureBoxECGPaciente.Location.X + PictureBoxECGPaciente.Width * 0.5 - LabelPacienteDesconectado.Width * 0.5, PictureBoxECGPaciente.Location.Y + PictureBoxECG.Height * 0.5)
        LabelPacientedesconectadoprotocolo.Location = New Point(LabelPacienteDesconectado.Location.X, LabelPacienteDesconectado.Location.Y)
        LabelPacientedesconectadoExamen.Location = New Point(LabelPacienteDesconectado.Location.X, LabelPacienteDesconectado.Location.Y)

        'botones correspondientes a la pantalla inicial
        botonNuevopaciente.Location = New Point(screenWidth * 0.25 - (botonNuevopaciente.Width / 2), screenHeight * 0.5)
        botonBuscarpaciente.Location = New Point(screenWidth * 0.5 - (botonBuscarpaciente.Width / 2), screenHeight * 0.5)
        botonbuscarexamen.Location = New Point(screenWidth * 0.75 - (botonbuscarexamen.Width / 2), screenHeight * 0.5)


        iconoPlayPaciente.Location = New Point(PictureBoxECGPaciente.Location.X + 5, PictureBoxECGPaciente.Location.Y + 5)
        iconoPlayPaciente.Width = PictureBoxEditarPaciente.Width * 0.5
        iconoPlayPaciente.Height = PictureBoxEditarPaciente.Height * 0.5

        iconoRECpaciente.Location = New Point(iconoPlayPaciente.Location.X + iconoPlayPaciente.Width, iconoPlayPaciente.Location.Y)
        iconoRECpaciente.Width = iconoPlayPaciente.Width
        iconoRECpaciente.Height = iconoPlayPaciente.Height


        iconoPlayProtocolos.Location = New Point(iconoPlayPaciente.Location.X, iconoPlayPaciente.Location.Y)
        iconoPlayProtocolos.Width = iconoPlayPaciente.Width
        iconoPlayProtocolos.Height = iconoPlayPaciente.Height

        iconoRecProtocolos.Location = New Point(iconoRECpaciente.Location.X, iconoRECpaciente.Location.Y)
        iconoRecProtocolos.Width = iconoPlayPaciente.Width
        iconoRecProtocolos.Height = iconoPlayPaciente.Height

        iconoPlayExamen.Location = New Point(iconoPlayPaciente.Location.X, iconoPlayPaciente.Location.Y)
        iconoPlayExamen.Width = iconoPlayPaciente.Width
        iconoPlayExamen.Height = iconoPlayPaciente.Height

        iconoRecExamen.Location = New Point(iconoRECpaciente.Location.X, iconoRECpaciente.Location.Y)
        iconoRecExamen.Width = iconoPlayPaciente.Width
        iconoRecExamen.Height = iconoPlayPaciente.Height


        'a partir de aca ordena la tab de protocolos------------------------------------

        botonsiguienteprotocolo.Height = botonsiguiente.Height
        botonsiguienteprotocolo.Width = botonsiguiente.Width

        botonAnteriorProtocolo.Height = botonsiguienteprotocolo.Height
        botonAnteriorProtocolo.Width = botonsiguienteprotocolo.Width

        botonanteriorExamen.Height = botonsiguienteprotocolo.Height
        botonanteriorExamen.Width = botonsiguienteprotocolo.Width

        botonanteriorGrafico.Height = botonsiguienteprotocolo.Height
        botonanteriorGrafico.Width = botonsiguienteprotocolo.Width

        botonanteriorConclusion.Height = botonsiguienteprotocolo.Height
        botonanteriorConclusion.Width = botonsiguienteprotocolo.Width

        iconoGuardarExamen.Height = botonsiguienteprotocolo.Height
        iconoGuardarExamen.Width = botonsiguienteprotocolo.Width

        iconoImprimirPDF.Height = botonsiguienteprotocolo.Height
        iconoImprimirPDF.Width = botonsiguienteprotocolo.Width

        botonModificarPresion.Height = botonsiguienteprotocolo.Height
        botonModificarPresion.Width = botonsiguienteprotocolo.Width


        botonsiguienteExamen.Height = botonsiguienteprotocolo.Height
        botonsiguienteExamen.Width = botonsiguienteprotocolo.Width

        botonsiguienteGrafico.Height = botonsiguienteprotocolo.Height
        botonsiguienteGrafico.Width = botonsiguienteprotocolo.Width


        tickprotocolo.Height = tickpersonales.Height
        tickprotocolo.Width = tickpersonales.Width

        PictureBoxSalirProtocolo.Height = PictureBoxSalirPaciente.Height
        PictureBoxSalirProtocolo.Width = PictureBoxSalirPaciente.Width


        LabelConexionProtocolo.Width = LabelConexionPersonales.Width
        LabelConexionProtocolo.Height = LabelConexionPersonales.Height


        botonsiguienteprotocolo.Location = New Point(botonsiguiente.Location.X, botonsiguiente.Location.Y)
        botonAnteriorProtocolo.Location = New Point(botonsiguienteprotocolo.Location.X, botonsiguienteprotocolo.Location.Y + botonsiguienteprotocolo.Height + 17)


        botonsiguienteExamen.Location = New Point(botonsiguiente.Location.X, botonsiguiente.Location.Y)
        botonanteriorExamen.Location = New Point(botonsiguienteprotocolo.Location.X, botonAnteriorProtocolo.Location.Y)


        botonsiguienteGrafico.Location = New Point(botonsiguiente.Location.X, botonsiguiente.Location.Y)
        botonanteriorGrafico.Location = New Point(botonsiguienteprotocolo.Location.X, botonAnteriorProtocolo.Location.Y)

        botonanteriorConclusion.Location = New Point(botonsiguienteprotocolo.Location.X, botonAnteriorProtocolo.Location.Y)

        iconoGuardarExamen.Location = New Point(botonsiguienteprotocolo.Location.X, PictureBoxEditarPaciente.Location.Y)

        iconoImprimirPDF.Location = New Point(botonsiguienteprotocolo.Location.X, botonsiguiente.Location.Y)

        tickprotocolo.Location = New Point(tickpersonales.Location.X, tickpersonales.Location.Y)


        PictureBoxSalirProtocolo.Location = New Point(PictureBoxSalirPaciente.Location.X, PictureBoxSalirPaciente.Location.Y)

        '  botonModificarPresion.Location = New Point(botonsiguiente.Location.X, botonanteriorExamen.Location.Y + botonanteriorExamen.Height + 10)
        botonModificarPresion.Location = New Point(botonsiguiente.Location.X, LabelPD.Location.Y)

        PictureBoxsalirTiras.Height = PictureBoxSalirPaciente.Height
        PictureBoxsalirTiras.Width = PictureBoxSalirPaciente.Width

        PictureBoxsalirTiras.Location = New Point(PictureBoxSalirPaciente.Location.X, PictureBoxSalirPaciente.Location.Y)


        '-------------------------
        PictureBox2.Width = screenWidth * 0.1
        PictureBox2.Location = New Point(screenWidth * 0.02, 0.05)

        ' LabeltituloINTE.Location = New Point(screenWidth * 0.15, 36)


        LabeltituloINTE.Location = New Point(LabeltituloPaciente.Location.X, LabeltituloPaciente.Location.Y)

        'Labelpreg1.Location = New Point(screenWidth * 0.15, 81)

        'originalmente era 81 el valor Y del labelpreg1

        Labelpreg1.Location = New Point(LabeltituloINTE.Location.X, LabeltituloPROTO.Location.Y + LabeltituloPROTO.Height + 15)

        Labelpreg2.Location = New Point(Labelpreg1.Location.X, 121 - 5)
        Labelpreg3.Location = New Point(Labelpreg1.Location.X, 161 - 5)
        Labelpreg4.Location = New Point(Labelpreg1.Location.X, 201 - 5)
        Labelpreg5.Location = New Point(Labelpreg1.Location.X, 251 - 5)
        Labelpreg6.Location = New Point(Labelpreg1.Location.X, 291 - 5)
        Labelpreg7.Location = New Point(Labelpreg1.Location.X, 331 - 5)
        Labelpreg8.Location = New Point(Labelpreg1.Location.X, 371 - 5)
        Labelpreg9.Location = New Point(Labelpreg1.Location.X, 411 - 5)


        Panel4.Location = New Point(Labelpreg1.Location.X + Labelpreg2.Width, Labelpreg1.Location.Y - 7)
        Panel5.Location = New Point(Panel4.Location.X, Labelpreg2.Location.Y - 7)

        Panel4.Height = INTE1SI.Height
        Panel4.Width = INTE1SI.Width + INTE1NO.Width + 20


        Panel5.Height = Panel4.Height
        Panel5.Width = Panel4.Width
        Panel6.Height = Panel4.Height
        Panel6.Width = Panel4.Width
        Panel7.Height = Panel4.Height
        Panel7.Width = Panel4.Width
        Panel9.Height = Panel4.Height
        Panel9.Width = Panel4.Width
        Panel10.Height = Panel4.Height
        Panel10.Width = Panel4.Width

        Panel8.Width = INTE6SI.Width + INTE6NO.Width + INTE6NOSABE.Width + 20 + 20


        TextINTE3.Width = Panel4.Location.X + Panel4.Width - (Labelpreg3.Location.X + Labelpreg3.Width * 1)


        TextINTE3.Location = New Point(Panel4.Location.X + Panel4.Width - TextINTE3.Width, Labelpreg3.Location.Y - 7)

        Panel6.Location = New Point(Panel4.Location.X, Labelpreg4.Location.Y - 7)
        Panel7.Location = New Point(Panel4.Location.X, Labelpreg5.Location.Y - 7)

        Panel8.Location = New Point(Panel4.Location.X + Panel4.Width - Panel8.Width, Labelpreg6.Location.Y - 7)
        Panel9.Location = New Point(Panel4.Location.X, Labelpreg7.Location.Y - 7)
        Panel10.Location = New Point(Panel4.Location.X, Labelpreg8.Location.Y - 7)

        TextINTE9.Width = TextINTE3.Width

        TextINTE9.Location = New Point(TextINTE3.Location.X, Labelpreg9.Location.Y - 5)


        INTE1NO.Location = New Point(Panel4.Width - INTE1NO.Width, 0)
        INTE1SI.Location = New Point(0, 0)

        INTE2NO.Location = New Point(Panel5.Width - INTE2NO.Width, 0)
        INTE2SI.Location = New Point(0, 0)

        INTE4NO.Location = New Point(Panel6.Width - INTE4NO.Width, 0)
        INTE4SI.Location = New Point(0, 0)

        INTE5NO.Location = New Point(Panel7.Width - INTE5NO.Width, 0)
        INTE5SI.Location = New Point(0, 0)

        INTE6SI.Location = New Point(0, 0)
        INTE6NOSABE.Location = New Point(Panel8.Width - INTE6NOSABE.Width, 0)
        INTE6NO.Location = New Point(INTE6SI.Width + 20, 0)

        INTE7NO.Location = New Point(Panel9.Width - INTE7NO.Width, 0)
        INTE7SI.Location = New Point(0, 0)

        INTE8NO.Location = New Point(Panel10.Width - INTE8NO.Width, 0)
        INTE8SI.Location = New Point(0, 0)




        ' TextINTE3.Width = Panel6.Location.X + Panel6.Width - (Labelpreg3.Location.X + Labelpreg3.Width * 1.5)
        ' TextINTE9.Width = TextINTE3.Width
        'primero la parte derecha

        'LabeltituloPROTO.Location = New Point(TextINTE3.Location.X + TextINTE3.Width + 40, LabeltituloINTE.Location.Y)

        LabeltituloPROTO.Location = New Point(PictureBoxECGProtocolo.Location.X + PictureBoxECGProtocolo.Width - TextProtocolo.Width, LabeltituloINTE.Location.Y)


        'ComboBoxProtocolo.Location = New Point(TextINTE3.Location.X + TextINTE3.Width + 43, LabeltituloPROTO.Location.Y + 55)


        'asi estaba hasta recien LabeltituloPROTO.Location.Y + 55
        ComboBoxProtocolo.Location = New Point(LabeltituloPROTO.Location.X, Panel4.Location.Y)



        '  TextProtocolo.Location = New Point(TextINTE3.Location.X + TextINTE3.Width + 43, ComboBoxProtocolo.Location.Y + 35)
        TextProtocolo.Location = New Point(LabeltituloPROTO.Location.X, ComboBoxProtocolo.Location.Y + 35)

        'PictureBoxECGProtocolo.Width = PictureBoxECG.Width

        'PictureBoxECGProtocolo.Height = PictureBoxECG.Height

        ' PictureBoxECGProtocolo.Location = New Point(Labelpreg1.Location.X, PictureBoxECG.Location.Y)

        PictureBoxECGProtocolo.Width = PictureBoxECGPaciente.Width

        PictureBoxECGProtocolo.Height = PictureBoxECGPaciente.Height


        PictureBoxECGProtocolo.Location = New Point(PictureBoxECGPaciente.Location.X, PictureBoxECGPaciente.Location.Y)

        '-aca pongo la parte de grafico que seria facil a priori


        PictureBox3.Width = PictureBox1.Width
        PictureBox3.Height = PictureBox1.Height
        PictureBox3.Location = New Point(PictureBox1.Location.X, PictureBox1.Location.Y)

        PictureBox4.Width = PictureBox3.Width
        PictureBox4.Height = PictureBox3.Height
        PictureBox4.Location = New Point(PictureBox3.Location.X, PictureBox3.Location.Y)


        PictureBox6.Width = PictureBox3.Width
        PictureBox6.Height = PictureBox3.Height
        PictureBox6.Location = New Point(PictureBox3.Location.X, PictureBox3.Location.Y)



        LabeltituloPaciente.Location = New Point(LabeltituloINTE.Location.X, LabeltituloINTE.Location.Y)


        PictureBoxsalirgrafico.Width = PictureBoxSalirPaciente.Width
        PictureBoxsalirgrafico.Height = PictureBoxSalirPaciente.Height
        PictureBoxsalirgrafico.Location = New Point(PictureBoxSalirPaciente.Location.X, PictureBoxSalirPaciente.Location.Y)


        PictureBoxsalirServicio.Width = PictureBoxSalirPaciente.Width
        PictureBoxsalirServicio.Height = PictureBoxSalirPaciente.Height

        PictureBoxsalirServicio.Location = New Point(PictureBoxSalirPaciente.Location.X, PictureBoxSalirPaciente.Location.Y)

        'Chart1.Width = screenWidth * 0.9
        'Chart1.Height = screenHeight * 0.9

        Chart1.Width = screenWidth * 0.84
        Chart1.Height = screenHeight * 0.87

        Chart1.Location = New Point(PictureBox4.Location.X + PictureBox4.Width, Chart1.Location.Y)


        DatosExamen.RowHeadersVisible = False

        'antes que los botones deberia tocar la tabla
        If (screenWidth * 0.65 < 778) Then
            DatosExamen.Width = screenWidth * 0.65
        End If

        'aca esta la papota
        'DatosExamen.Width = screenWidth * 0.595
        DatosExamen.Width = PictureBoxECGPaciente.Width

        DatosExamen.Height = screenHeight * 0.51

        Dim maximo As Integer = screenHeight - TextTelefono.Location.Y - TextTelefono.Height

        If DatosExamen.Height > maximo Then

            DatosExamen.Height = TextTelefono.Location.Y + TextTelefono.Height

        End If




        Dim min As DataGridViewColumn = DatosExamen.Columns(0)
        'min.Width = DatosExamen.Width * 0.1
        min.Width = 75

        Dim min2 As DataGridViewColumn = DatosExamen.Columns(1)
        'min = DatosExamen.Columns(1)
        min2.Width = 250


        For i As Integer = 2 To 4
            min = DatosExamen.Columns(i)
            min.Width = (DatosExamen.Width - DatosExamen.Columns(1).Width - DatosExamen.Columns(0).Width) / 3
        Next


        'ChartECG.Width = DatosExamen.Width
        ' ChartECG.Height = screenHeight - DatosExamen.Height - 100

        'ChartECG.Location = New Point(DatosExamen.Location.X, DatosExamen.Location.Y + DatosExamen.Height + 10)


        '   PictureBoxECG.Width = DatosExamen.Width
        PictureBoxECG.Height = screenHeight - DatosExamen.Height - 100

        PictureBoxECG.Location = New Point(DatosExamen.Location.X, DatosExamen.Location.Y + DatosExamen.Height + 10)


        ' PictureBoxECG.Width = PictureBoxECGPaciente.Width
        '  PictureBoxECG.Height = PictureBoxECGPaciente.Height

        'PictureBoxECG.Location = New Point(PictureBoxECGPaciente.Location.X, PictureBoxECGPaciente.Location.Y)
        PictureBoxECG.Location = New Point(PictureBoxECGPaciente.Location.X, PictureBoxECG.Location.Y)


        'DatosExamen.Location = New Point(PictureBoxECG.Location.X, DatosExamen.Location.Y)

        DatosExamen.Location = New Point(PictureBoxECG.Location.X, PictureBoxSalirPaciente.Location.Y) '10)


        'ancho_display es la variable global que utilizo para recorrer el display
        ancho_display = PictureBoxECG.Width

        ancho_display_print = ancho_display * 2




        'la parte de examen

        'IniciarExamen.Location = New Point(DatosExamen.Location.X + DatosExamen.Width + 5, 0)
        botonSiguienteEtapa.Location = New Point(10, PictureBox3.Location.Y + PictureBox3.Height)


        ' IniciarExamen.Width = screenWidth * 0.13125 + 10

        'el que habia antes
        'IniciarExamen.Width = screenWidth * 0.11
        botonSiguienteEtapa.Width = DatosExamen.Location.X - 25
        ' IniciarExamen.Width = DatosExamen.Location.X - IniciarExamen.Location.X


        botonSiguienteEtapa.Height = screenHeight * 0.093

        'DetenerExamen.Location = New Point(DatosExamen.Location.X + DatosExamen.Width + 5, IniciarExamen.Location.Y + IniciarExamen.Height + 3)
        ''  DetenerExamen.Width = screenWidth * 0.13125 + 10
        'DetenerExamen.Width = screenWidth * 0.11
        'DetenerExamen.Height = screenHeight * 0.093




        ' botonPresion.Location = New Point(DatosExamen.Location.X + DatosExamen.Width + 5, IniciarExamen.Location.Y + IniciarExamen.Height + 3)

        botonPresion.Location = New Point(botonSiguienteEtapa.Location.X, botonSiguienteEtapa.Location.Y + botonSiguienteEtapa.Height + 3)

        'botonPresion.Width = screenWidth * 0.13125 + 10
        botonPresion.Width = botonSiguienteEtapa.Width
        botonPresion.Height = botonSiguienteEtapa.Height

        '  botonPresion.Font = fntText


        'botonECG.Location = New Point(DatosExamen.Location.X + DatosExamen.Width + 5, botonPresion.Location.Y + IniciarExamen.Height + 3)
        'botonECG.Location = New Point(IniciarExamen.Location.X, PictureBoxECG.Location.Y)

        '' botonECG.Width = screenWidth * 0.13125 + 10
        'botonECG.Width = IniciarExamen.Width
        'botonECG.Height = IniciarExamen.Height

        ' botonECG.Font = fntText


        ' botonDeshacer.Location = New Point(DatosExamen.Location.X + DatosExamen.Width + 5, botonECG.Location.Y + IniciarExamen.Height + 3)
        'botonDeshacer.Location = New Point(IniciarExamen.Location.X, botonECG.Location.Y + IniciarExamen.Height + 3)


        'botonDeshacer.Width = screenWidth * 0.13125 + 10
        botonDeshacer.Width = botonSiguienteEtapa.Width
        botonDeshacer.Height = botonSiguienteEtapa.Height

        ' botonDeshacer.Font = fntText

        'botonSiguienteEtapa.Location = New Point(IniciarExamen.Location.X, botonDeshacer.Location.Y + IniciarExamen.Height + 3)

        'botonSiguienteEtapa.Location = New Point(IniciarExamen.Location.X, IniciarExamen.Location.Y)
        botonDeshacer.Location = New Point(botonSiguienteEtapa.Location.X, botonSiguienteEtapa.Location.Y)

        '   botonSiguienteEtapa.Width = IniciarExamen.Width

        'botonSiguienteEtapa.Height = IniciarExamen.Height


        botonTerminarExamen.Location = New Point(botonSiguienteEtapa.Location.X, botonPresion.Location.Y + botonSiguienteEtapa.Height + 3)

        botonTerminarExamen.Width = botonSiguienteEtapa.Width
        botonTerminarExamen.Height = botonSiguienteEtapa.Height


        LabelConexionPersonales.Width = botonSiguienteEtapa.Width
        LabelConexionPersonales.Location = New Point(botonSiguienteEtapa.Location.X, PictureBoxECGPaciente.Location.Y + PictureBoxECGPaciente.Height - LabelConexionPersonales.Height)

        LabelConexionProtocolo.Width = LabelConexionPersonales.Width
        LabelConexionProtocolo.Height = LabelConexionPersonales.Height
        LabelConexionProtocolo.Location = New Point(LabelConexionPersonales.Location.X, LabelConexionPersonales.Location.Y)

        LabelConexionExamen.Width = LabelConexionPersonales.Width
        LabelConexionExamen.Height = LabelConexionPersonales.Height
        LabelConexionExamen.Location = New Point(LabelConexionPersonales.Location.X, LabelConexionPersonales.Location.Y)

        Dim graf As Graphics = botonPresion.CreateGraphics
        Dim tamaniofont As Single = botonPresion.Font.Size
        ' MsgBox("Original font size = " & tamaniofont)
        Dim fntText As System.Drawing.Font
        Dim dsfRequired As SizeF


        'Dim strText As String = "This is an example of setting the font size to fit the height of the label."
        'Dim graLabel As Graphics = Me.Label1.CreateGraphics
        ' Dim sngFontSize As Single = Me.Label1.Font.Size
        'MsgBox("Original font size = " & sngFontSize)


        Do
            ' LabelTitulo.Font = New System.Drawing.Font(LabelTitulo.Font.Name, tamanio, LabelTitulo.Font.Style)
            fntText = New System.Drawing.Font(botonPresion.Font.FontFamily, tamaniofont)
            dsfRequired = graf.MeasureString(botonPresion.Text, fntText)
            tamaniofont = 0.99F * tamaniofont
        Loop Until (dsfRequired.Height <= botonPresion.ClientSize.Height * 0.35)

        'MsgBox("Final font size = " & tamanio)
        botonSiguienteEtapa.Font = fntText
        'DetenerExamen.Font = fntText
        botonPresion.Font = fntText
        botonDeshacer.Font = fntText
        'botonECG.Font = fntText
        botonSiguienteEtapa.Font = fntText
        botonTerminarExamen.Font = fntText
        'aca pongo botones de otras pestañas

        'botonECGpersonales.Font = fntText
        'botonECGprotocolo.Font = fntText

        'botones de conclusiones



        botonBorrarEventos.Width = botonSiguienteEtapa.Width
        botonBorrarEventos.Height = botonSiguienteEtapa.Height
        botonBorrarEventos.Location = New Point(botonSiguienteEtapa.Location.X, botonPresion.Location.Y + botonSiguienteEtapa.Height + 3)
        botonBorrarEventos.Font = fntText


        botonEditarEvento.Width = botonSiguienteEtapa.Width
        botonEditarEvento.Height = botonSiguienteEtapa.Height
        botonEditarEvento.Location = New Point(botonSiguienteEtapa.Location.X, botonBorrarEventos.Location.Y + botonSiguienteEtapa.Height + 3)
        botonEditarEvento.Font = fntText

        botonCancelarEdicionEvento.Width = botonSiguienteEtapa.Width
        botonCancelarEdicionEvento.Height = botonSiguienteEtapa.Height
        botonCancelarEdicionEvento.Location = New Point(botonSiguienteEtapa.Location.X, botonEditarEvento.Location.Y + botonSiguienteEtapa.Height + 3)
        botonCancelarEdicionEvento.Font = fntText



        '´---ahora los displays

        LabelINC.Location = New Point(DatosExamen.Location.X + DatosExamen.Width + 5, botonDeshacer.Location.Y + botonSiguienteEtapa.Height + 3)

        txtinclinacion.Location = New Point(DatosExamen.Location.X + DatosExamen.Width + 5, LabelINC.Location.Y + LabelINC.Height)



        'LabelTiempo.Location = New Point(IniciarExamen.Location.X + IniciarExamen.Width + 5, 0)
        'LabelFrecuencia.Location = New Point(IniciarExamen.Location.X + IniciarExamen.Width + 5, TextBoxTiempo.Location.Y + TextBoxTiempo.Height + 5)
        'LabelPS.Location = New Point(IniciarExamen.Location.X + IniciarExamen.Width + 5, txtFC.Location.Y + TextBoxTiempo.Height + 5)
        'LabelPD.Location = New Point(IniciarExamen.Location.X + IniciarExamen.Width + 5, txtsistolica.Location.Y + TextBoxTiempo.Height + 5)
        'LabelINC.Location = New Point(IniciarExamen.Location.X + IniciarExamen.Width + 5, txtdiastolica.Location.Y + TextBoxTiempo.Height + 5)


        'LabelTiempo.Location = New Point(DatosExamen.Location.X + DatosExamen.Width + 5, 0)

        LabelTiempo.Location = New Point(DatosExamen.Location.X + DatosExamen.Width + 5, DatosExamen.Location.Y)
        ' LabelTiempo.Location = New Point(0, 0)

        'hasta arhoa estaba en 32
        LabelTiempo.Height = screenHeight * 0.0373
        LabelFrecuencia.Height = LabelTiempo.Height
        LabelPD.Height = LabelTiempo.Height
        LabelPS.Height = LabelTiempo.Height
        LabelINC.Height = LabelTiempo.Height

        TextBoxTiempo.Location = New Point(LabelTiempo.Location.X, LabelTiempo.Location.Y + LabelTiempo.Height)

        'antes era 5 la distancia entre labels de tiempo, fc, ps , pd e incl
        'en lugar de 17 pongo la proporcion
        Dim dist As Integer = screenHeight * 0.0198

        LabelFrecuencia.Location = New Point(LabelTiempo.Location.X, TextBoxTiempo.Location.Y + TextBoxTiempo.Height + dist)
        LabelPS.Location = New Point(LabelTiempo.Location.X, txtFC.Location.Y + TextBoxTiempo.Height + dist)
        LabelPD.Location = New Point(LabelTiempo.Location.X, txtsistolica.Location.Y + TextBoxTiempo.Height + dist)
        LabelINC.Location = New Point(LabelTiempo.Location.X, txtdiastolica.Location.Y + TextBoxTiempo.Height + dist)



        txtFC.Location = New Point(LabelTiempo.Location.X, LabelFrecuencia.Location.Y + LabelFrecuencia.Height)

        txtsistolica.Location = New Point(LabelTiempo.Location.X, LabelPS.Location.Y + LabelPS.Height)
        txtdiastolica.Location = New Point(LabelTiempo.Location.X, LabelPD.Location.Y + LabelPD.Height)
        txtinclinacion.Location = New Point(LabelTiempo.Location.X, LabelINC.Location.Y + LabelINC.Height)



        'TextBoxTiempo.Width = screenWidth * 0.2


        'antes estaba textboxtiempo = datos examen location
        'TextBoxTiempo.Width = DatosExamen.Location.X

        TextBoxTiempo.Width = PictureBoxSalirPaciente.Location.X - (DatosExamen.Location.X + DatosExamen.Width) - 10

        TextBoxTiempo.Height = screenHeight * 0.126
        LabelTiempo.Width = TextBoxTiempo.Width

        txtFC.Width = TextBoxTiempo.Width
        txtFC.Height = TextBoxTiempo.Height
        LabelFrecuencia.Width = txtFC.Width

        txtsistolica.Width = TextBoxTiempo.Width
        txtsistolica.Height = TextBoxTiempo.Height
        LabelPS.Width = txtsistolica.Width

        txtdiastolica.Width = TextBoxTiempo.Width
        txtdiastolica.Height = TextBoxTiempo.Height
        LabelPD.Width = txtdiastolica.Width

        txtinclinacion.Width = TextBoxTiempo.Width
        txtinclinacion.Height = TextBoxTiempo.Height
        LabelINC.Width = txtinclinacion.Width

        graf = TextBoxTiempo.CreateGraphics
        tamaniofont = TextBoxTiempo.Font.Size

        Do
            ' LabelTitulo.Font = New System.Drawing.Font(LabelTitulo.Font.Name, tamanio, LabelTitulo.Font.Style)
            fntText = New System.Drawing.Font(TextBoxTiempo.Font.FontFamily, tamaniofont)
            dsfRequired = graf.MeasureString(TextBoxTiempo.Text, fntText)
            tamaniofont = 0.99F * tamaniofont
        Loop Until (dsfRequired.Height <= TextBoxTiempo.ClientSize.Height * 0.99 And dsfRequired.Width <= TextBoxTiempo.ClientSize.Width * 0.99)




        'MsgBox("Final font size = " & tamanio)
        TextBoxTiempo.Font = fntText
        txtFC.Font = fntText
        txtsistolica.Font = fntText
        txtdiastolica.Font = fntText
        txtinclinacion.Font = fntText

        PictureBoxsalirexamen.Width = PictureBoxSalirPaciente.Width
        PictureBoxsalirexamen.Height = PictureBoxSalirPaciente.Height
        PictureBoxsalirexamen.Location = New Point(PictureBoxSalirPaciente.Location.X, PictureBoxSalirPaciente.Location.Y)

        'nuevos botones de ECG

        'botonECGpersonales.Width = botonECG.Width
        'botonECGprotocolo.Width = botonECG.Width

        'botonECGpersonales.Height = botonECG.Height
        'botonECGprotocolo.Height = botonECG.Height

        'botonECGpersonales.Location = New Point(botonECG.Location.X, PictureBoxECGPaciente.Location.Y)
        'botonECGprotocolo.Location = New Point(botonECG.Location.X, PictureBoxECGPaciente.Location.Y)



        '---------------------------------------aca empieza el ordenamiento del servicio tecnico

        'PanelStaff.Location = New Point(19, 0)

        PanelStaff.Location = New Point(LabeltituloINTE.Location.X + LabeltituloINTE.Width * 0.25, 30)

        txtbuscartecnico.Location = New Point(PanelStaff.Location.X, PanelStaff.Location.Y + PanelStaff.Height + 10)
        txtbuscarmandante.Location = New Point(PanelStaff.Location.X, PanelStaff.Location.Y + PanelStaff.Height + 10)
        txtbuscaractuante.Location = New Point(PanelStaff.Location.X, PanelStaff.Location.Y + PanelStaff.Height + 10)

        LabelNombreTecnico.Location = New Point(PanelStaff.Location.X, txtbuscartecnico.Location.Y + txtbuscartecnico.Height + 5)
        LabelApellidoTecnico.Location = New Point(PanelStaff.Location.X, txtNombreTecnico.Location.Y + txtNombreTecnico.Height + 5)

        txtNombreTecnico.Location = New Point(LabelNombreTecnico.Location.X + LabelApellidoTecnico.Width, txtbuscartecnico.Location.Y + txtbuscartecnico.Height + 5)
        txtNombreMandante.Location = New Point(LabelNombreTecnico.Location.X + LabelApellidoTecnico.Width, txtbuscartecnico.Location.Y + txtbuscartecnico.Height + 5)
        txtNombreactuante.Location = New Point(LabelNombreTecnico.Location.X + LabelApellidoTecnico.Width, txtbuscartecnico.Location.Y + txtbuscartecnico.Height + 5)

        txtApellidoTecnico.Location = New Point(LabelApellidoTecnico.Location.X + LabelApellidoTecnico.Width, txtNombreTecnico.Location.Y + txtNombreTecnico.Height + 5)
        txtApellidoMandante.Location = New Point(LabelApellidoTecnico.Location.X + LabelApellidoTecnico.Width, txtNombreTecnico.Location.Y + txtNombreTecnico.Height + 5)
        txtApellidoactuante.Location = New Point(LabelApellidoTecnico.Location.X + LabelApellidoTecnico.Width, txtNombreTecnico.Location.Y + txtNombreTecnico.Height + 5)

        activotecnico.Location = New Point(PanelStaff.Location.X, LabelApellidoTecnico.Location.Y + LabelApellidoTecnico.Height + 10)
        activomandante.Location = New Point(PanelStaff.Location.X, LabelApellidoTecnico.Location.Y + LabelApellidoTecnico.Height + 10)
        activoactuante.Location = New Point(PanelStaff.Location.X, LabelApellidoTecnico.Location.Y + LabelApellidoTecnico.Height + 10)

        DefectoTecnico.Location = New Point(activotecnico.Location.X + activotecnico.Width, LabelApellidoTecnico.Location.Y + LabelApellidoTecnico.Height + 10)
        DefectoMandante.Location = New Point(activotecnico.Location.X + activotecnico.Width, LabelApellidoTecnico.Location.Y + LabelApellidoTecnico.Height + 10)
        DefectoActuante.Location = New Point(activotecnico.Location.X + activotecnico.Width, LabelApellidoTecnico.Location.Y + LabelApellidoTecnico.Height + 10)
        'pongo todos en el mismo lugar y depediendo del panel con radio buttons cambia quien es visible

        botonBuscarTecnico.Location = New Point(PanelStaff.Location.X + txtbuscartecnico.Width + 60, PanelStaff.Location.Y + PanelStaff.Height + 10)
        BuscarMedMan.Location = New Point(PanelStaff.Location.X + txtbuscartecnico.Width + 60, PanelStaff.Location.Y + PanelStaff.Height + 10)
        buscaractuante.Location = New Point(PanelStaff.Location.X + txtbuscartecnico.Width + 60, PanelStaff.Location.Y + PanelStaff.Height + 10)

        InsertarTecnico.Location = New Point(PanelStaff.Location.X + txtbuscartecnico.Width + 60, botonBuscarTecnico.Location.Y + botonBuscarTecnico.Height + 5)
        InsertarMandante.Location = New Point(PanelStaff.Location.X + txtbuscartecnico.Width + 60, botonBuscarTecnico.Location.Y + botonBuscarTecnico.Height + 5)
        Insertaractuante.Location = New Point(PanelStaff.Location.X + txtbuscartecnico.Width + 60, botonBuscarTecnico.Location.Y + botonBuscarTecnico.Height + 5)

        EliminarTecnico.Location = New Point(PanelStaff.Location.X + txtbuscartecnico.Width + 60, InsertarTecnico.Location.Y + botonBuscarTecnico.Height + 5)
        EliminarMandante.Location = New Point(PanelStaff.Location.X + txtbuscartecnico.Width + 60, InsertarTecnico.Location.Y + botonBuscarTecnico.Height + 5)
        Eliminaractuante.Location = New Point(PanelStaff.Location.X + txtbuscartecnico.Width + 60, InsertarTecnico.Location.Y + botonBuscarTecnico.Height + 5)

        EditarTecnico.Location = New Point(PanelStaff.Location.X + txtbuscartecnico.Width + 60, EliminarTecnico.Location.Y + botonBuscarTecnico.Height + 5)
        EditarMandante.Location = New Point(PanelStaff.Location.X + txtbuscartecnico.Width + 60, EliminarTecnico.Location.Y + botonBuscarTecnico.Height + 5)
        Editaractuante.Location = New Point(PanelStaff.Location.X + txtbuscartecnico.Width + 60, EliminarTecnico.Location.Y + botonBuscarTecnico.Height + 5)

        DGVtecnicos.Location = New Point(PanelStaff.Location.X, EditarTecnico.Location.Y + EditarTecnico.Height + 5)
        DGVmedicosman.Location = New Point(PanelStaff.Location.X, EditarTecnico.Location.Y + EditarTecnico.Height + 5)
        DGVmedicosact.Location = New Point(PanelStaff.Location.X, EditarTecnico.Location.Y + EditarTecnico.Height + 5)


        'antes estaba en 0.6 de la screenwidth , ahora la pongo en funcion del resto
        'DGVtecnicos.Width = screenWidth * 0.6

        DGVtecnicos.Width = botonBuscarTecnico.Location.X + botonBuscarTecnico.Width - txtbuscartecnico.Location.X

        DGVmedicosman.Width = DGVtecnicos.Width
        DGVmedicosman.Height = DGVtecnicos.Height

        DGVmedicosact.Width = DGVtecnicos.Width
        DGVmedicosact.Height = DGVtecnicos.Height


        'DGVtecnicos.Width = 650


        txtNombreTecnico.ReadOnly = True
        txtNombreactuante.ReadOnly = True
        txtNombreMandante.ReadOnly = True

        txtApellidoactuante.ReadOnly = True
        txtApellidoTecnico.ReadOnly = True
        txtApellidoMandante.ReadOnly = True

        activotecnico.Enabled = False
        activoactuante.Enabled = False
        activomandante.Enabled = False

        DefectoTecnico.Enabled = False
        DefectoActuante.Enabled = False
        DefectoMandante.Enabled = False



        'Dim min As DataGridViewColumn = DatosExamen.Columns(0)
        ''min.Width = DatosExamen.Width * 0.1
        'min.Width = 75

        'Dim min2 As DataGridViewColumn = DatosExamen.Columns(1)
        ''min = DatosExamen.Columns(1)
        'min2.Width = 250


        'For i As Integer = 2 To 4
        '    min = DatosExamen.Columns(i)
        '    min.Width = (DatosExamen.Width - DatosExamen.Columns(1).Width - DatosExamen.Columns(0).Width) / 3
        'Next


        BotonRutaPDF.Width = DGVtecnicos.Width * 0.22
        password.Width = BotonRutaPDF.Width
        botonPlantillas.Width = BotonRutaPDF.Width
        botonProtocolos.Width = BotonRutaPDF.Width
        ' botonRecuperar.Width = BotonRutaPDF.Width
        BotonCambiarServidor.Width = BotonRutaPDF.Width
        BotonBaseDatos.Width = BotonRutaPDF.Width

        BotonIP.Width = BotonRutaPDF.Width
        BotonUsuarios.Width = BotonRutaPDF.Width

        'primera columna
        BotonRutaPDF.Location = New Point(PanelStaff.Location.X, DGVtecnicos.Location.Y + DGVtecnicos.Height + 25)
        password.Location = New Point(PanelStaff.Location.X, BotonRutaPDF.Location.Y + BotonRutaPDF.Height + 25)

        'segunda columna
        botonPlantillas.Location = New Point(BotonRutaPDF.Location.X + DGVtecnicos.Width * 0.26, DGVtecnicos.Location.Y + DGVtecnicos.Height + 25)
        botonProtocolos.Location = New Point(BotonRutaPDF.Location.X + DGVtecnicos.Width * 0.26, BotonRutaPDF.Location.Y + BotonRutaPDF.Height + 25)

        'tercera columna
        BotonCambiarServidor.Location = New Point(BotonRutaPDF.Location.X + DGVtecnicos.Width * 0.52, DGVtecnicos.Location.Y + DGVtecnicos.Height + 25)
        BotonBaseDatos.Location = New Point(BotonRutaPDF.Location.X + DGVtecnicos.Width * 0.52, BotonRutaPDF.Location.Y + BotonRutaPDF.Height + 25)

        'cuarta columna
        BotonIP.Location = New Point(BotonRutaPDF.Location.X + DGVtecnicos.Width * 0.78, DGVtecnicos.Location.Y + DGVtecnicos.Height + 25)
        BotonUsuarios.Location = New Point(BotonRutaPDF.Location.X + DGVtecnicos.Width * 0.78, BotonRutaPDF.Location.Y + BotonRutaPDF.Height + 25)




        'botonProtocolos.Location = New Point(PanelStaff.Location.X + BotonRutaPDF.Width + 15, DGVtecnicos.Location.Y + DGVtecnicos.Height + 5)
        'botonRecuperar.Location = New Point(PanelStaff.Location.X + BotonRutaPDF.Width + 15, BotonRutaPDF.Location.Y + BotonRutaPDF.Height + 5)
        'BotonCambiarServidor.Location = New Point(PanelStaff.Location.X + BotonRutaPDF.Width + 15, password.Location.Y + BotonRutaPDF.Height + 5)

        'botonProtocolos.Location = New Point(BotonRutaPDF.Location.X + DGVtecnicos.Width * 0.26, DGVtecnicos.Location.Y + DGVtecnicos.Height + 5)
        ' botonRecuperar.Location = New Point(BotonRutaPDF.Location.X + DGVtecnicos.Width * 0.26, BotonRutaPDF.Location.Y + BotonRutaPDF.Height + 5)
        '   BotonCambiarServidor.Location = New Point(BotonRutaPDF.Location.X + DGVtecnicos.Width * 0.26, password.Location.Y + BotonRutaPDF.Height + 5)


        'BotonBaseDatos.Location = New Point(botonProtocolos.Location.X + botonProtocolos.Width + 15, DGVtecnicos.Location.Y + DGVtecnicos.Height + 5)

        ' BotonBaseDatos.Location = New Point(BotonRutaPDF.Location.X + DGVtecnicos.Width * 0.52, DGVtecnicos.Location.Y + DGVtecnicos.Height + 5)

        'BotonIP.Location = New Point(BotonRutaPDF.Location.X + DGVtecnicos.Width * 0.52, BotonRutaPDF.Location.Y + BotonRutaPDF.Height + 5)

        'BotonUsuarios.Location = New Point(BotonRutaPDF.Location.X + DGVtecnicos.Width * 0.52, password.Location.Y + BotonRutaPDF.Height + 5)



        txtbuscartecnico.Width = PanelStaff.Location.X + PanelStaff.Width - botonBuscarTecnico.Width
        txtbuscarmandante.Width = PanelStaff.Location.X + PanelStaff.Width - botonBuscarTecnico.Width
        txtbuscaractuante.Width = PanelStaff.Location.X + PanelStaff.Width - botonBuscarTecnico.Width

        txtNombreTecnico.Width = txtbuscartecnico.Location.X + txtbuscartecnico.Width - txtNombreTecnico.Location.X
        txtApellidoTecnico.Width = txtbuscartecnico.Location.X + txtbuscartecnico.Width - txtNombreTecnico.Location.X

        txtNombreMandante.Width = txtbuscartecnico.Location.X + txtbuscartecnico.Width - txtNombreTecnico.Location.X
        txtApellidoMandante.Width = txtbuscartecnico.Location.X + txtbuscartecnico.Width - txtNombreTecnico.Location.X

        txtNombreactuante.Width = txtbuscartecnico.Location.X + txtbuscartecnico.Width - txtNombreTecnico.Location.X
        txtApellidoactuante.Width = txtbuscartecnico.Location.X + txtbuscartecnico.Width - txtNombreTecnico.Location.X





        '-------------------------------------------------aca ORDENO LA PARTE DE TIRAS DE ECG
        ChartEventos.Height = PictureBoxECG.Height '* 0.92

        'ChartEventos.Width = ChartECG.Width * 1.25
        PictureBox5.Width = PictureBox3.Width
        PictureBox5.Height = PictureBox3.Height
        PictureBox5.Location = New Point(PictureBox3.Location.X, PictureBox3.Location.Y)

        'ChartEventos.Width = DatosExamen.Width


        'ListBoxeventos.Width = ChartEventos.Width
        ListBoxeventos.Width = TextINTE3.Location.X + TextINTE3.Width - Labelpreg3.Location.X


        'ListBoxeventos.Height = ChartEventos.Location.Y - ListBoxeventos.Location.Y - 40



        ' ListBoxeventos.Width = ChartEventos.Width * 0.75

        LabeltituloTiras.Location = New Point(LabeltituloINTE.Location.X, LabeltituloINTE.Location.Y)

        'ListBoxeventos.Location = New Point(LabeltituloTiras.Location.X, LabeltituloTiras.Location.Y + LabeltituloTiras.Height + 5)
        ListBoxeventos.Location = New Point(LabeltituloTiras.Location.X, Labelpreg1.Location.Y)


        ListBoxeventos.Height = botonanteriorConclusion.Location.Y + botonanteriorConclusion.Height - ListBoxeventos.Location.Y


        ChartEventos.Location = New Point(ListBoxeventos.Location.X, ListBoxeventos.Location.Y + ListBoxeventos.Height + 5)

        'asi estaba hasta el 24 de septiembre
        ' ChartEventos.Location = New Point(ListBoxeventos.Location.X, PictureBoxECG.Location.Y)

        'arriba esta que agarre la altura del ecg display

        ChartEventos.Height = PictureBoxECG.Location.Y + PictureBoxECG.Height - ChartEventos.Location.Y


        '-----

        'ACA DE NUEVO LA MISMA BOLUDEZ DE DEPENDENCIA AL REVEZ
        '   PictureBoxECGPaciente.Width = TextRitmo.Location.X + TextRitmo.Width - LabelNombre.Location.X


        'PictureBoxECGPaciente.Width = PictureBoxECG.Width

        PictureBoxECGPaciente.Height = PictureBoxECG.Height

        PictureBoxECGPaciente.Location = New Point(LabelNombre.Location.X, PictureBoxECG.Location.Y)

        altura_display = PictureBoxECG.Height

        'Personal.BackgroundImage = New Bitmap("C:\Users\Facundo\Desktop\fondo3.png")
        'TabPersonales.BackgroundImage = New Bitmap(direccion_txt & "\fondo3.png")

        'TabPersonales.BackgroundImage = New Bitmap("C:\Users\Facundo\Desktop\fondo3.png")
        'Fotofondo.Height = (screenHeight - LabelTitulo.Location.Y - LabelTitulo.Height)
        'Fotofondo.ImageLocation = LabelTitulo.Location.X
        txtfechahoy.Location = New Point((PictureBoxSalirPaciente.Location.X + PictureBoxSalirPaciente.Width - txtfechahoy.Width), PictureBox1.Location.Y)


        'asi estaba hasta el 1 de octubre

        imagenfondo.Location = New Point(LabelTitulo.Location.X, LabelTitulo.Location.Y + LabelTitulo.Height)
        'imagenfondo.Location = New Point((screenWidth / 2) - (LabelTitulo.Width / 2), LabelTitulo.Location.Y + LabelTitulo.Height)

        imagenfondo.Width = LabelTitulo.Width

        imagenfondo.Height = screenHeight - LabelTitulo.Location.Y - LabelTitulo.Height




        'aca falta la parte de conclusiones



        LabelConclusion.Location = New Point(LabeltituloPROTO.Location.X, LabeltituloTiras.Location.Y)
        conclusiontext.Location = New Point(LabelConclusion.Location.X, ListBoxeventos.Location.Y)


        'conclusiontext.Width = ListBoxeventos.Width
        conclusiontext.Width = TextBoxTiempo.Location.X + TextBoxTiempo.Width - conclusiontext.Location.X
        conclusiontext.Height = ListBoxeventos.Height


        ChartEventos.Width = conclusiontext.Location.X + conclusiontext.Width - ChartEventos.Location.X

        ' ImprimirPDF.Width = IniciarExamen.Width
        'ImprimirPDF.Height = IniciarExamen.Height
        'ImprimirPDF.Location = New Point(IniciarExamen.Location.X, IniciarExamen.Location.Y)

       

        cbxConclusiones.Location = New Point(LabelConclusion.Location.X + LabelConclusion.Width + 5, LabelConclusion.Location.Y + 5)


        Dim aux As Integer = PictureBoxECG.Width
        aux = TextBoxTiempo.Width
        aux = botonsiguienteprotocolo.Width
        aux = PictureBox2.Width
        aux = screenWidth
        aux = ancho - PictureBox2.Width - botonsiguienteprotocolo.Width - TextBoxTiempo.Width - PictureBoxECG.Width


        If TextNombre.Location.X + TextNombre.Width >= LabelRitmo.Location.X Then


            LabelRitmo.Location = New Point(TextNombre.Location.X + TextNombre.Width + 10, LabelRitmo.Location.Y)

            LabelSintoma.Location = New Point(LabelRitmo.Location.X, LabelApellido.Location.Y)
            LabelFecha.Location = New Point(LabelSintoma.Location.X, LabelDNI.Location.Y)


            TextRitmo.Location = New Point(LabelRitmo.Location.X + LabelSintoma.Width, LabelRitmo.Location.Y)
            TextSintoma.Location = New Point(LabelSintoma.Location.X + LabelSintoma.Width, LabelSintoma.Location.Y)
            txtfechaexamen.Location = New Point(TextSintoma.Location.X, LabelFecha.Location.Y)






            LabelMandantevisible.Location = New Point(LabelSintoma.Location.X, LabelEdad.Location.Y)

            LabelActuantevisible.Location = New Point(LabelSintoma.Location.X, LabelSexo.Location.Y)

            LabelTecnicovisible.Location = New Point(LabelSintoma.Location.X, LabelInternado.Location.Y)


            cbxMandante.Location = New Point(TextSintoma.Location.X, LabelMandantevisible.Location.Y)

            cbxActuante.Location = New Point(TextSintoma.Location.X, LabelActuantevisible.Location.Y)

            cbxTecnico.Location = New Point(TextSintoma.Location.X, LabelTecnicovisible.Location.Y)

            Labelmandante.Location = New Point(cbxMandante.Location.X + cbxMandante.Width + 20, LabelMandantevisible.Location.Y)

            Labelactuante.Location = New Point(cbxMandante.Location.X + cbxMandante.Width + 20, LabelActuantevisible.Location.Y)

            Labeltecnico.Location = New Point(cbxMandante.Location.X + cbxMandante.Width + 20, LabelTecnicovisible.Location.Y)



            CheckBoxMandanteExterno.Location = New Point(cbxMandante.Location.X + cbxMandante.Width + 5, cbxMandante.Location.Y)
        End If

        If Panel4.Location.X + Panel4.Width >= LabeltituloPROTO.Location.X Then


            LabeltituloPROTO.Location = New Point(Panel4.Location.X + Panel4.Width + 10, LabeltituloINTE.Location.Y)


            'ComboBoxProtocolo.Location = New Point(TextINTE3.Location.X + TextINTE3.Width + 43, LabeltituloPROTO.Location.Y + 55)
            ComboBoxProtocolo.Location = New Point(LabeltituloPROTO.Location.X, LabeltituloPROTO.Location.Y + 55)

            '  TextProtocolo.Location = New Point(TextINTE3.Location.X + TextINTE3.Width + 43, ComboBoxProtocolo.Location.Y + 35)

            TextProtocolo.Location = New Point(LabeltituloPROTO.Location.X, ComboBoxProtocolo.Location.Y + 35)


        End If


        If ListBoxeventos.Location.X + ListBoxeventos.Width >= conclusiontext.Location.X Then

            ListBoxeventos.Width = (conclusiontext.Location.X - 10) - ListBoxeventos.Location.X

        End If

    End Sub

    Private Sub tickpersonales_MouseEnter(sender As Object, e As EventArgs) Handles tickpersonales.MouseEnter
        sender.backcolor = Color.LightGray
    End Sub

    Private Sub tickpersonales_MouseLeave(sender As Object, e As EventArgs) Handles tickpersonales.MouseLeave
        If edicion_personales = True Then
            sender.backcolor = Color.LightSteelBlue
        Else
            sender.backcolor = Color.Transparent
        End If

    End Sub

    Private Sub tickprotocolo_MouseEnter(sender As Object, e As EventArgs) Handles tickprotocolo.MouseEnter
        sender.backcolor = Color.LightGray
    End Sub

    Private Sub tickprotocolo_MouseLeave(sender As Object, e As EventArgs) Handles tickprotocolo.MouseLeave

        If edicion_protocolo = True Then
            sender.backcolor = Color.LightSteelBlue
        Else
            sender.backcolor = Color.Transparent
        End If
    End Sub

    Private Sub botonsiguienteprotocolo_MouseEnter(sender As Object, e As EventArgs) Handles botonsiguienteprotocolo.MouseEnter
        sender.backcolor = Color.LightGray
    End Sub

    Private Sub botonsiguienteprotocolo_MouseLeave(sender As Object, e As EventArgs) Handles botonsiguienteprotocolo.MouseLeave
        sender.backcolor = Color.Transparent
    End Sub

    Private Sub tickprotocolo_Click(sender As Object, e As EventArgs) Handles tickprotocolo.Click

        If edicion_protocolo = False Then

            mostrar_opciones_respuestas()

            If MsgBox("Desea modificar las respuestas del interrogatorio?", MsgBoxStyle.YesNo, "Edicion") = MsgBoxResult.Yes Then

                ' MsgBox("Realice las modificaciones deseadas y una vez finalizado vuelva a oprimir el botón")

                edicion_protocolo = True
                estado_protocolo = False
                TabPreguntas.Text = "   Interrogatorio y Protocolo   "
                'tickprotocolo.BackColor = Color.WhiteSmoke

                Panel4.Enabled = True
                Panel5.Enabled = True
                Panel6.Enabled = True
                Panel7.Enabled = True
                Panel8.Enabled = True
                Panel9.Enabled = True
                Panel10.Enabled = True

                TextINTE3.Enabled = True
                TextINTE9.Enabled = True

                sender.backcolor = Color.LightSteelBlue
                Exit Sub

            Else
                Exit Sub
            End If
            Exit Sub
        End If

    End Sub

    Sub Mostrar_personal()
        Personal.Show()
    End Sub

    Sub Esconder_personal()
        Personal.Hide()
    End Sub

    Private Sub BotonCambiarServidor_Click(sender As Object, e As EventArgs) Handles BotonCambiarServidor.Click
        If MsgBox("Esta seguro que desea cambiar el servidor de la base de datos?", MsgBoxStyle.YesNo, "Cambiar Servidor") = MsgBoxResult.Yes Then
            File.WriteAllText(direccion_txt & "\conexionSQL.txt", "")
            '  FileOpen(4, direccion_txt & "conexionSQL.txt", OpenMode.Output)
            Dim nueva_conexion As String = InputBox("Ingrese el string de conexión al nuevo Servidor SQL")
            '  C:\Users\Facundo\Desktop\TiltTest-BETA- 6junio\TiltTest\bin
            File.WriteAllText(direccion_txt & "\conexionSQL.txt", nueva_conexion)
            'PrintLine(4, nueva_conexion)
            'FileClose(4)
        End If

    End Sub

    Private Sub BotonBaseDatos_Click(sender As Object, e As EventArgs) Handles BotonBaseDatos.Click

        If MsgBox("Esta seguro que desea formatear la base de datos?", MsgBoxStyle.YesNo, "Formatear base de datos") = MsgBoxResult.Yes Then

            'aca borramos todas las tablas 
            SQL.ExecQuery("DROP TABLE Examen ;")
            SQL.ExecQuery("drop table Pacientes ;")
            SQL.ExecQuery("drop table Actuantes ;")
            SQL.ExecQuery("drop table Mandantes ;")
            SQL.ExecQuery("drop table Pacientes ;")
            SQL.ExecQuery("drop table Tecnicos ;")
            SQL.ExecQuery("drop table Plantillas ;")
            SQL.ExecQuery("drop table Protocolos ;")
            SQL.ExecQuery("drop table Auxiliar ;")
            SQL.ExecQuery("drop table Usuarios ;")

            'ahora creamos todas las tablas de nuevo
            'creo la tabla examen
            SQL.ExecQuery("CREATE TABLE Examen (ID int NOT NULL IDENTITY PRIMARY KEY ," & _
                           " DNIPaciente int NOT NULL, " & _
                           "NombrePaciente nchar(30) NOT NULL," & _
                           "ApellidoPaciente nchar(30) NOT NULL," & _
                           "Fecha date NOT NULL," & _
                           "IdTecnico int NOT NULL," & _
                           "IdMandante int, " & _
                           "IdActuante int NOT NULL," & _
                           "Sintomas nchar(30)," & _
                           "Ritmo nchar(30)," & _
                           "Internado bit ," & _
                           "Datos varchar(MAX) NOT NULL," & _
                           "Tiras varchar(MAX), " & _
                           "Conclusion nvarchar(500)," & _
                           "ECG varchar(MAX), " & _
                            "MandanteExterno nchar(30) ); ")
            If SQL.HasException(True) Then Exit Sub


            'creo la tabla pacientes
            SQL.ExecQuery("CREATE TABLE Pacientes (DNI int NOT NULL PRIMARY KEY ," & _
                      "Nombre nchar(30) NOT NULL," & _
                      "Apellido nchar(30) NOT NULL," & _
                      "Edad int NOT NULL," & _
                      "Domicilio nchar(40) ," & _
                      "Telefono nchar(25), " & _
                      "Sexo bit );")
            If SQL.HasException(True) Then Exit Sub

            'creo la tabla tecnico
            SQL.ExecQuery("CREATE TABLE Tecnicos (ID int NOT NULL IDENTITY PRIMARY KEY ," & _
                           "Nombre nchar(30) NOT NULL," & _
                           "Apellido nchar(30) NOT NULL," & _
                           "Activo bit NOT NULL," & _
                           "Defecto bit NOT NULL);")
            If SQL.HasException(True) Then Exit Sub

            'creo la tabla mandante
            SQL.ExecQuery("CREATE TABLE Mandantes (ID int NOT NULL IDENTITY PRIMARY KEY ," & _
                           "Nombre nchar(30) NOT NULL," & _
                           "Apellido nchar(30) NOT NULL," & _
                           "Activo bit NOT NULL," & _
                           "Defecto bit NOT NULL);")
            If SQL.HasException(True) Then Exit Sub

            'creo la tabla actuante
            SQL.ExecQuery("CREATE TABLE Actuantes (ID int NOT NULL IDENTITY PRIMARY KEY ," & _
                           "Nombre nchar(30) NOT NULL," & _
                           "Apellido nchar(30) NOT NULL," & _
                           "Activo bit NOT NULL," & _
                           "Defecto bit NOT NULL);")
            If SQL.HasException(True) Then Exit Sub

            'creo la tabla Plantillas
            SQL.ExecQuery("CREATE TABLE Plantillas (Nombre nchar(20) NOT NULL PRIMARY KEY ," & _
                           "Texto nchar(500) ) ;")
            If SQL.HasException(True) Then Exit Sub

            'creo la tabla Protocolos
            SQL.ExecQuery("CREATE TABLE Protocolos (ID int NOT NULL IDENTITY PRIMARY KEY ," & _
                           "Nombre nchar(30) NOT NULL," & _
                           "Descripcion nchar(350) NOT NULL," & _
                                "DuracionBasal int NOT NULL," & _
                                "InclinacionBasal int NOT NULL," & _
                                 "DuracionE1 int NOT NULL," & _
                                "InclinacionE1 int NOT NULL," & _
                                 "DuracionE2 int ," & _
                                "InclinacionE2 int ," & _
                                 "DuracionE3 int ," & _
                                "InclinacionE3 int );")
            If SQL.HasException(True) Then Exit Sub

            'creo la tabla Protocolos
            SQL.ExecQuery("CREATE TABLE Auxiliar (ID int NOT NULL IDENTITY PRIMARY KEY ," & _
                           "Ruta nchar(200) NOT NULL," & _
                           "Contraseña nchar(25) NOT NULL, " & _
                           "IP nchar(20) NOT NULL);")
            If SQL.HasException(True) Then Exit Sub


            SQL.ExecQuery("CREATE TABLE Usuarios (ID int NOT NULL IDENTITY PRIMARY KEY ," & _
                          "Usuario nchar(30) NOT NULL, " & _
                          "Contraseña nchar(30) NOT NULL," & _
                          "Nivel int NOT NULL ) ;")
            If SQL.HasException(True) Then Exit Sub

            ' aca hay que poner la parte de insert into las tablas por defecto

            'aca pongo el usuario por defecto de admin 

            SQL.AddParam("@usuario", "admin")
            SQL.AddParam("@contraseña", "admin")
            SQL.AddParam("@nivel", 3)

            SQL.ExecQuery("INSERT INTO Usuarios (Usuario, Contraseña , Nivel) VALUES (@usuario, @contraseña, @nivel);")

            If SQL.HasException(True) Then Exit Sub


            'aca pongo por defecto la tabla auxiliar

            SQL.AddParam("@ruta", "C:\")
            SQL.AddParam("@contraseña", "admin")
            SQL.AddParam("@IP", "192.168.1.101")

            SQL.ExecQuery("INSERT INTO Auxiliar (Ruta , Contraseña , IP) VALUES (@ruta, @contraseña, @IP);")

            If SQL.HasException(True) Then Exit Sub


            'aca inserto el protocolo normal a la tabla correspondiente
            SQL.AddParam("@nombreprotocolo", "Normal")
            SQL.AddParam("@descripcionprotocolo", "1-Período Basal dura: 1 minutos y tiene una inclinación de: 5 grados." & vbCrLf & "2-La primera etapa dura: 30 minutos y tiene una inclinación de: 70 grados.")
            SQL.AddParam("@durbasal", 1)
            SQL.AddParam("@incbasal", 5)
            SQL.AddParam("@dure1", 15)
            SQL.AddParam("@ince1", 70)

            SQL.ExecQuery("INSERT INTO Protocolos (Nombre, Descripcion , DuracionBasal, InclinacionBasal, DuracionE1 , InclinacionE1) VALUES (@nombreprotocolo, @descripcionprotocolo, @durbasal, @incbasal, @dure1 , @ince1);")
            If SQL.HasException(True) Then Exit Sub


            SQL.AddParam("@nombreplantilla", "Positivo")
            SQL.AddParam("@textoplantilla", "Examen positivo. Sincope en el minuto:")

            SQL.ExecQuery("INSERT INTO Plantillas (Nombre, Texto) VALUES (@nombreplantilla, @textoplantilla);")


            If SQL.HasException(True) Then Exit Sub



            Loadgrilla("Tecnicos", DGVtecnicos)
            Loadcombobox(cbxTecnico, "Tecnicos")
            Loadgrilla("Mandantes", DGVmedicosman)
            Loadcombobox(cbxMandante, "Mandantes")
            Loadgrilla("Actuantes", DGVmedicosact)
            Loadcombobox(cbxActuante, "Actuantes")


            Loadgrilla("Auxiliar", DGVauxiliar)
            'CARGO LA COMBOBOX DE PLANTILLAS
            Loadcomboboxplantilla(cbxConclusiones, "Plantillas")

            'PROTOCOLOS - Y LUEGO SU COMBOBOX
            Loadgrilla("Protocolos", DGVprotocolo)
            Loadcomboboxprotocolo(ComboBoxProtocolo, "Protocolos")

            MsgBox("Se ha formateado la base de datos con exito!")

            MsgBox("Recuerde ingresar al menos un técnico y un médico actuante, de lo contrario no podrá realizar exámenes")


        End If



    End Sub


    Private Sub TextDNI_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextDNI.KeyPress
        Dim allowedChars As String = "0123456789"

        If TextEdad.Text.Length >= 9 Then
            If e.KeyChar = ControlChars.Back Then
                e.Handled = False
                Exit Sub
            End If
            e.Handled = True
            Exit Sub
        End If

        If e.KeyChar = ControlChars.Back Then
            e.Handled = False
            Exit Sub
        End If


        If allowedChars.IndexOf(e.KeyChar) = -1 Then
            ' Invalid Character
            e.Handled = True
        End If
    End Sub

    Private Sub TextTelefono_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextTelefono.KeyPress
        Dim allowedChars As String = "0123456789"

        If e.KeyChar = ControlChars.Back Then
            e.Handled = False
            Exit Sub
        End If


        If allowedChars.IndexOf(e.KeyChar) = -1 Then
            ' Invalid Character
            e.Handled = True
        End If
    End Sub

    Private Sub TextEdad_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextEdad.KeyPress
        Dim allowedChars As String = "0123456789"

        If TextEdad.Text.Length >= 3 Then
            If e.KeyChar = ControlChars.Back Then
                e.Handled = False
                Exit Sub
            End If
            e.Handled = True
            Exit Sub
        End If

        If e.KeyChar = ControlChars.Back Then
            e.Handled = False
            Exit Sub
        End If


        If allowedChars.IndexOf(e.KeyChar) = -1 Then
            ' Invalid Character
            e.Handled = True
        End If
    End Sub

    Public Sub abrir_tiras()
        'tengo que abrir los tiempo de inicio y final de cada evento y ademas fijare que tipo de evento, como asi tambien el tiempo " real"
        ' puedo guardor los datos separados por guiones y los eventos separaados por¨asteriscos

        Dim buffer() As String = tiras_aux.Split("*")
        contador_eventos = buffer.Length - 1
        eventos = ""
        For i As Integer = 0 To contador_eventos - 1
            Dim aux As String = buffer(i)
            Dim buffer_chico() As String = buffer(i).Split("-")



            inicio_evento(i) = buffer_chico(0)
            fin_evento(i) = buffer_chico(1)
            inicio_Ereloj(i) = buffer_chico(2)
            fin_Ereloj(i) = buffer_chico(3)
            stopW_eventos(0, i) = buffer_chico(4)
            stopW_eventos(1, i) = buffer_chico(5)
            Try
                stopW_eventos(2, i) = buffer_chico(7)
            Catch ex As Exception

            End Try


            tipos_eventos(i) = buffer_chico(6)

            'volver aca

            If tipos_eventos(i).Trim() = "Pre Examen" Then

                eventos = eventos & "- " & tipos_eventos(i) & vbCrLf
            Else

                eventos = eventos & "- " & tipos_eventos(i) & ": "


                If inicio_Ereloj(i).Minute() < 10 Then
                    eventos = eventos & "0" & inicio_Ereloj(i).Minute.ToString() & ":"
                Else
                    eventos = eventos & inicio_Ereloj(i).Minute.ToString() & ":"
                End If


                If inicio_Ereloj(i).Second() < 10 Then
                    eventos = eventos & "0" & inicio_Ereloj(i).Second.ToString()
                Else
                    eventos = eventos & inicio_Ereloj(i).Second.ToString()
                End If


                If fin_Ereloj(i).Minute < 10 Then
                    eventos = eventos & " / " & "0" & fin_Ereloj(i).Minute.ToString & ":"
                Else
                    eventos = eventos & " / " & fin_Ereloj(i).Minute.ToString & ":"
                End If

                If fin_Ereloj(i).Second < 10 Then
                    eventos = eventos & "0" & fin_Ereloj(i).Second.ToString & vbCrLf
                Else
                    eventos = eventos & fin_Ereloj(i).Second.ToString & vbCrLf
                End If


            End If



            'eventos = eventos & "- " & tipos_eventos(i) & ":" & inicio_Ereloj(i).Minute.ToString() & ":" & inicio_Ereloj(i).Second.ToString()

            'eventos = eventos & " / " & fin_Ereloj(i).Minute.ToString & ":" & fin_Ereloj(i).Second.ToString & vbCrLf

        Next
    End Sub


    Sub eliminar_paciente()

        Try
            Dim i As Integer = Busquedapaciente.DGVpacientes.CurrentCell.RowIndex
            Dim dni As Integer = Busquedapaciente.DGVpacientes.Item(0, i).Value
            Dim nombre As String = Busquedapaciente.DGVpacientes.Item(1, i).Value.ToString
            Dim apellido As String = Busquedapaciente.DGVpacientes.Item(2, i).Value.ToString

            SQL.AddParam("@dnipaciente", dni)
            SQL.ExecQuery("SELECT * from Examen  WHERE DNIPaciente= @dnipaciente;")
            If SQL.HasException(True) Then Exit Sub

            If SQL.DBDT.Rows.Count <> 0 Then

                MsgBox("No se puede eliminar al paciente seleccionado ya que esta asociado a un examen en la base de datos", MsgBoxStyle.Information, "Error")

                Exit Sub
            End If

            SQL.AddParam("@dnipaciente", dni)
            'Borrar_Campo(txtNombreMandante, txtApellidoMandante, DGVmedicosman, "Mandantes", cbxMandante)
            If MsgBox("Esta seguro que quiere borrar el siguiente campo?" & vbCrLf & _
                       "Nombre: " & nombre & vbCrLf & _
                       "Apellido: " & apellido, MsgBoxStyle.YesNo, "title") = MsgBoxResult.Yes Then

                SQL.ExecQuery("DELETE  from  Pacientes WHERE DNI= @dnipaciente;")

                If SQL.HasException(True) Then Exit Sub

            End If

            Loadgrilla("Pacientes", Busquedapaciente.DGVpacientes)

        Catch ex As Exception
            MsgBox("No hay ningun paciente seleccionado!", MsgBoxStyle.Exclamation, "Eliminar Paciente")
        End Try

    End Sub

    'cuando se cierra deberia escribir algo en los archivos en caso que no se haya podido guardar el examen
    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

        If estado_examen_viejo_recuperado = True Then

        End If

        If estado_examen_viejo = True Then

            escritor_general.Write("BIEN-GUARDADO")
            escritor_ecg.Write("BIEN-GUARDADO")
            escritor_evento.Write("BIEN-GUARDADO")

        End If


        'If estado_examen_ahora = True Or estado_datos = True Or estado_protocolo = True Then

        '    PrintLine(numarchivo_general, "NO TERMINADO")
        '    PrintLine(numarchivo_ECG, "NO TERMINADO")
        '    PrintLine(numarchivo_eventos, "NO TERMINADO")
        'End If

        If ventana_inicial = True Then



            Try
                escritor_general.Write("BIEN-GUARDADO")
                escritor_ecg.Write("BIEN-GUARDADO")
                escritor_evento.Write("BIEN-GUARDADO")
            Catch ex As Exception

            End Try

        End If


        'objWriter.Close()
        Try
            escritor_general.Close()
            escritor_evento.Close()
            escritor_ecg.Close()
        Catch ex As Exception

        End Try

        Try
            Enviar_INO("0")
        Catch ex As Exception

        End Try


    End Sub

    Private Sub Form1_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Login.Close()
    End Sub

    Private Sub BotonUsuarios_Click(sender As Object, e As EventArgs) Handles BotonUsuarios.Click
        Usuarios.Show()
        Usuarios.BringToFront()
        TabGeneral.SendToBack()
    End Sub

    Sub Loadgrilla_usuarios()
        SQL.ExecQuery("SELECT * FROM Usuarios;")
        If SQL.HasException(True) Then Exit Sub
        Usuarios.DGVUsuarios.DataSource = SQL.DBDT
    End Sub

    Sub ordenar_grillas_usuarios()
        Dim min As DataGridViewColumn = Usuarios.DGVUsuarios.Columns(0)
        'primero estaba en 30 ahora lo pongo en 0
        'min.Width = 30
        min.Width = 0
        min = Usuarios.DGVUsuarios.Columns(3)
        min.Width = 70

        For i As Integer = 1 To 2
            min = Usuarios.DGVUsuarios.Columns(i)
            ' min.Width = (DGVtecnicos.Width - DGVtecnicos.Columns(3).Width - DGVtecnicos.Columns(4).Width - DGVtecnicos.Columns(0).Width) / 2
            min.Width = (Usuarios.DGVUsuarios.Width - Usuarios.DGVUsuarios.Columns(0).Width - Usuarios.DGVUsuarios.Columns(3).Width) / 2
        Next

    End Sub

    'subrutina para crear un nuevo usuario, le paso el nombre, la clave y su nivel de acceso
    Sub nuevo_usuario(usuario As String, contraseña As String, nivel As Integer)
        SQL.AddParam("@usuario", usuario)
        SQL.AddParam("@contraseña", contraseña)
        SQL.AddParam("@nivel", nivel)
        SQL.ExecQuery("INSERT INTO  Usuarios (Usuario, contraseña, nivel) VALUES (@usuario, @contraseña, @nivel);")
        If SQL.HasException(True) Then Exit Sub
        MsgBox("Usuario añadido con exito!")
    End Sub
    'subrutina para eliminar un usuario, nunca se puede eliminar al usuario ADMIN
    Sub eliminar_usuario()
        Dim i As Integer = Usuarios.DGVUsuarios.CurrentCell.RowIndex
        Dim id As Integer = Usuarios.DGVUsuarios.Item(0, i).Value
        If id = 1 Then
            MsgBox("No se puede eliminar al usuario admin por defecto!")
            Exit Sub
        End If

        If MsgBox("Esta seguro que quiere borrar al siguiente usuario?:" & vbCrLf & _
                   Usuarios.DGVUsuarios.Item(1, i).Value.ToString, MsgBoxStyle.YesNo, "title") = MsgBoxResult.Yes Then

            SQL.AddParam("@id", id)
            SQL.ExecQuery("DELETE  from Usuarios WHERE Id= @id;")
            If SQL.HasException(True) Then Exit Sub
        End If

    End Sub
    'subrutina para editar usuario
    Sub editar_usuario()

        Dim i As Integer = Usuarios.DGVUsuarios.CurrentCell.RowIndex
        Dim id As Integer = Usuarios.DGVUsuarios.Item(0, i).Value
        If id = 1 Then
            MsgBox("No se puede editar al usuario admin por defecto!")
            Exit Sub
        End If

        Dim nivel_nuevo As Integer = 1
        Try
            nivel_nuevo = InputBox("Ingrese el nivel de acceso del nuevo usuario:", "Nuevo Usuario", "1")
        Catch ex As Exception
            MsgBox("El nivel debe ser un entero entre 1 y 3!")
            Exit Sub
        End Try

        If Not IsNumeric(nivel_nuevo) Or nivel_nuevo > 3 Or nivel_nuevo < 1 Then
            MsgBox("El nivel debe ser un entero entre 1 y 3!")
            Exit Sub
        End If

        Dim contraseña_nuevo As String = InputBox("Ingrese la nueva contraseña:", "Editar Usuario")

        If contraseña_nuevo = "" Then
            Exit Sub
        End If

        Dim confirmada As String = InputBox("Confirme la nueva contraseña:", "Editar Usuario")
        If confirmada = "" Then
            Exit Sub
        End If

        If contraseña_nuevo = confirmada Then

        Else
            MsgBox("Las contraseñas ingresadas no coinciden!")
            Exit Sub
        End If

        SQL.AddParam("@id", id)
        SQL.AddParam("@contraseña", contraseña_nuevo)
        SQL.AddParam("@nivel", nivel_nuevo)
        SQL.ExecQuery("UPDATE Usuarios SET Contraseña =@contraseña, Nivel=@nivel WHERE Id= @id;")
        If SQL.HasException(True) Then Exit Sub
        MsgBox("Se ha editado el usuario con éxito!")

    End Sub
    'subrutina que chequea los accesos del usuario que haya ingresado
    Sub chequear_accesos()
        If nivel_login = 1 Then

            BotonCambiarServidor.Enabled = False
            BotonCambiarServidor.Visible = False

            BotonBaseDatos.Enabled = False
            BotonBaseDatos.Visible = False

            BotonUsuarios.Enabled = False
            BotonUsuarios.Visible = False

            password.Enabled = False
            password.Visible = False

            BotonIP.Enabled = False
            BotonIP.Visible = False

        End If
    End Sub
    'evento el mouse entra al cartel de conexion
    Private Sub LabelConexionPersonales_MouseEnter(sender As Object, e As EventArgs) Handles LabelConexionPersonales.MouseEnter
        If estado_conexion = False Then
            LabelConexionPersonales.Text = "CONECTAR"
            LabelConexionPersonales.BackColor = Color.PaleGreen
        End If
    End Sub
    'evento el mouse sale al cartel de conexion
    Private Sub LabelConexionPersonales_MouseLeave(sender As Object, e As EventArgs) Handles LabelConexionPersonales.MouseLeave
        If estado_conexion = False Then
            LabelConexionPersonales.Text = "OFFLINE"
            LabelConexionPersonales.BackColor = Color.Tomato
        End If
    End Sub
    'evento click sobre el cartel de conexion
    Private Sub LabelConexionPersonales_Click(sender As Object, e As EventArgs) Handles LabelConexionPersonales.Click
        reconectar()
    End Sub


    Sub reconectar()
        If estado_conexion = False Then
            Dim auxiliar_cone As Boolean
            Me.Cursor = Cursors.WaitCursor

            Try
                auxiliar_cone = My.Computer.Network.Ping(IPadres, 2500)
            Catch ex As Exception
                MsgBox("No hay ninguna conexion de red", MsgBoxStyle.Exclamation, "Offline")
                Me.Cursor = Cursors.Default

            End Try
            Me.Cursor = Cursors.Default
            If auxiliar_cone Then
                clientSocket = New System.Net.Sockets.TcpClient()
                estado_conexion = True
                clientSocket.Connect(IPadres, 255)
                estado_conexion = True
                LabelConexionPersonales.Text = "ONLINE"
                LabelConexionPersonales.BackColor = Color.LightSteelBlue
                LabelConexionProtocolo.Text = "ONLINE"
                LabelConexionProtocolo.BackColor = Color.LightSteelBlue
                LabelConexionExamen.Text = "ONLINE"
                LabelConexionExamen.BackColor = Color.LightSteelBlue
                CNX = True
                contador_desconexion = 0
            Else
                MsgBox("No se ha podido conectar al arduino", MsgBoxStyle.Information, "SIN CONEXIÓN")
            End If
        End If
        Me.Cursor = Cursors.Default
    End Sub

    'ESTA FUNCION BUSCA ALGUIEN DEL STAFF Y LO MUESTRA EN LA GRILLA
    Public Sub Buscarexamen(busqueda As TextBox, tabla As String, grilla As DataGridView)
        If busqueda.Text = "" Then
            Loadgrilla_examen(tabla, grilla, "")
            'Busquedaexamen.Loadgrilla_examen(tabla, grilla, "")
            Exit Sub
        End If
        SQL.AddParam("@item", "%" & busqueda.Text & "%")
        'Loadgrilla_examen(tabla, grilla, "SELECT IDNpaciente, NombrePaciente, ApellidoPaciente, Fecha FROM " & tabla & " WHERE Nombre LIKE @item OR Apellido LIKE @item")
        Loadgrilla_examen(tabla, grilla, "SELECT * FROM " & tabla & " WHERE NombrePaciente LIKE @item OR ApellidoPaciente LIKE @item OR DNIPaciente LIKE @item OR Fecha LIKE @item")
    End Sub

    'subrutina para cargar los examenes a su grilla
    Public Sub Loadgrilla_examen(table As String, grid As DataGridView, Optional Query As String = "")
        If Query = "" Then
            ' SQL.ExecQuery("SELECT IDNpaciente, NombrePaciente, ApellidoPaciente, Fecha FROM " & table & ";")
            SQL.ExecQuery("SELECT * FROM " & table & ";")
        Else
            SQL.ExecQuery(Query)
        End If
        'error handling 
        If SQL.HasException(True) Then Exit Sub
        'DGVtecnicos.DataSource = SQL.DBDT
        grid.DataSource = SQL.DBDT
    End Sub
    'evento de click sobre el boton que cambia las IP
    Private Sub BotonIP_Click(sender As Object, e As EventArgs) Handles BotonIP.Click
        IP.Show()
        IP.BringToFront()
        TabGeneral.SendToBack()
    End Sub

    Sub leer_txt()
        lector_general = New StreamReader(FILE_GENERAL)
        Dim general_entero As String = lector_general.ReadToEnd()
        Dim general_separado() As String = general_entero.Split(vbCrLf)
        Dim cant_general As Integer = general_separado.Count()
        Dim aux_general As String = general_separado(cant_general - 1).Trim()

        lector_ecg = New StreamReader(FILE_ECG)
        Dim ecg_entero As String = lector_ecg.ReadToEnd()
        Dim ecg_separado() As String = ecg_entero.Split(vbCrLf)
        Dim cant_ecg As Integer = ecg_separado.Count()
        Dim aux_ecg As String = ecg_separado(cant_ecg - 1).Trim()

        lector_evento = New StreamReader(FILE_EVENTO)
        Dim evento_entero As String = lector_evento.ReadToEnd()
        Dim evento_separado() As String = evento_entero.Split(vbCrLf)
        Dim cant_evento As Integer = evento_separado.Count()
        Dim aux_evento As String = evento_separado(cant_evento - 1).Trim()

        If aux_general = "BIEN-GUARDADO" And aux_ecg = "BIEN-GUARDADO" And aux_evento = "BIEN-GUARDADO" Then
            'si se guardo bien la ultima vez, cierro el lector y abro el escritor, al abrir el escritor , queda en blanco
            lector_general.Close()
            escritor_general = New StreamWriter(FILE_GENERAL)
            lector_ecg.Close()
            escritor_ecg = New StreamWriter(FILE_ECG)
            lector_evento.Close()
            escritor_evento = New StreamWriter(FILE_EVENTO)

        Else


            lector_general.Close()
            escritor_general = New StreamWriter(FILE_GENERAL)
            lector_ecg.Close()
            escritor_ecg = New StreamWriter(FILE_ECG)
            lector_evento.Close()
            escritor_evento = New StreamWriter(FILE_EVENTO)

            If MsgBox("La aplicación se cerró por ultima vez durante un examen en curso. Desea continuar con dicho examen?", MsgBoxStyle.YesNo, "Recuperar Estudio") = MsgBoxResult.Yes Then

                'vuelvo a escribir en el txt lo que habia antes de continuar con el examen
                escritor_general.Write(general_entero)
                escritor_ecg.Write(ecg_entero)
                escritor_evento.Write(evento_entero)
                'ahora hay que abrir los datos

                recuperar_temporal_general(general_separado, cant_general)

                recuperar_temporal_ECGcrudo_Eventos(ecg_entero, cant_ecg, evento_separado, cant_evento)

            End If

        End If

    End Sub


    'subrutina que deja todo en el estado de pantalla de inicio
    Sub GO_Inicio()
        'coloco las variables de datos como deben
        ventana_inicial = True
        estado_datos = False
        estado_protocolo = False
        estado_examen_ahora = False
        estado_examen_viejo = False
        estado_examen_viejo_recuperado = False

        service_tuerca = True

        estado_mandante_externo = False
        CheckBoxMandanteExterno.Checked = False

        paciente_nuevo = False
        paciente_ingresado = False


        'hago que todos los controles sean invisibles y luego elijo a mano cuales habilitar
        For Each Control In TabPersonales.Controls
            Control.visible = False
            Control.enabled = False
        Next

        LabelTitulo.Visible = True
        PictureBox1.Visible = True
        botonbuscarexamen.Visible = True
        botonBuscarpaciente.Visible = True
        botonNuevopaciente.Visible = True
        txtfechahoy.Visible = True

        LabelTitulo.Enabled = True
        PictureBox1.Enabled = True
        botonbuscarexamen.Enabled = True
        botonBuscarpaciente.Enabled = True
        botonNuevopaciente.Enabled = True
        txtfechahoy.Enabled = True


        PictureBoxTuercaFondo.Enabled = True
        PictureBoxTuercaFondo.Visible = True

        'botonsiguiente.Visible = True
        'botonsiguiente.Enabled = False
        LabelConexionPersonales.Visible = True
        LabelConexionPersonales.Enabled = True
        'PictureBoxfondosalir.Visible = True


        'estos no deberian estar disponibles en la pantalla de inicio
        'PictureBoxSalirPaciente.Visible = True
        'PictureBoxSalirPaciente.Enabled = False


        ' PictureBoxTuercaFondo.BackColor = Color.White
        botonsiguiente.BackColor = Color.DimGray
        ' txtConexion.BackColor = Color.White
        'PictureBoxfondosalir.BackColor = Color.DimGray
        PictureBoxSalirPaciente.BackColor = Color.Transparent
        'PictureBoxTuercaFondo.BackColor = Color.LightSteelBlue
        PictureBoxTuercaFondo.BackColor = Color.Transparent

        imagenfondo.Visible = True
        hideTabs(TabGeneral)

        'detenemos el timer del ecg
        TimerEnvio.Enabled = True
        'deberiamos limpiar el display y los temporales
        Try
            limpiar_display()
        Catch ex As Exception

        End Try

        TabGeneral.SelectedIndex = 0


        cbxTecnico.DropDownStyle = ComboBoxStyle.DropDownList
        cbxMandante.DropDownStyle = ComboBoxStyle.DropDownList
        cbxActuante.DropDownStyle = ComboBoxStyle.DropDownList

        cbxTecnico.Enabled = True
        cbxActuante.Enabled = True
        cbxMandante.Enabled = True

        mostrar_opciones_respuestas()

        orden_tabulacion_inicio()
    End Sub

    Sub GO_NuevoPaciente()
        'coloco las variables de datos como deben

        TimerDisplay.Enabled = True

        ventana_inicial = False
        estado_datos = False
        estado_protocolo = False
        estado_examen_ahora = False
        estado_examen_viejo = False
        estado_examen_viejo_recuperado = False

        service_tuerca = False

        For Each Control In TabPersonales.Controls
            Control.visible = True
            Control.enabled = True
        Next

        botonbuscarexamen.Visible = False
        botonBuscarpaciente.Visible = False
        botonNuevopaciente.Visible = False
        botonbuscarexamen.Enabled = False
        botonBuscarpaciente.Enabled = False
        botonNuevopaciente.Enabled = False
        imagenfondo.Visible = False

        PictureBoxEditarPaciente.Enabled = False
        PictureBoxEditarPaciente.Visible = False


        LabelTitulo.Visible = False
        LabelTitulo.Enabled = False

        Labelmandante.Visible = False
        Labelactuante.Visible = False
        Labeltecnico.Visible = False

        tickpersonales.Visible = False

        botonsiguiente.Enabled = True
        botonsiguiente.Visible = True
        ' botonsiguiente.Location = New Point(PictureBoxSalirPaciente.Location.X + PictureBoxSalirPaciente.Width - botonsiguiente.Width, screenHeight * 0.9 - txtConexion.Height - botonsiguiente.Height)
        botonsiguiente.BackColor = Color.Transparent
        PictureBoxSalirPaciente.BackColor = Color.Transparent

        PictureBoxTuercaFondo.Visible = False
        PictureBoxTuercaFondo.Enabled = False

        MostrarTabs(TabGeneral)

        'botonECGpersonales.Enabled = True
        'botonECGpersonales.Visible = True


        'botonECGprotocolo.Enabled = True
        'botonECGprotocolo.Visible = True


        TimerEnvio.Enabled = True

        TextNombre.Enabled = True
        TextNombre.ReadOnly = False
        TextNombre.Clear()
        TextApellido.Enabled = True
        TextApellido.ReadOnly = False
        TextApellido.Clear()
        TextDNI.Enabled = True
        TextDNI.ReadOnly = False
        TextDNI.Clear()
        TextEdad.Enabled = True
        TextEdad.ReadOnly = False
        TextEdad.Clear()
        TextDomicilio.Enabled = True
        TextDomicilio.ReadOnly = False
        TextDomicilio.Clear()
        TextTelefono.Enabled = True
        TextTelefono.ReadOnly = False
        TextTelefono.Clear()
        'cbxSexo.Enabled = True
        Panelsexo.Enabled = True
        PanelINT.Enabled = True
        paciente_nuevo = True

        txtfechaexamen.Text = todaysdate


        Loadcombobox(cbxTecnico, "Tecnicos")
        Loadcombobox(cbxMandante, "Mandantes")
        Loadcombobox(cbxActuante, "Actuantes")

        sin_textos()

        TabPersonales.Text = "   Datos Paciente    "
        TextSintoma.Text = "SINCOPE"
        TextRitmo.Text = "SINUSAL"

        iconoRECpaciente.Visible = False
        iconoRecProtocolos.Visible = False
        iconoRecExamen.Visible = False

        orden_tabulacion_paciente()
    End Sub


    Sub GO_PacienteViejo()
        TimerDisplay.Enabled = True
        'coloco las variables de datos como deben
        ventana_inicial = False
        estado_datos = False
        estado_protocolo = False
        estado_examen_ahora = False
        estado_examen_viejo = False
        estado_examen_viejo_recuperado = False

        service_tuerca = False

        For Each Control In TabPersonales.Controls
            Control.visible = True
            Control.enabled = True
        Next

        botonbuscarexamen.Visible = False
        botonBuscarpaciente.Visible = False
        botonNuevopaciente.Visible = False
        botonbuscarexamen.Enabled = False
        botonBuscarpaciente.Enabled = False
        botonNuevopaciente.Enabled = False
        imagenfondo.Visible = False

        PictureBoxEditarPaciente.Enabled = True
        PictureBoxEditarPaciente.Visible = True

        Labelmandante.Visible = False
        Labelactuante.Visible = False
        Labeltecnico.Visible = False


        LabelTitulo.Visible = False
        LabelTitulo.Enabled = False

        tickpersonales.Visible = False
        ' tickprotocolo.Visible = False


        botonsiguiente.Visible = True
        ' botonsiguienteprotocolo.Visible = False
        '      botonsiguiente.Location = New Point(PictureBoxSalirPaciente.Location.X + PictureBoxSalirPaciente.Width - botonsiguiente.Width, screenHeight * 0.9 - txtConexion.Height - botonsiguiente.Height)
        botonsiguiente.BackColor = Color.Transparent
        PictureBoxSalirPaciente.BackColor = Color.Transparent

        PictureBoxTuercaFondo.Visible = False
        PictureBoxTuercaFondo.Enabled = False

        MostrarTabs(TabGeneral)


        'botonECGpersonales.Enabled = True
        'botonECGpersonales.Visible = True

        'botonECGprotocolo.Enabled = True
        'botonECGprotocolo.Visible = True


        TimerEnvio.Enabled = True




        TextNombre.Enabled = True
        TextNombre.ReadOnly = True

        TextApellido.Enabled = True
        TextApellido.ReadOnly = True

        TextDNI.Enabled = True
        TextDNI.ReadOnly = True

        TextEdad.Enabled = True
        TextEdad.ReadOnly = True

        TextDomicilio.Enabled = True
        TextDomicilio.ReadOnly = True

        TextTelefono.Enabled = True
        TextTelefono.ReadOnly = True


        Panelsexo.Enabled = False
        PanelINT.Enabled = True


        txtfechaexamen.Text = todaysdate

        sin_textos()

        Loadcombobox(cbxTecnico, "Tecnicos")
        Loadcombobox(cbxMandante, "Mandantes")
        Loadcombobox(cbxActuante, "Actuantes")

        TabPersonales.Text = "   Datos Paciente    "

        TextSintoma.Text = "SINCOPE"
        TextRitmo.Text = "SINUSAL"


        iconoRECpaciente.Visible = False
        iconoRecProtocolos.Visible = False
        iconoRecExamen.Visible = False


        orden_tabulacion_paciente()

    End Sub



    Sub limpiar_display()

        ' GFX2.FillRectangle(Brushes.CadetBlue, 0, 0, BMP2.Width, BMP2.Height)
        GFX2.FillRectangle(Brushes.MediumBlue, 0, 0, BMP2.Width, BMP2.Height)
        PictureBoxECG.Image = BMP2
        PictureBoxECGPaciente.Image = BMP2
        PictureBoxECGProtocolo.Image = BMP2
        contador_display = 0
        contador_ecg = 0
        contador_ecg2 = 0

    End Sub

    Sub sin_textos()
        TabPersonales.Text = ""
        TabPreguntas.Text = ""
        Examen.Text = ""
        Grafico.Text = ""
        TirasECG.Text = ""

    End Sub



    Private Sub PictureBoxsalirexamen_MouseEnter(sender As Object, e As EventArgs) Handles PictureBoxsalirexamen.MouseEnter
        PictureBoxsalirexamen.BackColor = Color.LightGray
    End Sub

    Private Sub PictureBoxsalirexamen_MouseLeave(sender As Object, e As EventArgs) Handles PictureBoxsalirexamen.MouseLeave
        PictureBoxsalirexamen.BackColor = Color.Transparent
    End Sub

    Private Sub PictureBoxsalirexamen_Click(sender As Object, e As EventArgs) Handles PictureBoxsalirexamen.Click
        If estado_examen_viejo = True Then
            Salir_Examen()
            'TabPersonales.BackgroundImage = Nothing

            GO_Inicio()
            Exit Sub
        End If

        If MsgBox("Esta seguro que desea salir del examena actual? Los datos no guardados se perderán.", MsgBoxStyle.YesNo, "Salir Examen") = MsgBoxResult.Yes Then
            Salir_Examen()
            'TabPersonales.BackgroundImage = Nothing

            GO_Inicio()
            'Esconder_Datos()
            'ventana_inicial = True
            'TabPersonales.BackgroundImage = New Bitmap(direccion_txt & "\fondo3.png")
        End If
    End Sub

    Sub Go_ExamenViejo()
        'coloco las variables de datos como deben
        ventana_inicial = False
        estado_datos = True
        estado_protocolo = True
        estado_examen_ahora = True
        estado_examen_viejo = True
        estado_examen_viejo_recuperado = False

        service_tuerca = False

        For Each Control In TabPersonales.Controls
            Control.visible = True
            Control.enabled = True
        Next

        TimerEnvio.Enabled = True
        TimerDisplay.Enabled = False

        botonbuscarexamen.Visible = False
        botonBuscarpaciente.Visible = False
        botonNuevopaciente.Visible = False
        botonbuscarexamen.Enabled = False
        botonBuscarpaciente.Enabled = False
        botonNuevopaciente.Enabled = False
        imagenfondo.Visible = False

        PictureBoxEditarPaciente.Enabled = False
        PictureBoxEditarPaciente.Visible = False



        CheckBoxMandanteExterno.Enabled = False


        'aca esta la parte esta
        If actividad_del_tecnico = True Then
            Labeltecnico.Visible = False
        End If

        If actividad_del_mandante = True Then
            Labelmandante.Visible = False
        End If

        If actividad_del_actuante = True Then
            Labelactuante.Visible = False

        End If


        LabelTitulo.Visible = False
        LabelTitulo.Enabled = False

        tickpersonales.Visible = False
        tickpersonales.Enabled = False


        botonsiguiente.Visible = True
        botonsiguiente.Enabled = True

        tickprotocolo.Visible = False
        tickprotocolo.Enabled = False


        botonsiguienteprotocolo.Visible = True
        botonsiguienteprotocolo.Enabled = True



        ' botonsiguienteprotocolo.Visible = False
        '      botonsiguiente.Location = New Point(PictureBoxSalirPaciente.Location.X + PictureBoxSalirPaciente.Width - botonsiguiente.Width, screenHeight * 0.9 - txtConexion.Height - botonsiguiente.Height)
        botonsiguiente.BackColor = Color.Transparent
        PictureBoxSalirPaciente.BackColor = Color.Transparent

        PictureBoxTuercaFondo.Visible = False
        PictureBoxTuercaFondo.Enabled = False

        MostrarTabs(TabGeneral)



        TimerEnvio.Enabled = True


        TextNombre.Enabled = True
        TextNombre.ReadOnly = True
        TextApellido.Enabled = True
        TextApellido.ReadOnly = True
        TextDNI.Enabled = True
        TextDNI.ReadOnly = True
        TextEdad.Enabled = True
        TextEdad.ReadOnly = True
        TextDomicilio.Enabled = True
        TextDomicilio.ReadOnly = True
        TextTelefono.Enabled = True
        TextTelefono.ReadOnly = True
        TextRitmo.Enabled = True
        TextRitmo.ReadOnly = True
        TextSintoma.Enabled = True
        TextSintoma.ReadOnly = True
        txtfechaexamen.Enabled = True
        txtfechaexamen.ReadOnly = True
        Panelsexo.Enabled = False
        PanelINT.Enabled = False

        Panel4.Enabled = False
        Panel5.Enabled = False
        Panel6.Enabled = False
        Panel7.Enabled = False
        Panel8.Enabled = False
        Panel9.Enabled = False
        Panel10.Enabled = False
        TextINTE3.Enabled = False
        TextINTE9.Enabled = False
        TextINTE3.ReadOnly = True
        TextINTE9.ReadOnly = True
        TextProtocolo.Enabled = False
        ComboBoxProtocolo.Enabled = False
        PictureBoxSalirProtocolo.Enabled = True

        botonTerminarExamen.Enabled = False
        botonSiguienteEtapa.Enabled = False

        '  IniciarExamen.Enabled = False
        botonPresion.Enabled = False
        botonModificarPresion.Enabled = False
        botonModificarPresion.Visible = False
        'botonECG.Enabled = False
        'botonECGprotocolo.Enabled = False
        'botonECGpersonales.Enabled = False

        iconoPlayPaciente.Enabled = False
        iconoPlayProtocolos.Enabled = False
        iconoPlayExamen.Enabled = False

        botonDeshacer.Enabled = False

        cbxConclusiones.Enabled = False
        '  LabelConexionPersonales.ReadOnly = True

        iconoGuardarExamen.Enabled = False
        iconoGuardarExamen.Visible = False
        botonBorrarEventos.Enabled = False
        botonEditarEvento.Enabled = False
        iconoImprimirPDF.Enabled = True
        iconoImprimirPDF.Visible = True
        DatosExamen.ReadOnly = True
        sin_textos()
        TabPersonales.Text = "   Datos Paciente " & ChrW(&H2714) & "  "
        TabPreguntas.Text = "   Interrogatorio y Protocolo " & ChrW(&H2714) & "  "
        Examen.Text = "    Examen " & ChrW(&H2714) & "  "
        Grafico.Text = "   Gráfico " & ChrW(&H2714) & "  "
        TirasECG.Text = "   Tiras y Conclusión " & ChrW(&H2714) & "  "
        cbxTecnico.Enabled = False
        cbxActuante.Enabled = False
        cbxMandante.Enabled = False
        esconder_respuestas_no_elegidas()

        iconoRECpaciente.Visible = False
        iconoRecProtocolos.Visible = False
        iconoRecExamen.Visible = False
    End Sub

    Private Sub PictureBoxsalirgrafico_Click(sender As Object, e As EventArgs) Handles PictureBoxsalirgrafico.Click
        If estado_examen_viejo = True Then
            Salir_Examen()
            'TabPersonales.BackgroundImage = Nothing

            GO_Inicio()
            Exit Sub
        End If

        If MsgBox("Esta seguro que desea salir del examena actual? Los datos no guardados se perderán.", MsgBoxStyle.YesNo, "Salir Examen") = MsgBoxResult.Yes Then
            Salir_Examen()
            'TabPersonales.BackgroundImage = Nothing

            GO_Inicio()
            'Esconder_Datos()
            'ventana_inicial = True
            'TabPersonales.BackgroundImage = New Bitmap(direccion_txt & "\fondo3.png")
        End If
    End Sub

    Private Sub PictureBoxsalirgrafico_MouseEnter(sender As Object, e As EventArgs) Handles PictureBoxsalirgrafico.MouseEnter
        PictureBoxsalirgrafico.BackColor = Color.LightGray
    End Sub

    Private Sub PictureBoxsalirgrafico_MouseLeave(sender As Object, e As EventArgs) Handles PictureBoxsalirgrafico.MouseLeave
        PictureBoxsalirgrafico.BackColor = Color.Transparent
    End Sub

    Private Sub PictureBoxsalirServicio_MouseEnter(sender As Object, e As EventArgs) Handles PictureBoxsalirServicio.MouseEnter
        sender.backcolor = Color.LightGray
    End Sub

    Private Sub PictureBoxsalirServicio_MouseLeave(sender As Object, e As EventArgs) Handles PictureBoxsalirServicio.MouseLeave
        sender.backcolor = Color.Transparent
    End Sub

    Private Sub PictureBoxsalirServicio_Click(sender As Object, e As EventArgs) Handles PictureBoxsalirServicio.Click
        TabGeneral.SelectedIndex = 0
        pass_correcta = False
        pass_correcta = False
        pass_correcta = False
        pass_correcta = False
    End Sub

    Private Sub PictureBoxsalirTiras_MouseEnter(sender As Object, e As EventArgs) Handles PictureBoxsalirTiras.MouseEnter
        sender.backcolor = Color.LightGray
    End Sub

    Private Sub PictureBoxsalirTiras_MouseLeave(sender As Object, e As EventArgs) Handles PictureBoxsalirTiras.MouseLeave
        sender.backcolor = Color.Transparent
    End Sub

    Private Sub PictureBoxsalirTiras_Click(sender As Object, e As EventArgs) Handles PictureBoxsalirTiras.Click
        If estado_examen_viejo = True Then
            Salir_Examen()
            'TabPersonales.BackgroundImage = Nothing

            GO_Inicio()
            Exit Sub
        End If

        If MsgBox("Esta seguro que desea salir del examena actual? Los datos no guardados se perderán.", MsgBoxStyle.YesNo, "Salir Examen") = MsgBoxResult.Yes Then
            Salir_Examen()
            GO_Inicio()

        End If
    End Sub

    Private Sub CheckBoxMandanteExterno_CheckStateChanged(sender As Object, e As EventArgs) Handles CheckBoxMandanteExterno.CheckStateChanged

        If sender.checked = True Then
            cbxMandante.DropDownStyle = ComboBoxStyle.Simple
            cbxMandante.Text = ""
            Labelmandante.Visible = True
            Labelmandante.Text = "*Externo"
            estado_mandante_externo = True
        End If

        If sender.checked = False Then
            cbxMandante.Text = ""
            cbxMandante.DropDownStyle = ComboBoxStyle.DropDownList
            Loadcombobox(cbxMandante, "Mandantes")
            Labelmandante.Visible = False
            Labelmandante.Text = "*este médico se encuentra inactivo"
            estado_mandante_externo = False
        End If


    End Sub

    Sub esconder_respuestas_no_elegidas()
        For Each Paneles In TabPreguntas.Controls
            If TypeOf Paneles Is Panel Then
                For Each radio In Paneles.Controls
                    If radio.checked = False Then
                        radio.visible = False
                    End If
                Next
            End If
        Next
    End Sub

    Sub mostrar_opciones_respuestas()
        For Each Paneles In TabPreguntas.Controls
            If TypeOf Paneles Is Panel Then
                For Each radio In Paneles.Controls
                    radio.visible = True
                Next
            End If
        Next
        TextINTE3.Enabled = False
        TextINTE9.Enabled = False
    End Sub

    Function revisar_dni_unico()
        SQL.AddParam("dni", TextDNI.Text)
        SQL.ExecQuery("SELECT * from Pacientes  WHERE DNI= @dni;")
        If SQL.HasException(True) Then Return False
        If SQL.DBDT.Rows.Count <> 0 Then
            MsgBox("Ya existe un paciente con ese DNI. Revise que el número sea correcto", MsgBoxStyle.Information, "Error")
            Return False
        End If
        Return True
    End Function

    Function Ingresar_medicion_presion()

        Dim aux_string As String = ingresar_sistolica()

        Dim aux_sis As Integer = Convert.ToInt32(aux_string)

        If aux_sis = 0 Then
            Return False
        End If


        aux_string = ingresar_diastolica()

        Dim aux_dia As Integer = Convert.ToInt32(aux_string)


        If aux_dia = 0 Then
            Return False
        End If


        'acotamos entre 260 y 40
        If aux_sis >= 300 Then aux_sis = 300
        If aux_dia >= 300 Then aux_dia = 300

        If aux_sis <= 20 Then aux_sis = 20
        If aux_dia <= 20 Then aux_dia = 20


        sistolica = aux_sis
        diastolica = aux_dia
        aux_dia = Nothing
        aux_sis = Nothing
        txtsistolica.Text = sistolica
        txtdiastolica.Text = diastolica
        Return True
    End Function


    Function ingresar_sistolica()
        Dim aux_sis As String
        Try
            aux_sis = InputBox("Ingrese la presión sistolica:")

            If aux_sis = "" Then
                'ingresar_sistolica()
                Return 0
                Exit Function
            End If

            If Not IsNumeric(aux_sis) Then

                aux_sis = ingresar_sistolica()
                Return aux_sis
                Exit Function
            End If

        Catch ex As Exception

            Return 0
            Exit Function
        End Try

        Return aux_sis
    End Function

    Function ingresar_diastolica()
        Dim aux_dia As String
        Try
            aux_dia = InputBox("Ingrese la presión diastolica:")

            If aux_dia = "" Then
                'ingresar_sistolica()
                Return 0
                Exit Function
            End If

            If Not IsNumeric(aux_dia) Then

                aux_dia = ingresar_diastolica()
                Return aux_dia
                Exit Function
            End If


            If aux_dia = 0 Then
                'ingresar_diastolica()
                Return aux_dia
                Exit Function
            End If
        Catch ex As Exception

            Return 0
            Exit Function
        End Try
        Return aux_dia
    End Function




    Private Sub botonBorrarEventos_Click(sender As Object, e As EventArgs) Handles botonBorrarEventos.Click
        If ListBoxeventos.SelectedIndex = -1 Then
            MsgBox("No hay ningún evento seleccionado!", MsgBoxStyle.OkOnly, "Borrar Evento")
            Exit Sub
        End If
        'primero armo un auxiliar que tiene el indice que deseo borrar
        Dim indice As Integer = ListBoxeventos.SelectedIndex

        'armar una funcion borrar y ordenar array

        inicio_Ereloj = borrar_elemento_arreglo(inicio_Ereloj, indice)
        fin_Ereloj = borrar_elemento_arreglo(fin_Ereloj, indice)

        inicio_evento = borrar_elemento_arreglo(inicio_evento, indice)
        fin_evento = borrar_elemento_arreglo(fin_evento, indice)

        stopW_eventos = borrar_elemento_arregloDoble(stopW_eventos, indice)

        Dim array_aux As String() = Split(eventos, vbCrLf)

        For k As Integer = 0 To array_aux.Length - 1
            Dim algo As String = array_aux(k)
        Next

        array_aux = borrar_elemento_arreglo(array_aux, indice)

        'For k As Integer = 0 To array_aux.Length - 1
        '    Dim algo As String = array_aux(k)
        'Next


        eventos = ""
        For j As Integer = 0 To array_aux.Length - 1

            If array_aux(j) = Nothing Then Exit For
            eventos = eventos & array_aux(j) & vbCrLf
        Next

        contador_eventos = contador_eventos - 1

        listar_eventos()


        escritor_evento.Write("BORRAR" & vbCrLf)
        escritor_evento.Write(indice & vbCrLf)
        escritor_evento.Write(indice & vbCrLf)
        escritor_evento.Write(indice & vbCrLf)
        escritor_evento.Write(indice & vbCrLf)
        escritor_evento.Write(indice & vbCrLf)
        escritor_evento.Write(indice & vbCrLf)
        escritor_evento.Write(indice & vbCrLf)
        escritor_evento.Write(indice & vbCrLf)
        escritor_evento.Write(indice & vbCrLf)


        For i As Integer = 0 To ChartEventos.Series("ECG").Points.Count - 1
            Try
                ChartEventos.Series("ECG").Points.RemoveAt(0)
            Catch ex As Exception

            End Try

        Next

        ChartEventos.ChartAreas(0).AxisX.ScaleView.Position = 0

    End Sub

    Sub borrar_evento_recuperado(indice As Integer)
        'Dim indice As Integer = ListBoxeventos.SelectedIndex

        'armar una funcion borrar y ordenar array
        '  indice = indice - 1

        inicio_Ereloj = borrar_elemento_arreglo(inicio_Ereloj, indice)
        fin_Ereloj = borrar_elemento_arreglo(fin_Ereloj, indice)

        inicio_evento = borrar_elemento_arreglo(inicio_evento, indice)
        fin_evento = borrar_elemento_arreglo(fin_evento, indice)

        arreglo_eventos_hora = borrar_elemento_arreglo(arreglo_eventos_hora, indice)


        tipos_eventos = borrar_elemento_arreglo(tipos_eventos, indice)


        'solo cambiaria esto porque ahora es un array triple
        stopW_eventos = borrar_elemento_arregloDoble(stopW_eventos, indice)

        Dim array_aux As String() = Split(eventos, vbCrLf)

        For k As Integer = 0 To array_aux.Length - 1
            Dim algo As String = array_aux(k)
        Next

        array_aux = borrar_elemento_arreglo(array_aux, indice)

        'For k As Integer = 0 To array_aux.Length - 1
        '    Dim algo As String = array_aux(k)
        'Next


        eventos = ""
        For j As Integer = 0 To array_aux.Length - 1

            If array_aux(j) = Nothing Then Exit For
            eventos = eventos & array_aux(j) & vbCrLf
        Next

        contador_eventos = contador_eventos - 1

        listar_eventos()

    End Sub





    Private Sub ListBoxeventos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBoxeventos.SelectedIndexChanged
        If sender.selectedindex = -1 Then
            botonBorrarEventos.Enabled = False
            botonEditarEvento.Enabled = False
        Else
            botonBorrarEventos.Enabled = True
            botonEditarEvento.Enabled = True
        End If
    End Sub

    ' como no se puede eliminar un pedazo, tendria que usar redim para cargarme todo el array de cero

    Function borrar_elemento_arreglo(arreglo As String(), indice As Integer) As String()
        'primero mido la longitud
        Dim l As Integer = arreglo.Length

        'Dim nuevo_arreglo As String()

        For i As Integer = indice To l - 3
            arreglo(i) = arreglo(i + 1)
        Next
        arreglo(l - 2) = Nothing

        arreglo(l - 1) = Nothing

        Return arreglo

    End Function

    Function borrar_elemento_arregloDoble(arreglo As String(,), indice As Integer) As String(,)
        'primero mido la longitud
        Dim l As Integer = arreglo.GetLength(0)

        'Dim nuevo_arreglo As String()

        'esto me parece que esta mal 


        'quiero que vaya hasta el penultimo . como el ultimo es cantidad menos uno, el penultimo es cantidad menos dos
        For i As Integer = indice To l - 2  ' esto deberia ir hasta l-2 como en el resto de los casos
            arreglo(0, i) = arreglo(0, i + 1)
            arreglo(1, i) = arreglo(1, i + 1)
            arreglo(2, i) = arreglo(2, i + 1)

        Next

        'aca tampo se porque pongo l-2 y l-1 en nothing
        'arreglo(0, l - 2) = Nothing

        'arreglo(1, l - 2) = Nothing

        'arreglo(2, l - 2) = Nothing

        arreglo(0, l - 1) = Nothing

        arreglo(1, l - 1) = Nothing

        arreglo(2, l - 1) = Nothing
        Return arreglo

    End Function


    Function borrar_elemento_arreglo(arreglo As Date(), indice As Integer) As Date()
        'primero mido la longitud
        Dim l As Integer = arreglo.Length

        For i As Integer = indice To l - 2
            arreglo(i) = arreglo(i + 1)
        Next

        arreglo(l - 1) = Nothing
        Return arreglo
    End Function

    Function borrar_elemento_arreglo(arreglo As Integer(), indice As Integer) As Integer()

        'primero mido la longitud
        Dim l As Integer = arreglo.Length

        For i As Integer = indice To l - 2
            arreglo(i) = arreglo(i + 1)
        Next

        arreglo(l - 1) = Nothing
        Return arreglo
    End Function



    Sub cargar_datos_paciente_corregido(datos As String(), indice As Integer)


        Dim Aux_dni As String = datos(indice).Trim()



        SQL.AddParam("@dni", Aux_dni)
        SQL.ExecQuery("SELECT * From Pacientes WHERE DNI=@dni;")
        If SQL.HasException(True) Then Exit Sub
        For Each r As DataRow In SQL.DBDT.Rows

            TextDNI.Text = r("DNI")
            TextNombre.Text = r("Nombre")
            TextApellido.Text = r("Apellido")
            TextEdad.Text = r("Edad")
            TextDomicilio.Text = r("Domicilio")
            TextTelefono.Text = r("Telefono")

            Dim aux_sexo As Boolean = r("Sexo")
            If aux_sexo = False Then botonMsexo.Checked = True

            If aux_sexo = True Then botonFsexo.Checked = True

            'Dim aux_internado As Boolean = r("Internado")
            'If aux_internado = False Then InternadoSI.Checked = True

            'If aux_internado = True Then InternadoNO.Checked = True



        Next

        Try
            If datos(indice + 1) = "SI" Then
                InternadoSI.Checked = True
            End If
        Catch ex As Exception
            Exit Sub
        End Try


        If datos(indice + 1) = "NO" Then
            InternadoNO.Checked = True
        End If



        TextRitmo.Text = datos(indice + 2)
        TextSintoma.Text = datos(indice + 3)
        txtfechaexamen.Text = datos(indice + 4)


        If datos(indice + 5).Trim() = "SI" Then

            CheckBoxMandanteExterno.Checked = True


            Labelmandante.Visible = True
            Labelmandante.Text = "*Externo"
        End If


        'ahora me fijo el id del staff
        Dim lista As String
        Dim aux_staff As String
        Dim aux2_staff As String


        aux_staff = datos(indice + 6).Trim()
        aux2_staff = aux_staff.Substring(0, 1)
        Dim cantidad_man As Integer = cbxMandante.Items.Count - 1
        Dim actividad_man As Boolean = False
        'aca estaba mal porque el valor maximo debe ser la cantidad de items menos uno
        For k As Integer = 0 To cantidad_man
            lista = cbxMandante.Items(k).ToString
            If lista.Substring(0, 1) = aux2_staff Then
                cbxMandante.SelectedIndex = k
                actividad_man = True
                Exit For
            End If
        Next


        If actividad_man = False Then
            cbxMandante.SelectedIndex = -1

            cbxMandante.DropDownStyle = ComboBoxStyle.Simple
            cbxMandante.Text = aux_staff
            Labelmandante.Visible = True
        End If

        aux_staff = datos(indice + 7).Trim()
        aux2_staff = aux_staff.Substring(0, 1)
        Dim cantidad_act As Integer = cbxActuante.Items.Count - 1
        Dim actividad_act As Boolean = False
        'aca estaba mal porque el valor maximo debe ser la cantidad de items menos uno
        For k As Integer = 0 To cantidad_act
            lista = cbxActuante.Items(k).ToString
            If lista.Substring(0, 1) = aux2_staff Then
                cbxActuante.SelectedIndex = k
                actividad_act = True
                Exit For
            End If
        Next

        If actividad_act = False Then
            cbxActuante.Text = aux_staff
            Labelactuante.Visible = True
        End If


        aux_staff = datos(indice + 8).Trim()
        aux2_staff = aux_staff.Substring(0, 1)
        Dim cantidad_tec As Integer = cbxTecnico.Items.Count - 1
        Dim actividad_tec As Boolean = False
        'aca estaba mal porque el valor maximo debe ser la cantidad de items menos uno
        For k As Integer = 0 To cantidad_tec
            lista = cbxTecnico.Items(k).ToString
            If lista.Substring(0, 1) = aux2_staff Then
                cbxTecnico.SelectedIndex = k
                actividad_tec = True
                Exit For
            End If
        Next

        If actividad_tec = False Then
            cbxTecnico.Text = aux_staff
            Labeltecnico.Visible = True
        End If



    End Sub

    Sub cargar_protocolo_corregidos(datos As String(), indice As Integer)
        Try
            If datos(indice).Trim() = "SI" Then INTE1SI.Checked = True
            If datos(indice).Trim() = "NO" Then INTE1NO.Checked = True
        Catch ex As Exception
            Exit Sub
        End Try

        Try
            If datos(indice + 1).Trim() = "SI" Then INTE2SI.Checked = True
            If datos(indice + 1).Trim() = "NO" Then INTE2NO.Checked = True
        Catch ex As Exception
            Exit Sub
        End Try

        Try
            If datos(indice + 1).Trim() = "NO" Then
                TextINTE3.Text = ""
            Else
                TextINTE3.Text = datos(indice + 2).Trim()
            End If
        Catch ex As Exception
            Exit Sub
        End Try



        Try
            If datos(indice + 3).Trim() = "SI" Then INTE4SI.Checked = True
            If datos(indice + 3).Trim() = "NO" Then INTE4NO.Checked = True
        Catch ex As Exception
            Exit Sub
        End Try

        Try
            If datos(indice + 4).Trim() = "SI" Then INTE5SI.Checked = True
            If datos(indice + 4).Trim() = "NO" Then INTE5NO.Checked = True
        Catch ex As Exception
            Exit Sub
        End Try

        Try
            If datos(indice + 5).Trim() = "SI" Then INTE6SI.Checked = True
            If datos(indice + 5).Trim() = "NO" Then INTE6NO.Checked = True
            If datos(indice + 5).Trim() = "NOSABE" Then INTE6NOSABE.Checked = True

        Catch ex As Exception
            Exit Sub
        End Try


        Try
            If datos(indice + 6).Trim() = "SI" Then INTE7SI.Checked = True
            If datos(indice + 6).Trim() = "NO" Then INTE7NO.Checked = True
        Catch ex As Exception
            Exit Sub
        End Try

        Try
            If datos(indice + 7).Trim() = "SI" Then INTE8SI.Checked = True
            If datos(indice + 7).Trim() = "NO" Then INTE8NO.Checked = True
        Catch ex As Exception
            Exit Sub
        End Try


        Try
            If datos(indice + 7).Trim() = "NO" Then
                TextINTE9.Text = ""
            Else
                TextINTE9.Text = datos(indice + 8).Trim()
            End If
        Catch ex As Exception
            Exit Sub
        End Try



        'falta la parte de protocolo mejorar, aunque tambien viene de lo de la tabla
        Dim aux_protocolo As String

        For k As Integer = 0 To (ComboBoxProtocolo.Items.Count - 1)

            aux_protocolo = ComboBoxProtocolo.Items(k).ToString
            Dim aux2 As String = aux_protocolo
            Dim aux3 As String = datos(indice + 9).Trim()


            If aux2 = aux3 Then
                ComboBoxProtocolo.SelectedIndex = k
                Exit For
            End If

        Next
    End Sub



    Sub cargar_fila_tabla(datos As String(), indice As Integer, indice_fila As Integer)


        ' DatosExamen.Rows.Add(lista(i), lista(i + 1), lista(i + 2), lista(i + 3), lista(i + 4))

        DatosExamen.Rows.Add(datos(indice), datos(indice + 1), datos(indice + 2), datos(indice + 3), datos(indice + 4))

        'DatosExamen.Rows(indice_fila).Cells(0).Value = datos(indice)
        'DatosExamen.Rows(indice_fila).Cells(1).Value = datos(indice + 1)

        ' DatosExamen.Rows(indice_fila).Cells(2).Value = datos(indice + 2)
        Chart1.Series("FC").Points.AddXY(datos(indice), datos(indice + 2))

        'DatosExamen.Rows(indice_fila).Cells(3).Value = datos(indice + 3)
        Chart1.Series("PS").Points.AddXY(datos(indice), datos(indice + 3))

        'DatosExamen.Rows(indice_fila).Cells(4).Value = datos(indice + 4)
        Chart1.Series("PD").Points.AddXY(datos(indice), datos(indice + 4))



    End Sub

    Sub cargar_fila_rojo(datos As String(), indice As Integer)

        Dim columna As Integer = datos(indice)
        Dim fila As Integer = datos(indice + 1)
        Dim valor As String = datos(indice + 2)
        DatosExamen.Rows(fila).Cells(columna).Value = valor

    End Sub

    'SUBRUTINA: RECUPERAR DATOS DEL ARCHIVO TEMPORAL EN TXT
    Sub recuperar_temporal_general(general_separada() As String, size_general As Integer) ', ecg_separada() As String, size_ecg As Integer, evento_separada() As String, size_evento As Integer)

        Dim contador_interno As Integer = 0
        Dim contador_fila As Integer = 0


        'estaba como size_general -2 ., pongo '1 a ver que pasa
        While contador_interno <= size_general - 2

            Select Case general_separada(contador_interno).Trim()

                Case "DATOS-PACIENTE"
                    contador_interno = contador_interno + 1
                    cargar_datos_paciente_corregido(general_separada, contador_interno)
                    contador_interno = contador_interno + 9
                    'significa que termine los datos
                    estado_datos = True



                Case "DATOS-PROTOCOLO"
                    contador_interno = contador_interno + 1
                    cargar_protocolo_corregidos(general_separada, contador_interno)
                    contador_interno = contador_interno + 10
                    'significa que termine los protocolos
                    estado_protocolo = True
                    'significa que estoy en el examen ahora mismo
                    estado_examen_ahora = True
                    estado_basal = True


                Case "DATOS-TABLA-EXAMEN"
                    contador_interno = contador_interno + 1
                    cargar_fila_tabla(general_separada, contador_interno, contador_fila)
                    contador_interno = contador_interno + 5
                    contador_fila = contador_fila + 1
                    aux_filas_datagrid = contador_fila
                    estado_examen_ahora = True
                    estado_basal = False


                Case "ROJOROJOROJO35126793"
                    contador_interno = contador_interno + 1
                    cargar_fila_rojo(general_separada, contador_interno)
                    contador_interno = contador_interno + 3
                    estado_examen_ahora = True


                Case "EXAMEN-TERMINADO-NO-GUARDADO"
                    contador_interno = contador_interno + 1
                    estado_examen_ahora = False
                    estado_examen_terminado = True

                Case Else

                    Exit Sub
            End Select


        End While

        'si esta en true significa que ya puse al menos una vez los datos del paciente, deberia seguir en protocolo
        If estado_datos = True Then estado_recuperar = "DATOS-PACIENTE-Pasado"


        'si esta en true significa que puse al menos una vez los datos del protocolo, deberia seguir en basal
        If estado_protocolo = True Then estado_recuperar = "DATOS-PROTOCOLO-Pasado"


        'si basal esta en false, significa que ya habia terminado la basal y puse al menos la fila cero en la tabla
        If estado_examen_ahora = True And estado_basal = False Then estado_recuperar = "DATOS-TABLA-EXAMEN-Pasado"


        'aca falta un if donde diga que el examen se termino pero no se guardo todavia
        If estado_examen_terminado = True Then estado_recuperar = "EXAMEN-TERMINADO-NO-GUARDADO"
        'estoy deberia ir al final una vez que esta todo recuperado
        estado_examen_viejo_recuperado = True

        Go_estado()

    End Sub

    'subrutina que se fija los estados booleanos y en base a eso me habilita cosas
    Sub Go_estado()
        'no puedo ir  a servicio desde un examen recuperado!
        service_tuerca = False
        Select Case estado_recuperar


            'si pase la primera parte es porque ya estaba para poner el protocolo
            Case "DATOS-PACIENTE-Pasado"
                Recupero_en_datos()

                'si termine protocolos siginifica que tengo que arrancar en etapa basal
            Case "DATOS-PROTOCOLO-Pasado"
                recupero_en_protocolos()

                'si termine la etapa basal y se puso al menos una linea entra aca
                'cada linea en la tabla entra a este caso
            Case "DATOS-TABLA-EXAMEN-Pasado"

                recupero_en_examen_ahora()

                'aca nunca va a entrar deberia cambiarlo
            Case "ROJOROJOROJO35126793"

            Case "EXAMEN-TERMINADO-NO-GUARDADO"

                recupero_en_examen_terminado()
            Case Else
                Exit Sub

        End Select


    End Sub

    'guarda la pestaña datos personales y se cerro cuando estaba en protocolo( osea no guarda nada del protocolo en el txt)
    'cargo lo que habia en datos y continuo en protocolo
    Sub Recupero_en_datos()

        'coloco las variables de datos como deben
        ventana_inicial = False

        'datos esta terminado
        estado_datos = True
        'protocolo todavia no se termino por lo que se pone false
        estado_protocolo = False
        estado_examen_ahora = False
        estado_examen_viejo = False
        estado_examen_viejo_recuperado = True

        'hago visible y disponible todos los controles en la ventana
        For Each Control In TabPersonales.Controls
            Control.visible = True
            Control.enabled = True
        Next

        'anulo e invisibilizo los botones de la ventana inicial
        botonbuscarexamen.Visible = False
        botonBuscarpaciente.Visible = False
        botonNuevopaciente.Visible = False
        botonbuscarexamen.Enabled = False
        botonBuscarpaciente.Enabled = False
        botonNuevopaciente.Enabled = False
        imagenfondo.Visible = False
        LabelTitulo.Visible = False
        LabelTitulo.Enabled = False


        'los visibles de estos dependen de otros parametros
        If actividad_del_mandante = True Then Labelmandante.Visible = False
        If CheckBoxMandanteExterno.Checked = True Then Labelmandante.Visible = True
        If actividad_del_actuante = True Then Labelactuante.Visible = False
        If actividad_del_tecnico = True Then Labeltecnico.Visible = False



        tickpersonales.Visible = True
        ' tickprotocolo.Visible = False

        botonsiguiente.Visible = True
        botonsiguiente.Enabled = True
        ' botonsiguienteprotocolo.Visible = False
        '      botonsiguiente.Location = New Point(PictureBoxSalirPaciente.Location.X + PictureBoxSalirPaciente.Width - botonsiguiente.Width, screenHeight * 0.9 - txtConexion.Height - botonsiguiente.Height)
        botonsiguiente.BackColor = Color.Transparent
        PictureBoxSalirPaciente.BackColor = Color.Transparent

        PictureBoxTuercaFondo.Visible = False
        PictureBoxTuercaFondo.Enabled = False

        MostrarTabs(TabGeneral)

        TimerEnvio.Enabled = True

        'habilito y pongo en read only los controles de los datos personales
        TextNombre.Enabled = True
        TextNombre.ReadOnly = True
        TextApellido.Enabled = True
        TextApellido.ReadOnly = True
        TextDNI.Enabled = True
        TextDNI.ReadOnly = True
        TextEdad.Enabled = True
        TextEdad.ReadOnly = True
        TextDomicilio.Enabled = True
        TextDomicilio.ReadOnly = True
        TextTelefono.Enabled = True
        TextTelefono.ReadOnly = True
        Panelsexo.Enabled = False
        PanelINT.Enabled = True

        sin_textos()

        'despues en tabpersonales se pone el tick
        TabPersonales.Text = "   Datos Paciente    "

        'tabpersonales me deja todo en readonly y me lleva a protocolos
        tabpersonalesterminada()

        botonsiguiente.Enabled = True
        botonsiguiente.Visible = True

        PictureBoxSalirProtocolo.Enabled = True
        paciente_ingresado = True
    End Sub


    Sub recupero_en_protocolos()
        Recupero_en_datos()

        esconder_respuestas_no_elegidas()

        protocoloterminado()
        habilitar_examen_ahora()

        Iniciar_examen_en_basal()

    End Sub

    'este no necesita demasiado
    Sub habilitar_examen_ahora()


        botonSiguienteEtapa.Enabled = True
        botonSiguienteEtapa.Visible = True
        If evento_iniciado = False Then
            ' botonECG.Enabled = True
            iconoPlayExamen.Enabled = True
        End If
        'botonECG.Enabled = True


        botonDeshacer.Enabled = False
        ' ImprimirPDF.Enabled = False
        iconoImprimirPDF.Enabled = False
        iconoImprimirPDF.Visible = False

        iconoGuardarExamen.Enabled = False
        iconoGuardarExamen.Visible = False
        botonTerminarExamen.Enabled = False

        botonSiguienteEtapa.Enabled = False
        botonSiguienteEtapa.Visible = False

        botonDeshacer.Enabled = False
        botonDeshacer.Visible = False

        estado_examen_ahora = True


    End Sub


    Sub habilitar_examen_en_standby_recuperado()

        ' IniciarExamen.Enabled = True

        If evento_iniciado = False Then
            '  botonECG.Enabled = True
            iconoPlayExamen.Enabled = True
        End If
        '  botonECG.Enabled = True
        botonDeshacer.Enabled = True



        ' si recupero post etapa basal estos deberian estar false
        botonSiguienteEtapa.Enabled = False
        botonSiguienteEtapa.Visible = False

        '   ImprimirPDF.Enabled = False
        iconoImprimirPDF.Enabled = False
        iconoImprimirPDF.Visible = False
        iconoGuardarExamen.Enabled = False
        iconoGuardarExamen.Visible = False
        estado_examen_ahora = True


        'no tengo porque obligar al operario a ingresar una medicion de presion ni bien reaunuda el examen

        '  Ingresar_medicion_presion()

        botonPresion.Enabled = True
        botonModificarPresion.Enabled = True
        botonModificarPresion.Visible = True
        '    IniciarExamen.Text = "Pausar"
        examen_iniciado = True
        estado_basal = False

        TimerReal.Enabled = True

    End Sub

    'falta enviar la inclinacion deseada
    Sub recupero_en_examen_ahora()
        recupero_en_protocolos()

        estado_basal = False
        estado_etapa1 = True
        LabelTiempo.Text = "Etapa 1:"

        'obtengo la inclinación objetivo y trato de mandarla
        inclinacion_objetivo = INC_etapa1
        Try
            Enviar_INO(inclinacion_objetivo)
        Catch ex As Exception

        End Try


        Dim cant_minuto_actual As Integer = DatosExamen.RowCount - 1

        If cant_minuto_actual > DUR_etapa1 Then
            estado_etapa1 = False
            estado_etapa2 = True
            LabelTiempo.Text = "Etapa 2:"

            'obtengo la inclinación objetivo y trato de mandarla
            inclinacion_objetivo = INC_etapa2
            Try
                Enviar_INO(inclinacion_objetivo)
            Catch ex As Exception

            End Try


        End If

        If cant_minuto_actual > DUR_etapa2 + DUR_etapa1 Then
            estado_etapa2 = False
            estado_etapa3 = True
            LabelTiempo.Text = "Etapa 3:"

            'obtengo la inclinación objetivo y trato de mandarla
            inclinacion_objetivo = INC_etapa3
            Try
                Enviar_INO(inclinacion_objetivo)
            Catch ex As Exception

            End Try

        End If



        Dim unidad_minuto_actual As Integer = cant_minuto_actual Mod 10

        Dim decena_minuto_actual As Integer = cant_minuto_actual - unidad_minuto_actual

        uniminutos = unidad_minuto_actual
        'lo tengo que dividir por diez porque despues se multiplica por diez en el timer
        decminutos = decena_minuto_actual / 10


        habilitar_examen_en_standby_recuperado()

    End Sub

    Sub recupero_en_examen_terminado()

        recupero_en_examen_ahora()

        Terminar_Examen()


    End Sub


    Sub tabpersonalesrestaurada()


        'guardo el dni con el que arranque, ya que si cambia el dni hay que borrar el paciente entero y guardar otro
        'si el dni no cambia solo hay que hacer un update
        auxiliar_dni_edicion = TextDNI.Text

        TextNombre.Enabled = True
        TextNombre.ReadOnly = False
        TextApellido.Enabled = True
        TextApellido.ReadOnly = False
        TextEdad.Enabled = True
        TextEdad.ReadOnly = False
        TextDNI.Enabled = True
        TextDNI.ReadOnly = False
        TextDomicilio.Enabled = True
        TextDomicilio.ReadOnly = False
        TextTelefono.Enabled = True
        TextTelefono.ReadOnly = False

        TextRitmo.Enabled = True
        TextRitmo.ReadOnly = False
        TextSintoma.Enabled = True
        TextSintoma.ReadOnly = False
        'fecha del examen no tiene sentido cambiar

        'txtfechaexamen.Enabled = True
        'txtfechaexamen.ReadOnly = True

        cbxMandante.Enabled = True
        cbxActuante.Enabled = True
        cbxTecnico.Enabled = True

        CheckBoxMandanteExterno.Enabled = True
        Panelsexo.Enabled = True
        PanelINT.Enabled = True


        tickpersonales.Visible = True

        'botonsiguiente.Enabled = False
        'botonsiguiente.Visible = False


        TabPersonales.Text = "   Datos Paciente   "

        ' TabPersonales.Text = "   Datos Paciente " & ChrW(&H2714) & "  

        edicion_personales = True

    End Sub


    Private Sub tickpersonales_Click(sender As Object, e As EventArgs) Handles tickpersonales.Click

        If edicion_personales = False Then

            If MsgBox("Desea modificar los datos personales?", MsgBoxStyle.YesNo, "Editar") = MsgBoxResult.Yes Then



                'llamar subrutina que hace eso

                tabpersonalesrestaurada()
                sender.backcolor = Color.LightSteelBlue
                estado_datos = False
                Exit Sub
            Else
                Exit Sub

            End If
        End If

        'If edicion_personales = True Then


        '    tabpersonales_editada()

        'End If


    End Sub

    Sub tabpersonales_editada()

        If String.IsNullOrWhiteSpace(TextNombre.Text) Or String.IsNullOrWhiteSpace(TextApellido.Text) Or String.IsNullOrWhiteSpace(TextEdad.Text) Or String.IsNullOrWhiteSpace(TextDNI.Text) Or String.IsNullOrWhiteSpace(cbxTecnico.Text) Or String.IsNullOrWhiteSpace(cbxActuante.Text) Or String.IsNullOrWhiteSpace(cbxMandante.Text) Then

            MsgBox("No se puede iniciar el estudio" & vbCrLf & "1-Los datos Nombre, Apellido , Edad y DNI son obligatorios!" & vbCrLf & "2-Debe seleccionar técnico y médicos! ", MsgBoxStyle.Exclamation, "Imposible iniciar examen")
            Exit Sub
        End If

        'si el dni no cambio solo tengo que updatear el resto en la tabla paciente

        If auxiliar_dni_edicion = TextDNI.Text Then

            Dim aux_sexo As String = ""
            Dim bool_sex As Boolean
            If botonMsexo.Checked = True Then
                aux_sexo = "Masculino"
                bool_sex = True
            End If

            If botonFsexo.Checked = True Then
                aux_sexo = "Femenino"
                bool_sex = False
            End If



            TextNombre.ReadOnly = True
            TextApellido.ReadOnly = True
            TextEdad.ReadOnly = True
            TextDomicilio.ReadOnly = True
            TextTelefono.ReadOnly = True
            TextDNI.ReadOnly = True

            Panelsexo.Enabled = False
            PanelINT.Enabled = False

            TextRitmo.ReadOnly = True
            TextSintoma.ReadOnly = True

            cbxActuante.Enabled = False
            cbxMandante.Enabled = False
            cbxTecnico.Enabled = False

            CheckBoxMandanteExterno.Enabled = False

            SQL.AddParam("@dni", TextDNI.Text)
            SQL.AddParam("@nombre", TextNombre.Text)
            SQL.AddParam("@apellido", TextApellido.Text)
            SQL.AddParam("@edad", TextEdad.Text)
            SQL.AddParam("@sexo", bool_sex)
            SQL.AddParam("@domicilio", TextDomicilio.Text)
            SQL.AddParam("@telefono", TextTelefono.Text)

            SQL.ExecQuery("UPDATE Pacientes SET Nombre =@nombre, Apellido=@apellido , Edad=@edad, Sexo=@sexo, Domicilio=@domicilio, Telefono=@telefono WHERE DNI= @dni;")
            If SQL.HasException(True) Then Exit Sub

            'hasta aca se updateo el paciente en caso que no haya cambiado el dni
            escritor_general.Write("DATOS-PACIENTE" & vbCrLf)
            escritor_general.Write(TextDNI.Text & vbCrLf)

            If (InternadoSI.Checked = True) Then


                escritor_general.Write("SI" & vbCrLf)
            Else

                If (InternadoNO.Checked = True) Then


                    escritor_general.Write("NO" & vbCrLf)
                Else


                    escritor_general.Write("" & vbCrLf)
                End If

            End If

            'ahora guardo ritmo de base, sintomas de ingreso y el staff


            escritor_general.Write(TextRitmo.Text & vbCrLf)
            escritor_general.Write(TextSintoma.Text & vbCrLf)
            escritor_general.Write(txtfechaexamen.Text & vbCrLf)

            If estado_mandante_externo = True Then
                escritor_general.Write("SI" & vbCrLf)
            Else
                escritor_general.Write("NO" & vbCrLf)
            End If

            escritor_general.Write(cbxMandante.Text & vbCrLf)
            escritor_general.Write(cbxActuante.Text & vbCrLf)
            escritor_general.Write(cbxTecnico.Text & vbCrLf)

            estado_recuperar = "DATOS-PACIENTE-Pasado"



            '  TabPersonales.Text = "   Datos Paciente " & ChrW(&H2714) & "  "
            MsgBox("Edición exitosa!", MsgBoxStyle.OkOnly, "Editar Datos Personales")
            tickpersonales.BackColor = Color.Transparent
            ' TabGeneral.SelectedIndex = 1
            tabpersonalesterminada()
            edicion_personales = False
            Exit Sub

        Else
            'si el dni cambio tengo que borrar el paciente y hacer uno nuevo


            Dim dni As Integer = auxiliar_dni_edicion

            SQL.AddParam("@dnipaciente", dni)


            SQL.ExecQuery("DELETE  from  Pacientes WHERE DNI= @dnipaciente;")
            If SQL.HasException(True) Then Exit Sub

            Dim aux_sex2 As String = ""
            If botonMsexo.Checked = True Then aux_sex2 = "M" 'antes decia Masculino entero
            If botonFsexo.Checked = True Then aux_sex2 = "F" 'antes decia femenino entero

            'ahora inserto el nuevo paciente
            InsertarPaciente(TextNombre, TextApellido, TextEdad, TextDomicilio, TextTelefono, TextDNI, aux_sex2)



            SQL.AddParam("dnipaciente", dni)
            SQL.AddParam("dniNUEVO", TextDNI.Text)

            SQL.ExecQuery("UPDATE EXAMEN SET DNIPaciente = @dniNUEVO WHERE DNIPaciente = @dnipaciente")
            If SQL.HasException(True) Then Exit Sub


            paciente_ingresado = True

            TextNombre.ReadOnly = True
            TextApellido.ReadOnly = True
            TextEdad.ReadOnly = True
            TextDomicilio.ReadOnly = True
            TextTelefono.ReadOnly = True
            TextDNI.ReadOnly = True

            Panelsexo.Enabled = False
            PanelINT.Enabled = False

            TextRitmo.ReadOnly = True
            TextSintoma.ReadOnly = True

            cbxActuante.Enabled = False
            cbxMandante.Enabled = False
            cbxTecnico.Enabled = False

            CheckBoxMandanteExterno.Enabled = False

            escritor_general.Write("DATOS-PACIENTE" & vbCrLf)
            escritor_general.Write(TextDNI.Text & vbCrLf)


            If (InternadoSI.Checked = True) Then


                escritor_general.Write("SI" & vbCrLf)
            Else

                If (InternadoNO.Checked = True) Then

                    escritor_general.Write("NO" & vbCrLf)
                Else


                    escritor_general.Write("" & vbCrLf)
                End If

            End If

            'ahora guardo ritmo de base, sintomas de ingreso y el staff
            escritor_general.Write(TextRitmo.Text & vbCrLf)
            escritor_general.Write(TextSintoma.Text & vbCrLf)
            escritor_general.Write(txtfechaexamen.Text & vbCrLf)
            escritor_general.Write(cbxMandante.Text & vbCrLf)
            escritor_general.Write(cbxActuante.Text & vbCrLf)
            escritor_general.Write(cbxTecnico.Text & vbCrLf)

            estado_recuperar = "DATOS-PACIENTE-Pasado"



            '  TabPersonales.Text = "   Datos Paciente " & ChrW(&H2714) & "  "
            MsgBox("Edición exitosa!", MsgBoxStyle.OkOnly, "Editar Datos Personales")
            tickpersonales.BackColor = Color.Transparent

            ' TabGeneral.SelectedIndex = 1
            tabpersonalesterminada()
            edicion_personales = False
        End If

    End Sub


    Sub recuperar_temporal_ECGcrudo_Eventos(ecg_entero As String, size_ecg As Integer, eventos_separado() As String, size_eventos As Integer)

        'hasta aca la parte de ecg estaría bien
        aux_datos_ecg = ""
        aux_datos_ecg = ecg_entero
        contador_ecg = size_ecg - 1

        contador_eventos = 0
        eventos = ""
        ' falta lo de abrir eventos que es medio largo pero se puede hacer, fijarse en la parte de borrar 
        For i As Integer = 0 To size_eventos - 2 Step 10

            'si tengo que borrar un evento
            If eventos_separado(i).Trim() = "BORRAR" Then
                borrar_evento_recuperado(eventos_separado(i + 1))


            Else

                Dim stri_aux As String
                Try
                    stri_aux = eventos_separado(i).Trim().Substring(0, 3)

                Catch ex As Exception
                    stri_aux = "MAaaLLL"
                End Try
                'Dim stri_aux As String = eventos_separado(i).Trim().Substring(0, 3)
                'si tengo que editar un evento
                If stri_aux = "EDI" Then

                    Dim aux_indice As String = eventos_separado(i).Trim().Substring(15)
                    'aca llamar a editar_evento_recuperado()
                    'editar_evento_recuperado(aux_indice)


                    inicio_evento(aux_indice) = eventos_separado(i + 1)
                    fin_evento(aux_indice) = eventos_separado(i + 2)

                    arreglo_eventos_hora(aux_indice) = eventos_separado(i + 3)


                    'eventos = eventos & eventos_separado(i + 3) & vbCrLf

                    eventos = ""
                    For k As Integer = 0 To contador_eventos - 1 '(arreglo_eventos_hora.Count - 1)
                        eventos = eventos & arreglo_eventos_hora(k) & vbCrLf
                    Next



                    stopW_eventos(0, aux_indice) = eventos_separado(i + 4)
                    stopW_eventos(1, aux_indice) = eventos_separado(i + 5)

                    '   stopW_eventos(2, contador_eventos - 1) = eje_temporal(contador_eventos - 1)

                    stopW_eventos(2, aux_indice) = eventos_separado(i + 6)

                    inicio_Ereloj(aux_indice) = eventos_separado(i + 7) ' antes 6
                    fin_Ereloj(aux_indice) = eventos_separado(i + 8) ' antes 7

                    tipos_eventos(aux_indice) = eventos_separado(i + 9)


                Else

                    contador_eventos = contador_eventos + 1

                    inicio_evento(contador_eventos - 1) = eventos_separado(i + 1)
                    fin_evento(contador_eventos - 1) = eventos_separado(i + 2)

                    arreglo_eventos_hora(contador_eventos - 1) = eventos_separado(i + 3)
                    eventos = eventos & eventos_separado(i + 3) & vbCrLf

                    stopW_eventos(0, contador_eventos - 1) = eventos_separado(i + 4)
                    stopW_eventos(1, contador_eventos - 1) = eventos_separado(i + 5)

                    '   stopW_eventos(2, contador_eventos - 1) = eje_temporal(contador_eventos - 1)

                    stopW_eventos(2, contador_eventos - 1) = eventos_separado(i + 6)

                    inicio_Ereloj(contador_eventos - 1) = eventos_separado(i + 7) ' antes 6
                    fin_Ereloj(contador_eventos - 1) = eventos_separado(i + 8) ' antes 7

                    tipos_eventos(contador_eventos - 1) = eventos_separado(i + 9)
                End If

            End If


        Next

        listar_eventos()

    End Sub
    'CON EL MISMO BOTON LLAMO A INICIAR RECUPERACION O TERMINAR EXAMEN
    Private Sub botonTerminarExamen_Click(sender As Object, e As EventArgs) Handles botonTerminarExamen.Click
        'SI ESTABA EL EXAMEN EN PROGRESO , INICIO RECUPERACION
        If estado_recuperacion = False Then
            Iniciar_recuperacion()
            Exit Sub
        End If
        'SI YA ESTABA EN RECUPERACIÓN , TERMINO EL EXAMEN
        If estado_examen_ahora = True Then
            Terminar_Examen()
        End If
    End Sub

    'ESTA SUBRUTINA FINALIZA EL EXAMEN ACTUAL LUEGO DE LA RECUPERACION
    Sub Terminar_Examen()

        'PRIMERO ENVIAR INCLINACION CERO AL ARDUINO - EN CASO DE NO PODER COMUNICARSE CON EL ARDUINO LE AVISA AL USUARIO QUE BAJE MANUAL
        inclinacion_objetivo = 0
        Try
            Enviar_INO(inclinacion_objetivo)
        Catch ex As Exception
            MsgBox("Fallo en comunicación. Bajar la camilla de manera manual.")
        End Try

        'SE TERMINO EL ESTADO DE RECUPERACION
        estado_recuperacion = False
        'DESHABILITO Y PONGO INVISIBLE LOS BOTONES DE PRESION
        botonPresion.Enabled = False
        botonModificarPresion.Enabled = False
        botonModificarPresion.Visible = False

        'DESHABILITO Y PONGO INVISIBLE LOS ICONOS PARA GRABAR EVENTOS
        iconoPlayPaciente.Enabled = False
        iconoPlayProtocolos.Enabled = False
        iconoPlayExamen.Enabled = False

        ' IniciarExamen.Enabled = False
        'INDICO EN LAS LABELS DE LAS PESTANAS QUE ESTAN TERMINADAS
        Examen.Text = "    Examen " & ChrW(&H2714) & "  "
        Grafico.Text = "   Gráfico " & ChrW(&H2714) & "  "
        TirasECG.Text = "   Tiras y Conclusión " & ChrW(&H2714) & "  "
        'DETENGO EL TIMER DEL TIEMPO
        TimerReal.Enabled = False
        'HABILITO BOTON PARA IMPRIMIR PDF
        iconoImprimirPDF.Enabled = True
        iconoImprimirPDF.Visible = True
        'HABILITO BOTON PARA GUARDAR EXAMEN
        iconoGuardarExamen.Enabled = True
        iconoGuardarExamen.Visible = True
        'INDICO ESTADO DE EXAMEN TERMINADO
        estado_examen_terminado = True
        'INDICO EXAMEN TERMINADO EN ARCHIVO DE RECUPERACION
        escritor_general.Write("EXAMEN-TERMINADO-NO-GUARDADO" & vbCrLf)
        escritor_general.Write("EXAMEN-TERMINADO-NO-GUARDADO" & vbCrLf)
        'INDICO QUE EL EXAMEN YA NO ESTA SIENDO LLEVADO A CABO
        estado_examen_ahora = False
        'DESHABILITO LOS BOTONES PARA TERMINAR EXAMEN
        botonTerminarExamen.Enabled = False
        botonTerminarExamen.Visible = False
        'CAMBIO SU LABEL NUEVAMENTE A "TERMINAR EXAMEN"
        botonTerminarExamen.Text = "Terminar Examen"
    End Sub
    'SUBRUTINA QUE INICIA LA ETAPA DE RECUPERACION DEL EXAMEN, PREVIO A TERMINARSE
    Sub Iniciar_recuperacion()
        'INDICO EL ESTADO RECUPERACION COMO VERDADERO
        estado_recuperacion = True
        estado_basal = False
        estado_etapa1 = False
        estado_etapa2 = False
        estado_etapa3 = False

        'PRIMERO ENVIAR INCLINACION CERO AL ARDUINO, EN CASO DE FALLA LE AVISA AL USUARIO Y SOLICITA QUE SE BAJE DE FORMA MANUAL
        inclinacion_objetivo = 0
        Try
            Enviar_INO(inclinacion_objetivo)
        Catch ex As Exception
            MsgBox("Fallo en comunicación. Bajar la camilla de manera manual.")
        End Try
        'CAMBIA EL LABEL DEL BOTON A TERMINAR RECUPERACION
        botonTerminarExamen.Text = "Terminar Recuperación"
        'CAMBIA LABEL ENCIMA DEL TIMER REAL
        LabelTiempo.Text = "Recuperación:"
        'guardo en el minuto en que ocurrio el sincope
        minuto_sincope = decminutos * 10 + uniminutos + 1
        'REINICIO EL CLOCK, TANTO SUS VARIABLES COMO EL TEXTBOX QUE LO MUESTRA
        unisegundos = 0
        decsegundos = 0
        uniminutos = 0
        decminutos = 0
        TextBoxTiempo.Text = decminutos & uniminutos & ":" & decsegundos & unisegundos


        PS(aux_filas_datagrid) = sistolica
        PD(aux_filas_datagrid) = diastolica
        INC(aux_filas_datagrid) = inclinacion_objetivo
        'SI NO HAY DATO DE FC , SE GUARDA UN CERO
        Try
            FC(aux_filas_datagrid) = txtFC.Text
        Catch ex As Exception
            FC(aux_filas_datagrid) = 0
        End Try
        'este va a ser el minuto cero, deberia decir BASAL en lugar de cero, probamos

        'Try
        'tiempo(aux_filas_datagrid) = "RECUPERACION"
        'Catch ex As Exception
        tiempo(aux_filas_datagrid) = 0
        'End Try


        ' Chart1.Series("FC").Points(tiempo(aux_filas_datagrid) + minuto_sincope).AxisLabel = "SINCOPE"

        'INSERTO UNA FILA EN EL DATAGRID QUE INDIQUE QUE LA RECUPERACION A INICIADO
        'LUEGO LOS INGRESO EN EL CHART1 LO QUE VA AL PDF

        Chart1.Series("FC").Points.AddXY(tiempo(aux_filas_datagrid) + minuto_sincope, FC(aux_filas_datagrid))
        Chart1.Series("PS").Points.AddXY(tiempo(aux_filas_datagrid) + minuto_sincope, PS(aux_filas_datagrid))
        Chart1.Series("PD").Points.AddXY(tiempo(aux_filas_datagrid) + minuto_sincope, PD(aux_filas_datagrid))
        Chart1.Series("IN").Points.AddXY(tiempo(aux_filas_datagrid) + minuto_sincope, INC(aux_filas_datagrid))

        ' Chart1.Series("FC").Points(tiempo(aux_filas_datagrid) + minuto_sincope).AxisLabel = (tiempo(aux_filas_datagrid) + minuto_sincope) & vbCrLf & "SINCOPE/RECUPERACION"
        Chart1.Series("FC").Points(tiempo(aux_filas_datagrid) + minuto_sincope).AxisLabel = "SINCOPE/RECUPERACION"


        Try
            tiempo(aux_filas_datagrid) = "RECUPERACION"
        Catch ex As Exception
            tiempo(aux_filas_datagrid) = 0
        End Try


        'GUARDO LOS DATOS EN UNA FILA DEL DATAGRID
        DatosExamen.Rows.Add(tiempo(aux_filas_datagrid), "RECUPERACION", FC(aux_filas_datagrid), PS(aux_filas_datagrid), PD(aux_filas_datagrid))
        ' DatosExamen.Rows.Add(tiempo(aux_filas_datagrid), "RECUPERACION", "", "", "")
        'contador = contador + 1
        'GUARDO LOS DATOS EN EL ARCHIVO DE RECUPERACION
        escritor_general.Write("DATOS-TABLA-EXAMEN" & vbCrLf)
        escritor_general.Write(DatosExamen.Rows(0).Cells(0).Value.ToString() & vbCrLf)
        escritor_general.Write(DatosExamen.Rows(0).Cells(1).Value.ToString() & vbCrLf)
        escritor_general.Write(DatosExamen.Rows(0).Cells(2).Value.ToString() & vbCrLf)
        escritor_general.Write(DatosExamen.Rows(0).Cells(3).Value.ToString() & vbCrLf)
        escritor_general.Write(DatosExamen.Rows(0).Cells(4).Value.ToString() & vbCrLf)
        'INCREMENTO EL AUXILIAR QUE ENUMERA LAS FILAS



        aux_filas_datagrid = aux_filas_datagrid + 1

    End Sub


    Private Sub LabelConexionProtocolo_MouseEnter(sender As Object, e As EventArgs) Handles LabelConexionProtocolo.MouseEnter
        If estado_conexion = False Then
            sender.Text = "CONECTAR"
            sender.BackColor = Color.PaleGreen
        End If
    End Sub

    Private Sub LabelConexionProtocolo_MouseLeave(sender As Object, e As EventArgs) Handles LabelConexionProtocolo.MouseLeave
        If estado_conexion = False Then
            sender.Text = "OFFLINE"
            sender.BackColor = Color.Tomato
        End If
    End Sub



    Private Sub LabelConexionProtocolo_Click(sender As Object, e As EventArgs) Handles LabelConexionProtocolo.Click
        reconectar()
    End Sub

    Private Sub botonSiguienteEtapa_Click(sender As Object, e As EventArgs) Handles botonSiguienteEtapa.Click
        'LA SUBRUTINA TERMINA LA ETAPA BASAL Y ARRANCA LA ETAPA 1
        terminar_basal()
    End Sub

    'SUBRUTINA QUE TERMINA LA ETAPA BASAL E INICIA LA ETAPA 1
    Sub terminar_basal()
        'SI NO SE INGRESO NINGUNA MEDICION DE PRESION, LE PIDE AL USUARIO QUE LA INGRESE
        If diastolica = 0 Or sistolica = 0 Then
            If Ingresar_medicion_presion() = False Then Exit Sub
        End If
        'SI HABIA UN EVENTO INICIADO LO FINALIZA, PARA EVITAR HORARIOS DE INICIO Y FIN SIN SENTIDO
        If evento_iniciado = True Then
            Iniciar_terminar_eventos()
        End If

        'COMPRUEBO QUE LA VARIABLE ESTADO_BASAL ERA VERDADERA
        If estado_basal = True Then
            'INDICO QUE SE TERMINO ESA ETAPA Y SE INICIO LA ETAPA 1
            estado_basal = False
            estado_etapa1 = True
            'ACTUALIZO LA INCLINACION OBJETIVO A LA DE LA ETAPA 1
            inclinacion_objetivo = INC_etapa1
            'AQUI TERMINA LA ETAPA BASAL POR LO QUE DEBO GUARDAR LAS MEDICIONES EN LA TABLA
            'AGREGO LOS VALORES INGRESADOS POR EL USUARIO A LOS VECTORES DE PRESION
            PS(aux_filas_datagrid) = sistolica
            PD(aux_filas_datagrid) = diastolica
            'SI NO HAY DATO DE FC , SE GUARDA UN CERO
            Try
                FC(aux_filas_datagrid) = txtFC.Text
            Catch ex As Exception
                FC(aux_filas_datagrid) = 0
            End Try
            'este va a ser el minuto cero, deberia decir BASAL en lugar de cero, probamos
            Try
                tiempo(aux_filas_datagrid) = "BASAL"
            Catch ex As Exception
                tiempo(aux_filas_datagrid) = 0
            End Try

            'LUEGO LOS INGRESO EN EL CHART1 LO QUE VA AL PDF
            Chart1.Series("FC").Points.AddXY(tiempo(aux_filas_datagrid), FC(aux_filas_datagrid))
            Chart1.Series("PS").Points.AddXY(tiempo(aux_filas_datagrid), PS(aux_filas_datagrid))
            Chart1.Series("PD").Points.AddXY(tiempo(aux_filas_datagrid), PD(aux_filas_datagrid))
            Chart1.Series("IN").Points.AddXY(tiempo(aux_filas_datagrid), INC(aux_filas_datagrid))
            'GUARDO LOS DATOS EN UNA FILA DEL DATAGRID
            DatosExamen.Rows.Add(tiempo(aux_filas_datagrid), "", FC(aux_filas_datagrid), PS(aux_filas_datagrid), PD(aux_filas_datagrid))
            'contador = contador + 1
            'GUARDO LOS DATOS EN EL ARCHIVO DE RECUPERACION
            escritor_general.Write("DATOS-TABLA-EXAMEN" & vbCrLf)
            escritor_general.Write(DatosExamen.Rows(0).Cells(0).Value.ToString() & vbCrLf)
            escritor_general.Write(DatosExamen.Rows(0).Cells(1).Value.ToString() & vbCrLf)
            escritor_general.Write(DatosExamen.Rows(0).Cells(2).Value.ToString() & vbCrLf)
            escritor_general.Write(DatosExamen.Rows(0).Cells(3).Value.ToString() & vbCrLf)
            escritor_general.Write(DatosExamen.Rows(0).Cells(4).Value.ToString() & vbCrLf)
            'INCREMENTO EL AUXILIAR QUE ENUMERA LAS FILAS
            aux_filas_datagrid = aux_filas_datagrid + 1
            'ENVIO AL ARDUINO LA INCLINACION OBJETIVO
            Try
                Enviar_INO(inclinacion_objetivo)
            Catch ex As Exception
                MsgBox("Fallo en comunicación. Subir/Bajar la camilla de manera manual.")
            End Try
            'CAMBIO EL TEXTO DEL CLOCK A ETAPA 1
            LabelTiempo.Text = "Etapa 1:"
            'REINICIO EL CLOCK
            unisegundos = 0
            decsegundos = 0
            uniminutos = 0
            decminutos = 0
            'ACTUALIZO EL TEXBOX QUE MUESTRA EL TIEMPO
            TextBoxTiempo.Text = decminutos & uniminutos & ":" & decsegundos & unisegundos
            'HABILITO EL BOTON DESHACER
            botonDeshacer.Enabled = True
            botonDeshacer.Visible = True
            'DESHABILITO EL BOTON SIGUIENTE ETAPA
            botonSiguienteEtapa.Enabled = False
            botonSiguienteEtapa.Visible = False
            'HABILITO BOTON TERMINAR EXAMEN, QUE PRIMERO EJECUTARIA INICIAR RECUPERACION
            botonTerminarExamen.Enabled = True
            botonTerminarExamen.Visible = True
        End If
    End Sub


    Private Sub PictureBoxEditarPaciente_Click(sender As Object, e As EventArgs) Handles PictureBoxEditarPaciente.Click


        If estado_editando_paciente_viejo = False Then

            MsgBox("Actualize los datos del paciente", MsgBoxStyle.Information, "Tilt Test")

            tabpersonalesrestaurada()

            tickpersonales.Visible = False
            'tickpersonales.Enabled = False

            botonsiguiente.Enabled = True
            botonsiguiente.Visible = True

            estado_datos = False
            edicion_personales = False

            estado_editando_paciente_viejo = True

            sender.backcolor = Color.LightSteelBlue

            Exit Sub
        End If


    End Sub

    Private Sub PictureBoxEditarPaciente_MouseEnter(sender As Object, e As EventArgs) Handles PictureBoxEditarPaciente.MouseEnter
        sender.backcolor = Color.LightGray
    End Sub

    Private Sub PictureBoxEditarPaciente_MouseLeave(sender As Object, e As EventArgs) Handles PictureBoxEditarPaciente.MouseLeave

        If estado_editando_paciente_viejo = True Then

            sender.backcolor = Color.LightSteelBlue
        Else
            sender.backcolor = Color.Transparent
        End If


    End Sub

    Private Sub PictureBoxSalirPaciente_MouseHover(sender As Object, e As EventArgs) Handles PictureBoxSalirPaciente.MouseHover
        ToolTip1.SetToolTip(sender, "Salir")
    End Sub

    Private Sub PictureBoxTuercaFondo_MouseHover(sender As Object, e As EventArgs) Handles PictureBoxTuercaFondo.MouseHover
        ToolTip1.SetToolTip(sender, "Configuración")
    End Sub

    Private Sub PictureBoxEditarPaciente_MouseHover(sender As Object, e As EventArgs) Handles PictureBoxEditarPaciente.MouseHover
        ToolTip1.SetToolTip(sender, "Editar Pestaña")
    End Sub

    Private Sub tickpersonales_MouseHover(sender As Object, e As EventArgs) Handles tickpersonales.MouseHover
        ToolTip1.SetToolTip(sender, "Editar Pestaña")
    End Sub

    Private Sub PictureBoxSalirProtocolo_MouseHover(sender As Object, e As EventArgs) Handles PictureBoxSalirProtocolo.MouseHover
        ToolTip1.SetToolTip(sender, "Salir")
    End Sub

    Private Sub tickprotocolo_MouseHover(sender As Object, e As EventArgs) Handles tickprotocolo.MouseHover
        ToolTip1.SetToolTip(sender, "Editar Pestaña")
    End Sub

    Private Sub botonsiguienteprotocolo_MouseHover(sender As Object, e As EventArgs) Handles botonsiguienteprotocolo.MouseHover
        ToolTip1.SetToolTip(sender, "Siguiente")
    End Sub

    Private Sub botonsiguiente_MouseHover(sender As Object, e As EventArgs) Handles botonsiguiente.MouseHover
        ToolTip1.SetToolTip(sender, "Siguiente")
    End Sub

    Private Sub PictureBoxsalirexamen_MouseHover(sender As Object, e As EventArgs) Handles PictureBoxsalirexamen.MouseHover
        ToolTip1.SetToolTip(sender, "Salir")
    End Sub

    Private Sub PictureBoxsalirgrafico_MouseHover(sender As Object, e As EventArgs) Handles PictureBoxsalirgrafico.MouseHover
        ToolTip1.SetToolTip(sender, "Salir")
    End Sub

    Private Sub PictureBoxsalirTiras_MouseHover(sender As Object, e As EventArgs) Handles PictureBoxsalirTiras.MouseHover
        ToolTip1.SetToolTip(sender, "Salir")
    End Sub

    Private Sub LabelConexionExamen_MouseEnter(sender As Object, e As EventArgs) Handles LabelConexionExamen.MouseEnter
        If estado_conexion = False Then
            sender.Text = "CONECTAR"
            sender.BackColor = Color.PaleGreen
        End If
    End Sub

    Private Sub LabelConexionExamen_MouseLeave(sender As Object, e As EventArgs) Handles LabelConexionExamen.MouseLeave
        If estado_conexion = False Then
            sender.Text = "OFFLINE"
            sender.BackColor = Color.Tomato
        End If
    End Sub



    Private Sub LabelConexionExamen_Click(sender As Object, e As EventArgs) Handles LabelConexionExamen.Click
        reconectar()
    End Sub

    Sub guardar_edicion_paciente()

        If String.IsNullOrWhiteSpace(TextNombre.Text) Or String.IsNullOrWhiteSpace(TextApellido.Text) Or String.IsNullOrWhiteSpace(TextEdad.Text) Or String.IsNullOrWhiteSpace(TextDNI.Text) Or String.IsNullOrWhiteSpace(cbxTecnico.Text) Or String.IsNullOrWhiteSpace(cbxActuante.Text) Or String.IsNullOrWhiteSpace(cbxMandante.Text) Then

            MsgBox("No se puede iniciar el estudio" & vbCrLf & "1-Los datos Nombre, Apellido , Edad y DNI son obligatorios!" & vbCrLf & "2-Debe seleccionar técnico y médicos! ", MsgBoxStyle.OkOnly, "Imposible iniciar examen")
            Exit Sub
        End If

        'si el dni no cambio solo tengo que updatear el resto en la tabla paciente

        If auxiliar_dni_edicion = TextDNI.Text Then

            Dim aux_sexo As String = ""
            Dim bool_sex As Boolean
            If botonMsexo.Checked = True Then
                aux_sexo = "Masculino"
                bool_sex = True
            End If

            If botonFsexo.Checked = True Then
                aux_sexo = "Femenino"
                bool_sex = False
            End If



            TextNombre.ReadOnly = True
            TextApellido.ReadOnly = True
            TextEdad.ReadOnly = True
            TextDomicilio.ReadOnly = True
            TextTelefono.ReadOnly = True
            TextDNI.ReadOnly = True

            Panelsexo.Enabled = False
            PanelINT.Enabled = False





            SQL.AddParam("@dni", TextDNI.Text)
            SQL.AddParam("@nombre", TextNombre.Text)
            SQL.AddParam("@apellido", TextApellido.Text)
            SQL.AddParam("@edad", TextEdad.Text)
            SQL.AddParam("@sexo", bool_sex)
            SQL.AddParam("@domicilio", TextDomicilio.Text)
            SQL.AddParam("@telefono", TextTelefono.Text)

            SQL.ExecQuery("UPDATE Pacientes SET Nombre =@nombre, Apellido=@apellido , Edad=@edad, Sexo=@sexo, Domicilio=@domicilio, Telefono=@telefono WHERE DNI= @dni;")
            If SQL.HasException(True) Then Exit Sub




            estado_editando_paciente_viejo = False
            PictureBoxEditarPaciente.BackColor = Color.Transparent
            MsgBox("Datos actualizados", MsgBoxStyle.Information, "Tilt Test")
            Exit Sub

        Else
            'si el dni cambio tengo que borrar el paciente y hacer uno nuevo


            Dim dni As Integer = auxiliar_dni_edicion

            SQL.AddParam("@dnipaciente", dni)


            SQL.ExecQuery("DELETE  from  Pacientes WHERE DNI= @dnipaciente;")
            If SQL.HasException(True) Then Exit Sub

            Dim aux_sex2 As String = ""
            If botonMsexo.Checked = True Then aux_sex2 = "M" 'antes decia Masculino entero
            If botonFsexo.Checked = True Then aux_sex2 = "F" 'antes decia femenino entero

            'ahora inserto el nuevo paciente
            InsertarPaciente(TextNombre, TextApellido, TextEdad, TextDomicilio, TextTelefono, TextDNI, aux_sex2)

            paciente_ingresado = True


            estado_editando_paciente_viejo = False

            'Dim dni As Integer = auxiliar_dni_edicion
            SQL.AddParam("dnipaciente", dni)
            SQL.AddParam("dniNUEVO", TextDNI.Text)

            SQL.ExecQuery("UPDATE EXAMEN SET DNIPaciente = @dniNUEVO WHERE DNIPaciente = @dnipaciente")
            If SQL.HasException(True) Then Exit Sub

            PictureBoxEditarPaciente.BackColor = Color.Transparent
        End If
    End Sub


    Private Sub TabGeneral_Selecting(sender As Object, e As TabControlCancelEventArgs) Handles TabGeneral.Selecting

        Dim actual As Integer = pestaña_actual
        Dim proxima As Integer = e.TabPageIndex

        If proxima = 5 Then
            If service_tuerca = False Then
                pestaña_actual = actual
                sender.selectedindex = actual


                Exit Sub
            Else
                pestaña_actual = proxima
                Exit Sub
            End If
        End If


        If actual = 0 Then
            If estado_datos = False Then
                pestaña_actual = actual
                sender.selectedindex = actual
                Exit Sub
            Else
                pestaña_actual = proxima

            End If
        End If




        If actual = 1 Then

            If estado_protocolo = False Then

                If proxima > actual Then
                    pestaña_actual = actual
                    sender.selectedindex = actual
                    Exit Sub
                Else
                    pestaña_actual = proxima

                End If
            End If
        End If

        If proxima > 1 Then

            If estado_datos = True And estado_protocolo = True Then
                pestaña_actual = proxima
                Exit Sub
            Else
                pestaña_actual = actual
                sender.selectedindex = actual
                Exit Sub
            End If
        End If

        pestaña_actual = proxima
    End Sub


    Sub tabprotocoloseditada()

        protocoloterminado()


        escritor_general.Write("DATOS-PROTOCOLO" & vbCrLf)

        If INTE1SI.Checked = True Then
            escritor_general.Write("SI" & vbCrLf)
        Else
            escritor_general.Write("NO" & vbCrLf)
        End If

        If INTE2SI.Checked = True Then

            escritor_general.Write("SI" & vbCrLf)
        Else


            escritor_general.Write("NO" & vbCrLf)
        End If

        escritor_general.Write(TextINTE3.Text & vbCrLf)

        If INTE4SI.Checked = True Then

            escritor_general.Write("SI" & vbCrLf)
        Else

            escritor_general.Write("NO" & vbCrLf)
        End If

        If INTE5SI.Checked = True Then

            escritor_general.Write("SI" & vbCrLf)
        Else

            escritor_general.Write("NO" & vbCrLf)
        End If

        If INTE6SI.Checked = True Then

            escritor_general.Write("SI" & vbCrLf)
        Else
            If INTE6NO.Checked = True Then

                escritor_general.Write("NO" & vbCrLf)

            Else

                escritor_general.Write("NOSABE" & vbCrLf)

            End If
        End If

        If INTE7SI.Checked = True Then

            escritor_general.Write("SI" & vbCrLf)
        Else

            escritor_general.Write("NO" & vbCrLf)
        End If

        If INTE8SI.Checked = True Then

            escritor_general.Write("SI" & vbCrLf)
        Else
            escritor_general.Write("NO" & vbCrLf)
        End If


        escritor_general.Write(TextINTE9.Text & vbCrLf)




        escritor_general.Write(ComboBoxProtocolo.Text & vbCrLf)




        esconder_respuestas_no_elegidas()

        MsgBox("Edición exitosa!", MsgBoxStyle.OkOnly, "Editar Interrogatorio")

        edicion_protocolo = False
        estado_protocolo = True
        tickprotocolo.BackColor = Color.Transparent

    End Sub

    Private Sub botonAnteriorProtocolo_MouseEnter(sender As Object, e As EventArgs) Handles botonAnteriorProtocolo.MouseEnter
        sender.backcolor = Color.LightGray
        ToolTip1.SetToolTip(sender, "Anterior")
    End Sub

    Private Sub botonAnteriorProtocolo_MouseLeave(sender As Object, e As EventArgs) Handles botonAnteriorProtocolo.MouseLeave
        sender.backcolor = Color.Transparent
    End Sub

    Private Sub botonAnteriorProtocolo_Click(sender As Object, e As EventArgs) Handles botonAnteriorProtocolo.Click
        TabGeneral.SelectedIndex = 0
    End Sub

    Private Sub botonsiguienteExamen_MouseEnter(sender As Object, e As EventArgs) Handles botonsiguienteExamen.MouseEnter
        sender.backcolor = Color.LightGray
        ToolTip1.SetToolTip(sender, "Siguiente")
    End Sub

    Private Sub botonsiguienteExamen_MouseLeave(sender As Object, e As EventArgs) Handles botonsiguienteExamen.MouseLeave
        sender.backcolor = Color.Transparent
    End Sub

    Private Sub botonsiguienteExamen_Click(sender As Object, e As EventArgs) Handles botonsiguienteExamen.Click
        TabGeneral.SelectedIndex = 3
    End Sub

    Private Sub botonanteriorExamen_MouseEnter(sender As Object, e As EventArgs) Handles botonanteriorExamen.MouseEnter
        sender.backcolor = Color.LightGray
        ToolTip1.SetToolTip(sender, "Anterior")
    End Sub

    Private Sub botonanteriorExamen_MouseLeave(sender As Object, e As EventArgs) Handles botonanteriorExamen.MouseLeave
        sender.backcolor = Color.Transparent
    End Sub

    Private Sub botonanteriorExamen_Click(sender As Object, e As EventArgs) Handles botonanteriorExamen.Click
        TabGeneral.SelectedIndex = 1
    End Sub

    Private Sub botonsiguienteGrafico_MouseEnter(sender As Object, e As EventArgs) Handles botonsiguienteGrafico.MouseEnter
        sender.backcolor = Color.LightGray
        ToolTip1.SetToolTip(sender, "Siguiente")
    End Sub

    Private Sub botonsiguienteGrafico_MouseLeave(sender As Object, e As EventArgs) Handles botonsiguienteGrafico.MouseLeave
        sender.backcolor = Color.Transparent
    End Sub

    Private Sub botonsiguienteGrafico_Click(sender As Object, e As EventArgs) Handles botonsiguienteGrafico.Click
        TabGeneral.SelectedIndex = 4
    End Sub

    Private Sub botonanteriorGrafico_MouseEnter(sender As Object, e As EventArgs) Handles botonanteriorGrafico.MouseEnter
        sender.backcolor = Color.LightGray
        ToolTip1.SetToolTip(sender, "Anterior")
    End Sub

    Private Sub botonanteriorGrafico_MouseLeave(sender As Object, e As EventArgs) Handles botonanteriorGrafico.MouseLeave
        sender.backcolor = Color.Transparent
    End Sub

    Private Sub botonanteriorGrafico_Click(sender As Object, e As EventArgs) Handles botonanteriorGrafico.Click
        TabGeneral.SelectedIndex = 2
    End Sub

    Private Sub PictureBox7_MouseEnter(sender As Object, e As EventArgs) Handles botonanteriorConclusion.MouseEnter
        sender.backcolor = Color.LightGray
        ToolTip1.SetToolTip(sender, "Anterior")
    End Sub

    Private Sub PictureBox7_MouseLeave(sender As Object, e As EventArgs) Handles botonanteriorConclusion.MouseLeave
        sender.backcolor = Color.Transparent
    End Sub

    Private Sub botonanteriorConclusion_Click(sender As Object, e As EventArgs) Handles botonanteriorConclusion.Click
        TabGeneral.SelectedIndex = 3
    End Sub


    'timer NUEVA FC se activa cada 100 mseg 
    Private Sub TimerRecepcion_Tick(sender As Object, e As EventArgs) Handles TimerRecepcion.Tick

        If evento_iniciado = True Then
            If iconoPlayPaciente.Enabled = False Or iconoPlayProtocolos.Enabled = False Or iconoPlayExamen.Enabled = False Then

                Try

                    If reloj_global.ElapsedMilliseconds() > tiempo_inicio_evento + 5000 Then
                        'botonECG.Enabled = True
                        'botonECGprotocolo.Enabled = True
                        'botonECGpersonales.Enabled = True

                        iconoPlayPaciente.Enabled = True
                        iconoPlayProtocolos.Enabled = True
                        iconoPlayExamen.Enabled = True

                    End If
                Catch ex As Exception
                    MsgBox("no conto evento")
                End Try



            End If
        End If

        RecibirDatos()

        '  contador_eje_temporal = contador_eje_temporal + 1

    End Sub




    Sub RecibirDatos()


        If estado_conexion = False Then
            Dim algo As String = ""
        End If

        Try
            'creo la instancia de un stream para la comunicación
            Dim serverStream As NetworkStream = clientSocket.GetStream()
            'flush limpia lo que queda en el stream para dejarlo en limpio para recibir data 
            serverStream.Flush()




            If (serverStream.DataAvailable) Then
                Dim inStream(1000) As Byte
                'serverStream.Read(inStream, 0, clientSocket.ReceiveBufferSize)
                serverStream.Read(inStream, 0, 1000)
                Dim returndata As String = System.Text.Encoding.ASCII.GetString(inStream)
                Dim splitpaquetes() As String = returndata.Split("_")
                Dim cantpaquetes As Integer = splitpaquetes.Length

                CNX = True
                contador_desconexion = 0


                For k As Integer = 0 To cantpaquetes - 1
                    If (splitpaquetes(k) = "") Then
                    Else
                        Dim data() As String = splitpaquetes(k).Split("*")
                        Dim cantdata As Integer = data.Length

                        ' si me llego dato de ecg--------------------------------------
                        If (data(0) = "ECG") Then


                            For i As Integer = 1 To cantdata - 1
                                If (data(i) = "" Or data(i) = " ") Then



                                Else
                                    ' si no estoy en la ventana inicial tengo que guardar en el txt e imprimir en pantalla, guardarlo en la 
                                    'global y aumentar el contador
                                    If ventana_inicial = False Then

                                        'actualizar_display_2(data(i))
                                        Dim aux As Integer = data(i)

                                        buffer_ECG.Enqueue(aux)
                                        'buffer_ECG.Enqueue(1023 - aux)


                                        aux_datos_ecg = aux_datos_ecg & data(i) & vbCrLf
                                        contador_ECG_nuevo = contador_ECG_nuevo + 1

                                        'aca guardo el ecg en el .txt
                                        escritor_ecg.Write(data(i) & vbCrLf)

                                        'ACA PONGO UNO A UNO 
                                        ' cant_buffer = cantdata / 1
                                        cant_buffer = cantdata - 1
                                    End If
                                End If
                            Next

                        End If


                        'ReDim Preserve arreglo_eje(contador_eje_temporal)
                        'arreglo_eje(contador_eje_temporal) = contador_ECG_nuevo
                        'contador_eje_temporal = contador_eje_temporal + 1



                        'arreglo_eje(contador_eje_temporal) = contador_ECG_nuevo

                        'SI ME LLEGO DATO DE FRECUENCIA CARDIACA
                        If (data(0) = "FCI") Then



                            If (data(1) = "" Or data(1) = " " Or data(1) = " ") Then
                            Else
                                txtFC.Text = data(1)
                            End If
                        End If


                        'SI ME LLEGO DATO DE FRECUENCIA CARDIACA
                        If (data(0) = "INA") Then


                            If (data(1) = "" Or data(1) = " ") Then

                            Else
                                txtinclinacion.Text = data(1)
                            End If
                        End If
                    End If
                Next

            Else




            End If

            'promedio_por_paquete = 0
            'For j As Integer = 0 To arreglo_eje.Count - 1
            '    promedio_por_paquete = promedio_por_paquete + arreglo_eje(j)
            'Next

            'promedio_por_paquete = promedio_por_paquete / arreglo_eje.Count

            cant_buffer = buffer_ECG.Count

            serverStream.Flush()

        Catch ex As Exception



            'If ventana_inicial = False And estado_conexion = False And CNX = False Then

            '    Dim data() As Integer = cuadrada
            '    'actualizar_display_2(data(i))

            '    For i As Integer = 0 To 25
            '        Dim aux As Integer = data(i) / 10
            '        ' buffer_ECG.Enqueue(aux)


            '        actualizar_display_2(aux)

            '        aux_datos_ecg = aux_datos_ecg & aux & vbCrLf
            '        contador_ECG_nuevo = contador_ECG_nuevo + 1

            '        'aca guardo el ecg en el .txt
            '        escritor_ecg.Write(aux & vbCrLf)

            '        'cant_buffer = 50 / 5
            '    Next
            'End If


            '        CNX = True


        End Try

    End Sub

    Private Sub TimerDisplay_Tick(sender As Object, e As EventArgs) Handles TimerDisplay.Tick

        'LOGICA DE LO QUE SE SEGUN EVENTO INICIADO O NO
        If evento_iniciado = True Then

            If rec_visible = False Then

                rec_visible = True
                iconoRECpaciente.Visible = rec_visible
                iconoRecProtocolos.Visible = rec_visible
                iconoRecExamen.Visible = rec_visible
            Else
                rec_visible = False
                iconoRECpaciente.Visible = rec_visible
                iconoRecProtocolos.Visible = rec_visible
                iconoRecExamen.Visible = rec_visible
            End If

        Else
            rec_visible = False
            iconoRECpaciente.Visible = rec_visible
            iconoRecProtocolos.Visible = rec_visible
            iconoRecExamen.Visible = rec_visible

        End If
        '--------------------------------------------------

        ' cant_buffer = buffer_ECG.Count

        Try
            For j As Integer = 0 To (cant_buffer / 3)

                LabelPacienteDesconectado.Visible = False
                LabelPacientedesconectadoprotocolo.Visible = False
                LabelPacientedesconectadoExamen.Visible = False

                actualizar_display_2(buffer_ECG.Dequeue)

            Next
        Catch ex As Exception

            If ventana_inicial = False And estado_conexion = False And CNX = False Then

                If bul_display_mayor = False Then


                    If bul_display = False Then


                        Dim data() As Integer = cuadrada
                        'actualizar_display_2(data(i))

                        For i As Integer = 0 To 6
                            Dim aux As Integer = data(i) / 4
                            ' buffer_ECG.Enqueue(aux)


                            If evento_iniciado = True Then
                                pincel_cuadrada.Color = Color.Tomato
                                actualizar_display_varios(aux, pincel_cuadrada)
                            Else
                                pincel_cuadrada.Color = Color.GreenYellow
                                actualizar_display_varios(aux, pincel_cuadrada)
                            End If

                            actualizar_display_varios(aux, pincel_cuadrada)

                            aux_datos_ecg = aux_datos_ecg & aux & vbCrLf
                            contador_ECG_nuevo = contador_ECG_nuevo + 1

                            'aca guardo el ecg en el .txt
                            escritor_ecg.Write(aux & vbCrLf)

                            'cant_buffer = 50 / 5
                        Next

                        bul_display = True

                    Else

                        LabelPacienteDesconectado.Visible = True
                        LabelPacientedesconectadoprotocolo.Visible = True
                        LabelPacientedesconectadoExamen.Visible = True

                        Dim data() As Integer = cuadrada
                        For i As Integer = 12 To 18
                            Dim aux As Integer = data(i) / 4
                            ' buffer_ECG.Enqueue(aux)


                            If evento_iniciado = True Then
                                pincel_cuadrada.Color = Color.Tomato
                                actualizar_display_varios(aux, pincel_cuadrada)
                            Else
                                pincel_cuadrada.Color = Color.GreenYellow
                                actualizar_display_varios(aux, pincel_cuadrada)
                            End If

                            actualizar_display_varios(aux, pincel_cuadrada)

                            aux_datos_ecg = aux_datos_ecg & aux & vbCrLf
                            contador_ECG_nuevo = contador_ECG_nuevo + 1

                            'aca guardo el ecg en el .txt
                            escritor_ecg.Write(aux & vbCrLf)

                            'cant_buffer = 50 / 5

                        Next
                        bul_display = False
                    End If
                    bul_display_mayor = True
                Else


                    If bul_display_2 = False Then


                        Dim data() As Integer = cuadrada
                        'actualizar_display_2(data(i))

                        For i As Integer = 7 To 11
                            Dim aux As Integer = data(i) / 4
                            ' buffer_ECG.Enqueue(aux)


                            If evento_iniciado = True Then
                                pincel_cuadrada.Color = Color.Tomato
                                actualizar_display_varios(aux, pincel_cuadrada)
                            Else
                                pincel_cuadrada.Color = Color.GreenYellow
                                actualizar_display_varios(aux, pincel_cuadrada)
                            End If

                            actualizar_display_varios(aux, pincel_cuadrada)

                            aux_datos_ecg = aux_datos_ecg & aux & vbCrLf
                            contador_ECG_nuevo = contador_ECG_nuevo + 1

                            'aca guardo el ecg en el .txt
                            escritor_ecg.Write(aux & vbCrLf)

                            'cant_buffer = 50 / 5
                        Next

                        bul_display_2 = True

                    Else
                        Dim data() As Integer = cuadrada
                        For i As Integer = 18 To 25
                            Dim aux As Integer = data(i) / 4
                            ' buffer_ECG.Enqueue(aux)


                            If evento_iniciado = True Then
                                pincel_cuadrada.Color = Color.Tomato
                                actualizar_display_varios(aux, pincel_cuadrada)
                            Else
                                pincel_cuadrada.Color = Color.GreenYellow
                                actualizar_display_varios(aux, pincel_cuadrada)
                            End If

                            actualizar_display_varios(aux, pincel_cuadrada)

                            aux_datos_ecg = aux_datos_ecg & aux & vbCrLf
                            contador_ECG_nuevo = contador_ECG_nuevo + 1

                            'aca guardo el ecg en el .txt
                            escritor_ecg.Write(aux & vbCrLf)

                            'cant_buffer = 50 / 5

                        Next
                        bul_display_2 = False
                    End If







                    bul_display_mayor = False
                End If


            End If

        End Try


    End Sub



    Function eje_temporal(indice As Integer)
        Dim inicio As Long = Convert.ToInt64(stopW_eventos(0, indice))
        Dim final As Long = Convert.ToInt64(stopW_eventos(1, indice))
        Dim ini_conta As Integer = inicio_evento(indice)
        Dim fin_conta As Integer = fin_evento(indice)
        Dim duracion As Long = final - inicio
        Dim paso As Long = duracion / (fin_conta - ini_conta)
        Return paso
    End Function

    Private Sub botonEditarEvento_Click(sender As Object, e As EventArgs) Handles botonEditarEvento.Click

        If ListBoxeventos.SelectedIndex = -1 Then
            MsgBox("No hay ningún evento seleccionado!", MsgBoxStyle.Exclamation, "Editar Evento")
            Exit Sub
        End If

        '  ChartEventos.ChartAreas(0).CursorX.IsUserEnabled = True

        ChartEventos.ChartAreas(0).CursorX.IsUserSelectionEnabled = True

        botonCancelarEdicionEvento.Visible = True
        botonCancelarEdicionEvento.Enabled = True

        Dim indice As Integer = ListBoxeventos.SelectedIndex
        'Dim paso As Integer = eje_temporal(indice)
        Dim paso As Integer = stopW_eventos(2, indice)

        Dim minutos As Integer = 0
        Dim segundos As Integer = 0
        Dim horas As Date

        If editando_eventos = False Then

            'If tipos_eventos(indice).Trim() = "Pre Examen" Then


            '    contador_eventos_editados = contador_eventos_editados + 1
            '    'el nuevo inicio es el inicio del evento viejo mas el valor del scroll
            '    backup_editados(0, contador_eventos_editados - 1) = indice
            '    eventos_editados(0, contador_eventos_editados - 1) = indice

            '    backup_editados(1, contador_eventos_editados - 1) = inicio_evento(indice)
            '    eventos_editados(1, contador_eventos_editados - 1) = inicio_evento(indice) + scrollecg.Value + Punto_entero 'punto_chart.XValue

            '    backup_editados(2, contador_eventos_editados - 1) = inicio_Ereloj(indice)
            '    eventos_editados(2, contador_eventos_editados - 1) = inicio_Ereloj(indice)


            '    ListBoxeventos.Enabled = False

            '    sender.text = "Finalizar"
            '    editando_eventos = True
            '    Exit Sub

            'Else


            '    contador_eventos_editados = contador_eventos_editados + 1
            '    'el nuevo inicio es el inicio del evento viejo mas el valor del scroll
            '    backup_editados(0, contador_eventos_editados - 1) = indice
            '    eventos_editados(0, contador_eventos_editados - 1) = indice

            '    backup_editados(1, contador_eventos_editados - 1) = inicio_evento(indice)
            '    eventos_editados(1, contador_eventos_editados - 1) = inicio_evento(indice) + scrollecg.Value + Punto_entero 'punto_chart.XValue

            '    'tiempo transcurrido en segundos
            '    Dim diferencia_inicio As Single = ((eventos_editados(1, contador_eventos_editados - 1) - inicio_evento(indice)) * paso) / 1000

            '    backup_editados(2, contador_eventos_editados - 1) = inicio_Ereloj(indice)

            '    horas = inicio_Ereloj(indice)


            '    minutos = Floor(diferencia_inicio / 60)
            '    segundos = diferencia_inicio Mod 60
            '    horas = horas.AddMinutes(minutos)
            '    horas = horas.AddSeconds(segundos)
            '    eventos_editados(2, contador_eventos_editados - 1) = horas

            '    ListBoxeventos.Enabled = False

            '    sender.text = "Finalizar"
            '    editando_eventos = True

            '    Exit Sub

            ' End If

            ListBoxeventos.Enabled = False

            sender.text = "Finalizar"
            editando_eventos = True

            Exit Sub
        End If


        If editando_eventos = True Then



            If tipos_eventos(indice).Trim() = "Pre Examen" Then

                contador_eventos_editados = contador_eventos_editados + 1

                backup_editados(0, contador_eventos_editados - 1) = indice
                backup_editados(1, contador_eventos_editados - 1) = inicio_evento(indice)
                backup_editados(2, contador_eventos_editados - 1) = inicio_Ereloj(indice)

                '   If inicio_evento(indice) + scrollecg.Value + Punto_entero <= eventos_editados(1, contador_eventos_editados - 1) Then Exit Sub
                backup_editados(3, contador_eventos_editados - 1) = fin_evento(indice)
                ' eventos_editados(3, contador_eventos_editados - 1) = inicio_evento(indice) + scrollecg.Value + Punto_entero 'punto_chart.XValue
                backup_editados(4, contador_eventos_editados - 1) = fin_Ereloj(indice)
                ' eventos_editados(4, contador_eventos_editados - 1) = fin_Ereloj(indice)

                ListBoxeventos.Enabled = True

                editando_eventos = False
                sender.text = "Editar Evento"

                '------------------------------
                inicio_evento(indice) = ChartEventos.ChartAreas(0).CursorX.SelectionStart       'eventos_editados(1, contador_eventos_editados - 1)
                inicio_Ereloj(indice) = inicio_Ereloj(indice)
                fin_evento(indice) = ChartEventos.ChartAreas(0).CursorX.SelectionEnd ' eventos_editados(3, contador_eventos_editados - 1)
                fin_Ereloj(indice) = fin_Ereloj(indice)

                Dim aux_array() As String = Split(eventos, vbCrLf)

                aux_array(indice) = "- " & tipos_eventos(indice).Trim() & ": "

                If (inicio_Ereloj(indice).Minute) < 10 Then
                    aux_array(indice) = aux_array(indice) & "0" & inicio_Ereloj(indice).Minute.ToString() & ":"
                Else
                    aux_array(indice) = aux_array(indice) & inicio_Ereloj(indice).Minute.ToString() & ":"
                End If

                If (inicio_Ereloj(indice).Second) < 10 Then
                    aux_array(indice) = aux_array(indice) & "0" & inicio_Ereloj(indice).Second.ToString()
                Else
                    aux_array(indice) = aux_array(indice) & inicio_Ereloj(indice).Second.ToString()
                End If

                If (fin_Ereloj(indice).Minute) < 10 Then
                    aux_array(indice) = aux_array(indice) & " / 0" & inicio_Ereloj(indice).Minute.ToString() & ":"
                Else
                    aux_array(indice) = aux_array(indice) & " / " & inicio_Ereloj(indice).Minute.ToString() & ":"
                End If

                If (fin_Ereloj(indice).Second) < 10 Then
                    aux_array(indice) = aux_array(indice) & "0" & fin_Ereloj(indice).Second.ToString()
                Else
                    aux_array(indice) = aux_array(indice) & fin_Ereloj(indice).Second.ToString()
                End If


                eventos = ""
                For i As Integer = 0 To (aux_array.Count - 2)
                    eventos = eventos & aux_array(i) & vbCrLf
                Next


                'aca deberia tocar el array
                arreglo_eventos_hora(indice) = aux_array(indice)

                listar_eventos()

                Mostrar_ventana(indice)

                botonCancelarEdicionEvento.Visible = False
                botonCancelarEdicionEvento.Enabled = False
                ChartEventos.ChartAreas(0).CursorX.SelectionStart = 0
                ChartEventos.ChartAreas(0).CursorX.SelectionEnd = 0
                ChartEventos.ChartAreas(0).CursorX.Position = 0

                ChartEventos.ChartAreas(0).CursorX.SetCursorPosition(0)
                ChartEventos.ChartAreas(0).CursorX.IsUserEnabled = False
                ChartEventos.ChartAreas(0).CursorX.IsUserSelectionEnabled = False


                ChartEventos.ChartAreas(0).AxisX.ScaleView.Position = 0


                '--------------------------------------------------------------


                ''aca la iria la parte de escribir la edicion en el txt temporal
                ''escribir temporal
                escritor_evento.Write("EDITAR-EVENTOS-" & indice & vbCrLf)
                ' escritor_evento.Write(indice & vbCrLf)


                escritor_evento.Write(inicio_evento(indice) & vbCrLf)
                escritor_evento.Write(fin_evento(indice) & vbCrLf)
                escritor_evento.Write(arreglo_eventos_hora(indice) & vbCrLf)
                escritor_evento.Write(stopW_eventos(0, indice) & vbCrLf)
                escritor_evento.Write(stopW_eventos(1, indice) & vbCrLf)
                escritor_evento.Write(stopW_eventos(2, indice) & vbCrLf)
                escritor_evento.Write(inicio_Ereloj(indice) & vbCrLf)
                escritor_evento.Write(fin_Ereloj(indice) & vbCrLf)
                escritor_evento.Write(tipos_eventos(indice) & vbCrLf)





            Else





                contador_eventos_editados = contador_eventos_editados + 1

                backup_editados(0, contador_eventos_editados - 1) = indice
                backup_editados(1, contador_eventos_editados - 1) = inicio_evento(indice)
                backup_editados(2, contador_eventos_editados - 1) = inicio_Ereloj(indice)
                backup_editados(3, contador_eventos_editados - 1) = fin_evento(indice)
                backup_editados(4, contador_eventos_editados - 1) = fin_Ereloj(indice)

                ' Dim diferencia_inicio As Single = (((ChartEventos.ChartAreas(0).CursorX.SelectionStart * 1000 / paso) - inicio_evento(indice)) * paso) / 1000

                Dim diferencia_inicio As Single = (ChartEventos.ChartAreas(0).CursorX.SelectionStart) * paso / 1000


                '   backup_editados(2, contador_eventos_editados - 1) = inicio_Ereloj(indice)

                horas = inicio_Ereloj(indice)


                minutos = Floor(diferencia_inicio / 60)
                segundos = diferencia_inicio Mod 60
                horas = horas.AddMinutes(minutos)
                horas = horas.AddSeconds(segundos)

                inicio_Ereloj(indice) = horas



                '  If inicio_evento(indice) + scrollecg.Value + Punto_entero <= eventos_editados(1, contador_eventos_editados - 1) Then Exit Sub


                '  eventos_editados(3, contador_eventos_editados - 1) = inicio_evento(indice) + scrollecg.Value + Punto_entero 'punto_chart.XValue

                horas = fin_Ereloj(indice)
                'tiempo transcurrido en segundos

                Dim diferencia_fin As Single = ((fin_evento(indice) - ChartEventos.ChartAreas(0).CursorX.SelectionEnd - inicio_evento(indice)) * paso) / 1000

                minutos = Floor(diferencia_fin / 60)
                segundos = diferencia_fin Mod 60
                horas = horas.AddMinutes(-minutos)
                horas = horas.AddSeconds(-segundos)


                inicio_evento(indice) = ChartEventos.ChartAreas(0).CursorX.SelectionStart
                fin_Ereloj(indice) = horas
                fin_evento(indice) = ChartEventos.ChartAreas(0).CursorX.SelectionEnd

                ListBoxeventos.Enabled = True

                editando_eventos = False
                sender.text = "Editar Evento"

                '------------------------------
                'inicio_evento(indice) = eventos_editados(1, contador_eventos_editados - 1)
                'inicio_Ereloj(indice) = eventos_editados(2, contador_eventos_editados - 1)

                'fin_Ereloj(indice) = eventos_editados(4, contador_eventos_editados - 1)

                Dim aux_array() As String = Split(eventos, vbCrLf)

                aux_array(indice) = "- " & tipos_eventos(indice).Trim() & ": "

                If (inicio_Ereloj(indice).Minute) < 10 Then
                    aux_array(indice) = aux_array(indice) & "0" & inicio_Ereloj(indice).Minute.ToString() & ":"
                Else
                    aux_array(indice) = aux_array(indice) & inicio_Ereloj(indice).Minute.ToString() & ":"
                End If

                If (inicio_Ereloj(indice).Second) < 10 Then
                    aux_array(indice) = aux_array(indice) & "0" & inicio_Ereloj(indice).Second.ToString()
                Else
                    aux_array(indice) = aux_array(indice) & inicio_Ereloj(indice).Second.ToString()
                End If

                If (fin_Ereloj(indice).Minute) < 10 Then
                    aux_array(indice) = aux_array(indice) & " / 0" & inicio_Ereloj(indice).Minute.ToString() & ":"
                Else
                    aux_array(indice) = aux_array(indice) & " / " & inicio_Ereloj(indice).Minute.ToString() & ":"
                End If

                If (fin_Ereloj(indice).Second) < 10 Then
                    aux_array(indice) = aux_array(indice) & "0" & fin_Ereloj(indice).Second.ToString()
                Else
                    aux_array(indice) = aux_array(indice) & fin_Ereloj(indice).Second.ToString()
                End If


                eventos = ""
                For i As Integer = 0 To (aux_array.Count - 2)
                    eventos = eventos & aux_array(i) & vbCrLf
                Next

                'aca deberia tocar el array
                arreglo_eventos_hora(indice) = aux_array(indice)

                listar_eventos()
                ListBoxeventos.SelectedIndex = indice




                Mostrar_ventana(indice)

                botonCancelarEdicionEvento.Visible = False
                botonCancelarEdicionEvento.Enabled = False

                ChartEventos.ChartAreas(0).CursorX.SelectionStart = 0
                ChartEventos.ChartAreas(0).CursorX.SelectionEnd = 0

                ChartEventos.ChartAreas(0).CursorX.Position = 0

                ChartEventos.ChartAreas(0).CursorX.SetCursorPosition(0)



                ChartEventos.ChartAreas(0).AxisX.ScaleView.Position = 0

                ChartEventos.ChartAreas(0).CursorX.IsUserEnabled = False
                ChartEventos.ChartAreas(0).CursorX.IsUserSelectionEnabled = False

                ' ListBoxeventos_DoubleClick(sender, e)
                ChartEventos.ChartAreas(0).CursorX.SetCursorPosition(0)


                '--------------------------------------------------------------



                ''aca la iria la parte de escribir la edicion en el txt temporal
                ''escribir temporal
                escritor_evento.Write("EDITAR-EVENTOS-" & indice & vbCrLf)
                'escritor_evento.Write(indice & vbCrLf)


                escritor_evento.Write(inicio_evento(indice) & vbCrLf)
                escritor_evento.Write(fin_evento(indice) & vbCrLf)
                escritor_evento.Write(arreglo_eventos_hora(indice) & vbCrLf)
                escritor_evento.Write(stopW_eventos(0, indice) & vbCrLf)
                escritor_evento.Write(stopW_eventos(1, indice) & vbCrLf)
                escritor_evento.Write(stopW_eventos(2, indice) & vbCrLf)
                escritor_evento.Write(inicio_Ereloj(indice) & vbCrLf)
                escritor_evento.Write(fin_Ereloj(indice) & vbCrLf)
                escritor_evento.Write(tipos_eventos(indice) & vbCrLf)



                'aca la iria la parte de escribir la edicion en el txt temporal
                'escribir temporal
                'escritor_evento.Write("EDITAR-EVENTOS" & vbCrLf)  ' el titulo editar eventos esta bien
                'escritor_evento.Write(indice & vbCrLf) 'el indice hay que pasarlo y es el correcto


                'escritor_evento.Write(inicio_evento(indice) & vbCrLf) ' inicio evento ya fue editado
                'escritor_evento.Write(fin_evento(indice) & vbCrLf)      ' fin evento ya fue editado


                'escritor_evento.Write(arreglo_eventos_hora(indice) & vbCrLf)
                'escritor_evento.Write(stopW_eventos(0, indice) & vbCrLf) ' inicio y fin delk stop watch no edito pero no es necesario
                'escritor_evento.Write(stopW_eventos(1, indice) & vbCrLf)

                '' en el termporal no estoy guardando el pasoo!!!!
                '' seria necesario en caso de una edición


                'escritor_evento.Write(fin_Ereloj(indice) & vbCrLf)  ' los valores del reloj fueron editados bien ya 
                'escritor_evento.Write(inicio_Ereloj(indice) & vbCrLf)




            End If
        End If
    End Sub


    Private Sub ChartEventos_Click(sender As Object, e As MouseEventArgs) Handles ChartEventos.Click
        Punto_entero = ChartEventos.ChartAreas(0).AxisX.PixelPositionToValue(e.X)

        If editando_eventos = True Then

            Dim e1 As System.Windows.Forms.ScrollEventArgs
            scrollecg_Scroll(sender, e1)
            '  scrollecg.Value = scrollecg.Minimum
            'scrollecg.Value = scrollecg.Value + 1
        End If

    End Sub

    Private Sub botonCancelarEdicionEvento_Click(sender As Object, e As EventArgs) Handles botonCancelarEdicionEvento.Click

        If MsgBox("Está seguro que desea cancelar la edición del evento?", MsgBoxStyle.YesNo, "Edición Evento") = MsgBoxResult.Yes Then
            'contador_eventos_editados = contador_eventos_editados - 1
            sender.visible = False
            sender.enabled = False
            botonEditarEvento.Text = "Editar Evento"
            ListBoxeventos.Enabled = True
            ' Mostrar_ventana(ListBoxeventos.SelectedIndex)

            editando_eventos = False
            ListBoxeventos_DoubleClick(sender, e)
            ChartEventos.ChartAreas(0).CursorX.SelectionStart = 0
            ChartEventos.ChartAreas(0).CursorX.SelectionEnd = 0
            ChartEventos.ChartAreas(0).CursorX.IsUserEnabled = False

        End If

    End Sub

    Private Sub ChartEventos_Click(sender As Object, e As EventArgs) Handles ChartEventos.Click

    End Sub

    Private Sub iconoGuardarExamen_MouseEnter(sender As Object, e As EventArgs) Handles iconoGuardarExamen.MouseEnter
        sender.backcolor = Color.LightGray
    End Sub

    Private Sub iconoGuardarExamen_MouseLeave(sender As Object, e As EventArgs) Handles iconoGuardarExamen.MouseLeave
        sender.backcolor = Color.Transparent
    End Sub

    Private Sub iconoGuardarExamen_MouseHover(sender As Object, e As EventArgs) Handles iconoGuardarExamen.MouseHover
        ToolTip1.SetToolTip(sender, "Guardar Examen y Salir")
    End Sub

    Private Sub iconoGuardarExamen_Click(sender As Object, e As EventArgs) Handles iconoGuardarExamen.Click
        If MsgBox("Esta seguro que desea guardar el examen y salir?", MsgBoxStyle.YesNo, "Guardar Examen y Salir") = MsgBoxResult.Yes Then
            guardar_examen()
        End If
    End Sub

    Private Sub iconoImprimirPDF_MouseEnter(sender As Object, e As EventArgs) Handles iconoImprimirPDF.MouseEnter
        sender.backcolor = Color.LightGray
    End Sub

    Private Sub iconoImprimirPDF_MouseLeave(sender As Object, e As EventArgs) Handles iconoImprimirPDF.MouseLeave
        sender.backcolor = Color.Transparent
    End Sub

    Private Sub iconoImprimirPDF_MouseHover(sender As Object, e As EventArgs) Handles iconoImprimirPDF.MouseHover
        ToolTip1.SetToolTip(sender, "Imprimir PDF")
    End Sub

    Private Sub iconoImprimirPDF_Click(sender As Object, e As EventArgs) Handles iconoImprimirPDF.Click
        Me.Cursor = Cursors.WaitCursor
        ' TimerScreen.Enabled = False

        Imprimir_PDF()
        Me.Cursor = Cursors.Default
        'reconectar()
        ' TimerScreen.Enabled = True
    End Sub

    Private Sub iconoECGpersonales_Click(sender As Object, e As EventArgs) Handles iconoPlayPaciente.Click
        Iniciar_terminar_eventos()
    End Sub

    Private Sub iconoECGpersonales_MouseEnter(sender As Object, e As EventArgs) Handles iconoPlayPaciente.MouseEnter
        sender.backcolor = Color.White
    End Sub

    Private Sub iconoECGpersonales_MouseLeave(sender As Object, e As EventArgs) Handles iconoPlayPaciente.MouseLeave
        ' sender.backcolor = Color.CadetBlue
        sender.backcolor = Color.MediumBlue
    End Sub

    Private Sub iconoECGpersonales_MouseHover(sender As Object, e As EventArgs) Handles iconoPlayPaciente.MouseHover
        If evento_iniciado = True Then
            ToolTip1.SetToolTip(sender, "Detener Grabación")
        Else
            ToolTip1.SetToolTip(sender, "Grabar ECG")
        End If
    End Sub

    Sub Iniciar_terminar_eventos()

        'If contador_eventos >= 11 Then
        '    MsgBox("Se alcanzó la cantidad máxima de eventos por estudio! Elimine un evento de la lista antes de realizar otro", MsgBoxStyle.Exclamation, "Evento Cancelado")
        '    Exit Sub
        'End If


        Dim tipo_evento As String = "Evento"

        If estado_basal = True Then
            tipo_evento = "Basal"
        Else

            If estado_etapa1 = True Then
                tipo_evento = "Etapa 1"
            Else
                If estado_etapa2 = True Then
                    tipo_evento = "Etapa 2"
                Else
                    If estado_etapa3 = True Then
                        tipo_evento = "Etapa 3"
                    Else

                        If estado_recuperacion = True Then
                            tipo_evento = "Recuperación"


                        Else
                            tipo_evento = "Pre Examen"
                        End If
                End If
                End If
            End If

        End If



        If evento_iniciado = False Then


            If contador_eventos >= 11 Then
                MsgBox("Se alcanzó la cantidad máxima de eventos por estudio! Elimine un evento de la lista antes de realizar otro", MsgBoxStyle.Exclamation, "Evento Cancelado")
                Exit Sub
            End If





            'declaro que se ha iniciado el evento
            evento_iniciado = True
            tiempo_inicio_evento = reloj_global.ElapsedMilliseconds()

            'aumento el contador
            contador_eventos = contador_eventos + 1
            'agrego al string de eventos

            'vuelvosiempre
            Try
                tipos_eventos(contador_eventos - 1) = tipo_evento

            Catch ex As Exception
                Exit Sub
            End Try


            'eventos = eventos & "- " & tipo_evento & ": "

            'agrego al array que tiene los tipos
            '    tipos_eventos(contador_eventos) = "M"

            stopW_eventos(0, contador_eventos - 1) = tiempo_inicio_evento.ToString()

            inicio_evento(contador_eventos - 1) = contador_ECG_nuevo


            tiempo_paquetes(0, contador_eventos - 1) = tiempo_inicio_evento


            If tipo_evento = "Pre Examen" Then

                arreglo_eventos_hora(contador_eventos - 1) = "- " & tipo_evento

                inicio_Ereloj(contador_eventos - 1) = inicio_Ereloj(contador_eventos - 1).AddMinutes(0)
                inicio_Ereloj(contador_eventos - 1) = inicio_Ereloj(contador_eventos - 1).AddSeconds(0)
                eventos = eventos & "- " & tipo_evento
            Else
                eventos = eventos & "- " & tipo_evento & ": "

                inicio_Ereloj(contador_eventos - 1) = inicio_Ereloj(contador_eventos - 1).AddMinutes(uniminutos + decminutos * 10)
                inicio_Ereloj(contador_eventos - 1) = inicio_Ereloj(contador_eventos - 1).AddSeconds(unisegundos + decsegundos * 10)


                momento_cero = inicio_Ereloj(contador_eventos - 1).Second + inicio_Ereloj(contador_eventos - 1).Minute * 60

                Dim uniseg_aux As Integer
                Dim decseg_aux As Integer

                Dim unimin_aux As Integer
                Dim decmin_aux As Integer


                Try
                    inicio_Ereloj(contador_eventos - 1) = inicio_Ereloj(contador_eventos - 1).AddSeconds(-5)
                    'falta sacarle cinco segundos a estos
                    Dim segundos_tot As Integer = (unisegundos + decsegundos * 10)
                    Dim minutos_tot As Integer = uniminutos + decminutos
                    If segundos_tot - 5 < 0 Then

                        segundos_tot = segundos_tot - 5 + 60

                        minutos_tot = minutos_tot - 1
                    Else
                        segundos_tot = segundos_tot - 5

                    End If

                    uniseg_aux = segundos_tot Mod 10
                    decseg_aux = segundos_tot \ 10


                    unimin_aux = minutos_tot Mod 10
                    decmin_aux = minutos_tot \ 10

                Catch ex As Exception
                    inicio_Ereloj(contador_eventos - 1) = inicio_Ereloj(contador_eventos - 1).AddSeconds(-1 * (unisegundos + decsegundos * 10))

                    uniseg_aux = 0
                    decseg_aux = 0

                    unimin_aux = 0
                    decmin_aux = 0

                End Try


                If (unimin_aux + decmin_aux * 10) < 10 Then
                    eventos = eventos & "0" & inicio_Ereloj(contador_eventos - 1).Minute.ToString() & ":"

                    arreglo_eventos_hora(contador_eventos - 1) = "- " & tipo_evento & ": 0" & inicio_Ereloj(contador_eventos - 1).Minute.ToString() & ":"
                Else
                    eventos = eventos & inicio_Ereloj(contador_eventos - 1).Minute.ToString() & ":"

                    arreglo_eventos_hora(contador_eventos - 1) = "- " & tipo_evento & ": " & inicio_Ereloj(contador_eventos - 1).Minute.ToString() & ":"

                End If

                If (uniseg_aux + decseg_aux * 10) < 10 Then
                    eventos = eventos & "0" & inicio_Ereloj(contador_eventos - 1).Second.ToString()

                    arreglo_eventos_hora(contador_eventos - 1) = arreglo_eventos_hora(contador_eventos - 1) & "0" & inicio_Ereloj(contador_eventos - 1).Second.ToString()

                Else
                    eventos = eventos & inicio_Ereloj(contador_eventos - 1).Second.ToString()
                    arreglo_eventos_hora(contador_eventos - 1) = arreglo_eventos_hora(contador_eventos - 1) & inicio_Ereloj(contador_eventos - 1).Second.ToString()
                End If


            End If



            'botonECG.Text = "Terminar evento"
            'botonECG.Enabled = False
            'botonECGprotocolo.Text = "Terminar evento"
            'botonECGpersonales.Text = "Terminar evento"
            'botonECGpersonales.Enabled = False
            'botonECGprotocolo.Enabled = False




            'cambio de íconos 
            iconoPlayPaciente.Load(direccion_txt & "\pausa.png")
            iconoPlayProtocolos.Load(direccion_txt & "\pausa.png")
            iconoPlayExamen.Load(direccion_txt & "\pausa.png")


            iconoPlayPaciente.Enabled = False
            iconoPlayProtocolos.Enabled = False
            iconoPlayExamen.Enabled = False

            Exit Sub
        End If



        'en eventos guardo el numero de contador ecg, serviria como indicador de en que tiempo inicio
        If evento_iniciado = True Then

            'declaro que se ha iniciado el evento
            evento_iniciado = False


            tiempo_final_evento = reloj_global.ElapsedMilliseconds()
            tiempo_paquetes(1, contador_eventos - 1) = tiempo_final_evento
            'agrego al string de eventos





            If tipo_evento = "Pre Examen" Then

                eventos = eventos & vbCrLf

                'botonECG.Text = "Iniciar evento"
                'botonECGpersonales.Text = "Iniciar evento"
                'botonECGprotocolo.Text = "Iniciar evento"

                iconoPlayPaciente.Load(direccion_txt & "\play.png")
                iconoPlayProtocolos.Load(direccion_txt & "\play.png")
                iconoPlayExamen.Load(direccion_txt & "\play.png")
                stopW_eventos(1, contador_eventos - 1) = tiempo_final_evento

                fin_evento(contador_eventos - 1) = contador_ECG_nuevo

                stopW_eventos(2, contador_eventos - 1) = eje_temporal(contador_eventos - 1)



                'aca calculo el nuevo inicio
                Dim nuevo_inicio As Integer = inicio_evento(contador_eventos - 1) - (5000 \ stopW_eventos(2, contador_eventos - 1))

                If nuevo_inicio <= 0 Then
                    nuevo_inicio = 0
                End If

                inicio_evento(contador_eventos - 1) = nuevo_inicio

                fin_Ereloj(contador_eventos - 1) = fin_Ereloj(contador_eventos - 1).AddMinutes(0)
                fin_Ereloj(contador_eventos - 1) = fin_Ereloj(contador_eventos - 1).AddSeconds(0)



            Else


                'botonECG.Text = "Iniciar evento"
                'botonECGpersonales.Text = "Iniciar evento"
                'botonECGprotocolo.Text = "Iniciar evento"

                iconoPlayPaciente.Load(direccion_txt & "\play.png")
                iconoPlayProtocolos.Load(direccion_txt & "\play.png")
                iconoPlayExamen.Load(direccion_txt & "\play.png")

                stopW_eventos(1, contador_eventos - 1) = tiempo_final_evento


                fin_evento(contador_eventos - 1) = contador_ECG_nuevo

                stopW_eventos(2, contador_eventos - 1) = eje_temporal(contador_eventos - 1)


                Dim nuevo_inicio As Integer

                If momento_cero <= 5 Then

                    nuevo_inicio = inicio_evento(contador_eventos - 1) - ((momento_cero * 1000) \ stopW_eventos(2, contador_eventos - 1))

                Else


                    nuevo_inicio = inicio_evento(contador_eventos - 1) - (5000 \ stopW_eventos(2, contador_eventos - 1))
                End If



                '  Dim nuevo_inicio As Integer = inicio_evento(contador_eventos - 1) - ((5000 \ stopW_eventos(2, contador_eventos - 1)) + 1)

                If nuevo_inicio <= 0 Then
                    nuevo_inicio = 0
                End If

                inicio_evento(contador_eventos - 1) = nuevo_inicio


                ' ahora lo del reloj
                'inicio_Ereloj(contador_eventos - 1).AddSeconds(-5)



                fin_Ereloj(contador_eventos - 1) = fin_Ereloj(contador_eventos - 1).AddMinutes(uniminutos + decminutos * 10)
                fin_Ereloj(contador_eventos - 1) = fin_Ereloj(contador_eventos - 1).AddSeconds(unisegundos + decsegundos * 10)



                If (uniminutos + decminutos * 10) < 10 Then
                    eventos = eventos & " / 0" & fin_Ereloj(contador_eventos - 1).Minute.ToString & ":"

                    arreglo_eventos_hora(contador_eventos - 1) = arreglo_eventos_hora(contador_eventos - 1) & " / 0" & fin_Ereloj(contador_eventos - 1).Minute.ToString & ":"

                Else
                    eventos = eventos & " / " & fin_Ereloj(contador_eventos - 1).Minute.ToString & ":"

                    arreglo_eventos_hora(contador_eventos - 1) = arreglo_eventos_hora(contador_eventos - 1) & " / " & fin_Ereloj(contador_eventos - 1).Minute.ToString & ":"
                End If


                If (unisegundos + decsegundos * 10) < 10 Then
                    eventos = eventos & "0" & fin_Ereloj(contador_eventos - 1).Second.ToString & vbCrLf

                    arreglo_eventos_hora(contador_eventos - 1) = arreglo_eventos_hora(contador_eventos - 1) & "0" & fin_Ereloj(contador_eventos - 1).Second.ToString

                Else
                    eventos = eventos & fin_Ereloj(contador_eventos - 1).Second.ToString & vbCrLf

                    arreglo_eventos_hora(contador_eventos - 1) = arreglo_eventos_hora(contador_eventos - 1) & fin_Ereloj(contador_eventos - 1).Second.ToString
                End If

            End If


            'se hace afuera del if, se escribe sea pre-examen- basal o lo que sea

            'escribir temporal
            escritor_evento.Write("EVENTOS-" & contador_eventos & vbCrLf)
            escritor_evento.Write(inicio_evento(contador_eventos - 1) & vbCrLf)
            escritor_evento.Write(fin_evento(contador_eventos - 1) & vbCrLf)
            escritor_evento.Write(arreglo_eventos_hora(contador_eventos - 1) & vbCrLf)
            escritor_evento.Write(stopW_eventos(0, contador_eventos - 1) & vbCrLf)
            escritor_evento.Write(stopW_eventos(1, contador_eventos - 1) & vbCrLf)
            escritor_evento.Write(stopW_eventos(2, contador_eventos - 1) & vbCrLf)
            escritor_evento.Write(inicio_Ereloj(contador_eventos - 1) & vbCrLf)
            escritor_evento.Write(fin_Ereloj(contador_eventos - 1) & vbCrLf)
            escritor_evento.Write(tipos_eventos(contador_eventos - 1) & vbCrLf)



            listar_eventos()

        End If

    End Sub

    Private Sub iconoPlayProtocolos_MouseEnter(sender As Object, e As EventArgs) Handles iconoPlayProtocolos.MouseEnter
        sender.backcolor = Color.White
    End Sub

    Private Sub iconoPlayProtocolos_MouseLeave(sender As Object, e As EventArgs) Handles iconoPlayProtocolos.MouseLeave
        ' sender.backcolor = Color.CadetBlue
        sender.backcolor = Color.MediumBlue
    End Sub

    Private Sub iconoPlayProtocolos_MouseHover(sender As Object, e As EventArgs) Handles iconoPlayProtocolos.MouseHover
        If evento_iniciado = True Then
            ToolTip1.SetToolTip(sender, "Detener Grabación")
        Else
            ToolTip1.SetToolTip(sender, "Grabar ECG")
        End If
    End Sub

    Private Sub iconoPlayProtocolos_Click(sender As Object, e As EventArgs) Handles iconoPlayProtocolos.Click
        Iniciar_terminar_eventos()
    End Sub

    Private Sub iconoPlayExamen_MouseLeave(sender As Object, e As EventArgs) Handles iconoPlayExamen.MouseLeave
        ' sender.backcolor = Color.CadetBlue
        sender.backcolor = Color.MediumBlue
    End Sub

    Private Sub iconoPlayExamen_MouseEnter(sender As Object, e As EventArgs) Handles iconoPlayExamen.MouseEnter
        sender.backcolor = Color.White
    End Sub

    Private Sub iconoPlayExamen_MouseHover(sender As Object, e As EventArgs) Handles iconoPlayExamen.MouseHover
        If evento_iniciado = True Then
            ToolTip1.SetToolTip(sender, "Detener Grabación")
        Else
            ToolTip1.SetToolTip(sender, "Grabar ECG")
        End If
    End Sub

    Private Sub iconoPlayExamen_Click(sender As Object, e As EventArgs) Handles iconoPlayExamen.Click
        Iniciar_terminar_eventos()
    End Sub

    Sub orden_tabulacion_inicio()

        LabelTitulo.TabStop = False
        botonNuevopaciente.TabIndex = 1
        botonBuscarpaciente.TabIndex = 2
        botonbuscarexamen.TabIndex = 3
        txtfechahoy.TabStop = False
        'TextNombre.TabIndex = 4
        'TextApellido.TabIndex = 5
        'TextDNI.TabIndex = 6

    End Sub

    Sub orden_tabulacion_paciente()

        ' TextNombre.
        LabelTitulo.TabStop = False
        txtfechaexamen.TabStop = False
        LabelConexionPersonales.TabStop = False
        LabelPacienteDesconectado.TabStop = False
        CheckBoxMandanteExterno.TabStop = False
        txtfechahoy.TabStop = False
        TextNombre.Select()

        TextNombre.TabIndex = 0
        TextApellido.TabIndex = 1
        TextDNI.TabIndex = 2
        TextEdad.TabIndex = 3
        Panelsexo.TabIndex = 4
        botonMsexo.TabIndex = 4
        botonFsexo.TabIndex = 4

        PanelINT.TabIndex = 5
        InternadoNO.TabIndex = 5
        InternadoSI.TabIndex = 5

        TextDomicilio.TabIndex = 6
        TextTelefono.TabIndex = 7
        TextRitmo.TabIndex = 8
        TextSintoma.TabIndex = 9

        txtfechaexamen.TabIndex = 10
        cbxMandante.TabIndex = 11
        cbxActuante.TabIndex = 12
        cbxTecnico.TabIndex = 13

    End Sub

    Sub orden_tabulacion_protocolo()

        ' TextNombre.
        LabeltituloINTE.TabStop = False
        LabeltituloPROTO.TabStop = False
        ' txtfechaexamen.TabStop = False
        LabelConexionProtocolo.TabStop = False
        LabelPacientedesconectadoprotocolo.TabStop = False

        '  CheckBoxMandanteExterno.TabStop = False
        'txtfechahoy.TabStop = False
        INTE1SI.Select()

        INTE1SI.TabIndex = 0
        INTE2SI.TabIndex = 1
        TextINTE3.TabIndex = 2
        INTE4SI.TabIndex = 3
        INTE5SI.TabIndex = 4
        INTE6SI.TabIndex = 5
        INTE7SI.TabIndex = 6

        INTE8SI.TabIndex = 7
        TextINTE9.TabIndex = 8
        ComboBoxProtocolo.TabIndex = 9

        'TextDomicilio.TabIndex = 6
        'TextTelefono.TabIndex = 7
        'TextRitmo.TabIndex = 8
        'TextSintoma.TabIndex = 9

        'txtfechaexamen.TabIndex = 10
        'cbxMandante.TabIndex = 11
        'cbxActuante.TabIndex = 12
        'cbxTecnico.TabIndex = 13

    End Sub



    Private Sub botonModificarPresion_MouseEnter(sender As Object, e As EventArgs) Handles botonModificarPresion.MouseEnter
        sender.backcolor = Color.LightGray
    End Sub

    Private Sub botonModificarPresion_MouseLeave(sender As Object, e As EventArgs) Handles botonModificarPresion.MouseLeave
        sender.backcolor = Color.Transparent
    End Sub

    Private Sub botonModificarPresion_MouseHover(sender As Object, e As EventArgs) Handles botonModificarPresion.MouseHover
        ToolTip1.SetToolTip(sender, "Modificar Presión")
    End Sub

    Private Sub botonModificarPresion_Click(sender As Object, e As EventArgs) Handles botonModificarPresion.Click
        Ingresar_medicion_presion()
    End Sub

    Sub limpiar_eventos()
        For i As Integer = 0 To ChartEventos.Series("ECG").Points.Count - 1
            ChartEventos.Series("ECG").Points.RemoveAt(0)
        Next
    End Sub

End Class
