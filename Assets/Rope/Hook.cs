using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour
{
    public FixedJoint FixedJoint;
    public Rigidbody Rigidbody;

    public RopeGun RopeGun;

    private bool _connectedToRigitbody;

    private void Update()
    {
        if (_connectedToRigitbody)
        {
            if(FixedJoint.connectedBody == null)
            {
                RopeGun.DestroySpring();
            }
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (FixedJoint == null)
        {
            FixedJoint = gameObject.AddComponent<FixedJoint>();
            RopeGun.CreateSpring();
            if (collision.rigidbody)
            {
                FixedJoint.connectedBody = collision.rigidbody;
                _connectedToRigitbody = true;
            }
            
        }
    }

    public void StopFix()
    {
        if (FixedJoint)
        {
            _connectedToRigitbody = false;
            Destroy(FixedJoint);
        }
    }
}
