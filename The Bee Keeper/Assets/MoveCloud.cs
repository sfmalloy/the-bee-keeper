using UnityEngine;

public class MoveCloud : MonoBehaviour
{
    public float speed;
    public float start;

    void Start()
    {
    }

    void Update()
    {
        if (Mathf.Abs(transform.position.x) < 11)
            transform.position = new Vector2(transform.position.x + speed, transform.position.y);
        else
            transform.position = new Vector2(start, transform.position.y);
    }
}
