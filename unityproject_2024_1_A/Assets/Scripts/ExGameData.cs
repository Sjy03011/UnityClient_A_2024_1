using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="ExGamData",fileName = "NeW ExgameData",order = 50)]
public class ExGameData : ScriptableObject 
{
    public string gameName;
    public int gsmeScore;
    public bool isGameActive;
}
