Imports OpenCL.Net

' 这个文件由代码生成。重新执行 CodeGen 会覆盖此文件。
Partial Public Module ClMethods
    Public Sub SetKernelArg(kernel As Kernel, argIndex As UInt32, value As IMem)
        errCode = Cl.SetKernelArg(kernel, argIndex, value)
        CheckErr(errCode)
    End Sub

    Public Sub SetKernelArg(Of T)(kernel As Kernel, argIndex As UInt32, length As Int32)
        errCode = Cl.SetKernelArg(Of T)(kernel, argIndex, length)
        CheckErr(errCode)
    End Sub

    Public Function GetEventInfo(e As ClEvent, paramName As EventInfo) As InfoBuffer
        Dim value = Cl.GetEventInfo(e, paramName, errCode)
        CheckErr(errCode)
        Return value
    End Function

    Public Function GetSamplerInfo(sampler As Sampler, paramName As SamplerInfo) As InfoBuffer
        Dim value = Cl.GetSamplerInfo(sampler, paramName, errCode)
        CheckErr(errCode)
        Return value
    End Function

    Public Function GetEventProfilingInfo(e As ClEvent, paramName As ProfilingInfo) As InfoBuffer
        Dim value = Cl.GetEventProfilingInfo(e, paramName, errCode)
        CheckErr(errCode)
        Return value
    End Function

    Public Sub RetainEvent(e As ClEvent)
        errCode = Cl.RetainEvent(e)
        CheckErr(errCode)
    End Sub

    Public Sub ReleaseEvent(e As ClEvent)
        errCode = Cl.ReleaseEvent(e)
        CheckErr(errCode)
    End Sub

    Public Function CreateSampler(context As Context, normalizedCoords As Boolean, addressingMode As AddressingMode, filterMode As FilterMode) As Sampler
        Dim value = Cl.CreateSampler(context, normalizedCoords, addressingMode, filterMode, errCode)
        CheckErr(errCode)
        Return value
    End Function

    Public Sub RetainSampler(sampler As Sampler)
        errCode = Cl.RetainSampler(sampler)
        CheckErr(errCode)
    End Sub

    Public Sub ReleaseSampler(sampler As Sampler)
        errCode = Cl.ReleaseSampler(sampler)
        CheckErr(errCode)
    End Sub

    Public Sub GetSamplerInfo(sampler As Sampler, paramName As SamplerInfo, paramValueSize As IntPtr, paramValue As InfoBuffer, paramValueSizeRet As IntPtr)
        errCode = Cl.GetSamplerInfo(sampler, paramName, paramValueSize, paramValue, paramValueSizeRet)
        CheckErr(errCode)
    End Sub

    Public Sub GetEventProfilingInfo(e As ClEvent, paramName As ProfilingInfo, paramValueSize As IntPtr, paramValue As InfoBuffer, paramValueSizeRet As IntPtr)
        errCode = Cl.GetEventProfilingInfo(e, paramName, paramValueSize, paramValue, paramValueSizeRet)
        CheckErr(errCode)
    End Sub

    Public Sub OnError([error] As ErrorCode, errorCode As ErrorCode, action As Action(Of ErrorCode))
        errCode = Cl.OnError([error], errorCode, action)
        CheckErr(errCode)
    End Sub

    Public Sub OnAnyError([error] As ErrorCode, action As Action(Of ErrorCode))
        errCode = Cl.OnAnyError([error], action)
        CheckErr(errCode)
    End Sub

    Public Sub Check([error] As ErrorCode)
        errCode = Cl.Check([error])
        CheckErr(errCode)
    End Sub

    Public Function GetPlatformIDs() As Platform()
        Dim value = Cl.GetPlatformIDs(errCode)
        CheckErr(errCode)
        Return value
    End Function

    Public Function GetPlatformInfo(platform As Platform, paramName As PlatformInfo) As InfoBuffer
        Dim value = Cl.GetPlatformInfo(platform, paramName, errCode)
        CheckErr(errCode)
        Return value
    End Function

    Public Function GetDeviceIDs(platform As Platform, deviceType As DeviceType) As Device()
        Dim value = Cl.GetDeviceIDs(platform, deviceType, errCode)
        CheckErr(errCode)
        Return value
    End Function

    Public Function GetDeviceInfo(device As Device, paramName As DeviceInfo) As InfoBuffer
        Dim value = Cl.GetDeviceInfo(device, paramName, errCode)
        CheckErr(errCode)
        Return value
    End Function

    Public Function GetContextInfo(context As Context, paramName As ContextInfo) As InfoBuffer
        Dim value = Cl.GetContextInfo(context, paramName, errCode)
        CheckErr(errCode)
        Return value
    End Function

    Public Function CreateContext(platformWildCard As String, deviceType As DeviceType) As Context
        Dim value = Cl.CreateContext(platformWildCard, deviceType, errCode)
        CheckErr(errCode)
        Return value
    End Function

    Public Function CreateBuffer(context As Context, flags As MemFlags, size As IntPtr) As IMem
        Dim value = Cl.CreateBuffer(context, flags, size, errCode)
        CheckErr(errCode)
        Return value
    End Function

    Public Function CreateBuffer(context As Context, flags As MemFlags, size As Int32) As IMem
        Dim value = Cl.CreateBuffer(context, flags, size, errCode)
        CheckErr(errCode)
        Return value
    End Function

    Public Function CreateBuffer(Of T As Structure)(context As Context, flags As MemFlags, hostData As T()) As IMem(Of T)
        Dim value = Cl.CreateBuffer(Of T)(context, flags, hostData, errCode)
        CheckErr(errCode)
        Return value
    End Function

    Public Function CreateBuffer(Of T As Structure)(context As Context, flags As MemFlags, length As Int32) As IMem(Of T)
        Dim value = Cl.CreateBuffer(Of T)(context, flags, length, errCode)
        CheckErr(errCode)
        Return value
    End Function

    Public Function GetMemObjectInfo(mem As IMem, paramName As MemInfo) As InfoBuffer
        Dim value = Cl.GetMemObjectInfo(mem, paramName, errCode)
        CheckErr(errCode)
        Return value
    End Function

    Public Function GetImageInfo(image As IMem, paramName As ImageInfo) As InfoBuffer
        Dim value = Cl.GetImageInfo(image, paramName, errCode)
        CheckErr(errCode)
        Return value
    End Function

    Public Function GetSupportedImageFormats(context As Context, flags As MemFlags, imageType As MemObjectType) As ImageFormat()
        Dim value = Cl.GetSupportedImageFormats(context, flags, imageType, errCode)
        CheckErr(errCode)
        Return value
    End Function

    Public Function GetProgramInfo(program As Program, paramName As ProgramInfo) As InfoBuffer
        Dim value = Cl.GetProgramInfo(program, paramName, errCode)
        CheckErr(errCode)
        Return value
    End Function

    Public Function GetProgramBuildInfo(program As Program, device As Device, paramName As ProgramBuildInfo) As InfoBuffer
        Dim value = Cl.GetProgramBuildInfo(program, device, paramName, errCode)
        CheckErr(errCode)
        Return value
    End Function

    Public Function GetCommandQueueInfo(commandQueue As CommandQueue, paramName As CommandQueueInfo) As InfoBuffer
        Dim value = Cl.GetCommandQueueInfo(commandQueue, paramName, errCode)
        CheckErr(errCode)
        Return value
    End Function

    Public Sub EnqueueReadBuffer(Of T As Structure)(commandQueue As CommandQueue, buffer As IMem, blockingRead As Boolean, offset As Int32, length As Int32, data As T(), numEventsInWaitList As Int32, eventWaitList As ClEvent(), e As ClEvent)
        errCode = Cl.EnqueueReadBuffer(Of T)(commandQueue, buffer, blockingRead, offset, length, data, numEventsInWaitList, eventWaitList, e)
        CheckErr(errCode)
    End Sub

    Public Sub EnqueueReadBuffer(Of T As Structure)(commandQueue As CommandQueue, buffer As IMem(Of T), blockingRead As Boolean, offset As Int32, length As Int32, data As T(), numEventsInWaitList As Int32, eventWaitList As ClEvent(), e As ClEvent)
        errCode = Cl.EnqueueReadBuffer(Of T)(commandQueue, buffer, blockingRead, offset, length, data, numEventsInWaitList, eventWaitList, e)
        CheckErr(errCode)
    End Sub

    Public Sub EnqueueReadBuffer(Of T As Structure)(commandQueue As CommandQueue, buffer As IMem(Of T), blockingRead As Boolean, data As T(), numEventsInWaitList As Int32, eventWaitList As ClEvent(), e As ClEvent)
        errCode = Cl.EnqueueReadBuffer(Of T)(commandQueue, buffer, blockingRead, data, numEventsInWaitList, eventWaitList, e)
        CheckErr(errCode)
    End Sub

    Public Sub EnqueueWriteBuffer(Of T As Structure)(commandQueue As CommandQueue, buffer As IMem(Of T), blockingWrite As Bool, offset As Int32, length As Int32, data As T(), numEventsInWaitList As Int32, eventWaitList As ClEvent(), e As ClEvent)
        errCode = Cl.EnqueueWriteBuffer(Of T)(commandQueue, buffer, blockingWrite, offset, length, data, numEventsInWaitList, eventWaitList, e)
        CheckErr(errCode)
    End Sub

    Public Sub EnqueueWriteBuffer(Of T As Structure)(commandQueue As CommandQueue, buffer As IMem(Of T), blockingWrite As Bool, data As T(), numEventsInWaitList As Int32, eventWaitList As ClEvent(), e As ClEvent)
        errCode = Cl.EnqueueWriteBuffer(Of T)(commandQueue, buffer, blockingWrite, data, numEventsInWaitList, eventWaitList, e)
        CheckErr(errCode)
    End Sub

    Public Function CreateKernelsInProgram(program As Program) As Kernel()
        Dim value = Cl.CreateKernelsInProgram(program, errCode)
        CheckErr(errCode)
        Return value
    End Function

    Public Function GetKernelInfo(kernel As Kernel, paramName As KernelInfo) As InfoBuffer
        Dim value = Cl.GetKernelInfo(kernel, paramName, errCode)
        CheckErr(errCode)
        Return value
    End Function

    Public Function GetKernelWorkGroupInfo(kernel As Kernel, device As Device, paramName As KernelWorkGroupInfo) As InfoBuffer
        Dim value = Cl.GetKernelWorkGroupInfo(kernel, device, paramName, errCode)
        CheckErr(errCode)
        Return value
    End Function

    Public Sub SetKernelArg(Of T As Structure)(kernel As Kernel, argIndex As UInt32, value As T)
        errCode = Cl.SetKernelArg(Of T)(kernel, argIndex, value)
        CheckErr(errCode)
    End Sub

    Public Sub SetKernelArg(Of T As Structure)(kernel As Kernel, argIndex As UInt32, value As IMem(Of T))
        errCode = Cl.SetKernelArg(Of T)(kernel, argIndex, value)
        CheckErr(errCode)
    End Sub

    Public Sub EnqueueWriteBuffer(commandQueue As CommandQueue, buffer As IMem, blockingWrite As Bool, offsetInBytes As IntPtr, lengthInBytes As IntPtr, data As Object, numEventsInWaitList As UInt32, eventWaitList As ClEvent(), e As ClEvent)
        errCode = Cl.EnqueueWriteBuffer(commandQueue, buffer, blockingWrite, offsetInBytes, lengthInBytes, data, numEventsInWaitList, eventWaitList, e)
        CheckErr(errCode)
    End Sub

    Public Sub EnqueueWriteBuffer(commandQueue As CommandQueue, buffer As IMem, blockingWrite As Bool, offsetInBytes As IntPtr, lengthInBytes As IntPtr, data As IntPtr, numEventsInWaitList As UInt32, eventWaitList As ClEvent(), e As ClEvent)
        errCode = Cl.EnqueueWriteBuffer(commandQueue, buffer, blockingWrite, offsetInBytes, lengthInBytes, data, numEventsInWaitList, eventWaitList, e)
        CheckErr(errCode)
    End Sub

    Public Sub EnqueueCopyBuffer(commandQueue As CommandQueue, srcBuffer As IMem, dstBuffer As IMem, srcOffset As IntPtr, dstOffset As IntPtr, cb As IntPtr, numEventsInWaitList As UInt32, eventWaitList As ClEvent(), e As ClEvent)
        errCode = Cl.EnqueueCopyBuffer(commandQueue, srcBuffer, dstBuffer, srcOffset, dstOffset, cb, numEventsInWaitList, eventWaitList, e)
        CheckErr(errCode)
    End Sub

    Public Sub EnqueueReadImage(commandQueue As CommandQueue, image As IMem, blockingRead As Boolean, origin As IntPtr(), region As IntPtr(), rowPitch As IntPtr, slicePitch As IntPtr, dataPtr As IntPtr, numEventsInWaitList As UInt32, eventWaitList As ClEvent(), e As ClEvent)
        errCode = Cl.EnqueueReadImage(commandQueue, image, blockingRead, origin, region, rowPitch, slicePitch, dataPtr, numEventsInWaitList, eventWaitList, e)
        CheckErr(errCode)
    End Sub

    Public Sub EnqueueWriteImage(commandQueue As CommandQueue, image As IMem, blockingWrite As Boolean, origin As IntPtr(), region As IntPtr(), rowPitch As IntPtr, slicePitch As IntPtr, dataPtr As IntPtr, numEventsInWaitList As UInt32, eventWaitList As ClEvent(), e As ClEvent)
        errCode = Cl.EnqueueWriteImage(commandQueue, image, blockingWrite, origin, region, rowPitch, slicePitch, dataPtr, numEventsInWaitList, eventWaitList, e)
        CheckErr(errCode)
    End Sub

    Public Sub EnqueueCopyImage(commandQueue As CommandQueue, srcImage As IMem, dstImage As IMem, srcOrigin As IntPtr(), dstOrigin As IntPtr(), region As IntPtr(), numEventsInWaitList As UInt32, eventWaitList As ClEvent(), e As ClEvent)
        errCode = Cl.EnqueueCopyImage(commandQueue, srcImage, dstImage, srcOrigin, dstOrigin, region, numEventsInWaitList, eventWaitList, e)
        CheckErr(errCode)
    End Sub

    Public Sub EnqueueCopyImageToBuffer(commandQueue As CommandQueue, srcImage As IMem, dstBuffer As IMem, srcOrigin As IntPtr(), region As IntPtr(), dstOffset As IntPtr, numEventsInWaitList As UInt32, eventWaitList As ClEvent(), e As ClEvent)
        errCode = Cl.EnqueueCopyImageToBuffer(commandQueue, srcImage, dstBuffer, srcOrigin, region, dstOffset, numEventsInWaitList, eventWaitList, e)
        CheckErr(errCode)
    End Sub

    Public Sub EnqueueCopyBufferToImage(commandQueue As CommandQueue, srcBuffer As IMem, dstImage As IMem, srcOffset As IntPtr, dstOrigin As IntPtr(), region As IntPtr(), numEventsInWaitList As UInt32, eventWaitList As ClEvent(), e As ClEvent)
        errCode = Cl.EnqueueCopyBufferToImage(commandQueue, srcBuffer, dstImage, srcOffset, dstOrigin, region, numEventsInWaitList, eventWaitList, e)
        CheckErr(errCode)
    End Sub

    Public Function EnqueueMapBuffer(commandQueue As CommandQueue, buffer As IMem, blockingMap As Bool, mapFlags As MapFlags, offset As IntPtr, cb As IntPtr, numEventsInWaitList As UInt32, eventWaitList As ClEvent(), e As ClEvent) As InfoBuffer
        Dim value = Cl.EnqueueMapBuffer(commandQueue, buffer, blockingMap, mapFlags, offset, cb, numEventsInWaitList, eventWaitList, e, errCode)
        CheckErr(errCode)
        Return value
    End Function

    Public Function EnqueueMapImage(commandQueue As CommandQueue, image As IMem, blockingMap As Bool, mapFlags As MapFlags, origin As IntPtr(), region As IntPtr(), imageRowPitch As IntPtr, imageSlicePitch As IntPtr, numEventsInWaitList As UInt32, eventWaitList As ClEvent(), e As ClEvent) As InfoBuffer
        Dim value = Cl.EnqueueMapImage(commandQueue, image, blockingMap, mapFlags, origin, region, imageRowPitch, imageSlicePitch, numEventsInWaitList, eventWaitList, e, errCode)
        CheckErr(errCode)
        Return value
    End Function

    Public Sub EnqueueUnmapObject(commandQueue As CommandQueue, memObj As IMem, mappedObject As InfoBuffer, numEventsInWaitList As UInt32, eventWaitList As ClEvent(), e As ClEvent)
        errCode = Cl.EnqueueUnmapObject(commandQueue, memObj, mappedObject, numEventsInWaitList, eventWaitList, e)
        CheckErr(errCode)
    End Sub

    Public Sub EnqueueNDRangeKernel(commandQueue As CommandQueue, kernel As Kernel, workDim As UInt32, globalWorkOffset As IntPtr(), globalWorkSize As IntPtr(), localWorkSize As IntPtr(), numEventsInWaitList As UInt32, eventWaitList As ClEvent(), e As ClEvent)
        errCode = Cl.EnqueueNDRangeKernel(commandQueue, kernel, workDim, globalWorkOffset, globalWorkSize, localWorkSize, numEventsInWaitList, eventWaitList, e)
        CheckErr(errCode)
    End Sub

    Public Sub EnqueueTask(commandQueue As CommandQueue, kernel As Kernel, numEventsInWaitList As UInt32, eventWaitList As ClEvent(), e As ClEvent)
        errCode = Cl.EnqueueTask(commandQueue, kernel, numEventsInWaitList, eventWaitList, e)
        CheckErr(errCode)
    End Sub

    Public Sub EnqueueMarker(commandQueue As CommandQueue, e As ClEvent)
        errCode = Cl.EnqueueMarker(commandQueue, e)
        CheckErr(errCode)
    End Sub

    Public Sub EnqueueWaitForEvents(commandQueue As CommandQueue, numEventsInWaitList As UInt32, eventWaitList As ClEvent())
        errCode = Cl.EnqueueWaitForEvents(commandQueue, numEventsInWaitList, eventWaitList)
        CheckErr(errCode)
    End Sub

    Public Sub EnqueueBarrier(commandQueue As CommandQueue)
        errCode = Cl.EnqueueBarrier(commandQueue)
        CheckErr(errCode)
    End Sub

    Public Sub Flush(commandQueue As CommandQueue)
        errCode = Cl.Flush(commandQueue)
        CheckErr(errCode)
    End Sub

    Public Sub Finish(commandQueue As CommandQueue)
        errCode = Cl.Finish(commandQueue)
        CheckErr(errCode)
    End Sub

    Public Sub WaitForEvents(numEvents As UInt32, eventWaitList As ClEvent())
        errCode = Cl.WaitForEvents(numEvents, eventWaitList)
        CheckErr(errCode)
    End Sub

    Public Sub GetEventInfo(e As ClEvent, paramName As EventInfo, paramValueSize As IntPtr, paramValue As InfoBuffer, paramValueSizeRet As IntPtr)
        errCode = Cl.GetEventInfo(e, paramName, paramValueSize, paramValue, paramValueSizeRet)
        CheckErr(errCode)
    End Sub

    Public Function CreateProgramWithBinary(context As Context, numDevices As UInt32, deviceList As Device(), lengths As IntPtr(), binaries As InfoBufferArray, binariesStatus As InfoBufferArray(Of ErrorCode)) As Program
        Dim value = Cl.CreateProgramWithBinary(context, numDevices, deviceList, lengths, binaries, binariesStatus, errCode)
        CheckErr(errCode)
        Return value
    End Function

    Public Sub RetainProgram(program As Program)
        errCode = Cl.RetainProgram(program)
        CheckErr(errCode)
    End Sub

    Public Sub ReleaseProgram(program As Program)
        errCode = Cl.ReleaseProgram(program)
        CheckErr(errCode)
    End Sub

    Public Sub BuildProgram(program As Program, numDevices As UInt32, deviceList As Device(), options As String, pfnNotify As Cl.ProgramNotify, userData As IntPtr)
        errCode = Cl.BuildProgram(program, numDevices, deviceList, options, pfnNotify, userData)
        CheckErr(errCode)
    End Sub

    Public Sub GetProgramInfo(program As Program, paramName As ProgramInfo, paramValueSize As IntPtr, paramValue As InfoBuffer, paramValueSizeRet As IntPtr)
        errCode = Cl.GetProgramInfo(program, paramName, paramValueSize, paramValue, paramValueSizeRet)
        CheckErr(errCode)
    End Sub

    Public Sub GetProgramInfo(program As Program, paramName As ProgramInfo, paramValueSize As IntPtr, paramValues As InfoBufferArray, paramValueSizeRet As IntPtr)
        errCode = Cl.GetProgramInfo(program, paramName, paramValueSize, paramValues, paramValueSizeRet)
        CheckErr(errCode)
    End Sub

    Public Sub GetProgramBuildInfo(program As Program, device As Device, paramName As ProgramBuildInfo, paramValueSize As IntPtr, paramValue As InfoBuffer, paramValueSizeRet As IntPtr)
        errCode = Cl.GetProgramBuildInfo(program, device, paramName, paramValueSize, paramValue, paramValueSizeRet)
        CheckErr(errCode)
    End Sub

    Public Function CreateKernel(program As Program, kernelName As String) As Kernel
        Dim value = Cl.CreateKernel(program, kernelName, errCode)
        CheckErr(errCode)
        Return value
    End Function

    Public Sub CreateKernelsInProgram(program As Program, numKernels As UInt32, kernels As Kernel(), numKernelsRet As UInt32)
        errCode = Cl.CreateKernelsInProgram(program, numKernels, kernels, numKernelsRet)
        CheckErr(errCode)
    End Sub

    Public Sub RetainKernel(kernel As Kernel)
        errCode = Cl.RetainKernel(kernel)
        CheckErr(errCode)
    End Sub

    Public Sub ReleaseKernel(kernel As Kernel)
        errCode = Cl.ReleaseKernel(kernel)
        CheckErr(errCode)
    End Sub

    Public Sub SetKernelArg(kernel As Kernel, argIndex As UInt32, argSize As IntPtr, argValue As Object)
        errCode = Cl.SetKernelArg(kernel, argIndex, argSize, argValue)
        CheckErr(errCode)
    End Sub

    Public Sub GetKernelInfo(kernel As Kernel, paramName As KernelInfo, paramValueSize As IntPtr, paramValue As InfoBuffer, paramValueSizeRet As IntPtr)
        errCode = Cl.GetKernelInfo(kernel, paramName, paramValueSize, paramValue, paramValueSizeRet)
        CheckErr(errCode)
    End Sub

    Public Sub GetKernelWorkGroupInfo(kernel As Kernel, device As Device, paramName As KernelWorkGroupInfo, paramValueSize As IntPtr, paramValue As InfoBuffer, paramValueSizeRet As IntPtr)
        errCode = Cl.GetKernelWorkGroupInfo(kernel, device, paramName, paramValueSize, paramValue, paramValueSizeRet)
        CheckErr(errCode)
    End Sub

    Public Function CreateCommandQueue(context As Context, device As Device, properties As CommandQueueProperties) As CommandQueue
        Dim value = Cl.CreateCommandQueue(context, device, properties, errCode)
        CheckErr(errCode)
        Return value
    End Function

    Public Sub RetainCommandQueue(commandQueue As CommandQueue)
        errCode = Cl.RetainCommandQueue(commandQueue)
        CheckErr(errCode)
    End Sub

    Public Sub ReleaseCommandQueue(commandQueue As CommandQueue)
        errCode = Cl.ReleaseCommandQueue(commandQueue)
        CheckErr(errCode)
    End Sub

    Public Sub GetCommandQueueInfo(commandQueue As CommandQueue, paramName As CommandQueueInfo, paramValueSize As IntPtr, paramValue As InfoBuffer, paramValueSizeRet As IntPtr)
        errCode = Cl.GetCommandQueueInfo(commandQueue, paramName, paramValueSize, paramValue, paramValueSizeRet)
        CheckErr(errCode)
    End Sub

    Public Sub SetCommandQueueProperty(commandQueue As CommandQueue, properties As CommandQueueProperties, enable As Boolean, oldProperties As CommandQueueProperties)
        errCode = Cl.SetCommandQueueProperty(commandQueue, properties, enable, oldProperties)
        CheckErr(errCode)
    End Sub

    Public Sub EnqueueReadBuffer(commandQueue As CommandQueue, buffer As IMem, blockingRead As Boolean, offsetInBytes As IntPtr, lengthInBytes As IntPtr, data As Object, numEventsInWaitList As UInt32, eventWaitList As ClEvent(), e As ClEvent)
        errCode = Cl.EnqueueReadBuffer(commandQueue, buffer, blockingRead, offsetInBytes, lengthInBytes, data, numEventsInWaitList, eventWaitList, e)
        CheckErr(errCode)
    End Sub

    Public Sub EnqueueReadBuffer(commandQueue As CommandQueue, buffer As IMem, blockingRead As Boolean, offsetInBytes As IntPtr, lengthInBytes As IntPtr, data As IntPtr, numEventsInWaitList As UInt32, eventWaitList As ClEvent(), e As ClEvent)
        errCode = Cl.EnqueueReadBuffer(commandQueue, buffer, blockingRead, offsetInBytes, lengthInBytes, data, numEventsInWaitList, eventWaitList, e)
        CheckErr(errCode)
    End Sub

    Public Sub GetPlatformIDs(numEntries As UInt32, platforms As Platform(), numPlatforms As UInt32)
        errCode = Cl.GetPlatformIDs(numEntries, platforms, numPlatforms)
        CheckErr(errCode)
    End Sub

    Public Sub GetPlatformInfo(platformId As Platform, paramName As PlatformInfo, paramValueBufferSize As IntPtr, paramValue As InfoBuffer, paramValueSize As IntPtr)
        errCode = Cl.GetPlatformInfo(platformId, paramName, paramValueBufferSize, paramValue, paramValueSize)
        CheckErr(errCode)
    End Sub

    Public Sub GetDeviceIDs(platform As Platform, deviceType As DeviceType, numEntries As UInt32, devices As Device(), numDevices As UInt32)
        errCode = Cl.GetDeviceIDs(platform, deviceType, numEntries, devices, numDevices)
        CheckErr(errCode)
    End Sub

    Public Sub GetDeviceInfo(device As Device, paramName As DeviceInfo, paramValueSize As IntPtr, paramValue As InfoBuffer, paramValueSizeRet As IntPtr)
        errCode = Cl.GetDeviceInfo(device, paramName, paramValueSize, paramValue, paramValueSizeRet)
        CheckErr(errCode)
    End Sub

    Public Function CreateContext(properties As ContextProperty(), numDevices As UInt32, devices As Device(), pfnNotify As Cl.ContextNotify, userData As IntPtr) As Context
        Dim value = Cl.CreateContext(properties, numDevices, devices, pfnNotify, userData, errCode)
        CheckErr(errCode)
        Return value
    End Function

    Public Function CreateContextFromType(properties As ContextProperty(), deviceType As DeviceType, pfnNotify As Cl.ContextNotify, userData As IntPtr) As Context
        Dim value = Cl.CreateContextFromType(properties, deviceType, pfnNotify, userData, errCode)
        CheckErr(errCode)
        Return value
    End Function

    Public Sub RetainContext(context As Context)
        errCode = Cl.RetainContext(context)
        CheckErr(errCode)
    End Sub

    Public Sub ReleaseContext(context As Context)
        errCode = Cl.ReleaseContext(context)
        CheckErr(errCode)
    End Sub

    Public Sub GetContextInfo(context As Context, paramName As ContextInfo, paramValueSize As IntPtr, paramValue As InfoBuffer, paramValueSizeRet As IntPtr)
        errCode = Cl.GetContextInfo(context, paramName, paramValueSize, paramValue, paramValueSizeRet)
        CheckErr(errCode)
    End Sub

    Public Function CreateBuffer(context As Context, flags As MemFlags, size As IntPtr, hostPtr As IntPtr) As IMem
        Dim value = Cl.CreateBuffer(context, flags, size, hostPtr, errCode)
        CheckErr(errCode)
        Return value
    End Function

    Public Function CreateBuffer(context As Context, flags As MemFlags, size As IntPtr, hostData As Object) As IMem
        Dim value = Cl.CreateBuffer(context, flags, size, hostData, errCode)
        CheckErr(errCode)
        Return value
    End Function

    Public Sub RetainMemObject(memObj As IMem)
        errCode = Cl.RetainMemObject(memObj)
        CheckErr(errCode)
    End Sub

    Public Sub ReleaseMemObject(memObj As IMem)
        errCode = Cl.ReleaseMemObject(memObj)
        CheckErr(errCode)
    End Sub

    Public Sub GetSupportedImageFormats(context As Context, flags As MemFlags, imageType As MemObjectType, numEntries As UInt32, imageFormats As ImageFormat(), numImageFormats As UInt32)
        errCode = Cl.GetSupportedImageFormats(context, flags, imageType, numEntries, imageFormats, numImageFormats)
        CheckErr(errCode)
    End Sub

    Public Function CreateImage2D(context As Context, flags As MemFlags, imageFormat As ImageFormat, imageWidth As IntPtr, imageHeight As IntPtr, imageRowPitch As IntPtr, hostData As Object) As IMem
        Dim value = Cl.CreateImage2D(context, flags, imageFormat, imageWidth, imageHeight, imageRowPitch, hostData, errCode)
        CheckErr(errCode)
        Return value
    End Function

    Public Function CreateImage2D(context As Context, flags As MemFlags, imageFormat As ImageFormat, imageWidth As IntPtr, imageHeight As IntPtr, imageRowPitch As IntPtr, hostPtr As IntPtr) As IMem
        Dim value = Cl.CreateImage2D(context, flags, imageFormat, imageWidth, imageHeight, imageRowPitch, hostPtr, errCode)
        CheckErr(errCode)
        Return value
    End Function

    Public Function CreateImage3D(context As Context, flags As MemFlags, imageFormat As ImageFormat, imageWidth As IntPtr, imageHeight As IntPtr, imageDepth As IntPtr, imageRowPitch As IntPtr, imageSlicePitch As IntPtr, hostData As Object) As IMem
        Dim value = Cl.CreateImage3D(context, flags, imageFormat, imageWidth, imageHeight, imageDepth, imageRowPitch, imageSlicePitch, hostData, errCode)
        CheckErr(errCode)
        Return value
    End Function

    Public Function CreateImage3D(context As Context, flags As MemFlags, imageFormat As ImageFormat, imageWidth As IntPtr, imageHeight As IntPtr, imageDepth As IntPtr, imageRowPitch As IntPtr, imageSlicePitch As IntPtr, hostPtr As IntPtr) As IMem
        Dim value = Cl.CreateImage3D(context, flags, imageFormat, imageWidth, imageHeight, imageDepth, imageRowPitch, imageSlicePitch, hostPtr, errCode)
        CheckErr(errCode)
        Return value
    End Function

    Public Sub GetMemObjectInfo(memObj As IMem, paramName As MemInfo, paramValueSize As IntPtr, paramValue As InfoBuffer, paramValueSizeRet As IntPtr)
        errCode = Cl.GetMemObjectInfo(memObj, paramName, paramValueSize, paramValue, paramValueSizeRet)
        CheckErr(errCode)
    End Sub

    Public Sub GetImageInfo(image As IMem, paramName As ImageInfo, paramValueSize As IntPtr, paramValue As InfoBuffer, paramValueSizeRet As IntPtr)
        errCode = Cl.GetImageInfo(image, paramName, paramValueSize, paramValue, paramValueSizeRet)
        CheckErr(errCode)
    End Sub

    Public Function CreateProgramWithSource(context As Context, count As UInt32, strings As String(), lengths As IntPtr()) As Program
        Dim value = Cl.CreateProgramWithSource(context, count, strings, lengths, errCode)
        CheckErr(errCode)
        Return value
    End Function

End Module
