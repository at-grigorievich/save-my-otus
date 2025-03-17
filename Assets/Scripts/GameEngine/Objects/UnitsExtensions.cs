using GameEngine.Save;
using UnityEngine;

namespace GameEngine
{
    public static class UnitsExtensions
    {
        public static void Setup(this Unit unit, UnitSerializableData unitData)
        {
            unit.name = unitData.Type;
            
            unit.HitPoints = unitData.HitPoints;
            
            unit.transform.position = unitData.Position;
            unit.transform.rotation = Quaternion.Euler(unitData.Rotation);
        }
    }
}