using UnityEngine;
using System.Collections;

public class EnumTypes 
{

	// Use this for initialization
    public enum CloudState {Clear = 0, PartlyCloudy = 1, MostlyCloudy = 2, Cloudy = 3, Random = 4 };
    public enum DayState { Morning = 0, Afternoon = 1, Evening = 2, Night = 3 };
    public enum BackgroundSelection{ Clear = 0, Hills = 1, Forest= 2};
    public enum PlatformMapType { Empty = 0, A = 1, V = 2, BLine = 3, ULine = 4, TwoBottom = 5, TwoTop = 6 };
}
