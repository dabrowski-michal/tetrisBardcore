using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetrominoSpawner : MonoBehaviour
{
    [SerializeField] private TetrisBlock[] Tetrominos; 

    public void Start()
    {
        SpawnTetromino();
    }

    public void SpawnTetromino()
    {
        int randomTetromino = Random.Range(0, Tetrominos.Length);
        Instantiate(Tetrominos[randomTetromino],transform.position, Quaternion.identity);
    }
}
