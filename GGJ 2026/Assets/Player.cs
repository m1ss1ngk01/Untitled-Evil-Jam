using System;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    //IDK ig a bunch of Unity Events???
    public float health = 10.0f;
    public int ZombiesKilled = 0;

    public UnityEvent<float, float> OnHealthChange;
    public UnityEvent OnPlayerDeath; //What happens when u die
    public UnityEvent OnGameBeat; //literally useless rn bro.. 
    [SerializeField] private float _walkspeed;
    [SerializeField] private float _runspeed;

    [SerializeField] private float _requiredScore;

    private Rigidbody2D _rigidbody;
    private Animator _animator;
    public PlayerPosition myPlayerPosition;
    public float damageBounceBack;

    
    
    
    public void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        //Bro I hate this stupid Game Jam :man_standing: <--- Yes ik there's no emojis
    }

    public void Update()
    {
        //I don't actually know what this is but ig it's also movement :/
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector2 movementVector = new Vector2(horizontal, vertical);
        Vector2 normalizedMovementVector = Vector2.ClampMagnitude(movementVector, 1);
        Vector2 force = normalizedMovementVector * _walkspeed;

        if (Input.GetButton("Sprint"))
        {
            force = normalizedMovementVector * _runspeed;
        }

        //_rigidbody.AddForce(force);
        _rigidbody.linearVelocity = Vector2.Lerp(_rigidbody.linearVelocity, force, 0.9f * Time.deltaTime);
        myPlayerPosition.position = transform.position;



        if (_rigidbody.linearVelocity.y > 0.1 && Mathf.Abs(_rigidbody.linearVelocity.y) > Mathf.Abs(_rigidbody.linearVelocity.x)) _animator.SetInteger("AnimationIndex", 1);
        else if (_rigidbody.linearVelocity.y < -0.1 && Mathf.Abs(_rigidbody.linearVelocity.y) > Mathf.Abs(_rigidbody.linearVelocity.x)) _animator.SetInteger("AnimationIndex", 3);
        else if (_rigidbody.linearVelocity.x > 0.1) _animator.SetInteger("AnimationIndex", 2);
        else if (_rigidbody.linearVelocity.x < -0.1) _animator.SetInteger("AnimationIndex", 0);
        else _animator.SetInteger("AnimationIndex", 4);






        _animator.SetFloat("X Velocity", _rigidbody.linearVelocity.x);
        _animator.SetFloat("Y Velocity", _rigidbody.linearVelocity.y);
    }


    public void UpdateOld()
    {
        //movement
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
        if (health <= 0.0f && ZombiesKilled < _requiredScore)
        {
            OnPlayerDeath.Invoke();
            Destroy(gameObject);
            // show game over scene :(
            //Counter is split between Damage takers and Enemy Mover :/ 
            //Don't remember reason why ^
        }
    }

    public void AddScore(int score)
    {
        ZombiesKilled += score;
        Debug.Log("Enemies Killed: " + ZombiesKilled + " out of: " + EnemyMover.ZombieCount);
        if (ZombiesKilled == 20)
        {
            OnGameBeat.Invoke();
        }
    }
}
