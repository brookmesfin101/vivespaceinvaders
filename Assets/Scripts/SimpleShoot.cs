using UnityEngine;
using System.Collections;

public class SimpleShoot : MonoBehaviour {

    public int ammo = 25;
    public GameObject bulletPrefab;
    public GameObject spawnPoint;
    public SteamVR_TrackedObject rightController;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        var device = SteamVR_Controller.Input((int)rightController.index);
        if(device.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger))
        {
            ammo--;
        }
    }
}
