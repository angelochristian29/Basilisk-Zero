using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;
using System.IO;

public class InkDialogueVariables
{
    public Dictionary<string, Ink.Runtime.Object> variables { get; private set; }

    public InkDialogueVariables(TextAsset loadGlobalsJSON)
    {
        // creates a new story from the TextAsset
        Story globalVariablesStory = new Story(loadGlobalsJSON.text);

        // assign each variable to the dictionary
        variables = new Dictionary<string, Ink.Runtime.Object>();
        foreach ( string name in globalVariablesStory.variablesState)
        {
            Ink.Runtime.Object value = globalVariablesStory.variablesState.GetVariableWithName(name);
            variables.Add(name, value);
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
        if (variables.ContainsKey(name))
        {
            variables.Remove(name);
            variables.Add(name, value);
        }
    }

    private void VariablesToStory(Story story)
    {
        foreach (KeyValuePair<string, Ink.Runtime.Object> variable in variables)
        {
            story.variablesState.SetGlobal(variable.Key, variable.Value);
        }
    }
}
