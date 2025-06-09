using System;
using System.Collections.Generic;
using System.Linq;
using UniRx;
using UnityEngine;

public static class DataExtension
{
    public static Vector3 FastLerp(Vector3 a, Vector3 b, float t)
    {
        a.x += (b.x - a.x) * t;
        a.y += (b.y - a.y) * t;
        a.z += (b.z - a.z) * t;

        return a;
    }
    
    public static DateTime UnixTimeToDateTime(long unixTime)
    {
        if(unixTime == 0)
            return DateTime.MinValue;
        var offset = DateTimeOffset.FromUnixTimeMilliseconds(unixTime);
        return offset.UtcDateTime;
    }

    public static long ToUnixDate(DateTime date)
    {
        if (date == DateTime.MinValue)
            return 0;
        
        var offset = new DateTimeOffset(date);
        return offset.ToUnixTimeMilliseconds();
    }

    public static Vector3 FastAdd(Vector3 a, Vector3 b)
    {
        a.x += b.x;
        a.y += b.y;
        a.z += b.z;

        return a;
    }
}