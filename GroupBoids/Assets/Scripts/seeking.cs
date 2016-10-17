using UnityEngine;
using System.Collections;
using System;
using UnityEditor;

public class seeking : MonoBehaviour
{
    public GameObject Target;
    private Vector3 desiredVelocity;
    private Vector3 Displacement;
    private Vector3 Steering;
    public float SteeringMag = 0.1f;
    private Agent agent;
    public bool Behavior = true;

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

    void seek()
    {
        Displacement = Norm(Target.transform.position - gameObject.transform.position); //sets the Displacement from the Target's position to the Sphere's Position
        Steering = SteeringMag * Vector3.ClampMagnitude(Displacement - Utilities.AVec3toUVec3(agent.Velocity), 1.0f).normalized; //Uses the Displacement and the current velocity to create a steering vector
        agent.Velocity += Utilities.UVec3toAVec3(Steering / agent.Mass); // adds the steerign vector to the currentVelocity
    }

    void avoid()
    {
        Displacement = Norm(gameObject.transform.position - Target.transform.position); //sets the Displacement from the Target's position to the Sphere's Position
        Steering = SteeringMag * Vector3.ClampMagnitude(Displacement - Utilities.AVec3toUVec3(agent.Velocity), 1.0f).normalized; //Uses the Displacement and the current velocity to create a steering vector
        agent.Velocity += Utilities.UVec3toAVec3(Steering / agent.Mass); // adds the steerign vector to the currentVelocity
    }

    // Use this for initialization
    void Start()
    {
        agent = gameObject.GetComponent<MonoAgent>().agent;
        agent.Velocity = Utilities.UVec3toAVec3(Norm(gameObject.transform.position)); // sets strating velocity  
    }

    // Update is called once per frame
    void Update()
    {
        if (Behavior == true)
        {
            seek();
        }
        else
        {
            avoid();
        }
    }
}
