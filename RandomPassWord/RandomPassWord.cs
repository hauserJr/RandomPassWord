using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class RandomPassWord
{
    Random _Random = new Random();

    //存放ASCII
    private List<int> ASCII_List = new List<int>();

    //存放轉換後的密碼
    private string ResultPassWord = string.Empty;

    //每位密碼種類,大小寫英數
    private static int PassWordType;
    private static int PassWordTypeMix = 0;
    private static int PassWordTypeMax = 2 + 1;

    /*ASCII碼 大寫英文*/
    private static int capital_PassWordMix = 65;
    private static int capital_PassWordMax = 90 + 1;

    /*ASCII碼 小寫英文*/
    private static int lower_PassWordMix = 97;
    private static int lower_PassWordMax = 122 + 1;

    /*ASCII碼 數字*/
    private static int integer_PassWordMix = 48;
    private static int integer_PassWordMax = 57 + 1;

    /// <summary>
    /// 產生隨機密碼,所有參數皆可不帶,密碼預設為八個字元長度,不需插入符號
    /// </summary>
    /// <param name="PassWordLength">密碼長度</param>
    /// <param name="MarkFlag">是否需要插入符號 0:不用,1:需要</param>
    /// <returns></returns>
    public string ProducePasswWord(int? PassWordLength = null,int? MarkFlag = null)
    {
        //存放ASCII的List每次執行前須Clear以確保沒有任何舊內容
        ASCII_List.Clear();
        //存放結果的String每次執行前須Empty以確保沒有任何舊內容
        ResultPassWord = string.Empty;
        //預設8個字元
        PassWordLength = PassWordLength.HasValue ? PassWordLength : 8;
        for (int i = 0; i < PassWordLength; i++)
        {
            PassWordType = _Random.Next(PassWordTypeMix, PassWordTypeMax);
            switch (PassWordType)
            {
                //大寫英文
                case 0:
                    ASCII_List.Add(_Random.Next(capital_PassWordMix, capital_PassWordMax));
                    break;
                //小寫英文
                case 1:
                    ASCII_List.Add(_Random.Next(lower_PassWordMix, lower_PassWordMax));
                    break;
                //數字
                default:
                    ASCII_List.Add(_Random.Next(integer_PassWordMix, integer_PassWordMax));
                    break;
            }
        }
        foreach (int ASCII_Num in ASCII_List)
        {
            ResultPassWord += Convert.ToChar(ASCII_Num);
        }
        //密碼產生完畢後,插入符號
        if (MarkFlag == 1)
        {
            ResultPassWord = PassWordMark(ResultPassWord);
        }
        return ResultPassWord;
    }

    public string PassWordMark(string OldPassWord)
    {
        string NEWPassWord = string.Empty;
        try
        {
            //符號ASCII陣列 ~!@#$%^&*()-+<>? 
            int[] ASCII_Mark = { 126, 33, 64, 35, 36, 37, 94, 38, 42, 40, 41, 45, 43, 60, 62, 63 };
            //隨機選擇一個符號
            string MarkLength = Convert.ToChar(ASCII_Mark[_Random.Next(0, ASCII_Mark.Length)]).ToString();
            //隨機取得密碼任一位置
            int strPlace = _Random.Next(0, OldPassWord.Length);
            //移除隨機位置的密碼字元
            NEWPassWord = OldPassWord.Remove(strPlace, 1).Insert(strPlace, @MarkLength);
            return NEWPassWord;
        }
        catch
        {

        }
        return NEWPassWord;
    }
}

