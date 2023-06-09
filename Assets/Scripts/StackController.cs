using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class StackController : MonoBehaviour
{
    public static StackController instance;

    public float movementDelay = 0.25f;
    public float originDelay = 0.7f;

    public List<GameObject> cups = new List<GameObject>();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    private void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            MoveListElements();
        }

        if (Input.GetButtonUp("Fire1"))
        {
            MoveOrigin();
        }
    }

  public void StackCup(GameObject other, int index)
    {
        other.transform.parent = transform;
        Vector3 newPos = cups[index].transform.localPosition;
        newPos.z += 1;
        other.transform.localPosition = newPos;
        cups.Add(other);
        StartCoroutine(MakeBigger());
    }

    private IEnumerator MakeBigger()
    {
        for (int i = cups.Count - 1; i > 0; i--)
        {
            int index = i;
            Vector3 scale = new Vector3(1, 1, 1);
            scale *= 1.5f;

            cups[index].transform.DOScale(scale, 0.1f).OnComplete(() => cups[index].transform.DOScale(new Vector3(1, 1, 1), 0.1f));
            
            yield return new WaitForSeconds(0.05f);
        }
    }

    private void MoveListElements()
    {
        for (int i = 1; i < cups.Count; i++)
        {
            Vector3 pos = cups[i].transform.localPosition;
            pos.x = cups[i - 1].transform.localPosition.x;
            cups[i].transform.DOLocalMove(pos, movementDelay);
        }
    }

    private void MoveOrigin()
    {
        for (int i = 1; i < cups.Count; i++)
        {
            Vector3 pos = cups[i].transform.localPosition;
            pos.x = cups[0].transform.localPosition.x;
            cups[i].transform.DOLocalMove(pos, originDelay);
        }
    }
}
