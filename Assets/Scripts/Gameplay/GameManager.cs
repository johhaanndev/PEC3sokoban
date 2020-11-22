using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool readyForInput;
    private Player player;
    private bool isWin;

    public GameObject winMenu;
    public GameObject pauseMenu;
    private bool isPaused;

    private Box box;

    private void Start()
    {
        player = FindObjectOfType<Player>();
        winMenu.SetActive(false);
        pauseMenu.SetActive(false);
        isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveInput.Normalize();
        if (!isPaused)
        {

            if (moveInput.sqrMagnitude > 0.5)
            {
                // if the player is holding, then we make the input false so it can move only 1 at a time
                if (readyForInput)
                {
                    readyForInput = false;
                    player.Move(moveInput);
                }
            }
            else
            {
                readyForInput = true;
            }
        }
        if (CheckWin())
        {
            winMenu.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                isPaused = false;
                pauseMenu.SetActive(false);
            }
            else
            {
                pauseMenu.SetActive(true);
                isPaused = true;
            }
        }
    }

    // Return true if player made all boxes in goal, false if did not
    private bool CheckWin()
    {
       
        GameObject[] box = GameObject.FindGameObjectsWithTag("Box");
        //Debug.Log(box.Length); // manual debug
        for (int i = 0; i < box.Length; i++)
        {
            if (box[i].GetComponent<SpriteRenderer>().color == Color.black)
            {
                return false;
            }
        }
        return true;
    }
}
