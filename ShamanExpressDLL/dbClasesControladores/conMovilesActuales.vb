Imports System.Data
Imports System.Data.SqlClient
Public Class conMovilesActuales
    Inherits typMovilesActuales
    Public Sub New(Optional ByVal pCnnName As String = "")
        MyBase.New(pCnnName)
    End Sub

    Public Function GetMovilesOperativos() As DataTable

        GetMovilesOperativos = Nothing

        Try
            Dim SQL As String, vRowSel As Int16 = -1, vColSel As Int16 = -1

            If cnnsNET.Count > 1 Then Exit Function

            SQL = "SELECT act.ID, mov.Movil, zon.ColorHexa AS ColorZona, sus.ValorGrilla, sus.ColorHexa AS ColorSuceso, "
            SQL = SQL & "CASE ISNULL(act.MotivoCondicionalId, 0) WHEN 0 THEN loc.AbreviaturaId ELSE mot.AbreviaturaId END AS Localidad, "
            SQL = SQL & "act.TipoMovilId, blc.ZonaGeograficaId "
            SQL = SQL & "FROM MovilesActuales act "
            SQL = SQL & "INNER JOIN Moviles mov ON (act.MovilId = mov.ID) "
            SQL = SQL & "INNER JOIN BasesOperativas bas ON (act.BaseOperativaId = bas.ID) "
            SQL = SQL & "INNER JOIN Localidades blc ON (bas.LocalidadId = blc.ID) "
            SQL = SQL & "INNER JOIN ZonasGeograficas zon ON (blc.ZonaGeograficaId = zon.ID) "
            SQL = SQL & "INNER JOIN SucesosIncidentes sus ON (act.SucesoIncidenteId = sus.ID) "
            SQL = SQL & "LEFT JOIN Localidades loc ON (act.LocalidadId = loc.ID) "
            SQL = SQL & "LEFT JOIN MotivosCondicionales mot ON (act.MotivoCondicionalId = mot.ID) "
            SQL = SQL & "ORDER BY mov.Movil"

            Dim cmdMov As New SqlCommand(SQL, cnnsNET(Me.myCnnName), cnnsTransNET(Me.myCnnName))
            Dim dt As New DataTable
            Dim vIdx As Integer = 0
            dt.Load(cmdMov.ExecuteReader)

            '-------> Aplico seguridad de perfiles
            SetPerfiles(dt)

            GetMovilesOperativos = dt

        Catch ex As Exception
            HandleError(Me.GetType.Name, "GetMovilesOperativos", ex)
        End Try
    End Function

    Public Sub SetPerfiles(ByRef dt As DataTable)
        Try
            If CBool(shamanConfig.flgDespachoPerfiles) And logDespacha Then

                Dim vIdx As Integer = 0

                Do Until vIdx = dt.Rows.Count
                    '----> Verifico si es de mi tipo móvil y zona
                    Dim SQL As String

                    SQL = "SELECT cab.ID FROM Perfiles cab "
                    SQL = SQL & "INNER JOIN PerfilesTiposMoviles tmv ON (cab.ID = tmv.PerfilId) "
                    SQL = SQL & "INNER JOIN PerfilesZonasGeograficas zon ON (cab.ID = zon.PerfilId) "
                    SQL = SQL & "WHERE (cab.ID = " & logPerfilId & ") AND (tmv.TipoMovilId = " & dt(vIdx)("TipoMovilId") & ") "
                    SQL = SQL & "AND (zon.ZonaGeograficaId = " & dt(vIdx)("ZonaGeograficaId") & ") "

                    Dim cmdPrf As New SqlCommand(SQL, cnnsNET(Me.myCnnName), cnnsTransNET(Me.myCnnName))
                    Dim vRowId As String = CType(cmdPrf.ExecuteScalar, String)
                    If vRowId Is Nothing Then
                        dt.Rows.RemoveAt(vIdx)
                    Else
                        vIdx = vIdx + 1
                    End If
                Loop

            End If
        Catch ex As Exception
            HandleError(Me.GetType.Name, "SetPerfiles", ex)
        End Try
    End Sub

    Public Function GetIDByIndex(ByVal pVal As Int64) As Int64
        GetIDByIndex = 0
        Try
            Dim SQL As String
            '--------> QUERY
            SQL = "SELECT ID FROM MovilesActuales WHERE MovilId = " & pVal
            Dim cmFind As New SqlCommand(SQL, cnnsNET(Me.myCnnName), cnnsTransNET(Me.myCnnName))
            Dim vOutVal As String = CType(cmFind.ExecuteScalar, String)
            If Not vOutVal Is Nothing Then GetIDByIndex = CType(vOutVal, Int64)

        Catch ex As Exception
            HandleError(Me.GetType.Name, "GetIDByIndex", ex)
        End Try
    End Function

    Public Function GetIDByVehiculo(ByVal pVal As Int64) As Int64
        GetIDByVehiculo = 0
        Try
            Dim SQL As String
            '--------> QUERY
            SQL = "SELECT ID FROM MovilesActuales WHERE VehiculoId = " & pVal
            Dim cmFind As New SqlCommand(SQL, cnnsNET(Me.myCnnName), cnnsTransNET(Me.myCnnName))
            Dim vOutVal As String = CType(cmFind.ExecuteScalar, String)
            If Not vOutVal Is Nothing Then GetIDByVehiculo = CType(vOutVal, Int64)

        Catch ex As Exception
            HandleError(Me.GetType.Name, "GetIDByVehiculo", ex)
        End Try
    End Function

    Public Function GetIDAndValidation(Optional ByVal pMov As Long = 0, Optional ByVal pAbr As String = "", Optional ByVal pMsg As Boolean = True) As Long
        GetIDAndValidation = 0
        Try
            Dim objMovil As New conMoviles
            If pMov = 0 And pAbr = "" Then
                '--------> Por ahora sin rutina
            Else
                '--------> Valido si existe móvil
                If pMov = 0 Then pMov = objMovil.GetIDByMovil(pAbr)
                If objMovil.Abrir(pMov) Then
                    '-----> Valido si esta de alta operativa
                    If Me.Abrir(Me.GetIDByIndex(pMov)) Then
                        '-----> Valido x perfil
                        GetIDAndValidation = Me.ID
                    Else
                        If pMsg Then MsgBox("El móvil ingresado no se encuentra operativo", MsgBoxStyle.Critical, "Móviles")
                    End If
                Else
                    If pMsg Then MsgBox("El móvil ingresado es inexistente", MsgBoxStyle.Critical, "Móviles")
                End If
            End If
        Catch ex As Exception
            HandleError(Me.GetType.Name, "GetIDAndValidation", ex)
        End Try
    End Function

    Public Function GetDTSugerenciaDespacho(ByVal pSel As Integer, Optional ByVal pGdo As Long = 0, Optional ByVal pLoc As Long = 0) As DataTable

        GetDTSugerenciaDespacho = Nothing

        Try
            Dim SQL As String = ""

            Select Case pSel

                Case 0
                    '-----> Móviles
                    SQL = "SELECT A.ID, B.Movil, C.Descripcion AS TipoMovil, D.Descripcion AS Estado, 0 AS Sel, "
                    SQL = SQL & "A.gpsFecHorTransmision, A.gpsLatitud, A.gpsLongitud, "
                    SQL = SQL & "9999 AS Distancia, 9999 AS Tiempo, SPACE(100) AS DistanciaTiempo, SPACE(10) AS Link "
                    SQL = SQL & "FROM MovilesActuales A "
                    SQL = SQL & "INNER JOIN Moviles B ON (A.MovilId = B.ID) "
                    SQL = SQL & "INNER JOIN TiposMoviles C ON (A.TipoMovilId = C.ID) "
                    SQL = SQL & "INNER JOIN SucesosIncidentes D ON (A.SucesoIncidenteId = D.ID) "
                    If pLoc > 0 Then SQL = SQL & "WHERE A.MovilId IN(SELECT MovilId FROM MovilesLocalidades WHERE (LocalidadId =  " & pLoc & ")) "
                    If pGdo > 0 Then SQL = SQL & "AND A.TipoMovilId IN(SELECT TipoMovilId FROM TiposMovilesGrados WHERE (GradoOperativoId =  " & pGdo & ")) "
                    SQL = SQL & "ORDER BY D.Orden"

                Case 1
                    '-----> Empresas
                    SQL = "SELECT A.ID, B.Movil, A.RazonSocial AS TipoMovil, C.Descripcion AS Estado, 1 AS Sel, "
                    SQL = SQL & "CAST('1980-01-01' AS DATETIME) AS gpsFecHorTransmision, 0 AS gpsLatitud, 0 AS gpsLongitud, "
                    SQL = SQL & "9999 AS Distancia, 9999 AS Tiempo, SPACE(100) AS DistanciaTiempo, SPACE(10) AS Link "
                    SQL = SQL & "FROM Prestadores A "
                    SQL = SQL & "INNER JOIN Moviles B ON (A.ID = B.PrestadorId) "
                    SQL = SQL & "INNER JOIN TiposMoviles C ON (B.TipoMovilId = C.ID) "
                    If pLoc > 0 Then SQL = SQL & "WHERE B.ID IN(SELECT MovilId FROM MovilesLocalidades WHERE (LocalidadId =  " & pLoc & ")) "
                    If pGdo > 0 Then SQL = SQL & "AND B.TipoMovilId IN(SELECT TipoMovilId FROM TiposMovilesGrados WHERE (GradoOperativoId =  " & pGdo & ")) "
                    SQL = SQL & "ORDER BY B.Movil"

                Case 2
                    '-----> Domiciliario
                    SQL = "SELECT A.ID, B.Movil, A.Apellido + ' ' + A.Nombre AS TipoMovil, C.Descripcion AS Estado, 1 AS Sel, "
                    SQL = SQL & "A.gpsFecHorTransmision, A.gpsLatitud, A.gpsLongitud, "
                    SQL = SQL & "9999 AS Distancia, 9999 AS Tiempo, SPACE(100) AS DistanciaTiempo, SPACE(10) AS Link "
                    SQL = SQL & "FROM Personal A "
                    SQL = SQL & "INNER JOIN Moviles B ON (A.ID = B.PersonalId) "
                    SQL = SQL & "INNER JOIN TiposMoviles C ON (B.TipoMovilId = C.ID) "
                    If pLoc > 0 Then SQL = SQL & "WHERE B.ID IN(SELECT MovilId FROM MovilesLocalidades WHERE (LocalidadId =  " & pLoc & ")) "
                    If pGdo > 0 Then SQL = SQL & "AND B.TipoMovilId IN(SELECT TipoMovilId FROM TiposMovilesGrados WHERE (GradoOperativoId =  " & pGdo & ")) "
                    SQL = SQL & "ORDER BY B.Movil"

            End Select

            Dim cmdEqp As New SqlCommand(SQL, cnnsNET(Me.myCnnName), cnnsTransNET(Me.myCnnName))
            Dim dt As New DataTable
            dt.Load(cmdEqp.ExecuteReader)

            GetDTSugerenciaDespacho = dt

        Catch ex As Exception
            HandleError(Me.GetType.Name, "GetDTSugerenciaDespacho", ex)
        End Try
    End Function

End Class
