using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using VoxelParkour;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    public List<string> sceneNames;

    private ObjectPoolManager _pooler;
    private int _currentScene = 0;
    private int _furthestLevel = 1;

    // Save Data
    private LevelSavaData _saveData;
    private string _saveFilePath;

    // Awake -- Runs before Start()
    private void Awake()
    {
        // If our Instance is Null
        if (instance == null)
        {
            // Set our Instance, Do not Destory it
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        // Else, we have a Pool Instance
        else
        {
            // Self Destruct
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // Get our Pooler
        if (ObjectPoolManager.instance != null)
        {
            _pooler = ObjectPoolManager.instance;
        }

        // Define our File Path.
        _saveFilePath = Application.persistentDataPath + "/LevelSaveData.json";

        // Load the Data
        LoadProgress();

        // Load Scene
        // LoadScene("SampleScene");
    }

    // Head to GameStart (Main Menu)
    private void Update()
    {
        if (Input.GetButtonDown("Cancel") && _currentScene != 0)
        {
            // Go To Scene 0
            LoadScene(sceneNames[0]);

            // Unlock Cursor
            Cursor.lockState = CursorLockMode.None;
        }
    }

    // Load Scene -- Only Function that should Access SceneManager.LoadScene()
    private void LoadScene(string name)
    {
        for (int i = 0; i < sceneNames.Count; i++)
        {
            if (name == sceneNames[i])
            {
                // Deactivate Pool
                _pooler.DeactivatePool();

                // Load Scene
                SceneManager.LoadScene(sceneNames[i]);
                _currentScene = i;

                // Save that Data
                SaveProgress();
            }
        }
    }

    /*  PUBLIC FUNCTIONS */
    public void LoadNextScene()
    {
        if (_currentScene < sceneNames.Count - 1)
        {
            _currentScene++;

            // Store Current Scene as Furthest Level
            if (_currentScene > _furthestLevel)
            {
                _furthestLevel = _currentScene;
            }

            LoadScene(sceneNames[_currentScene]);
        }
        else
        {
            // To Main Menu
            LoadScene(sceneNames[0]);
        }
    }

    public void GetScene(string name)
    {
        int index = 0;
        for (int i = 0; i < sceneNames.Count; i++)
        {
            if (name == sceneNames[i])
            {
                index = i; break;
            }
        }

        if (index > _furthestLevel)
        {
            Debug.Log($"Requested Level ({sceneNames[index]}) is more than Furthest.");
        }
        else
        {
            LoadScene(sceneNames[index]);
        }
    }

    public void SaveProgress()
    {
        _saveData.furthestLevel = _furthestLevel;

        // Stringify and Write
        string data = JsonUtility.ToJson(_saveData);
        File.WriteAllText(_saveFilePath, data);

        // Debug Message
        Debug.Log($"Saved. Furthest Level: {_furthestLevel} - {sceneNames[_furthestLevel]}\nPath: {_saveFilePath}");
    }

    public void LoadProgress()
    {
        // If we have a Save File...
        if (File.Exists(_saveFilePath))
        {
            // Read that file and Parse
            string data = File.ReadAllText(_saveFilePath);
            _saveData = JsonUtility.FromJson<LevelSavaData>(data);

            // Parse
            _furthestLevel = _saveData.furthestLevel;

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
        _saveData = new LevelSavaData();
        _saveData.furthestLevel = 0;

        // Debug Message
        Debug.Log("Save Information Created.");

        // Call Save Game
        SaveProgress();
    }

}
