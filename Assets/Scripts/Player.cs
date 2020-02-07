using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] int health = 1;

    private void Update()
    {
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<Enemy>() != null)
        {
            if(gameObject.GetComponentInChildren<PlayerMovement>().GetState() != PlayerMovement.State.dashing)
            {
                health--;
            }            
            Destroy(collision.gameObject);
            FindObjectOfType<GameSession>().EnemyKilled();
        }
    }


}
