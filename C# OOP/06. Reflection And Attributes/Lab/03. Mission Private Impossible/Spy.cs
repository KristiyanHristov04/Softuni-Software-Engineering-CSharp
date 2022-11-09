using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Stealer
{
    public class Spy
    {
        public string StealFieldInfo(string classToInvestigate, params string[] fieldsToInvestigate)
        {
            Type classType = Type.GetType(classToInvestigate);

            FieldInfo[] classFields = classType.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            StringBuilder sb = new StringBuilder();
            Object classInstance = Activator.CreateInstance(classType, new object[] { });
            sb.AppendLine($"Class under investigation: {classType.Name}");

            foreach (FieldInfo field in classFields)
            {
                sb.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
            }

            return sb.ToString().TrimEnd();
        }
        public string AnalyzeAccessModifiers(string investigatedClass)
        {
            StringBuilder sb = new StringBuilder();
            Type classType = Type.GetType(investigatedClass);

            FieldInfo[] classFields = classType.GetFields(BindingFlags.Instance | BindingFlags.Public);
            foreach (var field in classFields)
            {
                sb.AppendLine($"{field.Name} must be private!");
            }

            MethodInfo[] classPublicMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.Public);
            foreach (var publicMethod in classPublicMethods)
            {
                sb.AppendLine($"{publicMethod.Name} have to be private!");
            }

            MethodInfo[] classPrivateMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);
            foreach (var privateMethod in classPrivateMethods)
            {
                sb.AppendLine($"{privateMethod.Name} have to be public!");
            }

            return sb.ToString().TrimEnd();
        }
        public string RevealPrivateMethods(string className)
        {
            Type classType = Type.GetType(className);
            StringBuilder sb = new StringBuilder(); 
            MethodInfo[] privateMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

            sb.AppendLine($"All Private Methods of Class: {className}");
            sb.AppendLine($"Base Class: {classType.BaseType.Name}");

            foreach (var privateMethod in privateMethods)
            {
                sb.AppendLine(privateMethod.Name);
            }

            return sb.ToString().TrimEnd();
        }
    }
}
