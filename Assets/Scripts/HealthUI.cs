using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUI : MonoBehaviour
{
    public GameObject HealthIconPrefab;
    public List<GameObject> HealthIcons = new();
    public void Setup(int maxHealth)
    {
        for (int i = 0; i < maxHealth; i++)
        {
            HealthIcons.Add(Instantiate(HealthIconPrefab, transform));
        }
    }

    public void DisplayHealth(int health)
    {
        for (int i = 0; i < HealthIcons.Count; i++)
        {
            if (i < health)
            {
                HealthIcons[i].SetActive(true);
            }
            else
            {
                HealthIcons[i].SetActive(false);
            }
        }
    }
}
