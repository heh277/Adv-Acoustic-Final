using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MenuController : MonoBehaviour
{
    // Start is called before the first frame update
    public Audio audio;
   public  UnityEvent m_MyEvent;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        {
            m_MyEvent = new UnityEvent();

            void Start()
            {
                //Add a listener to the new Event. Calls MyAction method when invoked
                m_MyEvent.AddListener(MyAction);
            }
                // Press Q to close the Listener
                if (Input.GetKeyDown("q") && m_MyEvent != null)
                {
                    Debug.Log("Quitting");
                    m_MyEvent.RemoveListener(MyAction);

#if UNITY_EDITOR
                    UnityEditor.EditorApplication.isPlaying = false;
#endif

                    Application.Quit();
                }

                //Press any other key to begin the action if the Event exists
                if (Input.GetKeyDown("space") && m_MyEvent != null)
                {
                //Begin the action
                audio.Pause();
                }
            }

           void MyAction()
            {
            //Output message to the console
           audio.Pause();
            print("Space");
        }
        }
    }

