using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using com.cratesmith.Enums;
using NUnit.Framework;
using Debug = UnityEngine.Debug;

public class Tests
{
    public enum IntEnum : int
    {
        Val1=0,
        Val2=1,
        Val3=2,
        ValMax=int.MaxValue
    }
    
    public enum ByteEnum : byte
    {
        Val1 =0,
        Val2 =1,
        Val3 =2,
        ValMax = byte.MaxValue
    }
    
    public enum ShortEnum : byte
    {
        Val1   =0,
        Val2   =1,
        Val3   =2,
        ValMax = byte.MaxValue
    }
    
    public enum LongEnum : long
    {
        Val1 =0,
        Val2 =1,
        Val3 =2,
        ValMax = long.MaxValue
    }

    // A Test behaves as an ordinary method
    [Test]
    public void ByteEnumTest()
    {
        GenericTests<ByteEnum>();
    }
    
    [Test]
    public void LongEnumTest()
    {
        GenericTests<LongEnum>();
    }
    
    [Test]
    public void IntEnumTest()
    {
        GenericTests<IntEnum>();
    }
    
    [Test]
    public void ShortEnumTest()
    {
        GenericTests<ShortEnum>();
    }
    
    public void GenericTests<T>() where T:Enum
    {
        IList rawValues = Enum.GetValues(typeof(T));
        foreach (var e in EnumInfo<T>.values)
        {
            Assert.AreEqual(e.ToName(), Enum.GetName(typeof(T), e));
            Assert.AreEqual(e, e.ToNumber().ToEnum<T>());
            Assert.AreEqual(rawValues.IndexOf(e), e.ToEnumIndex());
            Assert.AreEqual(e, e.ToEnumIndex().ToEnumFromIndex<T>());
            Assert.AreEqual(e, e.ToEnumIndex().ToEnumFromIndex<T>());
            Assert.IsFalse((-1).TryGetEnumFromIndex(out T _));
            Debug.Log($"type:{typeof(T).Name} number:{e.ToNumber()} name:{e.ToName()}");
        }
    }
}
