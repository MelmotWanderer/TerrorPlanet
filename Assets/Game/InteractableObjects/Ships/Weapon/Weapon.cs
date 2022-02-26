
using UnityEngine;
using System;
public class Weapon : MonoBehaviour
{

    
    public Action<float> OnChangeEndurance;
    public Action<string> OnChangeCurrentTarget;

    [SerializeField] private WeaponData _weaponData;
    public string Name;
    public Shell Shell;  
    private float Strenght;    
    private float MaxEndurance;
    private float Delay;
    private float SpeedReload;
    


    private Ship _ship;
    private float CurrentEndurance;
    private Vector3 _target;

    private void Start()
    {
        SetMaxEndurance();

        SetShip();
        
    }
    
    public void Init()
    {
        Name = _weaponData.Name;
        Shell = _weaponData.Shell;
        Strenght = _weaponData.Strenght;
        MaxEndurance = _weaponData.MaxEndurance;
        Delay = _weaponData.Delay;
        SpeedReload = _weaponData.SpeedReload;
       
       

    }
    public void SetWeaponData(WeaponData weaponData)
    {
        _weaponData = weaponData;
    }
    public void SetShip()
    {
        _ship = transform.parent.GetComponent<Ship>();
    }
    public Ship GetShip()
    {
        return _ship;
    }
    public float GetStrenght()
    {
        return Strenght;
    }
    public Vector3 GetTarget()
    {
        return _target;
    }

    public float GetDelay()
    {
        return Delay;
    }
    public float GetEndurance()
    {
        return CurrentEndurance;
    }
    public void ChangeEndurance(float change)
    {
        CurrentEndurance =  Mathf.Clamp(CurrentEndurance + change, 0, MaxEndurance);
        OnChangeEndurance?.Invoke(CurrentEndurance / MaxEndurance);


    }
    
    public float GetMaxEndurance()
    {
        return MaxEndurance;
    }
    public float GetSpeedReload()
    {
        return SpeedReload;
    }
    public bool isEqualMaxEndurance()
    {
        return CurrentEndurance == MaxEndurance ? true : false;
    }
    public void SetTarget(Vector3 target)
    {
        _target = target;





    }
    private void SetMaxEndurance()
    {
        CurrentEndurance = MaxEndurance;
        OnChangeEndurance?.Invoke(CurrentEndurance / MaxEndurance);
    }
    
   
}
