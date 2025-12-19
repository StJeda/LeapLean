using ProjectAssets.Scripts.States;
using Zenject;

namespace ProjectAssets.Scripts.Installers
{
    public sealed class PlayerInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .Bind<PlayerState>()
                .AsSingle();
        }
    }
}