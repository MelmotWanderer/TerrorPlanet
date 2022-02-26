using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New SettingSpace", menuName = "SettingSpace", order = 51)]
public class SettingSpace : ScriptableObject
{
    public int CountPlanet { get; set; }
    public int DensityPlanet { get; set; }

   public void ResetSetting()
    {
        CountPlanet = 0;
        DensityPlanet = 0;
    }
   

    
}
