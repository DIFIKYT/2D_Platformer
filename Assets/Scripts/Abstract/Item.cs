using UnityEngine;

public abstract class Item : MonoBehaviour
{
    protected bool _isTaken = false;

    public void Remove()
    {
        if (_isTaken == false)
        {
            _isTaken = true;
            Destroy(gameObject);
        }
    }
}