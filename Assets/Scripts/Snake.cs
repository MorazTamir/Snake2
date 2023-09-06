using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Snake : MonoBehaviour
{
    [SerializeField] private float speed;

    private Rigidbody2D _rigidbody2D;
    private List<Transform> _snakeSpawn;
    public Transform snakePrefab;
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _rigidbody2D.velocity = new Vector2(speed, 0);
        
        _snakeSpawn = new List<Transform>();
        _snakeSpawn.Add(this.transform);
    }

    // Update is called once per frame
    void Update()
    {
       move();
    }


    private void FixedUpdate()
    {
        for (int i = _snakeSpawn.Count - 1; i > 0; i--)
        {
            _snakeSpawn[i].position = _snakeSpawn[i - 1].position;
        }
    }

    private void move()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            _rigidbody2D.velocity = new Vector2(0, speed);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            _rigidbody2D.velocity = new Vector2(0, -speed);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            _rigidbody2D.velocity = new Vector2(speed, 0);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            _rigidbody2D.velocity = new Vector2(-speed, 0);
        }
    }
    private void grow()
    {
        Transform snakeSpawn = Instantiate(this.snakePrefab);
        snakeSpawn.position = _snakeSpawn[_snakeSpawn.Count - 1].position;
        
        _snakeSpawn.Add(snakeSpawn);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Food")
        {
            grow();
        }
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Wall"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
