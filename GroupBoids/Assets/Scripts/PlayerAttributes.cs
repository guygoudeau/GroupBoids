using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerAttributes : MonoBehaviour {

    AudioSource hitSource;
    public int health;
    public string gameOverScene;
    public Slider healthSlider;
	
    void Start()
    {
        hitSource = gameObject.GetComponent<AudioSource>();
    }

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
            hitSource.Play();
            health--;           
            Destroy(other.gameObject);         
        }
    }
}
