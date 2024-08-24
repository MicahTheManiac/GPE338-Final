using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dispenser : MonoBehaviour
{
    public float fireRate = 1f;

    private ObjectPoolManager _pooler;

    // Start is called before the first frame update
    void Start()
    {
        if (ObjectPoolManager.instance != null)
        {
            _pooler = ObjectPoolManager.instance;
        }
    }

    float _timer = 0f;

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;

        if (_timer >= fireRate)
        {
            _timer = 0f;

            if (_pooler != null)
            {
                _pooler.AccessPool(transform.position, transform.rotation);
            }
        }
    }
}
