using TMPro;
using UnityEngine;

public class ShowValues : MonoBehaviour
{

    public PlayerScriptableObject player;
    public TextMeshProUGUI dias;
    public TextMeshProUGUI valor;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        dias.text = $"Dia: {player.dias}";
        valor.text = $"Valor: {player.value}";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
