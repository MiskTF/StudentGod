using UnityEngine;
using System.Collections;
using System.Diagnostics.CodeAnalysis;

public class EventManager : MonoBehaviour
{
    public delegate void NoArgAction();
    public static event NoArgAction OnPause;

    public delegate void OneArgAction(GameObject obj);
    public static event OneArgAction OnStudentHit;
    public static event OneArgAction OnStudentLate;
    public static event OneArgAction OnStudentMissed;

    public delegate void TwoArgAction(GameObject student, GameObject building);
    public static event TwoArgAction OnBuildingCollision;

    public static void FireOnBuildingCollision(GameObject student, GameObject building)
    {
        if (OnBuildingCollision != null)
        {
            OnBuildingCollision(student, building);
        }
    }

    public static void FireOnStudentHit(GameObject student)
    {
        if (OnStudentHit != null)
        {
            OnStudentHit(student);
        }
    }
    public static void FireOnStudentLate(GameObject student)
    {
        if (OnStudentLate != null)
        {
            OnStudentLate(student);
        }
    }

    public static void FireOnStudentMissed(GameObject student)
    {
        if (OnStudentMissed != null)
        {
            OnStudentMissed(student);
        }
    }

    public static void FireOnPause()
    {
        if (OnPause != null)
        {
            OnPause();
        }
    }
}