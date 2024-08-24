using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEditor;
using UnityEngine;

public class Replay : MonoBehaviour, IReplay
{
    // Public
    public KeyCode keyRecord = KeyCode.I;
    public KeyCode keyStop = KeyCode.O;
    public KeyCode keyPlay = KeyCode.P;

    public GameObject replayObject;

    public GameObject canvas;

    // Private
    private float _recordInterval = 0.01f;
    private List<Vector3> _cache;
    private bool _isRecording = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*  COMMENTED OUT -- FEEL FREE TO CHANGE IF MESSING WITH PROJECT
        // Start Recording
        if (Input.GetKeyDown(keyRecord))
        {
            ReplayStartRecording(true);
        }
        // Stop Recording
        if (Input.GetKeyDown(keyStop))
        {
            ReplayStartRecording(false);
        }
        // Play Recording
        if (Input.GetKeyDown(keyPlay))
        {
            ReplayPlayback(true);
        }
        // COMMENT */

    }

    // ReplayStartRecording() -- Public Function to be accessed by other Scripts
    public void ReplayStartRecording(bool start)
    {
        if (start == true && _isRecording == false)
        {
            _isRecording = true;
            StartCoroutine(RecordReplay());
        }
        else if (start == false && _isRecording == true)
        {
            _isRecording = false;
        }
    }

    // ReplayPlayback() -- Public Function to be accessed by other Scripts
    public void ReplayPlayback(bool start)
    {
        if (start && !_isRecording)
        {
            StartCoroutine(PlayReplay());
        }
        else if (!start && !_isRecording)
        {
            StopCoroutine(PlayReplay());
        }
        else
        {
            Debug.Log("Recording in Progress!");
        }
    }

    // ReplayGetSeconds() -- Public Function to be accessed by other Scripts
    public float ReplayGetSeconds()
    {
        if (!_isRecording)
        {
            if (_cache != null)
            {
                return (float)_cache.Count * _recordInterval;
            }
            else
            {
                return 0;
            }
        }
        else
        {
            Debug.Log("Still Recording. Returning 10s.");
            return 10f;
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
            canvas.SetActive(true);

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
