using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class BGManager : Singleton<BGManager>
{
    // Start is called before the first frame update
    public List<string> urls;
    public SpriteRenderer sp;
    protected override void Awake() {
        base.Awake();
        sp = GetComponent<SpriteRenderer>();
        
            
    }
    private void Start() {
        for(int i = 1;i<100;++i)
        {
            string filePath = string.Format("{0}_{1}", "urls", i);
            var s = PlayerPrefs.GetString(filePath);
            if (s=="") 
            break;
            else
            {
                urls.Add(s);
                ButtonManager.GetInstance().AddItem(s);
            }
            
        }
    }
    public void AddBG(string url)
    {
        LoadTextureUrl(null,url);
    }

    public void LoadTexture(Image obj, string path)
    {
        // Application.dataPath + "/Resources/Image/Guide1.png"
        string finalPath = Application.dataPath + "/Resources/" + path;
        print("final " + finalPath);
        StartCoroutine(ILoadTexture(obj, finalPath));
    }

    public void LoadTextureUrl(Image obj, string url)
    {
        var s = urls.Find(c => c.Equals(url));
        if(s!=null) 
        {
            Debug.Log(s);
            return;
        }
        StartCoroutine(ILoadTexture(obj, url));
    }

    IEnumerator ILoadTexture(Image obj, string url)
    {
        double startTime = (double)Time.time;
        //请求WWW
        // UnityWebRequest www = new UnityWebRequest(url);
        var www = UnityWebRequestTexture.GetTexture(url);
        // yield return www;
        yield return www.SendWebRequest();
        if (www != null && string.IsNullOrEmpty(www.error))
        {
            //获取Texture
            Texture2D texture = DownloadHandlerTexture.GetContent(www);
                
            // var t = new Texture2D(1920, 1080);
            // Color[] colors = texture.GetPixels(0, 0, texture.width, texture.height);
            // t.SetPixels(colors);
            // t.Apply();//必须apply才生效
            // //创建Sprite
            // Sprite sprite = Sprite.Create(texture, new Rect(0, 0, 1920, 1080), new Vector2(0.5f, 0.5f));
            Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
            startTime = (double)Time.time - startTime;
            Debug.Log("www加载用时 : " + startTime);
            sp.sprite = sprite;

            string savePath = System.Environment.CurrentDirectory;
            var i = this.urls.Count + 1;
            string filePath = string.Format("{0}_{1}", "urls", i);
            PlayerPrefs.SetString(filePath,url);
            urls.Add(url);
            ButtonManager.GetInstance().AddItem(url);
        }
    }
}
