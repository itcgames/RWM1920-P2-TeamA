using NUnit.Framework;
using UnityEngine;

namespace Tests
{
    public class TutorialTest
    {
        [Test]
        public void ButtonsTutorial()
        {
            int input = -1;
            int output = TextScript.tutorial(input);
            int index = 0;
            Assert.AreEqual(index, output);
        }

        [Test]
        public void QuitTutorial()
        {
            int input = -1;
            int output = TextScript.tutorial(input);
            int index = 1;
            Assert.AreEqual(index, output);
        }

        [Test]
        public void PlayTutorial()
        {
            int input = -1;
            int output = TextScript.tutorial(input);
            int index = 2;
            Assert.AreEqual(index, output);
        }

        [Test]
        public void RestartTutorial()
        {

            int input = -1;
            int output = TextScript.tutorial(input);
            int index = 3;
            Assert.AreEqual(index, output);
        }

        [Test]
        public void TimerTutorial()
        {
            int input = -1;
            int output = TextScript.tutorial(input);
            int index = 4;
            Assert.AreEqual(index, output);
        }

        [Test]
        public void ComponentsTutorial()
        {
            int input = -1;
            int output = TextScript.tutorial(input);
            int index = 5;
            Assert.AreEqual(index, output);
        }

        [Test]
        public void PlayerTutorial()
        {
            int input = -1;
            int output = TextScript.tutorial(input);
            int index = 6;
            Assert.AreEqual(index, output);
        }

       /* [Test]
        public void TutorialTestOverflowTutorial()
        {
            Assert.Throws<System.OverflowException>(Tutorial() => TextScript.tutorial(9999));
        }*/
    }

}