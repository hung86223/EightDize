using System.Collections.Generic;
using NUnit.Framework;

namespace EightenDize
{
    public class Tests
    {
        private Dice _dice;

        [SetUp]
        public void Setup()
        {
            _dice = new Dice();
        }

        [Test]
        public void No_Point_No_Point()
        {
            ResultShouldBe("Amy:1 2 3 4  Lin:2 3 4 5", "Tie.");
        }

        [Test]
        public void Normal_Points_No_Points()
        {
            ResultShouldBe("Amy:1 1 2 4  Lin:2 3 4 5", "Amy wins. normal points: 6");
        }
        private void ResultShouldBe(string score, string expected)
        {
            Assert.AreEqual(expected, _dice.Result(score));
        }
    }

    public class Dice
    {
        private string[] _playerInfo;
        private List<PlayerInfo> _playerInfos = new List<PlayerInfo>();

        public string Result(string score)
        {
            var players = score.Split("  ");
            foreach (var player in players)
            {
                _playerInfo = player.Split(':');
                _playerInfos.Add(new PlayerInfo()
                {
                    Name = _playerInfo[0],
                    ScoreString = _playerInfo[1],
                }); ;
            }

            return "Tie.";
        }
    }

    public class PlayerInfo
    {
        public string Name { get; set; }
        public string ScoreString { get; set; }
    }
}