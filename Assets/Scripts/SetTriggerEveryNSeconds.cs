using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTriggerEveryNSeconds : MonoBehaviour
{
    public float Period = 7f;
    private float _timer;
    public string TriggerName;

    public Animator Animator;

    private void Update()
    {
        if (Animator != null)
        {
            _timer += Time.deltaTime;
            if (_timer > Period)
            {
                _timer = 0;
                Animator.SetTrigger(TriggerName);
            }
        }
        
    }
}
