using UnityEngine;

public class TimeTutorial : MonoBehaviour
{
    float time;
    
    void Start()
    {
        time = 0;
    }

    void Update()
    {
        if (time >= 10.0f)
            gameObject.SetActive(false);
        else
            time += Time.deltaTime;
    }
}
