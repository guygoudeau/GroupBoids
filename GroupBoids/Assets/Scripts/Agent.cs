using System;
public class Agent
{//creates a public Agent to be used outside of unity.

    public struct Vector3 //Data structure to represent a Vector 3 for vector direction or position.
    {
        public float x, y, z;
        public Vector3(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
    }
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
    public Vector3 Position = new Vector3(0,0,0); //starting position for the agent
    public Vector3 Velocity = new Vector3(0,0,1); //starting velocity for the agent
    public float Mass = 10.0f; //starting mass for the agent
}
