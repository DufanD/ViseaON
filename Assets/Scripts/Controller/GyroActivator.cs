using UnityEngine;

public class GyroActivator : MonoBehaviour {

    public GameObject cameraCont;
    Quaternion rot;

    void Start () {
        if (PlayerPrefs.GetInt("vrLevel") == 1)
        {
            gameObject.GetComponent<GyroActivator>().enabled = false;
        }
    }
	
	void Update () {
        updateGyroCamera();
	}

   private void updateGyroCamera(){
        if(SystemInfo.supportsGyroscope)
        {
            Input.gyro.enabled = true;
            rot = new Quaternion(0, 0, 1, 0);
            gameObject.transform.localRotation = gyroCore(Input.gyro.attitude) * rot;
            cameraCont.transform.rotation = Quaternion.Euler(90f, 0f, 0f);
        }
    }

    private static Quaternion gyroCore(Quaternion q){
        return new Quaternion(q.x, q.y, q.z, q.w);
    }
}
