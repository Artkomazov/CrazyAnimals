using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blink : MonoBehaviour
{
    public Renderer[] Renderer;

    public void StartBlink()
    {
        StartCoroutine(BlinkEffect());
    }

    public IEnumerator BlinkEffect()
    {

        for (float t = 0; t < 1; t += Time.deltaTime)
        {
            for (int i = 0; i < Renderer.Length; i++)
            {
                for (int j = 0; j < Renderer[i].materials.Length; j++)
                {
                    Renderer[i].materials[j].SetColor("_EmissionColor", new Color(Mathf.Sin(t * 20) * 0.5f + 0.5f, 0, 0, 0));
                }
            }
            yield return null;
        }

        for (int i = 0; i < Renderer.Length; i++)
        {
            for (int j = 0; j < Renderer[i].materials.Length; j++)
            {
                Renderer[i].materials[j].SetColor("_EmissionColor", new Color(0.01f, 0, 0, 0));
            }
            
        }
    }
}
