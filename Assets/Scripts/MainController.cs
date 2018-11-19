using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainController : MonoBehaviour {

    public Touch myTouch;
    public float touchX;
    public float touchY;
	// Use this for initialization
	void Start () {
        Screen.orientation = ScreenOrientation.Portrait;

    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }

        myTouch = Input.GetTouch(0);

        touchX = myTouch.position.x;
        touchY = myTouch.position.y;

    }

    public void LoadScene (int level)
    {
        Application.LoadLevel(level);
    }

    public void LoadMain()
    {
        Application.LoadLevel(0);
    }

    public void ExitApplication ()
    {
        Application.Quit();
    }
}
