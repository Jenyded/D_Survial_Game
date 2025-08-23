using JetBrains.Annotations;

namespace Zenject
{
    [MeansImplicitUse(ImplicitUseKindFlags.Assign)]
    public abstract class InjectAttributeBase : Zenject.Internal.PreserveAttribute
    {
        public bool Optional
        {
            get;
            set;
        }

        public object Id
        {
            get;
            set;
        }

        public InjectSources Source
        {
            get;
            set;
        }
    }
}
