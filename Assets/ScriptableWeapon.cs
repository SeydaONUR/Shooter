using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="Weapons")]
public class ScriptableWeapon : ScriptableObject
{
    //Silah bilgileri
    public float range;
    public float damage;
    public int ammo;
    public float waitToShot;
    public float reload;
}
