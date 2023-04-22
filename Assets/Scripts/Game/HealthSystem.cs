using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem
{
    private int _health;

    private int _maxHealth;

    //Properties
    public int Health
    {
        get { return _health; }
        set { _health = value; }
    }

    public int MaxHealth
    {
        get { return _maxHealth; }
        set { _maxHealth = value; }
    }

    //constructor
    public HealthSystem(int health, int maxHealth)
    {
        _health = health;
        _maxHealth = maxHealth;
    }

    //methods
    public void TakeDamage(int damage)
    {
        _health = _health - damage;
    }

    public void TakeHeal(int heal)
    {
        if (_health < _maxHealth)
        {
            _health = _health + heal;
        }

        if (_health >= _maxHealth)
        {
            _health = _maxHealth;
        }
    }
}