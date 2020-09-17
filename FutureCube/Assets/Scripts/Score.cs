using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static Score score;
    public Transform player;
    public Text scoreText;
    public float pos;

    void Start()
    {
        score = this;
    }

    void Update()
    {
        pos = (player.position.z - 10);

        if (pos > 0) { scoreText.text = DisplayScore(pos); }
    }

    string DisplayScore(float pos) => pos.ToString("n0").Replace(',', '.');
}
