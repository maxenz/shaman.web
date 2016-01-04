Public Class typPreIncidentes
    Inherits typAll
    Private clClienteId As typClientes
    Private clNroServicio As String
    Private clFecHorServicio As DateTime
    Private clTelefono As String
    Private clPaciente As String
    Private clNroAfiliado As String
    Private clSexo As String
    Private clEdad As Decimal
    Private clSintomas As String
    Private clGradoOperativoId As typGradosOperativos
    Private clPlanId As String
    Private clCoPago As Decimal
    Private clflgIvaGravado As Integer
    Private clDomicilio As usrDomicilio
    Private clLocalidadId As typLocalidades
    Private clObservaciones As String
    Private clFecHorRecepcion As DateTime
    Private clIncidenteId As typIncidentes
    Private clerrCliente As String
    Private clerrLocalidad As String
    Private clerrGradoOperativo As String
    Private clmailSender As String
    Private clmailSubject As String
    Private clflgStatus As Integer
    Private clerrIncorporacion As String
    Public Sub New(Optional ByVal pCnnName As String = "")
        MyBase.New(pCnnName)
    End Sub
    Public Property ClienteId() As typClientes
        Get
            Return Me.GetTypProperty(clClienteId)
        End Get
        Set(ByVal value As typClientes)
            clClienteId = value
        End Set
    End Property
    Public Property FecHorServicio() As DateTime
        Get
            Return clFecHorServicio
        End Get
        Set(ByVal value As DateTime)
            clFecHorServicio = value
        End Set
    End Property
    Public Property NroServicio() As String
        Get
            Return clNroServicio
        End Get
        Set(ByVal value As String)
            clNroServicio = value
        End Set
    End Property
    Public Property Telefono() As String
        Get
            Return clTelefono
        End Get
        Set(ByVal value As String)
            clTelefono = value
        End Set
    End Property
    Public Property Paciente() As String
        Get
            Return clPaciente
        End Get
        Set(ByVal value As String)
            clPaciente = value
        End Set
    End Property
    Public Property NroAfiliado() As String
        Get
            Return clNroAfiliado
        End Get
        Set(ByVal value As String)
            clNroAfiliado = value
        End Set
    End Property
    Public Property Sexo() As String
        Get
            Return clSexo
        End Get
        Set(ByVal value As String)
            clSexo = value
        End Set
    End Property
    Public Property Edad() As Decimal
        Get
            Return clEdad
        End Get
        Set(ByVal value As Decimal)
            clEdad = value
        End Set
    End Property
    Public Property Sintomas() As String
        Get
            Return clSintomas
        End Get
        Set(ByVal value As String)
            clSintomas = value
        End Set
    End Property
    Public Property GradoOperativoId() As typGradosOperativos
        Get
            Return Me.GetTypProperty(clGradoOperativoId)
        End Get
        Set(ByVal value As typGradosOperativos)
            clGradoOperativoId = value
        End Set
    End Property
    Public Property PlanId() As String
        Get
            Return clPlanId
        End Get
        Set(ByVal value As String)
            clPlanId = value
        End Set
    End Property
    Public Property CoPago() As Decimal
        Get
            Return clCoPago
        End Get
        Set(ByVal value As Decimal)
            clCoPago = value
        End Set
    End Property
    Public Property flgIvaGravado() As Integer
        Get
            Return clflgIvaGravado
        End Get
        Set(ByVal value As Integer)
            clflgIvaGravado = value
        End Set
    End Property
    Public Property Domicilio() As usrDomicilio
        Get
            Return clDomicilio
        End Get
        Set(ByVal value As usrDomicilio)
            clDomicilio = value
        End Set
    End Property
    Public Property LocalidadId() As typLocalidades
        Get
            Return Me.GetTypProperty(clLocalidadId)
        End Get
        Set(ByVal value As typLocalidades)
            clLocalidadId = value
        End Set
    End Property
    Public Property Observaciones() As String
        Get
            Return clObservaciones
        End Get
        Set(ByVal value As String)
            clObservaciones = value
        End Set
    End Property
    Public Property FecHorRecepcion() As DateTime
        Get
            Return clFecHorRecepcion
        End Get
        Set(ByVal value As DateTime)
            clFecHorRecepcion = value
        End Set
    End Property
    Public Property IncidenteId() As typIncidentes
        Get
            Return Me.GetTypProperty(clIncidenteId)
        End Get
        Set(ByVal value As typIncidentes)
            clIncidenteId = value
        End Set
    End Property
    Public Property errCliente() As String
        Get
            Return clerrCliente
        End Get
        Set(ByVal value As String)
            clerrCliente = value
        End Set
    End Property
    Public Property errLocalidad() As String
        Get
            Return clerrLocalidad
        End Get
        Set(ByVal value As String)
            clerrLocalidad = value
        End Set
    End Property
    Public Property errGradoOperativo() As String
        Get
            Return clerrGradoOperativo
        End Get
        Set(ByVal value As String)
            clerrGradoOperativo = value
        End Set
    End Property
    Public Property mailSender() As String
        Get
            Return clmailSender
        End Get
        Set(ByVal value As String)
            clmailSender = value
        End Set
    End Property
    Public Property mailSubject() As String
        Get
            Return clmailSubject
        End Get
        Set(ByVal value As String)
            clmailSubject = value
        End Set
    End Property
    Public Property flgStatus() As Integer
        Get
            Return clflgStatus
        End Get
        Set(ByVal value As Integer)
            clflgStatus = value
        End Set
    End Property
    Public Property errIncorporacion() As String
        Get
            Return clerrIncorporacion
        End Get
        Set(ByVal value As String)
            clerrIncorporacion = value
        End Set
    End Property

End Class
