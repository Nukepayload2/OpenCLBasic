Imports System.Runtime.CompilerServices
Imports OpenCL.Net
Imports ClException = OpenCL.Net.Cl.Exception

<HideModuleName>
Partial Public Module ClMethods

    Private errCode As ErrorCode

    Private Sub CheckErr(errCode As ErrorCode, <CallerMemberName> Optional method As String = Nothing)
        If errCode <> ErrorCode.Success Then
            Throw New ClException(errCode, method)
        End If
    End Sub

End Module
