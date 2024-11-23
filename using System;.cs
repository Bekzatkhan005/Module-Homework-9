using System;

namespace ReportDecoratorPattern
{
    // Интерфейс для отчетов
    public interface IReport
    {
        // Метод для генерации данных отчета
        string Generate();
    }

    // Класс отчета по продажам, который реализует IReport
    public class SalesReport : IReport
    {
        public string Generate()
        {
            // Возвращает данные отчета по продажам
            return "Sales Report Data";
        }
    }

    // Класс отчета по пользователям, который реализует IReport
    public class UserReport : IReport
    {
        public string Generate()
        {
            // Возвращает данные отчета по пользователям
            return "User Report Data";
        }
    }

    // Абстрактный класс декоратора для отчетов
    public abstract class ReportDecorator : IReport
    {
        // Ссылка на исходный отчет, к которому добавляются новые функции
        protected IReport Report;

        // Конструктор принимает отчет для декорирования
        protected ReportDecorator(IReport report)
        {
            Report = report;
        }

        public virtual string Generate()
        {
            // Вызывает метод Generate() базового отчета
            return Report.Generate();
        }
    }

    // Декоратор для фильтрации отчета по дате
    public class DateFilterDecorator : ReportDecorator
    {
        public DateFilterDecorator(IReport report) : base(report) { }

        public override string Generate()
        {
            // Добавляет текст "with Date Filter" к данным отчета
            return base.Generate() + " with Date Filter";
        }
    }

    // Декоратор для сортировки данных отчета
    public class SortingDecorator : ReportDecorator
    {
        public SortingDecorator(IReport report) : base(report) { }

        public override string Generate()
        {
            // Добавляет текст "with Sorting" к данным отчета
            return base.Generate() + " with Sorting";
        }
    }

    // Декоратор для экспорта отчета в формат CSV
    public class CsvExportDecorator : ReportDecorator
    {
        public CsvExportDecorator(IReport report) : base(report) { }

        public override string Generate()
        {
            // Добавляет текст "Exported as CSV" к данным отчета
            return base.Generate() + " Exported as CSV";
        }
    }

    // Декоратор для экспорта отчета в формат PDF
    public class PdfExportDecorator : ReportDecorator
    {
        public PdfExportDecorator(IReport report) : base(report) { }

        public override string Generate()
        {
            // Добавляет текст "Exported as PDF" к данным отчета
            return base.Generate() + " Exported as PDF";
        }
    }

    // Основной класс с клиентским кодом
    public class Program
    {
        public static void Main(string[] args)
        {
            // Создаем отчет по продажам
            IReport report = new SalesReport();

            // Последовательно добавляем декораторы: фильтр по дате, сортировку и экспорт в PDF
            report = new DateFilterDecorator(report);
            report = new SortingDecorator(report);
            report = new PdfExportDecorator(report);

            // Выводим результат, включающий все примененные декорации
            Console.WriteLine(report.Generate());
        }
    }
}
