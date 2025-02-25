using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "Scriptable Objects/EnemyData")]
public class EnemyData : ScriptableObject
{
    public int enemy;
    public int enemyKilled;
    public int round;
    public int max_life;
}
