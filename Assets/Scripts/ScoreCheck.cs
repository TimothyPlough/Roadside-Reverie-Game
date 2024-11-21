using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreCheck : MonoBehaviour
{
    private float SurvivalScore;
    public float speedScore;

    private float Totalscore;

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
        Totalscore = SurvivalScore + speedScore;

        //displayed on game over
        TotalScore.SetText("TOTAL SCORE: " + Totalscore.ToString("F0")
            +"\n Survival Score: " + SurvivalScore.ToString("F0") +
            "\n Speed Bonus: " + speedScore.ToString("F0"));

        //ScoreDisplay.SetText($"SCORE: {SurvivalScore}");

        //displayed during gameplay
        ScoreDisplay.SetText("SCORE: " + Totalscore.ToString("F0"));
    }

    private void FixedUpdate()
    {
        SurvivalScore = Time.timeSinceLevelLoad;
    }
}
