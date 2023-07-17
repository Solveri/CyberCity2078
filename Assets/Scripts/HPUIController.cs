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

        for (int i = 0; i <= player.HP; i++)
        {
            var currentSegment = Instantiate(HPSegment);
            currentSegment.transform.SetParent(gameObject.transform);
            //Segments.Add(currentSegment);
            SegmentsUI.Add(currentSegment.GetComponent<Image>());
            //Debug.Log(SegmentsUI[0]);
        }
        counterHP = SegmentsUI.Count - 1;
    }

    public void ChangeHPSegments()
    {
        try
        {
            SegmentsUI[counterHP].color = Color.black;
            counterHP--;
            //SegmentsUI.Remove(SegmentsUI.Last());
        }
        catch (System.InvalidOperationException e)
        {
            Debug.Log("The guy should be super dead");
        }
    }

    public void IncreaseHPSegment()
    {
        try
        {
            counterHP++;
            SegmentsUI[player.HP].color = Color.magenta;
        }
        catch (System.Exception)
        {

            Debug.Log("Can't heal");
        }
    }
}
