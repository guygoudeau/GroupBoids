using UnityEngine;
using System.Collections.Generic;

public class SetTextures : MonoBehaviour {

    public List<Texture> textures;

	// Use this for initialization
	void Start () {
	    foreach(MonoAgent ma in FindObjectsOfType<MonoAgent>())
        {
            int index = Random.Range(0, textures.Count - 1);
            ma.gameObject.GetComponent<MeshRenderer>().material.mainTexture = textures[index];
        }
	}
}
