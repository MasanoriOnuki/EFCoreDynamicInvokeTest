using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System.Runtime.InteropServices;

namespace TestApp
{
    public class Application
    {
        // This is the main entry point of the application.
        static void Main(string[] args)
        {
            var maxArgumentCount = 30;
            SameTypeTest<byte>(maxArgumentCount);
            SameTypeTest<char>(maxArgumentCount);
            SameTypeTest<Size1>(maxArgumentCount);
            SameTypeTest<short>(maxArgumentCount);
            SameTypeTest<bool>(maxArgumentCount);
            SameTypeTest<int>(maxArgumentCount);
            //SameTypeTest<float>(maxArgumentCount); // error: * Assertion: should not be reached at /Users/builder/data/lanes/5024/152b654a/source/xamarin-macios/external/mono/mono/mini/mini-arm64-gsharedvt.c:120
            SameTypeTest<DayOfWeek>(maxArgumentCount);
            SameTypeTest<Size4>(maxArgumentCount);
            SameTypeTest<long>(maxArgumentCount);
            //SameTypeTest<double>(maxArgumentCount); // ditto
            SameTypeTest<Size8>(maxArgumentCount);
            SameTypeTest<TimeSpan>(maxArgumentCount);
            SameTypeTest<DateTime>(maxArgumentCount);
            SameTypeTest<Size9>(maxArgumentCount);
            SameTypeTest<Size12>(maxArgumentCount);
            SameTypeTest<decimal>(maxArgumentCount);
            SameTypeTest<Guid>(maxArgumentCount);
            SameTypeTest<DateTimeOffset>(maxArgumentCount);
            SameTypeTest<Size16>(maxArgumentCount);
            SameTypeTest<Size20>(maxArgumentCount);
            SameTypeTest<Size24>(maxArgumentCount);
            SameTypeTest<Size28>(maxArgumentCount);
            SameTypeTest<Size32>(maxArgumentCount);
            SameTypeTest<Size36>(maxArgumentCount);
            SameTypeTest<Size40>(maxArgumentCount);
            SameTypeTest<byte?>(maxArgumentCount);
            SameTypeTest<char?>(maxArgumentCount);
            SameTypeTest<Size1?>(maxArgumentCount);
            SameTypeTest<short?>(maxArgumentCount);
            SameTypeTest<bool?>(maxArgumentCount);
            SameTypeTest<int?>(maxArgumentCount);
            SameTypeTest<float?>(maxArgumentCount);
            SameTypeTest<DayOfWeek?>(maxArgumentCount);
            SameTypeTest<Size4?>(maxArgumentCount);
            SameTypeTest<long?>(maxArgumentCount);
            SameTypeTest<double?>(maxArgumentCount);
            SameTypeTest<Size8?>(maxArgumentCount);
            SameTypeTest<TimeSpan?>(maxArgumentCount);
            SameTypeTest<DateTime?>(maxArgumentCount);
            SameTypeTest<Size12?>(maxArgumentCount);
            SameTypeTest<decimal?>(maxArgumentCount);
            SameTypeTest<Guid?>(maxArgumentCount);
            SameTypeTest<DateTimeOffset?>(maxArgumentCount);
            SameTypeTest<Size16?>(maxArgumentCount);
            SameTypeTest<Size20?>(maxArgumentCount);
            SameTypeTest<Size24?>(maxArgumentCount);
            SameTypeTest<Size28?>(maxArgumentCount);
            SameTypeTest<Size32?>(maxArgumentCount);
            SameTypeTest<Size36?>(maxArgumentCount);
            SameTypeTest<Size40?>(maxArgumentCount);
            SameTypeTest<string>(maxArgumentCount);
            SameTypeTest<Klass>(maxArgumentCount);
            SameTypeTest<GenericKlass<int>>(maxArgumentCount);
            SameTypeTest<GenericKlass<DateTime?>>(maxArgumentCount);
            SameTypeTest<GenericKlass<Klass>>(maxArgumentCount);
        }

        private static void SameTypeTest<T>(int maxArgumentCount)
        {
            var type = typeof(T);
            var results = new Dictionary<int, bool>();

            foreach (var argumentCount in Enumerable.Range(1, maxArgumentCount))
            {
                if (type.IsValueType && SizeOf<T>() * argumentCount >= 256)
                {
                    break;
                }

                var types = Enumerable.Repeat(type, argumentCount).ToArray();
                results.Add(argumentCount, TestDynamicInvoke(types));
            }

            Console.Out.Write($"Number of arguments when first failed : {results.First(r => !r.Value).Key, 2}");
            Console.Out.Write($"	Size of Type: {(type.IsValueType ? SizeOf<T>().ToString() : "N/A"), 3}");
            Console.Out.WriteLine($"	Type: {type}");
        }

        private static bool TestDynamicInvoke(Type[] types)
        {
            var snapShotFunc = CreateSnapShotFunc(types);

            try
            {
                snapShotFunc.Invoke();
                return true;
            }
            catch (ExecutionEngineException ex)
            {
                return false;
            }
        }

        private static Func<ISnapshot> CreateSnapShotFunc(Type[] types)
            => Expression.Lambda<Func<ISnapshot>>(Expression.New(
                    GetSnapShotConstrucorInfo(types),
                    types.Select(CreateDefaultExpression).ToArray()))
                .Compile();

        private static ConstructorInfo GetSnapShotConstrucorInfo(Type[] types)
            => Snapshot.CreateSnapshotType(types).GetConstructor(types);

        private static Expression CreateDefaultExpression(Type type)
            => Expression.Constant(type.IsValueType ? Activator.CreateInstance(type) : null, type);

        private static int SizeOf<T>()
        {
            try
            {
                var type = typeof(T);
                return Marshal.SizeOf(type.IsEnum ? type.GetEnumUnderlyingType() : type);
            }
            // DateTime and DateTimeOffset throw ArgumentException
            catch
            {
                return Marshal.SizeOf(new TypeSizePtoxy<T>());
            }
        }
    }

    class Klass
    { }

    class GenericKlass<T>
    { }

    struct TypeSizePtoxy<T>
    {
        T Value;
    }

    struct Size1
    {
        byte Value1;
    }

    struct Size4
    {
        int Value1;
    }

    struct Size8
    {
        int Value1, Value2;
    }

    struct Size9
    {
        byte Value1, Value2, Value3, Value4, Value5, Value6, Value7, Value8, Value9;
    }

    struct Size12
    {
        int Value1, Value2, Value3;
    }

    struct Size16
    {
        int Value1, Value2, Value3, Value4;
    }

    struct Size20
    {
        int Value1, Value2, Value3, Value4, Value5;
    }

    struct Size24
    {
        int Value1, Value2, Value3, Value4, Value5, Value6;
    }

    struct Size28
    {
        int Value1, Value2, Value3, Value4, Value5, Value6, Value7;
    }

    struct Size32
    {
        int Value1, Value2, Value3, Value4, Value5, Value6, Value7, Value8;
    }

    struct Size36
    {
        int Value1, Value2, Value3, Value4, Value5, Value6, Value7, Value8, Value9;
    }

    struct Size40
    {
        int Value1, Value2, Value3, Value4, Value5, Value6, Value7, Value8, Value9, Value10;
    }
}