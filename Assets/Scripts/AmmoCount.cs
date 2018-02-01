using UnityEngine;
using System.Collections;

public class AmmoCount : MonoBehaviour {

    void onGUI()
    {
        GUI.Label(new Rect(25, 25, 100, 30), "Ammo");
    }
}
