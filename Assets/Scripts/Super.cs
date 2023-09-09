using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Super : MonoBehaviour
{
    [SerializeField] private BoxCollider2D foodSpawn;
    public float score;
    public TextMeshProUGUI scoreText;
    

    
    void Start()
    {
        RandomPose();
    }

    // Update is called once per frame
    void Update()
    {
        if (scoreText != null)
        {
            scoreText.text = "" + score;
        }
    }


    private void RandomPose()
    {
        Bounds bounds = this.foodSpawn.bounds;

        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);
        this.transform.position = new Vector3(Mathf.Round(x), Mathf.Round(y), 0.0f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
          
          RandomPose();
          score = score + 2;
            
        }
    }
}