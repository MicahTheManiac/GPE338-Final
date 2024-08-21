using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OscilateFade : MonoBehaviour
{
    float baseAlpha = 0.9f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Fade());
    }

    IEnumerator Fade()
    {
        Renderer renderer = GetComponent<Renderer>();
        Color c = renderer.material.color;

        while (true)
        {
            float animation = baseAlpha + Mathf.Sin(Time.time * 2f);

            animation = Mathf.Clamp01(animation);

            c.a = animation;
            renderer.material.color = c;

            // Debug.Log(c.a);

            yield return null;
        }
    }
}
