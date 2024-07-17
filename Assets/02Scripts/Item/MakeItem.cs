using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeItem : MonoBehaviour
{
    [SerializeField] private GameObject Item;
    public static Stack<GameObject> ItemMakeMachine = new Stack<GameObject>();
    
    private void Start()
    {
        MakeItemMode();
    }

    private void MakeItemMode()
    {
        for (int i = 0; i < 30; i++)
        {
            GameObject ItemPop = Instantiate(Item);
            ItemMakeMachine.Push(ItemPop);
            ItemPop.SetActive(false);
        }
    }
}
