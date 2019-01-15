using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameGameManager : MonoBehaviour {
    private StateMachine sm;

    public Dictionary<string, IState> gamestates;

	// Use this for initialization
	void Start () {
        sm = this.GetComponent<StateMachine>();
        //sm.ChangeState (new SecretOfLifeMenuState()
		
	}

    private void init()
    {
        gamestates = new Dictionary<string, IState>();
        gamestates.Add("MainMenu", new SecretOfLifeMenu(GameObject.Find("MenuScreenCanvas")));
        


    }

    public void StartGame()
    {
        Debug.Log("Game Started!");
        this.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update () {
		
	}
}
