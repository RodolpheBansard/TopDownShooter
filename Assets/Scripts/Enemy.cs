using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int moveSpeed = 3;
    [SerializeField] int health = 3;

    private Player player;
    private GameSession gameSession;

    
    void Start()
    {
        player = FindObjectOfType<Player>();
        gameSession = FindObjectOfType<GameSession>();
    }

    
    void Update()
    {
        if(player != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);
        }
        

        if(health <= 0)
        {
            gameSession.EnemyKilled();
            Destroy(gameObject);
            
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }
}
