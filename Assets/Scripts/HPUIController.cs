using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPUIController : MonoBehaviour
{
    [SerializeField] PlayerHealth player;
    [SerializeField] GameObject HPSegment;
    [SerializeField] Image img;
    [SerializeField] List<GameObject> Segments;
    [SerializeField] List<Image> SegmentsUI;

    int counterHP;

    // Start is called before the first frame update
    void Start()
    {
        counterHP = player.HP;
        img.color = Color.magenta;
        Debug.Log(player.HP);

        for (int i = 0; i < player.HP; i++)
        {
            var currentSegment = Instantiate(HPSegment);
            currentSegment.transform.SetParent(gameObject.transform);
            //Segments.Add(currentSegment);
            SegmentsUI.Add(currentSegment.GetComponent<Image>());
            //Debug.Log(SegmentsUI[0]);
        }
    }

    public void ChangeHPSegments()
    {
        try
        {
            SegmentsUI.Last().color = Color.black;
            SegmentsUI.Remove(SegmentsUI.Last());
        }
        catch (System.InvalidOperationException e)
        {
            Debug.Log("The guy should be super dead");
        }
    }
}
