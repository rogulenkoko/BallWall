using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuScores : MonoBehaviour {

    public Text maxscore;
    public Text score;
	void Start () {
        maxscore.text = "Maxscore: " + PlayerPrefs.GetInt("Record");
        score.text = "Score: " + PlayerPrefs.GetInt("Score");
        if(PlayerPrefs.GetInt("Score") == PlayerPrefs.GetInt("Score"))
        {
            Color purple =new Color(191.000f, 68.000f, 242.000f, 255.000f);
            var sum = purple.r + purple.g + purple.b;
            purple = purple * (1 / sum);
            maxscore.color = purple;
            score.color = purple;
        }
    }
}
