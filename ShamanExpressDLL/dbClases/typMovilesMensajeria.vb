Public Class typMovilesMensajeria
    Inherits typAll
    Private clMovilId As typMoviles
    Private clMetodoMensajeriaId As typMetodosMensajeria
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
    Public Property MetodoMensajeriaId() As typMetodosMensajeria
        Get
            Return Me.GetTypProperty(clMetodoMensajeriaId)
        End Get
        Set(ByVal value As typMetodosMensajeria)
            clMetodoMensajeriaId = value
        End Set
    End Property
End Class
