using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIHealth : MonoBehaviour {

    PlayerAttributes player;
    Slider healthSlider;

	// Use this for initialization
	void Start () {
        player = FindObjectOfType<PlayerAttributes>();
        healthSlider = gameObject.GetComponent<Slider>();
	}
	
	// Update is called once per frame
	void Update () {
        healthSlider.value = player.health;
	}
}
