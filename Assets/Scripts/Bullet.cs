using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using static UnityEngine.UI.GridLayoutGroup;

public class Bullet : MonoBehaviour, IBullet
{
    public float speed = 8f;
    public float lifetime = 5f;
    public float force = 500000f;

    private float _timer = 0f;
    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;

        Move();

        // Deactivate after Lifetime
        if (_timer >= lifetime)
        {
            _timer = 0f;
            gameObject.SetActive(false);
        }
    }

    private void Move()
    {
        Vector3 move = transform.forward * speed * Time.deltaTime;
        transform.position += move;
    }

    // Collision Detection
    public void OnTriggerEnter(Collider other)
    {
        Block block = other.GetComponent<Block>();
        Dispenser dispenser = other.GetComponent<Dispenser>();
        PlayerMovement playerMover = other.GetComponent<PlayerMovement>();

        if (block != null && dispenser == null)
        {
            gameObject.SetActive(false);
        }
    }
}
