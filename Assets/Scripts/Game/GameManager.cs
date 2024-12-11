using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// In Game
public class GameManager : Singleton<GameManager>
{
    public SceneData currSceneData;
    public DialogueData currDialogueData;

    void InitGame(int sceneIndex,int dialogueIndex)
    {
        currSceneData = DialogueLoader.Instance.ReadScene(sceneIndex);
        if (currSceneData == null)
        {
            Debug.LogError("currSceneData == null");
        }
        else
        {
            EnterDialogue(dialogueIndex);
        }
    }
    DialogueData GetDialogueByIndex(int index)
    {
        var d = currSceneData.GetDialogueDataByIndex(index);
        if (d == null)
        {
            // 不知道scene的逻辑 先这样 可能要看剧情改
            currSceneData = DialogueLoader.Instance.ReadScene(currSceneData.index + 1);
            if (currSceneData == null)
            {
                // bug
                Debug.LogError("currSceneData == null");
                return null;
            }
            else
            {
                d = currSceneData.GetDialogueDataByIndex(index);
                if (d == null)
                {
                    // bug
                    Debug.LogError("currDialogueData == null");
                    return null;
                }
            }
        }
        return d;
    }
    void EnterDialogue(int index)
    {
        currDialogueData = GetDialogueByIndex(index);
        // change sprites
    }
    void ToNextIndex()
    {
        int next = currDialogueData.nextIndex;
        if (next != -1)
        {
            EnterDialogue(next);
        }
        else
        {
            //GameEnd
        }
    }

    // Start Button
    public void GameStart()
    {

    }

    // Continue Button
    public void GameContinue()
    {

    }

    // Load Button
    public void GameLoad()
    {

    }


    // GameEnd Button  Test..
    public void GameEnd()
    {
        SceneManager.UnloadSceneAsync("GameScene");
    }
}
