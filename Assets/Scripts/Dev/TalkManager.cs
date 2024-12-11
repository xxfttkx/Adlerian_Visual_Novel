using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : Singleton<TalkManager>
{
    public GameData gameData;

    public void ShowGameData()
    {
        if(gameData==null)return;
        foreach(var s in gameData.sceneDataList)
        {

        }
    }
}
