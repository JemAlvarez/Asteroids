using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] int damage = 50;

    public int GetDamage()
    {
        return damage;
    }
}
