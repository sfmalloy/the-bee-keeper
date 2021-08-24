using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public struct Item
{
    public GameObject gameObject;
    public int quantity;
    public Image uiImage;
    public bool isInfinite;
}

public class Inventory : MonoBehaviour
{
    public Item[] placeable;
    Item currentItem;
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

        if (newIndex != index)
            SetCurrentItem(newIndex);

        if (Input.GetButtonDown("Swing"))
        {
            if (currentItem.isInfinite || currentItem.quantity > 0)
            {
                currentItem.gameObject.GetComponent<Useable>().Use();
                if (!currentItem.isInfinite)
                    currentItem.quantity -= 1;
            }
        }
    }

    void SetCurrentItem(int newIndex)
    {
        if (index != -1)
            currentItem.gameObject.SetActive(false);

        index = newIndex;
        currentItem = placeable[index];
        currentItem.gameObject.SetActive(true);
    }
}
