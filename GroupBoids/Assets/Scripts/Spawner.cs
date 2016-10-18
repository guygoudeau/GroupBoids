using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Spawner : MonoBehaviour
{
    public GameObject Target;
    public GameObject Boid;
    public GameObject boss;
    private Vector3 Spawn;
    public List<Transform> spawnLocations;
    public float minSpawnDistance;
    public float waitTime;
    public int boidNumber;

    public List<Texture> textures;

    private int boidCounter = 0;

    private IEnumerator corutine;
    private bool corRunning;

	// Use this for initialization
	void Awake ()
    {
        corutine = WaitAndCreate(waitTime);
        StartCoroutine(corutine);
        corRunning = true;
    }

    void Update()
    {
        boidCounter = CountBoids();
        if (boidCounter >= boidNumber && corRunning == true)
        {
            StopCoroutine(corutine);
            corRunning = false;
            if(FindObjectOfType<BossBehavior>() == null)
            {
                Instantiate(boss, Vector3.zero, Quaternion.identity);
            }
        }

        else if (corRunning == false && boidCounter < boidNumber)
        {
            StartCoroutine(corutine);
            corRunning = true;
        }
    }

    void CreateAgent(int index)
    {
        GameObject a = (Instantiate(Boid, spawnLocations[index].position, Quaternion.identity) as GameObject);
        a.GetComponent<MonoAgent>().agent.Position = Utilities.UVec3toAVec3(spawnLocations[index].position);
        a.GetComponent<seeking>().Target = Target; //gives a reference of This GameObject
        Utilities.SetTexture(a.GetComponent<MonoAgent>(), textures);
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

    int CountBoids()
    {
        int count = 0;
        foreach(MonoAgent ma in FindObjectsOfType<MonoAgent>())
        {
            count++;
        }
        return count;
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
