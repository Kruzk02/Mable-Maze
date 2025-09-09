using System;
using UnityEngine;

public class TriggerHandler : MonoBehaviour
{
    [SerializeField] private GameObject hole;
        
    public static event Action<Collider> OnCollisionEnter;
            
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            OnCollisionEnter?.Invoke(other);
        }
    }
}
