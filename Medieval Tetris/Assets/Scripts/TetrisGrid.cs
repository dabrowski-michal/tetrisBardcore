using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetrisGrid : MonoBehaviour
{
    public static int width = 10;
    public static int height = 20;
    public static Transform[,] grid = new Transform[width, height];
    public ScoreManager scoreManager;

    public void AddToGrid(Transform tetromino)
    {
        foreach (Transform children in tetromino.transform)
        {
            int roundedX = Mathf.RoundToInt(children.transform.position.x);
            int roundedY = Mathf.RoundToInt(children.transform.position.y);

            grid[roundedX, roundedY] = children;
        }

        CheckForFullColumn();
        CheckForFullRowes();
    }

    public bool AllowMovement(Transform activeTetromino)
    {
        foreach (Transform children in activeTetromino.transform)
        {
            int roundedX = Mathf.RoundToInt(children.transform.position.x);
            int roundedY = Mathf.RoundToInt(children.transform.position.y);


            if (roundedX < 0 || roundedX >= width || roundedY < 0 || roundedY >= height)
            {
                return false;
            }

            if (grid[roundedX, roundedY] != null)
            {
                return false;
            }

        }
        return true;
    }

    public void CheckForFullColumn()
    {
    }

    public void CheckForFullRowes()
    {
        int numberOfFullRows =0;
        for (int i = height - 1; i >= 0; i--)
        {
            if (RowIsFull(i))
            {
                numberOfFullRows++;
                DestroyFullRow(i);
                MoveRowsDown(i);
            }
        }
        if (numberOfFullRows > 0) scoreManager.RowsHasBeenDestroyed(numberOfFullRows);
    }

    public bool RowIsFull(int i)
    {
        for (int j = 0; j < width; j++)
        {
            if (grid[j, i] == null)
            {
                return false;
            }
        }
        return true;
    }

    public void DestroyFullRow(int i)
    {
        for (int j = 0; j < width; j++)
        {
            Destroy(grid[j, i].gameObject);
            grid[j, i] = null;

        }
    }

    public void MoveRowsDown(int i)
    {
        for (int y = i; y < height; y++)
        {
            for (int j = 0; j < width; ++j)
            {
                if (grid[j, y] != null)
                {
                    grid[j, y].transform.position -= new Vector3(0, 1, 0);
                    grid[j, y - 1] = grid[j, y];
                    grid[j, y] = null;
                }
            }
        }
    }


}
