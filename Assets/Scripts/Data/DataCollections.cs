using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData
{
    public List<SceneData> sceneDataList;
    public SceneData GetSceneDataByIndex(int index)
    {
        return sceneDataList.Find(scene => scene.index == index);
    }

}
public class SceneData
{
    public int index;
    public List<DialogueData> dialogueDataList;
    public DialogueData GetDialogueDataByIndex(int index)
    {
        return dialogueDataList.Find(dialogue => dialogue.index == index);
    }
}

public class DialogueData
{
    public int index;
    public string text;
    public string name;
    public List<int> sprites;
    public List<int> positions;
    public int background;
    public int nextIndex;


    // select
    public List<int> selections;
    public List<int> nextIndexes;

}