using UnityEngine;
using UnityEngine.UI;

using System.Collections.Generic;

public class SpawnBee : MonoBehaviour
{
    public GameObject bee;
    int beeCount;
    public Text beeCountText;
    public int flowerCount;

    List<GameObject> bees;

    const float baseSpawnTime = 5.03f;
    float currTime;
    float spawnTime;

    void Start()
    {
        beeCount = 0;
        bees = new List<GameObject>();
        currTime = 0;

        spawnTime = Mathf.Clamp(baseSpawnTime - 0.01f * flowerCount, 1.0f, baseSpawnTime);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            GameObject temp = Instantiate(bee, new Vector2(Random.Range(-8.5f, 8.5f), transform.position.y), Quaternion.identity);
            beeCount += 1;
        }

        if (currTime >= spawnTime)
        {
            GameObject temp = Instantiate(bee, new Vector2(Random.Range(-8.5f, 8.5f), transform.position.y), Quaternion.identity);
            beeCount += 1;
            currTime = 0;
        }

        currTime += Time.deltaTime;
        spawnTime = baseSpawnTime - 0.01f * flowerCount;

        // if (Input.GetKeyDown(KeyCode.R))
        // {
        //     for (int i = 0; i < beeCount; ++i) {
        //         Destroy(bees[i]);
        //     }

        //     beeCount = 0;
        //     beeCountText.text = "" + beeCount;
        //     bees.Clear();
        // }

        // if (Input.GetKeyDown(KeyCode.Escape)) {
        //     Application.Quit();
        // }
    }
}
