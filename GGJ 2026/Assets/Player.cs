using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _walkspeed;
    [SerializeField] private float _runspeed;

    private Rigidbody2D _rigidbody;

    
    
    
    public void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector2 movementVector = new Vector2(horizontal, vertical);
        Vector2 normalizedMovementVector = Vector2.ClampMagnitude(movementVector, 1);
        Vector2 force = normalizedMovementVector * _walkspeed;
        if (Input.GetButton("Sprint"))
        {
            force = normalizedMovementVector * _runspeed;
        }
        _rigidbody.linearVelocity = force;
    }


    public void UpdateOld()
    {
        Vector2 movementVector = Vector2.zero;
        bool moving = false;
        
        if (Input.GetKey(KeyCode.W))
        {
            movementVector += new Vector2(0, 0.5f);
            moving = true;
        }

        if (Input.GetKey(KeyCode.S))
        {
            movementVector += new Vector2(0, -0.5f);
            moving = true;
        }

        if (Input.GetKey(KeyCode.D))
        {
            movementVector += new Vector2(0.5f, 0);
            moving = true;
        }

        if (Input.GetKey(KeyCode.A))
        {
            movementVector += new Vector2(-0.5f, 0);
            moving = true;
        }

        if (moving)
        {
            Vector2 normalizedMovementVector = movementVector.normalized;
            Vector2 force = normalizedMovementVector * _walkspeed;
            
            _rigidbody.AddForce(force);
        }
    }
}
