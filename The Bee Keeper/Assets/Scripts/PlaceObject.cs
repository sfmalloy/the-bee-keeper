using UnityEngine;
using System;

public class PlaceObject : MonoBehaviour, Useable
{
    public GameObject objectToPlace;
    public GameObject player;
    public float groundHeight;

    const float MAX_PLACE_DIST = 1.0f;

    void Update()
    {
        float mouseX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
        float screenWidth = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x - objectToPlace.transform.localScale.x / 2;

        if (mouseX < player.transform.position.x)
        {
            transform.position = new Vector2(ClampCompare(Mathf.Max, 
                                                          mouseX, 
                                                          player.transform.position.x - MAX_PLACE_DIST, 
                                                          -screenWidth, 
                                                          screenWidth), 
                                             groundHeight);
        }
        else
        {
            transform.position = new Vector2(ClampCompare(Mathf.Min, 
                                                          mouseX, 
                                                          player.transform.position.x + MAX_PLACE_DIST, 
                                                          -screenWidth, 
                                                          screenWidth),
                                             groundHeight);
        }
    }

    public void Use()
    {
        Instantiate(objectToPlace, 
                    transform.position, 
                    Quaternion.identity).SetActive(true);
    }

    private float ClampCompare(Func<float, float, float> function, float a, float b, float clampMin, float clampMax)
    {
        return Mathf.Clamp(function(a, b), clampMin, clampMax);
    }
}
