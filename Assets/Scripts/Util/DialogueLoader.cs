using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueLoader : Singleton<DialogueLoader>
{
    public GameData gameData;
    public SceneData ReadScene(int index)
    {
        string path = "json"+index;
        TextAsset jsonFile = Resources.Load<TextAsset>(path);
        SceneData sceneData = JsonUtility.FromJson<SceneData>(jsonFile.text);
        return sceneData;
    }
}
