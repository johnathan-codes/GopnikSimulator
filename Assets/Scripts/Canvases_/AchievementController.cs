using System;
using System.Collections;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Canvases_
{
    public class AchievementController: MonoBehaviour
    {
        #region Premenné
        public static AchievementController instance;// = new AchievementController();
        public float earnedMoney = 0;
        public float spentMoney = 0;
        public int missionsDone = 0;
        public bool paperWorkDone = false;
        public bool[] achsDone; //pole achievementov ako helper
        #endregion

        public void Start()
        {
            StartCoroutine(CheckAch());
            achsDone = new bool[5]; //1-earnend money, 2 - spent money, 3 - missions done, 4 - Paper Work done, 5 - all achievements

            for (int i = 0; i < achsDone.Length; i++ )
            {
                achsDone[i] = false;
            }
        }

        public void CheckSmthg()
        {
            if ((earnedMoney > 500000) && (achsDone[1] == false))
            {
                achsDone[1] = true;
                //ach.visible = true;
            }

            if((spentMoney > 500000) && (achsDone[2] == false))
            {
                achsDone[2] = true;
                //ach.visible = true;
            }

            if((missionsDone > 25) && (achsDone[3] == false))
            {
                achsDone[3] = true;
                //ach.visible = true;
            }

            if((paperWorkDone) && (achsDone[4] == false))
            {
                achsDone[4] = true;
                //ach.visible = true;
            }

            if((achsDone[1])&&(achsDone[2]) &&(achsDone[3]) &&(achsDone[4])&&(achsDone[5]))
            {
                achsDone[5] = true;
                //ach.visible = true;
            }
        }

        IEnumerator CheckAch()
        {
            yield return new WaitForSecondsRealtime(15);
            CheckSmthg();
            StartCoroutine(CheckAch());
        }
    }
}
