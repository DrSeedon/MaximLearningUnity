using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ScrollElement : MonoBehaviour
{
    public Transform scrollRect;
    public Transform scrollContent;

    public void onClickCube()
    {
        float dis = scrollRect.position.x - transform.position.x;
        ScrollController.newPose = new Vector3(scrollContent.position.x + dis, scrollContent.position.y, scrollContent.position.z);
        ScrollController.SelectMove = true;
    }

}
