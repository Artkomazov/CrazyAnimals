using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootHeal : MonoBehaviour
{
    public int HealthValue = 1;

    private void OnTriggerStay(Collider other)
    {
        PlayerHealth playerHealth = other.attachedRigidbody.GetComponent<PlayerHealth>();

        if (playerHealth && playerHealth.Health < playerHealth.MaxHealth)
        {
            playerHealth.AddHealth(HealthValue);
            Destroy(gameObject);
        }
    }
}
