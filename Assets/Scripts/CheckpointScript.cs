using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class CheckpointScript : MonoBehaviour
{
    [SerializeField] int distance;


    [SerializeField] GameObject ScoreMenu;
    ScoreCheck scores;

    [SerializeField] float baseScore;
    float currentScore;

    private float timer = 0f;

    void Start()
    {
        scores = ScoreMenu.GetComponent<ScoreCheck>();
        currentScore = baseScore;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        currentScore = baseScore - timer;

        if (currentScore < 0)
            currentScore = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //only if it collides with the player
        if (collision.name == "player")
        {
            scores.speedScore += currentScore;
            Debug.Log("Time Bonus: " + currentScore);

            timer = 0f;
            currentScore = baseScore;

            transform.position = new Vector3(transform.position.x - distance, transform.position.y, 1);
        }
    }
}
