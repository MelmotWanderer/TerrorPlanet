using System.Collections;

using UnityEngine;

using UnityEngine.UI;

public class HealthBarUI: MonoBehaviour
{
    
    public Image _healthUI;
    public Transform Pivot;
    private Transform _targetForLook;
    private IDamagable _body;
    private float _maxHealth;
    private float currentHealthBar;

    private void Start()
    {
        _targetForLook = GameObject.FindGameObjectWithTag("MainCamera").transform;
        _body = GetComponent<IDamagable>();
        _maxHealth = _body.Health;
        currentHealthBar = _healthUI.fillAmount;       
        Pivot.gameObject.SetActive(false);
        _body.OnGetDamage += ChangeHealth;
        
    }

  
    private void OnDisable()
    {
        _body.OnGetDamage -= ChangeHealth;
        Pivot.gameObject.SetActive(false);
    }

    
    void Update()
    {      
        Pivot.transform.LookAt(_targetForLook);
    }
    private void ChangeHealth(float currentHealth)
    {
        
        Pivot.gameObject.SetActive(true);

        _healthUI.fillAmount = currentHealth / _maxHealth;
    
        currentHealthBar = _healthUI.fillAmount;
        StartCoroutine(DisableHealthBar(currentHealthBar));
        
    }
    private IEnumerator DisableHealthBar(float newFillAmount)
    {
        
        yield return new WaitForSeconds(5.0f);
        if (currentHealthBar == newFillAmount)
        {
            Pivot.gameObject.SetActive(false);
        }
        
        

    }
}
