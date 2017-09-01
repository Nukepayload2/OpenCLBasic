Imports OpenCL.Net

Public Interface IOpenCLResourceCreatorWithContext
    Inherits IOpenCLResourceCreator

    ReadOnly Property DeviceContext As Context
End Interface
