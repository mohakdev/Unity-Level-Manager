using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace RadiantTools.LevelManager
{
    public class TransitionScript : MonoBehaviour
    {
        //Singleton Pattern
        public static TransitionScript Instance;
        void Start()
        {
            if (!Instance)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
                return;
            }
            DontDestroyOnLoad(gameObject);
        }

        [Header("References")]
        [SerializeField] Animator[] transitionAnims; //in accordance with transition type enum

        [Header("Transition Settings")]
        [SerializeField] float transitionTime = 1;
        public enum TransitionType
        {
            Crossfade,
            CircleWipe,
            LoadingTransition
        }
        [SerializeField] TransitionType transitionType;
        
        /// <summary>
        /// Can make you easily transition from your current level
        /// </summary>
        /// <param name="levelIndex">The built index of the level you want to transition to</param>
        public void TransitionToLevel(int levelIndex)
        {
            StartCoroutine(TransitScene(levelIndex , transitionType));
        }
        /// <summary>
        /// Can make you easily transition from your current level
        /// </summary>
        /// <param name="levelIndex">The built index of the level you want to transition to</param>
        /// <param name="transition">The type of transition you want to use</param>
        public void TransitionToLevel(int levelIndex , TransitionType transition)
        {
            StartCoroutine(TransitScene(levelIndex , transition));
        }
        /// <summary>
        /// Very helpful method which transitions you to the next level if it exists in the build index
        /// </summary>
        public void TransitionToNextLevel()
        {
            TransitionToLevel(LevelManager.GetNextLevel());
        }

        /// <summary>
        /// Simply plays athe transition and restarts the level
        /// </summary>
        public void TransitionToCurrentLevel()
        {
            TransitionToLevel(SceneManager.GetActiveScene().buildIndex);
        }

        //Base Transition Method
        IEnumerator TransitScene(int levelIndex, TransitionType transition)
        {
            Animator anim = GetAnimator(transition);

            anim.gameObject.SetActive(true);
            anim.SetTrigger("Start");
            yield return new WaitForSeconds(transitionTime);
            LevelManager.OpenLevel(levelIndex);
            yield return new WaitForSeconds(transitionTime);
            anim.SetTrigger("End");
            yield return new WaitForSeconds(transitionTime + 1);
            anim.gameObject.SetActive(false);
        }
        Animator GetAnimator(TransitionType transition)
        {
            switch (transition)
            {
                case TransitionType.Crossfade:
                    return transitionAnims[(int)TransitionType.Crossfade];
                case TransitionType.CircleWipe:
                    return transitionAnims[(int)TransitionType.CircleWipe];
                case TransitionType.LoadingTransition:
                    return transitionAnims[(int)TransitionType.LoadingTransition];
                default:
                    return transitionAnims[(int)TransitionType.Crossfade];
            }
        }
    }
}
