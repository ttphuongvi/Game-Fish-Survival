using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateScore : MonoBehaviour
{
    // Start is called before the first frame update
    public int score = 0;
    public Text textScore;
    void Start()
    {
        UpdateTextScore();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A)) {
            score += 1;
            UpdateTextScore();
        }
    }

    void UpdateTextScore() {
        textScore.text = "Score: " + score;
    }
}
