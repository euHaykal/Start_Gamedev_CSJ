using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{
    [Header("Items")]
    [SerializeField] private Image waterUIBar;
    [SerializeField] private Image woodUIBar;
    [SerializeField] private Image carrotUIBar;
    [SerializeField] private Image fishtUIBar;

    [Header("Tools")]
    // [SerializeField] private Image axeUI;
    // [SerializeField] private Image shovelUI;
    // [SerializeField] private Image wateringCanUI;
    public List<Image> toolsUI = new List<Image>();
    [SerializeField] private Color selectColor;
    [SerializeField] private Color unselectColor;



    private PlayerItems playerItems; // Referência ao script PlayerItems
    private Player player; // Referência ao script Player


    private void Awake()
    {
        playerItems = FindAnyObjectByType<PlayerItems>(); // Encontra o objeto PlayerItems na cena
        player = playerItems.GetComponent<Player>(); // Encontra o objeto Player na cena
    }

    private void Start()
    {
        waterUIBar.fillAmount = 0f;
        woodUIBar.fillAmount = 0f;
        carrotUIBar.fillAmount = 0f;
        fishtUIBar.fillAmount = 0f;
    }

    private void Update()
    {
        waterUIBar.fillAmount = playerItems.currentWater / playerItems.waterLimit; // Atualiza a barra de água
        woodUIBar.fillAmount = playerItems.currentWood / playerItems.woodLimit; // Atualiza a barra de madeira
        carrotUIBar.fillAmount = playerItems.currentCarrots / playerItems.carrotLimit; // Atualiza a barra de cenouras
        fishtUIBar.fillAmount = playerItems.currentFishies / playerItems.fishiesLimit; // Atualiza a barra de peixes


        for (int i = 1; i < toolsUI.Count; i++)
        {
            if (i == player.handlingObj) // Se o índice não for o mesmo que o objeto selecionado
            {
                toolsUI[i].color = selectColor; // Muda a cor para a cor não selecionada
            }
            else // Se o índice for o mesmo que o objeto selecionado
            {
                toolsUI[i].color = unselectColor; // Muda a cor para a cor selecionada
            }
        }
    }
}
