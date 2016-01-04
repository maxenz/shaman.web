Public Class typLocalidades
    Inherits typAllGenerico01
    Private clZonaGeograficaId As typZonasGeograficas
    Private clProvinciaId As typProvincias
    Private clPartidoId As typPartidos
    Private clflgDefault As Integer
    Public Sub New(Optional ByVal pCnnName As String = "")
        MyBase.New(pCnnName)
    End Sub
    Public Property ZonaGeograficaId() As typZonasGeograficas
        Get
            Return Me.GetTypProperty(clZonaGeograficaId)
        End Get
        Set(ByVal value As typZonasGeograficas)
            clZonaGeograficaId = value
        End Set
    End Property
    Public Property ProvinciaId() As typProvincias
        Get
            Return Me.GetTypProperty(clProvinciaId)
        End Get
        Set(ByVal value As typProvincias)
            clProvinciaId = value
        End Set
    End Property
    Public Property PartidoId() As typPartidos
        Get
            Return Me.GetTypProperty(clPartidoId)
        End Get
        Set(ByVal value As typPartidos)
            clPartidoId = value
        End Set
    End Property
    Public Property flgDefault() As Integer
        Get
            Return clflgDefault
        End Get
        Set(ByVal value As Integer)
            clflgDefault = value
        End Set
    End Property
End Class
