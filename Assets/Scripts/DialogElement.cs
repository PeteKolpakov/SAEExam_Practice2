using NaughtyAttributes;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public struct DialogElement
{
    public Interlocutor interlocutor;
    public string speakerName;
    [ResizableTextArea]
    public string dialogText;
    public Sprite image;
}
