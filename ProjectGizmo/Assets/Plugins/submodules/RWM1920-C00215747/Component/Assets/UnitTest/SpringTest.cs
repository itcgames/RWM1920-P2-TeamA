using NUnit.Framework;
using UnityEngine;
using System;
using System.Collections;

namespace Tests
{
    public class SpringTest
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        GameObject spring = GameObject.FindGameObjectWithTag("SpringSprite");

        [Test]
        public void SpringCollide()
        {
            //Assert.IsTrue();
            Vector3 pos = player.tranform.position;
            spring.tranform.position = pos;
            if(spring.transform.position == player.transform.position)
            {
                Spring.OnCollisionEnter2D(player.GetComponent<Collision2D>());
            }
            int input = -1;
            int output = Spring.collide(input);
            int collision = 1;

            //foreach (var o in output)
            //{
            //    Debug.Log(o);
            //}

            Assert.AreEqual(collision, output);
        }

        [Test]
        public void SpringDoesntCollide()
        {
            //Assert.IsFalse();
            if (spring.transform.position != player.transform.position)
            {
                Spring.OnCollisionEnter2D(spring.GetComponent<Collision2D>());
            }
            int input = -1;
            int output = Spring.collide(input);
            int collision = 0;

            //foreach (var o in output)
            //{
            //    Debug.Log(o);
            //}

            Assert.AreEqual(collision, output);
        }

        [Test]
        public void SpringTestOverflow()
        {
            Assert.Throws<System.OverflowException>(() => Spring.collide(9999));
        }
    }

}