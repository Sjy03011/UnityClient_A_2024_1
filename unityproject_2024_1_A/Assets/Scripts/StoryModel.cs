using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "NewStory", menuName = "SriptableObjects/StorjMpdel")]
public class StoryModel : MonoBehaviour
{
    public int storyNumber;
    public Texture2D Mainlmage;

    public enum STORYTYPE
    {
      MAIN,
      SUB,
      SERIAL


    }

    public STORYTYPE storytype;
    public bool stortDone;

    [TextArea(10, 10)]
    public string storyText;

    public Option[] optioms;

    [System.Serializable]
    public class Result
    {

        public enum ResultType : int
        {
              
            ChangeHp,
            ChangeSp,
            AddExperience,
            GoToNextStory,
            GoToRandomStory,
            GoToEndine




        }

        public ResultType resultType;
        public int value;
        public Stats stats;

    
    }

    [System.Serializable]
    public class EventCheck
    {
        public int checkValue;

        public enum EventType : int
        {
            NONE,
            GoToBattle,
            CheckSTR,
            CheckDEX,
            CheckCON,
            CheckINT,
            CheckWIS,
            CheckCHA

        }


        public EventType eventType;
        public Result[] suceessResult;
        public Result[] failResult;


        [TextArea(10, 10)]
        public string storyText;

        public Option[] options;
        [System.Serializable]
        public class Option
        {
            public string optionText;
            public string buttonText;

        }

        [System.Serializable]

        public class EventOhecK
        {



        }



    }
}
