using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RadiantTools.LevelManager
{
    public class ExampleScript : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            StartCoroutine(TestTransition());
        }

        IEnumerator TestTransition()
        {
            yield return new WaitForSeconds(4);
            TransitionScript.Instance.TransitionToNextLevel();
        }
    }
}
