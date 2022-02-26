using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceFactory : MonoBehaviour
{

    [SerializeField] private SettingSpace settingSpace;
    [SerializeField][Range(1, 1000)] private int _countPlanet;
    [SerializeField] CelestialBodyFactory celestialBodyFactory;
    [SerializeField] private int _densityCelestialBody;
    private void Awake()
    {
        _countPlanet = settingSpace.CountPlanet;
        _densityCelestialBody = settingSpace.DensityPlanet;
    }
    void Start()
    {
        Create();
        Destroy(gameObject);
    }
    
   
    void Create()
    {
      
        Vector3 pos = Vector3.zero;
        for (int i = 0; i < _countPlanet; i++)
        {
          
            pos = new Vector3(Random.Range(1, _countPlanet * _densityCelestialBody), 1.0f, Random.Range(1, _countPlanet * _densityCelestialBody));
           

            celestialBodyFactory.CreateCelestialBody(pos);

        }
        settingSpace.ResetSetting();
    }
}
