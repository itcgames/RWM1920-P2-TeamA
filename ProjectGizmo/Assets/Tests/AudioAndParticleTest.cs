using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class AudioAndParticleTest
    {
        GameObject player;


        [SetUp]
        public void SetUp()
        {
            player = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Gizmo"));
        }


        [UnityTest]
        public IEnumerator AudioAndParticleTestWithEnumeratorPasses()
        {
            Assert.NotNull(player.GetComponent<PlayerScript>().getPlayAudio());
            yield return null;
        }
    }
}
