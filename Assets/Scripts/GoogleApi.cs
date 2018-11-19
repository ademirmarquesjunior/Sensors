using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoogleApi : MonoBehaviour {


    public RawImage img;
    public float imgX;
    public float imgY;

    public Image point;

    string url;

    public float lat;
    public float lon;
    public string location;

    LocationInfo li;

    public int zoom = 14;
    public int mapWidth = 600;
    public int mapHeight = 1024;

    public enum MapType { roadmap, satellite, hybrid, terrain}
    public MapType mapSelected;
    public int scale = 2;

    IEnumerator Map()
    {
        url = "https://maps.googleapis.com/maps/api/staticmap?center=" + lat + "," + lon +
            "&zoom=" + zoom + "&size=" + mapWidth + "x" + mapHeight + "&scale=" + scale
            + "&maptype=" + mapSelected +
            "&markers=color:blue%7Clabel:S%7C" +
            lat + "," + lon +
            "&markers=color:green%7Clabel:G%7C40.711614,-74.012318&markers=color:red%7Clabel:C%7C40.718217,-73.998284" +
            "&key=AIzaSyAe7Vwf68zIt_iO8V40ziXJLmDbSZRBj10";
        WWW www = new WWW(url);
        yield return www;
        img.texture = www.texture;
        img.SetNativeSize();
    }

	// Use this for initialization
	void Start () {
        img = GetComponent<RawImage>();
        
        MyGPSLocal();
    }

    // Update is called once per frame
    void Update() {

        if (Input.touchCount > 0)
        {
            PointTouch();
        }
    }

    public void UpdateMap()
    {
        StartCoroutine(Map());
    }

    public void UpdateZoom (bool modeZoom)
    {
        if (modeZoom)
        {
            zoom += 1;
        } else
        {
            zoom -= 1;
        }

        UpdateMap();
    }

    public void MyGPSLocal()
    {
        lat = GPS.Instance.latitude;
        lon = GPS.Instance.longitude;
        zoom = 20;

        UpdateMap();
    }

    public void TraverseMap (string where)
    {
        if (where == "up")
        {

        } else if (where == "down")
        {

        } else if (where == "left")
        {

        } else
        {

        }

        UpdateMap();
    }

    public void SearchLocation ()
    {


    }

    public void PointTouch ()
    {
        Vector3 position = new Vector3(0, 0, 0);
        Touch touch = Input.GetTouch(0);
        position.x = touch.position.x;
        position.y = touch.position.y;

        imgX = position.x;
        imgY = position.y;

        point.transform.position = position;
    }
}
