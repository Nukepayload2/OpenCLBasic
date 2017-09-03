Imports System.Runtime.CompilerServices
Imports System.Runtime.InteropServices

Public Module Extensions
    <Extension>
    Public Function Read(Of T As Structure)(this As InfoBuffer) As T
        Return Marshal.PtrToStructure(Of T)(this.Ptr)
    End Function

    <Extension>
    Public Function ToArray(Of T As Structure)(this As InfoBuffer) As T()
        Dim sizeOfT = Marshal.SizeOf(Of T)
        Dim ub = this.Size \ sizeOfT - 1
        Dim values(ub) As T
        Dim pElement = this.Ptr
        For i = 0 To ub
            values(i) = Marshal.PtrToStructure(Of T)(pElement)
            pElement += sizeOfT
        Next
        Return values
    End Function

    <Extension>
    Public Function AsArray(this As InfoBuffer) As Byte()
        Return this._storage
    End Function

    <Extension>
    Public Function ToArray(this As InfoBuffer) As Byte()
        Return this._storage.ToArray()
    End Function

    <Extension>
    Public Function ToAnsiString(this As InfoBuffer) As String
        Return Marshal.PtrToStringAnsi(this.Ptr, this.Size - 1)
    End Function
End Module
