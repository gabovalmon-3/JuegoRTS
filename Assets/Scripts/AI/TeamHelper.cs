using UnityEngine;

namespace RTSGame.AI
{
    public static class TeamHelper
    {
        public static bool IsEnemy(Team a, Team b) => a != b;
    }
}
