using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    private float yVal;
    private float increment = 0.01f;
    //private Transform transform;

    // Start is called before the first frame update
    void Awake()
    {
        //transform = gameObject.GetComponent<SpriteRenderer>().transform;        
        yVal = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        //Transform transform = gameObject.GetComponent<SpriteRenderer>().transform;
        float newYPos = yVal + increment;
        yVal = newYPos;
        if (newYPos > 6 || newYPos < -6)
        {
            increment *= -1;
        }
        Vector3 newPosition = new Vector3(transform.position.x, newYPos, 0);
        transform.position = newPosition;
    }
}
