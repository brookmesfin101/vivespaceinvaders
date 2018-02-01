using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {

    public int playerHealth = 100;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
       
        if(playerHealth <= 0)
        {
            GameOver();
        }
	}

    public void OnTriggerEnter(Collider Col)
    {
        if(Col.tag == "Enemy1" || Col.tag == "Enemy2" || Col.tag == "Enemy3")
            playerHealth -= 20;
    }

    void GameOver()
    {
        SceneManager.LoadScene("GameOverScene");
    }
}
