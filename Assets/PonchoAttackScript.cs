using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PonchoAttackScript : MonoBehaviour
{
    public float baseDamage = 10f;

    private void Awake()
    {
    }

    void Start()
    {
        //var player = GameObject.FindGameObjectWithTag("Player");
        //Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Melee"))
        {
            StartCoroutine(DoPonchoAttack());
        }
    }

    IEnumerator DoPonchoAttack()
    {
        // activate collision detection
        GameObject PonchoHitCheckObject = GameObject.Find("/Player/PonchoHitCheck");
        PonchoHitCheckObject.GetComponent<BoxCollider2D>().enabled = true;
        PonchoHitCheckObject.GetComponent<SpriteRenderer>().enabled = true;
        yield return new WaitForSeconds(0.08f);
        PonchoHitCheckObject.GetComponent<SpriteRenderer>().enabled = false;
        PonchoHitCheckObject.GetComponent<BoxCollider2D>().enabled = false;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name);
        EnemyScript enemy = collision.GetComponent<EnemyScript>();

        if (enemy != null)
        {
            enemy.TakeDamage(baseDamage);
        }
        // Destroy(gameObject);
    }
}
