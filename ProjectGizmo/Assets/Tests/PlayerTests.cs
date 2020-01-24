using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class PlayerTests
    {
        GameObject player;

        [SetUp]
        public void SetUp()
        {
            player = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Gizmo"));
        }


        [UnityTest]
        public IEnumerator ExistanceTest()
        {
            yield return null;
            Assert.IsNotNull(player);
        }


        [UnityTest]
        public IEnumerator PlayerMovementTest()
        {
            float initialPos = player.transform.position.x;

            yield return new WaitForSeconds(1.0f);

            Assert.Greater(player.transform.position.x, initialPos);

            yield return null;
        }


        [UnityTest]
        public IEnumerator PlayerDirectionChangeTest()
        {
            float initialPos = player.transform.position.x;

            player.GetComponent<PlayerScript>().directionChange();

            yield return new WaitForSeconds(1.0f);

            Assert.Less(player.transform.position.x, initialPos);

            yield return null;
        }


        [UnityTest]
        public IEnumerator PlayerJumpTest()
        {
            float initialPos = player.transform.position.y;

            player.GetComponent<PlayerScript>().setBottomHit(true);

            player.GetComponent<PlayerScript>().setJump(true);

            yield return new WaitForSeconds(1.0f);

            Assert.Less(player.transform.position.y, initialPos);

            yield return null;
        }
    }
}
