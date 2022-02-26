using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
[RequireComponent(typeof(SpaceStation))]
public class SpaceStationUI : MonoBehaviour
{
    public WeaponProduct _block;
    public LayoutGroup _panel;
    public UnityEvent<bool> OnShopping = new UnityEvent<bool>();
    [SerializeField] private Button _button;
    [SerializeField] private Canvas canvas;
    [SerializeField] private Text _notFoundWeaponText;
    private List<WeaponProduct> weaponProducts = new List<WeaponProduct>();
    private SpaceStation _spaceStation;
  

    private void Start()
    {
        _spaceStation = GetComponent<SpaceStation>();
        _spaceStation.OnNoneWeapon += EnabledNoneWeaponText;
        _button.onClick.AddListener(OnClick);
        OnShopping.AddListener(_spaceStation.SetPlayerIsShopping);
        _notFoundWeaponText.gameObject.SetActive(false);
        DisableUI();
        
    }
    public void UpdateUI()
    {
        foreach(WeaponProduct weaponProduct in weaponProducts.ToArray())
        {
            DeleteWeaponProduct(weaponProduct);
        }
        
        

    }
    
    public void CreateWeaponProducts()
    {
        var weaponDatas = _spaceStation.GetWeaponDatas();
        if (_spaceStation.isNoneWeapon) {
            EnabledNoneWeaponText(true);
        }
           
            foreach (WeaponData weaponData in weaponDatas)
            {
                var product = Instantiate(_block, _panel.transform.position, Quaternion.identity);
                product.transform.parent = _panel.gameObject.transform;
                product.Init(weaponData);
                product.OnPurchaseWeapon.AddListener(_spaceStation.PurchaseWeapon);
                product.OnPurchaseWeapon.AddListener(DeleteWeaponProduct);
                if (_spaceStation._playerShip.Money < product._weaponData.Price)
                {
                    product._button.interactable = false;
                }
                else
                {
                    product._button.interactable = true;

                }

                weaponProducts.Add(product);


            }
        
       
        
    }
    public void ShowUI()
    {

        OnShopping.Invoke(true);

        canvas.gameObject.SetActive(true);
    }

    public void DisableUI()
    {
        OnShopping.Invoke(false);
        EnabledNoneWeaponText(false);
        canvas.gameObject.SetActive(false);
        
    }

    public void OnClick()
    {
        
        DisableUI();
        UpdateUI();

    }
    private void DeleteWeaponProduct(WeaponProduct weaponProduct)
    {
        weaponProducts.Remove(weaponProduct);
        weaponProduct.Delete();
    }
    private void EnabledNoneWeaponText(bool isEnabled)
    {
        _notFoundWeaponText.gameObject.SetActive(isEnabled);
    }
    
    
}
