using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] TextAsset[] scenes;

    private void Awake()
    {
        scenes = Resources.LoadAll<TextAsset>("Joker");
    }

    [NaughtyAttributes.Button]
    public void DebugTextDump()
    {
        print(GetRandomScene());
    }
    public string GetRandomScene()
    {
        int index = Random.Range(0, scenes.Length);
        return GetSceneFromIndex(index);
    }

    public string GetSceneFromIndex(int index)
    {
        if (index < 0 || index >= scenes.Length)
            return "INVALID SCENE";

        return scenes[index].text;
    }

}
