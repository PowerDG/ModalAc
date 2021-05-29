using Newtonsoft.Json;
using System;
using System.Linq;

namespace dgTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");


            //EnumerableRange();
            //IdRangePaged();

            TryEx();
            Console.ReadKey();
        }

        public static void EnumerableRange()
        {

            var list = Enumerable.Range(10, 43).ToList();
            //var list = Enumerable.Range(1, 9);

            Console.WriteLine(JsonConvert.SerializeObject(list));
        }


        public static void IdRangePaged2()
        {
            var sql= string.Empty;
            for (int j = 0; j < 3; j++)
            {

                var minId = 1;
                var maxId = 16;
                var pageSize =5;


                //item.MinId = isRetry ? documentTaskLog.RetryBeginID : item.MinId; //TODO  可以放foreach外

                var isFirstLoop = true;//是否是首次循环
                for (int i = minId; i < maxId; i += pageSize)
                {

                    //flagRetryId = minId;

                    //采用循环查询的方式 pageSize  作为每次循环 查询的数量 即每次查pageSize个id的记录
                    sql = string.Empty;
                    var currentIndex = i + pageSize;
                    var currentMax = currentIndex >= maxId ? maxId : currentIndex;
                    //如果首次循环id就超出最大边界值
                    if (isFirstLoop && currentIndex >= maxId)
                    {
                        //直接查询出结果
                        sql = @$"select * from table where id >={minId} and id<={currentMax}";
                        Console.WriteLine(sql);
                        break;
                    }
                    if (i == minId)
                    {
                        isFirstLoop = false;//打标记使得下次循环为非首次循环
                    }

                    //提前判断下一次的起始id值是否大于最大边界值
                    if (currentIndex >= maxId)
                    {
                        sql = @$"select * from table where id >={i} and id<={currentMax}";
                        Console.WriteLine(sql);
                        break;
                    }
                    //正常以PigeSize获取
                    sql = @$"select * from table where id >={i} and id<{currentMax}";
                    Console.WriteLine(sql);
                }
            }
        }


        public static string TryEx()
        {

            try
            {
                Console.WriteLine("run try");

                if (true)
                { 
                    Console.WriteLine("try LockReleaseAsync"); 
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ex了");
                //throw new Exception("！！！！");
                Console.WriteLine("catch???");


                Console.WriteLine("ex LockReleaseAsync");
                return null;
            }
            finally
            {

                Console.WriteLine("finally");
                Console.WriteLine("finally LockReleaseAsync");
            }


            return "over ";

        }


        public static void IdRangePaged()
        {
            var sql = string.Empty;
            //for (int j = 0; j < 3; j++)
            //{

                var minId = 1;
                var maxId = 16;
                var pageSize =6;


                //item.MinId = isRetry ? documentTaskLog.RetryBeginID : item.MinId; //TODO  可以放foreach外

                var isFirstLoop = true;//是否是首次循环
                for (int currentSatrtIndex = minId; currentSatrtIndex < maxId; currentSatrtIndex += pageSize)
                {

                    //flagRetryId = minId;

                    //采用循环查询的方式 pageSize  作为每次循环 查询的数量 即每次查pageSize个id的记录
                    sql = string.Empty;
                    var nextoffSet  = currentSatrtIndex + pageSize;
                    var currentEndIndex = nextoffSet  >= maxId ? maxId : nextoffSet ;

                    var remainToValidate = nextoffSet < maxId;
                    //如果首次循环id就超出最大边界值
                    //if (isFirstLoop && currentIndex >= maxId)
                    //{
                    //    //直接查询出结果
                    //    sql = @$" >={minId} and id<={currentMax}";
                    //    Console.WriteLine(sql);
                    //    break;
                    //}
                    //if (i == minId)
                    //{
                    //    isFirstLoop = false;//打标记使得下次循环为非首次循环
                    //}

                    //sql = @$" id >={currentSatrtIndex} and id<{currentEndIndex}";
                    //if (  !remainToValidate)
                    //{
                    //    sql = @$" id >={currentSatrtIndex} and id<={currentEndIndex}";
                    //    Console.WriteLine(sql);
                    //    break;
                    //}
                    ////if ((i + pageSize) >= maxId)
                    ////{
                    ////    sql = @$" id >={i} and id<={currentMax}";
                    ////    Console.WriteLine(sql);
                    ////    break;
                    ////}


                    sql = remainToValidate ?
                        @$"and id >={currentSatrtIndex} and id<{currentEndIndex}"
                        : @$"and id >={currentSatrtIndex} and id<={currentEndIndex}";

                    //Console.WriteLine(sql);
                    if (nextoffSet > 16)
                    {
                        Console.WriteLine($"continue");
                        continue;
                    }
                    Console.WriteLine(sql);
                    if (!remainToValidate)
                    { 
                        break;
                    }
                    //正常以PigeSize获取
                }
            //}
        }
    }
}
