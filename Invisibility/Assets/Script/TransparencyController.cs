using UnityEngine;

public class TransparencyController : MonoBehaviour
{
    private MaterialPropertyBlock _propertyBlock;
    private Renderer _renderer;
    private Color _transparentColor;
    private Color _originalColor;
    private bool isTransparent = false;

    void Start()
    {
        // Inicializando o MaterialPropertyBlock e o Renderer
        _propertyBlock = new MaterialPropertyBlock();
        _renderer = GetComponent<Renderer>();

        // Pegando a cor original do material
        _originalColor = _renderer.sharedMaterial.GetColor("_Color");

        // Definindo a cor transparente (mantendo a cor original, mas com alfa 0.5)
        _transparentColor = new Color(_originalColor.r, _originalColor.g, _originalColor.b, 0.5f);
    }

    void Update()
    {
        // Verificando se a tecla "I" foi pressionada
        if (Input.GetKeyDown(KeyCode.I))
        {
            isTransparent = !isTransparent; // Alterna entre transparente e opaco

            // Aplicando a transparência ou restaurando a opacidade
            ApplyTransparency(isTransparent);
        }
    }

    void ApplyTransparency(bool makeTransparent)
    {
        // Define a cor apropriada
        Color colorToSet = makeTransparent ? _transparentColor : _originalColor;

        // Modifica as propriedades do MaterialPropertyBlock
        _renderer.GetPropertyBlock(_propertyBlock);
        _propertyBlock.SetColor("_Color", colorToSet);
        _renderer.SetPropertyBlock(_propertyBlock);
    }
}
