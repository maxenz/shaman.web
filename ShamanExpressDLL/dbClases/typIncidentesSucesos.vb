Public Class typIncidentesSucesos
    Inherits typAll
    Private clIncidenteViajeId As typIncidentesViajes
    Private clFechaHoraSuceso As DateTime
    Private clSucesoIncidenteId As typSucesosIncidentes
    Private clMovilId As typMoviles
    Private clCondicion As String
    Public Sub New(Optional ByVal pCnnName As String = "")
        MyBase.New(pCnnName)
    End Sub
    Public Property IncidenteViajeId() As typIncidentesViajes
        Get
            Return Me.GetTypProperty(clIncidenteViajeId)
        End Get
        Set(ByVal value As typIncidentesViajes)
            clIncidenteViajeId = value
        End Set
    End Property
    Public Property FechaHoraSuceso() As DateTime
        Get
            Return clFechaHoraSuceso
        End Get
        Set(ByVal value As DateTime)
            clFechaHoraSuceso = value
        End Set
    End Property
    Public Property SucesoIncidenteId() As typSucesosIncidentes
        Get
            Return Me.GetTypProperty(clSucesoIncidenteId)
        End Get
        Set(ByVal value As typSucesosIncidentes)
            clSucesoIncidenteId = value
        End Set
    End Property
    Public Property MovilId() As typMoviles
        Get
            Return Me.GetTypProperty(clMovilId)
        End Get
        Set(ByVal value As typMoviles)
            clMovilId = value
        End Set
    End Property
    Public Property Condicion() As String
        Get
            Return clCondicion
        End Get
        Set(ByVal value As String)
            clCondicion = value
        End Set
    End Property

End Class
