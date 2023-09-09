using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;


public class Snake : MonoBehaviour
{
    [SerializeField] private float speed;

    private Rigidbody2D _rigidbody2D;
    private List<Transform> _snakeSpawn;
    public Transform snakePrefab;

    InputChannel inputChannel;
    [SerializeField] private InputActionReference moveActionReference;
    void Start()
    {
        var beacon = FindObjectOfType<BeaconSO>();
        inputChannel = beacon.inputChannel;
        inputChannel.MoveEvent += HandleMovement; 

        _rigidbody2D = GetComponent<Rigidbody2D>();
        _rigidbody2D.velocity = new Vector2(speed, 0);
        
        _snakeSpawn = new List<Transform>();
        _snakeSpawn.Add(this.transform);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveInput =  moveActionReference.action.ReadValue<Vector2>();
        HandleMovement(moveInput);
    }


    private void FixedUpdate()
    {
        for (int i = _snakeSpawn.Count - 1; i > 0; i--)
        {
            _snakeSpawn[i].position = _snakeSpawn[i - 1].position;
        }
        _snakeSpawn[0].position = _rigidbody2D.position;
        
    }

    private void grow()
    {
        Transform snakeSpawn = Instantiate(this.snakePrefab);
        snakeSpawn.position = _snakeSpawn[_snakeSpawn.Count - 1].position;
        
        _snakeSpawn.Add(snakeSpawn);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Food" || other.gameObject.tag == "Super" )
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
    private void HandleMovement(Vector2 dir)
    {
        dir.Normalize();
        _rigidbody2D.velocity = new Vector2(dir.x * speed, dir.y * speed);
    }
   
}