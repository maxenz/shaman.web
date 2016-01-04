Imports System.Data
Imports System.Data.SqlClient
Public Class conLocalidades
    Inherits typLocalidades
    Public Sub New(Optional ByVal pCnnName As String = "")
        MyBase.New(pCnnName)
    End Sub
    Public Function GetQueryBase() As DataTable

        GetQueryBase = Nothing

        Try
            Dim SQL As String

            SQL = "SELECT loc.ID, loc.AbreviaturaId, loc.Descripcion, pai.AbreviaturaId AS Pais, prv.AbreviaturaId AS Provincia, par.AbreviaturaId AS Partido, zon.Descripcion AS Zona "
            SQL = SQL & "FROM Localidades loc "
            SQL = SQL & "LEFT JOIN Provincias prv ON (loc.ProvinciaId = prv.ID) "
            SQL = SQL & "LEFT JOIN Paises pai ON (prv.PaisId = pai.ID) "
            SQL = SQL & "LEFT JOIN Localidades par ON (loc.PartidoId = par.ID) "
            SQL = SQL & "LEFT JOIN ZonasGeograficas zon ON (loc.ZonaGeograficaId = zon.ID) "
            SQL = SQL & " ORDER BY loc.AbreviaturaId"

            Dim cmdEqp As New SqlCommand(SQL, cnnsNET(Me.myCnnName), cnnsTransNET(Me.myCnnName))
            Dim dt As New DataTable
            dt.Load(cmdEqp.ExecuteReader)

            GetQueryBase = dt

        Catch ex As Exception
            HandleError(Me.GetType.Name, "GetQueryBase", ex)
        End Try
    End Function

    Public Function GetIDByAbreviaturaId(ByVal pVal As String) As Int64

        GetIDByAbreviaturaId = 0
        Try
            Dim SQL As String
            SQL = "SELECT ID FROM Localidades WHERE (AbreviaturaId = '" & pVal & "')"

            Dim cmFind As New SqlCommand(SQL, cnnsNET(Me.myCnnName), cnnsTransNET(Me.myCnnName))
            Dim vOutVal As String = CType(cmFind.ExecuteScalar, String)
            If Not vOutVal Is Nothing Then GetIDByAbreviaturaId = CType(vOutVal, Int64)

        Catch ex As Exception
            HandleError(Me.GetType.Name, "GetIDByAbreviaturaId", ex)
        End Try

    End Function

    Public Function GetIDByDescripcion(ByVal pVal As String) As Int64

        GetIDByDescripcion = 0
        Try
            Dim SQL As String
            SQL = "SELECT ID FROM Localidades WHERE (Descripcion = '" & pVal & "')"

            Dim cmFind As New SqlCommand(SQL, cnnsNET(Me.myCnnName), cnnsTransNET(Me.myCnnName))
            Dim vOutVal As String = CType(cmFind.ExecuteScalar, String)
            If Not vOutVal Is Nothing Then GetIDByDescripcion = CType(vOutVal, Int64)

        Catch ex As Exception
            HandleError(Me.GetType.Name, "GetIDByDescripcion", ex)
        End Try

    End Function

    Public Function GetCodigosPostalesByLocalidad(ByVal pLoc As Int64) As DataTable

        GetCodigosPostalesByLocalidad = Nothing

        Try
            Dim SQL As String

            SQL = "SELECT CodigoPostal FROM CodigosPostales WHERE (LocalidadId = " & pLoc & ") "
            SQL = SQL & "ORDER BY CodigoPostal"

            Dim cmdBas As New SqlCommand(SQL, cnnsNET(Me.myCnnName), cnnsTransNET(Me.myCnnName))
            Dim dt As New DataTable
            dt.Load(cmdBas.ExecuteReader)

            dt.Columns(0).ReadOnly = False

            GetCodigosPostalesByLocalidad = dt

        Catch ex As Exception
            HandleError(Me.GetType.Name, "GetCodigosPostalesByLocalidad", ex)
        End Try
    End Function
    Public Function Validar(Optional ByVal pMsg As Boolean = True) As Boolean
        Validar = False
        Try
            Dim vRdo As String = ""
            Validar = True
            If Me.AbreviaturaId = "" Then vRdo = "Debe determinar el código identificador de la localidad"
            If Me.Descripcion = "" And vRdo = "" Then vRdo = "Debe determinar la descripción de la localidad"
            If Me.ZonaGeograficaId.GetObjectId = 0 And vRdo = "" Then vRdo = "Debe determinar la zona geográfica de la localidad"
            If Me.ProvinciaId.GetObjectId = 0 And vRdo = "" Then vRdo = "Debe determinar la provincia de la localidad"
            If Me.PartidoId.GetObjectId = 0 And vRdo = "" And Me.ID > 0 Then vRdo = "Debe asignar el partido de localidad"
            If vRdo <> "" Then
                Validar = False
                If pMsg Then MsgBox(vRdo, MsgBoxStyle.Critical, Me.Tabla)
            End If
        Catch ex As Exception
            HandleError(Me.GetType.Name, "Validar", ex)
        End Try
    End Function
    Public Function GetDefault() As Int64
        GetDefault = 0
        Try
            Dim SQL As String
            SQL = "SELECT ID FROM Localidades WHERE flgDefault = 1"
            Dim cmFind As New SqlCommand(SQL, cnnsNET(Me.myCnnName), cnnsTransNET(Me.myCnnName))
            Dim vOutVal As String = CType(cmFind.ExecuteScalar, String)
            If Not vOutVal Is Nothing Then GetDefault = CType(vOutVal, Int64)
        Catch ex As Exception
            HandleError(Me.GetType.Name, "GetDefault", ex)
        End Try

    End Function
    Public Function SetDefault(ByVal pLoc As Int64) As Boolean
        SetDefault = False
        Try
            Dim SQL As String = "UPDATE Localidades SET flgDefault = 0 WHERE flgDefault = 1"
            Dim cmUpd As New SqlCommand(SQL, cnnsNET(Me.myCnnName), cnnsTransNET(Me.myCnnName))
            cmUpd.ExecuteNonQuery()

            Dim objLocalidad As New conLocalidades(Me.myCnnName)
            If objLocalidad.Abrir(pLoc) Then
                objLocalidad.flgDefault = 1
                SetDefault = objLocalidad.Salvar(objLocalidad)
            End If

        Catch ex As Exception
            HandleError(Me.GetType.Name, "SetDefault", ex)
        End Try

    End Function

End Class
