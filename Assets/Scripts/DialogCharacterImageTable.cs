using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class DialogCharacterImageTable : ScriptableObject
{
    [SerializeField] NameSpritePair[] nameSpriteTable;

    public NameSpritePair[] GetTable()
    {
        return nameSpriteTable;
    }

    [System.Serializable]
    public class NameSpritePair
    {
        public string Name;
        public Sprite Sprite;
    }

}
