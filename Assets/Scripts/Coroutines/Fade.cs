using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float fadeAmount = 0.01f;
    public float fadeIntervalTime = 0.25f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Fade());
    }

    /* Fade Method
     * The example from Unity Documentation,
     * but tweaked to fit my needs.
    */
    IEnumerator Fade()
    {
        // Set this var so Unity stops complaining
        Renderer renderer = GetComponent<Renderer>();

        // Get the Color in var 'c'
        Color c = renderer.material.color;

        // For Loop to decreate 'alpha'
        for (float n = 0; n <= 1 + fadeAmount; n += fadeAmount)
        {
            // Set Alpha for 'c'
            n = Mathf.Clamp(n, 0, 1);
            c.a = n;
            renderer.material.color = c;

            // Yield Return
            yield return new WaitForSeconds(fadeIntervalTime);
        }

        // For my own sake
        Debug.Log(gameObject.name + ": Coroutine Finished!");

        // Stop Myself
        StopCoroutine(Fade());
    }
}