using TMPro;
using UnityEngine;
using System.Collections;
enum Objectkind
{
    Box,
    Carpet,
    Cat,
}


public class ObjectManager : MonoBehaviour
{
    [SerializeField] private Objectkind _objectKind;
    [SerializeField] private GameObject _textBar;
    [SerializeField] private TextMesh _text;
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private Vector2 boxSize;
    
    public LayerMask Player;
    private bool _isPlayer;
    private bool _isFalse;



    private void Awake()
    {
        _isPlayer = false;
        _isFalse = false;
        _textBar.SetActive(false);
    }

    private void Start()
    {
        _inputReader.IntractionEvent += Interaction;
        
        
    }

    private void Update()
    {
        EnterPlayer();
    }



    private void EnterPlayer()
    {
        Collider2D hit = Physics2D.OverlapBox(transform.position, boxSize, 0, Player);

        if(hit == true)
        {
            _isPlayer = true;
        }
        else
        {
            _isPlayer = false;
        }
    }


    private void Interaction()
    {
        if (_objectKind == Objectkind.Box && _isPlayer == true)
        {
            _textBar.SetActive(true);
            _isFalse = true;
        }
    }

    private void UnInteraction()
    {
        if (_objectKind == Objectkind.Box && _isFalse == true)
        {
            _textBar.SetActive(false);
        }
    }
}
