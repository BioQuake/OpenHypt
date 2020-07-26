using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class TextureOffsetScroll : MonoBehaviour
{
    // Scroll main texture based on time
    public bool ScrollTex;
    public bool ScrollBump;
    public float scrollSpeed;
    public Renderer rend;
    public virtual void Start()
    {
        this.rend = this.GetComponent<Renderer>();
    }

    public virtual void Update()
    {
        float offset = Time.time * this.scrollSpeed;
        if (this.ScrollTex)
        {
            this.rend.material.SetTextureOffset("_MainTex", new Vector2(offset, 0));
        }
        if (this.ScrollBump)
        {
            this.rend.material.SetTextureOffset("_BumpMap", new Vector2(offset, 0));
        }
    }

    public TextureOffsetScroll()
    {
        this.scrollSpeed = 0.5f;
    }

}