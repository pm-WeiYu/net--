using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;

using System.Data;
using LabelManager2;
using System.Data.OleDb;


namespace ConsoleApplication1
{
    class Program
    {
        ApplicationClass lbl = new ApplicationClass();
        Document doc;
        static void Main(string[] args)
        {
            Program pr = new Program();
            pr.Band();
        }

        public  void Band()
        {
            //指定路径
            lbl.Documents.Open(@"c:\ckd.Lab", false);// 调用设计好的label文件
            doc = lbl.ActiveDocument;
            //输入参数
            doc.Variables.FormVariables.Item("变量0").Value = "123";//给参数传值物料编号
            doc.Variables.FormVariables.Item("变量1").Value = "123"; //给参数传值 日期
            doc.Variables.FormVariables.Item("变量2").Value = "123"; //给参数传值  数量
            doc.Variables.FormVariables.Item("变量4").Value = "123"; //给参数传值  描述

            int Num = Convert.ToInt32(3);        //打印数量
            doc.PrintDocument(Num);                             //打印
        }
    }
}
