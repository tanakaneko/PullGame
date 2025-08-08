using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    private Rigidbody body;
    private const float powerZ = -100.0f;

    private void Start()
    {
        body = GetComponent<Rigidbody>();    
    }

    public void OnHitShelfFront(){
        body.AddForce(new Vector3(0,0,powerZ));
    }
}
