Imports System.Data
Imports System.Data.SqlClient
Public Class conAlicuotasIva
    Inherits typAlicuotasIva
    Public Sub New(Optional ByVal pCnnName As String = "")
        MyBase.New(pCnnName)
    End Sub
    Public Overrides Function CanDelete(ByVal pId As String, Optional ByVal pMsg As Boolean = True) As Boolean
        CanDelete = False

        Try
            Dim SQL As String = "SELECT TOP 1 AbreviaturaId FROM Clientes WHERE AlicuotaIvaId = " & pId
            Dim cmAli As New SqlCommand(SQL, cnnsNET(Me.myCnnName), cnnsTransNET(Me.myCnnName))
            Dim vVal As String = cmAli.ExecuteScalar

            If Not vVal Is Nothing Then
                If pMsg Then MsgBox("Imposible Eliminar" & vbCrLf & "La alícuota en cuestión está vinculada al cliente " & vVal, MsgBoxStyle.Critical, "Shaman")
            Else
                CanDelete = True
            End If

        Catch ex As Exception
            HandleError(Me.GetType.Name, "CanDelete", ex)
        End Try
    End Function
    Public Function GetAll() As DataTable
        GetAll = Nothing
        Try
            Dim SQL As String

            SQL = "SELECT ID, Descripcion, Porcentaje FROM AlicuotasIva "
            SQL = SQL & " ORDER BY Descripcion"

            Dim cmdEqp As New SqlCommand(SQL, cnnsNET(Me.myCnnName), cnnsTransNET(Me.myCnnName))
            Dim dt As New DataTable
            dt.Load(cmdEqp.ExecuteReader)

            GetAll = dt

        Catch ex As Exception
            HandleError(Me.GetType.Name, "GetAll", ex)
        End Try
    End Function

    Public Function Validar(Optional ByVal pMsg As Boolean = True) As Boolean
        Validar = False
        Try
            Dim vRdo As String = ""
            Validar = True
            If Me.Descripcion = "" Then vRdo = "Debe determinar la descripción de la alícuota de Iva"
            If vRdo <> "" Then
                Validar = False
                If pMsg Then MsgBox(vRdo, MsgBoxStyle.Critical, Me.Tabla)
            End If
        Catch ex As Exception
            HandleError(Me.GetType.Name, "Validar", ex)
        End Try
    End Function
End Class
