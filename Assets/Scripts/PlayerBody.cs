using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerBody : MonoBehaviour {

    public Transform cameraEye;
    float yRotation;

    // Use this for initialization
    void Start () {
        this.transform.position = cameraEye.transform.position;
        this.transform.rotation = cameraEye.transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.position = cameraEye.transform.position;

        yRotation = cameraEye.transform.eulerAngles.y;

        this.transform.eulerAngles = new Vector3(this.transform.eulerAngles.x, yRotation, this.transform.eulerAngles.z);
	}

    public void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Enemy1" || col.gameObject.tag == "Enemy2" || col.gameObject.tag == "Enemy3")
        {
            Destroy(col.gameObject);
            //GameObject.Find("ScreenFlash").GetComponent<Image>().color = Color.black;
            StartCoroutine("Hit");
        }
    }

    IEnumerator Hit()
    {
        for(float f = 0f; f <= 1; f += .1f)
        {
            //Color HitScreenAlpha = GameObject.Find("Cube").GetComponent<Image>().color;
            Color HitScreenAlpha = GameObject.Find("ScreenFlash").GetComponent<Image>().color;
            HitScreenAlpha.a = f;
            GameObject.Find("ScreenFlash").GetComponent<Image>().color = HitScreenAlpha;
            yield return new WaitForSeconds(.01f);
        }
        for (float f = 1f; f >= -.1; f -= .1f)
        {
            //Color HitScreenAlpha = GameObject.Find("Cube").GetComponent<Image>().color;
            Color HitScreenAlpha = GameObject.Find("ScreenFlash").GetComponent<Image>().color;
            HitScreenAlpha.a = f;
            GameObject.Find("ScreenFlash").GetComponent<Image>().color = HitScreenAlpha;
            yield return new WaitForSeconds(.01f);
        }
    }
}
