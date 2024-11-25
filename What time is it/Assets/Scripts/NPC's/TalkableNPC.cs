using System.Collections.Generic;
using UnityEngine;

public class TalkableNPC : MonoBehaviour
{
    [SerializeField] private List<string> PhrasesField;
    
    private Animator _animator;

    protected IReadOnlyList<string> Phrases => PhrasesField;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }
    
    public virtual void StartTalking(){}
}
