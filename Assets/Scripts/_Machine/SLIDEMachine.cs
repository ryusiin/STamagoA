using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SLIDEMachine : MonoBehaviour
{
    // : Get
    public int Get_CurrentSlideNumber(Transform field, int gap)
    {
        // :: Get
        int xPos = (int)field.localPosition.x;
        int curNum = (xPos / -gap) + 1;

        // :: Send
        return curNum;
    }

    // : Slide
    // >> Status : Const
    const int SLIDE_SPEED = 64;
    public void SlidePrevious(Transform field, int gap)
    {
        this.StartCoroutine(this.SlidePrevious_Impl(field, gap));
    }
    private IEnumerator SlidePrevious_Impl(Transform field, int gap)
    {
        // : Set
        int xPos = 0;
        Vector3 curPos = field.localPosition;
        Vector3 setPos = field.localPosition + new Vector3(gap, 0, 0);

        // : Slide
        while(true)
        {
            if (xPos >= gap)
                break;

            Vector3 newPos = curPos + new Vector3(xPos, 0, 0);
            field.localPosition = newPos;

            xPos += SLIDE_SPEED;

            yield return null;
        }

        // : Adjust
        field.localPosition = setPos;
    }
    public void SlideNext(Transform field, int gap)
    {
        this.StartCoroutine(this.SlideNext_Impl(field, gap));
    }
    private IEnumerator SlideNext_Impl(Transform field, int gap)
    {
        // : Set
        int xPos = 0;
        Vector3 curPos = field.localPosition;
        Vector3 setPos = field.localPosition - new Vector3(gap, 0, 0);

        // : Slide
        while (true)
        {
            if (Math.Abs(xPos) >= gap)
                break;

            Vector3 newPos = curPos + new Vector3(xPos, 0, 0);
            field.localPosition = newPos;

            xPos -= SLIDE_SPEED;

            yield return null;
        }

        // : Adjust
        field.localPosition = setPos;
    }
}
