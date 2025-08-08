using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Shelf : MonoBehaviour, IPointerClickHandler
{
    private float closeZ; // 閉じたときのz座標
    private float openZ;  // 開いたときのz座標
    private const float OPEN_Z_OFFSET = 6.0f;  // 閉じた状態と開いた状態のz座標の差

    [SerializeField] private float animTime; // アニメーションにかかる時間

    private Rigidbody rb;

    [SerializeField] private ShelfTrigger trigger;

    // 対象とするアイテム
    [SerializeField] private ItemManager.ItemType targetItemType;

    private enum State
    {
        OPEN,
        OPENING,
        CLOSED,
        CLOSING
    }

    private State state;

    private void Start()
    {
        state = State.CLOSED;
        closeZ = transform.position.z;
        openZ = transform.position.z - OPEN_Z_OFFSET;

        rb = GetComponent<Rigidbody>();

        // イベント購読
        trigger.OnTriggerEnterItem += OnGetItem;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        switch(state){
        case State.OPEN:
            state = State.CLOSING;
            MoveAnim(closeZ);
            break;
        case State.OPENING:
        case State.CLOSING:
            return;
        case State.CLOSED:
            state = State.OPENING;
            MoveAnim(openZ);
            break;
        }
    }

    private void MoveAnim(float toZ)
    {
        this.rb
            .DOMoveZ(toZ, animTime)          // 目標のZ座標(toZ)とアニメーション時間(animTime)を指定
            .SetEase(Ease.OutCirc)           // イージングの種類をEase.OutCircに設定
            .OnComplete(AnimationEnd);
    }

    private void AnimationEnd()
    {
        if (state == State.CLOSING)
        {
            state = State.CLOSED;
        }
        else if (state == State.OPENING) 
        {
            state = State.OPEN;
        }
    }

    private void OnGetItem(Item item){
        if(item.Type == targetItemType){
            item.OnEnterCorrectShelf();
        }
        else{
            item.OnEnterWrongShelf();
        }
    }
}
