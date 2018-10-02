using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if (UNITY_EDITOR)
using UnityEditor;
#endif

public class VRMode : MonoBehaviour {
    public bool vrMode;

	// Use this for initialization
	void Start () {
        //PlayerSettings.SetVirtualRealitySupported(BuildTargetGroup.Android, vrMode);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
