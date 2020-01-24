using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class GoalColPlayerTest
    {
        GameObject player;
        GameObject goal;

    // A Test behaves as an ordinary method
    [SetUp]
        public void setUp()
        {
             player = Resources.Load("Gizmo") as GameObject;
             goal = Resources.Load("Goal") as GameObject;
        }

        [UnityTest]
        public IEnumerator GoalColPlayerTestWithEnumeratorPasses()
        {

            player.transform.position = new Vector2(100, 100);
            goal.transform.position = new Vector2(100, 100);

            Assert.AreEqual(player.transform.position, goal.transform.position);


            yield return null;
        }
    }
}
