using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExPlayer : MonoBehaviour
{
    private int health = 100;
    // Start is called before the first frame update
    public void TakeDamage(int damage)
    {
        health -= damage;

        if(health <= 0)
        {
            Die();
        }


      
    }






    // Update is called once per frame
    public void Die()
    {
        Debug.Log("플레이어가 사망했습니다.");
    }
}
