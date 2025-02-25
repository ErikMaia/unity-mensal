using System.Diagnostics;
using UnityEngine;
using UnityEngine.AI;

public class SpawnController : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform player; // Referência ao jogador
    public float spawnInterval = 5f;
    public float minDistance = 3f;
    public float maxDistance = 20f;

    void Start()
    {
        // Certifique-se de que o jogador foi atribuído no Inspector
        if (player == null)
        {
            UnityEngine.Debug.LogError("O jogador não foi atribuído no Inspector!");
            return; // Sai do Start para evitar erros
        }

        InvokeRepeating("SpawnEnemy", 0f, spawnInterval);
    }

    void SpawnEnemy()
    {
        // Calcula a distância entre o spawner e o jogador
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        UnityEngine.Debug.Log(distanceToPlayer);
        // Verifica se a distância está dentro do alcance desejado
        if (distanceToPlayer > minDistance && distanceToPlayer < maxDistance)
        {
            GameObject enemy = Instantiate(enemyPrefab, transform.position, transform.rotation);
            EnemyController enemyController = enemy.GetComponent<EnemyController>();
            enemyController.player = player;
        }
    }
}