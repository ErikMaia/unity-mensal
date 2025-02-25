using UnityEngine;

public class SetWeapon : MonoBehaviour
{
    private bool _isContactWithPlayer;
    public float FireRate;
    public GameObject prefab;
    public int price;
    public PlayerScriptableObject playerData;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _isContactWithPlayer = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (_isContactWithPlayer && Input.GetKeyDown(KeyCode.E) && playerData.points >= price)
        {
            playerData.fireRate = FireRate;
            playerData.Weapons = prefab;
            playerData.points -= price;
            gameObject.SetActive(false);
            Debug.Log($"SetWeapon: {gameObject.name}");
        }
    }

    
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _isContactWithPlayer = true;
            Debug.Log("Weap: true");
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _isContactWithPlayer = false;
            Debug.Log("Weap: false");
        }
    }
}
