using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int moveSpeed = 3;
    [SerializeField] int health = 3;
    [SerializeField] Color[] colors;

    private Player player;
    private GameSession gameSession;
    private SpriteRenderer sprite;

    
    void Start()
    {
        player = FindObjectOfType<Player>();
        gameSession = FindObjectOfType<GameSession>();

        int indexColor = Random.Range(0, colors.Length);
        GetComponent<SpriteRenderer>().color = colors[indexColor];

        
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
