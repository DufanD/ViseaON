using UnityEngine;

public class VRWalk : MonoBehaviour {

    public Transform vrCamera;
    public float speed = 3.0f;
    public bool moveForward = true;

    // Update is called once per frame
    void Update()
    {
        if (moveForward)
        {
            Vector3 forward = vrCamera.TransformDirection(Vector3.forward);

            Vector3 moving = vrCamera.TransformDirection(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")));
            
            transform.position = transform.position + moving * speed * Time.deltaTime;
        }
    }
}
