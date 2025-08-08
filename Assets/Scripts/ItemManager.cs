using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Threading;
using System.Runtime.CompilerServices;

public class ItemManager : MonoBehaviour
{
    public enum ItemType
    {
        Sphere,
        Cube,
        Cone,
    }

    [SerializeField] private GameObject ItemSphere;
    [SerializeField] private GameObject ItemCube;
    [SerializeField] private GameObject ItemCone;
    private Dictionary<ItemType, GameObject> itemPrefabs;

    [SerializeField] private Vector3[] spawnPoss;

    private int spawnSpan = 0;
    private int timer;

    public Action<int> OnItemEnterShelf;

    private const int LINE_NUM = 3;

    private void Start()
    {
        itemPrefabs = new Dictionary<ItemType, GameObject>()
        {
            [ItemType.Sphere] = ItemSphere,
            [ItemType.Cube] = ItemCube,
            [ItemType.Cone] = ItemCone,
        };
    }

    private void Update()
    {
        if (GameManager.Instance.state != GameManager.GameState.Playing) return;
        if(timer >= spawnSpan)
        {
            System.Random rand = new System.Random();

            spawnSpan = rand.Next(0, 1000);  // 単位フレーム
            timer = 0;

            int itemType = rand.Next(0,Enum.GetValues(typeof(ItemType)).Length);
            int lineNum = rand.Next(0,LINE_NUM);

            Item item = GameObject.Instantiate(itemPrefabs[(ItemType)itemType], spawnPoss[lineNum], Quaternion.identity).GetComponent<Item>();

            // イベントの購読
            item.OnCorrect += OnItemEnterCorrectShelf;
            item.OnWrong += OnItemEnterWrongShelf;
        }

        timer++;
    }

    private void OnItemEnterCorrectShelf()
    {
        OnItemEnterShelf.Invoke(100);
    }

    private void OnItemEnterWrongShelf()
    {
        OnItemEnterShelf.Invoke(50);
    }
}
