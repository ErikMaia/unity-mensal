using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LeaveRoom : MonoBehaviour
{
    public PlayerScriptableObject player;
    public string scene;
    private void OnTriggerEnter(Collider other) {
        if(SceneManager.GetActiveScene().name == "Loby"){
            player.position = new Vector3(0.579999983f,26.0900002f,-1.75f);
            player.dias++;
        }

        ChangeScene();
    }

    public void ChangeScene(){
        SceneManager.LoadScene(scene);
    }

}
