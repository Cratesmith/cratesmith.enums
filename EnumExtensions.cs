using System;

namespace com.cratesmith.Enums
{
	public static class EnumExtensions
	{
		public static bool HasName<T>(this T self) where T : Enum
			=> EnumInfo<T>.TryGetIndex(self, out var _);
		public static string ToName<T>(this T self) where T : Enum 
			=> EnumInfo<T>.GetName(self);
	
		public static long ToNumber<T>(this T self) where T : Enum 
			=> EnumInfo<T>.GetNumber(self);
	
		public static int ToEnumIndex<T>(this T self) where T : Enum 
			=> EnumInfo<T>.TryGetIndex(self, out var i) 
				? i
				: -1;
		
		public static bool TryGetIndex<T>(this T self, out int output) where T : Enum
			=> EnumInfo<T>.TryGetIndex(self, out output);
		
		public static T ToEnum<T>(this byte self) where T : Enum 
			=> EnumInfo<T>.GetEnum(self);

		public static T ToEnum<T>(this short self) where T : Enum 
			=> EnumInfo<T>.GetEnum(self);

		public static T ToEnum<T>(this int self) where T : Enum 
			=> EnumInfo<T>.GetEnum(self);
		public static T ToEnum<T>(this long self) where T : Enum 
			=> EnumInfo<T>.GetEnum(self);

		public static T ToEnumFromIndex<T>(this int self) where T : Enum
			=> EnumInfo<T>.values[self];

		public static bool TryGetEnumFromIndex<T>(this int self, out T output) where T : Enum
			=> EnumInfo<T>.TryGetEnumValueAtIndex(self, out output);
	}
}
