namespace PlatformerMovement
{
    using UnityEngine;

    public class DemoSceneManager : MonoBehaviour
    {
        [SerializeField]
        private Transform player;

        private float[] rooms = {
            5,
            25,
            45,
            65,
            85,
            105,
        };

        public void Update()
        {
            var room = GetRoomPressed();
            if (room != -1)
            {
                var coord = GetTeleportCoord(room);
                Teleport(coord);
            }
        }

        private int GetRoomPressed()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1))
            {
                return 0;
            }

            if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2))
            {
                return 1;
            }

            if (Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3))
            {
                return 2;
            }

            if (Input.GetKeyDown(KeyCode.Alpha4) || Input.GetKeyDown(KeyCode.Keypad4))
            {
                return 3;
            }

            if (Input.GetKeyDown(KeyCode.Alpha5) || Input.GetKeyDown(KeyCode.Keypad5))
            {
                return 4;
            }

            if (Input.GetKeyDown(KeyCode.Alpha6) || Input.GetKeyDown(KeyCode.Keypad6))
            {
                return 5;
            }

            return -1;
        }

        private Vector3 GetTeleportCoord(int index)
        {
            var y = rooms[index];
            return new Vector3(-1, y, 0);
        }

        private void Teleport(Vector3 position)
        {
            if (player)
            {
                player.gameObject.SetActive(false);
                player.SetParent(null);
                player.position = position;
                player.gameObject.SetActive(true);
            }
        }
    }
}
