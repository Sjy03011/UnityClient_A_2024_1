using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExGameManager : MonoBehaviour
{
    public ExGameData gameDate;

    void Start()
    {
        Debug.Log("Game Name : " + gameDate.gameName);
        Debug.Log("Game Score : " + gameDate.gsmeScore);
        Debug.Log("ls Game Active : " + gameDate.isGameActive);
    }
}
