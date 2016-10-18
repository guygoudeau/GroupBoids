using UnityEngine;
using System.Collections;

public class LockBoxModel : MonoBehaviour {
    public GameObject target;
    Vector3 offset;

	// Use this for initialization
	void Awake () {
        offset = target.transform.position - gameObject.transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate () {
        transform.localRotation = Quaternion.identity;
        transform.position = target.transform.position - offset;
	}
}
