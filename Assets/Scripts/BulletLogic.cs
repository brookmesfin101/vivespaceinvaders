using UnityEngine;
using System.Collections;

public class BulletLogic : MonoBehaviour {

    public Transform bulletSpawnPoint;
    public float bulletSpeed = 25f;
    public int ammoCount = 25;
    float fireRate = .35f;
    private float lastFire = 0;

    public AudioSource outofAmmoSound;
    public AudioSource reloadSound;
    public AudioSource shotfiredSound;

    public GameObject bulletPrefab;

    public SteamVR_TrackedObject rightController;

	// Update is called once per frame
	void Update () {

        var device = SteamVR_Controller.Input((int)rightController.index);

        if (device.GetTouch(SteamVR_Controller.ButtonMask.Trigger) && Time.time > lastFire)
        {
            if (ammoCount > 0)
            {
                lastFire = Time.time + fireRate;
                fireBullet();
            }
            else
            {
                //this.GetComponent<AudioSource>().Play(); <----- This works when you have one audiosource in the game object that this script is attached to
                outofAmmoSound.Play();
            }

            /* 
             *** ---- Another way to set the projectile speed of the bullet ---- ***
            Rigidbody temporaryRigidbody;
            temporaryRigidbody = bulletClone.GetComponent<Rigidbody>();
            temporaryRigidbody.AddForce(bulletSpawnPoint.transform.forward * bulletSpeed);
            */
        } 

        if(device.GetTouchDown(SteamVR_Controller.ButtonMask.Grip))
        {
            ammoCount = 25;
            reloadSound.Play();
        }
    }

    void fireBullet()
    {
        GameObject bulletClone = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.transform.rotation) as GameObject;
        bulletClone.transform.Rotate(270f, 0f, 0f);
        bulletClone.GetComponent<Rigidbody>().velocity = bulletSpeed * bulletSpawnPoint.transform.forward;
        shotfiredSound.Play();
        Destroy(bulletClone, 10.0f);
        ammoCount--;
    }
}
