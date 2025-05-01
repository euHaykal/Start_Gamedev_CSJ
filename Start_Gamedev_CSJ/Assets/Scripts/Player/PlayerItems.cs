using UnityEngine;

public class PlayerItems : MonoBehaviour
{
    [Header("Wood")]
    [SerializeField] private int _currentWood; //Total de madeira que o jogador tem
    public int currentWood { get => _currentWood; set => _currentWood = value; } //Propriedade para acessar a variável _totalWood de fora da classe
    [SerializeField] private float _woodLimit;
    public float woodLimit { get => _woodLimit; set => _woodLimit = value; } //Propriedade para acessar a variável _totalWater de fora da classe

    [Header("Water")]
    [SerializeField] private float _currentWater; //Total de água que o jogador tem
    public float currentWater { get => _currentWater; set => _currentWater = value; } //Propriedade para acessar a variável _totalWater de fora da classe
    [SerializeField] private float _waterLimit;
    public float waterLimit { get => _waterLimit; set => _waterLimit = value; } //Propriedade para acessar a variável _totalWater de fora da classe

    [Header("Carrots")]
    [SerializeField] private int _currentCarrots; //Total de cenouras que o jogador tem
    public int currentCarrots { get => _currentCarrots; set => _currentCarrots = value; } //Propriedade para acessar a variável _totalWater de fora da classe
    [SerializeField] private float _carrotLimit;
    public float carrotLimit { get => _carrotLimit; set => _carrotLimit = value; } //Propriedade para acessar a variável _totalWater de fora da classe

    public void WaterLimit(float water)
    {
        currentWater = Mathf.Min(currentWater + water, waterLimit);
    }
}
