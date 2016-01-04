Module modFuncionesGenerales

    Public Function haveProducto(ByVal pPrd As shamanProductos) As Boolean
        Dim vFnd As Boolean = False
        Dim vIdx As Integer = 0

        If Not sysProductos Is Nothing Then

            Do Until vIdx > UBound(sysProductos) Or vFnd
                If Val(sysProductos(vIdx)) = pPrd Then
                    vFnd = True
                Else
                    vIdx = vIdx + 1
                End If
            Loop

        End If

        haveProducto = vFnd

    End Function

    Public Function haveProductoSub(ByVal pPrd As shamanProductos, pNod As String) As Boolean

        Dim vFnd As Boolean = False
        Dim vIdx As Integer = 0

        If pNod = "X" Then

            If Debugger.IsAttached Then
                haveProductoSub = True
            Else
                haveProductoSub = False
            End If

        ElseIf pNod = "22" Then

            If Debugger.IsAttached Then
                haveProductoSub = True
            ElseIf sysHardKey = "10147 41472" Then
                haveProductoSub = True
            Else
                haveProductoSub = False
            End If

        Else

            If Not sysSubExclude Is Nothing Then

                Do Until vIdx > UBound(sysSubExclude) Or vFnd
                    If sysSubExclude(vIdx) = Format(Val(pPrd), "000") & pNod Then
                        vFnd = True
                    Else
                        vIdx = vIdx + 1
                    End If
                Loop

            End If

            haveProductoSub = Not (vFnd)

        End If

    End Function

    Public Function GetEdad(ByVal pFnc As Date) As Integer

        GetEdad = 0

        Try
            Dim vEda As Integer = 0

            If pFnc < Now.Date Then
                vEda = DateDiff(DateInterval.Year, pFnc, Now.Date)
                Try
                    pFnc = CDate(pFnc.Day & "/" & pFnc.Month & "/" & Now.Date.Year)
                    If DateDiff(DateInterval.Day, pFnc, Now.Date) < 0 Then
                        vEda = vEda - 1
                    End If
                Catch ex As Exception
                    GetEdad = vEda
                End Try
            End If

            GetEdad = vEda

        Catch ex As Exception
            HandleError("modFunciones", "GetEdad", ex)
        End Try

    End Function

    Public Function qyVal(ByVal pVal As String) As String
        If pVal.Length > 0 Then
            qyVal = Replace(pVal, "'", "")
        Else
            qyVal = pVal
        End If
    End Function

    Public Function getSINO(pVal As Integer, Optional pUppLow As Boolean = False) As String
        If Not pUppLow Then
            If pVal = 1 Then
                getSINO = "SI"
            Else
                getSINO = "NO"
            End If
        Else
            If pVal = 1 Then
                getSINO = "Si"
            Else
                getSINO = "No"
            End If
        End If
    End Function

    Public Function HaveCoberturaGrado(ByVal pCli As Int64, ByVal pGdo As Int64, ByRef pCos As Double, ByRef pMsgErr As String, Optional ByVal pMsg As Boolean = True, Optional ByVal pClf As gdoClasificacion = gdoClasificacion.gdoIncidente, Optional ByVal pPla As Int64 = 0) As Boolean

        HaveCoberturaGrado = False
        pCos = 0
        pMsgErr = ""

        Try
            Dim objCliente As New conClientes
            Dim objCobertura As conClientesGradosOperativos
            Dim objGrado As New conGradosOperativos
            Dim objCoberturaPlan As conClientesPlanes
            Dim objPlan As conPlanesGradosOperativos
            Dim vCub As Boolean = False
            Dim vErrPla As String = ""

            If objCliente.Abrir(pCli) Then
                '------> Seteo Grado
                If objGrado.Abrir(pGdo) Then
                    If pPla = 0 Then
                        objCobertura = New conClientesGradosOperativos
                        If objCobertura.HaveCoberturaPropia(objCliente.ID) Then
                            If objCobertura.Abrir(objCobertura.GetIDByIndex(objCliente.ID, objGrado.GradoAgrupacionId.ID)) Then
                                If objCobertura.flgCubierto = 1 Then
                                    pCos = objCobertura.CoPago
                                    vCub = True
                                End If
                            End If
                        Else
                            objCoberturaPlan = New conClientesPlanes
                            objCoberturaPlan.GetCobertura(objCliente.ID, objGrado.GradoAgrupacionId.ID, vCub, pCos)
                        End If

                    Else

                        objPlan = New conPlanesGradosOperativos

                        If objPlan.Abrir(objPlan.GetIDByIndex(pPla, pGdo)) Then
                            If objPlan.flgCubierto = 1 Then
                                pCos = objPlan.CoPago
                                vCub = True
                            Else
                                vErrPla = " en plan " & objPlan.PlanId.AbreviaturaId
                            End If
                        End If

                    End If
                End If
            End If

            If vCub Then

                HaveCoberturaGrado = True

            Else

                Select Case pClf
                    Case gdoClasificacion.gdoTraslado : pMsgErr = "El cliente " & objCliente.AbreviaturaId & " no tiene cubierta dicha modalidad de traslado" & vErrPla
                    Case gdoClasificacion.gdoIntDomiciliaria : pMsgErr = "El cliente " & objCliente.AbreviaturaId & " no tiene cubierta dicha prestación" & vErrPla
                    Case Else : pMsgErr = "El cliente " & objCliente.AbreviaturaId & " no tiene cubierto dicho grado" & vErrPla
                End Select

                If pMsg Then
                    MsgBox(pMsgErr, MsgBoxStyle.Exclamation, "Cobertura")
                End If

            End If

        Catch ex As Exception
            HandleError("modFunciones", "HaveCoberturaGrado", ex)
        End Try

    End Function

    Public Function HaveCoberturaPractica(ByVal pCli As Int64, pPra As Int64, pPla As Int64, pPlaCod As String, ByRef pCos As Double, ByRef pMsgErr As String, Optional pMsg As Boolean = False) As Boolean

        HaveCoberturaPractica = False
        pCos = 0
        pMsgErr = ""

        Try

            Dim objCliente As New conClientes
            Dim vCub As Boolean = False

            If objCliente.Abrir(pCli) Then

                Dim objClientesPracticas As New conClientesPracticas
                Dim vOpn As Boolean = objClientesPracticas.Abrir(objClientesPracticas.GetIDByIndex(objCliente.ID, pPra, pPla))

                If Not vOpn And pPla > 0 Then
                    vOpn = objClientesPracticas.Abrir(objClientesPracticas.GetIDByIndex(objCliente.ID, pPra))
                End If

                If vOpn Then
                    If objClientesPracticas.flgCubierto = 1 Then
                        pCos = objClientesPracticas.CoPago
                        vCub = True
                    Else
                        If pPla = 0 Then
                            pMsgErr = "El cliente " & objCliente.AbreviaturaId & " no tiene cubierta dicha práctica"
                        Else
                            pMsgErr = "El plan " & pPlaCod & " del cliente " & objCliente.AbreviaturaId & vbCrLf & "No tiene cubierta dicha práctica"
                        End If
                    End If
                End If

            End If

            If vCub Then
                HaveCoberturaPractica = True
            Else
                If pMsg And pMsgErr <> "" Then
                    MsgBox(pMsgErr, MsgBoxStyle.Critical, "Cobertura")
                End If
            End If

            objCliente = Nothing

        Catch ex As Exception
            HandleError("modFunciones", "HaveCoberturaPractica", ex)
        End Try
    End Function

    Public Sub RunShamanGestion(Optional pUsr As String = "", Optional pPsw As String = "")

        If pUsr = "" Then pUsr = shamanSession.webUser
        If pPsw = "" Then pPsw = shamanSession.webPassword

        Dim vUrl As String = "http://200.49.156.125:57771/ExternalLogin/?user=" & pUsr & "&pass=" & pPsw & "&llave=" & sysHardKey.Replace(" ", "") & "&shex_id=" & shamanSession.ID
        Process.Start(vUrl)

    End Sub

    Public Sub SetGrabacion(ByVal pInc As Decimal, ByRef pObj As conIncidentesLlamados, Optional pAddNew As Boolean = True)
        Try
            If pObj.AgenteId <> "" Then
                pObj.IncidenteId.SetObjectId(pInc)
                pObj.Salvar(pObj)
            Else
                If shamanRing.GrabacionId <> "" And pAddNew Then
                    '-----> Pregunto si quiere linkear el llamado...
                    Dim objLlamado As New conIncidentesLlamados

                    If objLlamado.GetIDByIndex(shamanRing.GrabacionId, shamanRing.AgenteId, shamanRing.NroInterno) = 0 Then

                        If Math.Abs(DateDiff(DateInterval.Minute, shamanRing.regFechaHora, Now)) <= 5 Then
                            If MsgBox("¿ Desea vincular la última llamada recibida a este servicio ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton1, "Grabaciones") = MsgBoxResult.Yes Then

                                pObj.CleanProperties(pObj)
                                pObj.IncidenteId.SetObjectId(pInc)
                                pObj.AgenteId = shamanRing.AgenteId
                                pObj.DNIS = shamanRing.DNIS
                                pObj.Campania = shamanRing.Campania
                                pObj.ANI = shamanRing.ANI
                                pObj.NroInterno = shamanRing.NroInterno
                                pObj.GrabacionId = shamanRing.GrabacionId

                                pObj.Salvar(pObj)

                            End If
                        End If

                    End If
                End If
            End If
        Catch ex As Exception
            HandleError("modFunciones", "SetGrabacion", ex)
        End Try
    End Sub

    Public Function CloneDT(dtClone As DataTable) As DataTable

        CloneDT = Nothing

        Try
            Dim dtNew As DataTable = dtClone.Clone()

            For vPerIdx = 0 To dtClone.Rows.Count - 1

                Dim desRow As DataRow = dtNew.NewRow()
                Dim sourceRow As DataRow = dtClone.Rows(vPerIdx)

                desRow.ItemArray = sourceRow.ItemArray.Clone()

                dtNew.Rows.Add(desRow)

            Next

            CloneDT = dtNew

        Catch ex As Exception
            HandleError("modFunciones", "SetGrabacion", ex)
        End Try

    End Function


End Module