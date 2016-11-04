using UnityEngine;
using System.Collections;

public class CameraFollowAbhishek : MonoBehaviour {


    public GameObject player;       //Public variable to store a reference to the player game object
    bool active;
    // The distance in the x-z plane to the target
    float distance = 6f;
    // the height we want the camera to be above the target
    float height = 3f;
    // How much we 
    float heightDamping = 2.0f;
    float rotationDamping = 3.0f;

    private Vector3 offset;        

    void Start()
    {
        //Calculate and store the offset value by getting the distance between the player's position and camera's position.
        offset = transform.position - player.transform.position;
    }

    void LateUpdate()
    {
            //SOURCE: http://answers.unity3d.com/questions/38526/smooth-follow-camera.html
            // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
            Transform target = player.transform;
            float wantedRotationAngle = target.eulerAngles.y;
            float wantedHeight = target.position.y + height;
            float currentRotationAngle = transform.eulerAngles.y;
            float currentHeight = transform.position.y;
            // Damp the rotation around the y-axis
            currentRotationAngle = Mathf.LerpAngle(currentRotationAngle, wantedRotationAngle, rotationDamping * Time.deltaTime);
            // Damp the height
            currentHeight = Mathf.Lerp(currentHeight, wantedHeight, heightDamping * Time.deltaTime);
            // Convert the angle into a rotation
            Quaternion currentRotation = Quaternion.Euler(0, currentRotationAngle, 0);
            // Set the position of the camera on the x-z plane to:
            // distance meters behind the target
            transform.position = target.position;
            transform.position -= currentRotation * Vector3.forward * distance;
            // Set the height of the camera
            transform.position = new Vector3(transform.position.x, currentHeight, transform.position.z);
            // Always look at the target
            transform.LookAt(target);
            active = true;
    }
}
