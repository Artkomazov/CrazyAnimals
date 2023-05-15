using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public float Speed = 3f;
    public float RotationSpeed  = 5f;

    private Transform _playerTransform;

    void Start()
    {
        _playerTransform = FindObjectOfType<PlayerMove>().transform;
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
    }
    void Update()
    {
        transform.position += Speed * Time.deltaTime * transform.forward;
        Vector3 toPlayer = _playerTransform.position - transform.position;
        Quaternion tergetRotation = Quaternion.LookRotation(toPlayer, Vector3.forward);


        transform.rotation = Quaternion.Lerp(transform.rotation, tergetRotation, Time.deltaTime * RotationSpeed);
    }
}
