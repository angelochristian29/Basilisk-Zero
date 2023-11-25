using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;

public class InkDialogueVariables
{
    public Dictionary<string, Ink.Runtime.Object> Variables { get; private set; }

    public InkDialogueVariables(TextAsset loadGlobalsJSON)
    {
        // creates a new story from the TextAsset
        Story globalVariablesStory = new(loadGlobalsJSON.text);

        // assign each variable to the dictionary
        Variables = new Dictionary<string, Ink.Runtime.Object>();
        
        foreach ( string name in globalVariablesStory.variablesState)
        {
            Ink.Runtime.Object value = globalVariablesStory.variablesState.GetVariableWithName(name);
            Variables.Add(name, value);
        }
    }

    public void StartListening(Story story)
    {
        VariablesToStory(story);
        // Add function to listener
        story.variablesState.variableChangedEvent += ChangedVariable;
    }

    public void StopListening(Story story)
    {
        // Remove function from listener
        story.variablesState.variableChangedEvent -= ChangedVariable;
    }

    // Variable observer
    private void ChangedVariable(string name, Ink.Runtime.Object value)
    {
        // only maintain variables that are contained in the Dictionary
        if (Variables.ContainsKey(name))
        {
            Variables.Remove(name);
            Variables.Add(name, value);
        }
    }

    private void VariablesToStory(Story story)
    {
        foreach (KeyValuePair<string, Ink.Runtime.Object> variable in Variables)
        {
            story.variablesState.SetGlobal(variable.Key, variable.Value);
        }
    }
}
