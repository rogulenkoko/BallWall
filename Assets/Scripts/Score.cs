using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Score : MonoBehaviour {

    public int score = 0;
    public Text GameScore;

    void Start()
    {
        if (PlayerPrefs.GetString("Sound") != "on")
            return;
        GetComponent<AudioSource>().Play();
        GetComponent<AudioSource>().loop = true;
    }

}
