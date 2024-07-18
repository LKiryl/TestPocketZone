using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Pool;

public class Gun : MonoBehaviour
{
    public static Action OnShoot;

    

    [SerializeField] private Transform _bulletSpawnPoint;


    [Header("Bullet")]
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private float _gunFireCD = 0.5f;


    private ObjectPool<Bullet> _bulletPool;

    private Vector2 _attackDirection;
    private Vector2 _targetPosition;
    private float _lastFireTime = 0f;


    


    private void Start()
    {
        CreateBulletPool();
    }
    private void Update()
    {
        if (!CheckTargetInArea()) return;
        Shoot();

    }

    private void OnEnable()
    {
        OnShoot += ShootProjectile;
        OnShoot += ResetLastFireTime;

    }

    private void OnDisable()
    {
        OnShoot -= ShootProjectile;
        OnShoot -= ResetLastFireTime;

    }

    public void ReleaseBulletFromPool(Bullet bullet)
    {
        _bulletPool.Release(bullet);
    }

   
    private void CreateBulletPool()
    {
        _bulletPool = new ObjectPool<Bullet>(() =>
        {
            return Instantiate(_bulletPrefab);
        }, bullet =>
        {
            bullet.gameObject.SetActive(true);
        }, bullet =>
        {
            bullet.gameObject.SetActive(false);
        }, bullet =>
        {
            Destroy(bullet);
        }, false, 10, 20);
    }
    private void Shoot()
    {
        if (Input.GetMouseButton(0) && Time.time >= _lastFireTime)
        {

            OnShoot?.Invoke();
        }     

    }



    private void ShootProjectile()
    {
        
        Bullet newBullet = _bulletPool.Get();
        newBullet.Init(this, _bulletSpawnPoint.position, _targetPosition);
        
    }

    private bool CheckTargetInArea()
    {
        RaycastHit2D hit = Physics2D.Raycast(_bulletSpawnPoint.position,
            CheckPlayerDirection(), 5f);
        if (hit.collider is not null && hit.collider.gameObject.GetComponent<Enemy>())
        {
            _targetPosition = hit.collider.transform.position;
            return true;
        }
        _targetPosition = default;
        return false; 
          

    }

    private Vector2 CheckPlayerDirection()
    {
        if(PlayerController.Instance.gameObject.transform.rotation.y >= 0)
        {
            
            return Vector2.right;
            
        }
        else 
        {
            return Vector2.left;

        }
    }
    //private void FireAnimation()
    //{
    //    _animator.Play(FIRE_HASH, 0, 0f);
    //}
   
    private void ResetLastFireTime()
    {
        _lastFireTime = Time.time + _gunFireCD;

    }

}
