using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    private int _score;

    public int Score{ get { return _score; } }

    [SerializeField] private ItemManager itemManager;

    private void Start()
    {
        itemManager.OnItemEnterShelf += OnGetScore;
    }

    private void OnGetScore(int score){
        _score += score;
        Debug.Log($"ÉXÉRÉA : { Score }");
    }
}
