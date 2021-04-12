using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] GameEnding gameEnding;

    bool m_PlayerInRange;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform == player)
        {
            m_PlayerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform == player)
        {
            m_PlayerInRange = false;
        }
    }

    private void Update()
    {
        if (m_PlayerInRange)
        {
            Vector3 direction = player.position - transform.position + Vector3.up;
            Ray ray = new Ray(transform.position, direction);
            RaycastHit raycastHitInfo;
            if (Physics.Raycast(ray, out raycastHitInfo))
            {
                if (raycastHitInfo.collider.transform == player)
                {
                    gameEnding.CaughtPlayer();
                }
            }
        }
    }



}
