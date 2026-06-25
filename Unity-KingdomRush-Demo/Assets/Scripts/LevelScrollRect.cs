using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LevelScrollRect : MonoBehaviour,IBeginDragHandler,IEndDragHandler
{
    private ScrollRect scrollRect;
    private float[] PagePos = new float[4] { 0, 0.3333f, 0.6666f, 1 };
    private float TargetPos = 0;
    private bool isScrolling = false;
    public float speed = 8f;
    public Toggle[] toggles;
    void Start()
    {
        scrollRect = GetComponent<ScrollRect>();
    }

    void Update()
    {
        if (isScrolling)
        {
            scrollRect.horizontalNormalizedPosition = Mathf.Lerp(scrollRect.horizontalNormalizedPosition, TargetPos, speed*Time.deltaTime);
            if (Mathf.Abs(scrollRect.horizontalNormalizedPosition - TargetPos) < 0.0005f)
            {
                isScrolling = false;
            }
        }
    }
    public void OnValueChange(Vector2 pos)
    {

    }
    
    public void OnBeginDrag(PointerEventData eventData)
    {  

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        float RealPos = scrollRect.horizontalNormalizedPosition;
        int index = 0;
        float offset = RealPos;
        for (int i = 1; i < 4; i++)
        {
            if (Mathf.Abs(RealPos - PagePos[i]) < offset)
            {
                index++;
                offset = Mathf.Abs(RealPos - PagePos[i]);
            }
            else
            {
                break;
            }
        }
        TargetPos = PagePos[index];
        isScrolling = true;
        toggles[index].isOn = true;
    }

    public void MoveToPage1(bool isOn)
    {
        if (isOn && Mathf.Abs(scrollRect.horizontalNormalizedPosition - PagePos[0]) > 0.001f)
        {
            isScrolling = true;
            TargetPos = PagePos[0];
        }
    }
    public void MoveToPage2(bool isOn)
    {
        if (isOn && Mathf.Abs(scrollRect.horizontalNormalizedPosition - PagePos[1]) > 0.001f)
        {
            isScrolling = true;
            TargetPos = PagePos[1];
        }
    }
    public void MoveToPage3(bool isOn)
    {
        if (isOn && Mathf.Abs(scrollRect.horizontalNormalizedPosition - PagePos[2]) > 0.001f)
        {
            isScrolling = true;
            TargetPos = PagePos[2];
        }
    }
    public void MoveToPage4(bool isOn)
    {
        if (isOn && Mathf.Abs(scrollRect.horizontalNormalizedPosition - PagePos[3]) > 0.001f)
        {
            isScrolling = true;
            TargetPos = PagePos[3];
        }
    }
}
