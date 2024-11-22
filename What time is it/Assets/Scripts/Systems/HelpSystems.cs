using System;
using System.Collections.Generic;
using UnityEngine;

public class HelpSystems : MonoBehaviour
{
    public static Action<List<string>> StartDialogue;
    public static Action<int> SetCurrentLocation;
}
