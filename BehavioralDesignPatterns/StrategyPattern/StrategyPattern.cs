using System;
public interface IStrategy
{
    void Play();
}

public class AttackStrategy : IStrategy
{
    public void Play()
    {
        Console.WriteLine("Time está jogando no modo de ataque!");
    }
}

public class DefenseStrategy : IStrategy
{
    public void Play()
    {
        Console.WriteLine("Time está jogando no modo de defesa!");
    }
}

public class FootballTeam
{
    private IStrategy _strategy;

    public FootballTeam(IStrategy strategy)
    {
        _strategy = strategy;
    }

    public void PlayGame()
    {
        Console.WriteLine("O jogo começou!");
        _strategy.Play();
    }

    public void ChangeStrategy(IStrategy newStrategy)
    {
        Console.WriteLine("Mudando a estratégia durante o jogo!");
        _strategy = newStrategy;
    }
}

class Program
{
    static void Main()
    {
        IStrategy attackStrategy = new AttackStrategy();
        IStrategy defenseStrategy = new DefenseStrategy();

        FootballTeam team = new FootballTeam(attackStrategy);

        team.PlayGame();

        team.ChangeStrategy(defenseStrategy);

        team.PlayGame();
    }
}
