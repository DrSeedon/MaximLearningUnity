using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SettingManager : MonoBehaviour
{
    public AddImage AddImage;
    public TimeManager TimeManager;
    public Settings settingsInstance = new Settings();

    private string dirSettings;

    void Awake()
    {
        UpdateSettings();
    }

    public void UpdateSettings()
    {
        dirSettings = Application.streamingAssetsPath + "/settings.json";
        if (!File.Exists(dirSettings))
        {
            CreateFile();
            return;
        }

        settingsInstance = new Settings();
        settingsInstance = JsonUtility.FromJson<Settings>(JsonHelper.FromJsonFile(dirSettings));
        
        AddImage.horizontalCount = settingsInstance.countImageInRow;
        AddImage.isNotRepeating = settingsInstance.isNotRepeating;
        TimeManager.maxCount = settingsInstance.timer;
    }

    private void CreateFile()
    {
        JsonHelper.ToJsonFile(dirSettings, settingsInstance);
    }
}

public class Settings
{
    public int countImageInRow = 12;
    public bool isNotRepeating = true;
    public float timer = 60;
}