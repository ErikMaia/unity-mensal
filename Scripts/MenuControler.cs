using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControler : MonoBehaviour
{
    public string level;
    public PlayerScriptableObject player;
    public void startGame()
    {
        SceneManager.LoadScene(level);
    }

    public void leaveGame()
    {
        Application.Quit();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player.dias = 0;
        player.value = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
