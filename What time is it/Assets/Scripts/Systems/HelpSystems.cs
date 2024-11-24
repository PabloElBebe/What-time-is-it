using System;
using System.Collections.Generic;

public static class HelpSystems
{
    public static Action<int> Transition;
    public static Action<int> SetCurrentLocation;

    public static Action<List<string>> StartDialogue;
    public static Action<List<string>> OpenHelpHint;
    public static Action<List<string>> OpenThoughts;
}
