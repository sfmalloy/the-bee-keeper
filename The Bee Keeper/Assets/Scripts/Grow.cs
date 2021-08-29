using UnityEngine;
using System.Collections;

public class Grow : MonoBehaviour
{
    public GameObject grownForm;
    public GameObject rareForm;
    public float yOffset;
    public int minTime, maxTime;

    bool growing;
    float time;

    public bool watered;

    bool didWaterBonus;

    void Start()
    {
        growing = false;
        time = -1;
        didWaterBonus = false;
    }

    void Update()
    {
        if (!growing)
        {
            time = Random.Range(minTime, maxTime);
            growing = true;
        }
        if (watered && !didWaterBonus)
        {
            time /= 2;
            didWaterBonus = true;
        }

        if (time <= 0)
        {
            if (rareForm != null && Random.Range(0.0f, 1.0f) <= 0.1f)
                Instantiate(rareForm, new Vector2(transform.position.x, transform.position.y + yOffset), Quaternion.identity);
            else
                Instantiate(grownForm, new Vector2(transform.position.x, transform.position.y + yOffset), Quaternion.identity);
            Destroy(gameObject);
        }
        else
            time -= Time.deltaTime;
    }
}
