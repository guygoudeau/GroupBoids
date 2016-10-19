using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

static class Utilities{

    public static Vector3 AVec3toUVec3(Agent.Vector3 apos)
    {
        Vector3 upos;
        upos.x = apos.x;
        upos.y = apos.y;
        upos.z = apos.z;
        return upos;
    }

    public static Agent.Vector3 UVec3toAVec3(Vector3 apos)
    {
        Agent.Vector3 upos;
        upos.x = apos.x;
        upos.y = apos.y;
        upos.z = apos.z;
        return upos;
    }
    public static Agent.Vector3 Invert(Vector3 apos)
    {
        Agent.Vector3 upos;
        upos.x = -1 * apos.x;
        upos.y = apos.y;
        upos.z = -1 * apos.z;
        return upos;
    }

    static public void SetTexture(MonoAgent ma, List<Texture> textures)
    {
        int index = Random.Range(0, textures.Count - 1);
        ma.gameObject.GetComponent<MeshRenderer>().material.mainTexture = textures[index];
    }

    static public void LoadScene(string name) // function attached to Main Menu button to return to menu, can choose which scene to load based on name 
    {
        SceneManager.LoadScene(name); // loads scene based on scene's name
    }

    /*
        There was once a time where Brock was famous. He was so famous that he had to get restraining orders 
        against his former friends. The biggest offender was Steve. He was dumb to the fact that 
        Brock was famous, he mistook Brock's BodyGuards for his parents. now using the restraining 
        order he must convince his former classmate to beat up steve by dropping the restraining order against 
        them.
    */
}
