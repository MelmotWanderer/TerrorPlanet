using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CelestialBodyFactory : MonoBehaviour
{
    [SerializeField] private Planet _emptyPlanet;
    [SerializeField] private GameObject[] _planets;
    [SerializeField] private Transform Folder;
    public CelestialBody CreateCelestialBody(Vector3 pos)
    {
        GameObject _planet = _planets[Random.Range(0, _planets.Length)];
        var planet =  Instantiate(_emptyPlanet, pos, Quaternion.identity);
        planet.SetMesh(_planet.GetComponent<MeshRenderer>(), _planet.GetComponent<MeshFilter>());
        if(Folder != null)
        {
            planet.transform.parent = Folder;
        }
       
        return planet;


    }
}
