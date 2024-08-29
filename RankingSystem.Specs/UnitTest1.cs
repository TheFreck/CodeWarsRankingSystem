using Machine.Specifications;

namespace RankingSystem.Specs
{
    public class When_Completing_An_Activity_That_Is_One_Level_Above
    {
        Establish context = () =>
        {
            actRank = -7;
            user = new User
            {
                rank = -8,
                progress = 95
            };
            expectedRank = -7;
            expectedProgress = 5;
        };

        Because of = () => user.incProgress(actRank);

        It Should_Increase_User_Rank = () => user.rank.ShouldEqual(expectedRank);
        It Should_Increase_User_Progress = () => user.progress.ShouldEqual(expectedProgress);

        private static int actRank;
        private static User user;
        private static int expectedRank;
        private static int expectedProgress;
    }

    public class When_Completing_Multiple_Levels_Above
    {
        Establish context = () =>
        {
            inputs = new List<Tuple<User, int, int, int>>
            {
                new (new User
                {
                    rank = -8,
                    progress = 0
                },-2,-5,60),
                new Tuple<User, int, int, int>(new User
                {
                    rank = -1,
                    progress = 50
                },4,2,10),
                new(new User
                {
                    rank = 5,
                    progress = 0
                }, 2, 5, 0),
                new(new User
                {
                    rank = 6,
                    progress = 35
                }, 6, 6, 38),
                new(new User
                {
                    rank = 7,
                    progress = 0
                }, 6, 7, 1),
                new(new User
                {
                    rank = -1,
                    progress = 0
                }, -7, -1, 0),
                new(new User
                {
                    rank = 2,
                    progress = 0
                }, 1, 2, 1),
                new(new User
                {
                    rank = 5,
                    progress = 0
                }, 5, 5, 3),
                new(new User
                {
                    rank = -8,
                    progress = 0
                }, 1, -2, 40),
                new(new User
                {
                    rank = -2,
                    progress = 40
                }, 1, -2, 80),
                new(new User
                {
                    rank = -2,
                    progress = 80
                }, 1, -1, 20),
                new(new User
                {
                    rank = -1,
                    progress = 20
                }, 1, -1, 30),
                new(new User
                {
                    rank = -1,
                    progress = 30
                }, 1, -1, 40),
                new(new User
                {
                    rank = -1,
                    progress = 40
                }, 2, -1, 80),
                new(new User
                {
                    rank = -1,
                    progress = 80
                }, 2, 1, 20),
                new(new User
                {
                    rank = 1,
                    progress = 20
                }, -1, 1, 21)
            };
        };

        Because of = () =>
        {
            for (var i = 0; i < inputs.Count; i++)
            {
                inputs[i].Item1.incProgress(inputs[i].Item2);
            }
        };

        It Should_Increase_User_Rank = () =>
        {
            for (var i = 0; i < inputs.Count; i++)
            {
                inputs[i].Item1.rank.ShouldEqual(inputs[i].Item3);
            }
        };
        It Should_Increase_User_Progress = () =>
        {
            for (var i = 0; i < inputs.Count; i++)
            {
                inputs[i].Item1.progress.ShouldEqual(inputs[i].Item4);
            }
        };

        private static List<Tuple<User, int, int, int>> inputs;
    }
}