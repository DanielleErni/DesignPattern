using System;

namespace Prototype
{
    // Prototype interface
    public interface IDocument : ICloneable
    {
        string Title { get; set; }
        string Content { get; set; }
        void ShowDocument();
    }

    // Concrete Prototype for Report
    public class Report : IDocument
    {
        public string Title { get; set; }
        public string Content { get; set; }

        public Report(string title, string content)
        {
            Title = title;
            Content = content;
        }

        // Clone method to create a copy of the current object
        public object Clone()
        {
            return new Report(Title, Content);
        }

        public void ShowDocument()
        {
            Console.WriteLine($"Report Title: {Title}");
            Console.WriteLine($"Report Content: {Content}");
        }
    }

    // Concrete Prototype for Invoice
    public class Invoice : IDocument
    {
        public string Title { get; set; }
        public string Content { get; set; }

        public Invoice(string title, string content)
        {
            Title = title;
            Content = content;
        }

        // Clone method to create a copy of the current object
        public object Clone()
        {
            return new Invoice(Title, Content);
        }

        public void ShowDocument()
        {
            Console.WriteLine($"Invoice Title: {Title}");
            Console.WriteLine($"Invoice Content: {Content}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Create an instance of Report
            IDocument originalReport = new Report("Annual Report", "This is the content of the annual report.");
            Console.WriteLine("Original Report:");
            originalReport.ShowDocument();

            // Clone the original report
            IDocument clonedReport = (IDocument)originalReport.Clone();
            Console.WriteLine("\nCloned Report:");
            clonedReport.ShowDocument();

            // Modify the cloned report
            clonedReport.Title = "Modified Annual Report";
            clonedReport.Content = "This is the modified content of the annual report.";
            Console.WriteLine("\nModified Cloned Report:");
            clonedReport.ShowDocument();

            // Original report remains unchanged
            Console.WriteLine("\nOriginal Report after modification:");
            originalReport.ShowDocument();

            // Create an instance of Invoice
            IDocument originalInvoice = new Invoice("Invoice #12345", "This is the content of the invoice.");
            Console.WriteLine("\nOriginal Invoice:");
            originalInvoice.ShowDocument();

            // Clone the original invoice
            IDocument clonedInvoice = (IDocument)originalInvoice.Clone();
            Console.WriteLine("\nCloned Invoice:");
            clonedInvoice.ShowDocument();

            // Modify the cloned invoice
            clonedInvoice.Title = "Modified Invoice #12345";
            clonedInvoice.Content = "This is the modified content of the invoice.";
            Console.WriteLine("\nModified Cloned Invoice:");
            clonedInvoice.ShowDocument();

            // Original invoice remains unchanged
            Console.WriteLine("\nOriginal Invoice after modification:");
            originalInvoice.ShowDocument();
        }
    }
}