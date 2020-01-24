using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class TutorialTest
    {
        GameObject tutorial = new GameObject("Tutorial");
        // A Test behaves as an ordinary method
        [SetUp]
        public void SetUp()
        {
            Assert.IsNotNull(tutorial);
        }

        [Test]
        public void TutorialTestSimplePasses()
        {
            Assert.IsNotNull(tutorial);
            // Use the Assert class to test conditions
        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator TutorialTestWithEnumeratorPasses()
        {
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            yield return new WaitForSeconds(1.0f);

            //Assert.IsNotNull(messages);
        }
    }
}
