using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Record : MonoBehaviour {
    
	void Start () {

        GetComponent<Text>().text = PlayerPrefs.GetInt("Record").ToString();
	}
	
}
