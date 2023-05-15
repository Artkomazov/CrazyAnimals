using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum Direction
{
    Left,
    Right
}

public class Walker : MonoBehaviour
{
    public Transform LeftTarget;
    public Transform RightTarget;
    public Direction CurrentDirection;

    public float Speed;
    public float StopTime;

    private bool _isStopped;

    public UnityEvent EventOnLeftTarget;
    public UnityEvent EventOnRightTarget;

    public Transform RayStart;

    private void Start()
    {
        LeftTarget.parent = null;
        RightTarget.parent = null;
    }

    void Update()
    {
        if (_isStopped) return;

        if (CurrentDirection == Direction.Left)
        {
            if (transform.position.x < LeftTarget.transform.position.x) 
            {
                CurrentDirection = Direction.Right;
                _isStopped = true;
                Invoke(nameof(ContinueWalk), StopTime);
                EventOnRightTarget.Invoke();
            }
            transform.position -= new Vector3(Time.deltaTime * Speed, 0, 0);
        }
        else
        {
            if (transform.position.x > RightTarget.transform.position.x)
            {
                CurrentDirection = Direction.Left;
                _isStopped = true;
                Invoke(nameof(ContinueWalk), StopTime);
                EventOnLeftTarget.Invoke();
            }
            transform.position += new Vector3(Time.deltaTime * Speed, 0, 0);
        }

        RaycastHit hit;
        if (Physics.Raycast(RayStart.position, Vector3.down, out hit)) 
        { 
            transform.position = hit.point;
        }
    }

    void ContinueWalk()
    {
        _isStopped = false;
    }
}
