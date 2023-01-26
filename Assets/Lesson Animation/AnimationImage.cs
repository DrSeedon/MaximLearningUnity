using UnityEngine;
using UnityEngine.UI;

public class AnimationImage : MonoBehaviour
{
    public Animator animator;
    public RawImage rawImage;
    public Texture texture1;
    public Texture texture2;
    bool isFirst = true;
    void Start()
    {
        animator = GetComponent<Animator>();
        rawImage = GetComponent<RawImage>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void EventAnimation()
    {
        if (isFirst)
        {
            rawImage.texture = texture2;
            isFirst = !isFirst;
        }
        else
        {
            rawImage.texture = texture1;
            isFirst = !isFirst;
        }
    }
}
