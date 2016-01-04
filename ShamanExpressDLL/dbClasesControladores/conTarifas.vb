Imports System.Data
Imports System.Data.SqlClient
Public Class conTarifas
    Inherits typTarifas
    Public Sub New(Optional ByVal pCnnName As String = "")
        MyBase.New(pCnnName)
    End Sub
    Public Function GetAll(Optional pLiq As Boolean = False, Optional ByVal pAct As Integer = 1) As DataTable

        GetAll = Nothing

        Try
            Dim SQL As String

            SQL = "SELECT ID, AbreviaturaId, Descripcion FROM Tarifas "
            SQL = SQL & "WHERE (flgLiquidacion = " & setBoolToInt(pLiq) & ") "
            If pAct = 1 Then SQL = SQL & "AND (Activo = 1) "
            If pAct = 2 Then SQL = SQL & "AND (Activo = 0) "
            SQL = SQL & "ORDER BY AbreviaturaId"

            Dim cmdEqp As New SqlCommand(SQL, cnnsNET(Me.myCnnName), cnnsTransNET(Me.myCnnName))
            Dim dt As New DataTable
            dt.Load(cmdEqp.ExecuteReader)

            GetAll = dt

        Catch ex As Exception
            HandleError(Me.GetType.Name, "GetAll", ex)
        End Try
    End Function

    Public Function GetConceptoId(ByVal pTar As Int64, ByVal pGdo As Int64) As Int64
        GetConceptoId = 0
        Try
            Dim SQL As String

            SQL = "SELECT TOP 1 tar.ConceptoFacturacionId FROM TarifasPrestaciones tar INNER JOIN GradosOperativos gdo ON (tar.ConceptoFacturacionId = gdo.ConceptoFacturacion1Id) "
            SQL = SQL & "WHERE (tar.TarifaId = " & pTar & ") AND (gdo.ID = " & pGdo & ") "

            Dim cmFind As New SqlCommand(SQL, cnnsNET(Me.myCnnName), cnnsTransNET(Me.myCnnName))
            Dim vOutVal As String = CType(cmFind.ExecuteScalar, String)

            If vOutVal Is Nothing Then

                SQL = "SELECT TOP 1 tar.ConceptoFacturacionId FROM TarifasPrestaciones tar INNER JOIN GradosOperativos gdo ON (tar.ConceptoFacturacionId = gdo.ConceptoFacturacion2Id) "
                SQL = SQL & "WHERE (tar.TarifaId = " & pTar & ") AND (gdo.ID = " & pGdo & ") "

                cmFind.CommandText = SQL
                vOutVal = CType(cmFind.ExecuteScalar, String)

                If vOutVal Is Nothing Then

                    SQL = "SELECT ConceptoFacturacion1Id FROM GradosOperativos WHERE (ID = " & pGdo & ")"

                    cmFind.CommandText = SQL
                    vOutVal = CType(cmFind.ExecuteScalar, String)

                    If vOutVal Is Nothing Then
                        GetConceptoId = 0
                    Else
                        GetConceptoId = CType(vOutVal, Int64)
                    End If
                Else
                    GetConceptoId = CType(vOutVal, Int64)
                End If
            Else
                GetConceptoId = CType(vOutVal, Int64)
            End If

        Catch ex As Exception
            HandleError(Me.GetType.Name, "GetConceptoId", ex)
        End Try
    End Function

    Public Function Valorizar(ByVal pTar As Long, ByVal pCon As Long, ByVal pKmt As Long, Optional ByVal pNoc As Boolean = False, Optional ByVal pPed As Boolean = False, Optional ByVal pDer As Boolean = False, Optional ByVal pDem As Long = 0) As Double
        Valorizar = 0
        Try
            Dim SQL As String, vId As Int64, objValores As New conTarifasPrestaciones(Me.myCnnName), vVal As Double = 0
            Valorizar = 0
            SQL = "SELECT ID FROM TarifasPrestaciones WHERE (TarifaId = " & pTar & ") AND (ConceptoFacturacionId = " & pCon & ") "
            SQL = SQL & "AND (KmDesde <= " & pKmt & ") AND (KmHasta >= " & pKmt & ") "

            Dim cmFind As New SqlCommand(SQL, cnnsNET(Me.myCnnName), cnnsTransNET(Me.myCnnName))
            Dim vOutVal As String = CType(cmFind.ExecuteScalar, String)

            If vOutVal Is Nothing Then

                SQL = "SELECT ID FROM TarifasPrestaciones WHERE (TarifaId = " & pTar & ") AND (ConceptoFacturacionId = " & pCon & ") "
                SQL = SQL & "ORDER BY KmDesde DESC"

                cmFind.CommandText = SQL
                vOutVal = CType(cmFind.ExecuteScalar, String)

                If vOutVal Is Nothing Then
                    Exit Function
                End If

            End If

            vId = CType(vOutVal, Int64)

            If objValores.Abrir(vId) Then
                vVal = objValores.Importe
                '--------> Km Excedente
                If pKmt > objValores.KmHasta Then
                    vVal = vVal + ((pKmt - objValores.KmHasta) * objValores.ImpKmExcedente)
                End If
                '--------> Espera
                Dim vHor As Integer = Int(pDem / 60), vMed As Integer = pDem - (vHor * 60), vFraMed As Boolean = False
                If vMed >= 46 Then
                    vHor = vHor + 1
                ElseIf vMed > 16 Then
                    vFraMed = True
                End If
                vVal = vVal + (objValores.ImpDemora * vHor)
                If vFraMed Then vVal = vVal + (objValores.ImpDemora / 2)
                '--------> Recargos
                If pNoc Then vVal = vVal + ((objValores.Importe * objValores.RecNocturno) / 100)
                If pPed Then vVal = vVal + ((objValores.Importe * objValores.RecPediatrico) / 100)
                If pDer Then vVal = vVal + ((objValores.Importe * objValores.RecDerivacion) / 100)
                '-------> Resultado
                Valorizar = Math.Round(vVal, 2)
            End If
            objValores = Nothing
        Catch ex As Exception
            HandleError(Me.GetType.Name, "Valorizar", ex)
        End Try
    End Function

    Public Function GetAlias(ByVal pTar As Long, ByVal pCon As Long, ByVal pKmt As Long, Optional ByVal pRel As Boolean = True) As String
        GetAlias = ""
        Try
            Dim SQL As String, vId As Int64, objValores As New conTarifasPrestaciones(Me.myCnnName), vVal As Double = 0

            SQL = "SELECT ID FROM TarifasPrestaciones WHERE (TarifaId = " & pTar & ") AND (ConceptoFacturacionId = " & pCon & ") "
            SQL = SQL & "AND (KmDesde <= " & pKmt & ") AND (KmHasta >= " & pKmt & ") "

            Dim cmFind As New SqlCommand(SQL, cnnsNET(Me.myCnnName), cnnsTransNET(Me.myCnnName))
            Dim vOutVal As String = CType(cmFind.ExecuteScalar, String)

            If vOutVal Is Nothing Then

                SQL = "SELECT ID FROM TarifasPrestaciones WHERE (TarifaId = " & pTar & ") AND (ConceptoFacturacionId = " & pCon & ") "
                SQL = SQL & "ORDER BY KmDesde DESC"

                cmFind.CommandText = SQL
                vOutVal = CType(cmFind.ExecuteScalar, String)

                If vOutVal Is Nothing Then
                    Exit Function
                End If

            End If

            vId = CType(vOutVal, Int64)

            If objValores.Abrir(vId) Then

                If pRel Then
                    GetAlias = objValores.Alias1
                Else
                    GetAlias = objValores.Alias2
                End If
            End If
            objValores = Nothing

        Catch ex As Exception
            HandleError(Me.GetType.Name, "GetAlias", ex)
        End Try
    End Function

    Public Function Validar(Optional ByVal pMsg As Boolean = True) As Boolean
        Validar = False
        Try
            Dim vRdo As String = ""
            Validar = True
            If Me.AbreviaturaId = "" Then vRdo = "Debe determinar el código de la tarifa"
            If Me.Descripcion = "" And vRdo = "" Then vRdo = "Debe determinar la descripción de la tarifa"
            If vRdo <> "" Then
                Validar = False
                If pMsg Then MsgBox(vRdo, MsgBoxStyle.Critical, Me.Tabla)
            End If
        Catch ex As Exception
            HandleError(Me.GetType.Name, "Validar", ex)
        End Try
    End Function

    Public Function GetKilometros(ByVal pTar As Long, ByVal pInc As Long, ByVal pVij As String) As Long
        GetKilometros = 0
        Try
            Dim vDesTip As Integer = 0, vDesAnx As Integer = 0
            Dim vHasTip As Integer = 0, vHasAnx As Integer = 0
            Select Case pVij
                Case "IDA"
                    vHasTip = 1
                Case "VUE"
                    vDesTip = 1
                    vHasTip = 0
                Case "AN1"
                    vHasTip = 2
                    vHasAnx = 1
                Case Else
                    vDesTip = 2
                    vDesAnx = Val(pVij.Substring(3, 1)) - 1
                    vHasTip = 2
                    vHasAnx = Val(pVij.Substring(3, 1))
            End Select
            '---------> Obtengo localidades
            Dim vLocOri As Long = GetLocalidadId(pInc, vDesTip, vDesAnx)
            Dim vLocDst As Long = GetLocalidadId(pInc, vHasTip, vHasAnx)
            '---------> Obtengo KMT
            Dim objDistancia As New conDistancias(Me.myCnnName)
            Dim objTarifa As New conTarifas(Me.myCnnName)
            If objTarifa.Abrir(pTar) Then
                GetKilometros = objDistancia.GetDistancia(vLocOri, vLocDst, , objTarifa.LocalidadOrigenId.ID)
            Else
                GetKilometros = objDistancia.GetDistancia(vLocOri, vLocDst)
            End If
            objTarifa = Nothing
            objDistancia = Nothing
        Catch ex As Exception
            HandleError(Me.GetType.Name, "GetKilometros", ex)
        End Try
    End Function
    Private Function GetLocalidadId(ByVal pInc As Long, ByVal pTdm As Long, ByVal pAnx As Long) As Long
        GetLocalidadId = 0
        Try
            Dim objDomicilio As New conIncidentesDomicilios(Me.myCnnName)
            If objDomicilio.Abrir(objDomicilio.GetIDByIndex(pInc, pTdm, pAnx)) Then
                GetLocalidadId = objDomicilio.LocalidadId.ID
            End If
            objDomicilio = Nothing
        Catch ex As Exception
            HandleError(Me.GetType.Name, "GetLocalidadId", ex)
        End Try
    End Function
    Public Function IsNocturno(ByVal pFhr As DateTime) As Boolean
        IsNocturno = False
        Try
            If pFhr.Year > 1940 Then
                Dim vNocDes As DateTime = pFhr.Date & " " & shamanConfig.hsNocDesde & ":00"
                Dim vNocHas As DateTime = pFhr.Date & " " & shamanConfig.hsNocHasta & ":59"
                If pFhr >= vNocDes Or pFhr <= vNocHas Then
                    IsNocturno = True
                End If
            End If
        Catch ex As Exception
            HandleError(Me.GetType.Name, "IsNocturno", ex)
        End Try
    End Function

    Public Function IsDerivado(ByVal pInc As Long) As Boolean

        IsDerivado = False

        Try
            Dim SQL As String
            SQL = "SELECT vij.ID FROM IncidentesViajes vij "
            SQL = SQL & "INNER JOIN IncidentesDomicilios dom ON (vij.IncidenteDomicilioId = dom.ID) "
            SQL = SQL & "INNER JOIN Incidentes inc ON (dom.IncidenteId = inc.ID) "
            SQL = SQL & "INNER JOIN GradosOperativos gdo ON (inc.GradoOperativoId = gdo.ID) "
            SQL = SQL & "WHERE (inc.ID = " & pInc & ") AND (vij.ViajeId = 'DER') AND (gdo.ClasificacionId = 0) "

            Dim cmFind As New SqlCommand(SQL, cnnsNET(Me.myCnnName), cnnsTransNET(Me.myCnnName))
            If cmFind.ExecuteScalar > 0 Then IsDerivado = True

        Catch ex As Exception
            HandleError(Me.GetType.Name, "IsDerivado", ex)
        End Try
    End Function
End Class
