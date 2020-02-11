using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] int damage = 1;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();
        Player player = collision.GetComponent<Player>();
        if(enemy != null)
        {
            enemy.TakeDamage(damage);
        }
        if(player != null && FindObjectOfType<PlayerMovement>().GetState() != PlayerMovement.State.dashing)
        {
            player.TakeDamage(damage);
        }

        Destroy(gameObject);
    }
}
