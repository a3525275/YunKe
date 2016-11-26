using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace YunKe.Infrastructure.Utilities
{
    public sealed class CardId
    {
        private static Hashtable areaInfo = new Hashtable();

        private static void IdentityCard()
        {
        }
        static CardId()
        {
            
        }
        public static string getAddress(string cardId)
        {
            return "";
        }
        public static string getSex(string cardId)
        {
            if (isCardId(cardId))
            {
                return Convert.ToInt16(cardId.Substring(16, 1)) % 2 == 0 ? "女" : "男";
            }
            else
            {
                return "";
            }
        }
        public static string getBirthday(string cardId)
        {
            if (isCardId(cardId))
            {
                if (isCardId18(cardId))
                {
                    return cardId.Substring(6, 8).Insert(4, "-").Insert(7, "-");
                }
                else
                {
                    return ("19" + cardId.Substring(6, 6)).Insert(4, "-").Insert(7, "-");
                }
            }
            else
            {
                return "";
            }
        }
        public static bool isCardId(string cardId)
        {
            if (cardId.Length == 18)
            {
                return isCardId18(cardId);
            }
            else if (cardId.Length == 15)
            {
                return isCardId15(cardId);
            }
            else
            {
                return false;
            }
        }
        public static bool isCardId18(string cardId)
        {
            long n = 0;
            if (long.TryParse(cardId.Remove(17), out n) == false || n < Math.Pow(10, 16) || long.TryParse(cardId.Replace('x', '0').Replace('X', '0'), out n) == false)
            {
                return false;
                //数字验证
            }
            //地址验证
            //if (!areaInfo.ContainsKey(cardId.Remove(6)))
            //    return false;
            string birth = cardId.Substring(6, 8).Insert(6, "-").Insert(4, "-");
            DateTime time = new DateTime();
            if (DateTime.TryParse(birth, out time) == false)
            {
                return false;
                //生日验证
            }
            string[] arrVarifyCode = ("1,0,x,9,8,7,6,5,4,3,2").Split(',');
            string[] Wi = ("7,9,10,5,8,4,2,1,6,3,7,9,10,5,8,4,2").Split(',');
            char[] Ai = cardId.Remove(17).ToCharArray();
            int sum = 0;
            for (int i = 0; i < 17; i++)
            {
                sum += int.Parse(Wi[i]) * int.Parse(Ai[i].ToString());

            }
            int y = -1;
            Math.DivRem(sum, 11, out y);
            if (arrVarifyCode[y] != cardId.Substring(17, 1).ToLower())
            {
                return false;
                //校验码验证
            }
            return true;
            //符合GB11643-1999标准
        }
        public static bool isCardId15(string cardId)
        {
            long n = 0;
            if (long.TryParse(cardId, out n) == false || n < Math.Pow(10, 14))
            {
                return false;
                //数字验证
            }
            //地址验证
            //if (!areaInfo.ContainsKey(cardId.Remove(6)))
            //    return false;
            string birth = cardId.Substring(6, 6).Insert(4, "-").Insert(2, "-");
            DateTime time = new DateTime();
            if (DateTime.TryParse(birth, out time) == false)
            {
                return false;
                //生日验证
            }
            return true;
            //符合15位身份证标准
        }
    }

    public sealed class PersonInfo
    {
        public Gender Gender { get; private set; }

        public DateTime? Birthday { get; private set; }

        public string Identity { get; private set; }

        public string Address { get; private set; }

        public bool IdentityValid { get; private set; }

        public PersonInfo(string identity)
        {
            if (CardId.isCardId(identity))
            {
                IdentityValid = true;
                this.Address = CardId.getAddress(identity);
                this.Gender = CardId.getSex(identity) == "女" ? Gender.Female : Gender.Male;
                var date = CardId.getBirthday(identity);
                DateTime birth;

                if (DateTime.TryParse(date, out birth))
                {
                    Birthday = birth;
                }
            }
            else
            {
                IdentityValid = false;
            }
        }
    }

    public enum Gender
    {
        Known = 0,
        Male = 1,
        Female = 2,
    }
}