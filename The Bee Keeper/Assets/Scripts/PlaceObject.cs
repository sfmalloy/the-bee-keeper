using UnityEngine;
using System;
using System.Collections.Generic;

public class PlaceObject : MonoBehaviour, Useable
{
    public GameObject[] objectsToPlace;
    public GameObject player;
    public float groundHeight;
    public GameManager gameManager;

    public List<GameObject> activeObjects;

    GameObject objectToPlace;

    const float MAX_PLACE_DIST = 1.0f;

    void Start()
    {
        if (objectsToPlace.Length == 1)
            objectToPlace = objectsToPlace[0];
        else
            objectToPlace = objectsToPlace[UnityEngine.Random.Range(0, objectsToPlace.Length)];

        activeObjects = new List<GameObject>();
    }

    void Update()
    {
        if (!gameManager.isPaused)
        {
            float mouseX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
            float screenWidth = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, groundHeight)).x - objectToPlace.transform.localScale.x / 2;

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
    }

    public void Use()
    {
        GameObject placed = Instantiate(objectToPlace, 
                                        transform.position, 
                                        Quaternion.identity);
        placed.SetActive(true);
        placed.GetComponent<Rigidbody2D>().isKinematic = true;
        placed.GetComponent<SpriteRenderer>().sortingOrder = -5;

        activeObjects.Add(placed);

        if (objectsToPlace.Length > 1)
            objectToPlace = objectsToPlace[UnityEngine.Random.Range(0, objectsToPlace.Length)];
    }

    public void Remove(GameObject gameObject)
    {
        int index = activeObjects.IndexOf(gameObject);
        GameObject temp = activeObjects[index];
        activeObjects[index] = activeObjects[activeObjects.Count - 1];
        activeObjects.RemoveAt(activeObjects.Count - 1);
    }

    public GameObject GetRandomObject()
    {
        return activeObjects[UnityEngine.Random.Range(0, activeObjects.Count)];
    }

    private float ClampCompare(Func<float, float, float> function, float a, float b, float clampMin, float clampMax)
    {
        return Mathf.Clamp(function(a, b), clampMin, clampMax);
    }
}
