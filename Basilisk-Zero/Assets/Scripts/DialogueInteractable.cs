using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DialogueInteractable : MonoBehaviour
{
    // this file is attached to every character in the scene and so will affect only
    // the targeted character object when functions are called

    // disable scene interaction, activate speaker indicator, and
    // run dialogue from {conversationStartNode}
    //private void StartConversation();

    // reverse StartConversation's changes: 
    // re-enable scene interaction, deactivate indicator, etc.
    //private void EndConversation();

    // make character not able to be clicked on
    //public void DisableConversation();
}
