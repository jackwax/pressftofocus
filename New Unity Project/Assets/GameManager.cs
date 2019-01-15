using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    //state manager class that acts as controller between game logic



    public StateMachine gameState;

    [SerializeField] private Queue<IState> states;


    


	// Use this for initialization
	void Start () {
        gameState = this.GetComponent<StateMachine>();
        //we can probably just leave the
        if (states == null)
        {
            states = new Queue<IState>();
        }

        sortStates();


        initStates();

        gameState.ChangeState(states.Dequeue());
		
	}

    public void sortStates()
    {
        ///ughhhhh i have to make a sorting algorithm...
        //might be a good lesson tho! :'(


        for (int i = 0; i < Priority.GOSTATES.Count- 1; i++)
        {
            for (int j = 0; j < Priority.GOSTATES.Count - i - 1; j++)
            {
                if (Priority.GOSTATES[j].priority > Priority.GOSTATES[j+1].priority)
                {
                    Priority temp = Priority.GOSTATES[j];
                    Priority.GOSTATES[j] = Priority.GOSTATES[j + 1];
                    Priority.GOSTATES[j + 1] = temp;
                }

            }

        }
        foreach (Priority p in Priority.GOSTATES)
        {
            print(p.gameObject.name);
        }
    }

    public void initStates()
    {
        List<Priority> gos = Priority.GOSTATES;

        states.Enqueue(new LoadingBarState(gos[0].gameObject, ComputerLoaded));
        //print(gos[0].gameObject.name);
        gos[0].gameObject.SetActive(false);

        states.Enqueue(new DesktopVideoState(gos[1].gameObject, ComputerLoaded));
        gos[1].gameObject.SetActive(false);

        states.Enqueue(new BenjiChatState(gos[2].gameObject));
        gos[2].gameObject.SetActive(false);




        //states.Enqueue(new )


    }

	
	// Update is called once per frame
	void Update () {
        this.gameState.ExecuteStateUpdate();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //pause menu

        }

		
	}

    public void ComputerLoaded()
    {
        //trigger the desktop cartridge
        //for now, let's just trigger the chat cartridge
        this.gameState.ChangeState(states.Dequeue());

    }
}
