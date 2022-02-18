using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Stages : MonoBehaviour
{
    [System.Serializable]
    private struct OperatorCard {
        public CharacterStats OP;
        public StageCard Card;
    }

    public static Stages StageInstance;

    [SerializeField] private List<OperatorCard> Operator;

    public int StageHP;

    [SerializeField] private int _dp;
    public int DP { get=>_dp; private set => _dp = value; } 

    [SerializeField] private float DPRegen;
    [SerializeField] private TextMeshProUGUI DPText;

    private float timer;
    public float Timer {get => timer;}

    private void Start()
    {
        if (StageInstance == null)
        {
            StageInstance = this;
        }
        else {
            Destroy(this);
        }
        
        DPText.SetText(DP.ToString());
        Debug.Log("ada");
        for (int i = 0; i < Operator.Count; i++) {
            Operator[i].Card.Text_DPCOST.SetText(Operator[i].OP.cost.ToString());
        }
    
    }

    private void Update()
    {
        if (StageHP <= 0) {
            Debug.Log("Failed");
        }
    }


    public void TakeDamage(int damage) {
        StageHP -= damage;
    }
}
