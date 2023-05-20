using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject UI;

    public bool menuActive = false;

      public void Menu(bool esc)
      {
        if (esc == true)
            menuActive = true;

        else
            menuActive = false;
      }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) == true)
        {
            Menu(Input.GetKeyDown(KeyCode.Escape));
        }

        if(menuActive == true && Input.GetKeyDown(KeyCode.Escape) == true)
        {
            menuActive = false;
            Menu(menuActive);
        }
    }
}
