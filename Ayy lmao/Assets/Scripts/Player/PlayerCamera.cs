using UnityEngine;
using System.Collections;

public class PlayerCamera : MonoBehaviour {

    public float speedH = 15.0f;
    public float speedV = 15.0f;

    public float yaw = 0.0f;
    public float pitch = 0.0f;
    public Camera playerCamera;
    // Use this for initialization

    void Start () {
	
	}
    
	// Update is called once per frame
	void Update () {

        yaw += speedH * Input.GetAxis("Mouse X");
        pitch -= speedV * Input.GetAxis("Mouse Y");

        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
    }
}
