using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreCheck : MonoBehaviour
{
    private float SurvivalScore;

    [SerializeField]
    private TMP_Text ScoreDisplay;

    [SerializeField]
    private TMP_Text TotalScore;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TotalScore.SetText($"TOTAL SCORE: {SurvivalScore}" );

        //ScoreDisplay.SetText($"SCORE: {SurvivalScore}");

        ScoreDisplay.SetText("SCORE: " + SurvivalScore.ToString("F0"));
    }

    private void FixedUpdate()
    {
        SurvivalScore = Time.time;
    }
}
