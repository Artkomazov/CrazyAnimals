using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class SetColliderbyAnimation : MonoBehaviour
{
    public Transform TopTarget;
    public Transform BottomLeftTarget;
    public Transform BottomRightTarget;
    public Collider Collider;

    void Update()
    {
        Transform bottomTarget;

        if (BottomLeftTarget.position.y < BottomRightTarget.position.y)
            bottomTarget = BottomLeftTarget;
        else
            bottomTarget = BottomRightTarget;

        float distanseTopToBottom = TopTarget.position.y - bottomTarget.position.y;
        float positionY = bottomTarget.position.y + distanseTopToBottom/2 - 0.05f;

        transform.position = new Vector3(transform.position.x, positionY, transform.position.z);
        transform.localScale = new Vector3(transform.localScale.x, distanseTopToBottom, transform.localScale.z);
        
    }
}
