using System;
using System.Collections.Generic;
using System.Threading;
using System.IO;
using System.Threading.Tasks;
using System.Text;

namespace Work1
{

    class Program
    {
       
        
        static async Task Main(string[] args)
        {
            var exePath = AppDomain.CurrentDomain.BaseDirectory;//Начало работы с файлами
            var path1 = Path.Combine(exePath, "Text\\t1.txt");//путь к файлу1
            var path2 = Path.Combine(exePath, "Text\\t2.txt");//путь к файлу2
            var path3 = Path.Combine(exePath, "Text\\t3.txt");//путь к файлу3

            FileStream fs1 = File.OpenRead(path1);//открываем файл1 для чтения
            byte[] ch1 = new byte[fs1.Length];//создаем массив для записи элементов файла
            await fs1.ReadAsync(ch1, 0, ch1.Length);//записываем элементы в массив
            string txt1 = Encoding.Default.GetString(ch1);// перевод байтов в число
            double num1 = Convert.ToDouble(txt1);//конвертирую в дабл
            Console.WriteLine(num1);//вывод числа
           

            FileStream fs2 = File.OpenRead(path2);//открываем файл2 для чтения
            byte[] ch2 = new byte[fs2.Length];//создаем массив для записи элементов файла
            await fs2.ReadAsync(ch2, 0, ch2.Length);//записываем элементы в массив
            string txt2 = Encoding.Default.GetString(ch2); ;// перевод байтов в число
            double num2 = Convert.ToDouble(txt2);//конвертирую в дабл
            Console.WriteLine(num2);//вывод числа

            FileStream fs3 = File.OpenRead(path3);//открываем файл2 для чтения
            byte[] ch3 = new byte[fs3.Length];//создаем массив для записи элементов файла
            await fs3.ReadAsync(ch3, 0, ch3.Length);//записываем элементы в массив
            string txt3 = Encoding.Default.GetString(ch3); ;// перевод байтов в число
            double num3 = Convert.ToDouble(txt3);//конвертирую в дабл
            Console.WriteLine(num3);//вывод числа







            var arr = new List<Double>();

            arr.Add(num1);//-
            arr.Add(num2);//-
            arr.Add(num3);//добовляем все три элемента в лист


            var start1 = DateTime.Now;//засекаем таймер первого варианта задачи
            var result1 = makeSum(arr);//вызов первой функции сложения 
            var end1 = DateTime.Now;//останавливаем таймер
            var duration1 = (end1 - start1).TotalMilliseconds;//высчитываем полученное время
            Console.WriteLine($"Result: {result1}, Time: {duration1}");//вывод времени


            var start2 = DateTime.Now;//засекаем таймер второго варианта задачи
            var result2 = makeSumWithThreads(arr);//вызов второй функции сложения 
            var end2 = DateTime.Now;//останавливаем таймер
            var duration2 = (end2 - start2).TotalMilliseconds;//высчитываем полученное время
            Console.WriteLine($"Result: {result2}, Time: {duration2}");//вывод времени



            double makeSum(List<Double> arr)//Первая функция сложения
            {
                return makeSumWithRange(arr, 0, arr.Count);//??? складываем все элементы ???
            }

            double makeSumWithThreads(List<Double> arr)//Вторая функция сложения 
            {
                var sum1 = 0.0;//-
                var sum2 = 0.0;//-
                var sum3 = 0.0;//Обнуление элемента
                var index1 = arr.Count / 3;//???-???
                var index2 = index1 * 2;//???-???

                var t1 = new Thread(() => {//1 часть поделенного поиска суммы
                    sum1 = makeSumWithRange(arr, 0, index1);// от 0 элемента до 1 индекса
                });

                var t2 = new Thread(() => {//2 часть поделенного поиска суммы
                    sum2 = makeSumWithRange(arr, index1, index2);// от 1 элемента до 2 индекса
                });

                var t3 = new Thread(() => {//3 часть поделенного поиска суммы
                    sum3 = makeSumWithRange(arr, index2, arr.Count);// от 2 элемента до последнего индекса
                });

                t1.Start();//-
                t2.Start();//-
                t3.Start();//старт 

                t1.Join();
                t2.Join();
                t3.Join();

                return sum1 + sum2 + sum3;//сложение 
            }

            double makeSumWithRange(List<Double> arr, int start, int end)//функция подсчета суммы
            {
                var sum = 0.0;//обнуление 
                for (var i = start; i < end; i++)
                {
                    sum += arr[i];// подсчет суммы
                    Thread.Sleep(1);// ???-???
                }
                return sum;
            }






        }
    }
}

