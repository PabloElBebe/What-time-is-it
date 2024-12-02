using System;
using UnityEngine;

public class ParallaxCamera : MonoBehaviour
{
    public Action<float> OnCameraTranslate;

    private float _oldPositionX;

    private void OnEnable()
    {
        _oldPositionX = transform.localPosition.x;
    }

    private void Update()
    {
        if (transform.localPosition.x == _oldPositionX || OnCameraTranslate == null)
            return;

        float delta = transform.localPosition.x - _oldPositionX;
        OnCameraTranslate?.Invoke(delta);
        _oldPositionX = transform.localPosition.x;
    }
}
