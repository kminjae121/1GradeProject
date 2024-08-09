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
    private bool IsInteraction;
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
        if (IsInteraction == false)
        {
            if (hit == true)
            {
                switch (_objectName)
                {
                    case ObjectName.Box:
                        TextboxSet();
                        _Text.text = "이것은 박스군";
                        break;
                    case ObjectName.tree:
                        TextboxSet();
                        _Text.text = "이것은 나무군";
                        break;
                }
            }
        }
        
    }

    private void TextboxSet()
    {
        _textBox.SetActive(true);
        _Text.text = null;
        IsInteraction = true;
    }

    private void HandleUnInterAction()
    {
        if(IsInteraction == true)
        {
            _textBox.SetActive(false);
        }
    }
}
