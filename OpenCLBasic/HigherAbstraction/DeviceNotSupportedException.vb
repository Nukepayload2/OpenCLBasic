Public Class DeviceNotSupportedException
    Inherits NotSupportedException

    Sub New(message As String)
        MyBase.New(message)
    End Sub
End Class
