using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    public Transform player;
    public Text scoreText;
    private float pos;

    void Update()
    {
        pos = (player.position.z - 10);

        if (pos > 0) { scoreText.text = pos.ToString("0"); }
    }
}
