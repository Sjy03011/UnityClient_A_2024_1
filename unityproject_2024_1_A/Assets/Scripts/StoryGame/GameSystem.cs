using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;          //������
using System.Text;          //�ؽ�Ʈ ���
using UnityEngine.UI;       //UI ����ϱ�����
using TMPro;

namespace STORYGAME //�̸� �浹 ����
{
#if UNITY_EDITOR
    [CustomEditor(typeof(GameSystem))]
    public class GameSystemEditor : Editor              //����Ƽ ��Ƽ���� ���
    {
        public override void OnInspectorGUI()               //�ν����� �Լ��� ������ 
        {
            base.OnInspectorGUI();                          //���� �ν����͸� �����ͼ� ����

            GameSystem gameSystem = (GameSystem)target;     //���� �ý��� ��ũ��Ʈ Ÿ���� ����

            if (GUILayout.Button("Reset Stroy Models"))          //��ư�� ���� 
            {
                gameSystem.ResetStoryModels();
            }

            if (GUILayout.Button("Assing Text Component by Name"))          //��ư�� ����(UI ������Ʈ�� �ҷ��´�)
            {
                //������Ʈ �̸����� Text ������Ʈ ã��
                GameObject textObject = GameObject.Find("StroyTextUI");
                if (textObject != null)
                {
                    Text textComponent = textObject.GetComponent<Text>();
                    if (textComponent != null)
                    {
                        //Text Component �Ҵ�
                        gameSystem.textComponent = textComponent;
                        Debug.Log("Text Componet assigned Successfully");
                    }


                }
            }


        }
    }
#endif
    public class GameSystem : MonoBehaviour
    {
        public static GameSystem instance;              //������ �̱��� ȭ
        public Text textComponent = null;

        public float delay = 0.1f;                      //�� ���ڰ� ��Ÿ���� �� �ɸ��� �ð�
        public string fullText;                         //��ü ǥ���� �ؽ�Ʈ
        public string currentText = "";                 //������� ǥ�õ� �ؽ�Ʈ

        public enum GAMESTATE                           //���°� ���� ������
        {
            STORYSHOW,
            WAITSELECT,
            STROTYEND,
            ENDMODE
        }

        public GAMESTATE currentState;
        public StoryTableObject[] storyModels;          //������ �ִ��� �𵨵� �ҽ��ڵ� ��ġ �̵�
        public StoryTableObject currentModels;          //���� ���丮 �� ��ü
        public int currentStoryIndex;                   //���丮 �� �ε���
        public bool showStroy = false;



        private void Awake()
        {
            instance = this;
        }

        public void Start()                     //���� ���۽�
        {
            StartCoroutine(ShowText());         //�ؽ�Ʈ�� �����ش�.
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q)) StoryShow(1);
            if (Input.GetKeyDown(KeyCode.W)) StoryShow(2);
            if (Input.GetKeyDown(KeyCode.E)) StoryShow(3);

            if (Input.GetKeyDown(KeyCode.Space))
            {

                currentText = currentModels.storyText;
                textComponent.text = currentText;
                StopCoroutine(ShowText());
                showStroy = false;




            }


            if(Input.GetKeyDown(KeyCode.Space))
            {
                delay = 0.0f;
            }



        }    

        public void StoryShow(int number)
        {
            if(!showStroy)
            {

                currentModels = FindStoryModel(number);
                delay = 0.1f;
                StartCoroutine(ShowText());


            }

          


        }
      






        StoryTableObject FindStoryModel(int number)
       {
            StoryTableObject tempsStoryModels = null;
            for(int i=0; i< storyModels.Length; i++)
            {
                if (storyModels[i].storyNumber == number)
                {
                    tempsStoryModels = storyModels[i];
                    break;

                }

            }
            return tempsStoryModels;
        }
        IEnumerator ShowText()
        {
            showStroy = true;
            for (int i = 0; i <= currentModels.storyText.Length; i++)
            {
                currentText = currentModels.storyText.Substring(0, i);
                textComponent.text = currentText;
                yield return new WaitForSeconds(delay);
            }

            yield return new WaitForSeconds(delay);
            showStroy = false;
        }   

#if UNITY_EDITOR
        [ContextMenu("Reset Stroy Models")]

        public void ResetStoryModels()
        {
            storyModels = Resources.LoadAll<StoryTableObject>("");// Resources ���� �Ʒ� ��� StroyModel �ҷ� ����
        }
#endif
    }
}