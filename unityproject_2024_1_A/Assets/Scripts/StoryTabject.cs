using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace STORYGAME
{
    [CreateAssetMenu(fileName = "NewStory", menuName = "SriptableObjects/StoryTableObject")]

    public class StoryTableObject : ScriptableObject
    {
        public int storyNumber;
        public Exnums.StoryType storyType;
        public bool storyDone;

        [TextArea(10, 10)]
        public string storyText;

        [System.Serializable]

        public class EventCheck
        {
            public int checkValue;
            public Exnums.EvenType eventType;
            public List<Reslut> successResult = new List<Reslut>();
            public List<Reslut> failResult = new List<Reslut>();
        }
        [System.Serializable]
        public class Option
        {
            public string optionText;
            public string buttonText;

        }

        [System.Serializable]

        public class Reslut
        {
            public Exnums.ResultType resultType;
            public int value;
            public Stats stats;
        }


    }
}
