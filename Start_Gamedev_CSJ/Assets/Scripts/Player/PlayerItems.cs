using UnityEngine;

public class PlayerItems : MonoBehaviour
{
    [SerializeField] private int _totalWood; //Total de madeira que o jogador tem
    public int totalWood { get => _totalWood; set => _totalWood = value; } //Propriedade para acessar a variável _totalWood de fora da classe
}
