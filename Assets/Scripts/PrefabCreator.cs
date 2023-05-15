using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabCreator : MonoBehaviour
{
    public GameObject Prefab;
    public Transform Spawn;
    public AudioSource PrefabCreateSound;

    public void Create()
    {
        Instantiate(Prefab, Spawn.position, Spawn.rotation);
        if (PrefabCreateSound != null)
        {
            Instantiate(PrefabCreateSound, Spawn.position, Spawn.rotation);
        }
        
    }
}
