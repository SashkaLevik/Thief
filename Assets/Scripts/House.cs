using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class House : MonoBehaviour
{    
    [SerializeField] private UnityEvent<bool> _perimeterBreached;

    
    public bool IsBreached { get; private set; }

    public event UnityAction<bool> Breached
    {
        add => _perimeterBreached.AddListener(value);
        remove => _perimeterBreached.RemoveListener(value);
    }       

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Thief>(out Thief thief))
        {
            IsBreached = true;
            _perimeterBreached.Invoke(IsBreached);
        }
    }    

    private void OnTriggerExit2D(Collider2D collision)
    {
        IsBreached = false;
        //_perimeterBreached.Invoke(IsBreached);
    }
}
