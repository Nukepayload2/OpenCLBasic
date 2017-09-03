Imports System.Runtime.InteropServices

Public Structure ContextHandle
    Public Value As IntPtr
End Structure

Public Structure ProgramHandle
    Public Value As IntPtr
End Structure

Public Structure SizeT
    Public Value As IntPtr
    Public Shared Widening Operator CType(value As Integer) As SizeT
        Return New SizeT With {.Value = New IntPtr(value)}
    End Operator
    Public Shared Widening Operator CType(value As Long) As SizeT
        Return New SizeT With {.Value = New IntPtr(value)}
    End Operator
    Public Shared Widening Operator CType(value As SizeT) As Long
        Return value.Value.ToInt64
    End Operator
    Public Shared Narrowing Operator CType(value As SizeT) As Integer
        Return value.Value.ToInt32
    End Operator
End Structure

Public Structure ClBuffer
    Public Value As IntPtr
End Structure

Public Structure EventHandle
    Public Value As IntPtr
End Structure

Public Structure CommandQueueHandle
    Public Value As IntPtr
End Structure

Public Structure DeviceHandle
    Public Value As IntPtr
End Structure

Public Structure PlatformHandle
    Public Value As IntPtr
End Structure

Public Structure SamplerHandle
    Public Value As IntPtr
End Structure

Public Structure KernelHandle
    Public Value As IntPtr
End Structure

Public Structure InfoBuffer
    Public Ptr As IntPtr
    Public Size As Integer
    Friend _storage As Byte()

    Public Sub New(storage As Byte())
        If storage Is Nothing Then
            Throw New ArgumentNullException(NameOf(storage))
        End If

        _storage = storage
        Ptr = Marshal.UnsafeAddrOfPinnedArrayElement(storage, 0)
        Size = storage.Length
    End Sub
    ''' <summary>
    ''' 创建一个托管的数组，并用这个数组的地址和长度初始化一个信息缓冲区。
    ''' </summary>
    Public Shared Function Alloc(size As Integer) As InfoBuffer
        If size <= 0 Then
            Throw New ArgumentOutOfRangeException(NameOf(size))
        End If
        Dim buffer As New InfoBuffer
        ReDim buffer._storage(size - 1)
        buffer.Size = size
        buffer.Ptr = Marshal.UnsafeAddrOfPinnedArrayElement(buffer._storage, 0)
        Return buffer
    End Function
    ''' <summary>
    ''' 让垃圾回收器快点回收信息缓冲区所用的托管数组。
    ''' </summary>
    Public Sub Free()
        _storage = Nothing
        Ptr = IntPtr.Zero
        Size = 0
    End Sub

End Structure

Public Structure ImageFormat
    Public ChannelOrder As ChannelOrder
    Public ChannelType As ChannelType

    Public Sub New(channelOrder As ChannelOrder, channelType As ChannelType)
        Me.ChannelOrder = channelOrder
        Me.ChannelType = channelType
    End Sub
End Structure

Public Structure ContextProperty
    Public PropertyName As ContextProperties
    Public PropertyValue As IntPtr
End Structure

Public Delegate Sub ContextNotify(errInfo As String, data As Byte(), cb As IntPtr, userData As IntPtr)

Public Delegate Sub ProgramNotify(program As ProgramHandle, userData As IntPtr)

Public Delegate Sub NativeKernel(args As IntPtr)

Public Delegate Function RetainHandleHandler(handle As IntPtr) As ErrorCode

Public Delegate Function ReleaseHandleHandler(handle As IntPtr) As ErrorCode

Public Enum ErrorCode
    Success = 0
    Unknown = 1
    DeviceNotFound = -1
    DeviceNotAvailable = -2
    CompilerNotAvailable = -3
    MemObjectAllocationFailure = -4
    OutOfResources = -5
    OutOfHostMemory = -6
    ProfilingInfoNotAvailable = -7
    MemCopyOverlap = -8
    ImageFormatMismatch = -9
    ImageFormatNotSupported = -10
    BuildProgramFailure = -11
    MapFailure = -12
    InvalidValue = -30
    InvalidDeviceType = -31
    InvalidPlatform = -32
    InvalidDevice = -33
    InvalidContext = -34
    InvalidQueueProperties = -35
    InvalidCommandQueue = -36
    InvalidHostPtr = -37
    InvalidMemObject = -38
    InvalidImageFormatDescriptor = -39
    InvalidImageSize = -40
    InvalidSampler = -41
    InvalidBinary = -42
    InvalidBuildOptions = -43
    InvalidProgram = -44
    InvalidProgramExecutable = -45
    InvalidKernelName = -46
    InvalidKernelDefinition = -47
    InvalidKernel = -48
    InvalidArgIndex = -49
    InvalidArgValue = -50
    InvalidArgSize = -51
    InvalidKernelArgs = -52
    InvalidWorkDimension = -53
    InvalidWorkGroupSize = -54
    InvalidWorkItemSize = -55
    InvalidGlobalOffset = -56
    InvalidEventWaitList = -57
    InvalidEvent = -58
    InvalidOperation = -59
    InvalidGlObject = -60
    InvalidBufferSize = -61
    InvalidMipLevel = -62
End Enum

Public Enum ProfilingInfo
    Queued = &H1280
    Submit = &H1281
    Start = &H1282
    Ended = &H1283
End Enum

Public Enum SamplerInfo As UInteger
    ReferenceCount = &H1150
    Context = &H1151
    NormalizedCoords = &H1152
    AddressingMode = &H1153
    FilterMode = &H1154
End Enum

Public Enum FilterMode As UInteger
    Nearest = &H1140
    Linear = &H1141
End Enum

Public Enum AddressingMode As UInteger
    None = &H1130
    ClampToEdge = &H1131
    Clamp = &H1132
    Repeat = &H1133
End Enum

Public Enum ExecutionStatus
    Complete = &H0
    Running = &H1
    Submitted = &H2
    Queued = &H3
End Enum

Public Enum EventInfo
    CommandQueue = &H11D0
    CommandType = &H11D1
    ReferenceCount = &H11D2
    CommandExecutionStatus = &H11D3
End Enum

<Flags>
Public Enum MapFlags
    Read = 1
    Write = 2
End Enum

Public Enum KernelWorkGroupInfo
    WorkGroupSize = &H11B0
    CompileWorkGroupSize = &H11B1
    LocalMemSize = &H11B2
End Enum

Public Enum KernelInfo
    FunctionName = &H1190
    NumArgs = &H1191
    ReferenceCount = &H1192
    Context = &H1193
    Program = &H1194
End Enum

Public Enum CommandQueueInfo
    Context = &H1090
    Device = &H1091
    ReferenceCount = &H1092
    Properties = &H1093
End Enum

<Flags>
Public Enum CommandQueueProperties As ULong
    None = 0
    OutOfOrderExecModeEnable = (1 << 0)
    ProfilingEnable = (1 << 1)
End Enum

Public Enum BuildStatus
    Success = 0
    None = -1
    ErrorOccurred = -2
    InProgress = -3
End Enum

Public Enum ProgramBuildInfo As UInteger
    Status = &H1181
    Options = &H1182
    Log = &H1183
End Enum

Public Enum ProgramInfo As UInteger
    ReferenceCount = &H1160
    Context = &H1161
    NumDevices = &H1162
    Devices = &H1163
    Source = &H1164
    BinarySizes = &H1165
    Binaries = &H1166
End Enum

Public Enum ImageInfo As UInteger
    Format = &H1110
    ElementSize = &H1111
    RowPitch = &H1112
    SlicePitch = &H1113
    Width = &H1114
    Height = &H1115
    Depth = &H1116
End Enum

Public Enum MemInfo As UInteger
    Type = &H1100
    Flags = &H1101
    Size = &H1102
    HostPtr = &H1103
    MapCount = &H1104
    ReferenceCount = &H1105
    Context = &H1106
End Enum

Public Enum MemObjectType As UInteger
    Buffer = &H10F0
    Image2D = &H10F1
    Image3D = &H10F2
End Enum

<Flags>
Public Enum MemFlags As ULong
    None = 0
    ReadWrite = (1 << 0)
    [WriteOnly] = (1 << 1)
    [ReadOnly] = (1 << 2)
    UseHostPtr = (1 << 3)
    AllocHostPtr = (1 << 4)
    CopyHostPtr = (1 << 5)
End Enum

Public Enum ContextInfo As UInteger
    ReferenceCount = &H1080
    Devices = &H1081
    Properties = &H1082
End Enum

Public Enum ChannelType As UInteger
    Snorm_Int8 = &H10D0
    Snorm_Int16 = &H10D1
    Unorm_Int8 = &H10D2
    Unorm_Int16 = &H10D3
    Unorm_Short565 = &H10D4
    Unorm_Short555 = &H10D5
    Unorm_Int101010 = &H10D6
    Signed_Int8 = &H10D7
    Signed_Int16 = &H10D8
    Signed_Int32 = &H10D9
    Unsigned_Int8 = &H10DA
    Unsigned_Int16 = &H10DB
    Unsigned_Int32 = &H10DC
    HalfFloat = &H10DD
    Float = &H10DE
End Enum

Public Enum ChannelOrder As UInteger
    R = &H10B0
    A = &H10B1
    RG = &H10B2
    RA = &H10B3
    RGB = &H10B4
    RGBA = &H10B5
    BGRA = &H10B6
    ARGB = &H10B7
    Intensity = &H10B8
    Luminance = &H10B9
End Enum

Public Enum ContextProperties As UInteger
    Platform = &H1084
End Enum

Public Enum DeviceInfo As UInteger
    Type = &H1000
    VendorId = &H1001
    MaxComputeUnits = &H1002
    MaxWorkItemDimensions = &H1003
    MaxWorkGroupSize = &H1004
    MaxWorkItemSizes = &H1005
    PreferredVectorWidthChar = &H1006
    PreferredVectorWidthShort = &H1007
    PreferredVectorWidthInt = &H1008
    PreferredVectorWidthLong = &H1009
    PreferredVectorWidthFloat = &H100A
    PreferredVectorWidthDouble = &H100B
    MaxClockFrequency = &H100C
    AddressBits = &H100D
    MaxReadImageArgs = &H100E
    MaxWriteImageArgs = &H100F
    MaxMemAllocSize = &H1010
    Image2DMaxWidth = &H1011
    Image2DMaxHeight = &H1012
    Image3DMaxWidth = &H1013
    Image3DMaxHeight = &H1014
    Image3DMaxDepth = &H1015
    ImageSupport = &H1016
    MaxParameterSize = &H1017
    MaxSamplers = &H1018
    MemBaseAddrAlign = &H1019
    MinDataTypeAlignSize = &H101A
    SingleFpConfig = &H101B
    GlobalMemCacheType = &H101C
    GlobalMemCachelineSize = &H101D
    GlobalMemCacheSize = &H101E
    GlobalMemSize = &H101F
    MaxConstantBufferSize = &H1020
    MaxConstantArgs = &H1021
    LocalMemType = &H1022
    LocalMemSize = &H1023
    ErrorCorrectionSupport = &H1024
    ProfilingTimerResolution = &H1025
    EndianLittle = &H1026
    Available = &H1027
    CompilerAvailable = &H1028
    ExecutionCapabilities = &H1029
    QueueProperties = &H102A
    Name = &H102B
    Vendor = &H102C
    DriverVersion = &H102D
    Profile = &H102E
    Version = &H102F
    Extensions = &H1030
    Platform = &H1031
End Enum

<Flags>
Public Enum DeviceType As ULong
    [Default] = (1 << 0)
    Cpu = (1 << 1)
    Gpu = (1 << 2)
    Accelerator = (1 << 3)
    All = &HFFFFFFFFUI
End Enum

Public Enum PlatformInfo As UInteger
    Profile = &H900
    Version = &H901
    Name = &H902
    Vendor = &H903
    Extensions = &H904
End Enum