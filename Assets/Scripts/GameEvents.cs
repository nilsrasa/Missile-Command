using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents
{
    public static System.Action<int> missileDestroyed;
    public static System.Action<City> cityDestroyed;
    public static System.Action<int> uiScore;
}
