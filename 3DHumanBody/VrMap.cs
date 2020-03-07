
Vr Rig (Robot Kylie)
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class VrMap
{
    public Transform vrTarget;
    public Transform rigTarget;
    public Vector3 trackingpositionoffset;
    public Vector3 trackingrotationoffset;

    public void Map()
    {
        rigTarget.position = vrTarget.TransformPoint(trackingpositionoffset);
        rigTarget.rotation = vrTarget.rotation * Quaternion.Euler(trackingrotationoffset);
    }
}