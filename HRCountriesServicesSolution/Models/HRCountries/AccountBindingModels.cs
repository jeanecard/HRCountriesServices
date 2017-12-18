using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace HRCountriesServicesSolution.Models
{
    // Modèles utilisés comme paramètres des actions AccountController.
    /// <summary>
    /// 
    /// </summary>
    public class AddExternalLoginBindingModel
    {
        /// <summary>
        /// 
        /// </summary>
        [Required]
        [Display(Name = "Jeton d’accès externe")]
        public string ExternalAccessToken { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
    public class ChangePasswordBindingModel
    {
        /// <summary>
        /// 
        /// </summary>
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Mot de passe actuel")]
        public string OldPassword { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Required]
        [StringLength(100, ErrorMessage = "La chaîne {0} doit comporter au moins {2} caractères.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Nouveau mot de passe")]
        public string NewPassword { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataType(DataType.Password)]
        [Display(Name = "Confirmer le nouveau mot de passe")]
        [Compare("NewPassword", ErrorMessage = "Le nouveau mot de passe et le mot de passe de confirmation ne correspondent pas.")]
        public string ConfirmPassword { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
    public class RegisterBindingModel
    {
        /// <summary>
        /// 
        /// </summary>
        [Required]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Required]
        [StringLength(100, ErrorMessage = "La chaîne {0} doit comporter au moins {2} caractères.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Mot de passe")]
        public string Password { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataType(DataType.Password)]
        [Display(Name = "Confirmer le mot de passe ")]
        [Compare("Password", ErrorMessage = "Le mot de passe et le mot de passe de confirmation ne correspondent pas.")]
        public string ConfirmPassword { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
    public class RegisterExternalBindingModel
    {
        /// <summary>
        /// 
        /// </summary>
        [Required]
        [Display(Name = "E-mail")]
        public string Email { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
    public class RemoveLoginBindingModel
    {
        /// <summary>
        /// 
        /// </summary>
        [Required]
        [Display(Name = "Fournisseur de connexion")]
        public string LoginProvider { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Required]
        [Display(Name = "Clé du fournisseur")]
        public string ProviderKey { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
    public class SetPasswordBindingModel
    {
        /// <summary>
        /// 
        /// </summary>
        [Required]
        [StringLength(100, ErrorMessage = "La chaîne {0} doit comporter au moins {2} caractères.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Nouveau mot de passe")]
        public string NewPassword { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataType(DataType.Password)]
        [Display(Name = "Confirmer le nouveau mot de passe")]
        [Compare("NewPassword", ErrorMessage = "Le nouveau mot de passe et le mot de passe de confirmation ne correspondent pas.")]
        public string ConfirmPassword { get; set; }
    }
}
