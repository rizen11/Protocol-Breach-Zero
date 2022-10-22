using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    protected int lives;
    public virtual void GetDamage(int damage)
    {
        lives=lives-damage;
        Debug.Log(lives);
        if (lives < 1)
            Die();
     }

    public virtual void Die()
    {
        Destroy(this.gameObject);
    }
   
}
