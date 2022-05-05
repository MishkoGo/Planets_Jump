using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObjects : MonoBehaviour,ICanSwitch
{
    #region VAR
    [SerializeField] private bool _active; 
    public Dictionary<int, DragObject> draggedObjects = new Dictionary<int, DragObject>();
    #endregion

    #region MONO
    private void Update()
    {
        if(_active)
            ControlDrag();
    }
    #endregion
    
    #region FUNC
    private void ControlDrag()
    {
        foreach (Touch t in Input.touches)
        {
            Ray ray = Camera.main.ScreenPointToRay(t.position);
            if (t.phase == TouchPhase.Began)
            {
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit) && hit.transform.CompareTag("draggable"))
                {
                    DragObject dragO;
                    if (!draggedObjects.TryGetValue(t.fingerId, out dragO))
                    {
                        dragO = new DragObject();
                        draggedObjects.Add(dragO.fingerID, dragO);
                    }

                    dragO.fingerID = t.fingerId;
                    dragO.obj = hit.transform;
                    dragO.rigidbody2D = hit.transform.GetComponent<Rigidbody2D>();
                    
                    dragO.startPos = hit.transform.position;
                    dragO.dragPlane = new Plane(-Camera.main.transform.forward, dragO.startPos);
                    float dist;
                    dragO.dragPlane.Raycast(ray, out dist);
                    dragO.dragOffset = dragO.startPos - ray.GetPoint(dist);
                }
            }
            else if (t.phase == TouchPhase.Moved)
            {
                DragObject dragO;
                if (draggedObjects.TryGetValue(t.fingerId, out dragO))
                {
                    if (dragO.obj == null)
                    {
                        // object has been destroyed, so remove this DragObject and continue
                        draggedObjects.Remove(t.fingerId);
                        continue;
                    }

                    float dist;
                    dragO.dragPlane.Raycast(ray, out dist);
                    dragO.rigidbody2D.MovePosition(ray.GetPoint(dist));
                }
            }
            else if (t.phase == TouchPhase.Ended || t.phase == TouchPhase.Canceled)
            {
                DragObject dragO;
                if (draggedObjects.TryGetValue(t.fingerId, out dragO))
                {
                    draggedObjects.Remove(t.fingerId);
                }
            }
        }
    }
    private void ControlDragMy()
    {
        foreach (Touch t in Input.touches)
        {
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(t.position);
            Ray ray = Camera.main.ScreenPointToRay(t.position);
            if (t.phase == TouchPhase.Began)
            {
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit) && hit.transform.CompareTag("draggable"))
                {
                    DragObject dragO;
                    if (!draggedObjects.TryGetValue(t.fingerId, out dragO))
                    {
                        dragO = new DragObject();
                        draggedObjects.Add(dragO.fingerID, dragO);
                    }

                    dragO.fingerID = t.fingerId;
                    dragO.obj = hit.transform;
                    dragO.startPos = hit.transform.position;

                    dragO.dragOffset = dragO.startPos - worldPos;
                    dragO.dragOffset.z = 0;
                }
            }
            else if (t.phase == TouchPhase.Moved)
            {
                DragObject dragO;
                if (draggedObjects.TryGetValue(t.fingerId, out dragO))
                {
                    if (dragO.obj == null)
                    {
                        // object has been destroyed, so remove this DragObject and continue
                        draggedObjects.Remove(t.fingerId);
                        continue;
                    }

                 
                 //   dragO.obj.position = ray.GetPoint(dist) + dragO.dragOffset;
                }
            }
            else if (t.phase == TouchPhase.Ended || t.phase == TouchPhase.Canceled)
            {
                DragObject dragO;
                if (draggedObjects.TryGetValue(t.fingerId, out dragO))
                {
                    if (dragO.obj == null)
                    {
                        dragO.obj.position = dragO.startPos;
                    }

                    draggedObjects.Remove(t.fingerId);
                }
            }
        }
    }
    public void Activate()
    {
        _active = true;
    }
    public void Deactivate()
    {
        _active = false;
    }
    public void Switch()
    {
        _active = !_active;
    }
    #endregion
    
}
