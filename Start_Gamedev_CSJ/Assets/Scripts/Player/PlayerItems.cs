using UnityEngine;

public class PlayerItems : MonoBehaviour
{
    [SerializeField] private int _totalWood; //Total de madeira que o jogador tem
    public int totalWood { get => _totalWood; set => _totalWood = value; } //Propriedade para acessar a variável _totalWood de fora da classe

    [SerializeField] private float _currentWater; //Total de água que o jogador tem
    public float currentWater { get => _currentWater; set => _currentWater = value; } //Propriedade para acessar a variável _totalWater de fora da classe

    [SerializeField] private int _currentCarrots; //Total de cenouras que o jogador tem
    public int currentCarrots { get => _currentCarrots; set => _currentCarrots = value; } //Propriedade para acessar a variável _totalWater de fora da classe

    [SerializeField] private float waterLimit;

    public void WaterLimit(float water)
    {
        if (currentWater < waterLimit) //Limite de água que o jogador pode ter
        {
            currentWater += water; //Adiciona a quantidade de água que o jogador tem

        }
    }
}
