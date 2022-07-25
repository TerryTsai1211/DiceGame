namespace Game_Dice
{
    public class DiceGameTest
    {
        DiceGame game ;

        [SetUp]
        public void SetUp()
        {
            game = new DiceGame();
        }

        [Test]
        public void ��ʴ����[��G()
        {
            DiceGame gameDemo = new DiceGame();
            var result = gameDemo.PlayAndGetResult();

            foreach (int number in result.DiceNumbers)
                TestContext.WriteLine($"�Ʀr�G{number}");

            TestContext.WriteLine($"�`�M�G{result.Total}");
        }

        [Test]
        public void Exception_��l�Ʀr_�u��O�|��()
        {
            Exception ex = Assert.Throws<Exception>(() => game.PlayAndGetResult(new int[] { 1, 2, 3, 4, 5 }));
            StringAssert.Contains("�u��O�|��", ex.Message);
        }

        [Test]
        [TestCase(1,2,3,4)]
        [TestCase(3,4,5,6)]
        public void Exception_��l�Ʀr_���ŦX�C���W�h(int no1, int no2, int no3, int no4)
        {
            var diceGame = ConvertToDiceNumbers(no1, no2, no3, no4);
            Exception ex = Assert.Throws<Exception>(() => game.PlayAndGetResult(diceGame));
            StringAssert.Contains("���ŦX�C���W�h", ex.Message);
        }

        [Test]
        [TestCase(1, 1, 1, 1, 2)]
        [TestCase(2, 2, 2, 2, 4)]
        [TestCase(3, 3, 3, 3, 6)]
        [TestCase(4, 4, 4, 4, 8)]
        [TestCase(5, 5, 5, 5, 10)]
        [TestCase(6, 6, 6, 6, 12)]
        public void �|��Ʀr���@��(int no1, int no2, int no3, int no4, int expected)
        {
            AssertMethod(no1, no2, no3, no4, expected);
        }

        [Test]
        [TestCase(1, 1, 1, 6, 7)]
        [TestCase(2, 2, 2, 6, 8)]
        [TestCase(3, 3, 3, 6, 9)]
        [TestCase(4, 4, 4, 6, 10)]
        [TestCase(5, 5, 5, 6, 11)]
        public void ��@�Ʀr�X�{�T��(int no1, int no2, int no3, int no4, int expected)
        {
            AssertMethod(no1, no2, no3, no4, expected);
        }

        [Test]
        [TestCase(1, 1, 2, 3, 5)]
        [TestCase(2, 2, 3, 4, 7)]
        [TestCase(3, 3, 4, 5, 9)]
        [TestCase(4, 4, 5, 6, 11)]
        public void �Ʀr����_�@��(int no1, int no2, int no3, int no4, int expected)
        {
            AssertMethod(no1, no2, no3, no4, expected);
        }

        [Test]
        [TestCase(1, 1, 2, 2, 4)]
        [TestCase(2, 2, 3, 3, 6)]
        [TestCase(3, 3, 4, 4, 8)]
        [TestCase(4, 4, 5, 5, 10)]
        [TestCase(5, 5, 6, 6, 12)]
        public void �Ʀr����_�G��(int no1, int no2, int no3, int no4, int expected)
        {
            AssertMethod(no1, no2, no3, no4, expected);
        }

        private void AssertMethod(int no1, int no2, int no3, int no4, int expected)
        {
            int[] diceGame = ConvertToDiceNumbers(no1, no2, no3, no4);
            int actual = game.PlayAndGetResult(diceGame);
            Assert.IsTrue(expected == actual);
        }

        private int[] ConvertToDiceNumbers(int no1, int no2, int no3, int no4)
        {
            int[] diceGame = new int[4];
            int index = 0;
            diceGame[index++] = no1;
            diceGame[index++] = no2;
            diceGame[index++] = no3;
            diceGame[index++] = no4;
            return diceGame;
        }
    }
}