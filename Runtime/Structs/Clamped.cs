using System;
using UnityEngine;
namespace GameHelper.Structs
{
[Serializable]
public struct Clamped 
{
    [SerializeField]
    float value;
   [SerializeField] public float  min;
   [SerializeField] public float max;
    public Clamped(float value, float min, float max)
    {
        this.value=Mathf.Clamp(value,min,max);
        this.min=min;
        this.max=max;
    }

    public static Clamped operator +(Clamped a,float b)
    {
        return new Clamped(a.value+b,a.min,a.max);
    }
    public static Clamped operator -(Clamped a,float b)
    {
        return new Clamped(a.value-b,a.min,a.max);
    }
     public static Clamped operator *(Clamped a,float b)
    {
        return new Clamped(a.value*b,a.min,a.max);
    }
     public static Clamped operator /(Clamped a,float b)
    {
        return new Clamped(a.value/b,a.min,a.max);
    }
    
     public static implicit operator float (Clamped c)
    {
        return c.value;
    }
}
}