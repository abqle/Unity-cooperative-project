using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAnimations : MonoBehaviour
{
    public float sizeChangeTime = 0.5f;
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    Coroutine corr = null;
    public void ScaleModeTo(float targetScale)
    {
        if (corr != null) StopCoroutine(corr);
        corr = StartCoroutine(SizeChange(targetScale));
    }
    IEnumerator SizeChange(float targetScale)
    {
        float t = 0;
        float currScale = transform.localScale.x;
        float delta = (targetScale - currScale) / sizeChangeTime;
        while (t < sizeChangeTime)
        {
            t += Time.deltaTime;
            transform.localScale += new Vector3(delta, delta, 0) * Time.deltaTime;
            yield return null; 
        }

        transform.localScale = new Vector3(targetScale, targetScale, transform.localScale.z);
    }

    
}
