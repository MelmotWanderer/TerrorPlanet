using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
public class SaveSettingsSpace : MonoBehaviour
{

    [SerializeField] private SettingSpace _settingSpace;
    [SerializeField] private InputField countPlanet;
    [SerializeField] private InputField densityPlanet;


  
    public void ChangeCountPlanet()
    {
        bool result = int.TryParse(countPlanet.text, out var number);
        if (result)
            _settingSpace.CountPlanet = number;
        else {
            
            countPlanet.text = "0";
            _settingSpace.CountPlanet = 0;
                }


        Debug.Log(_settingSpace.CountPlanet);

    }
    public void ChangeDensityPlanet()
    {
        bool result = int.TryParse(densityPlanet.text, out var number);
        if (result)
            _settingSpace.DensityPlanet = number;
        else
        {
            densityPlanet.text = "0";
            _settingSpace.DensityPlanet = 0;
        }


        Debug.Log(_settingSpace.DensityPlanet);


    }
  
}
