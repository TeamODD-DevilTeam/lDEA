using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SettingsManager : MonoBehaviour {

    protected class OptionData {
        public float bgm = 0.6f;
        public bool useless = false;
    }

    OptionData data = new();

    protected void SetVolume(float value) {
        data.bgm = value;
        Save();
    }

    protected void SetUseless(bool value) {
        data.useless = value;
        Save();
    }

    protected void Save() {
        string save = JsonUtility.ToJson(data);
        byte[] bytes = System.Text.Encoding.UTF8.GetBytes(save);
        File.WriteAllBytes(GetPath(), bytes);
    }

    protected OptionData Load() {
        if (!File.Exists(GetPath())) {
            data.bgm = 0.6f; 
            data.useless = false;
        } else {
            byte[] load = File.ReadAllBytes(GetPath());
            data = JsonUtility.FromJson<OptionData>(System.Text.Encoding.UTF8.GetString(load));
        }
        return data;
    }

    string GetPath() { return Application.persistentDataPath + "/options.data"; }

    public float GetVolume() { 
        Load();
        return data.bgm;
    }

    public bool GetUseless() {
        Load();
        return data.useless;
    }
}
