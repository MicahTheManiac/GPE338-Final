using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using VoxelParkour;

/*  Mouse Look Script :: Controls the Camera for the First Person Player
 *  Reference: Brackeys - https://www.youtube.com/watch?v=_QajrabyTJc
 */
public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity;
    public Transform playerBody;

    private float _xRotation = 0f;

    private OptionsSaveData _saveData;
    private string _saveFilePath;


    // Start is called before the first frame update
    void Start()
    {
        // Hide and Lock Cursor
        Cursor.lockState = CursorLockMode.Locked;

        // Save File Path
        _saveFilePath = Application.persistentDataPath + "/Options.json";

        // Load Data
        LoadData();
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        _xRotation -= mouseY;
        _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }

    private void LoadData()
    {
        // If we have a Save File...
        if (File.Exists(_saveFilePath))
        {
            // Read that file and Parse
            string data = File.ReadAllText(_saveFilePath);
            _saveData = JsonUtility.FromJson<OptionsSaveData>(data);

            // Parse
            mouseSensitivity = _saveData.mouseSensitivity;

            // Debug Message
            Debug.Log("Options Data File Exists and was Loaded.");
        }
        // If we don't///
        else
        {
            // Debug Message
            Debug.Log("Options Data File Not Found!");
        }
    }
}
