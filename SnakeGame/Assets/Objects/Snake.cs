using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Assets.Objects
{
    public class Snake
    {
        private List<GameObject> snakeBones;
        private GameObject head;

        public Snake(GameObject head)
        {
            this.head = head;
            snakeBones = new List<GameObject>();
        }

        public void AddBone()
        {
            GameObject snakeBone = new GameObject("SnakeBone", typeof(SpriteRenderer));
            snakeBone.transform.position = new Vector3(-100, -100);
            snakeBone.GetComponent<SpriteRenderer>().sprite = GameAssets.i.SnakeBoneSprite;
            snakeBone.GetComponent<SpriteRenderer>().sortingLayerName = "Items";

            snakeBones.Add(snakeBone);
        }

        public void UpdateMove(Vector2Int gridPosition, float angle)
        {
            var prevBoneInfo = Tuple.Create(head.transform.position, head.transform.eulerAngles);
            head.transform.position = new Vector3(gridPosition.x + 0.5f, gridPosition.y + 0.5f);
            head.transform.eulerAngles = new Vector3(0, 0, angle);

            foreach (var bone in snakeBones)
            {
                var temp = Tuple.Create(bone.transform.position, bone.transform.eulerAngles);
                bone.transform.position = prevBoneInfo.Item1;
                bone.transform.eulerAngles = prevBoneInfo.Item2;
                prevBoneInfo = temp;
            }
            CheckSnakePosition();
        }

        public IEnumerable<Vector3> GetFullSnakePosition()
        {
            yield return head.transform.position;
            foreach (var bone in snakeBones)
                yield return bone.transform.position;
        }

        private void CheckSnakePosition()
        {
            if (snakeBones.Any(b => b.transform.position == head.transform.position))
            {
                GameManager.StateGame = GameManager.State.Dead;
            }
        }
    }
}