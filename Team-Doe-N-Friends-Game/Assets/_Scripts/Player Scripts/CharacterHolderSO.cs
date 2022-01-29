using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Character Holder SO", menuName = "Character Holder")]
public class CharacterHolderSO : ScriptableObject{
   [SerializeField] public GravitySO gravitySo;
   [SerializeField] public LifeStateSO lifeStateSo;
   [SerializeField] public RespawnSO respawnSo;
}
