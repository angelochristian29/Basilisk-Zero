using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextAssetReaderFactory
{
    public static ITextAssetReader CreateReader(TextAssetType type)
    {
        switch (type)
        {
            case TextAssetType.Txt:
                return new TxtReader();
            case TextAssetType.Html:
                break;
            case TextAssetType.Json:
                break;
            default:
                break;
        }
        return null;
    }
}
