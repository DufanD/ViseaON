using System.Collections;
using UnityEngine;

public class DestroyObj : MonoBehaviour
{
    public GameObject objectToDestroy;

    void Start()
    {
        StartCoroutine(RemoveAfterSeconds(6, objectToDestroy));
    }

    IEnumerator RemoveAfterSeconds(int seconds, GameObject obj)
    {
        yield return new WaitForSeconds(seconds);
        obj.SetActive(false);
    }
}
 

