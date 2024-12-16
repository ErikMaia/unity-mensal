using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public PlayerScriptableObject player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(player.dias>5 && player.value<5){
            SceneManager.LoadScene("Morte_Menu");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
