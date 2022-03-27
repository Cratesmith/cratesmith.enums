# cratesmith.enums
helper methods for working with enums in Unity3d

Contains EnumInfo<T>, a class that caches off values and names of enums for faster/easier access. 
  
Also adds the following extension methods for enums:
    public static bool HasName<T>(this T self) where T : Enum
		public static string ToName<T>(this T self) where T : Enum 
		public static long ToNumber<T>(this T self) where T : Enum 	
		public static int ToEnumIndex<T>(this T self) where T : Enum 		
		public static bool TryGetIndex<T>(this T self, out int output) where T : Enum
		public static T ToEnum<T>(this byte self) where T : Enum 
		public static T ToEnum<T>(this short self) where T : Enum 
		public static T ToEnum<T>(this int self) where T : Enum 
		public static T ToEnum<T>(this long self) where T : Enum 
		public static T ToEnumFromIndex<T>(this int self) where T : Enum
		public static bool TryGetEnumFromIndex<T>(this int self, out T output) where T : Enum
