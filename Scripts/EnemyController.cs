using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
    // public 
    public Transform player;
    public NavMeshAgent agent;
    public int current_path;
    public float min_distance;
    public Transform[] possition;
    public bool isImortal;
    public bool isRun;
    // private void generateTargetIfNotExist(){
    //     if(possition.Length > 0){
    //         return;
    //     }
    //     // compara a distancia
    //     var distancia = Vector3.Distance(agent.destination, transform.position);
    //     if(distancia<10){
    //         agent.destination = Vector3.forward * Random.Range(-1000,1000) + Vector3.left * Random.Range(-1000,1000) + transform.position;
    //     }
    // }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        // generateTargetIfNotExist();
        // if(possition.Length!=0)
        agent.destination = transform.position;
        isImortal = false;
    }

    // Update is called once per frame
    void Update()
    {
        var distanceToPlayer = Vector3.Distance(agent.destination, player.transform.position);
        isRun = distanceToPlayer<6;
        // Debug.Log(distanceToPlayer);
        if(isRun){
            // Debug.Log($"Distancia para player: {distanceToPlayer}");
            agent.destination = player.transform.position;
            return;
        }
        agent.destination = transform.position;

        // var distanceToPoint = Vector3.Distance(agent.destination, transform.position);
        // if(distanceToPoint<min_distance){
        //     current_path = (current_path + 1)%possition.Length;
        //     agent.destination = possition[current_path].position;
        // }
        
    }
    private void OnTriggerEnter(Collider other) {
       if(other.CompareTag("Player") && !isImortal){
            SceneManager.LoadScene("Morte_Menu");
        }

    }
    void OnDestroy()
    {
        
    }
}
