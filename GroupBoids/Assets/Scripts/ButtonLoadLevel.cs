using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonLoadLevel : MonoBehaviour {

    public string level;

	// Use this for initialization
	void Start () {
        Button thisButton = gameObject.GetComponent<Button>();
        thisButton.onClick.AddListener(delegate { Utilities.LoadScene(level); });
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
