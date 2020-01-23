using NUnit.Framework;
using UnityEngine;

namespace Tests
{
    public class SpringTest
    {
        [Test]
        public void SpringCollide()
        {
            //Assert.IsTrue();

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