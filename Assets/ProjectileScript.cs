using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    public float baseDamage = 30f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

   void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name);
        EnemyScript enemy = collision.GetComponent<EnemyScript>();

        if (enemy != null)
        {
            enemy.TakeDamage(baseDamage);
        }
        Destroy(gameObject);
    }
}
