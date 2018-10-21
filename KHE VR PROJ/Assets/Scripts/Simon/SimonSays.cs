using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR;
public class SimonSays : MonoBehaviour {
    public VRInputs vrInput;

    public Text SimonSaysTextTemp;
    public Text SimonSaysActionText;
    public Text timerText;
    public Text counterText;
    public List<SimonAction> actions;
    public float timeBetweenSimonSaysDefault = .1f;
    public float timeBetweenSimonSays = .1f;
    public float timer;
    public float simonSaysPercent = .7f;
    bool doesHeSay = true;

    public int counter = 0;

    public bool lost;
    public bool actionFinished = false;
    // Use this for initialization
    void Start () {
        vrInput = GetComponent<VRInputs>();
        lost = true;
        SimonSaysTextTemp.text = "Press any Grip to begin";
    }
	
	// Update is called once per frame
	void Update () {


        if (vrInput.handGrip.GetStateDown(SteamVR_Input_Sources.Any))
        {
            startGame();
        }
            
    }
    public void startGame()
    {
        if (lost == true)
        {
            init();
            StartCoroutine(simonSays());
        }
    }
    public void init()
    {
        vrInput.playerHeight = vrInput.head.position.y;
        lost = false;
        counter = -1;
        counterText.text = "Actions Passed = 0";
        timeBetweenSimonSays = timeBetweenSimonSaysDefault;
    }
    IEnumerator simonSays()
    {
        while(!lost)
        {
            counter++;
            counterText.text = "Actions Passed = " + counter.ToString();
            SimonSaysTextTemp.text = "";
            SimonSaysActionText.text = "";
            int actionIndex = Random.Range(0, actions.Count);
            actionFinished = false;
            
            timeBetweenSimonSays = timeBetweenSimonSays * (1 - .025f);
            timeBetweenSimonSays = Mathf.Clamp(timeBetweenSimonSays, timeBetweenSimonSaysDefault / 2, timeBetweenSimonSaysDefault);
            yield return new WaitForSeconds(timeBetweenSimonSays);
            

            if (Random.Range(0, 101) <= 100 * simonSaysPercent)
            {
                SimonSaysTextTemp.text = "Simon Says: ";
                doesHeSay = true;
                
            }    
            else
            {
                int says = Random.Range(0, 5);
                switch(says)
                {
                    case 0:
                        SimonSaysTextTemp.text = "Salmon Says: ";
                        break;
                    case 1:
                        SimonSaysTextTemp.text = "Simins Says: ";
                        break;
                    case 2:
                        SimonSaysTextTemp.text = "Granny Says: ";
                        break;
                    case 3:
                        SimonSaysTextTemp.text = "Kent Hack Enough Says: ";
                        break;
                    case 4:
                        SimonSaysTextTemp.text = "Slymon Says: ";
                        break;
                    default:
                        SimonSaysTextTemp.text = "Lou Says: ";
                        break;
                }
                doesHeSay = false;
            }
                

            SimonSaysActionText.text = actions[actionIndex].actionName;
            

            actions[actionIndex].ActionStart(vrInput);
            timer = actions[actionIndex].actionTime * (1 - .020f * counter);
            timer = Mathf.Clamp(timer, actions[actionIndex].actionTime / 2, actions[actionIndex].actionTime);
            while (timer > 0 && !lost && !actionFinished)
            {
                timerText.text = timer.ToString();
                timer -= Time.deltaTime;

                if (actions[actionIndex].CheckAction(doesHeSay))
                {
                    actionFinished = true;
                }
                yield return null;
            }
            actions[actionIndex].ActionEnd();
            lost = (actionFinished != doesHeSay);
            
            
        }
        counter--;
        timerText.text = "";
        SimonSaysTextTemp.text = "You Lost";
        SimonSaysActionText.text = "You Lost";
        yield return new WaitForSeconds(1);
        SimonSaysActionText.text = "";
        SimonSaysTextTemp.text = "Press any Grip to begin";
        yield return null;
    }
}
