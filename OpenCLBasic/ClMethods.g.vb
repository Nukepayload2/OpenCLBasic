Option Strict On
Imports System.Runtime.InteropServices
' 这个文件由代码生成。重新执行 CodeGen 会覆盖此文件。
Partial Public Module ClMethods
    Public Sub ReleaseKernel(kernel As KernelHandle)
        errCode = clReleaseKernel(kernel)
        CheckErr(errCode)
    End Sub

    Public Sub ReleaseMemObject(memObj As ClBuffer)
        errCode = clReleaseMemObject(memObj)
        CheckErr(errCode)
    End Sub

    Public Sub ReleaseProgram(program As ProgramHandle)
        errCode = clReleaseProgram(program)
        CheckErr(errCode)
    End Sub

    Public Sub ReleaseSampler(sampler As SamplerHandle)
        errCode = clReleaseSampler(sampler)
        CheckErr(errCode)
    End Sub

    Public Sub RetainCommandQueue(commandQueue As CommandQueueHandle)
        errCode = clRetainCommandQueue(commandQueue)
        CheckErr(errCode)
    End Sub

    Public Sub RetainContext(context As ContextHandle)
        errCode = clRetainContext(context)
        CheckErr(errCode)
    End Sub

    Public Sub RetainEvent(eventHandle As EventHandle)
        errCode = clRetainEvent(eventHandle)
        CheckErr(errCode)
    End Sub

    Public Sub RetainKernel(kernel As KernelHandle)
        errCode = clRetainKernel(kernel)
        CheckErr(errCode)
    End Sub

    Public Sub RetainMemObject(memObj As IntPtr)
        errCode = clRetainMemObject(memObj)
        CheckErr(errCode)
    End Sub

    Public Sub RetainProgram(program As ProgramHandle)
        errCode = clRetainProgram(program)
        CheckErr(errCode)
    End Sub

    Public Sub RetainSampler(sampler As SamplerHandle)
        errCode = clRetainSampler(sampler)
        CheckErr(errCode)
    End Sub

    Public Function SetCommandQueueProperty(commandQueue As CommandQueueHandle, properties As CommandQueueProperties, enable As Boolean) As CommandQueueProperties
        Dim oldProperties As CommandQueueProperties = Nothing
        Dim errCode = clSetCommandQueueProperty(commandQueue, properties, enable, oldProperties)
        CheckErr(errCode)
        Return oldProperties
    End Function

    Public Sub SetKernelArg(kernel As KernelHandle, argIndex As UInt32, argSize As SizeT, ByRef argValue As ClBuffer)
        errCode = clSetKernelArg(kernel, argIndex, argSize, argValue)
        CheckErr(errCode)
    End Sub

    Public Function UnloadCompiler() As ErrorCode
        Return clUnloadCompiler()
    End Function

    Public Sub WaitForEvents(numEvents As UInt32, eventWaitList As EventHandle())
        errCode = clWaitForEvents(numEvents, eventWaitList)
        CheckErr(errCode)
    End Sub

    Public Sub EnqueueWaitForEvents(commandQueue As CommandQueueHandle, numEventsInWaitList As UInt32, eventWaitList As EventHandle())
        errCode = clEnqueueWaitForEvents(commandQueue, numEventsInWaitList, eventWaitList)
        CheckErr(errCode)
    End Sub

    Public Function EnqueueWriteBuffer(commandQueue As CommandQueueHandle, buffer As ClBuffer, blockingWrite As Boolean, offsetInBytes As SizeT, lengthInBytes As SizeT, ptr As IntPtr, numEventsInWaitList As UInt32, eventWaitList As EventHandle()) As EventHandle
        Dim evt As EventHandle = Nothing
        Dim errCode = clEnqueueWriteBuffer(commandQueue, buffer, blockingWrite, offsetInBytes, lengthInBytes, ptr, numEventsInWaitList, eventWaitList, evt)
        CheckErr(errCode)
        Return evt
    End Function

    Public Function EnqueueWriteImage(commandQueue As CommandQueueHandle, image As ClBuffer, blockingWrite As Boolean, origin As SizeT(), region As SizeT(), rowPitch As SizeT, slicePitch As SizeT, ptr As IntPtr, numEventsIntWaitList As UInt32, eventWaitList As EventHandle()) As EventHandle
        Dim evt As EventHandle = Nothing
        Dim errCode = clEnqueueWriteImage(commandQueue, image, blockingWrite, origin, region, rowPitch, slicePitch, ptr, numEventsIntWaitList, eventWaitList, evt)
        CheckErr(errCode)
        Return evt
    End Function

    Public Sub Finish(commandQueue As CommandQueueHandle)
        errCode = clFinish(commandQueue)
        CheckErr(errCode)
    End Sub

    Public Sub Flush(commandQueue As CommandQueueHandle)
        errCode = clFlush(commandQueue)
        CheckErr(errCode)
    End Sub

    Public Function GetCommandQueueInfo(commandQueue As CommandQueueHandle, paramKind As CommandQueueInfo, paramValueSize As SizeT, paramValue As IntPtr) As SizeT
        Dim paramValueSizeRet As SizeT = Nothing
        Dim errCode = clGetCommandQueueInfo(commandQueue, paramKind, paramValueSize, paramValue, paramValueSizeRet)
        CheckErr(errCode)
        Return paramValueSizeRet
    End Function

    Public Function GetContextInfo(context As ContextHandle, paramKind As ContextInfo, paramValueSize As SizeT, paramValue As IntPtr) As SizeT
        Dim paramValueSizeRet As SizeT = Nothing
        Dim errCode = clGetContextInfo(context, paramKind, paramValueSize, paramValue, paramValueSizeRet)
        CheckErr(errCode)
        Return paramValueSizeRet
    End Function

    Public Function GetDeviceIDs(platform As PlatformHandle, deviceType As DeviceType, numEntries As UInt32, devices As DeviceHandle()) As UInt32
        Dim numDevices As UInt32 = Nothing
        Dim errCode = clGetDeviceIDs(platform, deviceType, numEntries, devices, numDevices)
        CheckErr(errCode)
        Return numDevices
    End Function

    Public Function GetDeviceInfo(device As DeviceHandle, paramKind As DeviceInfo, paramValueSize As SizeT, paramValue As IntPtr) As SizeT
        Dim paramValueSizeRet As SizeT = Nothing
        Dim errCode = clGetDeviceInfo(device, paramKind, paramValueSize, paramValue, paramValueSizeRet)
        CheckErr(errCode)
        Return paramValueSizeRet
    End Function

    Public Function GetEventInfo(eventHandle As EventHandle, paramKind As EventInfo, paramValueSize As SizeT, paramValue As IntPtr) As SizeT
        Dim paramValueSizeRet As SizeT = Nothing
        Dim errCode = clGetEventInfo(eventHandle, paramKind, paramValueSize, paramValue, paramValueSizeRet)
        CheckErr(errCode)
        Return paramValueSizeRet
    End Function

    Public Function GetEventProfilingInfo(eventHandle As EventHandle, paramKind As ProfilingInfo, paramValueSize As SizeT, paramValue As IntPtr) As SizeT
        Dim paramValueSizeRet As SizeT = Nothing
        Dim errCode = clGetEventProfilingInfo(eventHandle, paramKind, paramValueSize, paramValue, paramValueSizeRet)
        CheckErr(errCode)
        Return paramValueSizeRet
    End Function

    Public Function GetExtensionFunctionAddress(ByRef funcName As String) As IntPtr
        Return clGetExtensionFunctionAddress(funcName)
    End Function

    Public Function GetImageInfo(image As IntPtr, paramType As ImageInfo, paramValueSize As SizeT, paramValue As IntPtr) As SizeT
        Dim paramValueSizeRet As SizeT = Nothing
        Dim errCode = clGetImageInfo(image, paramType, paramValueSize, paramValue, paramValueSizeRet)
        CheckErr(errCode)
        Return paramValueSizeRet
    End Function

    Public Function GetKernelInfo(kernel As KernelHandle, paramKind As KernelInfo, paramValueSize As SizeT, paramValue As IntPtr) As SizeT
        Dim paramValueSizeRet As SizeT = Nothing
        Dim errCode = clGetKernelInfo(kernel, paramKind, paramValueSize, paramValue, paramValueSizeRet)
        CheckErr(errCode)
        Return paramValueSizeRet
    End Function

    Public Function GetKernelWorkGroupInfo(kernel As KernelHandle, device As DeviceHandle, paramKind As KernelWorkGroupInfo, paramValueSize As SizeT, paramValue As IntPtr) As SizeT
        Dim paramValueSizeRet As SizeT = Nothing
        Dim errCode = clGetKernelWorkGroupInfo(kernel, device, paramKind, paramValueSize, paramValue, paramValueSizeRet)
        CheckErr(errCode)
        Return paramValueSizeRet
    End Function

    Public Function GetMemObjectInfo(memObj As IntPtr, paramKind As MemInfo, paramValueSize As SizeT, paramValue As IntPtr) As SizeT
        Dim paramValueSizeRet As SizeT = Nothing
        Dim errCode = clGetMemObjectInfo(memObj, paramKind, paramValueSize, paramValue, paramValueSizeRet)
        CheckErr(errCode)
        Return paramValueSizeRet
    End Function

    Public Function GetPlatformIDs(numEntries As UInt32, platforms As PlatformHandle()) As UInt32
        Dim numPlatforms As UInt32 = Nothing
        Dim errCode = clGetPlatformIDs(numEntries, platforms, numPlatforms)
        CheckErr(errCode)
        Return numPlatforms
    End Function

    Public Function GetPlatformInfo(platform As PlatformHandle, paramKind As PlatformInfo, paramValueSize As SizeT, paramValue As IntPtr) As SizeT
        Dim paramValueSizeRet As SizeT = Nothing
        Dim errCode = clGetPlatformInfo(platform, paramKind, paramValueSize, paramValue, paramValueSizeRet)
        CheckErr(errCode)
        Return paramValueSizeRet
    End Function

    Public Function GetProgramBuildInfo(program As ProgramHandle, device As DeviceHandle, paramKind As ProgramBuildInfo, paramValueSize As SizeT, paramValue As IntPtr) As SizeT
        Dim paramValueSizeRet As SizeT = Nothing
        Dim errCode = clGetProgramBuildInfo(program, device, paramKind, paramValueSize, paramValue, paramValueSizeRet)
        CheckErr(errCode)
        Return paramValueSizeRet
    End Function

    Public Function GetProgramInfo(program As ProgramHandle, paramKind As ProgramInfo, paramValueSize As SizeT, paramValue As IntPtr) As SizeT
        Dim paramValueSizeRet As SizeT = Nothing
        Dim errCode = clGetProgramInfo(program, paramKind, paramValueSize, paramValue, paramValueSizeRet)
        CheckErr(errCode)
        Return paramValueSizeRet
    End Function

    Public Function GetSamplerInfo(sampler As SamplerHandle, paramKind As SamplerInfo, paramValueSize As SizeT, paramValue As IntPtr) As SizeT
        Dim paramValueSizeRet As SizeT = Nothing
        Dim errCode = clGetSamplerInfo(sampler, paramKind, paramValueSize, paramValue, paramValueSizeRet)
        CheckErr(errCode)
        Return paramValueSizeRet
    End Function

    Public Function GetSupportedImageFormats(context As ContextHandle, flags As MemFlags, imageType As MemObjectType, numEntries As UInt32, imageFormats As ImageFormat()) As UInt32
        Dim numImageFormats As UInt32 = Nothing
        Dim errCode = clGetSupportedImageFormats(context, flags, imageType, numEntries, imageFormats, numImageFormats)
        CheckErr(errCode)
        Return numImageFormats
    End Function

    Public Sub ReleaseCommandQueue(commandQueue As CommandQueueHandle)
        errCode = clReleaseCommandQueue(commandQueue)
        CheckErr(errCode)
    End Sub

    Public Sub ReleaseContext(context As ContextHandle)
        errCode = clReleaseContext(context)
        CheckErr(errCode)
    End Sub

    Public Sub ReleaseEvent(eventHandle As EventHandle)
        errCode = clReleaseEvent(eventHandle)
        CheckErr(errCode)
    End Sub

    Public Sub BuildProgram(program As ProgramHandle, numDevices As UInt32, deviceList As DeviceHandle(), ByRef options As String, pfnNotify As ProgramNotify, userData As IntPtr)
        errCode = clBuildProgram(program, numDevices, deviceList, options, pfnNotify, userData)
        CheckErr(errCode)
    End Sub

    Public Function CreateBuffer(context As ContextHandle, flags As MemFlags, size As SizeT, hostPtr As IntPtr) As ClBuffer
        Dim value = clCreateBuffer(context, flags, size, hostPtr, errCode)
        CheckErr(errCode)
        Return value
    End Function

    Public Function CreateCommandQueue(context As ContextHandle, device As DeviceHandle, properties As CommandQueueProperties) As CommandQueueHandle
        Dim value = clCreateCommandQueue(context, device, properties, errCode)
        CheckErr(errCode)
        Return value
    End Function

    Public Function CreateContext(properties As ContextProperty(), numDevices As UInt32, devices As DeviceHandle(), pfnNotify As ContextNotify, userData As IntPtr) As ContextHandle
        Dim value = clCreateContext(properties, numDevices, devices, pfnNotify, userData, errCode)
        CheckErr(errCode)
        Return value
    End Function

    Public Function CreateContextFromType(properties As ContextProperty(), deviceType As DeviceType, pfnNotify As ContextNotify, userData As IntPtr) As ContextHandle
        Dim value = clCreateContextFromType(properties, deviceType, pfnNotify, userData, errCode)
        CheckErr(errCode)
        Return value
    End Function

    Public Function CreateImage2D(context As ContextHandle, flags As MemFlags, ByRef imageFormat As ImageFormat, imageWidth As SizeT, imageHeight As SizeT, imageRowPitch As SizeT, hostPtr As IntPtr) As ClBuffer
        Dim value = clCreateImage2D(context, flags, imageFormat, imageWidth, imageHeight, imageRowPitch, hostPtr, errCode)
        CheckErr(errCode)
        Return value
    End Function

    Public Function CreateImage3D(context As ContextHandle, flags As MemFlags, ByRef imageFormat As ImageFormat, imageWidth As SizeT, imageHeight As SizeT, imageDepth As SizeT, imageRowPitch As SizeT, imageSlicePitch As SizeT, hostPtr As IntPtr) As ClBuffer
        Dim value = clCreateImage3D(context, flags, imageFormat, imageWidth, imageHeight, imageDepth, imageRowPitch, imageSlicePitch, hostPtr, errCode)
        CheckErr(errCode)
        Return value
    End Function

    Public Function CreateKernel(program As ProgramHandle, ByRef kernelName As String) As KernelHandle
        Dim value = clCreateKernel(program, kernelName, errCode)
        CheckErr(errCode)
        Return value
    End Function

    Public Function CreateKernelsInProgram(program As ProgramHandle, numKernels As UInt32, kernels As KernelHandle(), <Out> ByRef numKernelsRet As UInt32) As KernelHandle
        Return clCreateKernelsInProgram(program, numKernels, kernels, numKernelsRet)
    End Function

    Public Function CreateProgramWithBinary(context As ContextHandle, numDevices As UInt32, deviceList As DeviceHandle(), lengths As IntPtr(), binaries As IntPtr, binaryStatus As IntPtr) As ProgramHandle
        Dim value = clCreateProgramWithBinary(context, numDevices, deviceList, lengths, binaries, binaryStatus, errCode)
        CheckErr(errCode)
        Return value
    End Function

    Public Function CreateProgramWithSource(context As ContextHandle, count As UInt32, strings As String(), lengths As IntPtr()) As ProgramHandle
        Dim value = clCreateProgramWithSource(context, count, strings, lengths, errCode)
        CheckErr(errCode)
        Return value
    End Function

    Public Function CreateSampler(context As ContextHandle, normalizedCoords As Boolean, addressingMode As AddressingMode, filterMode As FilterMode) As SamplerHandle
        Dim value = clCreateSampler(context, normalizedCoords, addressingMode, filterMode, errCode)
        CheckErr(errCode)
        Return value
    End Function

    Public Sub EnqueueBarrier(commandQueue As CommandQueueHandle)
        errCode = clEnqueueBarrier(commandQueue)
        CheckErr(errCode)
    End Sub

    Public Function EnqueueCopyBuffer(commandQueue As CommandQueueHandle, srcBuffer As ClBuffer, dstBuffer As ClBuffer, srcOffset As SizeT, dstOffset As SizeT, cb As IntPtr, numEventsInWaitList As UInt32, eventWaitList As EventHandle()) As EventHandle
        Dim evt As EventHandle = Nothing
        Dim errCode = clEnqueueCopyBuffer(commandQueue, srcBuffer, dstBuffer, srcOffset, dstOffset, cb, numEventsInWaitList, eventWaitList, evt)
        CheckErr(errCode)
        Return evt
    End Function

    Public Function EnqueueCopyBufferToImage(commandQueue As CommandQueueHandle, srcBuffer As ClBuffer, dstImage As IntPtr, srcOffset As SizeT, dstOrigin As SizeT(), region As SizeT(), numEventsInWaitList As UInt32, eventWaitList As EventHandle()) As EventHandle
        Dim evt As EventHandle = Nothing
        Dim errCode = clEnqueueCopyBufferToImage(commandQueue, srcBuffer, dstImage, srcOffset, dstOrigin, region, numEventsInWaitList, eventWaitList, evt)
        CheckErr(errCode)
        Return evt
    End Function

    Public Function EnqueueCopyImage(commandQueue As CommandQueueHandle, srcImage As IntPtr, dstImage As IntPtr, srcOrigin As SizeT(), dstOrigin As SizeT(), region As SizeT(), numEventsInWaitList As UInt32, eventWaitList As EventHandle()) As EventHandle
        Dim evt As EventHandle = Nothing
        Dim errCode = clEnqueueCopyImage(commandQueue, srcImage, dstImage, srcOrigin, dstOrigin, region, numEventsInWaitList, eventWaitList, evt)
        CheckErr(errCode)
        Return evt
    End Function

    Public Function EnqueueCopyImageToBuffer(commandQueue As CommandQueueHandle, srcImage As IntPtr, dstBuffer As ClBuffer, srcOrigin As SizeT(), region As SizeT(), dstOffset As SizeT, numEventsInWaitList As UInt32, eventWaitList As EventHandle()) As EventHandle
        Dim evt As EventHandle = Nothing
        Dim errCode = clEnqueueCopyImageToBuffer(commandQueue, srcImage, dstBuffer, srcOrigin, region, dstOffset, numEventsInWaitList, eventWaitList, evt)
        CheckErr(errCode)
        Return evt
    End Function

    Public Function EnqueueMapBuffer(commandQueue As CommandQueueHandle, buffer As ClBuffer, blockingMap As Boolean, mapFlags As MapFlags, offset As IntPtr, cb As IntPtr, numEventsInWaitList As UInt32, eventWaitList As EventHandle(), <Out> ByRef evt As EventHandle) As IntPtr
        Dim value = clEnqueueMapBuffer(commandQueue, buffer, blockingMap, mapFlags, offset, cb, numEventsInWaitList, eventWaitList, evt, errCode)
        CheckErr(errCode)
        Return value
    End Function

    Public Function EnqueueMapImage(commandQueue As CommandQueueHandle, image As IntPtr, blockingMap As Boolean, mapFlags As MapFlags, origin As SizeT(), region As SizeT(), <Out> ByRef imageRowPitch As SizeT, <Out> ByRef imageSlicePitch As SizeT, numEventsInWaitList As UInt32, eventWaitList As EventHandle(), <Out> ByRef evt As EventHandle) As IntPtr
        Dim value = clEnqueueMapImage(commandQueue, image, blockingMap, mapFlags, origin, region, imageRowPitch, imageSlicePitch, numEventsInWaitList, eventWaitList, evt, errCode)
        CheckErr(errCode)
        Return value
    End Function

    Public Function EnqueueMarker(commandQueue As CommandQueueHandle) As EventHandle
        Dim evt As EventHandle = Nothing
        Dim errCode = clEnqueueMarker(commandQueue, evt)
        CheckErr(errCode)
        Return evt
    End Function

    Public Function EnqueueNDRangeKernel(commandQueue As CommandQueueHandle, kernel As KernelHandle, workDim As UInt32, globalWorkOffset As SizeT(), globalWorkSize As SizeT(), localWorkSize As SizeT(), numEventsInWaitList As UInt32, eventWaitList As EventHandle()) As EventHandle
        Dim evt As EventHandle = Nothing
        Dim errCode = clEnqueueNDRangeKernel(commandQueue, kernel, workDim, globalWorkOffset, globalWorkSize, localWorkSize, numEventsInWaitList, eventWaitList, evt)
        CheckErr(errCode)
        Return evt
    End Function

    Public Function EnqueueReadBuffer(commandQueue As CommandQueueHandle, buffer As ClBuffer, blockingRead As Boolean, offsetInBytes As SizeT, lengthInBytes As SizeT, ptr As IntPtr, numEventsInWaitList As UInt32, eventWaitList As EventHandle()) As EventHandle
        Dim evt As EventHandle = Nothing
        Dim errCode = clEnqueueReadBuffer(commandQueue, buffer, blockingRead, offsetInBytes, lengthInBytes, ptr, numEventsInWaitList, eventWaitList, evt)
        CheckErr(errCode)
        Return evt
    End Function

    Public Function EnqueueReadImage(commandQueue As CommandQueueHandle, image As ClBuffer, blockingRead As Boolean, origin As SizeT(), region As SizeT(), rowPitch As SizeT, slicePitch As SizeT, ptr As IntPtr, numEventsIntWaitList As UInt32, eventWaitList As EventHandle()) As EventHandle
        Dim evt As EventHandle = Nothing
        Dim errCode = clEnqueueReadImage(commandQueue, image, blockingRead, origin, region, rowPitch, slicePitch, ptr, numEventsIntWaitList, eventWaitList, evt)
        CheckErr(errCode)
        Return evt
    End Function

    Public Function EnqueueTask(commandQueue As CommandQueueHandle, kernel As KernelHandle, numEventsInWaitList As UInt32, eventWaitList As EventHandle()) As EventHandle
        Dim evt As EventHandle = Nothing
        Dim errCode = clEnqueueTask(commandQueue, kernel, numEventsInWaitList, eventWaitList, evt)
        CheckErr(errCode)
        Return evt
    End Function

    Public Function EnqueueUnmapMemObject(commandQueue As CommandQueueHandle, memObj As IntPtr, mappedPtr As IntPtr, numEventsInWaitList As UInt32, eventWaitList As EventHandle()) As EventHandle
        Dim evt As EventHandle = Nothing
        Dim errCode = clEnqueueUnmapMemObject(commandQueue, memObj, mappedPtr, numEventsInWaitList, eventWaitList, evt)
        CheckErr(errCode)
        Return evt
    End Function

End Module
