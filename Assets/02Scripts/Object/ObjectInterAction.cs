using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


enum ObjectName
{
    Box,
    tree,
}
public class ObjectInterAction : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    private ObjectName _objectName;
    [SerializeField] private Vector2 _boxSize;
    [SerializeField] private LayerMask _player;
    [SerializeField] private GameObject _textBox;
    [SerializeField] private TextMeshPro _Text;
    private Collider2D hit;


    private void Awake()
    {
        _inputReader.IntractionEvent += HandleInterAction;
        _inputReader.UnintractionEvent += HandleUnInterAction;  
    }

    private void Start()
    {

    }

    private void Update()
    {
        hit = Physics2D.OverlapBox(transform.position, _boxSize, 0, _player);
    }


    private void HandleInterAction()
    {

        if (hit == true)
        {
            _textBox.SetActive(true);
        }
        else
        {
            _textBox.SetActive(false);
        }

        switch (_objectName)
        {
            case ObjectName.Box:
                StartCoroutine(Text());
                break;
            case ObjectName.tree:
                break;
        }

        
    }
    private void HandleUnInterAction()
    {
        
    }

    IEnumerator Text()
    {
        for(int i = 0; i < 10; i++)
        {


            yield return new WaitForSeconds(0.5f);
        }
    }
}
