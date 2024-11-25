using TMPro;
using UnityEngine;

public class HintTrigger : MonoBehaviour
{
    [SerializeField] private string _hintText;
    [SerializeField] private GameObject _hintPrefab;
    [SerializeField] private Vector3 _offset;
    [SerializeField] private Transform _canvas;

    private GameObject _spawnedHint;

    private void Update()
    {
        if (_spawnedHint != null)
        {
            _spawnedHint.transform.position = Camera.main.WorldToScreenPoint(transform.position + _offset);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player") || _hintPrefab == null)
            return;

        _spawnedHint = Instantiate(_hintPrefab, _canvas);
        
        _spawnedHint.GetComponent<TextMeshProUGUI>().text = _hintText;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
            return;
        
        Destroy(_spawnedHint);
    }
}
