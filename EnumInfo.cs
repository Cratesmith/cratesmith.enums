using System;
using System.Collections;
using Unity.Collections.LowLevel.Unsafe;

namespace com.cratesmith.Enums
{
	public static class EnumInfo<T> where T: Enum
	{
		public static readonly Type     underlyingType;
		public static readonly int		underlyingTypeSize;
		public static readonly T[]      values;
		public static readonly long[]   numbers;
		public static readonly long[]   sortedNumbers;
		public static readonly string[] names;

		static EnumInfo()
		{
			underlyingType = Enum.GetUnderlyingType(typeof(T));
			underlyingTypeSize = UnsafeUtility.SizeOf(underlyingType);
			
			IList rawValues = Enum.GetValues(typeof(T));
			values = new T[rawValues.Count];
			numbers = new long[rawValues.Count];
			sortedNumbers = new long[rawValues.Count];
			
			for (int i = 0; i < rawValues.Count; i++)
			{
				values[i]  = (T)rawValues[i];
				sortedNumbers[i] = numbers[i] = GetNumber(values[i]);
			}
			Array.Sort(sortedNumbers);
			
			names = Enum.GetNames(typeof(T));
		}

		public static bool TryGetIndex(T value, out int index)
		{
			index = Array.BinarySearch(sortedNumbers, GetNumber(value));
			return index>=0;
		}

		public static string GetName(T value)
		{
			if (TryGetIndex(value, out var i))
				return names[i];

			return "<unknown>";
		}

		public static long GetNumber(T value)
		{
			switch (underlyingTypeSize)
			{
				case sizeof(byte):
					return UnsafeUtility.As<T, byte>(ref value);

				case sizeof(short):
					return UnsafeUtility.As<T, short>(ref value);

				case sizeof(int):
					return UnsafeUtility.As<T, int>(ref value);

				case sizeof(long):
					return UnsafeUtility.As<T, long>(ref value);
			}
			throw new ArgumentException("unhandled backing type");
		}

		public static T GetEnum(long value)
		{
			switch (underlyingTypeSize)
			{
				case sizeof(byte):
					var b = (byte)value; 
					return UnsafeUtility.As<byte, T>(ref b);

				case sizeof(short):
					var s = (short)value;
					return UnsafeUtility.As<short,T>(ref s);

				case sizeof(int):
					var i = (int)value;
					return UnsafeUtility.As<int,T>(ref i);

				case sizeof(long):
					return UnsafeUtility.As<long,T>(ref value);
			}
			throw new ArgumentException("unhandled backing type");
		}

		public static bool TryGetEnumValueAtIndex(int index, out T output)
		{
			if (index < 0 || index >= EnumInfo<T>.values.Length)
			{
				output = default;
				return false;
			}

			output = EnumInfo<T>.values[index];
			return true;
		}
	}
}
