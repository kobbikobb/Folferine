namespace Folferine.Website.Domain
{
    public class Round
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public int Score { get; set; }
        public int Par { get; set; }

        public virtual Scorecard Scorecard { get; set; }

        public Round()
        {
            
        }

        public Round(int number, int par, Scorecard scorecard)
        {
            Number = number;
            Par = par;
            Scorecard = scorecard;
        }
    }
}
