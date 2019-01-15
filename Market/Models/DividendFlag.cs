namespace Market.Models
{
    public enum DividendFlag
    {
        Unknown,                    //Polygon.io codes below:
        FinalDividend,              //FI
        Liquidation,                //LI
        ProceedsOfSale,             //PR
        RedemptionOfRights,         //RE
        AccruedDividend,            //AC
        PaymentInArrears,           //AR
        AdditionalPayment,          //AD
        ExtraPayment,               //EX
        SpecialDividend,            //SP
        YearEnd,                    //YE
        UnknownRate,                //UR
        RegularDividendIsSuspended  //SU
    }
}