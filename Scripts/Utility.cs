using System.Collections;
using System.Collections.Generic;
using EathDefend;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

//using System;

public static class Utility
{
    public static Transform GetNear(Collider[] colliders, Vector3 originalPos)
    {
        float minDist = Mathf.Infinity;
        int best = -1;

        for (int i = 0; i < colliders.Length; i++)
        {
            float dist = Vector3.Distance(originalPos, colliders[i].transform.position);

            if (dist != 0 && dist < minDist)
            {
                best = i;
                minDist = dist;
            }
        }

        if (best != -1)
            return colliders[best].transform;
        else
            return null;
    }
    public static Transform GetNear(List<Transform> transforms, Vector3 originalPos)
    {
        float minDist = Mathf.Infinity;
        int best = -1;

        for (int i = 0; i < transforms.Count; i++)
        {
            float dist = Vector3.Distance(originalPos, transforms[i].transform.position);

            if (dist != 0 && dist < minDist)
            {
                best = i;
                minDist = dist;
            }
        }

        if (best != -1)
            return transforms[best];
        else
            return null;
    }
    public static Entity GetNearEntity(List<Entity> list, Vector3 originalPos)
    {
        float minDist = Mathf.Infinity;
        int best = -1;

        for (int i = 0; i < list.Count; i++)
        {
            float dist = Vector3.Distance(originalPos, list[i].transform.position);

            if (dist != 0 && dist < minDist)
            {
                best = i;
                minDist = dist;
            }
        }

        if (best != -1)
            return list[best];
        else
            return null;
    }
    public static Entity GetNearEntityMaxDistance(List<Entity> list, Vector3 originalPos, float maxDist)
    {
        float minDist = Mathf.Infinity;
        int best = -1;

        for (int i = 0; i < list.Count; i++)
        {
            float dist = Vector3.Distance(originalPos, list[i].transform.position);

            if (dist != 0 && dist < maxDist && dist < minDist)
            {
                best = i;
                minDist = dist;
            }
        }

        if (best != -1)
            return list[best];
        else
            return null;
    }
    public static Entity GetAnyEntityMaxDistance(List<Entity> list, Vector3 originalPos, float maxDist)
    {
        for (int i = 0; i < list.Count; i++)
        {
            float dist = Vector3.Distance(originalPos, list[i].transform.position);

            if (dist != 0 && dist < maxDist)
            {
                return list[i];
            }
        }

        return null;
    }
    public static Transform GetNear(Transform[] transforms, Vector3 originalPos)
    {
        float minDist = Mathf.Infinity;
        int best = -1;

        for (int i = 0; i < transforms.Length; i++)
        {
            float dist = Vector3.Distance(originalPos, transforms[i].transform.position);

            if (dist != 0 && dist < minDist)
            {
                best = i;
                minDist = dist;
            }
        }

        if (best != -1)
            return transforms[best];
        else
            return null;
    }

    public static void Shuffle<T>(this IList<T> list)
    {
        System.Random rng = new System.Random();

        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }
    public static List<Entity> GetAllEntities(Collider[] colliders)
    {
        var entities = new List<Entity>();

        for (int i = 0; i < colliders.Length; i++)
        {
            var entity = colliders[i].GetComponent<Entity>();

            if (entity != null)
                entities.Add(colliders[i].GetComponent<Entity>());
        }

        return entities;
    }
    public static Vector3 GetPointAround(Vector3 originalPos, float maxDistance)
    {
        float randomX = Random.Range(-maxDistance, maxDistance);
        float randomZ = Random.Range(-maxDistance, maxDistance);

        var newPos = new Vector3(originalPos.x + randomX, originalPos.y,
            originalPos.z + randomZ);

        return newPos;
    }
    public static bool CheckOnScreen(Vector3 pos)
    {
        Vector3 viewPos = Camera.main.WorldToViewportPoint(pos);
        if (viewPos.x >= 0 && viewPos.x <= 1 && viewPos.y >= 0 && viewPos.y <= 1 && viewPos.z > 0)
            return true;
        else
            return false;
    }
    public static bool CheckFreePosByRaycastNavmesh(Vector3 pos, float radius)
    {
        bool blocked = false;
        NavMeshHit hit;

        blocked = NavMesh.Raycast(pos, pos + Vector3.right * radius, out hit, NavMesh.AllAreas);
        Debug.DrawLine(pos, hit.position, blocked ? Color.red : Color.green);
        if (blocked)
            if (hit.distance < 2)
                return false;

        blocked = NavMesh.Raycast(pos, pos + Vector3.left * radius, out hit, NavMesh.AllAreas);
        Debug.DrawLine(pos, hit.position, blocked ? Color.red : Color.green);
        if (blocked)
            if (hit.distance < 2)
                return false;

        blocked = NavMesh.Raycast(pos, pos + Vector3.forward * radius, out hit, NavMesh.AllAreas);
        Debug.DrawLine(pos, hit.position, blocked ? Color.red : Color.green);
        if (blocked)
            if (hit.distance < 2)
                return false;

        blocked = NavMesh.Raycast(pos, pos - Vector3.forward * radius, out hit, NavMesh.AllAreas);
        Debug.DrawLine(pos, hit.position, blocked ? Color.red : Color.green);
        if (blocked)
            if (hit.distance < 2)
                return false;

        return true;
    }
    public static Vector3 GetFreePos(Vector3 originalPos, float distanceX, float _distanceY, float radius,
        LayerMask layerMask)
    {
        // Need testing
        Collider[] hitColliders = Physics.OverlapSphere(originalPos, radius, layerMask);

        if (hitColliders.Length == 0)
            return originalPos;

        for (int i = 0; i < distanceX; i++)
        {
            for (int j = 0; j < _distanceY; j++)
            {
                Debug.Log("for iteration count = " + ((i + 1) * (j + 1)));
                Vector3 newPos = new Vector3(originalPos.x + i, originalPos.y, originalPos.z + j);
                hitColliders = Physics.OverlapSphere(originalPos, radius, layerMask);
                if (hitColliders.Length == 0)
                    return originalPos;

                newPos = new Vector3(originalPos.x - i, originalPos.y, originalPos.z + j);
                hitColliders = Physics.OverlapSphere(originalPos, radius, layerMask);
                if (hitColliders.Length == 0)
                    return originalPos;

                newPos = new Vector3(originalPos.x + i, originalPos.y, originalPos.z - j);
                hitColliders = Physics.OverlapSphere(originalPos, radius, layerMask);
                if (hitColliders.Length == 0)
                    return originalPos;

                newPos = new Vector3(originalPos.x - i, originalPos.y, originalPos.z - j);
                hitColliders = Physics.OverlapSphere(originalPos, radius, layerMask);
                if (hitColliders.Length == 0)
                    return originalPos;
            }
        }

        return Vector3.zero;

        /*
        Vector3 spawnPoint = position;
        Vector2 offset = Random.insideUnitCircle * 1.2f;
        spawnPoint.x += offset.x;
        spawnPoint.z += offset.y;

        NavMeshHit closestHit;
        if (NavMesh.SamplePosition(spawnPoint, out closestHit, 20, 1))
        {
            spawnPoint = closestHit.position;
            transform.position = spawnPoint;
            agent.enabled = true;
            NavMeshPath path = new NavMeshPath();
            agent.CalculatePath(spawnPoint, path);
            agent.path = path;
        }
        */
    }
    public static bool IsPointerOverGameObject()
    {
#if UNITY_EDITOR
        if (EventSystem.current.IsPointerOverGameObject())
            return true;
#elif UNITY_ANDROID
        if(Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began ){
            if(EventSystem.current.IsPointerOverGameObject(Input.touches[0].fingerId))
                return true;
        }
             
        return false;
#endif
        return false; 
    }

    
}
