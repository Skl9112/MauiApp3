using MauiApp3;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

public interface IRateService
{
    Task<IEnumerable<Rate>> GetRates(DateTime date);
}
