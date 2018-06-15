''' <summary>
''' The wrapper code generator will generate an extension method instead of a normal method.
''' </summary>
<AttributeUsage(AttributeTargets.Method)>
Public NotInheritable Class WrapAsExtensionAttribute
    Inherits Attribute
End Class
