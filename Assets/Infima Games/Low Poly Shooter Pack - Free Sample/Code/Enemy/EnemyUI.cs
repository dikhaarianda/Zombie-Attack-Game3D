using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace InfimaGames.LowPolyShooterPack
{
public class EnemyUI : MonoBehaviour
{
    [SerializeField] private Text zombieUI;
    public int zombieNum = 30;

    // Update is called once per frame
    void Update()
    {
        zombieUI.text = zombieNum.ToString();
    }
}
}