using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int Health = 5;
    public int MaxHealth = 8;
    private bool _invulnerable;
    protected bool _healing;

    public AudioSource AddHelthSound;
    public HealthUI HealthUI;
    
    public UnityEvent EventOfTakeDamage;

    private void Start()
    {
        HealthUI.Setup(MaxHealth);
        HealthUI.DisplayHealth(Health);
    }

    public void TakeDamage(int damageValue)
    {
        if (_invulnerable == false)
        {
            Health -= damageValue;
            if (Health <= 0)
            {
                Health = 0;
                Die();
            }
            _invulnerable = true;
            Invoke(nameof(StopInvulnerable), 1f);

            HealthUI.DisplayHealth(Health);
            EventOfTakeDamage.Invoke();
        }

    }

    void StopInvulnerable()
    {
        _invulnerable = false;
    }

    public void AddHealth(int healthValue)
    {
        if (_healing == true)
        {
            return;
        }
        else
        {
            Health += healthValue;
            if (Health > MaxHealth)
            {
                Health = MaxHealth;
            }

            _healing = true;
            Invoke(nameof(StopHealing), 0.1f);

            AddHelthSound.Play();
            HealthUI.DisplayHealth(Health);
        }
    }

    void Die()
    {
        Invoke("LoadScene", 0.5f);
    }

    void LoadScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }

    void StopHealing()
    {
        _healing = false;
    }
}
