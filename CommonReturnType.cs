namespace AzureFunctionsApp
{
    internal class CommonReturnType
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Employees { get; set; }
        public string IsCheck { get; set; }

    }

    public class Employees
    {
        public string MethodName { get; set; }
        public object[] Entities { get; set; }
        public bool IsActive { get; set; }
        public string text { get; set; }

    }
}