Public Class typMovilesLocalidades
    Inherits typAll
    Private clMovilId As typMoviles
    Private clLocalidadId As typLocalidades
    Public Sub New(Optional ByVal pCnnName As String = "")
        MyBase.New(pCnnName)
    End Sub
    Public Property MovilId() As typMoviles
        Get
            Return Me.GetTypProperty(clMovilId)
        End Get
        Set(ByVal value As typMoviles)
            clMovilId = value
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
End Class
