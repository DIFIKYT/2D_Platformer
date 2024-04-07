using UnityEngine;

public abstract class Item : MonoBehaviour
{
    public void Remove()
    {
        Destroy(gameObject);
    }
}