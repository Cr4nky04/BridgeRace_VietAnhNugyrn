using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private FixedJoystick _joystick;
    [SerializeField] private Animator _animator;

    [SerializeField] private float _movespeed;
    // Start is called before the first frame update
    private void Update()
    {
        _rigidbody.velocity = new Vector3(_joystick.Horizontal*_movespeed, 
                                          _rigidbody.velocity.y,
                                          _joystick.Vertical*_movespeed);
        if(_joystick.Horizontal!=0 || _joystick.Vertical!=0)
        {
            _rigidbody.rotation = Quaternion.LookRotation(_rigidbody.velocity);
        }
    }
}
