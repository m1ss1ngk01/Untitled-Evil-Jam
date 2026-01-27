using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;

public class ApplyFilter : MonoBehaviour
{
    public float fadeSpeed;
    private void Update()
    {
        var volume = GetComponent<Volume>();
        volume.weight -= fadeSpeed * Time.deltaTime;
        volume.weight = Mathf.Max(0.0f, volume.weight);
    }
    public void Apply()
    {
        GetComponent<Volume>().weight = 1.0f;
    }
}
