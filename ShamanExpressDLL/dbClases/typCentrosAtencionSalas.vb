Public Class typCentrosAtencionSalas
    Inherits typAll
    Private clCentroAtencionId As typCentrosAtencion
    Private clAbreviaturaId As String
    Private clObservaciones As String
    Public Sub New(Optional ByVal pCnnName As String = "")
        MyBase.New(pCnnName)
    End Sub
    Public Property CentroAtencionId() As typCentrosAtencion
        Get
            Return Me.GetTypProperty(clCentroAtencionId)
        End Get
        Set(ByVal value As typCentrosAtencion)
            clCentroAtencionId = value
        End Set
    End Property
    Public Property AbreviaturaId() As String
        Get
            Return clAbreviaturaId
        End Get
        Set(ByVal value As String)
            clAbreviaturaId = value
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

End Class
