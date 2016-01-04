Imports System.Data
Imports System.Data.SqlClient
Public Class conPracticas
    Inherits typPracticas
    Public Sub New(Optional ByVal pCnnName As String = "")
        MyBase.New(pCnnName)
    End Sub

    Public Function GetAll() As DataTable

        GetAll = Nothing

        Try

            Dim SQL As String

            SQL = "SELECT ID, Descripcion FROM Practicas "
            SQL = SQL & "ORDER BY Descripcion"

            Dim cmdEmp As New SqlCommand(SQL, cnnsNET(Me.myCnnName), cnnsTransNET(Me.myCnnName))
            Dim dt As New DataTable
            dt.Load(cmdEmp.ExecuteReader)

            GetAll = dt

        Catch ex As Exception
            HandleError(Me.GetType.Name, "GetAll", ex)
        End Try
    End Function


    Public Sub SetDTNomencladorByPractica(ByVal pPra As Int64, ByRef dtNomemclador As DataTable)
        Try
            Dim SQL As String
            SQL = "SELECT pra.NomencladorId, nom.AbreviaturaId, nom.Descripcion, pra.Cantidad "
            SQL = SQL & "FROM PracticasNomenclador pra "
            SQL = SQL & "INNER JOIN Nomenclador nom ON (pra.NomencladorId = nom.ID) "
            SQL = SQL & "WHERE (pra.PracticaId = " & pPra & ") "
            SQL = SQL & "ORDER BY nom.AbreviaturaId"

            Dim cmdBas As New SqlCommand(SQL, cnnsNET(Me.myCnnName), cnnsTransNET(Me.myCnnName))
            Dim dt As New DataTable
            Dim vIdx As Integer
            dt.Load(cmdBas.ExecuteReader)

            For vIdx = 0 To dt.Rows.Count - 1

                Dim dtRow As DataRow = dtNomemclador.NewRow
                Dim vCol As Integer

                For vCol = 0 To dtNomemclador.Columns.Count - 1
                    dtRow(vCol) = dt(vIdx)(vCol)
                Next vCol

                dtNomemclador.Rows.Add(dtRow)

            Next vIdx
        Catch ex As Exception
            HandleError(Me.GetType.Name, "SetDTNomencladorByPractica", ex)
        End Try
    End Sub

    Public Function GetValorVenta(pPra As Int64, pFec As Date) As Decimal
        GetValorVenta = 0
        Try
            Dim objPractica As New conPracticas(Me.myCnnName)
            If objPractica.Abrir(pPra) Then
                If objPractica.ClasificacionId < 2 Then

                    Dim SQL As String
                    Dim vNomVal As Double = 0

                    SQL = "SELECT ROUND(ISNULL(SUM(nom.Cantidad * uni.Importe), 0), 2) "
                    SQL = SQL & "FROM PracticasNomenclador pra "
                    SQL = SQL & "INNER JOIN NomencladorUnidades nom ON (pra.NomencladorId = nom.NomencladorId) "
                    SQL = SQL & "INNER JOIN UnidadesArancelariasVigencias uni ON (nom.UnidadArancelariaId = uni.UnidadArancelariaId) "
                    SQL = SQL & "WHERE (pra.PracticaId = " & pPra & ") AND ('" & DateToSql(pFec) & "' BETWEEN FecDesde AND FecHasta) "

                    Dim cmdNom As New SqlCommand(SQL, cnnsNET(Me.myCnnName), cnnsTransNET(Me.myCnnName))
                    Dim vOutVal As String = CType(cmdNom.ExecuteScalar, String)
                    If Not vOutVal Is Nothing Then
                        vNomVal = CType(vOutVal, Decimal)
                    End If

                    If objPractica.ClasificacionId = 0 Then
                        GetValorVenta = vNomVal
                    Else
                        GetValorVenta = vNomVal + objPractica.ImpAjuste
                    End If

                Else

                    GetValorVenta = objPractica.ImpAjuste
                End If

            End If
            objPractica = Nothing
        Catch ex As Exception
            HandleError(Me.GetType.Name, "GetValorVenta", ex)
        End Try
    End Function

    Public Function Validar(Optional ByVal pMsg As Boolean = True) As Boolean
        Validar = False
        Try
            Dim vRdo As String = ""
            If Me.Descripcion = "" Then vRdo = "Debe determinar el nombre de la práctica"
            If vRdo <> "" Then
                If pMsg Then MsgBox(vRdo, MsgBoxStyle.Critical, Me.Tabla)
            Else
                Validar = True
            End If
        Catch ex As Exception
            HandleError(Me.GetType.Name, "Validar", ex)
        End Try
    End Function
End Class
