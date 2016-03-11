using System;
using System.Collections.Generic;
using UnityEngine
    ;
[Serializable]
public class AxleInfo
{
    public WheelCollider leftWheel;
    public WheelCollider rightWheel;
    public bool motor; 
    public bool steering;
}

public class CarController : MonoBehaviour {

    public List<AxleInfo> axleInfos; // the information about each individual axle
    public float maxMotorTorque; 
    public float maxSteeringAngle; 

    // Finds the corresponding visual wheel & correctly applies the transform
    public void ApplyLocalPositionToVisuals(WheelCollider collider)
    {
        if(collider.transform.childCount == 0)
        {
            return;
        }
        Transform visualWheel = collider.transform.GetChild(0);

        Vector3 position;
        Quaternion rotation;
        collider.GetWorldPose(out position, out rotation);

        visualWheel.transform.position = position;
        visualWheel.transform.rotation = rotation;

    }

    // FixedUpdate is not tied to framerate
    public void FixedUpdate()
        {
            float motor = maxMotorTorque /** Input.GetAxis("Vertical")*/;
            float steering = maxSteeringAngle * 0 /** Input.GetAxis("Horizontal")*/;
                
            foreach (AxleInfo axleInfo in axleInfos) {
                if (axleInfo.steering) {
                    axleInfo.leftWheel.steerAngle = steering;
                    axleInfo.rightWheel.steerAngle = steering;
                }
                if (axleInfo.motor) {
                    axleInfo.leftWheel.motorTorque = motor;
                    axleInfo.rightWheel.motorTorque = motor;
                }
            }
        }

        
	}


