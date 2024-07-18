using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuSCC : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject InventoryUI;
    private void Start()
    {
        Time.timeScale = 0f;
    }
    public void StartNewGame()
    {
        Time.timeScale = 1f;
        InventoryUI.SetActive(false);
        Invoke("DestroyGameObj", 2);
    }


    public void LoadGame()
    {
        Time.timeScale = 1f;
        InventoryUI.SetActive(false);
        Player.main.LoadEverything();
        Invoke("DestroyGameObj", 2);
    }

    public void DestroyGameObj()
    {
        Destroy(MainMenu);
    }
}
