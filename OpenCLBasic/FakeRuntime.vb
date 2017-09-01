Public Class FakeRuntime
    Public Enum Sampler
        Placeholder
    End Enum

    Public Enum CLK
        NORMALIZED_COORDS_FALSE
        NORMALIZED_COORDS_TRUE
        ADDRESS_REPEAT
        ADDRESS_CLAMP_TO_EDGE
        ADDRESS_CLAMP
        ADDRESS_NONE
        FILTER_NEAREST
        FILTER_LINEAR
    End Enum

    Public Structure Image2D
    End Structure

    Public Shared Function GetGlobalId(v As Integer) As Integer
        Return 0
    End Function

    Public Structure Int2
        Public Shared Widening Operator CType(tuple As (Integer, Integer)) As Int2
        End Operator
        Public Shared Operator -(value As Int2) As Int2
        End Operator
    End Structure

    Public Structure UInt4
        Dim x, y, z, w As Byte
        Public Shared Widening Operator CType(value As Integer) As UInt4
        End Operator
        Public Shared Operator <>(a As UInt4, b As UInt4) As Boolean
            Return False
        End Operator
        Public Shared Operator =(a As UInt4, b As UInt4) As Boolean
            Return True
        End Operator
        Public Shared Operator -(value As UInt4) As UInt4
        End Operator
        Public Shared Operator -(a As UInt4, b As UInt4) As UInt4
        End Operator
    End Structure

    Public Shared Sub WriteImageUI(imageC As Image2D, coord As Int2, uInt4 As UInt4)
    End Sub

    Public Shared Function ReadImageUI(imageA As Image2D, sampler As Sampler, coord As Int2) As UInt4
    End Function

End Class
