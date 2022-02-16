using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ConversationObject")]
public class Conversation_SO : ScriptableObject
{
    public List<DialogElement> elements;

    public Conversation_SO(TextAsset input)
    {
        //string[] separators = new string[] { "</b>" };
        //string[] splitsting = input.text.Split(separators, 0);
        //elements = new List<DialogElement>(splitsting.Length);
        //int index = 0;
        //foreach (var element in elements)
        //{
        //    element.dialogText = splitsting[index];
        //    index++;
        //}

    }
}
