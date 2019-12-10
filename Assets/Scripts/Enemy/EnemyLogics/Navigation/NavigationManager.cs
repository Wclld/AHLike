using UnityEngine.AI;

namespace AHLike.Enemy.Navigation
{
    public static class NavigationManager 
    {
        public static void RebuildNavMesh(NavMeshSurface surface)
        {
            surface.BuildNavMesh();
        }
    }
}
