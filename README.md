# OpenCLBasic
Provides Visual Basic friendly OpenCL API bindings as a .NET Standard 2.0 class library.

It's a replacement of OpenCL.Net. Users will not be limited with the Eclipse Public License which is too strict.

## VB friendly
You'll not encounter the following issues if you replace OpenCL.Net with this library:
- Have `Optional` parameters before `ParamArray`.
- Generic constraints with enum types.
- Error handling without `Try` ... `Catch`.
- Some of the Type Names such as `uint4` are not VB-ish.
- Have to use c# `static class` instead of vb `Module`.
- Unable to use existing PInvoke declarations directly.
- Memory leak when using `InfoBuffer` improperly.

## Performance improvements
With enhanced wrapping logic, unnecessary memory copy and pinning are reduced. It's 20ms to 50ms faster while processing 200 images on the author's low end computer.

## Releases
[View on Nuget](https://www.nuget.org/packages/OpenCLBasic/)

# OpenCLBasic
对 VB 友好的 OpenCL 包装 .NET Standard 2.0 类库。

这是 OpenCL.Net 的替代品。让使用者不再受到 Eclipse Public License 这样严格的限制。

## VB 友好
使用这个类库将不再遇到可能在 OpenCL.Net 遇到的以下麻烦:
- `Optional` 参数后带有 `ParamArray`
- 泛型类型约束带有枚举类型
- 异常处理需要手动判断错误码
- 类型名称（如: uint4）不符合 VB 语言规范
- 仅存放非实例成员的类型不是 `Module`
- 不能直接使用其中声明的 PInvoke
- 使用 InfoBuffer 时内存泄漏存在较高风险

## 性能提升
改进了包装逻辑，减少了内存复制和固定。在作者的破电脑上处理 200 张图片加速 20 到 50 毫秒。

## 发行
[在 Nuget 查看](https://www.nuget.org/packages/OpenCLBasic/)
