using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject[] screens;
    [SerializeField] GameObject[] inputfields;
    [SerializeField] PlayerMove player;
    [SerializeField] PlayerBuffs starts;
    [SerializeField] PlayerBuffs stats;
    [SerializeField] Weapon wepData;
    [SerializeField] bool nameSet;
    [SerializeField] bool startSelected;
    [SerializeField] bool plyUpgrade;
    [SerializeField] bool wepUpgrade;


    // Start is called before the first frame update
    void Start()
    {
        screens[0].SetActive(true);
        screens[1].SetActive(false);
        screens[2].SetActive(false);
        inputfields[0].SetActive(false);
        inputfields[1].SetActive(false);
        inputfields[2].SetActive(false);

    }

    public void RestartGameLoop()
    {
        screens[0].SetActive(true);
        screens[1].SetActive(false);
        screens[2].SetActive(false);
        screens[3].SetActive(false);
        inputfields[0].SetActive(false);
        inputfields[1].SetActive(false);
        inputfields[2].SetActive(false);
        inputfields[3].GetComponent<Button>().interactable = true;
        inputfields[4].GetComponent<Button>().interactable = true;
        inputfields[5].GetComponent<Button>().interactable = true;
    }

    // Update is called once per frame
    void Update()
    {
            if(stats.Health <= 0)
        {
            screens[0].SetActive(false);
            screens[1].SetActive(false);
            screens[2].SetActive(false);
            screens[3].SetActive(true);
            Time.timeScale = 0;
        }
        if (stats.levelUp == true)
        {
            screens[2].SetActive(true);
            Time.timeScale = 0;
            player.enabled = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            screens[0].SetActive(false);
            player.start = true;
        }
        SetUIAmounts();
    }

    public void CloseStart()
    {
        if (nameSet == true && startSelected == true)
        {
           
            screens[0].SetActive(false);
            screens[1].SetActive(true);
            inputfields[2].SetActive(true);
        }
    }

    public void UpgradeClose()
    {
        stats.levelUp = false;
        if (wepUpgrade == true && plyUpgrade == true)
        {
            player.enabled = true;
            screens[2].SetActive(false);
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            wepUpgrade = false;
            inputfields[15].SetActive(false);
            inputfields[12].GetComponent<Button>().interactable = true;
            inputfields[13].GetComponent<Button>().interactable = true;
            inputfields[14].GetComponent<Button>().interactable = true;

            plyUpgrade = false;
            inputfields[16].SetActive(false);
            inputfields[17].GetComponent<Button>().interactable = true;
            inputfields[18].GetComponent<Button>().interactable = true;
            inputfields[19].GetComponent<Button>().interactable = true;
        }
    }

    public void NameSet()
    {
        nameSet = true;
        inputfields[0].SetActive(true);
    }

    public void StartSelected()
    {
        startSelected = true;
        inputfields[1].SetActive(true);
        inputfields[3].GetComponent<Button>().interactable = false;
        inputfields[4].GetComponent<Button>().interactable = false;
        inputfields[5].GetComponent<Button>().interactable = false;
    }

    public void WepUpGradeSelected()
    {
        wepUpgrade = true;
        inputfields[15].SetActive(true);
        inputfields[12].GetComponent<Button>().interactable = false;
        inputfields[13].GetComponent<Button>().interactable = false;
        inputfields[14].GetComponent<Button>().interactable = false;
    }

    public void PlayerUpGradeSelected()
    {
        plyUpgrade = true;
        inputfields[16].SetActive(true);
        inputfields[17].GetComponent<Button>().interactable = false;
        inputfields[18].GetComponent<Button>().interactable = false;
        inputfields[19].GetComponent<Button>().interactable = false;
    }

    public void VitalityStart()
    {
        starts.HealthStart();
    }

    public void TankStart()
    {
        starts.AddDamage();
    }

    public void SpeedyStart()
    {
        starts.AddSpeed();
    }

    void SetUIAmounts()
    {
        inputfields[6].GetComponent<Text>().text = stats.Health.ToString("n0");
        inputfields[7].GetComponent<Text>().text = stats.speed.ToString("n0");
        inputfields[8].GetComponent<Text>().text = stats.damage.ToString("n0");
        inputfields[9].GetComponent<Text>().text = stats.Kills.ToString("n0");
        inputfields[10].GetComponent<Text>().text = wepData.currentAmmo.ToString("n0");
        inputfields[11].GetComponent<Text>().text = wepData.ammoCap.ToString("n0");
    }
}
