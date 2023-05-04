using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    /**
     * The SceneController class will control all loading
     * of scenes and will make sure that the Player object that we
     * have is going to stay persistent throughout the whole
     * game.ller
     */
    private static bool created = false;
    private static bool justLoaded = false;
    private string nextSpawnStringName;
    private int currentScene;

    private void Start()
    {
        nextSpawnStringName = "StartGameSpawn";
        currentScene = 1;
    }

    private void Awake()
    {
        if (!created)
        {
            DontDestroyOnLoad(this.gameObject);
            created = true;
        }
    }

    private void Update()
    {
        if (justLoaded) 
        { 
            GameObject overworldFromCaveSpawn = GameObject.Find(nextSpawnStringName);
            overworldFromCaveSpawn = GameObject.Find(nextSpawnStringName);
            GameObject playerObject = GameObject.Find("Player");
            playerObject.transform.position = overworldFromCaveSpawn.transform.position;
            justLoaded = false;
        }
    }

    public void startGame()
    {
        SceneManager.LoadScene(1);
        currentScene = 1;

        // Teleport to the start of the game
        nextSpawnStringName = "StartGameSpawn";
        justLoaded = true;
    }
    public void overworldFromCave()
    {
        SceneManager.LoadScene(1);
        currentScene = 1;

        // Teleport to the overworldFromCaveSpawn
        nextSpawnStringName = "OverworldFromCaveSpawn";
        justLoaded = true;
    }

    public void caveFromOverworld()
    {
        SceneManager.LoadScene(2);

        nextSpawnStringName = "CaveEntranceSpawn";
        justLoaded = true;
    }

    public void castleFromOverworld()
    {
        SceneManager.LoadScene(3);
        currentScene = 3;

        nextSpawnStringName = "Spawn Point Entrance";
        justLoaded = true;
    }

    public void overworldFromCastle()
    {
        SceneManager.LoadScene(1);
        currentScene = 1;

        // Teleport to the spawn
        nextSpawnStringName = "Spawn Point Entrance";
        justLoaded = true;
    }

    public void respawnPlayerInScene()
    {
        SceneManager.LoadScene(currentScene);

        // Next spawn string name should just stay the same on respawn

        // Make if statements depending on the level (e.g. if castle level, make sure keys are reset to 0)
        justLoaded = true;
    }

    public Scene getActiveScene()
    {
        return SceneManager.GetActiveScene();
    }

    public void setNextSpawnName(string name){
        nextSpawnStringName = name;
    }
}
