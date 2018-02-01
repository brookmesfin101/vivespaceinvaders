using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour {

    public GameObject controller;
    public SteamVR_TrackedObject vivecontroller;
    bool laserpointer;
    Color selectedColor = new Color(32, 32, 32, 00);
    Color defaultColor = new Color(32, 32, 32, 81);



	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        laserpointer = controller.GetComponent<BrooksLaserPointer>().bHit;
        var device = SteamVR_Controller.Input((int)vivecontroller.index);

        Debug.Log("Value of TriggerDown = " + device.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger));

        if (device.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger) == true && laserpointer)
        {
            if(this.GetComponent<Animation>() != null)
                this.GetComponent<Animation>().Play();
        }
        else if(device.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger) == false && laserpointer)
        {
            this.GetComponent<Button>().image.color = selectedColor;
        }
        else
        {
            this.GetComponent<Button>().image.color = defaultColor;
        }
        
	}

    
    void LoadFirstScene()
    {
        SceneManager.LoadScene("FirstScene");
    }

}
