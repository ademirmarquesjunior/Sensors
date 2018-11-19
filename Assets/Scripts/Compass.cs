using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Compass : MonoBehaviour {

    public Text compassText;
    public GameObject needle;

	// Use this for initialization
	void Start () {

        Input.location.Start();
        Input.compass.enabled = true;
        

    }
	
	// Update is called once per frame
	void Update () {
        int compass = (int) Input.compass.trueHeading;
        compassText.text = compass.ToString() + "º";
        needle.transform.eulerAngles = new Vector3(needle.transform.eulerAngles.x, needle.transform.eulerAngles.y, -compass);
		
	}
}
