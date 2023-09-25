using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    private char _inputChar;
    private event Action<char> OnCharacterInput = delegate { };

    private void ReadInputCharacter()
    {
        foreach (char c in Input.inputString)
        {
            if (c == '\b') // has backspace/delete been pressed?
            {
                return;
            }
            else if ((c == '\n') || (c == '\r')) // enter/return
            {
                return;
            }
            else if (char.IsLetter(c))
            {
                _inputChar = c;
                OnCharacterInput(_inputChar);
            }
        }
    }

    private void Update()
    {
        ReadInputCharacter();
    }

    public void AssignOnInputListener(Action<char> listener)
    {
        OnCharacterInput += listener;
    }

    public void UnssignOnInputListener(Action<char> listener)
    {
        OnCharacterInput -= listener;
    }
}
