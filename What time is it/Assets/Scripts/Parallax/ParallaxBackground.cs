using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    [SerializeField] private ParallaxCamera _parallaxCamera;

    private List<ParallaxLayer> ParallaxLayers = new List<ParallaxLayer>();

    private void Start()
    {
        if (_parallaxCamera == null)
            return;

        _parallaxCamera.onCameraTranslate += Move;
        
        SetLayers();
    }

    private void SetLayers()
    {
        ParallaxLayers.Clear();

        for (int i = 0; i < transform.childCount; i++)
        {
            ParallaxLayer layer = transform.GetChild(i).GetComponent<ParallaxLayer>();
            
            if (layer == null)
                return;
            
            ParallaxLayers.Add(layer);
        }
    }

    private void Move(float delta)
    {
        foreach (ParallaxLayer layer in ParallaxLayers)
        {
            layer.Move(delta);
        }
    }
}
