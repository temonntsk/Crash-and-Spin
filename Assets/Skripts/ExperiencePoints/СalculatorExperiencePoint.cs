using System;
using UnityEngine;

public class ÑalculatorExperiencePoint
{
    private const int ExperiencePointsPerLevel = 300;

    private int _experiencePoint;

    public event Action<int> ExperiencePointsCalculated;

    public void CalculateExperiencePoint(float completionTime)
    {
        int lostExperiencePoints = Convert.ToInt32(completionTime);

        _experiencePoint =  ExperiencePointsPerLevel - lostExperiencePoints;

    }

    public  int GiveExperiencePoint()
    {
        return _experiencePoint;
    }
}
