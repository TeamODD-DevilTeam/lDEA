using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassBlock : MonoBehaviour
{
    [SerializeField] BlockType blockType = BlockType.Grass; // Enums.cs에 정의된 BlockTypes Enum을 정의합니다.
    public void SetBlockType(BlockType blockType) { this.blockType = blockType; }
    public BlockType GetBlockType() { return blockType; }
    public bool IsBlockType(BlockType blockType) { return this.blockType == blockType; }
}
