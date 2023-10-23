using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FooBarQixV2;

internal class NumberInterpreter
{
    private int InputNumber { get; set; }
    private string OutputExpression { get; set; }
    public NumberInterpreter(int number) 
    { 
        InputNumber = number;
        OutputExpression = string.Empty;
    }

    public void GetExpressionByNumber()
    {
        var rslt = new StringBuilder();

        var foo = GetDivisibilityByEnum(EnumExpressions.Foo, InputNumber);
        var bar = GetDivisibilityByEnum(EnumExpressions.Bar, InputNumber);
        var qix = GetDivisibilityByEnum(EnumExpressions.Qix, InputNumber);
        var contained = GetContainedChar(InputNumber);
        rslt.Append(foo).Append(bar).Append(qix).Append(contained);

        if (rslt.Length == 0 || rslt.ToString().Distinct().Count() == 1)
        {
            OutputExpression = InputNumber.ToString().Replace("0", "*");
        }
        else
        {
            OutputExpression = rslt.ToString();
        }
    }

    private static string GetDivisibilityByEnum(EnumExpressions enumTable, int number)
    {
        var rslt = new StringBuilder();
        if (number % (int)enumTable == 0)
        {
            rslt.Append(enumTable.ToString());
        }
        return rslt.ToString();
    }

    private static string GetContainedChar(int number)
    {
        var rslt = new StringBuilder();

        foreach (char c in number.ToString())
        {
            if (c.ToString() == ((int)EnumExpressions.Foo).ToString())
            {
                rslt.Append(EnumExpressions.Foo.ToString());
            }
            else if (c.ToString() == ((int)EnumExpressions.Bar).ToString())
            {
                rslt.Append(EnumExpressions.Bar.ToString());
            }
            else if (c.ToString() == ((int)EnumExpressions.Qix).ToString())
            {
                rslt.Append(EnumExpressions.Qix.ToString());
            }
            else if (c == '0')
            {
                rslt.Append('*');
            }
        }

        return rslt.ToString();
    }

}
