using ServiceLocatorPath;

namespace Gameplay
{
    public class RecoverHealthItem : InteractableObject
    {
        public override void Interact()
        {
            ServiceLocator.Instance.GetService<IPlayerHealth>().RestoreHealth();
            gameObject.SetActive(false);
        }
    }
}