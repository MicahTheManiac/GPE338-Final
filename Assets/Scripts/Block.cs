using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public Material defaultMaterial;
    public Material[] materials;

    // Start is called before the first frame update
    void Start()
    {
        GetMaterial();
    }

    public void GetMaterial()
    {
        Renderer renderer = GetComponent<Renderer>();
        renderer.material = materials[Random.Range(0, materials.Length)];
    }

    public void Reset()
    {
        Renderer renderer = GetComponent<Renderer>();
        renderer.material = defaultMaterial;
    }
}
