using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Animator), typeof(SpriteRenderer))]

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed = 4;

    Rigidbody2D _rigidbody2D;
    SpriteRenderer _spriteRenderer;
    Animator _animator;
    private Vector2 _movement = new Vector2(0,0);
    
    private const string AnimationSpeed = "Speed";

    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        _movement.x = 0;

        if (Input.GetKey(KeyCode.A))
        {
            _movement.x = -1;
            _spriteRenderer.flipX = true;
        }

        if (Input.GetKey(KeyCode.D))
        {
            _movement.x = 1;
            _spriteRenderer.flipX = false;
        }

        _animator.SetFloat(AnimationSpeed, Mathf.Abs(_movement.x));
        _rigidbody2D.position += _movement * _speed * Time.deltaTime;
    }
}
