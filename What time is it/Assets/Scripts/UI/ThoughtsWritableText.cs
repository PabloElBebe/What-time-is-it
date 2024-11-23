using Cinemachine;
using UnityEngine;

public class ThoughtsWritableText : SoloWritableText
{
    [SerializeField] private Vector3 _textOffset;

    private GameObject _playerObject;

    private void Start()
    {
        _playerObject = GameObject.FindGameObjectWithTag("Player");
    }

    private void Awake()
    {
        HelpSystems.OpenThoughts += StartWriting;
    }

    private void Update()
    {
        FollowPlayer();
    }

    private void FollowPlayer()
    {
        if (_playerObject == null)
            return;

        transform.position = Camera.main.WorldToScreenPoint(_playerObject.transform.position + _textOffset);
    }
}
