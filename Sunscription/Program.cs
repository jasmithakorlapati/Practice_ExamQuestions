namespace Subscriptions
{
    interface IbroadbandPlan
    {
        int GetBroadbandPlan();
    }
    class Black : IbroadbandPlan
    {
        private readonly bool _isSubscriptionValid;
        private readonly int _discountPercentage;
        private const int PlanAmount = 3000;
        public Black(bool isSubscriptionValid, int discountPercentage)
        {
           
            if (discountPercentage < 0 || discountPercentage > 50)
            {
                throw new ArgumentOutOfRangeException();
            }
            
                _isSubscriptionValid = isSubscriptionValid;
                _discountPercentage = discountPercentage;
            
        }
        public int GetBroadbandPlan()
        {
            if (_isSubscriptionValid)
                return PlanAmount-((PlanAmount*_discountPercentage)/100);
            else
                return PlanAmount;
        }
    }
    class Gold : IbroadbandPlan
    {
        private readonly bool _isSubscriptionValid;
        private readonly int _discountPercentage;
        private const int PlanAmount = 1500;

        public Gold(bool isSubscriptionValid, int discountPercentage)
        {
           
            if (discountPercentage < 0 || discountPercentage > 50)
            {
                throw new ArgumentOutOfRangeException();
            }
             _discountPercentage = discountPercentage;
             _isSubscriptionValid = isSubscriptionValid;
        }
        public int GetBroadbandPlan()
        {
            if (_isSubscriptionValid)
                return PlanAmount - ((PlanAmount * _discountPercentage) / 100);
            else
                return PlanAmount;
        }
    }
    class SubscribePlan
    {
        private readonly IList<IbroadbandPlan> _broadbandPlans;
        SubscribePlan(IList<IbroadbandPlan> broadbandPlans)
        {
            _broadbandPlans = broadbandPlans;
        }
        public IList<Tuple<string, int>> GetSubscriptionPlan()
        {
            if (_broadbandPlans == null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                var res = new List<Tuple<string, int>>();
                foreach (var item in _broadbandPlans)
                {
                    string name = item.GetType().Name;
                    int amount = item.GetBroadbandPlan();
                    res.Add(new Tuple<string,int>(name, amount));
                }
                return res;
            }
        }
        public class Program
        {
            static void Main(string[] args)
            {
                var plans = new List<IbroadbandPlan>
                {
                    new Black(true, 50),
                    new Black(false, 10),
                    new Gold(true, 30),
                    new Black(true, 20),
                    new Gold(false, 20)
                };
                var subscriptionPlans = new SubscribePlan(plans);
                var result = subscriptionPlans.GetSubscriptionPlan();
                foreach (var item in result)
                {
                    Console.WriteLine($"{item.Item1},{item.Item2}");
                }
            }
        }
    }
}
