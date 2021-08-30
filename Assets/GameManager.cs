using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] PlayerBuffs player;
    [SerializeField] PlayerMove ply;
    [SerializeField] Weapon wepData;
    [SerializeField] Enemy[] enemies;
    [SerializeField] Transform[] Spawns;
    [SerializeField] GameObject[] enemiesSpawned;
    [SerializeField] UIManager UI;
    public int enemyCount = 10;
    public int roundCount;
    

 

    private void Start()
    {
        player.killLvLCap = 10;
        enemyCount = 10;
    }

    private void Update()
    {

        if (ply.dead == true)
        {
            enemiesSpawned = GameObject.FindGameObjectsWithTag("Enemy");
            for (int i = 0; i < enemiesSpawned.Length; i++)
            {
                Destroy(enemiesSpawned[i].gameObject);
            }

        }
        player.enemycount = enemyCount;
    }

  public  void GameStart()
    {
        enemyCount = 10;
        
        if (roundCount == 0)
        {
            roundCount = roundCount + 1; 
        }
        
        if (enemiesSpawned.Length < enemyCount)
        {
            for (int i = 0; i < enemyCount; i++)
            {
                int randEnemy = Random.Range(0, enemies.Length);
                int randspawn = Random.Range(0, Spawns.Length);
                Instantiate(enemies[randEnemy], Spawns[randspawn]);
                GameObject[] enemiesSpawned = GameObject.FindGameObjectsWithTag("Enemy");
            }
        }
       
    }

   public void WaitForRoundEnd()
    {
        enemiesSpawned = new GameObject[0];
        enemyCount = enemyCount + 5;
            roundCount = roundCount + 1;
            NextRound();
    }

    public void NextRound()
    {
        player.Health = player.CurrentMaxHealth;
        player.LevelCap();
        
        if (enemiesSpawned.Length < enemyCount)
        {
            for (int i = 0; i < enemyCount; i++)
            {
                int randEnemy = Random.Range(0, enemies.Length);
                int randspawn = Random.Range(0, Spawns.Length);
                Instantiate(enemies[randEnemy], Spawns[randspawn]);
                GameObject[] enemiesSpawned = GameObject.FindGameObjectsWithTag("Enemy");
            }
        }

    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void RestartGame()
    {
        ply.ResetBaseStats();
        UI.RestartGameLoop();
    }

}
