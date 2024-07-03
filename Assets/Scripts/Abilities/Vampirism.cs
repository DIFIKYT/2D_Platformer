using System.Collections;
using UnityEngine;

public class Vampirism : MonoBehaviour
{
    private bool _isActivate = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {

        }
    }

    private IEnumerator ActiveCorutine()
    {


        yield return null;
    }
}