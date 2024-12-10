 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// In Game
public class GameManager : Singleton<GameManager>
{
    // Start is called before the first frame update
    public List<string> tBGURLs;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
