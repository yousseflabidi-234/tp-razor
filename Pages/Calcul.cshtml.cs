using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TPIntroRazor.Pages
{
    public class CalculModel : PageModel
    {
        private const int AnneeMin = 1900;

        [BindProperty]
        [Display(Name = "Votre nom")]
        [Required(ErrorMessage = "Le nom est obligatoire.")]
        [StringLength(50, ErrorMessage = "Le nom ne doit pas dépasser 50 caractères.")]
        public string Nom { get; set; } = string.Empty;

        [BindProperty]
        [Display(Name = "Année de naissance")]
        [Required(ErrorMessage = "L'année de naissance est obligatoire.")]
        public int? AnneeNaissance { get; set; }

        public string Message { get; set; } = string.Empty;
        public bool EstValide { get; set; }
        public int AnneeCentenaire { get; set; }
        public bool CentenaireDejaAtteint { get; set; }
        public string Decennie { get; set; } = string.Empty;

        public void OnGet() { }

        public void OnPost()
        {
            int anneeActuelle = DateTime.Now.Year;

            // Validation de la plage (dynamique, sans année codée en dur)
            if (AnneeNaissance.HasValue &&
                (AnneeNaissance < AnneeMin || AnneeNaissance > anneeActuelle))
            {
                ModelState.AddModelError(nameof(AnneeNaissance),
                    $"Entrez une année valide entre {AnneeMin} et {anneeActuelle}.");
            }

            if (!ModelState.IsValid)
            {
                Message = "Veuillez corriger les erreurs du formulaire.";
                EstValide = false;
                return;
            }

            int annee = AnneeNaissance!.Value;
            int age = anneeActuelle - annee;

            if (age > 120)
            {
                Message = "Année de naissance invalide !";
                EstValide = false;
                return;
            }

            Message = $"Bonjour {Nom}, vous avez environ {age} ans cette année !";
            EstValide = true;
            AnneeCentenaire = annee + 100;
            CentenaireDejaAtteint = AnneeCentenaire <= anneeActuelle;
            Decennie = $"années {(annee / 10) * 10}";
        }
    }
}