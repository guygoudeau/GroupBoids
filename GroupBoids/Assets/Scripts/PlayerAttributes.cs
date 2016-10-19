using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerAttributes : MonoBehaviour {

    public int health;
    public string gameOverScene;
	
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
            health--;
            Destroy(other.gameObject);         
        }
    }
}
