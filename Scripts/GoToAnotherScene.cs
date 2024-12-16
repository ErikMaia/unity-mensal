using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToAnotherScene : MonoBehaviour
{
    public PlayerScriptableObject player;
    private bool isInFontTheDoor;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isInFontTheDoor = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(isInFontTheDoor && Input.GetKey(KeyCode.E)){
            player.position = transform.position + transform.up * 2;
            SceneManager.LoadScene("Lab_Info");
        }
    }

    private void OnTriggerEnter(Collider other) {
        isInFontTheDoor = true;
    }
    private void OnTriggerExit(Collider other) {
        isInFontTheDoor = false;
    }
}
