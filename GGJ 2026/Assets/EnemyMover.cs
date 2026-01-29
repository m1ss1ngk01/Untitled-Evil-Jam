using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    public static int ZombiesKilled = 0;
    public static int ZombieCount = 0;


    public PlayerPosition guyIWantToKill;
    public float speed = 1.0f;
    private Rigidbody2D _rigidbody;
    private Animator _animator;

    public void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        ZombieCount += 1;
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        var myPosition = transform.position;
        var targetPosition = guyIWantToKill.position;
        var distance = targetPosition - myPosition;
        var direction = distance.normalized;

        //transform.position += direction * speed * Time.deltaTime;
        Vector2 velocity = direction * speed;
        _rigidbody.linearVelocity = velocity;

        if (_rigidbody.linearVelocity.y > 0.1 && Mathf.Abs(_rigidbody.linearVelocity.y) > Mathf.Abs(_rigidbody.linearVelocity.x)) _animator.SetInteger("Animation", 0);
        else if (_rigidbody.linearVelocity.y < -0.1 && Mathf.Abs(_rigidbody.linearVelocity.y) > Mathf.Abs(_rigidbody.linearVelocity.x)) _animator.SetInteger("Animation", 1);
        else if (_rigidbody.linearVelocity.x > 0.1) _animator.SetInteger("Animation", 3);
        else if (_rigidbody.linearVelocity.x < -0.1) _animator.SetInteger("Animation", 1);


        _animator.SetFloat("X Velocity", _rigidbody.linearVelocity.x);
        _animator.SetFloat("Y Velocity", _rigidbody.linearVelocity.y);
    }
}
