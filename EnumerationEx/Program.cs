using System;
using System.Runtime.CompilerServices;
enum CommodityCategory 
{
    Furniture, Grocery, Service
}
class Commodity
{
    public CommodityCategory Category;
    public string CommodityName;
    public int CommodityQuantity;
    public double CommodityPrice;
    public Commodity(CommodityCategory Category, string CommodityName, int CommodityQuantity, int CommodityPrice)
    {
        this.Category = Category;
        this.CommodityName = CommodityName;
        this.CommodityQuantity = CommodityQuantity;
        this.CommodityPrice = CommodityPrice;
    }
}
class PrepareBill
{
    private readonly IDictionary<CommodityCategory, double> _taxRates;
    public PrepareBill()
    {
       _taxRates=new Dictionary<CommodityCategory,double>();
    }
   public void SetTaxRates(CommodityCategory category, double taxRate)
   {
        if (!(_taxRates.ContainsKey(category)))
        {
            _taxRates.Add(category, taxRate);
        }
        
   }
    public double CalculateBillAmount(IList<Commodity> items)
    {
       
        double totalPrice = 0;
        double tax = 0;
        foreach(Commodity item in items)
        {
            foreach (var taxRate in _taxRates)
            {

                if (item.Category == taxRate.Key)
                {
                    tax = taxRate.Value;
                    totalPrice = item.CommodityPrice * item.CommodityQuantity;
                }
                else
                {
                    throw new ArgumentException();
                }
            }
        }

        return totalPrice+tax;

    }
   public static void Main(string[] args)
    {
        var commodities = new List<Commodity>()
        {
            new Commodity(CommodityCategory.Furniture,"Bed",2,50000),
            new Commodity(CommodityCategory.Grocery,"Flour",5,80),
            new Commodity(CommodityCategory.Service,"Insurance",8,8500)
        };
        var prepareBill=new PrepareBill();
        prepareBill.SetTaxRates(CommodityCategory.Furniture, 18);
        prepareBill.SetTaxRates(CommodityCategory.Grocery, 5);
        prepareBill.SetTaxRates(CommodityCategory.Service, 12);
        var billAmount=prepareBill.CalculateBillAmount(commodities);
        Console.WriteLine(billAmount);



    }
}
