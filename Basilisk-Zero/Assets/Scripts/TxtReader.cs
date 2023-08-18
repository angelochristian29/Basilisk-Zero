using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Linq;
using Random = UnityEngine.Random;

public class TxtReader : ITextAssetReader
{
    public Queue<string> ReadFile(TextAsset resourceFile)
    {
        string[] words = resourceFile.text.Split(new char[0]);
        return PrepareWords(words);
    }

    private Queue<string> PrepareWords(string[] words)
    {

        List<string> wordsMax4Letters = words.Where(word => word.Length < 4).ToList();
        wordsMax4Letters = ShuffleList(wordsMax4Letters);
        return new Queue<string>(wordsMax4Letters);
    }

    private List<string> ShuffleList(List<string> words)
    {
        List<string> temporaryList = new List<string>(words);
        for (int i = 0; i < words.Count; i++)
        {
            string temporaryWord = words[i];
            int randomIndex = Random.Range(i, words.Count);
            temporaryList[i] = words[randomIndex];
            temporaryList[randomIndex] = temporaryWord;
        }
        return temporaryList;
    }
}
