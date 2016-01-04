Imports System.Data
Imports System.Data.SqlClient
Public Class conClientesContactos
    Inherits typClientesContactos
    Public Sub New(Optional ByVal pCnnName As String = "")
        MyBase.New(pCnnName)
    End Sub
    Public Function GetByCliente(ByVal pCli As Int64) As DataTable

        GetByCliente = Nothing

        Try
            Dim SQL As String

            SQL = "SELECT ID, Nombre, Email, Telefono FROM ClientesContactos "
            SQL = SQL & "WHERE (ClienteId = " & pCli & ") ORDER BY Nombre"

            Dim cmdEqp As New SqlCommand(SQL, cnnsNET(Me.myCnnName), cnnsTransNET(Me.myCnnName))
            Dim dt As New DataTable
            dt.Load(cmdEqp.ExecuteReader)

            GetByCliente = dt

        Catch ex As Exception
            HandleError(Me.GetType.Name, "GetByCliente", ex)
        End Try
    End Function
    Public Function EliminarByCliente(ByVal pId As Int64) As Boolean
        Dim SQL As String

        EliminarByCliente = False
        Try
            Dim cmOpe As New SqlCommand

            SQL = "DELETE FROM ClientesContactos WHERE ClienteId = " & pId
            cmOpe.Connection = cnnsNET(Me.myCnnName)
            cmOpe.Transaction = cnnsTransNET(Me.myCnnName)
            cmOpe.CommandText = SQL
            cmOpe.ExecuteNonQuery()

            EliminarByCliente = True
        Catch ex As Exception
            HandleError(Me.GetType.Name, "EliminarByCliente", ex)
        End Try
    End Function
End Class
