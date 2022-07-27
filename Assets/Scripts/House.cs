using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class House : MonoBehaviour
{    
    public bool IsBreached { get; private set; }

    public event UnityAction<bool> Breached;
           

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Thief>(out Thief thief))
        {
            IsBreached = true;
            Breached.Invoke(IsBreached);
        }
    }    

    private void OnTriggerExit2D(Collider2D collision)
    {
        IsBreached = false;
        Breached.Invoke(IsBreached);
    }
}
