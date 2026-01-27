using UnityEngine;

public class PlayerDamager : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.TryGetComponent<Player>(out var player))
        {
            player.Damage(transform.position);
        }
    }
}
