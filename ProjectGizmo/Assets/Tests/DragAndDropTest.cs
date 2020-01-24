using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{

    public class DragAndDropTest
    {



        GameObject gizmoSprite = Resources.Load("GizmoS") as GameObject;
        GameObject fan = Resources.Load("Fan") as GameObject;
        GameObject bubble = Resources.Load("BubbleS") as GameObject;


        // A Test behaves as an ordinary method
        [UnityTest]
        public IEnumerator DragAndDropTestForObjectNotDeletedOnStart()
        {
            GameObject gizmoSprite = Resources.Load("GizmoS") as GameObject;
            GameObject fan = Resources.Load("Fan") as GameObject;

            GameObject[] objects = GameObject.FindGameObjectsWithTag("GizmoSprite");
            Assert.IsNotNull(objects);

            yield return new WaitForSeconds(0.1f);

            gizmoSprite.SetActive(false);
            objects = GameObject.FindGameObjectsWithTag("GizmoSprite");
            Assert.IsEmpty(objects);
            Assert.IsNotNull(fan);
        }

        [UnityTest]
        public IEnumerator DragAndDropTestAbleToMoveOnPlay()
        {


            GameObject GizmoSpriteOBJ1  = MonoBehaviour.Instantiate(gizmoSprite);
            GameObject GizmoSpriteOBJ2 = MonoBehaviour.Instantiate(gizmoSprite);
            GameObject bubbleOBJ  = MonoBehaviour.Instantiate(bubble);


            GameObject[] OBJ1 = {  };

            Assert.IsFalse(bubbleOBJ.GetComponent<ClickDrag>().forceUpdate(OBJ1));
            yield return new WaitForSeconds(2f);

            GameObject[] OBJ2 = { GizmoSpriteOBJ1, GizmoSpriteOBJ2 };
            Assert.IsTrue(bubbleOBJ.GetComponent<ClickDrag>().forceUpdate(OBJ2));

        }



        //// A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        //// `yield return null;` to skip a frame.
        //[UnityTest]
        //public IEnumerator DragAndDropTestWithEnumeratorPasses()
        //{
        //    // Use the Assert class to test conditions.
        //    // Use yield to skip a frame.
        //    yield return null;
        //}
    }
}
