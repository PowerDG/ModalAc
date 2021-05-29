using Newtonsoft.Json;
using System;
using System.Text;
using System.Text.RegularExpressions;

namespace RegexDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //Console.WriteLine(ReplaceStyleSheetsByRegexTest());

            //(new CurrentThreadDemo()).operatorJoinDemo();

            //ThreadTestDemo.MainTitle();

            (new CopyTest()).RunTask();
            Console.ReadKey();
        }

        public static string ReplaceStyleSheetsByRegexTest()
        {
            var html = GetHtml();
            var externalStyle = $@"<link href=   ""22"" rel=""stylesheet"" type=""text / css"" /> ";
            return ReplaceStyleSheetsByRegex(html,externalStyle);
        }

        /// <summary>
        /// 配置中获取的样式文件替换html中的style标签
        /// Replaces the style sheets by regex.
        /// </summary>
        /// <param name="html">The HTML.</param>
        /// <param name="stylesheet">The stylesheet.</param>
        /// <returns></returns>
        public static string ReplaceStyleSheetsByRegex(string html ,string stylesheet)
        {
            Regex regex = new Regex(@"<style((.|\n)*)</style>");
            if (regex.IsMatch(html))
            {
                html = regex.Replace(html, stylesheet);
            }
            return html;
        }

        /// <summary>
        /// Replaces the by regex.
        /// </summary>
        ///  string pattern2 = @"^[1-9]\d{4,11}$";
        ///  var pattern = @"(\d+)-(\d+)-(\d+)";
        /// var targetStyle = "<hr/>";
        /// <returns></returns>
        public static string GetHtml()
        {
            //var htmlBulider = new StringBuilder(html);
            return "<html xmlns:n3=\"http://www.w3.org/1999/xhtml\" xmlns:n1=\"urn:hl7-org:v3\" xmlns:n2=\"urn:hl7-org:v3/meta/voc\" xmlns:voc=\"urn:hl7-org:v3/voc\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\">\n  <head>\n    <!--\n          Do NOT edit this HTML directly, it was generated via an XSLt\n          transmation from the original release 2 CDA Document.\n        -->\n    <title>手术知情告知书</title>\n    <style type=\"text/css\">\n                    h1 {\n                        padding: 12px;\n                        padding-bottom: 0;\n                    }      \n                    .divCell {\n                        padding: 12px;\n                        padding-bottom: 0;\n                    }\n\n                    .divCell:last-child {\n                        padding-bottom: 12px;\n                    }\n                    .base-table {\n                      width: 100%;\n                      border: 1px solid #DDDDE3;\n                      border-spacing: 0;\n                      border-collapse: separate;\n                  }\n\n                    .special-table {\n                        margin: 0 12px;\n                        width: calc(100% - 24px);\n                    }\n\n                    .base-table td {\n                        padding: 0;\n                    }\n\n                    .base-table tr .col_Key,\n                    .base-table tr .col_Value {\n                        padding-bottom: 0 !important;\n                    }\n\n                    .base-table tr:last-child .col_Key,\n                    .base-table tr:last-child .col_Value {\n                        padding-bottom: 20px !important;\n                    }\n\n                    .base-table h3 {\n                        padding: 8px;\n                        margin: 0;\n                        font-size: 14px;\n                        font-weight: 600;\n                        color: #293750;\n                        background: #F6F7F9;\n                        border-bottom: 1px solid #DDDDE3;\n                    }\n                    .col_Key, .col_Value {\n                        font-size: 14px;\n                        font-weight: 400;\n                        color: #293750;\n                        padding: 20px 8px !important;\n                    }\n\n                    .header{\n                        padding: 10px 0px 5px;\n                        background-color: rgb(225, 225, 225);\n                    }\n\n                    .col_Key{\n                         width:150px;\n                    }\n                    .col_Value{\n                        text-align:left;\n                    }\n                </style>\n  </head>\n  <!--\n        Derived from HL7 Finland R2 Tyylitiedosto: Tyyli_R2_B3_01.xslt\n        Updated by   Calvin E. Beebe,   Mayo Clinic - Rochester Mn.\n      -->\n  <body>\n    <table>\n      <table>\n        <tr>\n          <td colspan=\"4\">\n            <h1 align=\"center\">手术知情告知书</h1>\n          </td>\n        </tr>\n      </table>\n      <div class=\"divCell\">\n        <table class=\"base-table\">\n          <tr class=\"header-title\">\n            <td colspan=\"4\">\n              <h3 class=\"header\">患者基本资料</h3>\n            </td>\n          </tr>\n          <tr>\n            <td class=\"col_Key\">\n              <b>身份证号：</b>\n            </td>\n            <td>\n              <div class=\"col_Value\">350********1100013</div>\n            </td>\n          </tr>\n          <tr>\n            <td class=\"col_Key\">\n              <b>病历号码：</b>\n            </td>\n            <td>\n              <div class=\"col_Value\">2020003115_1</div>\n            </td>\n          </tr>\n          <tr>\n            <td class=\"col_Key\">\n              <b>病患姓名：</b>\n            </td>\n            <td>\n              <div class=\"col_Value\">翁**</div>\n            </td>\n          </tr>\n          <tr>\n            <td class=\"col_Key\">\n              <b>患者性别：</b>\n            </td>\n            <td>\n              <div class=\"col_Value\">**</div>\n            </td>\n          </tr>\n          <tr>\n            <td class=\"col_Key\">\n              <b>出生日期：</b>\n            </td>\n            <td>\n              <div class=\"col_Value\">19**-**-**</div>\n            </td>\n          </tr>\n          <tr>\n            <td class=\"col_Key\">\n              <b>患者职业：</b>\n            </td>\n            <td>\n              <div class=\"col_Value\"></div>\n            </td>\n          </tr>\n        </table>\n      </div>\n      <div class=\"divCell\">\n        <table class=\"base-table\">\n          <tr class=\"header-title\">\n            <td colspan=\"4\">\n              <h3 class=\"header\">\n                住院基本资料\n              </h3>\n            </td>\n          </tr>\n          <tr>\n            <td class=\"col_Key\">\n              <b>住院科室：</b>\n            </td>\n            <td>\n              <div class=\"col_Value\">十二区</div>\n            </td>\n          </tr>\n          <tr>\n            <td class=\"col_Key\">\n              <b>住院床号：</b>\n            </td>\n            <td>\n              <div class=\"col_Value\">41</div>\n            </td>\n          </tr>\n        </table>\n      </div>\n      <div class=\"divCell\">\n        <table class=\"base-table\">\n          <tr>\n            <td colspan=\"4\">\n              <h3 class=\"header\">术前诊断\n                    </h3>\n            </td>\n          </tr>\n          <tr>\n            <td class=\"col_Key\">\n              <b>术前诊断名称     ：</b>\n            </td>\n            <td>\n              <div class=\"col_Value\">背部脓肿</div>\n            </td>\n          </tr>\n        </table>\n      </div>\n      <div class=\"divCell\">\n        <table class=\"base-table\">\n          <tr>\n            <td colspan=\"4\">\n              <h3 class=\"header\">治疗计划\n                    </h3>\n            </td>\n          </tr>\n          <tr>\n            <td class=\"col_Key\">\n              <b>手术方式     ：</b>\n            </td>\n            <td>\n              <div class=\"col_Value\">-</div>\n            </td>\n          </tr>\n          <tr>\n            <td class=\"col_Key\">\n              <b>术前准备     ：</b>\n            </td>\n            <td>\n              <div class=\"col_Value\">-</div>\n            </td>\n          </tr>\n          <tr>\n            <td class=\"col_Key\">\n              <b>手术禁忌症     ：</b>\n            </td>\n            <td>\n              <div class=\"col_Value\">-</div>\n            </td>\n          </tr>\n          <tr>\n            <td class=\"col_Key\">\n              <b>手术指征     ：</b>\n            </td>\n            <td>\n              <div class=\"col_Value\">-</div>\n            </td>\n          </tr>\n          <tr>\n            <td class=\"col_Key\">\n              <b>拟实施麻醉方法     ：</b>\n            </td>\n            <td>\n              <div class=\"col_Value\">全身麻醉</div>\n            </td>\n          </tr>\n          <tr>\n            <td class=\"col_Key\">\n              <b>替代方案     ：</b>\n            </td>\n            <td>\n              <div class=\"col_Value\">PTCD、ERCP</div>\n            </td>\n          </tr>\n        </table>\n      </div>\n      <div class=\"divCell\">\n        <table class=\"base-table\">\n          <tr>\n            <td colspan=\"4\">\n              <h3 class=\"header\">意见章节</h3>\n            </td>\n          </tr>\n          <tr>\n            <td class=\"col_Key\">\n              <b>医疗机构的意见     ：</b>\n            </td>\n            <td>\n              <div class=\"col_Value\">以上内容请认真阅读，并理解其含义。对上述手术风险及并发症，如患者或代理人还不理解可以向医师咨询，在患者或代理人充分理解后，自主决定是否选择本治疗，请在文书上写明意见并签字。</div>\n            </td>\n          </tr>\n          <tr>\n            <td class=\"col_Key\">\n              <b>患者的意见     ：</b>\n            </td>\n            <td>\n              <div class=\"col_Value\">\n\t\t\t\t\t\t\t</div>\n            </td>\n          </tr>\n        </table>\n      </div>\n      <div class=\"divCell\">\n        <table class=\"base-table\">\n          <tr>\n            <td colspan=\"4\">\n              <h3 class=\"header\">操作风险</h3>\n            </td>\n          </tr>\n          <tr>\n            <td class=\"col_Key\">\n              <b>手术中可能出现的意外及风险     ：</b>\n            </td>\n            <td>\n              <div class=\"col_Value\">\n\t\t\t\t\t\t\t</div>\n            </td>\n          </tr>\n          <tr>\n            <td class=\"col_Key\">\n              <b>手术后可能出现的意外以及风险     ：</b>\n            </td>\n            <td>\n              <div class=\"col_Value\">\n\t\t\t\t\t\t\t</div>\n            </td>\n          </tr>\n        </table>\n      </div>\n    </table>\n  </body>\n</html>";


        }
    }
    

    public class CopyTest
    {
        public void RunTask()
        {

            var a = new CopyDemo(2, "form");
            var b = new CopyDemo();
            Console.WriteLine(JsonConvert.SerializeObject(a));

            Console.WriteLine(JsonConvert.SerializeObject(b));
            Console.WriteLine("==");

            b = a;
            b.name = "NextName";
            b.Index = 23;
            Console.WriteLine(JsonConvert.SerializeObject(a));

            Console.WriteLine(JsonConvert.SerializeObject(b));

            Console.WriteLine("==");

            a.name = "NewA'Name";
            Console.WriteLine(JsonConvert.SerializeObject(a));

            Console.WriteLine(JsonConvert.SerializeObject(b));
        }
    }

    public class CopyDemo
        
    {
        public CopyDemo()
        {

        }
        public CopyDemo( int index ,string name)
        {
            this.Index = index;
            this.name = name;

        }
        public int Index { get; set; }
        public string name { get; set; }

    }
}
