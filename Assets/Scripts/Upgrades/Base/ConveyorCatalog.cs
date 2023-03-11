using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ConveyorCatalog : MonoBehaviour
{
    [SerializeField] private List<SerializedConveyorData> _conveyorList = new();

    public List<SerializedConveyorData> GetAllConveyorsData()
    {
        return _conveyorList;
    }

    public Conveyor GetConveyor(string id)
    {
        for (int i = 0; i < _conveyorList.Count; i++)
        {
            if (_conveyorList[i].ID == id)
            {
                return _conveyorList[i].Conveyor;
            }
        }

        throw new Exception("there is no conveyor for such an index");
    }
}
