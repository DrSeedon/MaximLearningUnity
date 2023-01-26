using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

[Serializable]
public class Player
{
    public string playerId;
    public string playerLoc;
    public string playerNick;
}
[Serializable]
public class SpriteData
{
    public string sprite_name;
    public Vector2 sprite_size;
    public List<Vector2> subimage;
}
[Serializable]
public class SpriteDataCollection
{
    public SpriteData[] sprites;
}
public class JsonScript : MonoBehaviour
{
    public string nameTxt;
    string path;
    public Player playerInstance = new Player();
    public Player[] playerInstanceArray = new Player[2];
    string jsonString;

    void Start()
    {
        SpriteData data = new SpriteData();
        data.sprite_name = "idle";
        data.sprite_size = new Vector2(64.0f, 64.0f);
        data.subimage = new List<Vector2> { new Vector2(0.0f, 0.0f) };

        SpriteDataCollection col = new SpriteDataCollection();
        col.sprites = new SpriteData[] { data };

        var a = JsonUtility.ToJson(col, true);
        Debug.Log(a);



        path = Application.streamingAssetsPath + "/" + nameTxt + ".json";

        //������
        JsonHelper.ToJsonFile(path, playerInstance);

        Player player = JsonUtility.FromJson<Player>(JsonHelper.FromJsonFile(path));
        Debug.Log(player.playerNick);

        path = Application.streamingAssetsPath + "/" + nameTxt + "2.json";

        //������
        jsonString = JsonHelper.ToJson(playerInstanceArray, true);
        JsonHelper.ToJsonFile(path, jsonString);

        Player[] player2 = JsonHelper.FromJson<Player>(JsonHelper.FromJsonFile(path));

        for (int i = 0; i < player2.Length; i++)
        {
            Debug.Log(player2[i].playerNick);
        }


    }
}

