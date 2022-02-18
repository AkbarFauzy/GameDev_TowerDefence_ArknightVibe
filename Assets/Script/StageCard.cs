using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class StageCard : MonoBehaviour
{
    public Image splash;
    [SerializeField] private TextMeshProUGUI dpcostText;
    public TextMeshProUGUI Text_DPCOST { get => dpcostText; }
}
