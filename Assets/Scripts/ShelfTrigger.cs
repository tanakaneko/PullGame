using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShelfTrigger : MonoBehaviour
{
    public event Action <Item> OnTriggerEnterItem;

    private void OnTriggerEnter(Collider other){
        Item item = other.GetComponent<Item>();
        if (item != null){
            OnTriggerEnterItem?.Invoke(item);
        }
    }
}
