Public Class typAlicuotasIva
    Inherits typAllGenerico00
    Private clPorcentaje As Decimal
    Public Sub New(Optional ByVal pCnnName As String = "")
        MyBase.New(pCnnName)
    End Sub
    Public Property Porcentaje() As Decimal
        Get
            Return clPorcentaje
        End Get
        Set(ByVal value As Decimal)
            clPorcentaje = value
        End Set
    End Property
End Class
