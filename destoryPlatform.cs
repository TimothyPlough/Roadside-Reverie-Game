using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destoryPlatform : MonoBehaviour
{
    private float secondsToDestroy = 50f;
    void Start()
    {
        StartCoroutine(DestroySelf());
    }

    IEnumerator DestroySelf()
    {
        yield return new WaitForSeconds(secondsToDestroy);
        Destroy(gameObject);
    }
}
