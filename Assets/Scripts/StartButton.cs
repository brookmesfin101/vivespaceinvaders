using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour {

    public GameObject controller;
    public SteamVR_TrackedObject vivecontroller;
    bool laserpointer;
    public SteamVR_Camera mainCamera;
    string raycastTarget;
    GameObject fader;

    public Color selectedColor = new Color(32, 32, 32, 00);
    public Color defaultColor = new Color(32, 32, 32, 81);

    void Start()
    {
        fader = GameObject.Find("Fader");
    }
	
	// Play animation when trigger is pressed and raycast is centered on UI button
	void Update () {

        laserpointer = controller.GetComponent<BrooksLaserPointer>().bHit;
        var device = SteamVR_Controller.Input((int)vivecontroller.index);

        if (controller.GetComponent<BrooksLaserPointer>().hit.collider != null && controller.GetComponent<BrooksLaserPointer>().hit.collider.tag != null)
            raycastTarget = controller.GetComponent<BrooksLaserPointer>().hit.collider.tag;

        if (device.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger) == true && laserpointer && raycastTarget == "StartButton")
        {
            Debug.Log("Value of mainCamera.isActiveAndEnabled = " + mainCamera.isActiveAndEnabled);
            if(mainCamera != null && mainCamera.isActiveAndEnabled == true)
            {
                SteamVR_LoadLevel tempload = mainCamera.GetComponent<SteamVR_LoadLevel>();
                tempload.fadeOutTime = 1f;
                tempload.fadeInTime = 1f;
                tempload.Trigger();
            }
        }
        else if (device.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger) == false && laserpointer && raycastTarget == "StartButton")
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
