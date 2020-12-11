using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private int currentScore;
    [SerializeField] private Text scoreText;
    [SerializeField] private AudioClip tetrisSound, tripleSound, doubleSound, singleSound;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        currentScore = 0;
        UpdateScoreText();
    }

    public void RowsHasBeenDestroyed(int numberOfRowsDestroyed)
    {
        switch (numberOfRowsDestroyed)
        {
            case 1:
                ScoreSingle();
                break;
            case 2:
                ScoreDouble();
                break;
            case 3:
                ScoreTriple();
                break;
            case 4:
                ScoreTetris();
                break;
            default:
                Debug.LogError("Impossible. User destroyed more than 4 rows in a turn.");
                break;
        }
        UpdateScoreText();
    }



    public void UpdateScoreText()
    {
        scoreText.text = currentScore.ToString();
    }

    public void ScoreSingle()
    {
        currentScore = currentScore + 40;
        PlayAudioClip(singleSound);
    }
    public void ScoreDouble()
    {
        currentScore = currentScore + 100;
        PlayAudioClip(doubleSound);
    }

    public void ScoreTriple()
    {
        currentScore = currentScore + 300;
        PlayAudioClip(tripleSound);
    }

    public void ScoreTetris()
    {
        currentScore = currentScore + 1200;
        PlayAudioClip(tetrisSound);
    }

    public void PlayAudioClip(AudioClip audioClip)
    {
        audioSource.clip = audioClip;
        audioSource.Play();
    }


}
