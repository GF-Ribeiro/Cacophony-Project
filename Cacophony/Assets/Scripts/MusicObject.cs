using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicObject : MonoBehaviour
{
    public List<GameObject> objects;
    MusicController musicController;

    private int currentIndex;

    // Start is called before the first frame update
    void Start()
    {
        musicController = FindObjectOfType<MusicController>();

        for (int i = 0; i < objects.Count; i++)
        {
            objects[i].SetActive(false);
        }
        currentIndex = 1;
    }


    public void Change()
    {
        for (int i = 0; i < objects.Count; i++)
        {
            objects[i].SetActive(false);
        }
        objects[currentIndex].SetActive(true);

        currentIndex++;

        if(currentIndex == objects.Count)
        {
            currentIndex = 0;
        }
    }
}
