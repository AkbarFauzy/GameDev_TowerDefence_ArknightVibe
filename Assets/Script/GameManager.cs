using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyType { Ground, Air};
public enum AttackType {Ranged_Phys, Ranged_Art, Melee_Phys, Melee_Art}


public class GameManager : MonoBehaviour
{
    public static GameManager Intance;

    private void Awake()
    {
        if (Intance == null)
        {
            Intance = this;
            DontDestroyOnLoad(Intance);
        }
        else {
            Destroy(this);
        }           



    }

}
