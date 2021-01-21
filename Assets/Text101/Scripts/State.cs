using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//makes it self into a field and is assignable to itself when we created.
[CreateAssetMenu(menuName = "State")]
public class State : ScriptableObject
{
    //textarea makes a text area in the inspector in Unity.
    //textarea, det første tal bestemmer minimuns størrelsen i vores inspector hvor vi kan skrive i.
    //textarea, det andet tal bestemmer max størrelsen og bagefter laver en scrollbar.
    [TextArea(10, 14)][SerializeField] string storyText;
    [SerializeField] State[] nextStates;

    public string GetStateStory()
    {
        return storyText;
    }

    public State[] GetStateStories()
    {
        return nextStates;
    }

}
