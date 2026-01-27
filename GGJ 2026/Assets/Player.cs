using System;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public float health = 10.0f;
    public UnityEvent<float, float> OnHealthChange;
    public UnityEvent OnPlayerDeath;
    [SerializeField] private float _walkspeed;
    [SerializeField] private float _runspeed;

    private Rigidbody2D _rigidbody;
    public PlayerPosition myPlayerPosition;
    public float damageBounceBack;

    
    
    
    public void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        //Bro I hate this stupid Game Jam :man_standing: <--- Yes ik there's no emojis
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
        _rigidbody.linearVelocity = Vector2.Lerp(_rigidbody.linearVelocity, force, 0.9f * Time.deltaTime);
        myPlayerPosition.position = transform.position;
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

    public void Damage(Vector3 source)
    {
        var velocity = _rigidbody.linearVelocity;
        Vector2 angle = (source - transform.position).normalized;
        _rigidbody.linearVelocity = velocity - angle * damageBounceBack;

        health -= 1.0f;
        OnHealthChange.Invoke(health + 1.0f, health);
        if (health <= 0.0f)
        {
            Destroy(gameObject);
            OnPlayerDeath.Invoke();
            // show game over scene :(
        }
    }
}
