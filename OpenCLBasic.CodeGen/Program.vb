Imports System.IO
Imports System.Reflection
Imports OpenCL.Net

Module Program
    Sub Main(args As String())
        If args.Length <> 1 Then
            Console.WriteLine("用法: 输出目录作为第一个参数。产生 ClMethods.g.vb。")
        End If
        Console.WriteLine("正在执行代码生成")
        Dim cl = From m In GetType(Cl).GetRuntimeMethods
                 Where m.IsPublic
        Dim sb As New IndentStringBuilder
        sb.AppendLine("Imports OpenCL.Net

' 这个文件由代码生成。重新执行 CodeGen 会覆盖此文件。
Partial Public Module ClMethods").IncreaseIndent()

        For Each method In cl
            Dim param = method.GetParameters
            If param.Length > 0 Then
                Dim name = method.Name
                Dim genName = name
                If method.IsGenericMethod Then
                    genName += "(Of " + String.Join(", ", From g In method.GetGenericArguments
                                                          Select n = g.Name + If(g.GetGenericParameterConstraints.FirstOrDefault?.Equals(GetType(ValueType)), " As Structure", "")) + ")"
                    name += "(Of " + String.Join(", ", From g In method.GetGenericArguments
                                                       Select n = g.Name) + ")"
                End If
                If param(param.Length - 1).ParameterType.Equals(GetType(ErrorCode).MakeByRefType) Then
                    WriteFunction(sb, name, genName, param, GetTypeName(method.ReturnType))
                ElseIf method.ReturnType.Equals(GetType(ErrorCode)) Then
                    WriteSub(sb, name, genName, param)
                End If
            End If
        Next

        sb.DecreaseIndent.AppendLine("End Module")
        File.WriteAllText(args(0) + "\ClMethods.g.vb", sb.ToString)

        Console.WriteLine("完成。按任意键退出。")
        Console.ReadKey()
    End Sub

    Private Function GetTypeName(tp As Type) As String
        Dim name$
        If tp.IsNested AndAlso Not tp.IsGenericParameter Then
            name = tp.DeclaringType.Name + "." + tp.Name
        Else
            name = tp.Name
        End If
        name = name.Replace("[]", "()").Replace("&", "")
        If tp.IsConstructedGenericType Then
            name = name.Substring(0, name.IndexOf("`"))
            Dim genParams = tp.GetGenericArguments
            name += "(Of " + String.Join(", ", From p In genParams Select GetTypeName(p)) + ")"
        End If

        Return name
    End Function

    Private Function PreserveName(name As String) As String
        If name.ToLower = "error" Then
            Return "[error]"
        End If
        Return name
    End Function

    Private Sub WriteSub(sb As IndentStringBuilder, name As String, genName As String, params() As ParameterInfo)
        Dim paramCodes = From p In params
                         Select PreserveName(p.Name) + " As " + GetTypeName(p.ParameterType)
        Dim paramCall = String.Join(", ", From p In params Select PreserveName(p.Name))
        sb.IndentAppend("Public Sub ").
           Append(genName).
           Append("(").
           Append(String.Join(", ", paramCodes)).
           AppendLine(")").
           IncreaseIndent().
           IndentAppendLine($"errCode = Cl.{name}({paramCall})").
           IndentAppendLine("CheckErr(errCode)").
           DecreaseIndent().
           IndentAppendLine("End Sub").
           AppendLine()
    End Sub

    Private Sub WriteFunction(sb As IndentStringBuilder, name As String, genName As String, params() As ParameterInfo, returnName As String)
        Dim paramCodes = From p In params
                         Take params.Length - 1
                         Select PreserveName(p.Name) + " As " + GetTypeName(p.ParameterType)
        Dim paramCall = String.Join(", ", (From p In params
                                           Take params.Length - 1
                                           Select PreserveName(p.Name)).Append("errCode"))
        sb.IndentAppend("Public Function ").
           Append(genName).
           Append("(").
           Append(String.Join(", ", paramCodes)).
           Append(") As ").
           AppendLine(returnName).
           IncreaseIndent().
           IndentAppendLine($"Dim value = Cl.{name}({paramCall})").
           IndentAppendLine("CheckErr(errCode)").
           IndentAppendLine("Return value").
           DecreaseIndent().
           IndentAppendLine("End Function").
           AppendLine()
    End Sub
End Module
