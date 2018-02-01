using UnityEngine;
using System.Collections;

using UnityEngine.UI;

public class HoloAmmoCounter : MonoBehaviour {


    public GameObject pulsegun;

    Text ammoText;

    void Awake()
    {
        ammoText = GetComponent<Text>();
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        ammoText.text = pulsegun.GetComponent<BulletLogic>().ammoCount.ToString();
	}
}
