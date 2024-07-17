using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _changeDirectionInterval = 2f;
    private Movement _movement;

    private void Awake()
    {
        _movement = GetComponent<Movement>();
    }

    private void Start()
    {
        StartCoroutine(ChangeDirectionRoutine());
    }


    private IEnumerator ChangeDirectionRoutine()
    {
        while (true)
        {
            float currentDirectionX = Random.Range(0, 2) * 2 - 1;
            float currentDirectionY = Random.Range(0, 2) * 2 - 1;
            _movement.SetCurrentDirection(currentDirectionX, currentDirectionY);
            yield return new WaitForSeconds(_changeDirectionInterval);
        }
        
    }
}
