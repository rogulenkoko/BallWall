using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Buttons : MonoBehaviour {

    public GameObject soundOn;
    public GameObject soundOff;

    void Start()
    {
        if(gameObject.name== "Sound")
        if (PlayerPrefs.GetString("Sound") == "on")
            setMusicOn();
        else setMusicOff();
        
    }

	void OnMouseDown()
    {
        if (PlayerPrefs.GetString("Sound") == "on")
            GetComponent<AudioSource>().Play();
        Debug.Log("asda");
        switch (gameObject.name)
        {
            case "Replay":
                SceneManager.LoadScene("main");
                break;
            case "Home":
                SceneManager.LoadScene("mainMenu");
                break;
            case "Start":
                SceneManager.LoadScene("main");
                break;
            case "Sound":
                if (PlayerPrefs.GetString("Sound") != "off")
                    setMusicOff();
                else setMusicOn();
                break;
            case "Exit":
                Application.Quit();
                break;
            case "Star":
                Debug.Log("dasd");
                Application.OpenURL("https://play.google.com/store/apps/details?id=com.trueaxis.trueskate&hl=ru");
                break;
        }
    }


    void setMusicOn()
    {
        PlayerPrefs.SetString("Sound", "on");
        soundOn.SetActive(true);
        soundOff.SetActive(false);
    }

    void setMusicOff()
    {
        PlayerPrefs.SetString("Sound", "off");
        soundOn.SetActive(false);
        soundOff.SetActive(true);
    }
}
