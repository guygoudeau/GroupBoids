using UnityEngine;
using System.Collections;

public class MonoAgent : MonoBehaviour
{
    public Agent agent;

    // Use this for initialization
    void Start ()
    {

        Seeking compSeek = gameObject.GetComponent<Seeking>(); //Get Reference to Gameobject's Seeking Behavior

        //Recieves information from Agent Script
        compSeek.Sphere.transform.position = new Vector3(agent.Position.x, agent.Position.y, agent.Position.z);
        compSeek.currentVelocity = new Vector3(agent.Velocity.x, agent.Velocity.y, agent.Velocity.z);
        compSeek.Mass = agent.Mass;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
