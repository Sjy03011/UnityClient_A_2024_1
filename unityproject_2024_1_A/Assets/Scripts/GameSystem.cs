using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Text;

#if UNITY_EDITOR
public class GameSystemEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        GameSystem gameSystem = (GameSystem)target;

        if (GUILayout.Button("Reset Story Models"))
        {
            gameSystem.ResetStoryModels();
        }
    }

}
#endif

public class GameSystem : MonoBehaviour
{
    public StoryModel[] storyModels;

    public static GameSystem instance;
  private void Awake()
    {
        instance = this;

    }

    public enum GAMESTATE
    {
        STROYSHOW,
        WAITSELECT,
        STORYEND,
        BATTLEMODE,
        BATTLEDONE,
        SHOPMODE,
        ENDMODE


    }

    public Stats stats;
    public GAMESTATE currentState;
    public int CurrentStorylndex = 1;

    StoryModel FindStoryModel(int number)
    {

        StoryModel tempStoryModels = null;

        for (int i =0; i<storyModels.Length;i++)
        {

            if (storyModels[i] .storyNumber == number)

            {

                tempStoryModels = storyModels[i];
                break;



            }

            return tempStoryModels;

        }




    }

    public void ChangeState(StoryModel.Result result)
    {
        if(result.stats.hpPoint >0) stats.hpPoint += result .stats .hpPoint;
        if(result.stats.hpPoint > 0) stats.spPoint += result.stats .spPoint;
        if (result.stats.currentHpPoint > 0) stats.currentHpPoint += result.stats.currentHpPoint;
        if (result.stats.currentSpPoint > 0) stats.currentHpPoint += result.stats.currentSpPoint;
        if(result.stats.currentxpPoint > 0) stats.currentHpPoint += result.stats.currentxpPoint;
        if (result.stats.strength > 0) stats.strength += result.stats. strength;
        if (result.stats.dexterity > 0) stats.dexterity += result.stats. dexterity;
        if (result.stats.consitiution > 0) stats.consitiution += result.stats.consitiution;
        if (result.stats.wisdom > 0) stats.hpPoint += result.stats.wisdom;
        if (result.stats.lntelligence > 0) stats.lntelligence += result.stats.lntelligence;
        if (result.stats.charisma> 0) stats.charisma > += result.stats .charisma;
    }






    StoryModel RandomStroy()
    {
        StoryModel tempStoryModeIs = null;
        List<StoryModel> storyModelList = new List<StoryModel>();

        for (int i = 0; i < storyModels.Length; i++)
       {
            if (storyModels [i].storytype == StoryModel .STORYTYPE.MAIN)
            {

                storyModelList.Add(storyModels[i]);

            }
        }
        tempStoryModeIs =  storyModelList[Random.Range(0, storyModelList.Count)];
        CurrentStorylndex = tempStoryModeIs.storyNumber;
        Debug.Log("currentStorylndex" + CurrentStorylndex);
        return tempStoryModeIs;

    }




#if UNITY_EDITOR
    [ContextMenu("Reset Story Models")]
    public void ResetStoryModels()
    {
        storyModels = Resources.LoadAll<StoryModel>(""); //Resources 폴더 아래 모든 StoryModel 불러오기
    }
#endif
    public void ApplyChoice(StoryModel.Result result)
    {
        switch(result.resultType)
        {
            case StoryModel.Result.ResultType.ChangeHp:
                ChangeState(result);
                break;


            case StoryModel.Result.ResultType.AddExperience:
                ChangeState(result);
                break;

            case StoryModel.Result.ResultType.GoToRandomStory:
                CurrentStorylndex = result.value;
                StoryShow(CurrentStorylndex);
                break;


        }


    }

    


    public void StoryShow(int number)
    {

        StoryModel tempStoryModel = FindStoryModel(number);



    }
}





