using UnityEngine;
using System.Collections;

public class PlayerInputManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        transform.LookAt(new Vector3(ray.direction.x, 0, ray.direction.z));
	}
}
