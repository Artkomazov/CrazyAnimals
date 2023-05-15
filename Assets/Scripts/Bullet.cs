using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject EffectPrefab;
    
    private void Start()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        Destroy(gameObject, 4f);
    }
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
        Instantiate(EffectPrefab, transform.position, Quaternion.identity);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<TakeDamageOnTrigger>())
        {
                Destroy(gameObject);
                Instantiate(EffectPrefab, transform.position, Quaternion.identity);
        }
    }
}
