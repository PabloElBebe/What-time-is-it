using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Transition : MonoBehaviour
{
    private int _currentLocationIndex;

    private Animator _animator;

    private void Awake()
    {
        HelpSystems.Transition += StartTransition;
    }

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void StartTransition(int index)
    {
        if (_animator == null)
            return;
        if (_animator.GetBool("isTransition") && _currentLocationIndex != index)
            return;

        _animator.SetBool("isTransition", true);

        _currentLocationIndex = index;
    }

    private void ChangeLocation()
    {
        _animator.SetBool("isTransition", false);
        
        HelpSystems.SetCurrentLocation(_currentLocationIndex);
    }
}
