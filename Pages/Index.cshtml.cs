using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TPIntroRazor.Pages
{
    public class IndexModel : PageModel
    {
        public string MessageAccueil { get; } = "Bienvenue sur mon application Razor Pages !";

        public IReadOnlyList<string> Modules { get; } = new List<string>
        {
            "Introduction à ASP.NET Core",
            "Syntaxe Razor",
            "Formulaires et BindProperty",
            "Traitement HTTP GET/POST"
        };

        public IReadOnlyList<string> Prerequis { get; } = new List<string>
        {
            "Notions de base en C#",
            "Notions de base en HTML/CSS",
            "SDK .NET 8.0 ou supérieur installé"
        };

        public string MessageAccueilDynamique { get; private set; } = string.Empty;
        public DateTime DateServeur { get; private set; }

        public void OnGet()
        {
            // Un seul appel pour que le message et la date soient cohérents
            DateServeur = DateTime.Now;

            MessageAccueilDynamique = DateServeur.Hour switch
            {
                < 5 => "Il est tard ! N'oubliez pas de vous reposer.",
                < 12 => "Bonjour ! Prêt(e) pour une session productive ?",
                < 18 => "Bon après-midi ! Continuons ce TP.",
                _ => "Bonsoir ! Encore motivé(e) pour coder ?"
            };
        }
    }
}