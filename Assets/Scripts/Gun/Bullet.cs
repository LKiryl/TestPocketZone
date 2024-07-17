using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 4f;
    [SerializeField] private int _damageAmount = 1;

    private Vector2 _fireDirection;
    private Rigidbody2D _rigidBody;
    private Gun _gun;
    

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {


        _rigidBody.velocity = _fireDirection * _moveSpeed;
        //_rigidBody.MovePosition(_rigidBody.position + _fireDirection * _moveSpeed * Time.deltaTime);
    }

    public void Init(Gun gun, Vector2 bulletSpawnPos, Vector2 targetPosition)
    {
        _gun = gun;
        transform.position = bulletSpawnPos;
        _fireDirection = (targetPosition - bulletSpawnPos).normalized;   
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Health targetHealth = collision.gameObject.GetComponent<Health>();
        targetHealth?.TakeDamage(_damageAmount);

        _gun.ReleaseBulletFromPool(this);
    }
}
