using System;
using UnityEngine;

public class KeyController : MonoBehaviour
{
    public event Action<KeyCode> KeyPassed;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            KeyPassed?.Invoke(KeyCode.W);
        }

        if (Input.GetKey(KeyCode.A))
        {
            KeyPassed?.Invoke(KeyCode.A);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            KeyPassed?.Invoke(KeyCode.S);
        }

        if (Input.GetKey(KeyCode.D))
        {
            KeyPassed?.Invoke(KeyCode.D);
        }
    }
}
