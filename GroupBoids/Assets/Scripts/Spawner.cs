using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Spawner : MonoBehaviour
{
    public GameObject Target;
    public GameObject Boid;
    private Vector3 Spawn;
    public List<Transform> spawnLocations;
    public float minSpawnDistance;
    public float waitTime;
    public int boidNumber;

    private int boidCounter = 0;

    private IEnumerator corutine;

	// Use this for initialization
	void Awake ()
    {
        corutine = WaitAndCreate(waitTime);
        StartCoroutine(corutine);
    }

    void Update()
    {
        if(boidCounter >= boidNumber)
        {
            StopCoroutine(corutine);
        }
    }

    void CreateAgent(int index)
    {
        GameObject a = (Instantiate(Boid, spawnLocations[index].position, Quaternion.identity) as GameObject);
        a.GetComponent<MonoAgent>().agent.Position = Utilities.UVec3toAVec3(spawnLocations[index].position);
        a.GetComponent<seeking>().Target = Target; //gives a reference of This GameObject
        boidCounter++;
    }

    int CheckDistance()
    {
        Transform playerTrans = GameObject.Find("Player").transform;    //Get Player
        int finalIndex;     //The final product
        while (true)
        {
            finalIndex = Random.Range(0, spawnLocations.Count);

            if((spawnLocations[finalIndex].position - playerTrans.position).magnitude > minSpawnDistance)
            {               
                break;
            }
        }
        return finalIndex;
    }

    private IEnumerator WaitAndCreate(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            int index = CheckDistance();
            CreateAgent(index);
        }     
    }
}
