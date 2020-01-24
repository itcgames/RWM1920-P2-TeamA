using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class OisinTest
    {
        GameObject player = Resources.Load("Gizmo") as GameObject;
        GameObject block = Resources.Load("Obstacle") as GameObject;

        [SetUp]
        public void SetUp()
        {
            Assert.IsNotNull(player);
            player.transform.position = new Vector3(0, 0, 0);

            Assert.IsNotNull(block);
            block.transform.position = new Vector3(0, 10, 0);

        }


        // A Test behaves as an ordinary method
        [Test]
        public void OisinTestSimplePasses()
        {
            // Use the Assert class to test conditions
        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator OisinTestWithEnumeratorPasses()
        {
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.

            //playerobj.transform.position = new Vector3(0, 0, 0);

            float initialPos = player.transform.position.x;


            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            yield return new WaitForSeconds(0.1f);


            //yield return null;
            Assert.Less(player.transform.position.x, initialPos);

            //Assert.

        }
    }
}
