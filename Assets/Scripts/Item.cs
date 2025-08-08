using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private ItemManager.ItemType _type;

    public ItemManager.ItemType Type{  get { return _type; } }

    public void OnEnterCorrectShelf(){
        EnterShelf();
    }

    public void OnEnterWrongShelf(){
        EnterShelf();
    }

    private void EnterShelf(){
        Destroy(gameObject);
    }
}
