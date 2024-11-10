using UnityEngine;

public class ScrollInfinito : MonoBehaviour
{
    Material mt;
    public float paralax;
    Vector2 offset;
    Transform cam;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpriteRenderer sp = GetComponent<SpriteRenderer>();
        mt = sp.material;
        cam = Camera.main.transform;
        offset = mt.mainTextureOffset;
    }

    // Update is called once per frame
    void Update()
    {
        offset.x = cam.position.x / transform.localScale.x / paralax;
        offset.y = cam.position.y / transform.localScale.y / paralax;

        mt.mainTextureOffset = offset;
    }
}
