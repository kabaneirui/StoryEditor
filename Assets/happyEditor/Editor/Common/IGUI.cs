#if UNITY_EDITOR

namespace n.editor
{
    public interface IGUI 
    {
        void Init();
        void OnGUI();
        void Release();

    }

}
#endif