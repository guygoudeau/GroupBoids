using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Spawner : MonoBehaviour
{
    public GameObject Target;               //The target that will be set for the boid
    public GameObject Boid;                 //Boid Prefab
    public GameObject boss;                 //Boss Prefab
    public List<Transform> spawnLocations;  //All possible locations the boid can spawn
    public float minSpawnDistance;          //Minimum distance the boid can spawn from the player
    public float waitTime;                  //How long to wait for till we spawn next boid
    public int boidNumber;                  //How many boids can be in the scene

    public List<Texture> textures;          //Textures to put on the boids

    public int boidCounter = 0;             //how many Boids in the scene

    private IEnumerator corutine;           //Corutine to spawn in the Agents
    private bool corRunning;                //Is the Corutine running?

    public bool survival;                   //Is this the survival level?

	// Use this for initialization
	void Awake ()
    {
        corutine = WaitAndCreate(waitTime); 
        StartCoroutine(corutine);   //Start Corutine
        corRunning = true;          //Say that the Corutine is running
    }

    void Update()
    {
        boidCounter = CountBoids();     //Update how many boids there are in the scene
        //If it is Story, Run this
        if (survival == false)
        {
            if (boidCounter >= boidNumber && corRunning == true)
            {
                StopCoroutine(corutine);
                corRunning = false;
                if (FindObjectOfType<BossBehavior>() == null)
                {
                    Instantiate(boss, Vector3.zero, Quaternion.identity);
                    FindObjectOfType<BossBehavior>().Target = Target;
                }
            }

            else if (corRunning == false && boidCounter < boidNumber)
            {
                StartCoroutine(corutine);
                corRunning = true;
            }
        }
        
        //Else, never stop boid Spawning      
    }

    void CreateAgent(int index) //Creates an agent and sets certain values
    {
        GameObject a = Instantiate(Boid, spawnLocations[index].position, Quaternion.identity) as GameObject;
        a.GetComponent<MonoAgent>().agent.Position = Utilities.UVec3toAVec3(spawnLocations[index].position);
        a.GetComponent<seeking>().Target = Target; 
        Utilities.SetTexture(a.GetComponent<MonoAgent>(), textures);
    }

    int CheckDistance()     //Gets a spawn index that is a certain distance away from the player
    {
        Transform playerTrans = GameObject.Find("Player").transform;    //Get Player
        int finalIndex;     //The final product
        while (true)
        {
            finalIndex = Random.Range(0, spawnLocations.Count); //Get a number to test for spawning

            //if passes the conditional, break out of loop
            if((spawnLocations[finalIndex].position - playerTrans.position).magnitude > minSpawnDistance)
            {               
                break;
            }
        }
        return finalIndex;
    }

    int CountBoids()    //Gets number of boids in the scene
    {
        int count = 0;
        foreach(MonoAgent ma in FindObjectsOfType<MonoAgent>())
        {
            count++;
        }
        return count;
    }

    private IEnumerator WaitAndCreate(float waitTime)   //Corutine that handles creating the Agents
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            int index = CheckDistance();
            CreateAgent(index);
        }     
    }
}
