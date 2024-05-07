using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum StoryType
{
    MAIN,
    SUB,
    SERAL


}

public enum EvenType
{
    NONE,
    GoToBattle = 100,
    CeckSTR = 1000,
    CheckDEX,
    CheckCon,
    CheckINT,
    CHECKWIS,
    CHeckCHA

}

public enum ResultType
{
    ChangeHp,
    ChanageSp,
    AddExperience,
    GoToShop,
    GoToNexdStory,
    GoToRandomStory,
    GoToEnding


}

[System.Serializable]
public class Stats
{
    public int hpPoint;
    public int spPoint;


    public int currentHpPoint;
    public int currentSpPoint;
    public int currentxpPoint;

    public int strength;
    public int dexterity;
    public int consitiution;
    public int wisdom;
    public int lntelligence;
    public int charisma;


}
    

  