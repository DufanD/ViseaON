using UnityEngine;

public class VRAllow : MonoBehaviour {
    public bool statusAllow;

	// Use this for initialization
	void Start () {
        if (statusAllow) PlayerPrefs.SetInt("vrAllow", 1);
        else PlayerPrefs.SetInt("vrAllow", 0);
    }
}
