using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootBullets : MonoBehaviour
{
    public int GunIndex;
    public int NumberOfBullets;

    public AudioSource LootSound;

    private void OnTriggerStay(Collider other)
    {
        if (other.attachedRigidbody.GetComponent <PlayerArmory>())
        {
            other.attachedRigidbody.GetComponent<PlayerArmory>().AddBullets(GunIndex, NumberOfBullets);
            LootSound.Play();
            Destroy(gameObject);
        }
    }
}
