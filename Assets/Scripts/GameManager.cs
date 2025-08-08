using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public enum GameState{
        Ready,
        Start,
        Playing,
        Finish,
        Result,
    }

    public GameState state;

    private int _score;

    public int Score{ get { return _score; } }

    [SerializeField] private ItemManager itemManager;
    [SerializeField] private UIManager uiManager;

    private void Start()
    {
        itemManager.OnItemEnterShelf += OnGetScore;
        uiManager.OnClickStart += OnClickStart;
        state = GameState.Ready;
    }

    private void OnGetScore(int score){
        _score += score;
        Debug.Log($"ÉXÉRÉA : { Score }");
    }

    private void OnClickStart(){
        state = GameState.Playing;
    }
}
