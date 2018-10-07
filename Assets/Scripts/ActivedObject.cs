using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivedObject : MonoBehaviour {
    public GameObject activedObject;
    private static ActivedObject _instance;
        
    public static ActivedObject Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<ActivedObject>();
            }
            return _instance;
        }
        
    }

    public void setActivedObject(GameObject activedObject)
    {
        this.activedObject = activedObject;
    }

    public GameObject getActivedObject()
    {
        return activedObject;
    }

    public void Active()
    {
        activedObject.SetActive(true);
    }

    public void Deactive()
    {
        activedObject.SetActive(false);
    }
}
