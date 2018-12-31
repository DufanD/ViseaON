using UnityEngine;

public class GyroForMain : MonoBehaviour {

    public GameObject cameraCont;
    public Animator animator;
    Quaternion rot;

    void Start()
    {
        if (PlayerPrefs.GetInt("vrLevel") == 1)
        {
            animator.SetInteger("vrMode", 1);
            gameObject.GetComponent<GyroForMain>().enabled = false;
        } else
        {
            animator.SetInteger("vrMode", 2);
        }
    }

    void Update()
    {
        updateGyroCamera();
    }

    private void updateGyroCamera()
    {
        if (SystemInfo.supportsGyroscope)
        {
            Input.gyro.enabled = true;
            rot = new Quaternion(0, 0, 1, 0);
            gameObject.transform.localRotation = gyroCore(Input.gyro.attitude) * rot;
            cameraCont.transform.rotation = Quaternion.Euler(90f, 0f, 0f);
        }
    }

    private static Quaternion gyroCore(Quaternion q)
    {
        return new Quaternion(q.x, q.y, q.z, q.w);
    }
}
