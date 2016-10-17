using UnityEngine;
using System.Collections;
using System;

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
   

    public Vector3 Norm(Vector3 x)
    {
        float e = (x.x * x.x + x.y * x.y + x.z * x.z);
        float d = Mathf.Sqrt(e);
        float q = x.x / d;
        float w = x.y / d;
        float t = x.z / d;
        Vector3 c = new Vector3(q, w, t);
        return c;
    }

    // Use this for initialization
    void Start ()
    {
        currentVelocity = Norm(Sphere.transform.position);      
    }

    // Update is called once per frame
    void Update ()
	{
	    Displacement = Target.transform.position - Sphere.transform.position;
	    Steering = Vector3.ClampMagnitude((Displacement - currentVelocity),1.0f) / Mass;
	    currentVelocity += Steering;
        Sphere.transform.position = Sphere.transform.position + currentVelocity;

	}
}
