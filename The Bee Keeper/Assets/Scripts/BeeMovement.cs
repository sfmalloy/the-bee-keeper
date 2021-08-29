using UnityEngine;
using System.Collections;

public class BeeMovement : MonoBehaviour
{
    public enum State
    {
        IDLE,
        FLOWER,
        COUNT
    }

    public float speed;
    public GameObject seeds;

    Rigidbody2D rb;

    Vector2 minPoint, maxPoint;
    State state;

    Vector2 dest;
    float distDelta;
    bool waiting;
    bool flowerWait;
    bool hiveWait;

    GameObject currFlower;
    GameObject currHive;

    const float epsilon = 1f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        minPoint = new Vector2(-8.7f, -0.5f);
        maxPoint = new Vector2(8.7f, 4.8f);

        state = State.IDLE;
        dest = rb.position;
        waiting = false;
    }

    void FixedUpdate()
    {
        if (!(waiting || flowerWait || hiveWait))
            StartCoroutine("SwitchState");

        switch (state)
        {
        case State.IDLE:
            PickPoint();
            break;
        case State.FLOWER:
            PickFlower();
            break;
        }
    }

    void PickPoint()
    {
        if (Vector2.Distance(rb.position, dest) < epsilon)
        {
            dest = new Vector2(Random.Range(minPoint.x, maxPoint.x), Random.Range(minPoint.y, maxPoint.y));
            GetComponent<SpriteRenderer>().flipX = rb.position.x > dest.x;
        }
        else
            rb.position = Vector2.MoveTowards(rb.position, dest, speed);
    }

    void PickFlower()
    {
        if (!flowerWait)
        {
            GameObject[] flowers = GameObject.FindGameObjectsWithTag("Flower");
            if (flowers.Length > 0)
            {
                currFlower = flowers[Random.Range(0, flowers.Length)];
                StartCoroutine("Wait", "Flower");
            }
        }
        if (currFlower != null)
            rb.position = Vector2.MoveTowards(rb.position, new Vector2(currFlower.transform.position.x, currFlower.transform.position.y + 0.5f), speed);
        else
            PickPoint();
    }

    IEnumerator SwitchState()
    {
        waiting = true;
        state = (State) Random.Range(0, (int) State.COUNT);
        yield return new WaitForSeconds(3);
        waiting = false;
    }

    IEnumerator Wait(string thingToWaitFor)
    {
        flowerWait = true;
        yield return new WaitForSeconds(Random.Range(4, 7));
        Instantiate(seeds, currFlower.transform.position, Quaternion.identity);
        flowerWait = false;
        currFlower = null;
    }
}
