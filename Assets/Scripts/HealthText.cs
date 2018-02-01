using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthText : MonoBehaviour {

    //public SteamVR_TrackedObject leftController;
    //bool showHealth = false;
    string healthText = "Player Health : ";
    int playerHealth;

    public GameObject HeadCamera;
    //public Text bodyText;


	// Use this for initialization
	void Start () {
        //this.GetComponent<Text>().text = healthText + playerHealth.ToString();

	}

    // Update is called once per frame
    void Update()
    {
        /* --- Opted to place health on body capsule instead ----
        var device = SteamVR_Controller.Input((int)leftController.index);

        if (device.GetPressDown(SteamVR_Controller.ButtonMask.Touchpad) && showHealth == false)
        {
            showHealth = true;
        }
        else if(device.GetPressDown(SteamVR_Controller.ButtonMask.Touchpad) && showHealth == true)
        {
            showHealth = false;
        }

        if(showHealth == true)
        {
            this.GetComponent<Text>().enabled = true;
        }
        else if(showHealth == false)
        {
            this.GetComponent<Text>().enabled = false;
        }
        */

        this.playerHealth = HeadCamera.GetComponent<PlayerHealth>().playerHealth;
        this.GetComponent<Text>().text = healthText + playerHealth.ToString();
        //bodyText.GetComponent<Text>().text = healthText + playerHealth.ToString();
    }


}
