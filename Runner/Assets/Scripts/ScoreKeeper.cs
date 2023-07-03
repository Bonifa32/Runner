using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private TextMeshProUGUI _scoreText;

    private void FixedUpdate()
    {
        _scoreText.text = "Score: " + ((int)(player.position.x)).ToString();
    }
}
