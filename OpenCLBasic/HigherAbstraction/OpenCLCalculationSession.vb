﻿Public Class OpenCLCalculationSession
    Implements IOpenCLResourceCreatorWithContext, IDisposable

    Private ReadOnly _context As ContextHandle
    Private ReadOnly _device As IOpenCLResourceCreator

    Public ReadOnly Property DeviceContext As ContextHandle Implements IOpenCLResourceCreatorWithContext.DeviceContext
        Get
            Return _context
        End Get
    End Property

    Public ReadOnly Property Device As DeviceHandle Implements IOpenCLResourceCreator.Device
        Get
            Return _device.Device
        End Get
    End Property

    Public Event ContextNotify As ContextNotify

    Private Sub OnContextNotify(errInfo As String, data As Byte(), cb As IntPtr, userData As IntPtr)
        RaiseEvent ContextNotify(errInfo, data, cb, userData)
    End Sub

    Sub New()
        MyClass.New(OpenCLDevice.GetPrimaryGpuDevice)
    End Sub

    Sub New(device As IOpenCLResourceCreator)
        _device = device
        _context = CreateContext(Nothing, 1UI, {_device.Device}, AddressOf OnContextNotify, IntPtr.Zero)
    End Sub

#Region "IDisposable Support"
    Private disposedValue As Boolean ' 要检测冗余调用

    ' IDisposable
    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not disposedValue Then
            If disposing Then
                ' TODO: 释放托管状态(托管对象)。
                GC.SuppressFinalize(Me)
            End If

            ReleaseContext(_context)
            ' TODO: 释放未托管资源(未托管对象)并在以下内容中替代 Finalize()。
            ' TODO: 将大型字段设置为 null。
        End If
        disposedValue = True
    End Sub

    ' TODO: 仅当以上 Dispose(disposing As Boolean)拥有用于释放未托管资源的代码时才替代 Finalize()。
    Protected Overrides Sub Finalize()
        ' 请勿更改此代码。将清理代码放入以上 Dispose(disposing As Boolean)中。
        Dispose(False)
        MyBase.Finalize()
    End Sub

    ' Visual Basic 添加此代码以正确实现可释放模式。
    Public Sub Dispose() Implements IDisposable.Dispose
        ' 请勿更改此代码。将清理代码放入以上 Dispose(disposing As Boolean)中。
        Dispose(True)
        ' TODO: 如果在以上内容中替代了 Finalize()，则取消注释以下行。
        ' GC.SuppressFinalize(Me)
    End Sub
#End Region

End Class