using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ObjectPoolManager : MonoBehaviour
{
    public static ObjectPoolManager instance;
    public List<GameObject> objects;
    public int numObjects;
    public GameObject prefab;

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
        InitPool();
        //GetObject(prefab, transform.position, transform.rotation); // Why?
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Initiate Pool Function
    private void InitPool()
    {
        // Create our Pool
        objects = new List<GameObject>();

        for (int i = 0; i < numObjects; i++)
        {
            // Instantiate an Object
            GameObject temp = Instantiate(prefab);

            // Prevent our Pool from Being Destroyed
            DontDestroyOnLoad(temp);

            // Start Inactive
            temp.SetActive(false);

            // Add to pool
            objects.Add(temp);
        }
    }

    // Get Object Function -- Would SetObject or ActivateObject be better?
    private GameObject GetObject(GameObject prefab, Vector3 position, Quaternion rotation)
    {
        // Search for Inactive Game Object
        foreach (GameObject obj in objects)
        {
            // If the object is Inactive
            if (!obj.activeInHierarchy)
             {
                // Set Values
                obj.name = prefab.name;

                Transform otf = obj.GetComponent<Transform>();

                otf.position = position;
                otf.rotation = rotation;

                // Activate Object
                obj.SetActive(true);

                // Return
                return obj;
            }
        }

        // Retun Null
        return null;

    }

    public void AccessPool(Vector3 position, Quaternion rotation)
    {
        GetObject(prefab, position, rotation);
    }

    public void DeactivatePool()
    {
        // Search for Inactive Game Object
        foreach (GameObject obj in objects)
        {
            // If the object is Inactive
            if (obj.activeInHierarchy)
            {
                // Set Values
                obj.name = prefab.name;

                Transform otf = obj.GetComponent<Transform>();

                otf.position = Vector3.zero;
                otf.rotation = Quaternion.identity;

                // Activate Object
                obj.SetActive(false);
            }
        }
    }
}
