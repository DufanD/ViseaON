using UnityEngine;

public class VRWalk : MonoBehaviour {

    public Transform vrCamera;
    public float speed = 3.0f;
    public bool moveForward = true;

    private float vertical;
    private float horizontal;

    // Update is called once per frame
    void Update()
    {
        if (moveForward)
        {
            Vector3 forward = vrCamera.TransformDirection(Vector3.forward);

            Vector3 moving = vrCamera.TransformDirection(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")));
            //if (Mathf.Abs(vertical) > 0.01)
            //{
            //    //move in the direction of the camera
            //    transform.position = transform.position + forward * vertical * speed * Time.deltaTime;
            //}
            //if (Mathf.Abs(horizontal) > 0.01)
            //{
            //    //strafe sideways
            //    transform.position += new Vector3(horizontal * speed * Time.deltaTime, 0, 0);
            //}
            //transform.position = transform.position + forward * speed * Time.deltaTime;
            transform.position = transform.position + moving * speed * Time.deltaTime;
        }
    }
}
