using Microsoft.EntityFrameworkCore.Migrations;

namespace QuizNet.DataAccess.Migrations
{
    public partial class SeedDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"--1 pytanie
            INSERT INTO[dbo].[Questions]([Text],[CreationTime]) VALUES('Jakiej metody HTTP używamy aby pobrać dane z serwera?', GETDATE())
            DECLARE @questionId AS int = SCOPE_IDENTITY()
            INSERT INTO[dbo].[Answers]
                    ([Text],[IsCorrect],[QuestionId]) VALUES('PUT',0, @questionId)
            INSERT INTO[dbo].[Answers]
                    ([Text],[IsCorrect],[QuestionId]) VALUES('POST',0, @questionId)
            INSERT INTO[dbo].[Answers]
                    ([Text],[IsCorrect],[QuestionId]) VALUES('GET',1, @questionId)
            INSERT INTO[dbo].[Answers]
                    ([Text],[IsCorrect],[QuestionId]) VALUES('DELETE',0, @questionId)
            --2 pytanie
            INSERT INTO[dbo].[Questions]
                    ([Text],[CreationTime]) VALUES('Na jakim systemie operacyjnym możemy uruchomić aplikację napisaną w .NET Core?', GETDATE())
            SET @questionId = SCOPE_IDENTITY()
            INSERT INTO[dbo].[Answers]
                    ([Text],[IsCorrect],[QuestionId]) VALUES('Tylko Linux',0, @questionId)
            INSERT INTO[dbo].[Answers]
                    ([Text],[IsCorrect],[QuestionId]) VALUES('Tylko MAC OS',0, @questionId)
            INSERT INTO[dbo].[Answers]
                    ([Text],[IsCorrect],[QuestionId]) VALUES('Tylko Windows',0, @questionId)
            INSERT INTO[dbo].[Answers]
                    ([Text],[IsCorrect],[QuestionId]) VALUES('Jest cross platformowy',1, @questionId)
            --3 pytanie
            INSERT INTO[dbo].[Questions]
                    ([Text],[CreationTime]) VALUES('Które zdanie najlepiej opisuje kontroler', GETDATE())
            SET @questionId = SCOPE_IDENTITY()
            INSERT INTO[dbo].[Answers]
                    ([Text],[IsCorrect],[QuestionId]) VALUES('Wykonuje operacje przeszukiwania i modyfikacji bazy danych',0, @questionId)
            INSERT INTO[dbo].[Answers]
                    ([Text],[IsCorrect],[QuestionId]) VALUES('Realizuje algorytmy sztucznej inteligencji',0, @questionId)
            INSERT INTO[dbo].[Answers]
                    ([Text],[IsCorrect],[QuestionId]) VALUES('Odpowiada na zapytania wysyłane przez klienta',1, @questionId)
            INSERT INTO[dbo].[Answers]
                    ([Text],[IsCorrect],[QuestionId]) VALUES('Tworzy instancje obiektów zainicjalizowane w kontenerze DI',0, @questionId)
            --4 pytanie
            INSERT INTO[dbo].[Questions]
                    ([Text],[CreationTime]) VALUES('Która metoda służy do sortowania kolekcji z wykorzystaniem LINQ', GETDATE())
            SET @questionId = SCOPE_IDENTITY()
            INSERT INTO[dbo].[Answers]
                    ([Text],[IsCorrect],[QuestionId]) VALUES('First',0, @questionId)
            INSERT INTO[dbo].[Answers]
                    ([Text],[IsCorrect],[QuestionId]) VALUES('Single',0, @questionId)
            INSERT INTO[dbo].[Answers]
                    ([Text],[IsCorrect],[QuestionId]) VALUES('Sort',0, @questionId)
            INSERT INTO[dbo].[Answers]
                    ([Text],[IsCorrect],[QuestionId]) VALUES('OrderBy',1, @questionId)
            --5 pytanie
            INSERT INTO[dbo].[Questions]
                    ([Text],[CreationTime]) VALUES('Co robi metoda FirstOrDefault', GETDATE())
            SET @questionId = SCOPE_IDENTITY()
            INSERT INTO[dbo].[Answers]
                    ([Text],[IsCorrect],[QuestionId]) VALUES('Zwraca ostatni element kolekcji',0, @questionId)
            INSERT INTO[dbo].[Answers]
                    ([Text],[IsCorrect],[QuestionId]) VALUES('Zwraca pierwszy element kolekcji spełniający warunek jeśli nie znajdzie rzuca wyjątkiem',0, @questionId)
            INSERT INTO[dbo].[Answers]
                    ([Text],[IsCorrect],[QuestionId]) VALUES('Zwraca pierwszy element kolekcji spełniający warunek jeśli nie znajdzie zwraca nulla',1, @questionId)
            INSERT INTO[dbo].[Answers]
                    ([Text],[IsCorrect],[QuestionId]) VALUES('Nic nie robi',0, @questionId)
            --6 pytanie
            INSERT INTO[dbo].[Questions]
                    ([Text],[CreationTime]) VALUES('Co to jest EntityFramework', GETDATE())
            SET @questionId = SCOPE_IDENTITY()
            INSERT INTO[dbo].[Answers]
                    ([Text],[IsCorrect],[QuestionId]) VALUES('Rodzaj kolekcji',0, @questionId)
            INSERT INTO[dbo].[Answers]
                    ([Text],[IsCorrect],[QuestionId]) VALUES('ORM',1, @questionId)
            INSERT INTO[dbo].[Answers]
                    ([Text],[IsCorrect],[QuestionId]) VALUES('Rodzaj aplikacji',0, @questionId)
            INSERT INTO[dbo].[Answers]
                    ([Text],[IsCorrect],[QuestionId]) VALUES('System ERP',0, @questionId)
            --7 pytanie
            INSERT INTO[dbo].[Questions]
                    ([Text],[CreationTime]) VALUES('Który język nie należy do platformy .NET', GETDATE())
            SET @questionId = SCOPE_IDENTITY()
            INSERT INTO[dbo].[Answers]
                    ([Text],[IsCorrect],[QuestionId]) VALUES('C#',0, @questionId)
            INSERT INTO[dbo].[Answers]
                    ([Text],[IsCorrect],[QuestionId]) VALUES('D#',1, @questionId)
            INSERT INTO[dbo].[Answers]
                    ([Text],[IsCorrect],[QuestionId]) VALUES('F#',0, @questionId)
            INSERT INTO[dbo].[Answers]
                    ([Text],[IsCorrect],[QuestionId]) VALUES('VB',0, @questionId)
            --8 pytanie
            INSERT INTO[dbo].[Questions]
                    ([Text],[CreationTime]) VALUES('Które framework nie jest powiązane z .NET', GETDATE())
            SET @questionId = SCOPE_IDENTITY()
            INSERT INTO[dbo].[Answers]
                    ([Text],[IsCorrect],[QuestionId]) VALUES('WPF',0, @questionId)
            INSERT INTO[dbo].[Answers]
                    ([Text],[IsCorrect],[QuestionId]) VALUES('ASP.NET',0, @questionId)
            INSERT INTO[dbo].[Answers]
                    ([Text],[IsCorrect],[QuestionId]) VALUES('EntityFramework',0, @questionId)
            INSERT INTO[dbo].[Answers] ([Text],[IsCorrect],[QuestionId]) VALUES('Swing',1, @questionId)");


        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
