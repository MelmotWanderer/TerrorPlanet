using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerUI : MonoBehaviour
{

    public Text TypeWeapon;
    [SerializeField] private Text CountMoney;
    [SerializeField] private PlayerShip _player;
    
    private void OnEnable()
    {
        _player.OnChangeMoney += ChangeMoney;
        _player.OnChangeWeapon += ChangeWeapon;
    }

    private void OnDisable()
    {
        _player.OnChangeMoney -= ChangeMoney;
        _player.OnChangeWeapon -= ChangeWeapon;
    }

    public void ChangeMoney(float money)
    {
        CountMoney.text = money.ToString();
    }
    private void ChangeWeapon(string type)
    {
        TypeWeapon.text = type;
    }
}
