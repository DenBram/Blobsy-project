using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcicleBlastScript : MonoBehaviour
{
    public Transform firePoint;
    public GameObject iciclePrefab;

    private void Awake()
    {
        firePoint = GameObject.Find("/Player/IceFirePoint").transform;
        iciclePrefab = Resources.Load<GameObject>("Prefabs/atk_icicle");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            FireIcicle();
        }
    }

    void FireIcicle()
    {
        Instantiate(iciclePrefab, firePoint.position, firePoint.rotation);
    }
}
