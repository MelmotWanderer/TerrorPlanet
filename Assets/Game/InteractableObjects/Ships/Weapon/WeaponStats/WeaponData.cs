
using UnityEngine;


[CreateAssetMenu(fileName = "New WeaponData", menuName = "Weapon Data", order = 51)]
public  class WeaponData: ScriptableObject
{
    public string Name;
    public Sprite Icon;
    public Shell Shell;
    public float Strenght;
    public float MaxEndurance;
    public float Delay;
    public float SpeedReload;
    public float Price;
    
}
