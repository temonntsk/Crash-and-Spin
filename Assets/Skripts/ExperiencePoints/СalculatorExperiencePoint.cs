using System;
using UnityEngine;

public class ÑalculatorExperiencePoint
{
    private const int ExperiencePointsPerLevel = 300;

    private int _experiencePoint;

    public int CalculateExperiencePoint(float completionTime)
    {
        int lostExperiencePoints = (int)completionTime;

        _experiencePoint =  ExperiencePointsPerLevel - lostExperiencePoints;

        return _experiencePoint;
    }
}
