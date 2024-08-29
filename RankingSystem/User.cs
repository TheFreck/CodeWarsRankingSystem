namespace RankingSystem
{
    public class User
    {
        public int rank;
        public int progress;

        public User()
        {
            rank = -8;
        }
        public void incProgress(int actRank)
        {
            if (actRank < -8 || actRank > 8 || actRank == 0) throw new ArgumentException();
            var ranks = new int[] { -8, -7, -6, -5, -4, -3, -2, -1, 1, 2, 3, 4, 5, 6, 7, 8 };
            var diff = Array.IndexOf(ranks, actRank) - Array.IndexOf(ranks, rank);
            if (diff < 1)
            {
                if (diff == -1) progress += 1;
                if (diff == 0) progress += 3;
                progress = rank < 8 ? progress % 100 : 0;
            }
            else progress += diff * diff * 10;

            rank = ranks[Array.IndexOf(ranks, rank) + (progress - (progress % 100)) / 100];
            progress = rank < 8 ? progress % 100 : 0;
        }
    }
}