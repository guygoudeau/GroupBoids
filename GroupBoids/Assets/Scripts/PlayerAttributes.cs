using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerAttributes : MonoBehaviour {

    public int health;
    public string gameOverScene;
    public Slider healthSlider;
	
	// Update is called once per frame
	void Update () {

        healthSlider.value = health;

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
