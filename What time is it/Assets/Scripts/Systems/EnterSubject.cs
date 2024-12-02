using System;
using UnityEngine;

public class EnterSubject : MonoBehaviour
{
    private EnterPoint _enterPoint;

    private void Update()
    {
        if (_enterPoint != null && Input.GetKeyDown(KeyCode.E))
            _enterPoint.UsePoint();
    }

    public void EnterTrigger(EnterPoint point)
    {
        _enterPoint = point;
    }
}
