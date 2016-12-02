using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour {

    //replace these with waypoints from the real scene
    public GameObject[] waypoints;
    float speed = 0.10f;//distance covered per time interval essentially
    float rotation = 10f;//degrees per time interval essentially
    Transform target;
    int current = 1;

	// Use this for initialization
	void Start () {
        //target = waypoints[current].transform;
    }
	
	// Update is called once per frame
	void Update () {
        //updateNextPos();
        //transform.LookAt(target);
        // transform.position = Vector3.MoveTowards(this.transform.position, target.position, speed);
        //transform.Rotate(rotation * Vector3.up * Time.deltaTime, Space.World);
    }
    void updateNextPos()
    {
        if (Vector3.Distance(transform.position, target.position) < 1)
        {
            current = (current + 1) % waypoints.Length;
            target = waypoints[current].transform;
        }
    }
}