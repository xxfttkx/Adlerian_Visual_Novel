using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueLoader : MonoBehaviour
{
    void ReadJson()
    {
        TextAsset jsonFile = Resources.Load<TextAsset>("json");
        DialogueData dialogueData = JsonUtility.FromJson<DialogueData>(jsonFile.text);

        foreach (var scene in dialogueData.scenes)
        {
            Debug.Log("Scene ID: " + scene.id);
            foreach (var line in scene.lines)
            {
                Debug.Log(line.character + ": " + line.text);
            }
        }
    }
}
