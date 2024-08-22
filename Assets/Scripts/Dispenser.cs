using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dispenser : MonoBehaviour
{
    private ObjectPoolManager _pooler;

    // Start is called before the first frame update
    void Start()
    {
        if (ObjectPoolManager.instance != null)
        {
            _pooler = ObjectPoolManager.instance;
        }
    }

    float _t = 0f;

    // Update is called once per frame
    void Update()
    {
        _t += Time.deltaTime;

        if (_t >= 3f)
        {
            _t = 0f;
            _pooler.AccessPool(transform.position, transform.rotation);
        }
    }
}
