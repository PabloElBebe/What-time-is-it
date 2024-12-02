using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterPoint : MonoBehaviour
{
    [SerializeField] private EnterPointType PointType;
    [SerializeField] private int _sceneIndex;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.GetComponent<EnterSubject>())
            return;
        
        other.GetComponent<EnterSubject>().EnterTrigger(this);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.GetComponent<EnterSubject>())
            return;
        
        other.GetComponent<EnterSubject>().EnterTrigger(this);
    }

    public void UsePoint()
    {
        switch (PointType)
        {
            case EnterPointType.Enter:
                SceneManager.LoadScene(_sceneIndex);
                break;
            case EnterPointType.Exit:
                SceneManager.LoadScene(_sceneIndex);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}
