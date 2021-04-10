using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogCharacterImageHandler : MonoBehaviour
{
    [SerializeField] DialogCharacterImageTable tableContainer;

    Dictionary<string, Sprite> characterImageDictionary;

    private void Awake()
    {
        Debug.Assert(tableContainer != null, "No table assigned to DialogCharacterImageHandler");

        var table = tableContainer.GetTable();
        characterImageDictionary = new Dictionary<string, Sprite>(table.Length);

        foreach (var entry in table)
        {
            characterImageDictionary.Add(entry.Name.ToLowerInvariant(), entry.Sprite);
        }
    }


    public Sprite GetSpriteFor(string name)
    {
        name = name.ToLowerInvariant();
        if (characterImageDictionary.ContainsKey(name))
        {
            return characterImageDictionary[name];
        }

        return null;
    }

}
