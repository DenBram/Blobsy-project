using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoveSparkScript : MonoBehaviour
{
    public Transform firePoint;
    public float baseDamage = 90f;
    public GameObject impactEffect;
    public LineRenderer lineRenderer;

    // Start is called before the first frame update
    void Awake()
    {
        firePoint = GameObject.Find("/Player/IceFirePoint").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            StartCoroutine(LoveSpark());
        }
    }

    IEnumerator LoveSpark()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(firePoint.position, firePoint.right);

        if (hitInfo)
        {
            EnemyScript enemy =  hitInfo.transform.GetComponent<EnemyScript>();

            if (enemy != null)
            {
                enemy.TakeDamage(baseDamage);
            }

            lineRenderer.SetPosition(0, firePoint.position);
            lineRenderer.SetPosition(1, hitInfo.point);

            //Instantiate(impactEffect, hitInfo.point, Quaternion.identity);
        } else
        {
            lineRenderer.SetPosition(0, firePoint.position);
            lineRenderer.SetPosition(1, firePoint.position + firePoint.right *100);
        }

        lineRenderer.enabled = true;

        // wait some time
        yield return new WaitForSeconds(0.08f);

        lineRenderer.enabled = false;
    }
}
