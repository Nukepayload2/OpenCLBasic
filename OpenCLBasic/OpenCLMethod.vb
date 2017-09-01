Imports System.IO
Imports System.Text
Imports OpenCL.Net

Public Class OpenCLMethod
    Implements IOpenCLResourceCreatorWithContext, IDisposable

    Private _session As IOpenCLResourceCreatorWithContext
    Private ReadOnly _program As Program
    Private ReadOnly _kernel As Kernel

    Friend Sub New(session As IOpenCLResourceCreatorWithContext, program As Program, kernel As Kernel)
        _session = session
        _program = program
        _kernel = kernel
    End Sub

    Public ReadOnly Property DeviceContext As Context Implements IOpenCLResourceCreatorWithContext.DeviceContext
        Get
            Return _session.DeviceContext
        End Get
    End Property

    Public ReadOnly Property Device As Device Implements IOpenCLResourceCreator.Device
        Get
            Return _session.Device
        End Get
    End Property

    Public ReadOnly Property Program As Program
        Get
            Return _program
        End Get
    End Property

    Public ReadOnly Property Kernel As Kernel
        Get
            Return _kernel
        End Get
    End Property

    Public Shared Function Compile(session As OpenCLCalculationSession, programSource As String, entryName As String) As OpenCLMethod
        Dim device = session.Device
        Dim program = CreateProgramWithSource(session.DeviceContext, 1, {programSource}, Nothing)
        Try
            BuildProgram(program, 1, {device}, String.Empty, Nothing, IntPtr.Zero)
            Dim kernel = CreateKernel(program, entryName)
            Return New OpenCLMethod(session, program, kernel)
        Catch ex As Cl.Exception
            Dim buf = GetProgramBuildInfo(program, device, ProgramBuildInfo.Log)
            Using strm As New StreamReader(buf.AsStream, Encoding.ASCII)
                Throw New ArgumentException(strm.ReadToEnd(), NameOf(programSource))
            End Using
        End Try
    End Function

    Public Function CreateCommandList() As CommandList
        Return New CommandList(Me)
    End Function

#Region "IDisposable Support"
    Private disposedValue As Boolean ' 要检测冗余调用

    ' IDisposable
    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not disposedValue Then
            If disposing Then
                ' TODO: 释放托管状态(托管对象)。
                GC.SuppressFinalize(Me)
            End If

            _program.Dispose()
            _kernel.Dispose()
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
