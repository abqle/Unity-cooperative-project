using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimatedBackground : MonoBehaviour
{
    Material material = null;

    private void Awake()
    {
        var img = GetComponent<Image>();
        img.material = new Material(img.material);
        material = img.material;
        material.name = material.name + " (CLONE)";
        

    }
    private void OnEnable()
    {
        StartCoroutine(frequency());
    }

    IEnumerator frequency()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.02f);
            material.mainTextureOffset = new Vector2(Random.Range(0f, 1f), Random.Range(0f, 1f));
        }
    }
}