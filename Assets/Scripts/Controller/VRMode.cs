using System.Collections;
using UnityEngine;
using UnityEngine.XR;

public class VRMode : MonoBehaviour {
    public bool vrMode;
    private readonly int vrLevel;

	// Use this for initialization
	void Start () {
        if (PlayerPrefs.GetInt("vrLevel") == 1)
        {
            vrMode = true;
        }

        if (PlayerPrefs.GetInt("vrAllow") == 1)
        {
            StartCoroutine(activatorVR());
        }
    }
	
    public IEnumerator activatorVR()
    {
        if (vrMode || PlayerPrefs.GetInt("vrLevel") == 1)
        {
            XRSettings.LoadDeviceByName("cardboard");
            vrMode = true;
        }
        else
        {
            XRSettings.LoadDeviceByName("none");
        }
        yield return null;
        XRSettings.enabled = vrMode;
    }

    public void forceVR()
    {
        PlayerPrefs.SetInt("vrLevel", 1);
    }

    public void forceNormal()
    {
        PlayerPrefs.SetInt("vrLevel", 0);
    }

    public void vrNotAllow()
    {
        PlayerPrefs.SetInt("vrAllow", 0);
    }
}
