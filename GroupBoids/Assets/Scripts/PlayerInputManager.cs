using UnityEngine;
using System.Collections;

public class PlayerInputManager : MonoBehaviour {

    public float speed;

	// Update is called once per frame
	void Update () {
        //Rotation
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);    //Ray
        RaycastHit hit = new RaycastHit();                              //Raycast hit that stores the Info of what it hit
        Physics.Raycast(ray.origin, ray.direction, out hit);            //Actual Casting of the ray
        transform.LookAt(new Vector3(hit.point.x, 1, hit.point.z));


        //movement
        Vector3 direction = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
        {
            direction += new Vector3(0,0,1);
        }

        if (Input.GetKey(KeyCode.S))
        {
            direction += new Vector3(0, 0, -1);
        }

        if (Input.GetKey(KeyCode.D))
        {
            direction += new Vector3(1, 0, 0);
        }

        if (Input.GetKey(KeyCode.A))
        {
            direction += new Vector3(-1, 0, 0);
        }

        transform.position += direction * speed * Time.deltaTime;
    }
}
