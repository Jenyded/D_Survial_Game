using System;

public static class TimeExtensions
{
    public static double TimeLeftSeconds(this long value)
    {
        DateTime dateTime = new(value);
        TimeSpan leftTime = dateTime - DateTime.Now;
        return leftTime.TotalSeconds;
    }

    public static long TimeLeft(this long value)
    {
        DateTime dateTime = new(value);
        TimeSpan leftTime = dateTime - DateTime.Now;
        return leftTime.Ticks;
    }

    public static long AddSeconds(this long value, float seconds)
    {
        DateTime dateTime = new(value);
        return dateTime.AddSeconds(seconds).Ticks;
    }

    public static string ToMs(this float value)
    {
        TimeSpan time = TimeSpan.FromSeconds(value);
        string ms = time.ToString(@"mm\:ss");

        return ms;
    }

    public static string ToMs(this long value)
    {
        TimeSpan time = TimeSpan.FromTicks(value);
        string ms = time.ToString(@"mm\:ss");

        return ms;
    }
    
    public static string ToHMs(this long value)
    {
        TimeSpan time = TimeSpan.FromTicks(value);
        string hms = time.ToString(@"hh\:mm\:ss");

        return hms;
    }
}