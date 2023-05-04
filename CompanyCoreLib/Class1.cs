using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyCoreLib
{
    public class DateTimeWithCounter
    {
        public DateTime DateTimeProp;
        public int Counter;
    }
    public class Analytics
    {
        public List<DateTime> PopularMonths(List<DateTime> dates)
        {
            // объавляем временный массив объектов "ДатаСоСчетчиком"
            var DateTimeWithCounterList = new List<DateTimeWithCounter>();
            // тут сразу можно сделать проверку на длину исходного
            // перебираем исходный массив
            foreach (DateTime date in dates)
            {
                // вычисляем начало месяца для даты текущего элемента
                var DateMonthStart = new DateTime(date.Year, date.Month, 1, 0, 0, 0);
                // ищем эту дату во вспомогательном массиве
                var index = DateTimeWithCounterList.FindIndex(item => item.DateTimeProp == DateMonthStart);
                // index содержит позицию найденного элемента в массиве или -1, если не найдно
                if (index == -1)
                {
                    // такой даты нет - добавляю
                    DateTimeWithCounterList.
                        Add(
                            new DateTimeWithCounter
                            {
                                DateTimeProp = DateMonthStart,
                                Counter = 1
                            }
                        );
                }
                else
                {
                    // дата есть - увеличиваем счетчик
                    DateTimeWithCounterList[index].Counter++;
                }
            }
            // вспомогательный массив сортируем по убыванию по счетчику(самые популярные попадают в начало списка)
            // ЗАТЕМ сортируем ПО дате по возрастанию
            // выбираем из объекта только дату, счетчик нам уже не нужен
            return DateTimeWithCounterList
                .OrderByDescending(item => item.Counter)
                .ThenBy(item => item.DateTimeProp)
                .Select(item => item.DateTimeProp)
                .ToList();
        }
    }
}
