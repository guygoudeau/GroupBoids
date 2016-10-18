using UnityEngine;
using System.Collections;
using System.Security.Cryptography;

public class Spawner : MonoBehaviour
{
    public GameObject Target;
    public GameObject Boid;
    private Vector3 Spawn;
    public int amount = 10;
    public Vector3 targetPos;
	// Use this for initialization
	void Awake ()
    { 
        //this loop creates random starting positions for the boids
        for (int i = 0; i <= amount; ++i)
	    {
            GameObject temp;
            if (i % 4 == 0)
            {
                float x = Random.Range(100, 1);
                float y = transform.position.y;
                float z = Random.Range(-100, -1);
                Spawn = new Vector3(x, y, z);
                temp = Instantiate(Boid, Spawn, Quaternion.identity) as GameObject;             
            }
            else if (i % 3 == 0)
            {
                float x = Random.Range(-100, -1);
                float y = transform.position.y;
                float z = Random.Range(100, 1);
                Spawn = new Vector3(x, y, z);
                temp = Instantiate(Boid, Spawn, Quaternion.identity) as GameObject;            
            }
            else if (i % 2 == 0)
            {
                float x = Random.Range(-100, -1);
                float y = transform.position.y;
                float z = Random.Range(-100, -1);
                Spawn = new Vector3(x, y, z);
                temp = Instantiate(Boid, Spawn, Quaternion.identity) as GameObject;
            }
            else
            {
                float x = Random.Range(1, 100);
                float y = transform.position.y;
                float z = Random.Range(1, 100);
                Spawn = new Vector3(x, y, z);
                temp = Instantiate(Boid, Spawn, Quaternion.identity) as GameObject;          
            }
            Boid.GetComponent<seeking>().Target = this.gameObject; //gives a reference of This GameObject
        }

	}
}
