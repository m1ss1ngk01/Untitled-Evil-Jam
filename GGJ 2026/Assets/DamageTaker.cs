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
            Destroy(gameObject);
        }
    }
}
