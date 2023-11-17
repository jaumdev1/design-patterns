#include <iostream>
#include <string>

class BasePDF {
public:
    std::string Type;
    std::string BackgroundColor;
    std::string TextColor;
    int FontSize;
    std::string TypeFont;
    std::string Name;

    BasePDF(std::string name, std::string type, std::string backgroundColor, std::string textColor, int fontSize, std::string typefont)
        : Name(name), Type(type), BackgroundColor(backgroundColor), TextColor(textColor), FontSize(fontSize), TypeFont(typefont) {}

    void Display() {
        std::cout << "PDF Details:" << std::endl;
        std::cout << "Name: " << Name << std::endl;
        std::cout << "Type: " << Type << std::endl;
        std::cout << "BackgroundColor: " << BackgroundColor << std::endl;
        std::cout << "TextColor: " << TextColor << std::endl;
        std::cout << "FontSize: " << FontSize << std::endl;
        std::cout << "TypeFont: " << TypeFont << std::endl;
    }
};

class IPDFBuilder {
public:
    virtual void BuildType() = 0;
    virtual void BuildBackgroundColor() = 0;
    virtual void BuildTextColor() = 0;
    virtual void BuildFontSize() = 0;
    virtual void BuildTypeFont() = 0;
    virtual BasePDF GetPDF() = 0;
};

class PDFInvoiceBuilder : public IPDFBuilder {
private:
    BasePDF pdf;

public:
    PDFInvoiceBuilder(std::string name, std::string type, std::string backgroundColor, std::string textColor, int fontSize, std::string typefont)
        : pdf(name, type, backgroundColor, textColor, fontSize, typefont) {}

   void BuildType() override {
        pdf.Type = "Invoice";
    }

    void BuildBackgroundColor() override {
       if(pdf.TextColor =="#FFFFFF")
        pdf.BackgroundColor = "White";
    }

    void BuildTextColor() override {
        if(pdf.TextColor =="#000000")
        pdf.TextColor = "Black";
    }

    void BuildFontSize() override {
        pdf.FontSize = 12;
    }

    void BuildTypeFont() override {
        pdf.TypeFont = "Arial";
    }

    BasePDF GetPDF() override {
        return pdf;
    }
};

class PDFDirector {
public:
    BasePDF ConstructPDF(IPDFBuilder& builder) {
        builder.BuildType();
        builder.BuildBackgroundColor();
        builder.BuildTextColor();
        builder.BuildFontSize();
        builder.BuildTypeFont();
        return builder.GetPDF();
    }
};

int main() {
    IPDFBuilder* builder = new PDFInvoiceBuilder("MyPDF", "Type1", "#FFFFFF", "#000000", 12, "Arial");
    PDFDirector director;
    BasePDF _pdf = director.ConstructPDF(*builder);
    _pdf.Display();

    delete builder; 
    return 0;
}