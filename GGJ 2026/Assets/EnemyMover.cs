using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    public PlayerPosition guyIWantToKill;
    public float speed = 1.0f;
    public static int ZombiesKilled = 0;
    
    // Update is called once per frame
    void Update()
    {
        var myPosition = transform.position;
        var targetPosition = guyIWantToKill.position;
        var distance = targetPosition - myPosition;
        var angle = distance.normalized;
        transform.position += angle * Time.deltaTime * speed;
    }
}
