using UnityEngine;
using System.Collections;
using System.Security.Cryptography;

public class Spawner : MonoBehaviour
{
    public GameObject Target;
    public GameObject Boid;
    private Vector3 Spawn;
    private int amount = 90;
    public Vector3 targetPos;
	// Use this for initialization
	void Awake ()
    { 
        //this loop creates random starting positions for the boids
        for (int i = 0; i <= amount; ++i)
	    {
            if (i % 4 == 0)
            {
                int x = Random.Range(100, 1);
                int y = Random.Range(95, 100);
                int z = Random.Range(-100, -1);
                Spawn = new Vector3(x, y, z);
                GameObject temp = Instantiate(Boid, Spawn, Quaternion.identity) as GameObject;
                MonoAgent ma = temp.GetComponent<MonoAgent>();
                //ma.agent.Position = Utilities.UVec3toAVec3(Spawn);
            }
            else if (i % 3 == 0)
            {
                int x = Random.Range(-100, -1);
                int y = Random.Range(95, 100);
                int z = Random.Range(100, 1);
                Spawn = new Vector3(x, y, z);
                GameObject temp = Instantiate(Boid, Spawn, Quaternion.identity) as GameObject;
                MonoAgent ma = temp.GetComponent<MonoAgent>();
                //ma.agent.Position = Utilities.UVec3toAVec3(Spawn);
            }
            else if (i % 2 == 0)
            {
                int x = Random.Range(-100, -1);
                int y = Random.Range(95, 100);
                int z = Random.Range(-100, -1);
                Spawn = new Vector3(x, y, z);
                GameObject temp = Instantiate(Boid, Spawn, Quaternion.identity) as GameObject;
                MonoAgent ma = temp.GetComponent<MonoAgent>();
                //ma.agent.Position = Utilities.UVec3toAVec3(Spawn);
            }
            else
            {
                int x = Random.Range(1, 100); 
                int y = Random.Range(95, 100);
                int z = Random.Range(1, 100);
                Spawn = new Vector3(x, y, z);
                GameObject temp = Instantiate(Boid, Spawn, Quaternion.identity) as GameObject;
                MonoAgent ma = temp.GetComponent<MonoAgent>();
               // ma.agent.Position = Utilities.UVec3toAVec3(Spawn);
            }
            Boid.GetComponent<seeking>().Target = this.gameObject; //gives a reference of This GameObject
        }

	}
	
	// Update is called once per frame
	void Update ()
	{
        
	}
}
