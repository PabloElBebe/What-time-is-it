using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightBlinking : MonoBehaviour
{
    [SerializeField] private Vector2 _blinkingBorders;
    [SerializeField] private float _blinkingSpeed;
    
    private Light2D _light;

    private void OnEnable()
    {
        _light = GetComponent<Light2D>();
        
        if (_light == null)
            return;
        
        StartCoroutine(Blinking());
    }

    private IEnumerator Blinking()
    {
        while (true)
        {
            float targetLight = Random.Range(_blinkingBorders.x, _blinkingBorders.y);

            while (Mathf.Abs(_light.intensity - targetLight) > 0.001f)
            {
                _light.intensity = Mathf.Lerp(_light.intensity, targetLight, Time.deltaTime * _blinkingSpeed);
                yield return null;
            }
        }
    }
}
