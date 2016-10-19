using UnityEngine;
using UnityEngine.UI;

public class UIBoidCounter : MonoBehaviour {

    Spawner spawner;
    public Text counter;

	// Use this for initialization
	void Start ()
    {
        spawner = FindObjectOfType<Spawner>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        counter.text = "Boids: " + spawner.boidCounter.ToString();
    }
}
