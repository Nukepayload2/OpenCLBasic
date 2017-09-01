Imports System.IO
Imports OpenCL.Net

Public Class OpenCLDevice
    Implements IOpenCLResourceCreator

    Private ReadOnly _id As Device

    Public Sub New(device As Device)
        _id = device
    End Sub

    Public ReadOnly Property Device As Device Implements IOpenCLResourceCreator.Device
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
                                Where GetDeviceInfo(d, DeviceInfo.ImageSupport).CastTo(Of Bool) = Bool.True
                    Console.Write(New StreamReader(GetDeviceInfo(dev, DeviceInfo.Vendor).AsStream).ReadToEnd)
                    Console.Write(" - ")
                    Console.WriteLine(New StreamReader(GetDeviceInfo(dev, DeviceInfo.Name).AsStream).ReadToEnd)
                    Return New OpenCLDevice(dev)
                Next
            Catch ex As Exception
            End Try
        Next
        Throw New DeviceNotSupportedException("找不到带有图像处理功能并且支持 OpenGL 的显卡。")
    End Function

End Class
