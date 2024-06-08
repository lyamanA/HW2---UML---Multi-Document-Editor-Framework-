DocumentManager documentManager = new DocumentManager();
IDocumentFactory textDocumentFactory = new TextDocumentFactory();

IDocument textDocument = textDocumentFactory.CreateDocument();
textDocument.Name = "New Text Document";
documentManager.CreateDocument(textDocument, "new_document.txt");

documentManager.OpenDocument(textDocument, "document.txt");

documentManager.SaveDocument(textDocument, "document.txt");

documentManager.PrintDocument(textDocument);

documentManager.CloseDocument(textDocument);

public interface IDocument
{
    string Name { get; set; } 
    void Create(string path);
    void Open(string path);
    void Save(string path);
    void Print();
    void Close();
}

public abstract class DocumentBase : IDocument
{
    public string Name { get; set; }

    public abstract void Create(string path);
    public abstract void Open(string path);
    public abstract void Save(string path);
    public abstract void Print();
    public abstract void Close();
}

public class TextDocument : DocumentBase
{
    public override void Create(string path)
    {
        
        Console.WriteLine($"Создан текстовый документ: {path}");
    }

    public override void Open(string path)
    {
       
        Console.WriteLine($"Открыт текстовый документ: {path}");
    }

    public override void Save(string path)
    {
       
        Console.WriteLine($"Сохранен текстовый документ: {path}");
    }

    public override void Print()
    {
        
        Console.WriteLine("Печать текстового документа");
    }

    public override void Close()
    {
        Console.WriteLine("Закрыт текстовый документ");
    }
}

public class DocumentManager
{
    private List<IDocument> documents = new List<IDocument>();

    public void CreateDocument(IDocument document, string path)
    {
        document.Create(path);
        documents.Add(document);
    }

    public void OpenDocument(IDocument document, string path)
    {
        document.Open(path);
        documents.Add(document);
    }

    public void SaveDocument(IDocument document, string path)
    {
        document.Save(path);
    }

    public void PrintDocument(IDocument document)
    {
        document.Print();
    }

    public void CloseDocument(IDocument document)
    {
        document.Close();
        documents.Remove(document);
    }

    public void SaveDocumentAs(IDocument document, string newPath)
    {
        document.Save(newPath);
    }
}

public interface IDocumentFactory
{
    IDocument CreateDocument();
}

public class TextDocumentFactory : IDocumentFactory
{
    public IDocument CreateDocument()
    {
        return new TextDocument();
    }
}
