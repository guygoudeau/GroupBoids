using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerAttributes : MonoBehaviour
{ 
    AudioSource hitSource;
    public int health;
    public string gameOverScene;
    bool mesh = true;
    float resetTime = 20.0f;
    float currenttime;

    void Start()
    {
        hitSource = gameObject.GetComponent<AudioSource>();
    }
    void reset()
    {
        currenttime = resetTime;
        mesh = false;
    }
    // Update is called once per frame
    void Update()
    {

        if (currenttime <= 1.2)
        {
            mesh = true;
        }
        if (mesh == false)
        {
            currenttime -= 0.2f;
            int cTime = (int)currenttime;
            float i = (float)cTime;
            if (i % 2 == 0)
            {
                transform.parent.gameObject.GetComponent<MeshRenderer>().enabled = false;
            }
            else
            {
                transform.parent.gameObject.GetComponent<MeshRenderer>().enabled = true;
            }
        }

        if (health <= 0)
        {
            SceneManager.LoadScene(gameOverScene);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Boid(Clone)") //Collision
        {
            if (mesh == true)
            {
                hitSource.Play();
                health--;
                reset();
                Destroy(other.gameObject);
            }
        }
    }
}