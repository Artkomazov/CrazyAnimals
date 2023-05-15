using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateOnTrigger : MonoBehaviour
{
    public GameObject PrefabForInstantiate;
    public float Delay = 0;

    private bool _isUsed;

    private void OnTriggerEnter(Collider other)
    {
        if (!_isUsed)
        {
            if (other.attachedRigidbody.GetComponent<PlayerMove>())
            {
                Invoke(nameof(PrefabInstantiate), Delay);
                _isUsed = true;
            }
        }
       
    }

    private void PrefabInstantiate()
    {
        Instantiate(PrefabForInstantiate, transform.position, transform.rotation);
    }
}
