using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public event Action OnClickStart;

    [SerializeField] private Button startBtn;

    private void Start()
    {
        startBtn.onClick.AddListener(() => { OnClickStartHandler(); });
    }

    private void Update()
    {
        if(GameManager.Instance.state == GameManager.GameState.Ready){
            startBtn.gameObject.SetActive(true);
        }
    }

    private void OnClickStartHandler(){
        OnClickStart?.Invoke();
        startBtn.gameObject.SetActive(false);
    }
}
