using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carrot : MonoBehaviour
{
    public Rigidbody Rigidbody;
    public float Speed;

    void Start()
    {
        transform.rotation = Quaternion.identity;
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        Transform playerTransform = FindObjectOfType<PlayerMove>().transform;
        Vector3 toPlayer = (playerTransform.position- transform.position).normalized;
        Rigidbody.velocity = toPlayer * Speed;
    }
}
