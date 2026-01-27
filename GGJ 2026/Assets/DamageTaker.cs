using UnityEngine;

public class DamageTaker : MonoBehaviour
{
    public float health;

    public void DoDamage()
    {
        health -= 1.0f;
    }

    public void Update()
    {
        if (health <= 0.0f)
        {
            EnemyMover.ZombiesKilled = EnemyMover.ZombiesKilled + 1;
            Destroy(gameObject);
            Debug.Log("Enemies Killed: " + EnemyMover.ZombiesKilled);
        }
    }
}
