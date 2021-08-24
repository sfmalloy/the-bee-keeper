using UnityEngine;

public class PlayerAttributes : MonoBehaviour
{
    GameObject currentTree;

    void Start()
    {
        currentTree = null;
    }

    void Update()
    {
    }

    public void SetCurrentTree(GameObject tree)
    {
        currentTree = tree;
    }

    public void DestoryCurrentTree() 
    {
        if (currentTree != null)
        {
            Destroy(currentTree);
            currentTree = null;
        }
    }
}
