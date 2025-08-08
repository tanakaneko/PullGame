using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private ItemManager.ItemType _type;

    public ItemManager.ItemType Type{  get { return _type; } }

    public event Action OnCorrect;
    public event Action OnWrong;

    private void Update()
    {
        if(transform.position.y < -10){
            Destroy(gameObject);
        }
    }

    public void OnEnterCorrectShelf(){
        OnCorrect?.Invoke();
        EnterShelf();
    }

    public void OnEnterWrongShelf(){
        OnWrong?.Invoke();
        EnterShelf();
    }

    private void EnterShelf(){
        Destroy(gameObject);
    }
}
