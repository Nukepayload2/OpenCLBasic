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
        ImgDiff64(imageAData.Scan0,
                imageBData.Scan0,
                imageCData.Scan0, imageCData.Stride * imageCData.Height \ 4)

        ' 释放
        imageA.UnlockBits(imageAData)
        imageB.UnlockBits(imageBData)
        imageC.UnlockBits(imageCData)

        Return imageC
    End Function

    Private Shared Sub ImgDiff64(p1 As IntPtr, p2 As IntPtr, p3 As IntPtr, boundary As Integer)
        Dim lp1 As InteriorPointer(Of Long) = p1
        Dim lp2 As InteriorPointer(Of Long) = p2
        Dim lp3 As InteriorPointer(Of Long) = p3
        Dim halfBoundary = boundary >> 1
        For i = 0 To halfBoundary - 1
            Dim a = lp1.GetAndIncrement.UnmanagedItem
            Dim b = lp2.GetAndIncrement.UnmanagedItem
            Dim c = 0L
            If a <> b Then
                c = &HFFFFFF00FFFFFFL Xor a
            End If
            lp3.GetAndIncrement.SetUnmanagedItem(c)
        Next
        Dim rest As Integer = boundary - (halfBoundary << 1)
        If rest > 0 Then
            ImgDiff32(lp1, lp2, lp3, rest)
        End If
    End Sub

    Private Shared Sub ImgDiff32(p1 As IntPtr, p2 As IntPtr, p3 As IntPtr, boundary As Integer)
        Dim ip1 As InteriorPointer(Of Integer) = p1
        Dim ip2 As InteriorPointer(Of Integer) = p2
        Dim ip3 As InteriorPointer(Of Integer) = p3
        For i = 0 To boundary - 1
            Dim a = ip1.GetAndIncrement.UnmanagedItem
            Dim b = ip2.GetAndIncrement.UnmanagedItem
            Dim c = 0
            If a <> b Then
                c = &HFFFFFF Xor a
            End If
            ip3.GetAndIncrement.SetUnmanagedItem(c)
        Next
    End Sub

    Public Sub Dispose() Implements IDisposable.Dispose
        ' 没有任何资源需要释放
    End Sub

End Class
