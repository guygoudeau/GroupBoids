using UnityEngine;
using System.Collections;

public class MonoAgent : MonoBehaviour
{
    public Agent agent;

    public GameObject monoAgent;


    // Use this for initialization
    void Start () {

        monoAgent.GetComponent<Seeking>().Sphere.transform.position = new Vector3(agent.Position.x, agent.Position.y, agent.Position.z);
        monoAgent.GetComponent<Seeking>().currentVelocity = new Vector3(agent.Velocity.x, agent.Velocity.y, agent.Velocity.z);
        monoAgent.GetComponent<Seeking>().Mass = agent.Mass;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
