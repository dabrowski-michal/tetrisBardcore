using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public void RowsHasBeenDestroyed(int numberOfRowsDestroyed)
    {
        Debug.Log("You destroyed " + numberOfRowsDestroyed + " rows in a row!");
        switch (numberOfRowsDestroyed)
        {
        }
    }
}
