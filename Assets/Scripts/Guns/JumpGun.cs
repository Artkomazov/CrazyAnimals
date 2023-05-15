using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpGun : MonoBehaviour
{
    public Rigidbody PlayerRigidbody;
    public Transform Spawn;
    public ChargeIcon ChargeIcon;
    public Gun Pistol;

    public float Speed;
    public float MaxCharge = 3f;

    private float _currentCharge;
    private bool _isCharget;

    private void Update()
    {
        if (_isCharget)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                PlayerRigidbody.AddForce(-Spawn.forward * Speed, ForceMode.VelocityChange);
                Pistol.Shot();
                _currentCharge = 0;
                _isCharget = false;
                ChargeIcon.StartCharge();
            }
        }
        else
        {
            _currentCharge += Time.unscaledDeltaTime;
            ChargeIcon.SetChargeValue(_currentCharge, MaxCharge);
            if (_currentCharge >= MaxCharge)
            {
                _isCharget = true;
                ChargeIcon.StopCharge();
            }
        }
    }
}
