using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace InfimaGames.LowPolyShooterPack
{
public class EnemyUI : MonoBehaviour
{
    [SerializeField] private Text zombieUI;
    public int zombieNum = 30;

    // Update is called once per frame
    void Update()
    {
        if (zombieNum == 0)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene("MissionComplete");
        }
        zombieUI.text = zombieNum.ToString();
    }
}
}