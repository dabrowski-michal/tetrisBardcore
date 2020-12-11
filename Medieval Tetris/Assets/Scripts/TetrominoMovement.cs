using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetrominoMovement : MonoBehaviour
{

    private Transform activeTetromino;
    private float previousTime;
    public Vector3 rotationPoint;

    [SerializeField] private float fallTime;
    [SerializeField] private float accelerationFactor;
    public TetrominoProvider tetrominoProvider;
    public TetrisGrid tetrisGrid;

    public void SetActiveTetromino(Transform newActiveTetromino)
    {
        activeTetromino = newActiveTetromino;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            MoveTetromino(new Vector3(-1, 0, 0));
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            MoveTetromino(new Vector3(+1, 0, 0));
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            RotateTetromino();
        }

        if (Time.time - previousTime > (Input.GetKey(KeyCode.DownArrow) ? fallTime / accelerationFactor : fallTime))
        {
            activeTetromino.transform.position += new Vector3(0, -1, 0);
            if (!tetrisGrid.AllowMovement(activeTetromino))
            {
                StopActiveTetrominoMovement();
            }
            previousTime = Time.time;
        }
    }

    public void MoveTetromino(Vector3 vectorMovement)
    {
        activeTetromino.transform.position += vectorMovement;
        if (!tetrisGrid.AllowMovement(activeTetromino))
        {
            activeTetromino.transform.position -= vectorMovement;
        }
    }
    public void RotateTetromino()
    {
        activeTetromino.transform.RotateAround(activeTetromino.transform.TransformPoint(rotationPoint), new Vector3(0, 0, 1), 90);
        if (!tetrisGrid.AllowMovement(activeTetromino)) activeTetromino.transform.RotateAround(activeTetromino.transform.TransformPoint(rotationPoint), new Vector3(0, 0, 1), -90);
    }

    public void StopActiveTetrominoMovement()
    {
        activeTetromino.transform.position -= new Vector3(0, -1, 0);
        tetrisGrid.AddToGrid(activeTetromino);
        tetrominoProvider.ProvideTetromino(); 
    }
}
