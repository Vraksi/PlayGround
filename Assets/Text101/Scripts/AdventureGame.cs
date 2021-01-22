using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class AdventureGame : MonoBehaviour
{
    [SerializeField] Text textComponent;
    //we have assigned state in the editor corresponding to the state we've made called the name of the variable we made.
    [SerializeField] State startingState;

    TextActions controls;
    //float action;

    State state;

    private void Awake()
    {
        controls = new TextActions();

        //controls.Moving.Action.performed += ctx => action = ctx.ReadValue<float>();
        controls.Moving.Action.performed += ctx => ManageState(ctx.ReadValue<float>());
    }

    // Start is called before the first frame update
    void Start()
    {
        state = startingState;
        textComponent.text = state.GetStateStory();
    }

    // Update is called once per frame
    void Update()
    {
        
        //ManageState();
    }

    private void ManageState(float action)
    {
        Debug.Log(action);
        var nextStates = state.GetStateStories();
        //minus 1 for at få den korrekte plads i vores array.
        action -= 1;
        for (int i = 0; i < nextStates.Length; i++)
        {
            if (action == i)
            {
                state = nextStates[i];
            }
        }
        textComponent.text = state.GetStateStory();
        /*
                Debug.Log(action);
                var nextStates = state.GetStateStories();
                if (action == 1)
                {
                    state = nextStates[0];
                }
                else if (action == 2)
                {
                    state = nextStates[1];
                }
                else if (action == 3)
                {
                    state = nextStates[2];
                }

                action = 0;
        */
    }

    private void OnEnable()
    {
        controls.Moving.Enable();
    }

    //Skal være med for Disable vores movement input control
    private void OnDisable()
    {
        controls.Moving.Disable();
    }
}
