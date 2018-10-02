using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObj : MonoBehaviour
{
    public GameObject gameObject;

    void Start()
    {
        StartCoroutine(RemoveAfterSeconds(6, gameObject));
    }
    IEnumerator RemoveAfterSeconds(int seconds, GameObject obj)
    {
        yield return new WaitForSeconds(6);
        obj.SetActive(false);
    }

}
 

