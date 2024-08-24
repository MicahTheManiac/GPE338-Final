using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Trigger, IBullet
{
    public float speed = 8f;
    public float lifetime = 5f;

    private float _timer = 0f;

    // Start is called before the first frame update
    public override void Start()
    {
        
    }

    private void Update()
    {
        _timer += Time.deltaTime;

        // Deactivate after Lifetime
        if (_timer >= lifetime)
        {
            _timer = 0f;
            gameObject.SetActive(false);
        }

        Move();
    }

    private void Move()
    {
        Vector3 move = transform.forward * speed * Time.deltaTime;
        transform.position += move;
    }

    // Collision Detection
    public override void OnTriggerEnter(Collider other)
    {
        Block block = other.GetComponent<Block>();
        Dispenser dispenser = other.GetComponent<Dispenser>();
        PlayerMovement playerMove = other.GetComponent<PlayerMovement>();

        if (block != null && dispenser == null)
        {
            gameObject.SetActive(false);
        }

        // Only Disable Movement & Set Pos
        if (playerMove != null)
        {
            playerMove.GoToStartingPosition();
        }
    }
}
