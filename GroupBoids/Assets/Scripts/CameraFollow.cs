using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
    public GameObject target;
    Vector3 offset;

	// Use this for initialization
	void Awake () {
        offset = target.transform.position - gameObject.transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate () {
        transform.position = target.transform.position - offset;
	}
}
