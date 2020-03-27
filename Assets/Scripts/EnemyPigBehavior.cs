using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPigBehavior : MonoBehaviour
{
    private Rigidbody2D _rigidBody2D;
    private Vector3 _playerPosition;

    public void Start()
    {
        _playerPosition = FindObjectOfType<Player>().transform.position;
        _rigidBody2D = GetComponent<Rigidbody2D>();
    }
}
