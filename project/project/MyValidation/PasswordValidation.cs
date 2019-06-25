using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace project.MyValidation
{
    public class PasswordValidation:ValidationAttribute
    {

        public override bool IsValid(object value)
        {

            string str = value.ToString();
            bool UpperFlag = false;
            bool LowerFlag = false;
            bool NumberFlag = false;
            bool SpecialFlag = false;
            for (int i = 0; i < str.Length; i++)
            {
                if (Char.IsDigit(str[i]))
                {
                    NumberFlag = true;
                }
                else if (char.IsLower(str[i]))
                {
                    LowerFlag = true;
                }
                else if (char.IsUpper(str[i]))
                {
                    UpperFlag = true;
                }
                else
                    SpecialFlag = true;
            }
            return LowerFlag && UpperFlag && SpecialFlag && NumberFlag;

        }
}
    
}