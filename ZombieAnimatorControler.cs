using UnityEngine;

public class ZombieAnimatorControler : MonoBehaviour
{   
    private EnemyController enemyController;
    private Animator _animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemyController = GetComponent<EnemyController>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        _animator.SetBool("run", enemyController.isRun);
    }

    
}
