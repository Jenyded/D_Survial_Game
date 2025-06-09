using System;
using UniRx;

[Serializable]
public class PlayerOptions
{
    public ReactiveProperty<bool> Sound = new(true);
    public ReactiveProperty<bool> Music = new(true);
    public ReactiveProperty<bool> Vibration = new(true);
    public ReactiveProperty<string> CurrentLanguage = new("");
}