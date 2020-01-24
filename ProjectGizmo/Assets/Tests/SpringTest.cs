using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class SpringTest
    {
        GameObject player = new GameObject("Player");
        GameObject spring = new GameObject("SpringSprite");

        [SetUp]
        public void SetUp()
        {
            Assert.IsNotNull(player);
            Assert.IsNotNull(spring);
            player.transform.position = new Vector3(0, 0, 0);
            spring.transform.position = new Vector3(0, 0, 0);
        }
        // A Test behaves as an ordinary method
        [Test]
        public void SpringTestCollide()
        {
            Assert.AreEqual(player.transform.position, spring.transform.position);
            // Use the Assert class to test conditions
        }

        [Test]
        public void SpringTestNotCollide()
        {
            spring.transform.position = new Vector3(200, 200, 0);
            Assert.AreNotEqual(player.transform.position, spring.transform.position);
            // Use the Assert class to test conditions
        }
        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator SpringTestWithEnumeratorPasses()
        {
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            yield return new WaitForSeconds(1.0f);

            Assert.IsNotNull(player);
            Assert.IsNotNull(spring);
        }
    }
}
