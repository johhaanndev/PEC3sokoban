using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    // variable to check if is in goal spot
    private bool OnGoal;

    public bool Move(Vector2 direction)
    {
        // if in the direction we are blocked
        if (BoxBlocked(transform.position, direction))
        {
            return false;
        }
        else
        {
            transform.Translate(direction);
            TestForOnCross();
            return true;
        }
    }

    public bool BoxBlocked(Vector3 position, Vector2 direction)
    {
        Vector2 newPos = new Vector2(position.x, position.y) + direction;
        
        // check if box is hitting a wall
        GameObject[] walls = GameObject.FindGameObjectsWithTag("Wall");

        foreach (var wall in walls)
        {
            if (wall.transform.position.x == newPos.x && wall.transform.position.y == newPos.y)
            {
                return true;
            }
        }

        //check if box is hitting another box
        GameObject[] boxes = GameObject.FindGameObjectsWithTag("Box");
        foreach (var box in boxes)
        {
            if (box.transform.position.x == newPos.x && box.transform.position.y == newPos.y)
            {
                return true;
            }
        }
        return false;
    }

    void TestForOnCross()
    {
        GameObject[] crosses = GameObject.FindGameObjectsWithTag("boxGoal");

        foreach (var cross in crosses)
        {
            if (transform.position.x == cross.transform.position.x && transform.position.y == cross.transform.position.y)
            {
                OnGoal = true;
                GetComponent<SpriteRenderer>().color = Color.red;
                return;
            }
        }
        GetComponent<SpriteRenderer>().color = Color.black;
        OnGoal = false;
    }
}
