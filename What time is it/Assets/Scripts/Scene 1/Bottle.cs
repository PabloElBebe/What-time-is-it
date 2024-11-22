using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Bottle : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private AnimationCurve _animationCurve;

    private Animator _animator;

    private Vector2 _oldPosition;
    private Vector2 _velocity;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void TakeBottle(Transform targetTransform)
    {
        if (_animator == null)
            return;

        _animator.SetBool("isTaken", true);

        List<string> phrases = new List<string>();
        
        phrases.Add("Надо бы бухнуть");
        phrases.Add("Пойду водки найду епта как в песне");
        phrases.Add("Ладно пойду я");

        HelpSystems.StartDialogue(phrases);
        
        StartCoroutine(MoveBottle(targetTransform));
    }

    private IEnumerator MoveBottle(Transform targetTransform)
    {
        _oldPosition = transform.position;

        float progress = 0;

        while (Vector2.Distance(transform.position, targetTransform.position) > 0.01f)
        {
            progress += Time.deltaTime * _moveSpeed;

            transform.position = Vector2.Lerp(transform.position, targetTransform.position, _animationCurve.Evaluate(progress));

            Vector2 currentPosition = transform.position;
            _velocity = (currentPosition - _oldPosition) / Time.deltaTime;
            _oldPosition = currentPosition;

            transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(0, 0, _velocity.x * _moveSpeed),
                Time.deltaTime * 200);

            const float smoothness = 3;
            float scale = Mathf.Clamp(Vector2.Distance(currentPosition, targetTransform.position), 0, 0.3f * smoothness) / smoothness;

            transform.localScale = new Vector3(scale, scale, scale);

            yield return null;
        }

        Destroy();
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }
}
