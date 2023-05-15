using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject BulletPrefab;
    public Transform Spawn;
    public AudioSource ShotSound;
    public GameObject Flash;
    public ParticleSystem ShotEffect;

    public float BulletSpeed = 10f;
    public float ShotPeriod = 0.2f;


    private float _timer;
    void Update()
    {
        
        _timer += Time.unscaledDeltaTime; 
        if (_timer > ShotPeriod && Input.GetMouseButton(0))
        {
            _timer= 0;
            Shot();
        }

    }
    public virtual void Shot()
    {
        GameObject newBullet = Instantiate(BulletPrefab, Spawn.position, Spawn.rotation);
        newBullet.GetComponent<Rigidbody>().velocity = Spawn.forward * BulletSpeed;
        ShotSound.Play();
        Flash.SetActive(true);
        Invoke(nameof(HideFlash), 0.1f);
        ShotEffect.Play();
    }

    public void HideFlash()
    {
        Flash.SetActive(false);
    }

    public virtual void Activate()
    {
        gameObject.SetActive(true);
    }
    public virtual void Deactivate()
    {
        gameObject.SetActive(false);
    }

    public virtual void AddBullets(int numberOfBullets)
    { }

}
