using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] float xClampRange = 8;
    [SerializeField] float yClampRange = 5;

    bool isPressLeft => Input.GetKeyDown(KeyCode.A);
    bool isPressRight => Input.GetKeyDown(KeyCode.D);
    bool isPressUp => Input.GetKeyDown(KeyCode.W);
    bool isPressDown => Input.GetKeyDown(KeyCode.S);

    bool isGameOver;

    void Update()
    {
        if(isGameOver)
            return;

        Vector2 newPos = transform.position;

        if(isPressLeft)
            newPos.x--;
        else if(isPressRight)
            newPos.x++;
        else if(isPressUp)
            newPos.y++;
        else if(isPressDown)
            newPos.y--;

        newPos.x = Mathf.Clamp(newPos.x, -xClampRange, xClampRange);
        newPos.y = Mathf.Clamp(newPos.y, -yClampRange, yClampRange);

        transform.position = newPos;
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag("Car"))
        {
            isGameOver = true;
            Debug.Log("Game Over !");
            Invoke("RestartGame",1);
        }
        else if(other.gameObject.CompareTag("Goal"))
        {
            FindObjectOfType<GameManager>().IncreaseScore();
        }
    }

    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
