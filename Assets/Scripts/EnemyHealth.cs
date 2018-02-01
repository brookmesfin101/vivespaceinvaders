using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

    public int enemyHealth;

	// Use this for initialization
	void Start () {
        switch(this.gameObject.tag)
        {
            case "Enemy1": enemyHealth = 10; break;
            case "Enemy2": enemyHealth = 20; break;
            case "Enemy3": enemyHealth = 30; break;
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    
    void OnTriggerExit(Collider col)
    {
        Debug.Log("Value of GameObject in Collision = " + col.gameObject.name);
        if(col.gameObject.tag == "Bullet")
        {
            Destroy(col.gameObject, 0.1f);
        }
        enemyHealth -= 10;
        if(enemyHealth <= 0)
        {
            this.gameObject.GetComponent<ParticleSystem>().Play();

            if(this.gameObject.GetComponent<SphereCollider>())
            {
                Destroy(this.gameObject.GetComponent<SphereCollider>());
            }
            else if(this.gameObject.GetComponent<CapsuleCollider>())
            {
                Destroy(this.gameObject.GetComponent<CapsuleCollider>());
            }
            Destroy(this.gameObject, .2f);
        }
    }
    
}
