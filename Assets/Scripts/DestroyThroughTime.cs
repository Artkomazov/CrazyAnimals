using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyThroughTime : MonoBehaviour
{
    public float TimeToDestroy = 1f;
    private void Start()
    {
        Destroy(gameObject, TimeToDestroy);
    }
}
