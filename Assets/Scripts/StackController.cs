using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class StackController : MonoBehaviour
{
    public static StackController instance;

    public List<GameObject> cups = new List<GameObject>();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    private void Start()
    {
        
    }

  public void StackCup(GameObject other, int index)
    {
        other.transform.parent = transform;
        Vector3 newPos = cups[index].transform.localPosition;
        newPos.z += 1;
        other.transform.localPosition = newPos;
        StartCoroutine(MakeBigger());
    }

    private IEnumerator MakeBigger()
    {
        for (int i = cups.Count; i > 0; i--)
        {
            Vector3 scale = new Vector3(1, 1, 1);
            scale *= 1.25f;

            cups[i].transform.DOScale(scale, 0.1f).OnComplete(() => cups[i].transform.DOScale(new Vector3(1, 1, 1), 0.1f));
            
            yield return new WaitForSeconds(0.05f);
        }
    }
}
