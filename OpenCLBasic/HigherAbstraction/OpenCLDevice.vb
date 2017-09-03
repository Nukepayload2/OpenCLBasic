Public Class OpenCLDevice
    Implements IOpenCLResourceCreator

    Private ReadOnly _id As DeviceHandle

    Public Sub New(device As DeviceHandle)
        _id = device
    End Sub

    Public ReadOnly Property Device As DeviceHandle Implements IOpenCLResourceCreator.Device
        Get
            Return _id
        End Get
    End Property

    Public Shared Function GetPrimaryGpuDevice() As OpenCLDevice
        Dim platforms = GetPlatformIDs()
        For Each platform In platforms
            Try
                Dim deviceIds = GetDeviceIDs(platform, DeviceType.Gpu)
                For Each dev In From d In deviceIds
                                Where GetDeviceInfo(d, DeviceInfo.ImageSupport).Read(Of Integer) = 1
                    Console.Write(GetDeviceInfo(dev, DeviceInfo.Vendor).ToAnsiString)
                    Console.Write(" - ")
                    Console.WriteLine(GetDeviceInfo(dev, DeviceInfo.Name).ToAnsiString)
                    Return New OpenCLDevice(dev)
                Next
            Catch ex As Exception
            End Try
        Next
        Throw New DeviceNotSupportedException("找不到带有图像处理功能并且支持 OpenGL 的显卡。")
    End Function

End Class
