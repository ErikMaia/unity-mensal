using UnityEngine;

public class ColetableObject : MonoBehaviour
{
    public float price;
    public PlayerScriptableObject player;
    
    private bool isOnTheObject;
    private void OnTriggerEnter(Collider other) {
        isOnTheObject = true;
    }

    private void OnTriggerExit(Collider other) {
        isOnTheObject = false;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        price = float.Parse(Random.Range(0,1000).ToString());
        isOnTheObject = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(isOnTheObject && Input.GetKey(KeyCode.E)){
            colectObject();
        }
    }

    private void colectObject(){
        gameObject.SetActive(false);
        player.value += price;
    }
}
