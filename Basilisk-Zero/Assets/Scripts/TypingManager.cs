using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Linq;

public class TypingManager
{
    Queue<char> _currentWord = null;

    public TypingManager(string word)
    {
        SetAsNewWord(word);
    }

    public void SetAsNewWord(string word)
    {
        _currentWord = new Queue<char>(word.ToLower());
    }

    public bool CheckCharacter(char inputChar)
    {
        if (_currentWord.Count > 0 && _currentWord.Peek() == inputChar)
        {
            _currentWord.Dequeue();
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
        return string.Concat(_currentWord);
    }

}
