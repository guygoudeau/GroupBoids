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
	void Start ()
    { 
        for (int i = 0; i <= amount; ++i)
	    {
            if (i % 4 == 0)
            {
                int x = Random.Range(100, 1);
                int y = Random.Range(95, 100);
                int z = Random.Range(-100, -1);
                Spawn = new Vector3(x, y, z);
                Instantiate(Boid, Spawn, Quaternion.identity);
            }
            else if (i % 3 == 0)
            {
                int x = Random.Range(-100, -1);
                int y = Random.Range(95, 100);
                int z = Random.Range(100, 1);
                Spawn = new Vector3(x, y, z);
                Instantiate(Boid, Spawn, Quaternion.identity);
            }
            else if (i % 2 == 0)
            {
                int x = Random.Range(-100, -1);
                int y = Random.Range(95, 100);
                int z = Random.Range(-100, -1);
                Spawn = new Vector3(x, y, z);
                Instantiate(Boid, Spawn, Quaternion.identity);
            }
            else
            {
                int x = Random.Range(1, 100);
                int y = Random.Range(95, 100);
                int z = Random.Range(1, 100);

                Spawn = new Vector3(x, y, z);
                Instantiate(Boid, Spawn, Quaternion.identity);
            }
            Boid.GetComponent<Seeking>().Target = this.gameObject;
        }

	}
	
	// Update is called once per frame
	void Update ()
	{
        
	}
}
