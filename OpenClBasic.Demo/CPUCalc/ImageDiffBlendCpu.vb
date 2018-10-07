Imports System.Drawing
Imports System.Drawing.Imaging
Imports Nukepayload2.CompilerServices.Unsafe

Public Class ImageDiffBlendCpu
    Implements IImageProc

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
        ImgProc(imageAData.Scan0,
                imageBData.Scan0,
                imageCData.Scan0, imageCData.Stride * imageCData.Height \ 4)

        ' 释放
        imageA.UnlockBits(imageAData)
        imageB.UnlockBits(imageBData)
        imageC.UnlockBits(imageCData)

        Return imageC
    End Function

    Private Sub ImgProc(p1 As InteriorPointer(Of Integer),
                        p2 As InteriorPointer(Of Integer),
                        p3 As InteriorPointer(Of Integer),
                        boundary As Integer)
        For i = 0 To boundary - 1
            Dim a = p1.GetAndIncrement.UnmanagedItem
            Dim b = p2.GetAndIncrement.UnmanagedItem
            Dim c = 0
            If a <> b Then
                c = &HFFFFFF Xor a
            End If
            p3.GetAndIncrement.SetUnmanagedItem(c)
        Next
    End Sub

    Public Sub Dispose() Implements IDisposable.Dispose
        ' 没有任何资源需要释放
    End Sub

End Class
