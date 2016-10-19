using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerAttributes : MonoBehaviour {

    AudioSource hitSource;
    public int health;
    public string gameOverScene;
	
    void Start()
    {
        hitSource = gameObject.GetComponent<AudioSource>();
    }

	// Update is called once per frame
	void Update () {
        if (health <= 0)
        {
            SceneManager.LoadScene(gameOverScene);
        }
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Boid(Clone)") //Collision
        {
            hitSource.Play();
            health--;           
            Destroy(other.gameObject);         
        }
    }
}
