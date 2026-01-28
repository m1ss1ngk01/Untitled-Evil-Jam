using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    public static int ZombiesKilled = 0;
    public static int ZombieCount = 0;


    public PlayerPosition guyIWantToKill;
    public float speed = 1.0f;
    private Rigidbody2D _rigidbody;

    public void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        ZombieCount += 1;
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
    }
}
