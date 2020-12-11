using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetrominoSpawner : MonoBehaviour
{
    [SerializeField] private Transform[] Tetrominos;

    [SerializeField] private TetrominoMovement tetrominoController;

    public void Start()
    {
        SpawnTetromino();
    }

    public void SpawnTetromino()
    {
        int randomTetromino = Random.Range(0, Tetrominos.Length);
        Transform newTetromino = Instantiate(Tetrominos[randomTetromino],transform.position, Quaternion.identity);
        tetrominoController.ProvideTetromino(newTetromino);
    }


}
