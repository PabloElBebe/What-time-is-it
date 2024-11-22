using System.Collections.Generic;
using UnityEngine;

public class LocationManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> Locations;

    private void Awake()
    {
        HelpSystems.SetCurrentLocation += SetLocationByIndex;
    }

    private void SetLocationByIndex(int index)
    {
        if (index > Locations.Count - 1 || index < 0)
            return;
        
        CloseAllLocations();
        
        Locations[index].SetActive(true);
    }

    private void CloseAllLocations()
    {
        foreach (GameObject location in Locations)
        {
            location.SetActive(false);
        }
    }
}
