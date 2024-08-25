using System.IO;
using UnityEngine;

public class ImageSlicer : MonoBehaviour
{
    [SerializeField]
    private Texture2D sourceImage;
    [SerializeField]
    private int rows = 3; // Jumlah baris
    [SerializeField]
    private int cols = 3; // Jumlah kolom
    [SerializeField]
    private GameObject puzzlePiecePrefab; // Prefab untuk potongan puzzle
    [SerializeField]
    private Transform puzzleParent; // Parent untuk semua potongan puzzle

    private Sprite[] slices;

    void Start()
    {
        if (sourceImage == null)
        {
            Debug.LogError("Source image not set!");
            return;
        }

        if (!sourceImage.isReadable)
        {
            Debug.LogError("Source image is not readable. Please enable Read/Write in the texture import settings.");
            return;
        }

        SliceImage();
        InitializePuzzlePieces();
    }

    private void SliceImage()
    {
        int sliceWidth = sourceImage.width / cols;
        int sliceHeight = sourceImage.height / rows;
        slices = new Sprite[rows * cols];

        for (int y = 0; y < rows; y++)
        {
            for (int x = 0; x < cols; x++)
            {
                Texture2D slice = new Texture2D(sliceWidth, sliceHeight);
                slice.SetPixels(sourceImage.GetPixels(x * sliceWidth, y * sliceHeight, sliceWidth, sliceHeight));
                slice.Apply();

                Sprite sprite = Sprite.Create(slice, new Rect(0, 0, sliceWidth, sliceHeight), new Vector2(0.5f, 0.5f));
                slices[y * cols + x] = sprite;
            }
        }

        Debug.Log("Slicing complete!");
    }

    private void InitializePuzzlePieces()
    {
        if (puzzlePiecePrefab == null || puzzleParent == null)
        {
            Debug.LogError("Puzzle piece prefab or parent not set!");
            return;
        }

        for (int i = 0; i < slices.Length; i++)
        {
            GameObject puzzlePiece = Instantiate(puzzlePiecePrefab, puzzleParent);
            puzzlePiece.GetComponent<SpriteRenderer>().sprite = slices[i];
            puzzlePiece.transform.localPosition = new Vector3((i % cols) * 1.1f, (i / cols) * -1.1f, 0);
        }
    }
}
