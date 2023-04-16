using UnityEngine;

public class MainMEnuMaterial : MonoBehaviour
{
    public float BackgroundSpeed;
    public Renderer BackgroundRenderer;

    void Update()
    {
        BackgroundRenderer.material.mainTextureOffset += new Vector2(0f, BackgroundSpeed * Time.deltaTime);
    }
}
