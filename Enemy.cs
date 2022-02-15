using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public delegate void EnemyKilled();
    public static event EnemyKilled OnEnemyKilled;
    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        if (health <= 0){
            die();
        }
    }
    public void die(){
        Destroy(gameObject);
        if(OnEnemyKilled != null)
        {
            OnEnemyKilled();
        }
    }
}
