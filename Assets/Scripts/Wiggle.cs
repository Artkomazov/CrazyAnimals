using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wiggle : MonoBehaviour
{
    public float amplitude = 0.5f; // амплитуда колебаний
    public float frequency = 1f; // частота колебаний

    private Vector3 startPos; // начальная позиция объекта

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        float offset = amplitude * Mathf.Sin(frequency * Time.time);
        transform.position = startPos + new Vector3(0, offset, 0);
    }
}
