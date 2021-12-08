using TMPro;
using System;
using UnityEngine;
using Zork.Common;

public class UnityInputService : MonoBehaviour, IInputService
{
    #region Variables

    public TMP_InputField InputField;

    #endregion Variables

    #region Properties

    public event EventHandler<string> InputReceived;

    #endregion Properties

    #region Update

    private void Update()
    {
        if (Input.GetKey(KeyCode.Return))
        {
            if (string.IsNullOrWhiteSpace(InputField.text) == false)
            {
                string inputString = InputField.text.Trim().ToUpper();
                InputReceived?.Invoke(this, inputString);
            }

            InputField.text = string.Empty;
            InputField.Select();
            InputField.ActivateInputField();
        }

        #endregion Update
    }
}
