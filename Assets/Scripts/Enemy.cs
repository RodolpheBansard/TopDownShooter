using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int moveSpeed = 3;
    [SerializeField] int health = 3;
    [SerializeField] Color[] colors;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform firePoint;
    [SerializeField] float bulletSpeed;
    [SerializeField] float fireRate;

    private Player player;
    private GameSession gameSession;
    private SpriteRenderer sprite;
    private bool contactWithPlayer = false;
    

    
    void Start()
    {
        player = FindObjectOfType<Player>();
        gameSession = FindObjectOfType<GameSession>();

        int indexColor = Random.Range(0, colors.Length);
        GetComponent<SpriteRenderer>().color = colors[indexColor];

        StartCoroutine(Shoot());
    }

    
    void Update()
    {
        if(player != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);
            Vector2 lookDir = player.transform.position - transform.position;
            float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
            transform.localEulerAngles = new Vector3(0, 0, angle);


            
        }
        

        if(health <= 0)
        {
            Destroy(gameObject);
            
            
        }
    }

    public void SetContactWithPlayer(bool var)
    {
        contactWithPlayer = var;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }

    IEnumerator Shoot()
    {
        while (true)
        {
            yield return new WaitForSeconds(fireRate);
            if(player == null)
            {
                break;
            }
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation) as GameObject;
            bullet.GetComponent<Rigidbody2D>().velocity = (player.transform.position - firePoint.position).normalized * bulletSpeed;
        }
        
    }

    private void OnDestroy()
    {
        if (contactWithPlayer)
        {
            player.TakeDamage(1);
        }
        gameSession.EnemyKilled();
    }
}
