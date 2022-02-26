using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WeaponUI : MonoBehaviour
{

    public Image Endurance;
    
    [SerializeField] private Weapon _weapon;
    

    void OnEnable()
    {
        _weapon.OnChangeEndurance += ChangeEndurance;
       
      
    }
    private void OnDisable()
    {
        _weapon.OnChangeEndurance -= ChangeEndurance;
      
    }
    private void ChangeEndurance(float currentEndurance)
    {
        Endurance.fillAmount = currentEndurance;
    }
    



}
