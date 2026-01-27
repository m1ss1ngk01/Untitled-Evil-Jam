using System.Collections.Generic;
using UnityEngine;

public class DamageHitbox : MonoBehaviour
{
    private List<GameObject> others = new();

    public void Danage()
    {
        Debug.Log("Do Danage");
        foreach (GameObject other in others)
        {
            // This is bad, but we don't care because it's a game jam!!
            if (other == null) continue;
            if (other.TryGetComponent(out DamageTaker damageTaker))
            {
                damageTaker.DoDamage();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        others.Add(collision.gameObject);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        others.Remove(collision.gameObject);

    }
}
