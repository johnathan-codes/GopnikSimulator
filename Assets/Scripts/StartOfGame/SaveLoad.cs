using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.StartOfGame
{ 
    public class SaveLoad: MonoBehaviour
    {
        public CharacterStats character;

        public void SaveGame()
        {
            PlayerPrefs.SetFloat("maxHP", character.maxHealth);
            PlayerPrefs.SetFloat("currHP", character.currentHealth);
            PlayerPrefs.SetFloat("brubles", character.brubles);
            PlayerPrefs.SetFloat("cancer",character.cancer);
            PlayerPrefs.SetFloat("wantedLVL", character.wantedLVL);
            PlayerPrefs.SetFloat("drunk", character.drunk);
            PlayerPrefs.SetInt("naMissions", character.numberOfMissions);
        }


        public void LoadGame()
        {
            character.maxHealth = PlayerPrefs.GetFloat("maxHP");
            character.SetHealth(PlayerPrefs.GetFloat("currHP"));
            character.SetMoney(PlayerPrefs.GetFloat("brubles"));
            character.SetCancer(PlayerPrefs.GetFloat("cancer"));
            character.SetWanted(PlayerPrefs.GetFloat("wantedLVL"));
            character.SetDrunk(PlayerPrefs.GetFloat("drunk"));
            character.SetNumberOfMissions(PlayerPrefs.GetInt("naMissions"));
        }

        public void NewGame()
        {
            //TODO delete all datas
            PlayerPrefs.DeleteAll();
        }
    }
}
