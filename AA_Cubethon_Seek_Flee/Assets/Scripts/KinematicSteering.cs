using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KinematicSteering : MonoBehaviour
{
    //vars
    public Transform PlayerTarget;
    public float maxSpeed = 10;
    public bool IsSeeking = true;

    // Fixed update to make sure frames won't make objects move faster or slower
    void FixedUpdate()
    {
        SteeringOutput steering = GetSteering();
        transform.position += steering.linearVelocity * Time.deltaTime;
    }

    SteeringOutput GetSteering()
    {
        SteeringOutput result = new SteeringOutput();

        //Transform for where the player is going to be moving towards
        Vector3 orientationVelocity = PlayerTarget.position - transform.position;
        
        if (IsSeeking)
            result.linearVelocity = orientationVelocity;
        else
            result.linearVelocity = PlayerTarget.position + transform.position;
       
        //Normalizing to allow change of speed
        result.linearVelocity.Normalize();
        result.linearVelocity *= maxSpeed;

        //Orientation for where the player will be looking at
        result.angularVelocity = NewOrientation(orientationVelocity, transform.rotation.y);
        result.angularVelocity *= Mathf.Rad2Deg;
        
        //if it is seeking, the forward will be facing the target, if not it will be facing away
        if(IsSeeking)
            transform.eulerAngles = new Vector3(0, result.angularVelocity, 0);
        else
            transform.eulerAngles = new Vector3(0, result.angularVelocity + 180, 0);

        //returning result to let movement occur in 
        return result;
    }

    // Shows the new orientation that would make the object face it's target
    float NewOrientation (Vector3 velocity, float CurrentRotation)
    {
        if (velocity != Vector3.zero)
        
            return Mathf.Atan2(velocity.x, velocity.z);

        else
            return CurrentRotation;

    }
}
