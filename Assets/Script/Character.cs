using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private CharacterStats characterStats;
    private int currentHP;
    private int currentATK;
    private int currentDEF;
    private int currentRES;
    private float currentASPD;

    private List<Character> target = new List<Character>();


    private bool isAttacking;

    public string CharacterName { get => characterStats.characterName;}
    public int BaseHP { get => characterStats.baseHP;}
    public int BaseATK { get => characterStats.baseATK;}
    public int BaseDEF { get => characterStats.baseDEF;}
    public int BaseRES { get => characterStats.baseRES;}
    public float ASPD { get => characterStats.attackSpeed;}
    public List<Character> Target { get => target; set => target = value; }
    public bool IsAttacking { get => isAttacking; set => isAttacking = value; }


    public float NormalizedASPD() => 0f;
    public void setStats(CharacterStats stats) {
        characterStats = stats;
    }

    protected void Start()
    { 
        currentHP = characterStats.baseHP;
        currentATK = characterStats.baseATK;
        currentDEF = characterStats.baseDEF;
        currentRES = characterStats.baseRES;
        currentASPD = characterStats.attackSpeed;
    }

    private void Update()
    {
        if (currentHP <= 0)
        {
            Destroy(transform.parent.gameObject);
        }
    }

    public IEnumerator Attack()
    {
        while (target.Count != 0)
        {
            target[0].TakeDamage(1);
            yield return new WaitForSeconds(1f);
        }
        IsAttacking = false;
        yield break;
    }

    public void TakeDamage(int damage) {
        currentHP -= damage;
    }
}
