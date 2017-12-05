using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using Assets.Scripts.Canvases_;


public class MissionButton : MonoBehaviour
{

    #region Variables
    //premenné
    public float lowerReward, higherReward;
    public float baseTime;
    private float timer = 0f;
    private bool isClicked = false;
    public float addWanted;
    //UI elementy
    public Image loadingMissionBar;
    public Text reward, duration;
    public Button missionButton;
    public CharacterStats player;
    public AudioSource clickSource, finishedSource;
    public AudioClip clickClip, finishedClip;
    #endregion
    
    //akcia ktorá sa vykoná po stlačení
    public void Click()
    {
        clickSource.clip = clickClip;
        finishedSource.clip = finishedClip;

        clickSource.Play();

        player.AddNumberOfMissions(1);                                                                                                  //zvys misie o jednu
        timer = baseTime+(baseTime* player.drunk);                                                                                      //nastav casovac na hodnotu zadanú v prostredí unity
        StartCoroutine(AddMoney());                                                                                                    //po čase pridaj love
        player.AddWanted(addWanted);                                                                                              //pridaj hviezdicku

    }
    public void Update()
    {

        missionButton.interactable = (isClicked || player.numberOfMissions >= 3) ? false : true;                                   //ak je pocet aktuálne sa konajúcich misií menší ako 3 nastav klikatelnost na moznu, ak je 3 zrus klikatelnost

        if (timer > 0)                                                                                                             // ak je časovač väčší ako 0 - tzn. beží couroutine
            {
                timer -= Time.deltaTime;                                                                                               //po sekundách znižuj čas
                TimeSpan time_Span = TimeSpan.FromSeconds(timer);                                                                      //premenná time span ktorá rozdelí čas na hodiny, minuty a sekundy
                string time_Text = string.Format("{0:D2}:{1:D2}:{2:D2}", time_Span.Hours, time_Span.Minutes, time_Span.Seconds);       //hodiny, minuty, sekundy do textu
                loadingMissionBar.fillAmount = timer / baseTime;                                                                       //odlievaj z obrázku -> loading bar
                reward.text = "Reward: " + (lowerReward + (lowerReward * player.skill.GetValue())/10) + " - " + (higherReward + (higherReward * player.skill.GetValue())/10);
            duration.text = "Duration: " + string.Format("{0:D2}:{1:D2}:{2:D2}", TimeSpan.FromSeconds(timer).Hours, TimeSpan.FromSeconds(timer).Minutes, TimeSpan.FromSeconds(timer).Seconds);

            isClicked = true;                                                                                                      //klikateľnosť na true
            }
            else if (timer <= 0)                                                                                                       //ak je časovač menší alebo rovný nule
            {                                                                                                                          //ak je kliknuté tlačidlo
                if (isClicked)
                {
                player.DecreaseNumberOfMissions(1);                                                                                      //uber pocer misií
                finishedSource.Play();
            }
            loadingMissionBar.fillAmount = 1;                                                                                      //napln loading bar
            isClicked = false;                                                                                                     //klikateľnosť na false
            reward.text = "Reward: " + (lowerReward + (lowerReward * player.skill.GetValue())/10) + " - " + (higherReward + (higherReward * player.skill.GetValue())/10);     //zobraz v texte reward a čas do ukončenia
            duration.text = "Duration: " + string.Format("{0:D2}:{1:D2}:{2:D2}", TimeSpan.FromSeconds(baseTime).Hours, TimeSpan.FromSeconds(baseTime).Minutes, TimeSpan.FromSeconds(baseTime).Seconds);
            }

    }

    IEnumerator AddMoney()                                                                                                         //coroutine pridaj peniaze a.k.a casovac
    {
        yield return new WaitForSeconds(timer);                                                                                    //počkaj určitý čas (timer)
        int pomoc = (int)UnityEngine.Random.Range(lowerReward+(lowerReward*player.skill.GetValue()/10), higherReward + (higherReward * player.skill.GetValue()) /10);
        player.AddMoney(pomoc);                                           //po ubehnutí času pridaj hráčovi peniaze
        //AchievementController.instance.earnedMoney += pomoc;
    }
}
