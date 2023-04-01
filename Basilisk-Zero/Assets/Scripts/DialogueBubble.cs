using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
using System;


public class DialogueBubble : DialogueViewBase
{
    [SerializeField] RectTransform container;
    [SerializeField] TMPro.TextMeshProUGUI text;
    Action advanceHandler;

    void Start()
    {
        ShowBubble(false);
    }

    public override void RunLine(LocalizedLine dialogueLine, Action onDialogueLineFinished)
    {
        ShowBubble(true);
        text.text = dialogueLine.Text.Text;
        advanceHandler = requestInterrupt;
    }

    public override void DismissLine(Action onDismissalComplete)
    {
        ShowBubble(false);
        onDismissalComplete();
    }

    public override void UserRequestedViewAdvancement()
    {
        if (container.gameObject.activeSelf)
        {
            advanceHandler?.Invoke();
        }
    }

    public void ShowBubble(bool show)
    {
        container.gameObject.SetActive(show);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            UserRequestedViewAdvancement();
        }
    }
}
