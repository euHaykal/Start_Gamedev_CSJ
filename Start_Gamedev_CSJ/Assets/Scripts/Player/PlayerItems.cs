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

    [Header("Fishies")]
    [SerializeField] private int _currentFishies; //Total de peixes que o jogador tem
    public int currentFishies { get => _currentFishies; set => _currentFishies = value; } //Propriedade para acessar a variável _totalWater de fora da classe
    [SerializeField] private float _fishiesLimit;
    public float fishiesLimit { get => _fishiesLimit; set => _fishiesLimit = value; } //Propriedade para acessar a variável _totalWater de fora da classe
    [SerializeField] private float _fishingRangeMin = 1; // Valor mínimo do Random.Range
    [SerializeField] private float _fishingRangeMax = 100; // Valor máximo do Random.Range
    public float fishingRangeMin { get => _fishingRangeMin; set => _fishingRangeMin = value; }
    public float fishingRangeMax { get => _fishingRangeMax; set => _fishingRangeMax = value; }

    public void WaterLimit(float water)
    {
        currentWater = Mathf.Min(currentWater + water, waterLimit);
    }

    public void WoodLimit(int wood)
    {
        currentWood = Mathf.Min(currentWood + wood, (int)woodLimit);
    }

    public void CarrotLimit(int carrots)
    {
        currentCarrots = Mathf.Min(currentCarrots + carrots, (int)carrotLimit);
    }

    public void FishiesLimit(int fishies)
    {
        currentFishies = Mathf.Min(currentFishies + fishies, (int)fishiesLimit);
    }
}
