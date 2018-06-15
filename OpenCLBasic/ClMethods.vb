Imports System.Runtime.CompilerServices
Imports OpenCLBasic.Native

<HideModuleName>
Partial Public Module ClMethods

    Private errCode As ErrorCode

    Private Sub CheckErr(errCode As ErrorCode, <CallerMemberName> Optional method As String = Nothing)
        If errCode <> ErrorCode.Success Then
            Throw New ClException(errCode, method)
        End If
    End Sub

    Public Function GetPlatformIDs() As PlatformHandle()
        Dim platformCount As UInteger

        errCode = clGetPlatformIDs(0, Nothing, platformCount)
        CheckErr(errCode)

        Dim platformIds = New PlatformHandle(CInt(platformCount) - 1) {}
        errCode = clGetPlatformIDs(platformCount, platformIds, platformCount)

        CheckErr(errCode)
        Return platformIds
    End Function

    <Extension>
    Public Function GetDeviceIDs(platform As PlatformHandle, deviceType As DeviceType) As DeviceHandle()
        Dim deviceCount As UInteger
        errCode = clGetDeviceIDs(platform, deviceType, 0, Nothing, deviceCount)

        Dim deviceIds = New DeviceHandle(CInt(deviceCount) - 1) {}
        errCode = clGetDeviceIDs(platform, deviceType, deviceCount, deviceIds, deviceCount)

        CheckErr(errCode)
        Return deviceIds
    End Function

    <Extension>
    Public Function GetDeviceInfo(
        device As DeviceHandle,
        paramKind As DeviceInfo
    ) As InfoBuffer
        Dim size As SizeT
        errCode = clGetDeviceInfo(device, paramKind, 0, Nothing, size)
        Dim sizeInt32 = size.SignedValue.ToInt32

        Dim info = InfoBuffer.Alloc(sizeInt32)
        errCode = clGetDeviceInfo(device, paramKind, size, info.Ptr, size)

        CheckErr(errCode)
        Return info
    End Function

    <Extension>
    Public Function GetProgramBuildInfo(
        program As ProgramHandle,
        device As DeviceHandle,
        paramKind As ProgramBuildInfo
    ) As InfoBuffer
        Dim size As SizeT
        errCode = clGetProgramBuildInfo(program, device, paramKind, 0, Nothing, size)
        Dim sizeInt32 = size.SignedValue.ToInt32

        Dim info = InfoBuffer.Alloc(sizeInt32)
        errCode = clGetProgramBuildInfo(program, device, paramKind, size, info.Ptr, size)

        CheckErr(errCode)
        Return info
    End Function
End Module
