using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

namespace Tests
{
    public class JackTest
    {
        
        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator CheckFinalScoreIncrements()
        {   // Use the Assert class to test conditions.
            // Use yield to skip a frame.

            GameObject ScoreGameObject = new GameObject(name: "Score");
            Score score = ScoreGameObject.AddComponent<Score>();

            for(int i = 3;i<6;i++)
            {
                if(SceneManager.GetActiveScene().buildIndex == i)
                {
                    if(score.finalScore > 0)
                    {
                        yield return true;
                    }
                }
            }

        }
        [UnityTest]
        public IEnumerator PlayerJumpClick()
        {   // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            GameObject PlayerGameObject = new GameObject(name: "PlayerJumpClick");
            PlayerScript player = PlayerGameObject.AddComponent<PlayerScript>();


            


            yield return null;

        }
    }
}
