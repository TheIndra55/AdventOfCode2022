class Day2 : IDay
{
    public object Part1(List<string> lines)
    {
        var score = 0;

        foreach (var line in lines)
        {
            Action opponent = ToAction(line[0], out _), player = ToAction(line[2], out var actionScore);

            score += actionScore;
            score += Won(opponent, player);
        }

        return score;
    }

    public object Part2(List<string> lines)
    {
        var score = 0;

        foreach (var line in lines)
        {
            var opponent = ToAction(line[0], out _);
            var end = line[2];

            Action player = 0;
            switch (end)
            {
                case 'X':
                    player = opponent - 1;
                    if (player < 0) player = Action.Rock;

                    break;
                case 'Y':
                    player = opponent;

                    break;
                case 'Z':
                    player = opponent + 1;
                    if (player > Action.Rock) player = Action.Paper;

                    break;
            };

            score += ToScore(player);
            score += Won(opponent, player);
        }

        return score;
    }

    private int ToScore(Action action)
    {
        return action switch
        {
            Action.Rock => 1,
            Action.Paper => 2,
            Action.Scissors => 3
        };
    }

    private int Won(Action opponent, Action player)
    {
        if (player == opponent)
        {
            return 3;
        }

        // check if opponent move is below my move (with some ugly case for paper and rock)
        if ((player == Action.Paper && opponent == Action.Rock)
            || player > opponent && !(player == Action.Rock && opponent == Action.Paper))
        {
            return 6;
        }

        return 0;
    }

    private Action ToAction(char letter, out int score)
    {
        int action = 0;

        // ascii table position
        if ((byte)letter < 68)
        {
            action = (byte)letter - 65;
            score = action + 1;
        }
        else
        {
            action = (byte)letter - 88;
            score = action + 1;
        }

        // since action table not in that order
        return action switch
        {
            0 => Action.Rock,
            1 => Action.Paper,
            2 => Action.Scissors
        };
    }

    enum Action
    {
        Rock = 2,
        Paper = 0,
        Scissors = 1,
    }
}