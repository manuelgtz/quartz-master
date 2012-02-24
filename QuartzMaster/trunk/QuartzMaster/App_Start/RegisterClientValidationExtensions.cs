using DataAnnotationsExtensions.ClientValidation;

[assembly: WebActivator.PreApplicationStartMethod(typeof(QuartzMaster.App_Start.RegisterClientValidationExtensions), "Start")]
 
namespace QuartzMaster.App_Start {


    public static class RegisterClientValidationExtensions {
        public static void Start() {
            DataAnnotationsModelValidatorProviderExtensions.RegisterValidationExtensions();
        }
    }
}