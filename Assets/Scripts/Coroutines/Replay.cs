using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Replay : MonoBehaviour
{
    // Public
    public KeyCode keyRecord = KeyCode.I;
    public KeyCode keyStop = KeyCode.O;
    public KeyCode keyPlay = KeyCode.P;

    public GameObject replayObject;

    // Private
    float _recordInterval = 0.01f;
    List<Vector3> _cache;
    bool _isRecording = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Start Recording
        if (Input.GetKeyDown(keyRecord) && !_isRecording)
        {
            _isRecording = true;
            StartCoroutine(RecordReplay());
        }
        // Stop Recording
        if (Input.GetKeyDown(keyStop) && _isRecording)
        {
            _isRecording = false;
        }
        // Play Recording
        if (Input.GetKeyDown(keyPlay) & !_isRecording)
        {
            StartCoroutine(PlayReplay());
        }

    }

    IEnumerator RecordReplay()
    {
        if (_isRecording)
        {
            Debug.Log("Recording has Started.");
            _cache = new List<Vector3>();

            while (_isRecording == true)
            {
                _cache.Add(transform.position);

                yield return new WaitForSeconds(_recordInterval);

                if (!_isRecording)
                {
                    Debug.Log("Stopped Recording.");
                    StopCoroutine(RecordReplay());
                    break;
                }
            }
        }
        // Can't Else: No Code will Run, While Statement Quirk?
    }

    IEnumerator PlayReplay()
    {
        if (_cache == null)
        {
            Debug.Log("No Data to Play.");
            StopCoroutine(PlayReplay());
        }
        else
        {
            Vector3 pos = _cache[0];
            GameObject obj = Instantiate(replayObject, pos, Quaternion.identity);

            Debug.Log("Playing Replay Recording.");

            for (int i = 0; i < _cache.Count; i++)
            {
                obj.transform.position = _cache[i];

                yield return new WaitForSeconds(_recordInterval);
            }

            Debug.Log("Stopped Replay Recording.");
            Destroy(obj);

            StopCoroutine(PlayReplay());
        }
    }
}
