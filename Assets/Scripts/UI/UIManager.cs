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
        startBtn.onClick.AddListener(() => { OnClickStart?.Invoke(); });
    }
}
