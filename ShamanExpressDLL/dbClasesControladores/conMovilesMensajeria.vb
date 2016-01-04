Imports System.Data
Imports System.Data.SqlClient
Public Class conMovilesMensajeria
    Inherits typMovilesMensajeria
    Public Sub New(Optional ByVal pCnnName As String = "")
        MyBase.New(pCnnName)
    End Sub
    Public Function GetIDByIndex(ByVal pMovId As Int64, ByVal pMsgId As Int64) As Int64
        GetIDByIndex = 0
        Try
            Dim SQL As String

            SQL = "SELECT ID FROM MovilesMensajeria WHERE MovilId = " & pMovId & " AND MetodoMensajeriaId = " & pMsgId

            Dim cmFind As New SqlCommand(SQL, cnnsNET(Me.myCnnName), cnnsTransNET(Me.myCnnName))
            Dim vOutVal As String = CType(cmFind.ExecuteScalar, String)
            If Not vOutVal Is Nothing Then GetIDByIndex = CType(vOutVal, Int64)

        Catch ex As Exception
            HandleError(Me.GetType.Name, "GetIDByIndex", ex)
        End Try
    End Function

End Class
