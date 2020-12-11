using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetrominoProvider : MonoBehaviour
{
    [SerializeField] private Transform[] tetrominoPrefabs;
    [SerializeField] private Transform[] preparedBlocksPositions;
    [SerializeField] private List<Transform> preparedTetrominos;
    [SerializeField] private TetrominoMovement movementController;

    public void Start()
    {
        for(int i=0; i< preparedBlocksPositions.Length; i++)
        {
            preparedTetrominos.Add(GetRandomTetromino(i, preparedBlocksPositions[i].position));
        }
        ProvideTetromino();
    }

    public void ProvideTetromino()
    {
        preparedTetrominos[0].position = transform.position;
        movementController.SetActiveTetromino(preparedTetrominos[0]);
        ShiftPreparedTetrominos();
    }


    public void ShiftPreparedTetrominos()
    {
        preparedTetrominos[0] = preparedTetrominos[1];
        preparedTetrominos[0].transform.position = preparedBlocksPositions[0].position;

        preparedTetrominos[1] = preparedTetrominos[2];
        preparedTetrominos[1].transform.position = preparedBlocksPositions[1].position;

        preparedTetrominos[2] = GetRandomTetromino(2, preparedBlocksPositions[2].position);
        preparedTetrominos[2].transform.position = preparedBlocksPositions[2].position;
    }

    public Transform GetRandomTetromino(int i, Vector3 tetrominoPosition)
    {
        int randomIndex = Random.Range(0, tetrominoPrefabs.Length);
        Transform newTetromino = Instantiate(tetrominoPrefabs[randomIndex], tetrominoPosition, Quaternion.identity);
        return newTetromino;
    }


}
