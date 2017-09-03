Public Class ClException
    Inherits Exception
    Public Sub New(errorCode As ErrorCode)
        MyBase.New(errorCode.ToString)
        HResult = errorCode
    End Sub

    Public Sub New(errorCode As ErrorCode, message As String)
        MyBase.New($"{errorCode}: {message}")
    End Sub

    Public Sub New(errorCode As ErrorCode, message As String, inner As Exception)
        MyBase.New($"{errorCode}: {message}", inner)
    End Sub
End Class
