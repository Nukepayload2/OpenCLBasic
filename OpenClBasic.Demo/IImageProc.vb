Imports System.Drawing

Public Interface IImageProc
    Inherits IDisposable
    Function Invoke(imageA As Bitmap, imageB As Bitmap) As Bitmap
End Interface
