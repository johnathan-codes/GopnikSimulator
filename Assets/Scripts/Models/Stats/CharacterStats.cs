using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CharacterStats : MonoBehaviour
{
    //public static CharacterStats instance;
    public float maxHealth = 100;
    public float currentHealth { get; private set; }
    public float brubles { get; private set; }
    public float cancer { get; private set; }
    public float drunk { get; private set; }
    public float wantedLVL { get; private set; }

    public int numberOfMissions { get; private set; }

    #region Konštruktory

    public CharacterStats(){}

    public CharacterStats (float mx, float ch, float b, float c, float d, float wl, int naMiss)
    {
        maxHealth = mx;
        currentHealth = ch;
        brubles = b;
        cancer = c;
        drunk = d;
        wantedLVL = wl;
        numberOfMissions = naMiss;
    }
    
    #endregion

    public Stat skill;
    public Text brublesText, hpText, cancerText, drunkText, skillText;// popUp;
    public Image wantedImage, hpImage, cancerImage, drunkImgae, skillImage;

    void Awake()
    {
        //currentHealth = maxHealth;
    }

    #region Health
    public void RestoreHealth(float amount)
    {
        if ((currentHealth + amount) >= maxHealth)
        {
            currentHealth = maxHealth;
        }
        else currentHealth += amount;

    }

    public void SetHealth(float amount)
    {
        currentHealth = amount;
    }

    public void IncreaseHealth(float amount)
    {
        maxHealth += amount;
    }
    public void DecreaseHealth(float amount)
    {
        amount += cancer;
        amount = Mathf.Clamp(amount, 0, int.MaxValue); //nikdy nepôjde pod nulu, je to v tomto prípade zbytočné

        currentHealth -= amount;
        Debug.Log("Reduced health by: " + amount + " points.");

        if (currentHealth <= 0)
        {
            Die();
        }
    }
    #endregion

    #region Cancer
    public void AddCancer(int amount)
    {
        cancer += amount;
    }
    public void DecreaseCancer(int amount)
    {
        cancer -= amount;
    }

    public void SetCancer(float amount)
    {
        cancer = amount;
    }
    #endregion

    #region Money
    public void SetMoney(float amount)
    {
        brubles = amount;
    }

    public void AddMoney(float amount)
    {
        brubles += amount;
    }
    public void DecreaseMoney(float amount)
    {
        brubles -= amount;
    }
    #endregion

    #region NumberOfMissions
    public void AddNumberOfMissions(int amount)
    {
        numberOfMissions += amount;
    }
    public void DecreaseNumberOfMissions(int amount)
    {
        numberOfMissions -= amount;
    }
    public void SetNumberOfMissions(int amount)
    {
        numberOfMissions = amount;
    }
    #endregion

    #region Wanted
    public void AddWanted(float amount)
    {
        wantedLVL += amount;
    }

    public void DecreaseWanted(float amount)
    {
        wantedLVL -= amount;
    }

    public void SetWanted(float amount)
    {
        wantedLVL = amount;
    }
    #endregion

    #region Drunk
    public void AddDrunk(float amount)
    {
        drunk += amount;
    }
    public void DecreaseDrunk(float amount)
    {
        drunk -= amount;
    }
    public void SetDrunk(float amount)
    {
        drunk = amount;
    }

    #endregion
    public virtual void Die()
    {
        Debug.Log("You died!");
        GameObject.Find("PaperWork").GetComponent<Canvas>().enabled = false;
        GameObject.Find("MenuAndStats").GetComponent<Canvas>().enabled = false;
        GameObject.Find("Missions").GetComponent<Canvas>().enabled = false;
        GameObject.Find("Shop").GetComponent<Canvas>().enabled = false;
        GameObject.Find("Inventory_C").GetComponent<Canvas>().enabled = false;
        GameObject.Find("StartUp").GetComponent<Canvas>().enabled = false;
        GameObject.Find("Death").GetComponent<Canvas>().enabled = true;
    }
    void Update()
    {
        //brubles
        brublesText.text = brubles.ToString(); //konvert float na string
        wantedImage.fillAmount = wantedLVL / 5; //každý jeden wanted je 20 %
        //health
        hpImage.fillAmount = currentHealth / 100;
        hpText.text = "HP: " + currentHealth;
        //cancer
        cancerImage.fillAmount = cancer / 100;
        cancerText.text = "CANCER: " + cancer;
        //drunk
        drunkImgae.fillAmount = drunk / 100;
        drunkText.text = "DRUNK: " + drunk;
        //skill
        skillImage.fillAmount = skill.GetValue() / 250;
        skillText.text = "SKILL: " + skill.GetValue();

        GameObject.Find("current_crim_bonus").GetComponent<Text>().text = "CURRENT CRIMINAL BONUS: " + skill.GetValue();

        if(wantedLVL >= 5)
        {
            brubles = brubles / 2;
            wantedLVL = 0;
            GameObject.Find("caught_text").GetComponent<Text>().enabled = true;
            StartCoroutine(HideCaught());
        }
    }

    void Start()
    {
        EquipmentManager.instance.onEquipmentChanged += OnEquipmentChanged;
        StartCoroutine(DecreaseHealth());
    }

    void OnEquipmentChanged(Equipment newItem, Equipment oldItem)
    {
        if (newItem != null)
        {
            skill.AddModifier(newItem.bonusCrim);
        }

        if (oldItem != null)
        {
            skill.RemoveModifier(oldItem.bonusCrim);
        }
    }
 
    IEnumerator DecreaseHealth()
    {
        yield return new WaitForSecondsRealtime(10);
        currentHealth -= 1 + (1 * cancer);
        StartCoroutine(DecreaseHealth());
    }
    IEnumerator HideCaught()
    {
        yield return new WaitForSecondsRealtime(10);
        GameObject.Find("caught_text").GetComponent<Text>().enabled = false;
    }
}