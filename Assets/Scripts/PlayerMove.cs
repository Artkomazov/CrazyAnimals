using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMove : MonoBehaviour
{
    public Rigidbody Rigidbody;
    public float MoveSpeed;
    public float JumpSpeed;
    public float Friction;
    public float MaxSpeed;
    public bool Grounded;


    public Animator PlayerAnimator;
    public Transform PlayerTopTransform;
    public Transform BodyTransform;
    public Transform PlayerCollider;
    public Transform Aim;
    

    private float _lerpSpeed = 5f;
    private bool _objectOverHead;

    void Update()
    {
        Vector3 toAim = Aim.position - transform.position;
        if (toAim.x > 0)
            BodyTransform.rotation = Quaternion.Lerp(BodyTransform.rotation, Quaternion.Euler(0, -50, 0), Time.deltaTime * _lerpSpeed);
        else
            BodyTransform.rotation = Quaternion.Lerp(BodyTransform.rotation, Quaternion.Euler(0, 50, 0), Time.deltaTime * _lerpSpeed);

        if (Physics.Raycast(PlayerTopTransform.position, Vector3.up, out _, 0.70f))
        {
            PlayerAnimator.SetBool("ObjectOverHead", true);
            _objectOverHead = true;
        }
        else
        {
            PlayerAnimator.SetBool("ObjectOverHead", false);
            _objectOverHead = false;
        }

        if (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.S))
        {
            PlayerAnimator.SetTrigger("Crouch");
            if (PlayerCollider.localScale.y == 1.42f)
            {
                PlayerCollider.localScale = new(1f, 1.2f, 1f);
            }
            else
            {
                PlayerCollider.localScale = new(1f, 1.42f, 1f);
            }
        }
          
        if (Input.GetKeyDown(KeyCode.Space) && Grounded && !_objectOverHead)
        {
            Jump();
        }


        if (Input.GetAxis("Horizontal") != 0)
            PlayerAnimator.SetBool("IsMove", true);
        else
            PlayerAnimator.SetBool("IsMove", false);

        if (Input.GetAxis("Horizontal") > 0)
        {
            if (transform.position.x < Aim.position.x)
            {
                PlayerAnimator.SetBool("MoveForvard", true);
            }
            else
            {
                PlayerAnimator.SetBool("MoveForvard", false);
            }
        }
        else
        {
            if (transform.position.x < Aim.position.x)
                PlayerAnimator.SetBool("MoveForvard", false);
            else
                PlayerAnimator.SetBool("MoveForvard", true);
        }

        if (Rigidbody.velocity.y < -14)
            PlayerAnimator.SetBool("Falling", true);
        else
            PlayerAnimator.SetBool("Falling", false);
    }

    public void Jump()
    {
        PlayerCollider.localScale = new(1f, 1.42f, 1f);
        PlayerAnimator.SetTrigger("Jump");
        Rigidbody.AddForce(0, JumpSpeed, 0, ForceMode.VelocityChange);
    }
    private void FixedUpdate()
    {
        float speedmultiplier = 1f;

        if (!Grounded)
        {
            speedmultiplier = 0.2f;

            if (Rigidbody.velocity.x > MaxSpeed && Input.GetAxis("Horizontal") > 0)
            {
                speedmultiplier = 0;
            }
            if (Rigidbody.velocity.x < -MaxSpeed && Input.GetAxis("Horizontal") < 0)
            {
                speedmultiplier = 0;
            }
        } 

        Rigidbody.AddForce(Input.GetAxis("Horizontal") * MoveSpeed * speedmultiplier, 0, 0, ForceMode.VelocityChange);

        if (Grounded)
        {
            Rigidbody.AddForce(-Rigidbody.velocity.x * Friction, 0, 0, ForceMode.VelocityChange);
        }
    }


    private void OnCollisionStay(Collision collision)
    {
        for (int i = 0; i < collision.contactCount; i++)
        {
            float angle = Vector3.Angle(collision.contacts[i].normal, Vector3.up);
            if (angle < 70)
            {
                PlayerAnimator.SetBool("Gruonded", true);
                Grounded = true;
            }
        }

    }
    private void OnCollisionExit(Collision collision)
    {
        PlayerAnimator.SetBool("Gruonded", false);
        Grounded = false;
    }
}
