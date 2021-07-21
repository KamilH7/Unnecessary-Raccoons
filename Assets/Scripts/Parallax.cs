using UnityEngine;

public class Parallax : MonoBehaviour
{

    float length, startpos;
    GameObject cam;
    public float parrallaxStrength;

    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.Find("Main Camera");
        startpos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        float temp = (cam.transform.position.x * (1-parrallaxStrength));
        float dist = cam.transform.position.x * parrallaxStrength;
        transform.position = new Vector3(startpos + dist, transform.position.y, transform.position.z);

        if (temp > startpos + length) 
            startpos += length;
        else if (temp < startpos - length) 
            startpos -= length;
    }
}
