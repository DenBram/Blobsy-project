using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoomCollisionScript : MonoBehaviour
{
    public float zoomSpeed = .1f;
    private float targetOrtho;
    public float smoothSpeed = 2.0f;
    public float minOrtho = 2.0f;
    public float maxOrtho = 4.0f;
    private bool zooming = false;

    private void Awake()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();

        /*GameObject mainCameraObject = GameObject.FindGameObjectWithTag("MainCamera");
        Camera mainCamera = mainCameraObject.GetComponent<Camera>();
        minOrtho = mainCamera.orthographicSize;*/

        minOrtho = Camera.main.orthographicSize;
    }

    void Update()
    {        
        if (zooming)
        {
            targetOrtho += zoomSpeed;
            targetOrtho = Mathf.Clamp(targetOrtho, minOrtho, maxOrtho);            

            Camera.main.orthographicSize = Mathf.MoveTowards(Camera.main.orthographicSize, targetOrtho, smoothSpeed * Time.deltaTime);

            if (Camera.main.orthographicSize >= maxOrtho)
            {
                zooming = false;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {            
            zooming = true;
        }
    }


}
