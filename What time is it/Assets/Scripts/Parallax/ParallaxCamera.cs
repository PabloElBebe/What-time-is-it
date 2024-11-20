using UnityEngine;

public class ParallaxCamera : MonoBehaviour
{
    public delegate void ParallaxCameraDelegate(float deltaMovement);
    public ParallaxCameraDelegate onCameraTranslate;

    private float _oldPositionX;

    private void Start()
    {
        _oldPositionX = transform.position.x;
    }

    private void Update()
    {
        if (transform.position.x == _oldPositionX || onCameraTranslate == null)
            return;

        float delta = transform.position.x - _oldPositionX;
        onCameraTranslate(delta);
        _oldPositionX = transform.position.x;
    }
}
