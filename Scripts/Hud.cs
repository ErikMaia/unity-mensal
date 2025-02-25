
using System;
using TMPro;
using UnityEngine;

public class Hud : MonoBehaviour
{
    public TMP_Text scoreText; // Alterado para TMP_Text
    public TMP_Text roundsText; // Alterado para TMP_Text
    public PlayerScriptableObject playerData;
    public EnemyData enemyData;

    void Start()
    {
        // Opcional: Certifique-se de que os componentes TextMeshPro foram atribuídos no Inspector.
        if (scoreText == null)
        {
            Debug.LogError("O componente scoreText não foi atribuído no Inspector!");
        }
        if (roundsText == null)
        {
            Debug.LogError("O componente roundsText não foi atribuído no Inspector!");
        }
    }

    void Update()
    {
        if (playerData != null) // Verification para evitar erros de null reference
        {
            if (scoreText != null)
            {
                scoreText.text = playerData.points.ToString();
            }

            if (roundsText != null)
            {
                double round = (enemyData.enemyKilled/5)+1;
                object value = Math.Ceiling(round);
                roundsText.text = value.ToString();
            }
        }
    }
}
    // Update is called once per frame
    // void Update()
    // {
    //     score.text = playerData.points.ToString();
    //     rounds.text = playerData.rounds.ToString();
    // }
// }
