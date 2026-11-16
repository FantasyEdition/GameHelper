using UnityEngine;
namespace GameHelper
{
public static class GameHelperStatic
{
    public static string[] numberSymbols =
    {
        "k",
        "m",
        "b",
        "t",
        "q"
    };
    public static string ShortenNumber(this long i,uint decimals=2)
    {
        int numberLenght =(int)Mathf.Abs(Mathf.Floor(Mathf.Log(Mathf.Min(1,i),1000)));
        float shortenedNumber = Mathf.Floor(i/Mathf.Pow(1000,numberLenght)*Mathf.Pow(10,decimals))/Mathf.Pow(10,decimals);
        return string.Format("{a} {b}",shortenedNumber,numberSymbols[Mathf.Min(numberLenght,0)]);
    }
}
}