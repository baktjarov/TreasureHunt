using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Gameplay
{
    public class MapManager : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField] private List<Tilemap> targetTilemaps;
        [SerializeField] private GameObject overlayPrefab;
        [SerializeField] private GameObject overlayContainer;

        private static MapManager _instance;
        public static MapManager Instance { get { return _instance; } }
        public Dictionary<Vector2Int, OverlayTile> map;

        private void Awake()
        {
            if (_instance != null && _instance != this)
            {
                Destroy(this.gameObject);
            }
            else
            {
                _instance = this;
            }
        }

        void Start()
        {
            map = new Dictionary<Vector2Int, OverlayTile>();

            foreach (var tm in targetTilemaps)
            {
                BoundsInt bounds = tm.cellBounds;

                for (int y = bounds.min.y; y < bounds.max.y; y++)
                {
                    for (int x = bounds.min.x; x < bounds.max.x; x++)
                    {
                        if (tm.HasTile(new Vector3Int(x, y)))
                        {
                            if (!map.ContainsKey(new Vector2Int(x, y)))
                            {
                                var overlayTile = Instantiate(overlayPrefab, overlayContainer.transform);
                                var cellWorldPosition = tm.GetCellCenterWorld(new Vector3Int(x, y));
                                overlayTile.transform.position = new Vector3(cellWorldPosition.x, cellWorldPosition.y, cellWorldPosition.z + 1);
                                overlayTile.GetComponent<SpriteRenderer>().sortingOrder = tm.GetComponent<TilemapRenderer>().sortingOrder;
                                overlayTile.gameObject.GetComponent<OverlayTile>().gridLocation = new Vector3Int(x, y);

                                map.Add(new Vector2Int(x, y), overlayTile.gameObject.GetComponent<OverlayTile>());
                            }
                        }
                    }

                }
            }
        }
    }
}
