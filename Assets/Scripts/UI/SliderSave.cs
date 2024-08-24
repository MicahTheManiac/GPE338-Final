using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using VoxelParkour;

/*  I'M SURE THERE IS A MORE OBJECT ORIENTED WAY TO DO THIS, BUT I NEED TO GET
 *  THIS PROJECT DONE. THIS CODE IS GONNA BE A WRECK. I hate UI...
 */

public class SliderSave : MonoBehaviour
{
    private Slider _slider;
    private OptionsSaveData _saveData;
    private string _saveFilePath;

    void Start()
    {
        _slider = GetComponent<Slider>();

        // Save File Path
        _saveFilePath = Application.persistentDataPath + "/Options.json";

        // Load Data
        LoadData();
    }

    public void SaveData()
    {
        _saveData.mouseSensitivity = _slider.value;

        // Stringify and Write
        string data = JsonUtility.ToJson(_saveData);
        File.WriteAllText(_saveFilePath, data);

        // Debug Message
        Debug.Log($"Saved. Sensitvity: {_slider.value}\nPath: {_saveFilePath}");
    }

    public void LoadData()
    {
        // If we have a Save File...
        if (File.Exists(_saveFilePath))
        {
            // Read that file and Parse
            string data = File.ReadAllText(_saveFilePath);
            _saveData = JsonUtility.FromJson<OptionsSaveData>(data);

            // Parse
            _slider.value = _saveData.mouseSensitivity;

            // Debug Message
            Debug.Log("Save File Exists and was Loaded.");
        }
        // If we don't///
        else
        {
            // Debug Message
            Debug.Log("Save File Not Found!");

            // Create Save
            CreateSaveFile();
        }
    }

    private void CreateSaveFile()
    {
        _saveData = new OptionsSaveData();
        _saveData.mouseSensitivity = 500;

        // Debug Message
        Debug.Log("Save Information Created.");

        // Call Save Game
        SaveData();
    }
}
