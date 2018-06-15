Imports System.IO
Imports System.Reflection
Imports OpenCLBasic.Native

Module Program
    Sub Main(args As String())
        If args.Length <> 1 Then
            Console.WriteLine("用法: 输出目录作为第一个参数。产生 ClMethods.g.vb。")
        End If
        Console.WriteLine("正在执行代码生成")
        Dim cl = From m In GetType(UnsafeNativeMethods).GetRuntimeMethods
                 Where m.Name.StartsWith("cl")
        Dim sb As New IndentStringBuilder
        sb.AppendLine("Option Strict On
Imports System.Runtime.CompilerServices
Imports System.Runtime.InteropServices
Imports OpenCLBasic.Native

' 这个文件由代码生成。重新执行 CodeGen 会覆盖此文件。
Partial Public Module ClMethods").IncreaseIndent()

        For Each method In cl
            Dim param = method.GetParameters
            Dim name = method.Name.Substring(2)
            Dim genName = name
            If method.IsGenericMethod Then
                genName += "(Of " + String.Join(", ", From g In method.GetGenericArguments
                                                      Select n = g.Name + If(g.GetGenericParameterConstraints.FirstOrDefault?.Equals(GetType(ValueType)), " As Structure", "")) + ")"
                name += "(Of " + String.Join(", ", From g In method.GetGenericArguments
                                                   Select n = g.Name) + ")"
            End If
            If method.GetCustomAttribute(Of WrapAsExtensionAttribute) IsNot Nothing Then
                sb.IndentAppendLine("<Extension>")
            End If
            If param.Length > 0 Then
                If method.ReturnType.Equals(GetType(ErrorCode)) Then
                    If param(param.Length - 1).ParameterType.IsByRef Then
                        WriteSubAsFunction(sb, name, genName, param)
                    Else
                        WriteSub(sb, name, genName, param)
                    End If
                ElseIf param.Length > 0 AndAlso param(param.Length - 1).ParameterType.Equals(GetType(ErrorCode).MakeByRefType) Then
                    WriteFunction(sb, name, genName, param, GetTypeName(method.ReturnType), True)
                Else
                    WriteFunction(sb, name, genName, param, GetTypeName(method.ReturnType), False)
                End If
            Else
                WriteFunction(sb, name, genName, param, GetTypeName(method.ReturnType), False)
            End If
        Next

        sb.DecreaseIndent.AppendLine("End Module")
        File.WriteAllText(args(0) + "\ClMethods.g.vb", sb.ToString)

        Console.WriteLine("完成。")
    End Sub

    Private Sub WriteSubAsFunction(sb As IndentStringBuilder, name As String, genName As String, params() As ParameterInfo)
        Dim paramCodes = From p In params
                         Take params.Length - 1
                         Select GetParamDecl(p)
        Dim paramCall = String.Join(", ", (From p In params
                                           Select PreserveName(p.Name)))
        Dim returnTypeName = GetTypeName(params(params.Length - 1).ParameterType)
        Dim retValName = params(params.Length - 1).Name
        sb.IndentAppend("Public Function ").
           Append(genName).
           Append("(").
           Append(String.Join(", ", paramCodes)).
           Append(") As ").
           AppendLine(returnTypeName).
           IncreaseIndent().
           IndentAppendLine($"Dim {retValName} As {returnTypeName} = Nothing").
           IndentAppendLine($"Dim errCode = cl{name}({paramCall})").
           IndentAppendLine("CheckErr(errCode)").
           IndentAppendLine($"Return {retValName}").
           DecreaseIndent().
           IndentAppendLine("End Function").
           AppendLine()
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
                         Select GetParamDecl(p)
        Dim paramCall = String.Join(", ", From p In params Select PreserveName(p.Name))
        sb.IndentAppend("Public Sub ").
           Append(genName).
           Append("(").
           Append(String.Join(", ", paramCodes)).
           AppendLine(")").
           IncreaseIndent().
           IndentAppendLine($"errCode = cl{name}({paramCall})").
           IndentAppendLine("CheckErr(errCode)").
           DecreaseIndent().
           IndentAppendLine("End Sub").
           AppendLine()
    End Sub

    Private Function GetParamDecl(p As ParameterInfo) As String
        Dim inOut As String
        If p.ParameterType.IsByRef Then
            If p.IsOut Then
                inOut = "<Out> ByRef "
            Else
                inOut = "ByRef "
            End If
        Else
            inOut = String.Empty
        End If
        Return inOut + PreserveName(p.Name) + " As " + GetTypeName(p.ParameterType)
    End Function

    Private Sub WriteFunction(sb As IndentStringBuilder, name As String, genName As String, params() As ParameterInfo, returnName As String, hasErrorCode As Boolean)
        Dim takeCount = If(hasErrorCode, params.Length - 1, params.Length)
        Dim paramCodes = From p In params
                         Take takeCount
                         Select GetParamDecl(p)
        Dim paramCall = String.Join(", ", (From p In params
                                           Take takeCount
                                           Select PreserveName(p.Name)).Concat(If(hasErrorCode, {"errCode"}, {})))
        sb.IndentAppend("Public Function ").
           Append(genName).
           Append("(").
           Append(String.Join(", ", paramCodes)).
           Append(") As ").
           AppendLine(returnName).
           IncreaseIndent()
        If hasErrorCode Then
            sb.IndentAppendLine($"Dim value = cl{name}({paramCall})")
            sb.IndentAppendLine("CheckErr(errCode)")
            sb.IndentAppendLine("Return value")
        Else
            sb.IndentAppendLine($"Return cl{name}({paramCall})")
        End If
        sb.DecreaseIndent().
           IndentAppendLine("End Function").
           AppendLine()
    End Sub
End Module
