using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITextAssetReader
{
    Queue<string> ReadFile(TextAsset resourceFile);
}
