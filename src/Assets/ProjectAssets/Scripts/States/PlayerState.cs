using ProjectAssets.Scripts.Constants;

namespace ProjectAssets.Scripts.States
{
    public sealed class PlayerState
    {
        public int LivesCount { get; set; } = PlayerConstants.DefaultLivesCount;
        public int HealthPoints { get; set; } = PlayerConstants.DefaultHealthPoints;
    }
}