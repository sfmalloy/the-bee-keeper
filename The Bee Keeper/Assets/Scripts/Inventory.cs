using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public struct Item
{
    public GameObject gameObject;
    public int quantity;
    public Text quantityText;
    public Image uiImage;
    public bool isInfinite;
}

public class Inventory : MonoBehaviour
{
    public Item[] placeable;
    int index;

    public GameObject playerHand;

    void Start()
    {
        index = -1;
        SetCurrentItem(0);
    }

    void Update()
    {
        int newIndex = index;
        
        for (KeyCode k = KeyCode.Alpha1; k < KeyCode.Alpha1 + placeable.Length; ++k)
        {
            if (Input.GetKeyDown(k))
                newIndex = k - KeyCode.Alpha1;
        }

        newIndex -= (int) Input.mouseScrollDelta.y;

        if (newIndex < 0)
            newIndex += placeable.Length;
        else if (newIndex >= placeable.Length)
            newIndex -= placeable.Length;

        if (newIndex != index)
            SetCurrentItem(newIndex);
        
        if (Input.GetButtonDown("Swing"))
        {
            if (placeable[index].isInfinite || placeable[index].quantity > 0)
            {
                placeable[index].gameObject.GetComponent<Useable>().Use();
                if (!placeable[index].isInfinite) 
                {
                    placeable[index].quantity -= 1;
                }
            }
        }

        foreach (Item i in placeable)
        {
            if (!i.isInfinite)
                i.quantityText.text = "" + i.quantity;
        }

    }

    void SetCurrentItem(int newIndex)
    {
        if (index != -1)
        {
            placeable[index].uiImage.enabled = false;
            placeable[index].gameObject.SetActive(false);
        }

        index = newIndex;
        placeable[index].uiImage.enabled = true;
        placeable[index].gameObject.SetActive(true);
    }
}
