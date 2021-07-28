using UnityEngine;

public class Parallax : MonoBehaviour
{
    Vector2 length, startpos;

    [SerializeField]
    GameObject cam;
    [SerializeField]
    Vector2 parrallaxStrength;

    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.Find("Main Camera");
        startpos = new Vector2(transform.position.x, transform.position.y);
        length = new Vector2(GetComponent<SpriteRenderer>().bounds.size.x, GetComponent<SpriteRenderer>().bounds.size.y);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 temp, dist;
        temp = new Vector2(cam.transform.position.x * (1 - parrallaxStrength.x), cam.transform.position.y * (1 - parrallaxStrength.y));
        dist = new Vector2(cam.transform.position.x * parrallaxStrength.x, cam.transform.position.y * parrallaxStrength.y);


        if (temp.x > startpos.x + length.x)
            startpos.x += length.x;
        else if (temp.x < startpos.x - length.x)
            startpos.x -= length.x;


        transform.position = new Vector3(startpos.x + dist.x, startpos.y + dist.y, transform.position.z);
    }
}
