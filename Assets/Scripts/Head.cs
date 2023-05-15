using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Head : MonoBehaviour
{
    public Transform Terget;
    void Update()
    {
        transform.position = Terget.position;
    }
}
