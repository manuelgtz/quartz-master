using DataAnnotationsExtensions.ClientValidation;

[assembly: WebActivator.PreApplicationStartMethod(typeof(QuartzMaster.Data.App_Start.RegisterClientValidationExtensions), "Start")]
 
namespace QuartzMaster.Data.App_Start {
    public static class RegisterClientValidationExtensions {
        public static void Start() {
            DataAnnotationsModelValidatorProviderExtensions.RegisterValidationExtensions();            
        }
    }
}