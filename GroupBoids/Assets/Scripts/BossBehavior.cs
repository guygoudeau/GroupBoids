using UnityEngine;
using System.Collections.Generic;

public class BossBehavior : MonoBehaviour {

    public int Health = 10;
    public List<GameObject> Boids;
    public GameObject Target;   //Target Transform
    public Vector3 cV;              //Current Velocity
    public float    sM = 0,         //Seeking Magnitude
                    avM = 0,        //Avoid Magnitude
                    mass = 0, speed = 0, radius = 0,
                    ArrStr = 0,     //Arrival Strength
                    aM = 0;         //Arrival Magnitude

    public float           currentTime = 0,
                    previousTime = 0,
                    previousTime2 = 0,
                    deltaTime = 0,
                    deltaTime2 = 0;

    public float    Timer = 0;

    AudioSource hitSource;

	// Use this for initialization
	void Start () {
        hitSource = gameObject.GetComponent<AudioSource>();
        cV = transform.position.normalized;
        Boids = UpdateBoidsList();
        foreach (GameObject boid in Boids)
        {
            boid.GetComponent<seeking>().Target = this.gameObject;
            boid.GetComponent<seeking>().PreviousTarget = Target;
        }
        FindObjectOfType<Spawner>().Target = this.gameObject;
    }
	
	// Update is called once per frame
	void Update () {
        Boids.Clear();
        Boids = UpdateBoidsList();

        currentTime = Time.time;
        deltaTime = currentTime - previousTime;

        if (deltaTime >= Boids.Count)
        {
            if (Target.GetComponentInChildren<PlayerAttributes>().health > 0)
            {
                if (Boids.Count != 0)
                {
                    int i = Random.Range(0, Boids.Count - 1);
                    if (Boids[i].GetComponent<seeking>().Target != Target)
                    {
                        Boids[i].GetComponent<seeking>().Target = Target;
                        Boids[i].GetComponent<seeking>().PreviousTarget = this.gameObject;
                    }
                }
            }
            deltaTime = 0;
            previousTime = currentTime;
        }

        deltaTime2 = currentTime - previousTime2;

        if (deltaTime2 >= Timer)
        {
            if (Boids.Count != 0)
            {
                foreach(GameObject boid in Boids)
                {
                    if(boid.GetComponent<seeking>().Target == Target)
                    {
                        boid.GetComponent<seeking>().Target = this.gameObject;
                        break;
                    }
                }
            }
            deltaTime2 = 0;
            previousTime2 = currentTime;
        }

        Vector3 dV = Target.transform.position - transform.position;                 //Desired Vector

        Vector3 seeking = (dV.normalized - cV.normalized) * sM;

        Vector3 avoid = (transform.position - Target.transform.position) * avM;

        if (dV.magnitude <= radius)
        {
            ArrStr = dV.magnitude / radius;
        }
        else
        {
            ArrStr = 0;
        }

        Vector3 arrival = (transform.position - Target.transform.position) * ArrStr;

        Vector3 steering = seeking + avoid + arrival;

        if (cV.magnitude > 5)
        {
            cV = cV.normalized;
        }

        cV += steering;

        transform.position = new Vector3(transform.position.x,1,transform.position.z) + (cV / mass) * (speed / (Boids.Count + 1));

        transform.rotation = new Quaternion(0, transform.rotation.y, 0, transform.rotation.w);
	}

    List<GameObject> UpdateBoidsList()
    {
        List<GameObject> Update = new List<GameObject>();
        foreach (GameObject gO in Resources.FindObjectsOfTypeAll(typeof(GameObject)))
        {
            if (gO.name == "Boid(Clone)")
            {
                Update.Add(gO);
            }
        }
        return Update;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Boid(Clone)")
        {
            if (other.gameObject.GetComponent<seeking>().Target.name == "Player")
            {
                if (other.gameObject.GetComponent<seeking>().PreviousTarget.name == "Boss(Clone)")
                {
                    if(other.gameObject.GetComponent<seeking>().Behavior == false)
                    {
                        Health--;
                        hitSource.Play();
                        Destroy(other.gameObject);
                    }
                    
                }
            }
        }
        else if (other.gameObject.name == "Wall")
        {
            cV = new Vector3(0, 0, 0);
            sM = 0;
        }

        else if (other.gameObject.name == "PlayerModel")
        {
            other.gameObject.GetComponent<PlayerAttributes>().health = 0;
        }
    }

    void OnTriggerExit()
    {
        cV = transform.position.normalized;
        sM = 1;
    }

}
