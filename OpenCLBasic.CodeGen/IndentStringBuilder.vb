Imports System.Text

Public Class IndentStringBuilder
    Dim sb As New StringBuilder
    Dim indent As Integer
    Public Property Length As Integer
        Get
            Return sb.Length
        End Get
        Set(value As Integer)
            sb.Length = value
        End Set
    End Property
    Public Function IncreaseIndent() As IndentStringBuilder
        indent += 4
        Return Me
    End Function
    Public Function DecreaseIndent() As IndentStringBuilder
        indent -= 4
        Return Me
    End Function
    Public Function Append(str As String) As IndentStringBuilder
        sb.Append(str)
        Return Me
    End Function
    Public Function IndentAppend(str As String) As IndentStringBuilder
        sb.Append(" "c, indent).Append(str)
        Return Me
    End Function
    Public Function AppendLine(str As String) As IndentStringBuilder
        sb.AppendLine(str)
        Return Me
    End Function
    Public Function AppendLine() As IndentStringBuilder
        sb.AppendLine()
        Return Me
    End Function
    Public Function IndentAppendLine(str As String) As IndentStringBuilder
        sb.Append(" "c, indent).AppendLine(str)
        Return Me
    End Function
    ''' <summary>
    ''' 将所有非空行写入, 并去除起始处的空格
    ''' </summary>
    Public Function IndentAppendLines(str As String) As IndentStringBuilder
        For Each ln In str.Split({vbCrLf}, StringSplitOptions.RemoveEmptyEntries)
            IndentAppendLine(ln.TrimStart)
        Next
        Return Me
    End Function
    Public Function AppendLineIndent(str As String) As IndentStringBuilder
        sb.AppendLine(str).Append(" "c, indent)
        Return Me
    End Function
    Public Overrides Function ToString() As String
        Return sb.ToString
    End Function
    Public Function Remove(start As Integer, len As Integer) As IndentStringBuilder
        sb.Remove(start, len)
        Return Me
    End Function
End Class
