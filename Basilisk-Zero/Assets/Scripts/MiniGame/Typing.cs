﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Typing : MonoBehaviour
{
    private enum AudioClipType
    {
        GoodWord = 0,
        GoodLetter = 1,
        BadLetter = 2
    }
    [SerializeField]
    private FileData _data;

    private Queue<string> _wordsQueue;
    private ITextAssetReader _textReader;
    private TypingManager typingManager;
    private AudioSource _audioSource;

    [SerializeField]
    private AudioClip[] _audioClips;

    [SerializeField]
    private GameObject typingCanvas;
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        if (_data != null)
        {
            _textReader = TextAssetReaderFactory.CreateReader(_data.ResourceType);
            _wordsQueue = _textReader.ReadFile(_data.WordsFile);
            typingManager = new TypingManager(GetNextWord());
            UIManager.instance.UpdateText(typingManager.GetCurrentWord());
            FindObjectOfType<InputHandler>().AssignOnInputListener(CheckPlayerInput);
        }
        else
        {
            throw new System.Exception("No data file assigned");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }


    public string GetNextWord()
    {
        if (_wordsQueue.Count == 0)
        {
            // Ends the game and shuts Down UI elements
            Debug.Log("All words completed");
            OpenTypingGame.GetInstance().gameIsDone = true;
            OpenTypingGame.GetInstance().gameIsPlaying = false;
            // InkDialogueManager.GetInstance().currentStory.variablesState["supportAI"] = 30;
            // Debug.Log("supportAI = " + ((Ink.Runtime.IntValue) InkDialogueManager.GetInstance().GetVariableState("supportAI")).value);
            return "";
        }
        else
        {
            return _wordsQueue.Dequeue();
        }

    }

    public void CheckPlayerInput(char c)
    {
        Debug.Log(c);
        if (typingManager.CheckCharacter(c))
        {
            UIManager.instance.UpdateText(typingManager.GetCurrentWord());
            if (typingManager.CheckIfWordsFinished())
            {
                typingManager.SetAsNewWord(GetNextWord());
                PlayFeedbackSound(AudioClipType.GoodWord);
                UIManager.instance.UpdateText(typingManager.GetCurrentWord());
            }
            else
            {
                PlayFeedbackSound(AudioClipType.GoodLetter);
            }
        }
        else
        {
            PlayFeedbackSound(AudioClipType.BadLetter);
        }
    }

    private void PlayFeedbackSound(AudioClipType type)
    {
        _audioSource.clip = _audioClips[(int)type];
        _audioSource.Play();
    }
}
