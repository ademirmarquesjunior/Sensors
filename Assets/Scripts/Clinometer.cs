using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clinometer : MonoBehaviour
{
    public Text textX;
    public Text textY;
    public Text textZ;
    public Text textCompass;
    public Text textPosition;

    public GameObject cube;
    public GameObject needle;

    public GPS GPS;


    private void Start()
    {
        Input.location.Start();
        Input.compass.enabled = true;
    }

    private void Update()
    {
        float angleX, angleY, angleZ;

        angleX = Input.acceleration.x*90;
        angleY = Input.acceleration.y*90;
        //angleZ = Input.acceleration.z*90;


        textX.text = "" + (int)Mathf.RoundToInt(angleX) + "º";
        textY.text = "" + (int)Mathf.RoundToInt(angleY) + "º";
        //textZ.text = "Z: " + angleZ.ToString();

        cube.transform.eulerAngles = new Vector3(-angleY, -angleX, 0);

        

        int compass = (int)Input.compass.trueHeading;
        textCompass.text = compass + "º";
        needle.transform.eulerAngles = new Vector3(needle.transform.eulerAngles.x, needle.transform.eulerAngles.y, compass);

        textPosition.text = "GPS " + GPS.Instance.latitude.ToString() + ", " + GPS.Instance.longitude.ToString();
    }
}
