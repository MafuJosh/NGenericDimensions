using System;
using System.Diagnostics;
namespace NGenericDimensions.Math
{
    internal class GenericOperatorMath<T> where T : struct, IComparable, IFormattable, IComparable<T>, IEquatable<T>
    {
        internal delegate T TMath(T value1, T value2);
        internal delegate bool TMathBoolean(T value1, T value2);
        internal delegate byte ConvertTToByte(T value);
        internal delegate decimal ConvertTToDecimal(T value);
        internal delegate double ConvertTToDouble(T value);
        internal delegate Int16 ConvertTToInt16(T value);
        internal delegate Int32 ConvertTToInt32(T value);
        internal delegate Int64 ConvertTToInt64(T value);
        internal delegate SByte ConvertTToSByte(T value);
        internal delegate Single ConvertTToSingle(T value);
        internal delegate UInt16 ConvertTToUInt16(T value);
        internal delegate UInt32 ConvertTToUInt32(T value);
        internal delegate UInt64 ConvertTToUInt64(T value);
        internal delegate T ConvertDoubleToT(double value);
        internal delegate TypeCode GetTTypeCode();

        public static TMath Add;
        public static TMath Subtract;
        public static TMath Multiply;
        public static TMathBoolean LessThan;
        public static TMathBoolean GreaterThan;
        public static TMathBoolean LessThanOrEqualTo;
        public static TMathBoolean GreaterThanOrEqualTo;
        public static ConvertTToByte ConvertToByte;
        public static ConvertTToDecimal ConvertToDecimal;
        public static ConvertTToDouble ConvertToDouble;
        public static ConvertTToInt16 ConvertToInt16;
        public static ConvertTToInt32 ConvertToInt32;
        public static ConvertTToInt64 ConvertToInt64;
        public static ConvertTToSByte ConvertToSByte;
        public static ConvertTToSingle ConvertToSingle;
        public static ConvertTToUInt16 ConvertToUInt16;
        public static ConvertTToUInt32 ConvertToUInt32;
        public static ConvertTToUInt64 ConvertToUInt64;
        public static ConvertDoubleToT ConvertFromDouble;
        public static GetTTypeCode GetTypeCode;

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
                ConvertToByte = CastDelegate<ConvertTToByte>((Func<Int16, Byte>)((Int16 v) => Convert.ToByte(v)));
                ConvertToDecimal = CastDelegate<ConvertTToDecimal>((Func<Int16, Decimal>)((Int16 v) => Convert.ToDecimal(v)));
                ConvertToDouble = CastDelegate<ConvertTToDouble>((Func<Int16, Double>)((Int16 v) => Convert.ToDouble(v)));
                ConvertToInt16 = CastDelegate<ConvertTToInt16>((Func<Int16, Int16>)((Int16 v) => v));
                ConvertToInt32 = CastDelegate<ConvertTToInt32>((Func<Int16, Int32>)((Int16 v) => Convert.ToInt32(v)));
                ConvertToInt64 = CastDelegate<ConvertTToInt64>((Func<Int16, Int64>)((Int16 v) => Convert.ToInt64(v)));
                ConvertToSByte = CastDelegate<ConvertTToSByte>((Func<Int16, SByte>)((Int16 v) => Convert.ToSByte(v)));
                ConvertToSingle = CastDelegate<ConvertTToSingle>((Func<Int16, Single>)((Int16 v) => Convert.ToSingle(v)));
                ConvertToUInt16 = CastDelegate<ConvertTToUInt16>((Func<Int16, UInt16>)((Int16 v) => Convert.ToUInt16(v)));
                ConvertToUInt32 = CastDelegate<ConvertTToUInt32>((Func<Int16, UInt32>)((Int16 v) => Convert.ToUInt32(v)));
                ConvertToUInt64 = CastDelegate<ConvertTToUInt64>((Func<Int16, UInt64>)((Int16 v) => Convert.ToUInt64(v)));
                ConvertFromDouble = CastDelegate<ConvertDoubleToT>((Func<Double, Int16>)((Double v) => Convert.ToInt16(v)));
                GetTypeCode = CastDelegate<GetTTypeCode>((Func<TypeCode>)(() => TypeCode.Int16));
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
                ConvertToByte = CastDelegate<ConvertTToByte>((Func<Int32, Byte>)((Int32 v) => Convert.ToByte(v)));
                ConvertToDecimal = CastDelegate<ConvertTToDecimal>((Func<Int32, Decimal>)((Int32 v) => Convert.ToDecimal(v)));
                ConvertToDouble = CastDelegate<ConvertTToDouble>((Func<Int32, Double>)((Int32 v) => Convert.ToDouble(v)));
                ConvertToInt16 = CastDelegate<ConvertTToInt16>((Func<Int32, Int16>)((Int32 v) => Convert.ToInt16(v)));
                ConvertToInt32 = CastDelegate<ConvertTToInt32>((Func<Int32, Int32>)((Int32 v) => v));
                ConvertToInt64 = CastDelegate<ConvertTToInt64>((Func<Int32, Int64>)((Int32 v) => Convert.ToInt64(v)));
                ConvertToSByte = CastDelegate<ConvertTToSByte>((Func<Int32, SByte>)((Int32 v) => Convert.ToSByte(v)));
                ConvertToSingle = CastDelegate<ConvertTToSingle>((Func<Int32, Single>)((Int32 v) => Convert.ToSingle(v)));
                ConvertToUInt16 = CastDelegate<ConvertTToUInt16>((Func<Int32, UInt16>)((Int32 v) => Convert.ToUInt16(v)));
                ConvertToUInt32 = CastDelegate<ConvertTToUInt32>((Func<Int32, UInt32>)((Int32 v) => Convert.ToUInt32(v)));
                ConvertToUInt64 = CastDelegate<ConvertTToUInt64>((Func<Int32, UInt64>)((Int32 v) => Convert.ToUInt64(v)));
                ConvertFromDouble = CastDelegate<ConvertDoubleToT>((Func<double, Int32>)((double v) => Convert.ToInt32(v)));
                GetTypeCode = CastDelegate<GetTTypeCode>((Func<TypeCode>)(() => TypeCode.Int32));
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
                ConvertToByte = CastDelegate<ConvertTToByte>((Func<Int64, Byte>)((Int64 v) => Convert.ToByte(v)));
                ConvertToDecimal = CastDelegate<ConvertTToDecimal>((Func<Int64, Decimal>)((Int64 v) => Convert.ToDecimal(v)));
                ConvertToDouble = CastDelegate<ConvertTToDouble>((Func<Int64, Double>)((Int64 v) => Convert.ToDouble(v)));
                ConvertToInt16 = CastDelegate<ConvertTToInt16>((Func<Int64, Int16>)((Int64 v) => Convert.ToInt16(v)));
                ConvertToInt32 = CastDelegate<ConvertTToInt32>((Func<Int64, Int32>)((Int64 v) => Convert.ToInt32(v)));
                ConvertToInt64 = CastDelegate<ConvertTToInt64>((Func<Int64, Int64>)((Int64 v) => v));
                ConvertToSByte = CastDelegate<ConvertTToSByte>((Func<Int64, SByte>)((Int64 v) => Convert.ToSByte(v)));
                ConvertToSingle = CastDelegate<ConvertTToSingle>((Func<Int64, Single>)((Int64 v) => Convert.ToSingle(v)));
                ConvertToUInt16 = CastDelegate<ConvertTToUInt16>((Func<Int64, UInt16>)((Int64 v) => Convert.ToUInt16(v)));
                ConvertToUInt32 = CastDelegate<ConvertTToUInt32>((Func<Int64, UInt32>)((Int64 v) => Convert.ToUInt32(v)));
                ConvertToUInt64 = CastDelegate<ConvertTToUInt64>((Func<Int64, UInt64>)((Int64 v) => Convert.ToUInt64(v)));
                ConvertFromDouble = CastDelegate<ConvertDoubleToT>((Func<double, Int64>)((double v) => Convert.ToInt64(v)));
                GetTypeCode = CastDelegate<GetTTypeCode>((Func<TypeCode>)(() => TypeCode.Int64));
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
                ConvertToByte = CastDelegate<ConvertTToByte>((Func<UInt16, Byte>)((UInt16 v) => Convert.ToByte(v)));
                ConvertToDecimal = CastDelegate<ConvertTToDecimal>((Func<UInt16, Decimal>)((UInt16 v) => Convert.ToDecimal(v)));
                ConvertToDouble = CastDelegate<ConvertTToDouble>((Func<UInt16, Double>)((UInt16 v) => Convert.ToDouble(v)));
                ConvertToInt16 = CastDelegate<ConvertTToInt16>((Func<UInt16, Int16>)((UInt16 v) => Convert.ToInt16(v)));
                ConvertToInt32 = CastDelegate<ConvertTToInt32>((Func<UInt16, Int32>)((UInt16 v) => Convert.ToInt32(v)));
                ConvertToInt64 = CastDelegate<ConvertTToInt64>((Func<UInt16, Int64>)((UInt16 v) => Convert.ToInt64(v)));
                ConvertToSByte = CastDelegate<ConvertTToSByte>((Func<UInt16, SByte>)((UInt16 v) => Convert.ToSByte(v)));
                ConvertToSingle = CastDelegate<ConvertTToSingle>((Func<UInt16, Single>)((UInt16 v) => Convert.ToSingle(v)));
                ConvertToUInt16 = CastDelegate<ConvertTToUInt16>((Func<UInt16, UInt16>)((UInt16 v) => v));
                ConvertToUInt32 = CastDelegate<ConvertTToUInt32>((Func<UInt16, UInt32>)((UInt16 v) => Convert.ToUInt32(v)));
                ConvertToUInt64 = CastDelegate<ConvertTToUInt64>((Func<UInt16, UInt64>)((UInt16 v) => Convert.ToUInt64(v)));
                ConvertFromDouble = CastDelegate<ConvertDoubleToT>((Func<double, UInt16>)((double v) => Convert.ToUInt16(v)));
                GetTypeCode = CastDelegate<GetTTypeCode>((Func<TypeCode>)(() => TypeCode.UInt16));
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
                ConvertToByte = CastDelegate<ConvertTToByte>((Func<UInt32, Byte>)((UInt32 v) => Convert.ToByte(v)));
                ConvertToDecimal = CastDelegate<ConvertTToDecimal>((Func<UInt32, Decimal>)((UInt32 v) => Convert.ToDecimal(v)));
                ConvertToDouble = CastDelegate<ConvertTToDouble>((Func<UInt32, Double>)((UInt32 v) => Convert.ToDouble(v)));
                ConvertToInt16 = CastDelegate<ConvertTToInt16>((Func<UInt32, Int16>)((UInt32 v) => Convert.ToInt16(v)));
                ConvertToInt32 = CastDelegate<ConvertTToInt32>((Func<UInt32, Int32>)((UInt32 v) => Convert.ToInt32(v)));
                ConvertToInt64 = CastDelegate<ConvertTToInt64>((Func<UInt32, Int64>)((UInt32 v) => Convert.ToInt64(v)));
                ConvertToSByte = CastDelegate<ConvertTToSByte>((Func<UInt32, SByte>)((UInt32 v) => Convert.ToSByte(v)));
                ConvertToSingle = CastDelegate<ConvertTToSingle>((Func<UInt32, Single>)((UInt32 v) => Convert.ToSingle(v)));
                ConvertToUInt16 = CastDelegate<ConvertTToUInt16>((Func<UInt32, UInt16>)((UInt32 v) => Convert.ToUInt16(v)));
                ConvertToUInt32 = CastDelegate<ConvertTToUInt32>((Func<UInt32, UInt32>)((UInt32 v) => v));
                ConvertToUInt64 = CastDelegate<ConvertTToUInt64>((Func<UInt32, UInt64>)((UInt32 v) => Convert.ToUInt64(v)));
                ConvertFromDouble = CastDelegate<ConvertDoubleToT>((Func<double, UInt32>)((double v) => Convert.ToUInt32(v)));
                GetTypeCode = CastDelegate<GetTTypeCode>((Func<TypeCode>)(() => TypeCode.UInt32));
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
                ConvertToByte = CastDelegate<ConvertTToByte>((Func<UInt64, Byte>)((UInt64 v) => Convert.ToByte(v)));
                ConvertToDecimal = CastDelegate<ConvertTToDecimal>((Func<UInt64, Decimal>)((UInt64 v) => Convert.ToDecimal(v)));
                ConvertToDouble = CastDelegate<ConvertTToDouble>((Func<UInt64, Double>)((UInt64 v) => Convert.ToDouble(v)));
                ConvertToInt16 = CastDelegate<ConvertTToInt16>((Func<UInt64, Int16>)((UInt64 v) => Convert.ToInt16(v)));
                ConvertToInt32 = CastDelegate<ConvertTToInt32>((Func<UInt64, Int32>)((UInt64 v) => Convert.ToInt32(v)));
                ConvertToInt64 = CastDelegate<ConvertTToInt64>((Func<UInt64, Int64>)((UInt64 v) => Convert.ToInt64(v)));
                ConvertToSByte = CastDelegate<ConvertTToSByte>((Func<UInt64, SByte>)((UInt64 v) => Convert.ToSByte(v)));
                ConvertToSingle = CastDelegate<ConvertTToSingle>((Func<UInt64, Single>)((UInt64 v) => Convert.ToSingle(v)));
                ConvertToUInt16 = CastDelegate<ConvertTToUInt16>((Func<UInt64, UInt16>)((UInt64 v) => Convert.ToUInt16(v)));
                ConvertToUInt32 = CastDelegate<ConvertTToUInt32>((Func<UInt64, UInt32>)((UInt64 v) => Convert.ToUInt32(v)));
                ConvertToUInt64 = CastDelegate<ConvertTToUInt64>((Func<UInt64, UInt64>)((UInt64 v) => v));
                ConvertFromDouble = CastDelegate<ConvertDoubleToT>((Func<double, UInt64>)((double v) => Convert.ToUInt64(v)));
                GetTypeCode = CastDelegate<GetTTypeCode>((Func<TypeCode>)(() => TypeCode.UInt64));
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
                ConvertToByte = CastDelegate<ConvertTToByte>((Func<float, Byte>)((float v) => Convert.ToByte(v)));
                ConvertToDecimal = CastDelegate<ConvertTToDecimal>((Func<float, Decimal>)((float v) => Convert.ToDecimal(v)));
                ConvertToDouble = CastDelegate<ConvertTToDouble>((Func<float, Double>)((float v) => Convert.ToDouble(v)));
                ConvertToInt16 = CastDelegate<ConvertTToInt16>((Func<float, Int16>)((float v) => Convert.ToInt16(v)));
                ConvertToInt32 = CastDelegate<ConvertTToInt32>((Func<float, Int32>)((float v) => Convert.ToInt32(v)));
                ConvertToInt64 = CastDelegate<ConvertTToInt64>((Func<float, Int64>)((float v) => Convert.ToInt64(v)));
                ConvertToSByte = CastDelegate<ConvertTToSByte>((Func<float, SByte>)((float v) => Convert.ToSByte(v)));
                ConvertToSingle = CastDelegate<ConvertTToSingle>((Func<float, Single>)((float v) => v));
                ConvertToUInt16 = CastDelegate<ConvertTToUInt16>((Func<float, UInt16>)((float v) => Convert.ToUInt16(v)));
                ConvertToUInt32 = CastDelegate<ConvertTToUInt32>((Func<float, UInt32>)((float v) => Convert.ToUInt32(v)));
                ConvertToUInt64 = CastDelegate<ConvertTToUInt64>((Func<float, UInt64>)((float v) => Convert.ToUInt64(v)));
                ConvertFromDouble = CastDelegate<ConvertDoubleToT>((Func<double, float>)((double v) => Convert.ToSingle(v)));
                GetTypeCode = CastDelegate<GetTTypeCode>((Func<TypeCode>)(() => TypeCode.Single));
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
                ConvertToByte = CastDelegate<ConvertTToByte>((Func<double, Byte>)((double v) => Convert.ToByte(v)));
                ConvertToDecimal = CastDelegate<ConvertTToDecimal>((Func<double, Decimal>)((double v) => Convert.ToDecimal(v)));
                ConvertToDouble = CastDelegate<ConvertTToDouble>((Func<double, Double>)((double v) => v));
                ConvertToInt16 = CastDelegate<ConvertTToInt16>((Func<double, Int16>)((double v) => Convert.ToInt16(v)));
                ConvertToInt32 = CastDelegate<ConvertTToInt32>((Func<double, Int32>)((double v) => Convert.ToInt32(v)));
                ConvertToInt64 = CastDelegate<ConvertTToInt64>((Func<double, Int64>)((double v) => Convert.ToInt64(v)));
                ConvertToSByte = CastDelegate<ConvertTToSByte>((Func<double, SByte>)((double v) => Convert.ToSByte(v)));
                ConvertToSingle = CastDelegate<ConvertTToSingle>((Func<double, Single>)((double v) => Convert.ToSingle(v)));
                ConvertToUInt16 = CastDelegate<ConvertTToUInt16>((Func<double, UInt16>)((double v) => Convert.ToUInt16(v)));
                ConvertToUInt32 = CastDelegate<ConvertTToUInt32>((Func<double, UInt32>)((double v) => Convert.ToUInt32(v)));
                ConvertToUInt64 = CastDelegate<ConvertTToUInt64>((Func<double, UInt64>)((double v) => Convert.ToUInt64(v)));
                ConvertFromDouble = CastDelegate<ConvertDoubleToT>((Func<double, double>)((double v) => v));
                GetTypeCode = CastDelegate<GetTTypeCode>((Func<TypeCode>)(() => TypeCode.Double));
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
                ConvertToByte = CastDelegate<ConvertTToByte>((Func<decimal, Byte>)((decimal v) => Convert.ToByte(v)));
                ConvertToDecimal = CastDelegate<ConvertTToDecimal>((Func<decimal, Decimal>)((decimal v) => v));
                ConvertToDouble = CastDelegate<ConvertTToDouble>((Func<decimal, Double>)((decimal v) => Convert.ToDouble(v)));
                ConvertToInt16 = CastDelegate<ConvertTToInt16>((Func<decimal, Int16>)((decimal v) => Convert.ToInt16(v)));
                ConvertToInt32 = CastDelegate<ConvertTToInt32>((Func<decimal, Int32>)((decimal v) => Convert.ToInt32(v)));
                ConvertToInt64 = CastDelegate<ConvertTToInt64>((Func<decimal, Int64>)((decimal v) => Convert.ToInt64(v)));
                ConvertToSByte = CastDelegate<ConvertTToSByte>((Func<decimal, SByte>)((decimal v) => Convert.ToSByte(v)));
                ConvertToSingle = CastDelegate<ConvertTToSingle>((Func<decimal, Single>)((decimal v) => Convert.ToSingle(v)));
                ConvertToUInt16 = CastDelegate<ConvertTToUInt16>((Func<decimal, UInt16>)((decimal v) => Convert.ToUInt16(v)));
                ConvertToUInt32 = CastDelegate<ConvertTToUInt32>((Func<decimal, UInt32>)((decimal v) => Convert.ToUInt32(v)));
                ConvertToUInt64 = CastDelegate<ConvertTToUInt64>((Func<decimal, UInt64>)((decimal v) => Convert.ToUInt64(v)));
                ConvertFromDouble = CastDelegate<ConvertDoubleToT>((Func<double, decimal>)((double v) => Convert.ToDecimal(v)));
                GetTypeCode = CastDelegate<GetTTypeCode>((Func<TypeCode>)(() => TypeCode.Decimal));
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
                ConvertToByte = CastDelegate<ConvertTToByte>((Func<sbyte, Byte>)((sbyte v) => Convert.ToByte(v)));
                ConvertToDecimal = CastDelegate<ConvertTToDecimal>((Func<sbyte, Decimal>)((sbyte v) => Convert.ToDecimal(v)));
                ConvertToDouble = CastDelegate<ConvertTToDouble>((Func<sbyte, Double>)((sbyte v) => Convert.ToDouble(v)));
                ConvertToInt16 = CastDelegate<ConvertTToInt16>((Func<sbyte, Int16>)((sbyte v) => Convert.ToInt16(v)));
                ConvertToInt32 = CastDelegate<ConvertTToInt32>((Func<sbyte, Int32>)((sbyte v) => Convert.ToInt32(v)));
                ConvertToInt64 = CastDelegate<ConvertTToInt64>((Func<sbyte, Int64>)((sbyte v) => Convert.ToInt64(v)));
                ConvertToSByte = CastDelegate<ConvertTToSByte>((Func<sbyte, SByte>)((sbyte v) => v));
                ConvertToSingle = CastDelegate<ConvertTToSingle>((Func<sbyte, Single>)((sbyte v) => Convert.ToSingle(v)));
                ConvertToUInt16 = CastDelegate<ConvertTToUInt16>((Func<sbyte, UInt16>)((sbyte v) => Convert.ToUInt16(v)));
                ConvertToUInt32 = CastDelegate<ConvertTToUInt32>((Func<sbyte, UInt32>)((sbyte v) => Convert.ToUInt32(v)));
                ConvertToUInt64 = CastDelegate<ConvertTToUInt64>((Func<sbyte, UInt64>)((sbyte v) => Convert.ToUInt64(v)));
                ConvertFromDouble = CastDelegate<ConvertDoubleToT>((Func<double, sbyte>)((double v) => Convert.ToSByte(v)));
                GetTypeCode = CastDelegate<GetTTypeCode>((Func<TypeCode>)(() => TypeCode.SByte));
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
                ConvertToByte = CastDelegate<ConvertTToByte>((Func<byte, Byte>)((byte v) => v));
                ConvertToDecimal = CastDelegate<ConvertTToDecimal>((Func<byte, Decimal>)((byte v) => Convert.ToDecimal(v)));
                ConvertToDouble = CastDelegate<ConvertTToDouble>((Func<byte, Double>)((byte v) => Convert.ToDouble(v)));
                ConvertToInt16 = CastDelegate<ConvertTToInt16>((Func<byte, Int16>)((byte v) => Convert.ToInt16(v)));
                ConvertToInt32 = CastDelegate<ConvertTToInt32>((Func<byte, Int32>)((byte v) => Convert.ToInt32(v)));
                ConvertToInt64 = CastDelegate<ConvertTToInt64>((Func<byte, Int64>)((byte v) => Convert.ToInt64(v)));
                ConvertToSByte = CastDelegate<ConvertTToSByte>((Func<byte, SByte>)((byte v) => Convert.ToSByte(v)));
                ConvertToSingle = CastDelegate<ConvertTToSingle>((Func<byte, Single>)((byte v) => Convert.ToSingle(v)));
                ConvertToUInt16 = CastDelegate<ConvertTToUInt16>((Func<byte, UInt16>)((byte v) => Convert.ToUInt16(v)));
                ConvertToUInt32 = CastDelegate<ConvertTToUInt32>((Func<byte, UInt32>)((byte v) => Convert.ToUInt32(v)));
                ConvertToUInt64 = CastDelegate<ConvertTToUInt64>((Func<byte, UInt64>)((byte v) => Convert.ToUInt64(v)));
                ConvertFromDouble = CastDelegate<ConvertDoubleToT>((Func<double, byte>)((double v) => Convert.ToByte(v)));
                GetTypeCode = CastDelegate<GetTTypeCode>((Func<TypeCode>)(() => TypeCode.Byte));
            }
            else
            {
#pragma warning disable CA1065 // Do not raise exceptions in unexpected locations
                throw new NotSupportedException();
#pragma warning restore CA1065 // Do not raise exceptions in unexpected locations
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