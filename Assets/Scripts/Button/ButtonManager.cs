using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : Singleton<ButtonManager>
{
    public ScrollRect panelBG;
    public GameObject imageBG;

    public void ShowScrollView()
    {
        panelBG.gameObject.SetActive(!panelBG.gameObject.activeSelf);
    }
    public void AddItem(string url)
    {
        var g = GameObject.Instantiate(imageBG, panelBG.content.transform);
        var i = g.GetComponent<Image>();
        LoadTextureUrl(i,url);
    }

    public void LoadTextureUrl(Image obj, string url)
    {
        StartCoroutine(ILoadTexture(obj, url));
    }

    IEnumerator ILoadTexture(Image obj, string url)
    {
        double startTime = (double)Time.time;
        //请求WWW
        WWW www = new WWW(url);

        yield return www;
        if (www != null && string.IsNullOrEmpty(www.error))
        {
            //获取Texture
            Texture2D texture = www.texture;
                //创建Sprite
            Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
            startTime = (double)Time.time - startTime;
            Debug.Log("www加载用时 : " + startTime);
            obj.sprite = sprite;
        }
    }
    
    public void StartGame()
    {
        SceneManager.LoadSceneAsync("GameScene", LoadSceneMode.Additive);
    }

    public void ShowGameData()
    {
        TalkManager.Instance.ShowGameData();
    }
}
