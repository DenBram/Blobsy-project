using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteOverTimeScript : MonoBehaviour
{
    public int secondsToDestroy = 3;

    void Update()
    {
        Destroy(gameObject, secondsToDestroy);
    }
}
