using UnityEngine;
using UnityEngine.UI;

public class BarFollow : MonoBehaviour
{
    [SerializeField] private Slider _bar;
    [SerializeField] private Vector3 _offset;

    private void Update()
    {
        if (_bar != null)
            _bar.transform.position = transform.position + _offset;
    }
}