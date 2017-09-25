# TestApp for [aspnet/EntityFrameworkCore #9249](https://github.com/aspnet/EntityFrameworkCore/issues/9249)

Dynamic invocation test to constructor of `SnapShot<T1, T2, ... , Tn>` with various generic arguments.

* The number of generic arguments from 1 to 30.
* All generic arguments specified same type, like `SnapShot<int, int, ... ,int>`.
* Outputs following value
    * The number of arguments when first failed
    * Size of specified Type (Likely to be relevant)
    * Specified type 

## Results
#### Environment
* IDE
```
Microsoft Visual Studio Community 2017 
Version 15.3.5
VisualStudio.15.Release/15.3.5+26730.16
Microsoft .NET Framework
Version 4.7.02046

インストールされているバージョン:Community

Visual C# 2017   00369-60000-00001-AA411
Microsoft Visual C# 2017

Xamarin   4.7.9.45 (bd7e3753c)
Xamarin.iOS と Xamarin.Android の開発を有効にする Visual Studio 拡張機能

Xamarin.Android SDK   7.4.5.1 (fb018c5)
Xamarin.Android Reference Assemblies and MSBuild support.

Xamarin.iOS and Xamarin.Mac SDK   11.0.0.0 (152b654)
Xamarin.iOS and Xamarin.Mac Reference Assemblies and MSBuild support.
```
* Device
  * iPhone
    * iOS 10.3.3
    * Model: iPhone 7 (Model 1660, 1778, 1779, 1780)
  * iPad mini 4
    * iOS 10.3.3
    * Model: iPad mini 4 (Model A1550)

##### Result1
##### Supported Architecture: ARMv7s+ARM64
The following types are excluded because crashed by other error.

* `float`, `double`

        error: * Assertion: should not be reached at /Users/builder/data/lanes/5024/152b654a/source/xamarin-macios/external/mono/mono/mini/mini-arm64-gsharedvt.c:120

* Nullable&lt;custom struct `Size36`, `Size40`&gt;

        error: * Assertion at /Users/builder/data/lanes/5024/152b654a/source/xamarin-macios/external/mono/mono/mini/mini-arm64.c:1621, condition buffer_offset <= 256' not met

###### output
```
The number of arguments when first failed: 14	Size of Type:   1	Type: System.Byte
The number of arguments when first failed: 14	Size of Type:   1	Type: System.Char
The number of arguments when first failed:  8	Size of Type:   1	Type: TestApp.Size1
The number of arguments when first failed: 14	Size of Type:   2	Type: System.Int16
The number of arguments when first failed: 14	Size of Type:   4	Type: System.Boolean
The number of arguments when first failed: 14	Size of Type:   4	Type: System.Int32
The number of arguments when first failed: 14	Size of Type:   4	Type: System.DayOfWeek
The number of arguments when first failed:  8	Size of Type:   4	Type: TestApp.Size4
The number of arguments when first failed: 14	Size of Type:   8	Type: System.Int64
The number of arguments when first failed:  8	Size of Type:   8	Type: TestApp.Size8
The number of arguments when first failed:  8	Size of Type:   8	Type: System.TimeSpan
The number of arguments when first failed:  8	Size of Type:   8	Type: System.DateTime
The number of arguments when first failed:  4	Size of Type:   9	Type: TestApp.Size9
The number of arguments when first failed:  4	Size of Type:  12	Type: TestApp.Size12
The number of arguments when first failed:  4	Size of Type:  16	Type: System.Decimal
The number of arguments when first failed:  4	Size of Type:  16	Type: System.Guid
The number of arguments when first failed:  4	Size of Type:  16	Type: System.DateTimeOffset
The number of arguments when first failed:  4	Size of Type:  16	Type: TestApp.Size16
The number of arguments when first failed:  8	Size of Type:  20	Type: TestApp.Size20
The number of arguments when first failed:  8	Size of Type:  24	Type: TestApp.Size24
The number of arguments when first failed:  8	Size of Type:  28	Type: TestApp.Size28
The number of arguments when first failed:  8	Size of Type:  32	Type: TestApp.Size32
The number of arguments when first failed:  8	Size of Type:  36	Type: TestApp.Size36
The number of arguments when first failed:  8	Size of Type:  40	Type: TestApp.Size40
The number of arguments when first failed:  8	Size of Type:   8	Type: System.Nullable`1[System.Byte]
The number of arguments when first failed:  8	Size of Type:   8	Type: System.Nullable`1[System.Char]
The number of arguments when first failed:  8	Size of Type:   8	Type: System.Nullable`1[TestApp.Size1]
The number of arguments when first failed:  8	Size of Type:   8	Type: System.Nullable`1[System.Int16]
The number of arguments when first failed:  8	Size of Type:   8	Type: System.Nullable`1[System.Boolean]
The number of arguments when first failed:  8	Size of Type:   8	Type: System.Nullable`1[System.Int32]
The number of arguments when first failed:  8	Size of Type:   8	Type: System.Nullable`1[System.DayOfWeek]
The number of arguments when first failed:  8	Size of Type:   8	Type: System.Nullable`1[TestApp.Size4]
The number of arguments when first failed:  8	Size of Type:   8	Type: System.Nullable`1[System.Single]
The number of arguments when first failed:  4	Size of Type:  16	Type: System.Nullable`1[System.Int64]
The number of arguments when first failed:  4	Size of Type:  16	Type: System.Nullable`1[System.Double]
The number of arguments when first failed:  4	Size of Type:  12	Type: System.Nullable`1[TestApp.Size8]
The number of arguments when first failed:  4	Size of Type:  16	Type: System.Nullable`1[System.TimeSpan]
The number of arguments when first failed:  4	Size of Type:  16	Type: System.Nullable`1[System.DateTime]
The number of arguments when first failed:  4	Size of Type:  16	Type: System.Nullable`1[TestApp.Size12]
The number of arguments when first failed:  8	Size of Type:  20	Type: System.Nullable`1[System.Decimal]
The number of arguments when first failed:  8	Size of Type:  20	Type: System.Nullable`1[System.Guid]
The number of arguments when first failed:  8	Size of Type:  24	Type: System.Nullable`1[System.DateTimeOffset]
The number of arguments when first failed:  8	Size of Type:  20	Type: System.Nullable`1[TestApp.Size16]
The number of arguments when first failed:  8	Size of Type:  24	Type: System.Nullable`1[TestApp.Size20]
The number of arguments when first failed:  8	Size of Type:  28	Type: System.Nullable`1[TestApp.Size24]
The number of arguments when first failed:  8	Size of Type:  32	Type: System.Nullable`1[TestApp.Size28]
The number of arguments when first failed:  8	Size of Type:  36	Type: System.Nullable`1[TestApp.Size32]
The number of arguments when first failed: 14	Size of Type: N/A	Type: System.String
The number of arguments when first failed: 14	Size of Type: N/A	Type: TestApp.Klass
The number of arguments when first failed: 14	Size of Type: N/A	Type: TestApp.GenericKlass`1[System.Int32]
The number of arguments when first failed: 14	Size of Type: N/A	Type: TestApp.GenericKlass`1[System.Nullable`1[System.DateTime]]
The number of arguments when first failed: 14	Size of Type: N/A	Type: TestApp.GenericKlass`1[TestApp.Klass]
```
##### Result2
###### Supported Architecture: ARMv7
No other error.
###### output
```
The number of arguments when first failed : 14	Size of Type:   1	Type: System.Byte
The number of arguments when first failed : 14	Size of Type:   1	Type: System.Char
The number of arguments when first failed : 13	Size of Type:   1	Type: TestApp.Size1
The number of arguments when first failed : 14	Size of Type:   2	Type: System.Int16
The number of arguments when first failed : 14	Size of Type:   4	Type: System.Boolean
The number of arguments when first failed : 14	Size of Type:   4	Type: System.Int32
The number of arguments when first failed : 14	Size of Type:   4	Type: System.Single
The number of arguments when first failed : 14	Size of Type:   4	Type: System.DayOfWeek
The number of arguments when first failed : 13	Size of Type:   4	Type: TestApp.Size4
The number of arguments when first failed :  8	Size of Type:   8	Type: System.Int64
The number of arguments when first failed :  8	Size of Type:   8	Type: System.Double
The number of arguments when first failed :  7	Size of Type:   8	Type: TestApp.Size8
The number of arguments when first failed :  7	Size of Type:   8	Type: System.TimeSpan
The number of arguments when first failed :  7	Size of Type:   8	Type: System.DateTime
The number of arguments when first failed :  5	Size of Type:   9	Type: TestApp.Size9
The number of arguments when first failed :  5	Size of Type:  12	Type: TestApp.Size12
The number of arguments when first failed :  4	Size of Type:  16	Type: System.Decimal
The number of arguments when first failed :  4	Size of Type:  16	Type: System.Guid
The number of arguments when first failed :  5	Size of Type:  12	Type: System.DateTimeOffset
The number of arguments when first failed :  4	Size of Type:  16	Type: TestApp.Size16
The number of arguments when first failed :  3	Size of Type:  20	Type: TestApp.Size20
The number of arguments when first failed :  3	Size of Type:  24	Type: TestApp.Size24
The number of arguments when first failed :  2	Size of Type:  28	Type: TestApp.Size28
The number of arguments when first failed :  2	Size of Type:  32	Type: TestApp.Size32
The number of arguments when first failed :  2	Size of Type:  36	Type: TestApp.Size36
The number of arguments when first failed :  2	Size of Type:  40	Type: TestApp.Size40
The number of arguments when first failed : 13	Size of Type:   8	Type: System.Nullable`1[System.Byte]
The number of arguments when first failed : 13	Size of Type:   8	Type: System.Nullable`1[System.Char]
The number of arguments when first failed : 13	Size of Type:   8	Type: System.Nullable`1[TestApp.Size1]
The number of arguments when first failed : 13	Size of Type:   8	Type: System.Nullable`1[System.Int16]
The number of arguments when first failed : 13	Size of Type:   8	Type: System.Nullable`1[System.Boolean]
The number of arguments when first failed :  7	Size of Type:   8	Type: System.Nullable`1[System.Int32]
The number of arguments when first failed :  7	Size of Type:   8	Type: System.Nullable`1[System.Single]
The number of arguments when first failed :  7	Size of Type:   8	Type: System.Nullable`1[System.DayOfWeek]
The number of arguments when first failed :  7	Size of Type:   8	Type: System.Nullable`1[TestApp.Size4]
The number of arguments when first failed :  5	Size of Type:  12	Type: System.Nullable`1[System.Int64]
The number of arguments when first failed :  5	Size of Type:  12	Type: System.Nullable`1[System.Double]
The number of arguments when first failed :  5	Size of Type:  12	Type: System.Nullable`1[TestApp.Size8]
The number of arguments when first failed :  5	Size of Type:  12	Type: System.Nullable`1[System.TimeSpan]
The number of arguments when first failed :  5	Size of Type:  12	Type: System.Nullable`1[System.DateTime]
The number of arguments when first failed :  4	Size of Type:  16	Type: System.Nullable`1[TestApp.Size12]
The number of arguments when first failed :  3	Size of Type:  20	Type: System.Nullable`1[System.Decimal]
The number of arguments when first failed :  3	Size of Type:  20	Type: System.Nullable`1[System.Guid]
The number of arguments when first failed :  4	Size of Type:  16	Type: System.Nullable`1[System.DateTimeOffset]
The number of arguments when first failed :  3	Size of Type:  20	Type: System.Nullable`1[TestApp.Size16]
The number of arguments when first failed :  3	Size of Type:  24	Type: System.Nullable`1[TestApp.Size20]
The number of arguments when first failed :  2	Size of Type:  28	Type: System.Nullable`1[TestApp.Size24]
The number of arguments when first failed :  2	Size of Type:  32	Type: System.Nullable`1[TestApp.Size28]
The number of arguments when first failed :  2	Size of Type:  36	Type: System.Nullable`1[TestApp.Size32]
The number of arguments when first failed :  2	Size of Type:  40	Type: System.Nullable`1[TestApp.Size36]
The number of arguments when first failed :  2	Size of Type:  44	Type: System.Nullable`1[TestApp.Size40]
The number of arguments when first failed : 14	Size of Type: N/A	Type: System.String
The number of arguments when first failed : 14	Size of Type: N/A	Type: TestApp.Klass
The number of arguments when first failed : 14	Size of Type: N/A	Type: TestApp.GenericKlass`1[System.Int32]
The number of arguments when first failed : 14	Size of Type: N/A	Type: TestApp.GenericKlass`1[System.Nullable`1[System.DateTime]]
The number of arguments when first failed : 14	Size of Type: N/A	Type: TestApp.GenericKlass`1[TestApp.Klass]
```