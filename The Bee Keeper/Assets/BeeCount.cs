using UnityEngine;
using UnityEngine.UI;

public class BeeCount : MonoBehaviour
{
    public int caughtBeeCount;
    public Text text;

    void Update()
    {
        text.text = "" + caughtBeeCount;
    }
}
