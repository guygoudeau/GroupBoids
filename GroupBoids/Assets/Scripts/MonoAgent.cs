using UnityEngine;
using System.Collections;

public class MonoAgent : MonoBehaviour
{
    public Agent agent;

    public MonoAgent(float m_mass,Vector3 m_Vel, Vector3 m_Pos)
    {
        agent.Mass = m_mass;
        agent.Position = new Agent.Vector3(m_Pos.x, m_Pos.y, m_Pos.z);
        agent.Velocity = new Agent.Vector3(m_Vel.x, m_Vel.y, m_Vel.z);
    }

    void Awake()
    {
        agent = new Agent();
    }

	// Update is called once per frame
	void LateUpdate () {
	
        agent.UpdateVelocity();
        transform.forward = Utilities.AVec3toUVec3(agent.Velocity);
	    transform.position = new Vector3(agent.Position.x, transform.position.y, agent.Position.z);

	}
}
