using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitcherPanel: MonoBehaviour
{
   [SerializeField] private Menu[] _menus;
    [SerializeField] private Canvas _cancelCanvas;
    private int currentMenuIndex;
    public int prevMenuIndex;

    void Start()
    {
        SwitchMenu(0);
    }

    
   public void SwitchMenu(int menuIndex)
   {
        prevMenuIndex = currentMenuIndex;
        _menus[currentMenuIndex].gameObject.SetActive(false);
        _menus[menuIndex].gameObject.SetActive(true);
        currentMenuIndex = menuIndex;
        if (menuIndex != 0)
        {
            _cancelCanvas.gameObject.SetActive(true);
        }else
        {
            _cancelCanvas.gameObject.SetActive(false);
        }
        

    }
    public void ReturnPrevMenu()
    {
        SwitchMenu(prevMenuIndex);
    }
}
