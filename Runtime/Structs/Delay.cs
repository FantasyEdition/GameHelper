using System;
using System.Globalization;
using UnityEngine;
namespace GameHelper.Structs
{
[Serializable]
public struct Delay : IEquatable<Delay>,IFormattable
{
   public float time;
   public float maxTime;
   public static Delay Milisecond = new Delay(0.1f);
   public static Delay Second = new Delay(1);
   public static Delay Minut = new Delay(60);
   public Delay(float max,float value)
    {
        this.maxTime=max;
        this.time=Mathf.Min(value,max);
    }
    public Delay(float max)
    {
        this.maxTime=max;
        time=0;
    }
    public void Tick(float speed)
    {
        time=Mathf.Min(time+Time.deltaTime*speed,maxTime);
    }
    public void Reset()
    {
        time=0;
    }
     public override readonly int GetHashCode()
    {
        return time.GetHashCode() ^ (maxTime.GetHashCode() << 2);
    }
    public override readonly bool Equals(object other)
    {
        if (other is Delay other2)
        {
            return Equals(in other2);
        }

        return false;
    }

    public readonly bool Equals(Delay other)
    {
        return time==other.time && maxTime==other.maxTime;
    }
    public readonly bool Equals(in Delay other)
    {
        return time==other.time && maxTime==other.maxTime;
    }
    public readonly override string ToString()
    {
       return ToString(null,null);
    }
    public readonly string ToString(string format)
    {
       return ToString(format,null);
    }

    public readonly string ToString(string format, IFormatProvider formatProvider)
    {
          if (string.IsNullOrEmpty(format))
        {
            format = "F2";
        }

        if (formatProvider == null)
        {
            formatProvider = CultureInfo.InvariantCulture.NumberFormat;
        }

        return $"({time.ToString(format, formatProvider)}/ {maxTime.ToString(format, formatProvider)})";
    }

    public static Delay operator + (Delay a, float b)
    {
        return new Delay(a.maxTime,a.time+b);
    }
    public static Delay operator - (Delay a, float b)
    {
        return new Delay(a.maxTime,a.time-b);
    }
    public static Delay operator * (Delay a, float b)
    {
        return new Delay(a.maxTime,a.time*b);
    }
    public static Delay operator / (Delay a, float b)
    {
        return new Delay(a.maxTime,a.time/b);
    }
    public static bool operator == (Delay a, Delay b)
    {
        return a.time==b.time;
    }
    public static bool operator != (Delay a, Delay b)
    {
        return a.time!=b.time;
    }
    public static bool operator > (Delay a, Delay b)
    {
        return a.time>b.time;
    }
    public static bool operator < (Delay a, Delay b)
    {
        return a.time<b.time;
    }
}
}