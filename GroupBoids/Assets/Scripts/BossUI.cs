using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BossUI : MonoBehaviour {

    BossBehavior boss;          //Boss Instance
    public GameObject bossUI;   //Boss UI
    Slider bossHealthSlider;    //The actual boss slider
    bool bossIn;                //Is the boss in the scene?

	// Use this for initialization
	void Start () {
        bossIn = false;
	}
	
	// Update is called once per frame
	void Update () {
	    if(bossIn == false && FindObjectOfType<BossBehavior>() != null)
        {
            boss = FindObjectOfType<BossBehavior>();
            bossIn = true;
            bossUI.SetActive(true);
            bossHealthSlider = bossUI.GetComponent<Slider>();
            bossHealthSlider.maxValue = boss.Health;
            bossHealthSlider.value = bossHealthSlider.maxValue;
        }

        else if (bossIn == true)
        {
            bossHealthSlider.value = boss.Health;
        }
	}
}
