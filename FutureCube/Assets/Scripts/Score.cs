using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	public Transform player;
	public Text scoreText;
	
    private float Temp;
	// Update is called once per frame
	void Update () {

        Temp = player.position.z;

        scoreText.text = Temp.ToString("0");
	}
}
