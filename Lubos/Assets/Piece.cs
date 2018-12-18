using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour {

    public float moveSpeed = 1f;
    public Team team;

    public void MoveToPosition(Vector3 target)
    {
        StartCoroutine(LerpToPosition(target));
    }

    IEnumerator LerpToPosition(Vector3 target)
    {
        Vector3 startPos = transform.position;

        for (float i = 0; i < 1; i += Time.deltaTime)
        {
            transform.position = Vector3.Lerp(startPos, target, i * moveSpeed);

            yield return null;
        }
    }
}
