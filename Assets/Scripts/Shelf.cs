using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Shelf : MonoBehaviour, IPointerClickHandler
{
    private float closeZ; // �����Ƃ���z���W
    private float openZ;  // �J�����Ƃ���z���W
    private const float OPEN_Z_OFFSET = 6.0f;  // ������ԂƊJ������Ԃ�z���W�̍�

    [SerializeField] private float animTime; // �A�j���[�V�����ɂ����鎞��

    private Rigidbody rb;

    [SerializeField] private ShelfTrigger trigger;

    // �ΏۂƂ���A�C�e��
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

        // �C�x���g�w��
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
            .DOMoveZ(toZ, animTime)          // �ڕW��Z���W(toZ)�ƃA�j���[�V��������(animTime)���w��
            .SetEase(Ease.OutCirc)           // �C�[�W���O�̎�ނ�Ease.OutCirc�ɐݒ�
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
