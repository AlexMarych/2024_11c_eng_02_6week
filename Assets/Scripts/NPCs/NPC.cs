
using System;
using UnityEngine;

public abstract class NPC : MonoBehaviour, IDamagable
{
    public int Health { get; protected set; }
    public void Damage(int damage)
    {
        Health -= damage;
    }
}