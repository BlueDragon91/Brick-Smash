using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Scoring : MonoBehaviour
{
    //private readonly GameManager man;
    public TMP_Text Score;
    //private int points = 0;

    private void Update()
    {
        Score.text = FindAnyObjectByType<GameManager>().scores.ToString();
    }
}
