using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideOverTimeController : MonoBehaviour
{
    public float secondsToHide = 0.2f;

    private void OnBecameVisible()
    {
        StartCoroutine("disableSpriteRenderer", secondsToHide);
    }

    private IEnumerator disableSpriteRenderer(float _time)
    {
        yield return new WaitForSeconds(_time);
        GetComponent<SpriteRenderer>().enabled = false;
    }    
}
