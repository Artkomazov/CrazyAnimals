using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wiggle : MonoBehaviour
{
    public float amplitude = 0.5f; // ��������� ���������
    public float frequency = 1f; // ������� ���������

    private Vector3 startPos; // ��������� ������� �������

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
