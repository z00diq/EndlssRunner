using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Health _prefabItem;

    private List<Health> _items = new List<Health>();

    private void OnEnable()
    {
        _player.HealthChanged += OnHealthChanged;
    }

    private void OnDisable()
    {
        _player.HealthChanged -= OnHealthChanged;
    }

    private void OnHealthChanged(int value)
    {
        if (_items.Count < value)
        {
            int createHelath = value - _items.Count;
            for (int i=0; i < createHelath; i++)
            {
                CreateHealthItem(); 
            }
        }
        else if (_items.Count > value)
        {
            for(int i = 0; i < _items.Count - value; i++)
            {
                DestroyItem(_items[_items.Count-1]);
            }

        }
    }

    private void DestroyItem(Health healthItem)
    {
        _items.Remove(healthItem);
        healthItem.ToEmpty(); 
    }

    private void CreateHealthItem()
    {
        Health newItem = Instantiate(_prefabItem, transform);
        _items.Add(newItem);
        newItem.ToFill(); 
    }
}
