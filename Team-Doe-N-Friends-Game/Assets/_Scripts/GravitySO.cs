using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Gravity SO", menuName = "Gravity")]
public class GravitySO : ScriptableObject
{
    [SerializeField] public bool gravityIsReversed;
}
