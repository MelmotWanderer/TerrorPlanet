using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
public class WeaponProduct : MonoBehaviour
{


    public UnityEvent<WeaponProduct> OnPurchaseWeapon = new UnityEvent<WeaponProduct>();
    public WeaponData _weaponData;

    [SerializeField] private Text Name, Strenght, MaxEndurance, Delay, SpeedReload, Price;
    public Button _button;
    [SerializeField] private Image Icon;

    
  

    public void Init(WeaponData weaponData)
    {
       
      
        _weaponData = weaponData;
        Name.text += weaponData.Name;
        Icon.sprite = weaponData.Icon;
        Strenght.text += weaponData.Strenght.ToString();
        MaxEndurance.text += weaponData.MaxEndurance.ToString();
        Delay.text += weaponData.Delay.ToString();
        SpeedReload.text += weaponData.SpeedReload.ToString();
        Price.text += weaponData.Price.ToString();
    }
    
    public void Purchase()
    {
        OnPurchaseWeapon.Invoke(this);
       
    }

    public void Delete()
    {
        Destroy(gameObject);
    }
}
