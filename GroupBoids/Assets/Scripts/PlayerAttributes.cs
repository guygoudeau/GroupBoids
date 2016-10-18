using UnityEngine;
using System.Collections;

public class PlayerAttributes : MonoBehaviour {

    public int health;
	
	// Update is called once per frame
	void Update () {
        if (health <= 0)
        {
            ///Game Over code
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
