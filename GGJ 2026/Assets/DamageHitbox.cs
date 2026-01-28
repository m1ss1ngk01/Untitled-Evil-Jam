using System.Collections.Generic;
using UnityEngine;

public class DamageHitbox : MonoBehaviour
{
    private List<GameObject> others = new();

    public Player Player;

    public void Danage()
    {
        Debug.Log("Do Danage");
        foreach (GameObject other in others)
        {
            if (other != null)
            {
                // This is bad, but we don't care because it's a game jam!!
                DamageTaker damageTaker = other.GetComponent<DamageTaker>();
                if (damageTaker != null)
                {
                    damageTaker.DoDamage(Player);
                    break;
                }
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
