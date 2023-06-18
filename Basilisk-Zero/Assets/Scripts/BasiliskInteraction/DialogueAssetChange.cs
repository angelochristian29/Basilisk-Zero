using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueAssetChange : MonoBehaviour
{
    [Header("Sprites")]
    [SerializeField] private Sprite supportAIPoster;
    [SerializeField] private Sprite derailmentPoster;

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    private void Update()
    {
        // change posters in the world
        int supportAIValue = ((Ink.Runtime.IntValue) InkDialogueManager.GetInstance().GetVariableState("supportAI")).value;
        int derailmentValue = ((Ink.Runtime.IntValue) InkDialogueManager.GetInstance().GetVariableState("derailment")).value;

        if (supportAIValue >= 10)
        {
            spriteRenderer.sprite = supportAIPoster;
            return;
        }

        if (derailmentValue >= 10)
        {
            spriteRenderer.sprite = derailmentPoster;
            return;
        }
    }
}
