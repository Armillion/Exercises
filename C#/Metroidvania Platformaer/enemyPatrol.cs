using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class enemyPatrol : MonoBehaviour
{
    public List<Transform> objectives;          //list of points the AI would move to
    AIPath ai;                                  //AI itself
    AIDestinationSetter destinationSetter;      //object defining current objective
    public int currentObjective = 1;                   //a value I use to track what point is AI moving to

    //get needed components and set our first target
    void Start()
    {
        ai = GetComponent<AIPath>();
        destinationSetter = GetComponent<AIDestinationSetter>();
        destinationSetter.target = objectives[0];
    }

    void Update()
    {
        //if AI does not have more objectives to fullfill, start again
        if(currentObjective >= objectives.Count)
        {
            currentObjective = 0;
        }

        //if AI reaches current obj go to the next one
        if(ai.reachedDestination)
        {
            destinationSetter.target = objectives[currentObjective];
            currentObjective++;
        }
    }
}
