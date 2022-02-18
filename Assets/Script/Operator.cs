using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Operator : Character
{
    [SerializeField] [Range(1,6)] private int rarity;
    [SerializeField] private int lvl;
    [SerializeField] private int Exp;
    [SerializeField] private float SP;
    [SerializeField] private int cost;
    [SerializeField] private int blockCount;
    [SerializeField] private int blockedEnemy;
    [SerializeField] private float redeployTime;

    public int BlockCount { get; set; }
    public int Cost { get; }

    public bool MaxedOutBlock() => blockCount == blockedEnemy;

    private new void Start()
    {
        base.Start();
        if (Target.Count == 0) {
            Target = new List<Character>();
        }
    }

}
