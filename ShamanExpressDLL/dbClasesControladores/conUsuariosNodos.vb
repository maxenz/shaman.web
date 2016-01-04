Imports System.Data
Imports System.Data.SqlClient
Public Class conUsuariosNodos
    Inherits typUsuariosNodos
    Public Sub New(Optional ByVal pCnnName As String = "")
        MyBase.New(pCnnName)
    End Sub
    Public Function GetIDByIndex(ByVal pUsr As Int64, ByVal pTip As tipUsoRelacion, ByVal pNod As Int64) As Int64
        GetIDByIndex = 0
        Try
            Dim SQL As String
            '--------> QUERY
            SQL = "SELECT ID FROM UsuariosNodos WHERE UsuarioId = " & pUsr & " AND TipoRelacion = " & pTip & " AND sysNodoId = " & pNod

            Dim cmFind As New SqlCommand(SQL, cnnsNET(Me.myCnnName), cnnsTransNET(Me.myCnnName))
            Dim vOutVal As String = CType(cmFind.ExecuteScalar, String)
            If Not vOutVal Is Nothing Then GetIDByIndex = CType(vOutVal, Int64)

        Catch ex As Exception
            HandleError(Me.GetType.Name, "GetIDByIndex", ex)
        End Try
    End Function
End Class
