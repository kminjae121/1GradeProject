using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [Header ("Setting")]
    private GameObject _player;
    public float MoveSpeed;
    private bool _isFollow;

    private void Awake()
    {
        _isFollow = false;
    }

    private void Start()
    {
        _player = GameObject.Find("Player");
    }

    private void Update()
    {
        FollowPlayer();
    }


    private void FollowPlayer()
    {
        float Range = Vector2.Distance(transform.position, _player.transform.position);

        if(Range < 5)
        {
            _isFollow = true;
        }

        if(_isFollow == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, _player.transform.position, MoveSpeed * Time.deltaTime);
        }

        if(transform.position == _player.transform.position)
        {
            PlusPoint();
            gameObject.SetActive(false);
        }
    }


    
    public void PlusPoint()
    {
        _player.TryGetComponent(out Player player);

        player.Coin += 1;
        
    }
}
