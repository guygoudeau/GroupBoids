using UnityEngine;
using System.Collections;
using System;
using UnityEditor;

public class Seeking : MonoBehaviour
{
    public GameObject Sphere;
    public GameObject Target;
    public Vector3 currentVelocity;
    private Vector3 desiredVelocity;
    private Vector3 Displacement;
    private Vector3 Steering;
    public float SteeringMag = 1.0f;
    public float Mass = 10;


    public Vector3 Norm(Vector3 x) //Fuction to normalize a Vector.
    {
        //Pthagorean theorum for a Vector 3
        // x^2 + y^2 +z^2 = d^2 
        float e = (x.x * x.x + x.y * x.y + x.z * x.z);
        float d = UnityEngine.Mathf.Sqrt(e);
        //d is what all coordinates should be divided by to normalize the vector.

        //Actual normalization
        float q = x.x / d;
        float w = x.y / d;
        float t = x.z / d;
        Vector3 c = new Vector3(q, w, t);
        return c; //Return the normalized vector
    }

    // Use this for initialization
    void Start ()
    {
        currentVelocity = Norm(Sphere.transform.position); // sets strating velocity  
    }

    // Update is called once per frame
    void Update ()
	{
	    Displacement = Target.transform.position - Sphere.transform.position; //sets the Displacement from the Target's position to the Sphere's Position
	    Steering = Vector3.ClampMagnitude((Displacement - currentVelocity),1.0f) / Mass; //Uses the Displacement and the current velocity to create a steering vector
	    currentVelocity += Steering; // adds the steerign vector to the currentVelocity
        Sphere.transform.position = Sphere.transform.position + currentVelocity; // changes the position of the shere based on the current velocity.

	}
}
