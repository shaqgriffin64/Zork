using UnityEngine;
using Zork.Common;
using TMPro;
using System;

public class UnityInputService : MonoBehaviour, IInputService
{
    public event EventHandler<string> InputReceived;
    public void ProcessInput()
    {

    }

    void Update()
    {
        string inputString = InputField.text;

        if (string.IsNullOrWhiteSpace(inputString) == false)
        {
            if (Input.GetKey(KeyCode.Return))
            {
                InputReceived?.Invoke(this, inputString);
            }

            InputField.text = string.Empty;
        }
    }




    [SerializeField] private TMP_InputField InputField;
}
