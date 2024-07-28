using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


enum ObjectName
{
    Box,
    tree,
}
public class ObjectInterAction : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    private ObjectName _objectName;

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
        
    }

    private void HandleInterAction()
    {
        switch(_objectName)
        {
            case ObjectName.Box:
                break;
            case ObjectName.tree:
                break;
        }
    }
    private void HandleUnInterAction()
    {
        
    }
}
