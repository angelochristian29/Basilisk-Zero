using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TextAssetType
{
    Txt,
    Html,
    Json
}

[CreateAssetMenu(fileName ="wordAssetData", menuName ="Resource Data/Words Data")]
public class FileData : ScriptableObject
{
    
    [SerializeField]
    private TextAsset wordsFile;
    [SerializeField]
    private TextAssetType resourceType;

    public TextAsset WordsFile { get => wordsFile;}
    public TextAssetType ResourceType { get => resourceType;}
}
