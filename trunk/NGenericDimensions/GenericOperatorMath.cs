using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
namespace NGenericDimensions.Math
{

    internal class GenericOperatorMath<T> where T : struct
    {
        internal delegate T TMath(T value1, T value2);
        internal delegate bool TMathBoolean(T value1, T value2);

        public static TMath Add = null;
        public static TMath Subtract = null;
        public static TMath Multiply = null;
        public static TMath Divide = null;
        public static TMath DivideInteger = null;
        public static TMathBoolean Same = null;
        public static TMathBoolean NotSame = null;
        public static TMathBoolean LessThan = null;
        public static TMathBoolean GreaterThan = null;
        public static TMathBoolean LessThanOrEqualTo = null;

        public static TMathBoolean GreaterThanOrEqualTo = null;
        [System.Diagnostics.DebuggerStepThrough()]
        static GenericOperatorMath()
        {
            if (object.ReferenceEquals(typeof(T), typeof(Int16)))
            {
                Add = AddInt16;
                Subtract = SubtractInt16;
                Multiply = MultiplyInt16;
                Divide = DivideInt16;
                Same = SameInt16;
                NotSame = NotSameInt16;
                LessThan = LessThanInt16;
                GreaterThan = GreaterThanInt16;
                LessThanOrEqualTo = LessThanOrEqualToInt16;
                GreaterThanOrEqualTo = GreaterThanOrEqualToInt16;
            }
            else if (object.ReferenceEquals(typeof(T), typeof(Int32)))
            {
                Add = AddInt32;
                Subtract = SubtractInt32;
                Multiply = MultiplyInt32;
                Divide = DivideInt32;
                Same = SameInt32;
                NotSame = NotSameInt32;
                LessThan = LessThanInt32;
                GreaterThan = GreaterThanInt32;
                LessThanOrEqualTo = LessThanOrEqualToInt32;
                GreaterThanOrEqualTo = GreaterThanOrEqualToInt32;
            }
            else if (object.ReferenceEquals(typeof(T), typeof(Int64)))
            {
                Add = AddInt64;
                Subtract = SubtractInt64;
                Multiply = MultiplyInt64;
                Divide = DivideInt64;
                Same = SameInt64;
                NotSame = NotSameInt64;
                LessThan = LessThanInt64;
                GreaterThan = GreaterThanInt64;
                LessThanOrEqualTo = LessThanOrEqualToInt64;
                GreaterThanOrEqualTo = GreaterThanOrEqualToInt64;
            }
            else if (object.ReferenceEquals(typeof(T), typeof(UInt16)))
            {
                Add = AddUInt16;
                Subtract = SubtractUInt16;
                Multiply = MultiplyUInt16;
                Divide = DivideUInt16;
                Same = SameUInt16;
                NotSame = NotSameUInt16;
                LessThan = LessThanUInt16;
                GreaterThan = GreaterThanUInt16;
                LessThanOrEqualTo = LessThanOrEqualToUInt16;
                GreaterThanOrEqualTo = GreaterThanOrEqualToUInt16;
            }
            else if (object.ReferenceEquals(typeof(T), typeof(UInt32)))
            {
                Add = AddUInt32;
                Subtract = SubtractUInt32;
                Multiply = MultiplyUInt32;
                Divide = DivideUInt32;
                Same = SameUInt32;
                NotSame = NotSameUInt32;
                LessThan = LessThanUInt32;
                GreaterThan = GreaterThanUInt32;
                LessThanOrEqualTo = LessThanOrEqualToUInt32;
                GreaterThanOrEqualTo = GreaterThanOrEqualToUInt32;
            }
            else if (object.ReferenceEquals(typeof(T), typeof(UInt64)))
            {
                Add = AddUInt64;
                Subtract = SubtractUInt64;
                Multiply = MultiplyUInt64;
                Divide = DivideUInt64;
                Same = SameUInt64;
                NotSame = NotSameUInt64;
                LessThan = LessThanUInt64;
                GreaterThan = GreaterThanUInt64;
                LessThanOrEqualTo = LessThanOrEqualToUInt64;
                GreaterThanOrEqualTo = GreaterThanOrEqualToUInt64;
            }
            else if (object.ReferenceEquals(typeof(T), typeof(float)))
            {
                Add = AddSingle;
                Subtract = SubtractSingle;
                Multiply = MultiplySingle;
                Divide = DivideSingle;
                Same = SameSingle;
                NotSame = NotSameSingle;
                LessThan = LessThanSingle;
                GreaterThan = GreaterThanSingle;
                LessThanOrEqualTo = LessThanOrEqualToSingle;
                GreaterThanOrEqualTo = GreaterThanOrEqualToSingle;
            }
            else if (object.ReferenceEquals(typeof(T), typeof(double)))
            {
                Add = AddDouble;
                Subtract = SubtractDouble;
                Multiply = MultiplyDouble;
                Divide = DivideDouble;
                Same = SameDouble;
                NotSame = NotSameDouble;
                LessThan = LessThanDouble;
                GreaterThan = GreaterThanDouble;
                LessThanOrEqualTo = LessThanOrEqualToDouble;
                GreaterThanOrEqualTo = GreaterThanOrEqualToDouble;
            }
            else if (object.ReferenceEquals(typeof(T), typeof(decimal)))
            {
                Add = AddDecimal;
                Subtract = SubtractDecimal;
                Multiply = MultiplyDecimal;
                Divide = DivideDecimal;
                Same = SameDecimal;
                NotSame = NotSameDecimal;
                LessThan = LessThanDecimal;
                GreaterThan = GreaterThanDecimal;
                LessThanOrEqualTo = LessThanOrEqualToDecimal;
                GreaterThanOrEqualTo = GreaterThanOrEqualToDecimal;
            }
            else if (object.ReferenceEquals(typeof(T), typeof(sbyte)))
            {
                Add = AddSByte;
                Subtract = SubtractSByte;
                Multiply = MultiplySByte;
                Divide = DivideSByte;
                Same = SameSByte;
                NotSame = NotSameSByte;
                LessThan = LessThanSByte;
                GreaterThan = GreaterThanSByte;
                LessThanOrEqualTo = LessThanOrEqualToSByte;
                GreaterThanOrEqualTo = GreaterThanOrEqualToSByte;
            }
            else if (object.ReferenceEquals(typeof(T), typeof(byte)))
            {
                Add = AddByte;
                Subtract = SubtractByte;
                Multiply = MultiplyByte;
                Divide = DivideByte;
                Same = SameByte;
                NotSame = NotSameByte;
                LessThan = LessThanByte;
                GreaterThan = GreaterThanByte;
                LessThanOrEqualTo = LessThanOrEqualToByte;
                GreaterThanOrEqualTo = GreaterThanOrEqualToByte;
            }
        }

        #region "Add"
        [System.Diagnostics.DebuggerStepThrough()]
        private static T AddInt16(T value1, T value2)
        {
            return (T)(object)((Int16)(object)value1 + (Int16)(object)value2);
        }

        [System.Diagnostics.DebuggerStepThrough()]
        private static T AddInt32(T value1, T value2)
        {
            return (T)(object)((Int32)(object)value1 + (Int32)(object)value2);
        }

        [System.Diagnostics.DebuggerStepThrough()]
        private static T AddInt64(T value1, T value2)
        {
            return (T)(object)((Int64)(object)value1 + (Int64)(object)value2);
        }

        [System.Diagnostics.DebuggerStepThrough()]
        private static T AddSingle(T value1, T value2)
        {
            return (T)(object)((float)(object)value1 + (float)(object)value2);
        }

        [System.Diagnostics.DebuggerStepThrough()]
        private static T AddDouble(T value1, T value2)
        {
            return (T)(object)((double)(object)value1 + (double)(object)value2);
        }

        [System.Diagnostics.DebuggerStepThrough()]
        private static T AddDecimal(T value1, T value2)
        {
            return (T)(object)((decimal)(object)value1 + (decimal)(object)value2);
        }

        [System.Diagnostics.DebuggerStepThrough()]
        private static T AddUInt16(T value1, T value2)
        {
            return (T)(object)((UInt16)(object)value1 + (UInt16)(object)value2);
        }

        [System.Diagnostics.DebuggerStepThrough()]
        private static T AddUInt32(T value1, T value2)
        {
            return (T)(object)((Int32)(object)value1 + (Int32)(object)value2);
        }

        [System.Diagnostics.DebuggerStepThrough()]
        private static T AddUInt64(T value1, T value2)
        {
            return (T)(object)((UInt64)(object)value1 + (UInt64)(object)value2);
        }

        [System.Diagnostics.DebuggerStepThrough()]
        private static T AddSByte(T value1, T value2)
        {
            return (T)(object)((sbyte)(object)value1 + (sbyte)(object)value2);
        }

        [System.Diagnostics.DebuggerStepThrough()]
        private static T AddByte(T value1, T value2)
        {
            return (T)(object)((byte)(object)value1 + (byte)(object)value2);
        }
        #endregion

        #region "Subtract"
        [System.Diagnostics.DebuggerStepThrough()]
        private static T SubtractInt16(T value1, T value2)
        {
            return (T)(object)((Int16)(object)value1 - (Int16)(object)value2);
        }

        [System.Diagnostics.DebuggerStepThrough()]
        private static T SubtractInt32(T value1, T value2)
        {
            return (T)(object)((Int32)(object)value1 - (Int32)(object)value2);
        }

        [System.Diagnostics.DebuggerStepThrough()]
        private static T SubtractInt64(T value1, T value2)
        {
            return (T)(object)((Int64)(object)value1 - (Int64)(object)value2);
        }

        [System.Diagnostics.DebuggerStepThrough()]
        private static T SubtractSingle(T value1, T value2)
        {
            return (T)(object)((float)(object)value1 - (float)(object)value2);
        }

        [System.Diagnostics.DebuggerStepThrough()]
        private static T SubtractDouble(T value1, T value2)
        {
            return (T)(object)((double)(object)value1 - (double)(object)value2);
        }

        [System.Diagnostics.DebuggerStepThrough()]
        private static T SubtractDecimal(T value1, T value2)
        {
            return (T)(object)((decimal)(object)value1 - (decimal)(object)value2);
        }

        [System.Diagnostics.DebuggerStepThrough()]
        private static T SubtractUInt16(T value1, T value2)
        {
            return (T)(object)((UInt16)(object)value1 - (UInt16)(object)value2);
        }

        [System.Diagnostics.DebuggerStepThrough()]
        private static T SubtractUInt32(T value1, T value2)
        {
            return (T)(object)((Int32)(object)value1 - (Int32)(object)value2);
        }

        [System.Diagnostics.DebuggerStepThrough()]
        private static T SubtractUInt64(T value1, T value2)
        {
            return (T)(object)((UInt64)(object)value1 - (UInt64)(object)value2);
        }

        [System.Diagnostics.DebuggerStepThrough()]
        private static T SubtractSByte(T value1, T value2)
        {
            return (T)(object)((sbyte)(object)value1 - (sbyte)(object)value2);
        }

        [System.Diagnostics.DebuggerStepThrough()]
        private static T SubtractByte(T value1, T value2)
        {
            return (T)(object)((byte)(object)value1 - (byte)(object)value2);
        }
        #endregion

        #region "Multiply"
        [System.Diagnostics.DebuggerStepThrough()]
        private static T MultiplyInt16(T value1, T value2)
        {
            return (T)(object)((Int16)(object)value1 * (Int16)(object)value2);
        }

        [System.Diagnostics.DebuggerStepThrough()]
        private static T MultiplyInt32(T value1, T value2)
        {
            return (T)(object)((Int32)(object)value1 * (Int32)(object)value2);
        }

        [System.Diagnostics.DebuggerStepThrough()]
        private static T MultiplyInt64(T value1, T value2)
        {
            return (T)(object)((Int64)(object)value1 * (Int64)(object)value2);
        }

        [System.Diagnostics.DebuggerStepThrough()]
        private static T MultiplySingle(T value1, T value2)
        {
            return (T)(object)((float)(object)value1 * (float)(object)value2);
        }

        [System.Diagnostics.DebuggerStepThrough()]
        private static T MultiplyDouble(T value1, T value2)
        {
            return (T)(object)((double)(object)value1 * (double)(object)value2);
        }

        [System.Diagnostics.DebuggerStepThrough()]
        private static T MultiplyDecimal(T value1, T value2)
        {
            return (T)(object)((decimal)(object)value1 * (decimal)(object)value2);
        }

        [System.Diagnostics.DebuggerStepThrough()]
        private static T MultiplyUInt16(T value1, T value2)
        {
            return (T)(object)((UInt16)(object)value1 * (UInt16)(object)value2);
        }

        [System.Diagnostics.DebuggerStepThrough()]
        private static T MultiplyUInt32(T value1, T value2)
        {
            return (T)(object)((Int32)(object)value1 * (Int32)(object)value2);
        }

        [System.Diagnostics.DebuggerStepThrough()]
        private static T MultiplyUInt64(T value1, T value2)
        {
            return (T)(object)((UInt64)(object)value1 * (UInt64)(object)value2);
        }

        [System.Diagnostics.DebuggerStepThrough()]
        private static T MultiplySByte(T value1, T value2)
        {
            return (T)(object)((sbyte)(object)value1 * (sbyte)(object)value2);
        }

        [System.Diagnostics.DebuggerStepThrough()]
        private static T MultiplyByte(T value1, T value2)
        {
            return (T)(object)((byte)(object)value1 * (byte)(object)value2);
        }
        #endregion

        #region "Divide"
        [System.Diagnostics.DebuggerStepThrough()]
        private static T DivideInt16(T value1, T value2)
        {
            return (T)(object)((Int16)(object)value1 / (Int16)(object)value2);
        }

        [System.Diagnostics.DebuggerStepThrough()]
        private static T DivideInt32(T value1, T value2)
        {
            return (T)(object)((Int32)(object)value1 / (Int32)(object)value2);
        }

        [System.Diagnostics.DebuggerStepThrough()]
        private static T DivideInt64(T value1, T value2)
        {
            return (T)(object)((Int64)(object)value1 / (Int64)(object)value2);
        }

        [System.Diagnostics.DebuggerStepThrough()]
        private static T DivideSingle(T value1, T value2)
        {
            return (T)(object)((float)(object)value1 / (float)(object)value2);
        }

        [System.Diagnostics.DebuggerStepThrough()]
        private static T DivideDouble(T value1, T value2)
        {
            return (T)(object)((double)(object)value1 / (double)(object)value2);
        }

        [System.Diagnostics.DebuggerStepThrough()]
        private static T DivideDecimal(T value1, T value2)
        {
            return (T)(object)((decimal)(object)value1 / (decimal)(object)value2);
        }

        [System.Diagnostics.DebuggerStepThrough()]
        private static T DivideUInt16(T value1, T value2)
        {
            return (T)(object)((UInt16)(object)value1 / (UInt16)(object)value2);
        }

        [System.Diagnostics.DebuggerStepThrough()]
        private static T DivideUInt32(T value1, T value2)
        {
            return (T)(object)((Int32)(object)value1 / (Int32)(object)value2);
        }

        [System.Diagnostics.DebuggerStepThrough()]
        private static T DivideUInt64(T value1, T value2)
        {
            return (T)(object)((UInt64)(object)value1 / (UInt64)(object)value2);
        }

        [System.Diagnostics.DebuggerStepThrough()]
        private static T DivideSByte(T value1, T value2)
        {
            return (T)(object)((sbyte)(object)value1 / (sbyte)(object)value2);
        }

        [System.Diagnostics.DebuggerStepThrough()]
        private static T DivideByte(T value1, T value2)
        {
            return (T)(object)((byte)(object)value1 / (byte)(object)value2);
        }
        #endregion

        #region "Same"
        [System.Diagnostics.DebuggerStepThrough()]
        private static bool SameInt16(T value1, T value2)
        {
            return (Int16)(object)value1 == (Int16)(object)value2;
        }

        [System.Diagnostics.DebuggerStepThrough()]
        private static bool SameInt32(T value1, T value2)
        {
            return (Int32)(object)value1 == (Int32)(object)value2;
        }

        [System.Diagnostics.DebuggerStepThrough()]
        private static bool SameInt64(T value1, T value2)
        {
            return (Int64)(object)value1 == (Int64)(object)value2;
        }

        [System.Diagnostics.DebuggerStepThrough()]
        private static bool SameSingle(T value1, T value2)
        {
            return (float)(object)value1 == (float)(object)value2;
        }

        [System.Diagnostics.DebuggerStepThrough()]
        private static bool SameDouble(T value1, T value2)
        {
            return (double)(object)value1 == (double)(object)value2;
        }

        [System.Diagnostics.DebuggerStepThrough()]
        private static bool SameDecimal(T value1, T value2)
        {
            return (decimal)(object)value1 == (decimal)(object)value2;
        }

        [System.Diagnostics.DebuggerStepThrough()]
        private static bool SameUInt16(T value1, T value2)
        {
            return (UInt16)(object)value1 == (UInt16)(object)value2;
        }

        [System.Diagnostics.DebuggerStepThrough()]
        private static bool SameUInt32(T value1, T value2)
        {
            return (Int32)(object)value1 == (Int32)(object)value2;
        }

        [System.Diagnostics.DebuggerStepThrough()]
        private static bool SameUInt64(T value1, T value2)
        {
            return (UInt64)(object)value1 == (UInt64)(object)value2;
        }

        [System.Diagnostics.DebuggerStepThrough()]
        private static bool SameSByte(T value1, T value2)
        {
            return (sbyte)(object)value1 == (sbyte)(object)value2;
        }

        [System.Diagnostics.DebuggerStepThrough()]
        private static bool SameByte(T value1, T value2)
        {
            return (byte)(object)value1 == (byte)(object)value2;
        }
        #endregion

        #region "NotSame"
        [System.Diagnostics.DebuggerStepThrough()]
        private static bool NotSameInt16(T value1, T value2)
        {
            return (Int16)(object)value1 != (Int16)(object)value2;
        }

        [System.Diagnostics.DebuggerStepThrough()]
        private static bool NotSameInt32(T value1, T value2)
        {
            return (Int32)(object)value1 != (Int32)(object)value2;
        }

        [System.Diagnostics.DebuggerStepThrough()]
        private static bool NotSameInt64(T value1, T value2)
        {
            return (Int64)(object)value1 != (Int64)(object)value2;
        }

        [System.Diagnostics.DebuggerStepThrough()]
        private static bool NotSameSingle(T value1, T value2)
        {
            return (float)(object)value1 != (float)(object)value2;
        }

        [System.Diagnostics.DebuggerStepThrough()]
        private static bool NotSameDouble(T value1, T value2)
        {
            return (double)(object)value1 != (double)(object)value2;
        }

        [System.Diagnostics.DebuggerStepThrough()]
        private static bool NotSameDecimal(T value1, T value2)
        {
            return (decimal)(object)value1 != (decimal)(object)value2;
        }

        [System.Diagnostics.DebuggerStepThrough()]
        private static bool NotSameUInt16(T value1, T value2)
        {
            return (UInt16)(object)value1 != (UInt16)(object)value2;
        }

        [System.Diagnostics.DebuggerStepThrough()]
        private static bool NotSameUInt32(T value1, T value2)
        {
            return (Int32)(object)value1 != (Int32)(object)value2;
        }

        [System.Diagnostics.DebuggerStepThrough()]
        private static bool NotSameUInt64(T value1, T value2)
        {
            return (UInt64)(object)value1 != (UInt64)(object)value2;
        }

        [System.Diagnostics.DebuggerStepThrough()]
        private static bool NotSameSByte(T value1, T value2)
        {
            return (sbyte)(object)value1 != (sbyte)(object)value2;
        }

        [System.Diagnostics.DebuggerStepThrough()]
        private static bool NotSameByte(T value1, T value2)
        {
            return (byte)(object)value1 != (byte)(object)value2;
        }
        #endregion

        #region "LessThan"
        [System.Diagnostics.DebuggerStepThrough()]
        private static bool LessThanInt16(T value1, T value2)
        {
            return (Int16)(object)value1 < (Int16)(object)value2;
        }

        [System.Diagnostics.DebuggerStepThrough()]
        private static bool LessThanInt32(T value1, T value2)
        {
            return (Int32)(object)value1 < (Int32)(object)value2;
        }

        [System.Diagnostics.DebuggerStepThrough()]
        private static bool LessThanInt64(T value1, T value2)
        {
            return (Int64)(object)value1 < (Int64)(object)value2;
        }

        [System.Diagnostics.DebuggerStepThrough()]
        private static bool LessThanSingle(T value1, T value2)
        {
            return (float)(object)value1 < (float)(object)value2;
        }

        [System.Diagnostics.DebuggerStepThrough()]
        private static bool LessThanDouble(T value1, T value2)
        {
            return (double)(object)value1 < (double)(object)value2;
        }

        [System.Diagnostics.DebuggerStepThrough()]
        private static bool LessThanDecimal(T value1, T value2)
        {
            return (decimal)(object)value1 < (decimal)(object)value2;
        }

        [System.Diagnostics.DebuggerStepThrough()]
        private static bool LessThanUInt16(T value1, T value2)
        {
            return (UInt16)(object)value1 < (UInt16)(object)value2;
        }

        [System.Diagnostics.DebuggerStepThrough()]
        private static bool LessThanUInt32(T value1, T value2)
        {
            return (Int32)(object)value1 < (Int32)(object)value2;
        }

        [System.Diagnostics.DebuggerStepThrough()]
        private static bool LessThanUInt64(T value1, T value2)
        {
            return (UInt64)(object)value1 < (UInt64)(object)value2;
        }

        [System.Diagnostics.DebuggerStepThrough()]
        private static bool LessThanSByte(T value1, T value2)
        {
            return (sbyte)(object)value1 < (sbyte)(object)value2;
        }

        [System.Diagnostics.DebuggerStepThrough()]
        private static bool LessThanByte(T value1, T value2)
        {
            return (byte)(object)value1 < (byte)(object)value2;
        }
        #endregion

        #region "GreaterThan"
        [System.Diagnostics.DebuggerStepThrough()]
        private static bool GreaterThanInt16(T value1, T value2)
        {
            return (Int16)(object)value1 > (Int16)(object)value2;
        }

        [System.Diagnostics.DebuggerStepThrough()]
        private static bool GreaterThanInt32(T value1, T value2)
        {
            return (Int32)(object)value1 > (Int32)(object)value2;
        }

        [System.Diagnostics.DebuggerStepThrough()]
        private static bool GreaterThanInt64(T value1, T value2)
        {
            return (Int64)(object)value1 > (Int64)(object)value2;
        }

        [System.Diagnostics.DebuggerStepThrough()]
        private static bool GreaterThanSingle(T value1, T value2)
        {
            return (float)(object)value1 > (float)(object)value2;
        }

        [System.Diagnostics.DebuggerStepThrough()]
        private static bool GreaterThanDouble(T value1, T value2)
        {
            return (double)(object)value1 > (double)(object)value2;
        }

        [System.Diagnostics.DebuggerStepThrough()]
        private static bool GreaterThanDecimal(T value1, T value2)
        {
            return (decimal)(object)value1 > (decimal)(object)value2;
        }

        [System.Diagnostics.DebuggerStepThrough()]
        private static bool GreaterThanUInt16(T value1, T value2)
        {
            return (UInt16)(object)value1 > (UInt16)(object)value2;
        }

        [System.Diagnostics.DebuggerStepThrough()]
        private static bool GreaterThanUInt32(T value1, T value2)
        {
            return (Int32)(object)value1 > (Int32)(object)value2;
        }

        [System.Diagnostics.DebuggerStepThrough()]
        private static bool GreaterThanUInt64(T value1, T value2)
        {
            return (UInt64)(object)value1 > (UInt64)(object)value2;
        }

        [System.Diagnostics.DebuggerStepThrough()]
        private static bool GreaterThanSByte(T value1, T value2)
        {
            return (sbyte)(object)value1 > (sbyte)(object)value2;
        }

        [System.Diagnostics.DebuggerStepThrough()]
        private static bool GreaterThanByte(T value1, T value2)
        {
            return (byte)(object)value1 > (byte)(object)value2;
        }
        #endregion

        #region "LessThanOrEqualTo"
        [System.Diagnostics.DebuggerStepThrough()]
        private static bool LessThanOrEqualToInt16(T value1, T value2)
        {
            return (Int16)(object)value1 <= (Int16)(object)value2;
        }

        [System.Diagnostics.DebuggerStepThrough()]
        private static bool LessThanOrEqualToInt32(T value1, T value2)
        {
            return (Int32)(object)value1 <= (Int32)(object)value2;
        }

        [System.Diagnostics.DebuggerStepThrough()]
        private static bool LessThanOrEqualToInt64(T value1, T value2)
        {
            return (Int64)(object)value1 <= (Int64)(object)value2;
        }

        [System.Diagnostics.DebuggerStepThrough()]
        private static bool LessThanOrEqualToSingle(T value1, T value2)
        {
            return (float)(object)value1 <= (float)(object)value2;
        }

        [System.Diagnostics.DebuggerStepThrough()]
        private static bool LessThanOrEqualToDouble(T value1, T value2)
        {
            return (double)(object)value1 <= (double)(object)value2;
        }

        [System.Diagnostics.DebuggerStepThrough()]
        private static bool LessThanOrEqualToDecimal(T value1, T value2)
        {
            return (decimal)(object)value1 <= (decimal)(object)value2;
        }

        [System.Diagnostics.DebuggerStepThrough()]
        private static bool LessThanOrEqualToUInt16(T value1, T value2)
        {
            return (UInt16)(object)value1 <= (UInt16)(object)value2;
        }

        [System.Diagnostics.DebuggerStepThrough()]
        private static bool LessThanOrEqualToUInt32(T value1, T value2)
        {
            return (Int32)(object)value1 <= (Int32)(object)value2;
        }

        [System.Diagnostics.DebuggerStepThrough()]
        private static bool LessThanOrEqualToUInt64(T value1, T value2)
        {
            return (UInt64)(object)value1 <= (UInt64)(object)value2;
        }

        [System.Diagnostics.DebuggerStepThrough()]
        private static bool LessThanOrEqualToSByte(T value1, T value2)
        {
            return (sbyte)(object)value1 <= (sbyte)(object)value2;
        }

        [System.Diagnostics.DebuggerStepThrough()]
        private static bool LessThanOrEqualToByte(T value1, T value2)
        {
            return (byte)(object)value1 <= (byte)(object)value2;
        }
        #endregion

        #region "GreaterThanOrEqualTo"
        [System.Diagnostics.DebuggerStepThrough()]
        private static bool GreaterThanOrEqualToInt16(T value1, T value2)
        {
            return (Int16)(object)value1 >= (Int16)(object)value2;
        }

        [System.Diagnostics.DebuggerStepThrough()]
        private static bool GreaterThanOrEqualToInt32(T value1, T value2)
        {
            return (Int32)(object)value1 >= (Int32)(object)value2;
        }

        [System.Diagnostics.DebuggerStepThrough()]
        private static bool GreaterThanOrEqualToInt64(T value1, T value2)
        {
            return (Int64)(object)value1 >= (Int64)(object)value2;
        }

        [System.Diagnostics.DebuggerStepThrough()]
        private static bool GreaterThanOrEqualToSingle(T value1, T value2)
        {
            return (float)(object)value1 >= (float)(object)value2;
        }

        [System.Diagnostics.DebuggerStepThrough()]
        private static bool GreaterThanOrEqualToDouble(T value1, T value2)
        {
            return (double)(object)value1 >= (double)(object)value2;
        }

        [System.Diagnostics.DebuggerStepThrough()]
        private static bool GreaterThanOrEqualToDecimal(T value1, T value2)
        {
            return (decimal)(object)value1 >= (decimal)(object)value2;
        }

        [System.Diagnostics.DebuggerStepThrough()]
        private static bool GreaterThanOrEqualToUInt16(T value1, T value2)
        {
            return (UInt16)(object)value1 >= (UInt16)(object)value2;
        }

        [System.Diagnostics.DebuggerStepThrough()]
        private static bool GreaterThanOrEqualToUInt32(T value1, T value2)
        {
            return (Int32)(object)value1 >= (Int32)(object)value2;
        }

        [System.Diagnostics.DebuggerStepThrough()]
        private static bool GreaterThanOrEqualToUInt64(T value1, T value2)
        {
            return (UInt64)(object)value1 >= (UInt64)(object)value2;
        }

        [System.Diagnostics.DebuggerStepThrough()]
        private static bool GreaterThanOrEqualToSByte(T value1, T value2)
        {
            return (sbyte)(object)value1 >= (sbyte)(object)value2;
        }

        [System.Diagnostics.DebuggerStepThrough()]
        private static bool GreaterThanOrEqualToByte(T value1, T value2)
        {
            return (byte)(object)value1 >= (byte)(object)value2;
        }
        #endregion

    }

}