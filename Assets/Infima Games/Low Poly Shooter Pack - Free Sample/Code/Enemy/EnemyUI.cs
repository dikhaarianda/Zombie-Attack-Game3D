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
            StartCoroutine(DelayTimer());
        }
        zombieUI.text = zombieNum.ToString();
    }

    private IEnumerator DelayTimer () {
		//Wait for random amount of time
		yield return new WaitForSeconds(5);
        SceneManager.LoadScene("MissionComplete");
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
}