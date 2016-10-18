using UnityEngine;
using System.Collections;

public class BossBehavior : MonoBehaviour {

    public GameObject Target;   //Target Transform
    public Vector3 TargetPos;
    public Vector3 cV;              //Current Velocity
    public float    sM = 0,         //Seeking Magnitude
                    avM = 0,        //Avoid Magnitude
                    mass = 0, speed = 0, radius = 0,
                    ArrStr = 0,     //Arrival Strength
                    aM = 0;         //Arrival Magnitude

	// Use this for initialization
	void Start () {
        cV = transform.position.normalized;
	}
	
	// Update is called once per frame
	void Update () {
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
        //transform.position = new Vector3(transform.position.x, 1, transform.position.x);

        TargetPos = Target.transform.position;
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
            Destroy(other.gameObject);
        else if (other.gameObject.name == "Wall")
            sM = 0;
    }

}
