using System;
using System.Diagnostics;
namespace NGenericDimensions.Math
{
    internal class GenericOperatorMath<T> where T : struct, IComparable, IFormattable, IComparable<T>, IEquatable<T>
    {
        internal delegate T TMath(T value1, T value2);
        internal delegate bool TMathBoolean(T value1, T value2);
        internal delegate double ConvertTToDouble(T value);
        internal delegate T ConvertDoubleToT(double value);
        
        public static TMath Add;
        public static TMath Subtract;
        public static TMath Multiply;
        public static TMathBoolean LessThan;
        public static TMathBoolean GreaterThan;
        public static TMathBoolean LessThanOrEqualTo;
        public static TMathBoolean GreaterThanOrEqualTo;
        public static ConvertTToDouble ConvertToDouble;
        public static ConvertDoubleToT ConvertFromDouble;

        [DebuggerStepThrough()]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1810:Initialize reference type static fields inline", Justification = "Don't know a cleaner way than this.")]
        static GenericOperatorMath()
        {
            if (ReferenceEquals(typeof(T), typeof(Int16)))
            {
                Add = CastDelegate<TMath>((Func<Int16, Int16, Int16>)((Int16 a, Int16 b) => (Int16)(a + b)));
                Subtract = CastDelegate<TMath>((Func<Int16, Int16, Int16>)((Int16 a, Int16 b) => (Int16)(a - b)));
                Multiply = CastDelegate<TMath>((Func<Int16, Int16, Int16>)((Int16 a, Int16 b) => (Int16)(a * b)));
                LessThan = CastDelegate<TMathBoolean>((Func<Int16, Int16, bool>)((Int16 a, Int16 b) => a < b));
                GreaterThan = CastDelegate<TMathBoolean>((Func<Int16, Int16, bool>)((Int16 a, Int16 b) => a > b));
                LessThanOrEqualTo = CastDelegate<TMathBoolean>((Func<Int16, Int16, bool>)((Int16 a, Int16 b) => a <= b));
                GreaterThanOrEqualTo = CastDelegate<TMathBoolean>((Func<Int16, Int16, bool>)((Int16 a, Int16 b) => a >= b));
                ConvertToDouble = CastDelegate<ConvertTToDouble>((Func<Int16, double>)((Int16 v) => Convert.ToDouble(v)));
                ConvertFromDouble = CastDelegate<ConvertDoubleToT>((Func<double, Int16>)((double v) => Convert.ToInt16(v)));
            }
            else if (ReferenceEquals(typeof(T), typeof(Int32)))
            {
                Add = CastDelegate<TMath>((Func<Int32, Int32, Int32>)((Int32 a, Int32 b) => a + b));
                Subtract = CastDelegate<TMath>((Func<Int32, Int32, Int32>)((Int32 a, Int32 b) => a - b));
                Multiply = CastDelegate<TMath>((Func<Int32, Int32, Int32>)((Int32 a, Int32 b) => a * b));
                LessThan = CastDelegate<TMathBoolean>((Func<Int32, Int32, bool>)((Int32 a, Int32 b) => a < b));
                GreaterThan = CastDelegate<TMathBoolean>((Func<Int32, Int32, bool>)((Int32 a, Int32 b) => a > b));
                LessThanOrEqualTo = CastDelegate<TMathBoolean>((Func<Int32, Int32, bool>)((Int32 a, Int32 b) => a <= b));
                GreaterThanOrEqualTo = CastDelegate<TMathBoolean>((Func<Int32, Int32, bool>)((Int32 a, Int32 b) => a >= b));
                ConvertToDouble = CastDelegate<ConvertTToDouble>((Func<Int32, double>)((Int32 v) => Convert.ToDouble(v)));
                ConvertFromDouble = CastDelegate<ConvertDoubleToT>((Func<double, Int32>)((double v) => Convert.ToInt32(v)));
            }
            else if (ReferenceEquals(typeof(T), typeof(Int64)))
            {
                Add = CastDelegate<TMath>((Func<Int64, Int64, Int64>)((Int64 a, Int64 b) => a + b));
                Subtract = CastDelegate<TMath>((Func<Int64, Int64, Int64>)((Int64 a, Int64 b) => a - b));
                Multiply = CastDelegate<TMath>((Func<Int64, Int64, Int64>)((Int64 a, Int64 b) => a * b));
                LessThan = CastDelegate<TMathBoolean>((Func<Int64, Int64, bool>)((Int64 a, Int64 b) => a < b));
                GreaterThan = CastDelegate<TMathBoolean>((Func<Int64, Int64, bool>)((Int64 a, Int64 b) => a > b));
                LessThanOrEqualTo = CastDelegate<TMathBoolean>((Func<Int64, Int64, bool>)((Int64 a, Int64 b) => a <= b));
                GreaterThanOrEqualTo = CastDelegate<TMathBoolean>((Func<Int64, Int64, bool>)((Int64 a, Int64 b) => a >= b));
                ConvertToDouble = CastDelegate<ConvertTToDouble>((Func<Int64, double>)((Int64 v) => Convert.ToDouble(v)));
                ConvertFromDouble = CastDelegate<ConvertDoubleToT>((Func<double, Int64>)((double v) => Convert.ToInt64(v)));
            }
            else if (ReferenceEquals(typeof(T), typeof(UInt16)))
            {
                Add = CastDelegate<TMath>((Func<UInt16, UInt16, UInt16>)((UInt16 a, UInt16 b) => (UInt16)(a + b)));
                Subtract = CastDelegate<TMath>((Func<UInt16, UInt16, UInt16>)((UInt16 a, UInt16 b) => (UInt16)(a - b)));
                Multiply = CastDelegate<TMath>((Func<UInt16, UInt16, UInt16>)((UInt16 a, UInt16 b) => (UInt16)(a * b)));
                LessThan = CastDelegate<TMathBoolean>((Func<UInt16, UInt16, bool>)((UInt16 a, UInt16 b) => a < b));
                GreaterThan = CastDelegate<TMathBoolean>((Func<UInt16, UInt16, bool>)((UInt16 a, UInt16 b) => a > b));
                LessThanOrEqualTo = CastDelegate<TMathBoolean>((Func<UInt16, UInt16, bool>)((UInt16 a, UInt16 b) => a <= b));
                GreaterThanOrEqualTo = CastDelegate<TMathBoolean>((Func<UInt16, UInt16, bool>)((UInt16 a, UInt16 b) => a >= b));
                ConvertToDouble = CastDelegate<ConvertTToDouble>((Func<UInt16, double>)((UInt16 v) => Convert.ToDouble(v)));
                ConvertFromDouble = CastDelegate<ConvertDoubleToT>((Func<double, UInt16>)((double v) => Convert.ToUInt16(v)));
            }
            else if (ReferenceEquals(typeof(T), typeof(UInt32)))
            {
                Add = CastDelegate<TMath>((Func<UInt32, UInt32, UInt32>)((UInt32 a, UInt32 b) => a + b));
                Subtract = CastDelegate<TMath>((Func<UInt32, UInt32, UInt32>)((UInt32 a, UInt32 b) => a - b));
                Multiply = CastDelegate<TMath>((Func<UInt32, UInt32, UInt32>)((UInt32 a, UInt32 b) => a * b));
                LessThan = CastDelegate<TMathBoolean>((Func<UInt32, UInt32, bool>)((UInt32 a, UInt32 b) => a < b));
                GreaterThan = CastDelegate<TMathBoolean>((Func<UInt32, UInt32, bool>)((UInt32 a, UInt32 b) => a > b));
                LessThanOrEqualTo = CastDelegate<TMathBoolean>((Func<UInt32, UInt32, bool>)((UInt32 a, UInt32 b) => a <= b));
                GreaterThanOrEqualTo = CastDelegate<TMathBoolean>((Func<UInt32, UInt32, bool>)((UInt32 a, UInt32 b) => a >= b));
                ConvertToDouble = CastDelegate<ConvertTToDouble>((Func<UInt32, double>)((UInt32 v) => Convert.ToDouble(v)));
                ConvertFromDouble = CastDelegate<ConvertDoubleToT>((Func<double, UInt32>)((double v) => Convert.ToUInt32(v)));
            }
            else if (ReferenceEquals(typeof(T), typeof(UInt64)))
            {
                Add = CastDelegate<TMath>((Func<UInt64, UInt64, UInt64>)((UInt64 a, UInt64 b) => a + b));
                Subtract = CastDelegate<TMath>((Func<UInt64, UInt64, UInt64>)((UInt64 a, UInt64 b) => a - b));
                Multiply = CastDelegate<TMath>((Func<UInt64, UInt64, UInt64>)((UInt64 a, UInt64 b) => a * b));
                LessThan = CastDelegate<TMathBoolean>((Func<UInt64, UInt64, bool>)((UInt64 a, UInt64 b) => a < b));
                GreaterThan = CastDelegate<TMathBoolean>((Func<UInt64, UInt64, bool>)((UInt64 a, UInt64 b) => a > b));
                LessThanOrEqualTo = CastDelegate<TMathBoolean>((Func<UInt64, UInt64, bool>)((UInt64 a, UInt64 b) => a <= b));
                GreaterThanOrEqualTo = CastDelegate<TMathBoolean>((Func<UInt64, UInt64, bool>)((UInt64 a, UInt64 b) => a >= b));
                ConvertToDouble = CastDelegate<ConvertTToDouble>((Func<UInt64, double>)((UInt64 v) => Convert.ToDouble(v)));
                ConvertFromDouble = CastDelegate<ConvertDoubleToT>((Func<double, UInt64>)((double v) => Convert.ToUInt64(v)));
            }
            else if (ReferenceEquals(typeof(T), typeof(float)))
            {
                Add = CastDelegate<TMath>((Func<float, float, float>)((float a, float b) => a + b));
                Subtract = CastDelegate<TMath>((Func<float, float, float>)((float a, float b) => a - b));
                Multiply = CastDelegate<TMath>((Func<float, float, float>)((float a, float b) => a * b));
                LessThan = CastDelegate<TMathBoolean>((Func<float, float, bool>)((float a, float b) => a < b));
                GreaterThan = CastDelegate<TMathBoolean>((Func<float, float, bool>)((float a, float b) => a > b));
                LessThanOrEqualTo = CastDelegate<TMathBoolean>((Func<float, float, bool>)((float a, float b) => a <= b));
                GreaterThanOrEqualTo = CastDelegate<TMathBoolean>((Func<float, float, bool>)((float a, float b) => a >= b));
                ConvertToDouble = CastDelegate<ConvertTToDouble>((Func<float, double>)((float v) => Convert.ToDouble(v)));
                ConvertFromDouble = CastDelegate<ConvertDoubleToT>((Func<double, float>)((double v) => Convert.ToSingle(v)));
            }
            else if (ReferenceEquals(typeof(T), typeof(double)))
            {
                Add = CastDelegate<TMath>((Func<double, double, double>)((double a, double b) => a + b));
                Subtract = CastDelegate<TMath>((Func<double, double, double>)((double a, double b) => a - b));
                Multiply = CastDelegate<TMath>((Func<double, double, double>)((double a, double b) => a * b));
                LessThan = CastDelegate<TMathBoolean>((Func<double, double, bool>)((double a, double b) => a < b));
                GreaterThan = CastDelegate<TMathBoolean>((Func<double, double, bool>)((double a, double b) => a > b));
                LessThanOrEqualTo = CastDelegate<TMathBoolean>((Func<double, double, bool>)((double a, double b) => a <= b));
                GreaterThanOrEqualTo = CastDelegate<TMathBoolean>((Func<double, double, bool>)((double a, double b) => a >= b));
                ConvertToDouble = CastDelegate<ConvertTToDouble>((Func<double, double>)((double v) => v));
                ConvertFromDouble = CastDelegate<ConvertDoubleToT>((Func<double, double>)((double v) => v));
            }
            else if (ReferenceEquals(typeof(T), typeof(decimal)))
            {
                Add = CastDelegate<TMath>((Func<decimal, decimal, decimal>)((decimal a, decimal b) => a + b));
                Subtract = CastDelegate<TMath>((Func<decimal, decimal, decimal>)((decimal a, decimal b) => a - b));
                Multiply = CastDelegate<TMath>((Func<decimal, decimal, decimal>)((decimal a, decimal b) => a * b));
                LessThan = CastDelegate<TMathBoolean>((Func<decimal, decimal, bool>)((decimal a, decimal b) => a < b));
                GreaterThan = CastDelegate<TMathBoolean>((Func<decimal, decimal, bool>)((decimal a, decimal b) => a > b));
                LessThanOrEqualTo = CastDelegate<TMathBoolean>((Func<decimal, decimal, bool>)((decimal a, decimal b) => a <= b));
                GreaterThanOrEqualTo = CastDelegate<TMathBoolean>((Func<decimal, decimal, bool>)((decimal a, decimal b) => a >= b));
                ConvertToDouble = CastDelegate<ConvertTToDouble>((Func<decimal, double>)((decimal v) => Convert.ToDouble(v)));
                ConvertFromDouble = CastDelegate<ConvertDoubleToT>((Func<double, decimal>)((double v) => Convert.ToDecimal(v)));
            }
            else if (ReferenceEquals(typeof(T), typeof(sbyte)))
            {
                Add = CastDelegate<TMath>((Func<sbyte, sbyte, sbyte>)((sbyte a, sbyte b) => (sbyte)(a + b)));
                Subtract = CastDelegate<TMath>((Func<sbyte, sbyte, sbyte>)((sbyte a, sbyte b) => (sbyte)(a - b)));
                Multiply = CastDelegate<TMath>((Func<sbyte, sbyte, sbyte>)((sbyte a, sbyte b) => (sbyte)(a * b)));
                LessThan = CastDelegate<TMathBoolean>((Func<sbyte, sbyte, bool>)((sbyte a, sbyte b) => a < b));
                GreaterThan = CastDelegate<TMathBoolean>((Func<sbyte, sbyte, bool>)((sbyte a, sbyte b) => a > b));
                LessThanOrEqualTo = CastDelegate<TMathBoolean>((Func<sbyte, sbyte, bool>)((sbyte a, sbyte b) => a <= b));
                GreaterThanOrEqualTo = CastDelegate<TMathBoolean>((Func<sbyte, sbyte, bool>)((sbyte a, sbyte b) => a >= b));
                ConvertToDouble = CastDelegate<ConvertTToDouble>((Func<sbyte, double>)((sbyte v) => Convert.ToDouble(v)));
                ConvertFromDouble = CastDelegate<ConvertDoubleToT>((Func<double, sbyte>)((double v) => Convert.ToSByte(v)));
            }
            else if (ReferenceEquals(typeof(T), typeof(byte)))
            {
                Add = CastDelegate<TMath>((Func<byte, byte, byte>)((byte a, byte b) => (byte)(a + b)));
                Subtract = CastDelegate<TMath>((Func<byte, byte, byte>)((byte a, byte b) => (byte)(a - b)));
                Multiply = CastDelegate<TMath>((Func<byte, byte, byte>)((byte a, byte b) => (byte)(a * b)));
                LessThan = CastDelegate<TMathBoolean>((Func<byte, byte, bool>)((byte a, byte b) => a < b));
                GreaterThan = CastDelegate<TMathBoolean>((Func<byte, byte, bool>)((byte a, byte b) => a > b));
                LessThanOrEqualTo = CastDelegate<TMathBoolean>((Func<byte, byte, bool>)((byte a, byte b) => a <= b));
                GreaterThanOrEqualTo = CastDelegate<TMathBoolean>((Func<byte, byte, bool>)((byte a, byte b) => a >= b));
                ConvertToDouble = CastDelegate<ConvertTToDouble>((Func<byte, double>)((byte v) => Convert.ToDouble(v)));
                ConvertFromDouble = CastDelegate<ConvertDoubleToT>((Func<double, byte>)((double v) => Convert.ToByte(v)));
            }
            else
            {
                throw new NotSupportedException();
            }
        }
        
        #region "Delegate Casting"
        private static TDelegate CastDelegate<TDelegate>(Delegate source) where TDelegate : Delegate // use "class" instead of "Delegate" in older frameworks
        {
            var delegates = source.GetInvocationList();
            return (TDelegate)Delegate.CreateDelegate(typeof(TDelegate), delegates[0].Target, delegates[0].Method);
        }
        #endregion
    }

}