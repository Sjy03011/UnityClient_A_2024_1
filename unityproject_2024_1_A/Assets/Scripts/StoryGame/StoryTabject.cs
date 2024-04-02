using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace STORYGAME
{
    [CreateAssetMenu(fileName = "NewStory", menuName = "ScriptableObjects/StoryTableObject")]
    public class StoryTableObject : ScriptableObject
    {
        public int storyNumber;         //���丮 ��ȣ
        public Enums.StoryType storyType;   //���丮 Ÿ�� ����
        public bool storyDone;

        [TextArea(10, 10)]      //�ؽ�Ʈ ���� ǥ��
        public string storyText;        //���� ���丮
        public List<Option> options = new List<Option>();

        [System.Serializable]
        public class Option
        {
            public string optionText;
            public string buttonText;
            public EventCheck eventCheck;
        }
        [System.Serializable]
        public class EventCheck
        {
            public int checkValue;
            public Enums.EvenType eventType;
            public List<Reslut> successResult = new List<Reslut>();
            public List<Reslut> failResult = new List<Reslut>();
        }
        [System.Serializable]
        public class Reslut
        {
            public Enums.ResultType resultType;
            public int value;
            public Stats stats;
        }
    }
}
