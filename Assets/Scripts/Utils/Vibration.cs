using System.Runtime.InteropServices;

public class Vibration
{
    private readonly PlayerOptions _options;

    public Vibration(PlayerOptions options)
    {
        _options = options;
    }
    
    /* [DllImport("__Internal")]
     private static extern void Vibrate(int ms);

     public void VibrateFor(int ms)
     {
         if (_options.Vibration.Value)
             Vibrate(ms);
     }*/
}