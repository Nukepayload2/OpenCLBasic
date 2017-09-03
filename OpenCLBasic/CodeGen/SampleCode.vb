Option Strict Off
Imports System.Runtime.CompilerServices
Imports System.Runtime.InteropServices
Imports OpenCLBasic.FakeRuntime

Public Module SampleProgram

    Const sampler As Sampler = CLK.NORMALIZED_COORDS_FALSE Or CLK.ADDRESS_CLAMP Or CLK.FILTER_NEAREST

    ' 比较 BGRA32 像素格式的图片 A 和 B。如果颜色不一样, 则输出与 A 反色的像素点。否则输出透明像素点。
    ' Public -> __kernel, ByVal -> __read_only, <Out> ByRef -> __write_only, GetGlobalId 变量 -> const
    ' 其中的内容应该被阻止直接执行。
    <MethodImpl(MethodImplOptions.ForwardRef)>
    Public Sub ImageDiffBlend(ByVal imageA As Image2D, ByVal imageB As Image2D, <Out> ByRef imageC As Image2D)
        Dim x As Integer = GetGlobalId(0)
        Dim y As Integer = GetGlobalId(1)

        Dim coord As Int2 = (x, y)

        Dim A As UInt4 = ReadImageUI(imageA, sampler, coord)
        Dim B As UInt4 = ReadImageUI(imageB, sampler, coord)
        Dim C As UInt4 = 0

        If A <> B Then
            C = -A
            C.w = 255
        End If

        WriteImageUI(imageC, coord, A - B)
    End Sub
End Module
