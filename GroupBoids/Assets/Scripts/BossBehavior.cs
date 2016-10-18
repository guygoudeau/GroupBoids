using UnityEngine;
using System.Collections.Generic;

public class BossBehavior : MonoBehaviour {

    public int Health = 10;
    public List<GameObject> Boids;
    public GameObject Target;   //Target Transform
    public Vector3 TargetPos;
    public Vector3 cV;              //Current Velocity
    public float    sM = 0,         //Seeking Magnitude
                    avM = 0,        //Avoid Magnitude
                    mass = 0, speed = 0, radius = 0,
                    ArrStr = 0,     //Arrival Strength
                    aM = 0;         //Arrival Magnitude

    public float    currentTime = 0,
                    previousTime = 0,
                    deltaTime = 0,
                    Timer = 0;

	// Use this for initialization
	void Start () {
        cV = transform.position.normalized;
	}
	
	// Update is called once per frame
	void Update () {
        Boids.Clear();
        Boids = UpdateBoidsList();

        currentTime = Time.time;
        deltaTime = currentTime - previousTime;
        if(deltaTime >= Timer)
        {
        ShootBoid:
            int i = Random.Range(0, 9);
            if(Boids[i].GetComponent<seeking>().Target != Target)

        }

        Vector3 dV = Target.transform.position - transform.position;                 //Desired Vector
        Vector3 seeking = (dV.normalized - cV.normalized) * sM;
        Vector3 avoid = (transform.position - Target.transform.position) * avM;
        if (dV.magnitude <= radius)
            ArrStr = dV.magnitude / radius;
        else
            ArrStr = 0;
        Vector3 arrival = (transform.position - Target.transform.position) * ArrStr;
        Vector3 steering = seeking + avoid + arrival;
        if (cV.magnitude > 5)
            cV = cV.normalized;
        cV += steering;
        transform.position = transform.position + (cV / mass) * speed;
        transform.forward = cV;

        TargetPos = Target.transform.position;
	}

    List<GameObject> UpdateBoidsList()
    {
        List<GameObject> Update = new List<GameObject>();
        foreach (GameObject gO in Resources.FindObjectsOfTypeAll(typeof(GameObject)))
            if (gO.name == "Boid(Clone)")
                Update.Add(gO);
        return Update;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Boid(Clone)")
            if (other.gameObject.GetComponent<seeking>().Behavior == false)
            {
                Health--;
                Destroy(other.gameObject);
                Debug.Log("Boss Hit");
            }

        else if (other.gameObject.name == "Wall")
        {
            cV = new Vector3(0, 0, 0);
            sM = 0;
        }

        else if (other.gameObject.name == "Player")
        {
                Destroy(other.gameObject);
        }
    }

    void OnTriggerExit()
    {
        cV = transform.position.normalized;
        sM = 1;
    }

}
