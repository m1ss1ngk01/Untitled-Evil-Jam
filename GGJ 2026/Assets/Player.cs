using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region [ Unserialised Fields ]
    [SerializeField] private float _forceMultiplied;
    #endregion
    
    #region [ Unserialised Fields ]
    private Rigidbody2D _rigidbody;
    #endregion
    
    
    
    public void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }


    public void Update()
    {
        Vector2 movementVector = Vector2.zero;
        bool moving = false;
        
        if (Input.GetKey(KeyCode.W))
        {
            movementVector += new Vector2(0, 1);
            moving = true;
        }

        if (Input.GetKey(KeyCode.S))
        {
            movementVector += new Vector2(0, -1);
            moving = true;
        }

        if (Input.GetKey(KeyCode.D))
        {
            movementVector += new Vector2(1, 0);
            moving = true;
        }

        if (Input.GetKey(KeyCode.A))
        {
            movementVector += new Vector2(-1, 0);
            moving = true;
        }

        if (moving)
        {
            Vector2 normalizedMovementVector = movementVector.normalized;
            Vector2 force = normalizedMovementVector * _forceMultiplied;
            
            _rigidbody.AddForce(force);
        }
    }
}
