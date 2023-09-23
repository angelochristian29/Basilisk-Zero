using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Linq;

public class TypingManager
{
    LinkedList<char> _currentWord = null;

    public TypingManager(string word)
    {
        SetAsNewWord(word);
    }

    public void SetAsNewWord(string word)
    {
        _currentWord = new LinkedList<char>(word.ToLower());
    }

    public bool CheckCharacter(char inputChar)
    {
        if (_currentWord.First.Value == inputChar)
        {
            _currentWord.RemoveFirst();
            return true;
        }
        return false;
    }

    public bool CheckIfWordsFinished()
    {
        return _currentWord.Count <= 0;
    }

    public string GetCurrentWord()
    {
        return string.Join("", _currentWord.ToArray());
    }

}
