Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.IO
Imports System.Reflection
Imports System.Runtime.InteropServices
Imports System.Text
Imports OpenCLBasic

Public Class ImageDiffBlendCalc
    Implements IImageProc

    Private ReadOnly _session As New OpenCLCalculationSession
    Private ReadOnly _method As OpenCLMethod

    Sub New()
        Dim programSource As String
        Using sr As New StreamReader([GetType].GetTypeInfo.Assembly.GetManifestResourceStream("OpenCLBasic.Demo.ImageDiffBlendCalc.cl"), Encoding.UTF8)
            programSource = sr.ReadToEnd
        End Using
        _method = OpenCLMethod.Compile(_session, programSource, "ImageDiffBlend")
    End Sub

    ''' <summary>
    ''' 比较两张大小一样的 Format32bppArgb 位图。
    ''' </summary>
    Public Function Invoke(imageA As Bitmap, imageB As Bitmap) As Bitmap Implements IImageProc.Invoke
        ' A
        Dim inputImgWidth = imageA.Width
        Dim inputImgHeight = imageA.Height
        If imageA.PixelFormat <> PixelFormat.Format32bppArgb Then
            Throw New NotSupportedException("只支持 PixelFormat.Format32bppArgb。")
        End If
        Dim imageRegion As New Rectangle(0, 0, imageA.Width, imageA.Height)
        Dim imageAData = imageA.LockBits(imageRegion, ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb)

        ' B
        If imageB.PixelFormat <> PixelFormat.Format32bppArgb Then
            Throw New NotSupportedException("只支持 PixelFormat.Format32bppArgb。")
        End If
        Debug.Assert(imageRegion = New Rectangle(0, 0, imageB.Width, imageB.Height), "这两张图片应该有一样的尺寸")
        Dim imageBData = imageB.LockBits(imageRegion, ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb)

        ' C
        Dim imageC As New Bitmap(inputImgWidth, inputImgHeight, PixelFormat.Format32bppArgb)
        Dim imageCData = imageC.LockBits(imageRegion, ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb)

        ' 调用
        Using cl = _method.CreateCommandList
            cl.InputOutputBufferElementSize = Marshal.SizeOf(Of UInteger)
            cl.LoadInputAligned(imageAData.Scan0, imageAData.Stride * imageAData.Height)
            cl.LoadInputAligned(imageBData.Scan0, imageBData.Stride * imageBData.Height)
            cl.LoadOutputAligned(imageCData.Scan0, imageCData.Stride * imageCData.Height)
            cl.CallOneDimensionAligned()
        End Using

        ' 释放
        imageA.UnlockBits(imageAData)
        imageB.UnlockBits(imageBData)
        imageC.UnlockBits(imageCData)

        Return imageC
    End Function

#Region "IDisposable Support"
    Private disposedValue As Boolean ' 要检测冗余调用

    ' IDisposable
    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not disposedValue Then
            If disposing Then
                ' TODO: 释放托管状态(托管对象)。
                _session.Dispose()
                _method.Dispose()
            End If

            ' TODO: 释放未托管资源(未托管对象)并在以下内容中替代 Finalize()。
            ' TODO: 将大型字段设置为 null。
        End If
        disposedValue = True
    End Sub

    ' TODO: 仅当以上 Dispose(disposing As Boolean)拥有用于释放未托管资源的代码时才替代 Finalize()。
    'Protected Overrides Sub Finalize()
    '    ' 请勿更改此代码。将清理代码放入以上 Dispose(disposing As Boolean)中。
    '    Dispose(False)
    '    MyBase.Finalize()
    'End Sub

    ' Visual Basic 添加此代码以正确实现可释放模式。
    Public Sub Dispose() Implements IDisposable.Dispose
        ' 请勿更改此代码。将清理代码放入以上 Dispose(disposing As Boolean)中。
        Dispose(True)
        ' TODO: 如果在以上内容中替代了 Finalize()，则取消注释以下行。
        ' GC.SuppressFinalize(Me)
    End Sub
#End Region
End Class
