using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public AudioClip destructionSFX;

      public float offScreenMargin = 1f; 

    // Reference to the QuitButton script
    public QuitButton quitButton;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("I Collided!");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("I was triggered!");

        if (collision.tag == "Laser")
        {
            Destroy(gameObject);

            Destroy(collision.gameObject);

            AudioSource.PlayClipAtPoint(destructionSFX, transform.position);
        }
    }

    void Update()
    {
        // Check if the enemy is off the screen and trigger game over if true
        CheckIfOffScreen();
    }

    void CheckIfOffScreen()
    {
        // Get the enemy's position in the viewport space
        Vector3 screenPos = Camera.main.WorldToViewportPoint(transform.position);

        // If the enemy is outside the screen (using a margin for buffer)
        if (screenPos.x < -offScreenMargin || screenPos.x > 1 + offScreenMargin || screenPos.y < -offScreenMargin || screenPos.y > 1 + offScreenMargin)
        {
            EndGame();
        }
    }

    // Ending of the game
    void EndGame()
    {
        // Log the game over message or trigger actual game over logic
        Debug.Log("Game Over! Enemy went off screen.");

        // Quit Trigger to quit game after the event
        if (quitButton != null)
        {
            quitButton.QuitGame();
        }

        // Stop the game
        Time.timeScale = 0f;
    }
}
