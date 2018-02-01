using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

    //public SteamVR_TrackedObject playerCamera;
    [HideInInspector]
    public GameObject playerCamera;

	void Start () {
        playerCamera = GameObject.Find("PlayerBodyCapsule");
    }
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector3.MoveTowards(transform.position, playerCamera.transform.position, .05f);
        transform.LookAt(playerCamera.transform);
	}
}
