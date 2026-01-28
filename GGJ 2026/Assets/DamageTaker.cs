using UnityEngine;
using UnityEngine.Events;

public class DamageTaker : MonoBehaviour
{
    public float health;

    public void DoDamage(Player Player)
    {
        health -= 1.0f;
        if (health <= 0.0f)
        {
            //Player.ZombiesKilled += 1;
            Player.AddScore(1);
            //EnemyMover.ZombiesKilled = EnemyMover.ZombiesKilled + 1;
        }
    }

    public void Update()
    {
        if (health <= 0.0f)
        {
            Destroy(gameObject);
        }
    }
}
