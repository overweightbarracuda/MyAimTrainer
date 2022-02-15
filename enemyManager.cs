using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyManager : MonoBehaviour
{
    public Transform m_SpawnPoint1;
    public Transform m_SpawnPoint2;
    public Transform m_SpawnPoint3;
    public Transform m_SpawnPoint4;
    public Transform m_SpawnPoint5;
    public Transform m_SpawnPoint6;
    public GameObject m_EnemyPrefab;
    // Start is called before the first frame update
    void Start()
    {
        SpawnNewEnemy();
    }

    // Update is called once per frame
    void SpawnNewEnemy() {
        int RandSpawn = Random.Range(1, 6);
        Vector3 FinalPos;
        switch(RandSpawn)
        {
            case 6:
                FinalPos = m_SpawnPoint6.transform.position;
                break;
            case 5:
                FinalPos = m_SpawnPoint5.transform.position;
                break;
            case 4:
                FinalPos = m_SpawnPoint4.transform.position;
                break;
            case 3:
                FinalPos = m_SpawnPoint3.transform.position;
                break;
            case 2:
                FinalPos = m_SpawnPoint2.transform.position;
                break;
            case 1:
                FinalPos = m_SpawnPoint1.transform.position;
                break;
            default:
                FinalPos = m_SpawnPoint1.transform.position;
                break;
        }
        Instantiate(m_EnemyPrefab, FinalPos, Quaternion.identity);
    }

    void OnEnable()
    {
        
        Enemy.OnEnemyKilled += SpawnNewEnemy;
    }
}
