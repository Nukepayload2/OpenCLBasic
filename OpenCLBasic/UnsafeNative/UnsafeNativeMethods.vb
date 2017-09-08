Imports System.Runtime.InteropServices

Namespace Native

    <HideModuleName>
    Public Module UnsafeNativeMethods

        Public Declare Function clBuildProgram Lib "opencl" (
            program As ProgramHandle,
            numDevices As UInteger,
            deviceList As DeviceHandle(),
            options As String,
            pfnNotify As ProgramNotify,
            userData As IntPtr
        ) As ErrorCode

        Public Declare Function clCreateBuffer Lib "opencl" (
            context As ContextHandle,
            flags As MemFlags,
            size As SizeT,
            hostPtr As IntPtr,
            <Out> ByRef errcodeRet As ErrorCode
        ) As ClBuffer

        Public Declare Function clCreateCommandQueue Lib "opencl" (
            context As ContextHandle,
            device As DeviceHandle,
            properties As CommandQueueProperties,
            <Out> ByRef errorCode As ErrorCode
        ) As CommandQueueHandle

        Public Declare Function clCreateContext Lib "opencl" (
            properties As ContextProperty(),
            numDevices As UInteger,
            devices As DeviceHandle(),
            pfnNotify As ContextNotify,
            userData As IntPtr,
            <Out> ByRef errcodeRet As ErrorCode
        ) As ContextHandle

        Public Declare Function clCreateContextFromType Lib "opencl" (
            properties As ContextProperty(),
            deviceType As DeviceType,
            pfnNotify As ContextNotify,
            userData As IntPtr,
            <Out> ByRef errcodeRet As ErrorCode
        ) As ContextHandle

        Public Declare Function clCreateImage2D Lib "opencl" (
            context As ContextHandle,
            flags As MemFlags,
            ByRef imageFormat As ImageFormat,
            imageWidth As SizeT,
            imageHeight As SizeT,
            imageRowPitch As SizeT,
            hostPtr As IntPtr,
            <Out> ByRef errcodeRet As ErrorCode
        ) As ClBuffer

        Public Declare Function clCreateImage3D Lib "opencl" (
            context As ContextHandle,
            flags As MemFlags,
            ByRef imageFormat As ImageFormat,
            imageWidth As SizeT,
            imageHeight As SizeT,
            imageDepth As SizeT,
            imageRowPitch As SizeT,
            imageSlicePitch As SizeT,
            hostPtr As IntPtr,
            <Out> ByRef errcodeRet As ErrorCode
        ) As ClBuffer

        Public Declare Function clCreateKernel Lib "opencl" (
            program As ProgramHandle,
            kernelName As String,
            <Out> ByRef errcodeRet As ErrorCode
        ) As KernelHandle

        Public Declare Function clCreateKernelsInProgram Lib "opencl" (
            program As ProgramHandle,
            numKernels As UInteger,
            <Out> kernels As KernelHandle(),
            <Out> ByRef numKernelsRet As UInteger
        ) As KernelHandle

        Public Declare Function clCreateProgramWithBinary Lib "opencl" (
            context As ContextHandle,
            numDevices As UInteger,
            deviceList As DeviceHandle(),
            lengths As IntPtr(),
            binaries As IntPtr,
            <Out> binaryStatus As IntPtr,
            <Out> ByRef errcodeRet As ErrorCode
        ) As ProgramHandle

        Public Declare Function clCreateProgramWithSource Lib "opencl" (
            context As ContextHandle,
            count As UInteger,
            strings As String(),
            lengths As IntPtr(),
            <Out> ByRef errcodeRet As ErrorCode
        ) As ProgramHandle

        Public Declare Function clCreateSampler Lib "opencl" (
            context As ContextHandle,
            normalizedCoords As Boolean,
            addressingMode As AddressingMode,
            filterMode As FilterMode,
            <Out> ByRef errCodeRet As ErrorCode
        ) As SamplerHandle

        Public Declare Function clEnqueueBarrier Lib "opencl" (
            commandQueue As CommandQueueHandle
        ) As ErrorCode

        Public Declare Function clEnqueueCopyBuffer Lib "opencl" (
            commandQueue As CommandQueueHandle,
            srcBuffer As ClBuffer,
            dstBuffer As ClBuffer,
            srcOffset As SizeT,
            dstOffset As SizeT,
            cb As IntPtr,
            numEventsInWaitList As UInteger,
            eventWaitList As EventHandle(),
            <Out> ByRef evt As EventHandle
        ) As ErrorCode

        Public Declare Function clEnqueueCopyBufferToImage Lib "opencl" (
            commandQueue As CommandQueueHandle,
            srcBuffer As ClBuffer,
            dstImage As IntPtr,
            srcOffset As SizeT,
            dstOrigin As SizeT(),
            region As SizeT(),
            numEventsInWaitList As UInteger,
            eventWaitList As EventHandle(),
            <Out> ByRef evt As EventHandle
        ) As ErrorCode

        Public Declare Function clEnqueueCopyImage Lib "opencl" (
            commandQueue As CommandQueueHandle,
            srcImage As IntPtr,
            dstImage As IntPtr,
            srcOrigin As SizeT(),
            dstOrigin As SizeT(),
            region As SizeT(),
            numEventsInWaitList As UInteger,
            eventWaitList As EventHandle(),
            <Out> ByRef evt As EventHandle
        ) As ErrorCode

        Public Declare Function clEnqueueCopyImageToBuffer Lib "opencl" (
            commandQueue As CommandQueueHandle,
            srcImage As IntPtr,
            dstBuffer As ClBuffer,
            srcOrigin As SizeT(),
            region As SizeT(),
            dstOffset As SizeT,
            numEventsInWaitList As UInteger,
            eventWaitList As EventHandle(),
            <Out> ByRef evt As EventHandle
        ) As ErrorCode

        Public Declare Function clEnqueueMapBuffer Lib "opencl" (
            commandQueue As CommandQueueHandle,
            buffer As ClBuffer,
            blockingMap As Boolean,
            mapFlags As MapFlags,
            offset As IntPtr,
            cb As IntPtr,
            numEventsInWaitList As UInteger,
            eventWaitList As EventHandle(),
            <Out> ByRef evt As EventHandle,
            <Out> ByRef errCodeRet As ErrorCode
        ) As IntPtr

        Public Declare Function clEnqueueMapImage Lib "opencl" (
            commandQueue As CommandQueueHandle,
            image As IntPtr,
            blockingMap As Boolean,
            mapFlags As MapFlags,
            origin As SizeT(),
            region As SizeT(),
            <Out> ByRef imageRowPitch As SizeT,
            <Out> ByRef imageSlicePitch As SizeT,
            numEventsInWaitList As UInteger,
            eventWaitList As EventHandle(),
            <Out> ByRef evt As EventHandle,
            <Out> ByRef errCodeRet As ErrorCode
        ) As IntPtr

        Public Declare Function clEnqueueMarker Lib "opencl" (
            commandQueue As CommandQueueHandle,
            <Out> ByRef evt As EventHandle
        ) As ErrorCode

        Public Declare Function clEnqueueNDRangeKernel Lib "opencl" (
            commandQueue As CommandQueueHandle,
            kernel As KernelHandle,
            workDim As UInteger,
            globalWorkOffset As SizeT(),
            globalWorkSize As SizeT(),
            localWorkSize As SizeT(),
            numEventsInWaitList As UInteger,
            eventWaitList As EventHandle(),
            <Out> ByRef evt As EventHandle
        ) As ErrorCode

        Public Declare Function clEnqueueReadBuffer Lib "opencl" (
            commandQueue As CommandQueueHandle,
            buffer As ClBuffer,
            blockingRead As Boolean,
            offsetInBytes As SizeT,
            lengthInBytes As SizeT,
            ptr As IntPtr,
            numEventsInWaitList As UInteger,
            eventWaitList As EventHandle(),
            <Out> ByRef evt As EventHandle
        ) As ErrorCode

        Public Declare Function clEnqueueReadImage Lib "opencl" (
            commandQueue As CommandQueueHandle,
            image As ClBuffer,
            blockingRead As Boolean,
            origin As SizeT(),
            region As SizeT(),
            rowPitch As SizeT,
            slicePitch As SizeT,
            ptr As IntPtr,
            numEventsIntWaitList As UInteger,
            eventWaitList As EventHandle(),
            <Out> ByRef evt As EventHandle
        ) As ErrorCode

        Public Declare Function clEnqueueTask Lib "opencl" (
            commandQueue As CommandQueueHandle,
            kernel As KernelHandle,
            numEventsInWaitList As UInteger,
            eventWaitList As EventHandle(),
            <Out> ByRef evt As EventHandle
        ) As ErrorCode

        Public Declare Function clEnqueueUnmapMemObject Lib "opencl" (
            commandQueue As CommandQueueHandle,
            memObj As IntPtr,
            mappedPtr As IntPtr,
            numEventsInWaitList As UInteger,
            eventWaitList As EventHandle(),
            <Out> ByRef evt As EventHandle
        ) As ErrorCode

        Public Declare Function clEnqueueWaitForEvents Lib "opencl" (
            commandQueue As CommandQueueHandle,
            numEventsInWaitList As UInteger,
            eventWaitList As EventHandle()
        ) As ErrorCode

        Public Declare Function clEnqueueWriteBuffer Lib "opencl" (
            commandQueue As CommandQueueHandle,
            buffer As ClBuffer,
            blockingWrite As Boolean,
            offsetInBytes As SizeT,
            lengthInBytes As SizeT,
            ptr As IntPtr,
            numEventsInWaitList As UInteger,
            eventWaitList As EventHandle(),
            <Out> ByRef evt As EventHandle
        ) As ErrorCode

        Public Declare Function clEnqueueWriteImage Lib "opencl" (
            commandQueue As CommandQueueHandle,
            image As ClBuffer,
            blockingWrite As Boolean,
            origin As SizeT(),
            region As SizeT(),
            rowPitch As SizeT,
            slicePitch As SizeT,
            ptr As IntPtr,
            numEventsIntWaitList As UInteger,
            eventWaitList As EventHandle(),
            <Out> ByRef evt As EventHandle
        ) As ErrorCode

        Public Declare Function clFinish Lib "opencl" (
            commandQueue As CommandQueueHandle
        ) As ErrorCode

        Public Declare Function clFlush Lib "opencl" (
            commandQueue As CommandQueueHandle
        ) As ErrorCode

        Public Declare Function clGetCommandQueueInfo Lib "opencl" (
            commandQueue As CommandQueueHandle,
            paramKind As CommandQueueInfo,
            paramValueSize As SizeT,
            paramValue As IntPtr,
            <Out> ByRef paramValueSizeRet As SizeT
        ) As ErrorCode

        Public Declare Function clGetContextInfo Lib "opencl" (
            context As ContextHandle,
            paramKind As ContextInfo,
            paramValueSize As SizeT,
            paramValue As IntPtr,
            <Out> ByRef paramValueSizeRet As SizeT
        ) As ErrorCode

        Public Declare Function clGetDeviceIDs Lib "opencl" (
            platform As PlatformHandle,
            deviceType As DeviceType,
            numEntries As UInteger,
            <Out> devices As DeviceHandle(),
            <Out> ByRef numDevices As UInteger
        ) As ErrorCode

        Public Declare Function clGetDeviceInfo Lib "opencl" (
            device As DeviceHandle,
            paramKind As DeviceInfo,
            paramValueSize As SizeT,
            paramValue As IntPtr,
            <Out> ByRef paramValueSizeRet As SizeT
        ) As ErrorCode

        Public Declare Function clGetEventInfo Lib "opencl" (
            eventHandle As EventHandle,
            paramKind As EventInfo,
            paramValueSize As SizeT,
            paramValue As IntPtr,
            <Out> ByRef paramValueSizeRet As SizeT
        ) As ErrorCode

        Public Declare Function clGetEventProfilingInfo Lib "opencl" (
            eventHandle As EventHandle,
            paramKind As ProfilingInfo,
            paramValueSize As SizeT,
            paramValue As IntPtr,
            <Out> ByRef paramValueSizeRet As SizeT
        ) As ErrorCode

        Public Declare Function clGetExtensionFunctionAddress Lib "opencl" (
            funcName As String
        ) As IntPtr 'Delegate

        Public Declare Function clGetImageInfo Lib "opencl" (
            image As IntPtr,
            paramType As ImageInfo,
            paramValueSize As SizeT,
            paramValue As IntPtr,
            <Out> ByRef paramValueSizeRet As SizeT
        ) As ErrorCode

        Public Declare Function clGetKernelInfo Lib "opencl" (
            kernel As KernelHandle,
            paramKind As KernelInfo,
            paramValueSize As SizeT,
            paramValue As IntPtr,
            <Out> ByRef paramValueSizeRet As SizeT
        ) As ErrorCode

        Public Declare Function clGetKernelWorkGroupInfo Lib "opencl" (
            kernel As KernelHandle,
            device As DeviceHandle,
            paramKind As KernelWorkGroupInfo,
            paramValueSize As SizeT,
            paramValue As IntPtr,
            <Out> ByRef paramValueSizeRet As SizeT
        ) As ErrorCode

        Public Declare Function clGetMemObjectInfo Lib "opencl" (
            memObj As IntPtr,
            paramKind As MemInfo,
            paramValueSize As SizeT,
            paramValue As IntPtr,
            <Out> ByRef paramValueSizeRet As SizeT
        ) As ErrorCode

        Public Declare Function clGetPlatformIDs Lib "opencl" (
            numEntries As UInteger,
            <Out> platforms As PlatformHandle(),
            <Out> ByRef numPlatforms As UInteger
        ) As ErrorCode

        Public Declare Function clGetPlatformInfo Lib "opencl" (
            platform As PlatformHandle,
            paramKind As PlatformInfo,
            paramValueSize As SizeT,
            paramValue As IntPtr,
            <Out> ByRef paramValueSizeRet As SizeT
        ) As ErrorCode

        Public Declare Function clGetProgramBuildInfo Lib "opencl" (
            program As ProgramHandle,
            device As DeviceHandle,
            paramKind As ProgramBuildInfo,
            paramValueSize As SizeT,
            paramValue As IntPtr,
            <Out> ByRef paramValueSizeRet As SizeT
        ) As ErrorCode

        Public Declare Function clGetProgramInfo Lib "opencl" (
            program As ProgramHandle,
            paramKind As ProgramInfo,
            paramValueSize As SizeT,
            paramValue As IntPtr,
            <Out> ByRef paramValueSizeRet As SizeT
        ) As ErrorCode

        Public Declare Function clGetSamplerInfo Lib "opencl" (
            sampler As SamplerHandle,
            paramKind As SamplerInfo,
            paramValueSize As SizeT,
            paramValue As IntPtr,
            <Out> ByRef paramValueSizeRet As SizeT
        ) As ErrorCode

        Public Declare Function clGetSupportedImageFormats Lib "opencl" (
            context As ContextHandle,
            flags As MemFlags,
            imageType As MemObjectType,
            numEntries As UInteger,
            <Out> imageFormats As ImageFormat(),
            <Out> ByRef numImageFormats As UInteger
        ) As ErrorCode

        Public Declare Function clReleaseCommandQueue Lib "opencl" (
            commandQueue As CommandQueueHandle
        ) As ErrorCode

        Public Declare Function clReleaseContext Lib "opencl" (
            context As ContextHandle
        ) As ErrorCode

        Public Declare Function clReleaseEvent Lib "opencl" (
            eventHandle As EventHandle
        ) As ErrorCode

        Public Declare Function clReleaseKernel Lib "opencl" (
            kernel As KernelHandle
        ) As ErrorCode

        Public Declare Function clReleaseMemObject Lib "opencl" (
            memObj As ClBuffer
        ) As ErrorCode

        Public Declare Function clReleaseProgram Lib "opencl" (
            program As ProgramHandle
        ) As ErrorCode

        Public Declare Function clReleaseSampler Lib "opencl" (
            sampler As SamplerHandle
        ) As ErrorCode

        Public Declare Function clRetainCommandQueue Lib "opencl" (
            commandQueue As CommandQueueHandle
        ) As ErrorCode

        Public Declare Function clRetainContext Lib "opencl" (
            context As ContextHandle
        ) As ErrorCode

        Public Declare Function clRetainEvent Lib "opencl" (
            eventHandle As EventHandle
        ) As ErrorCode

        Public Declare Function clRetainKernel Lib "opencl" (
            kernel As KernelHandle
        ) As ErrorCode

        Public Declare Function clRetainMemObject Lib "opencl" (
            memObj As IntPtr
        ) As ErrorCode

        Public Declare Function clRetainProgram Lib "opencl" (
            program As ProgramHandle
        ) As ErrorCode

        Public Declare Function clRetainSampler Lib "opencl" (
            sampler As SamplerHandle
        ) As ErrorCode

        Public Declare Function clSetCommandQueueProperty Lib "opencl" (
            commandQueue As CommandQueueHandle,
            properties As CommandQueueProperties,
            enable As Boolean,
            <Out> ByRef oldProperties As CommandQueueProperties
        ) As ErrorCode

        Public Declare Function clSetKernelArg Lib "opencl" (
            kernel As KernelHandle,
            argIndex As UInteger,
            argSize As SizeT,
            ByRef argValue As ClBuffer
        ) As ErrorCode

        Public Declare Function clUnloadCompiler Lib "opencl" (
        ) As ErrorCode

        Public Declare Function clWaitForEvents Lib "opencl" (
            numEvents As UInteger,
            eventWaitList As EventHandle()
        ) As ErrorCode
    End Module

End Namespace