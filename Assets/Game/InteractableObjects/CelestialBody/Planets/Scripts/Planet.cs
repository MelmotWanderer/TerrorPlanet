using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : CelestialBody
{
    
    
    public void SetMesh(MeshRenderer meshRenderer, MeshFilter meshFilter)
    {
        GetComponent<MeshFilter>().sharedMesh = meshFilter.sharedMesh;
        GetComponent<MeshRenderer>().sharedMaterials = meshRenderer.sharedMaterials;
        GetComponent<Rotator>().SetSpeedRotation(SpeedRotation);
    }
}
