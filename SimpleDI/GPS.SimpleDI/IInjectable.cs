using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPS.SimpleDI
{
    /// <summary>
    /// Defines the interface for an injectable type
    /// </summary>
    public interface IInjectable
    {
        /// <summary>
        /// Namespace path to type
        /// </summary>
        string TypeNamespace { get; set; }

        /// <summary>
        /// Name of type
        /// </summary>
        string TypeName { get; set; }

        /// <summary>
        /// List of constructors with a list of Parameters for each.  
        /// </summary>
        List<List<Parameter>> Constructors { get; set; }
        
        /// <summary>
        /// List of Method objects defining methods.
        /// </summary>
        List<Method> Methods { get; set; }

        object MakeObject(List<Parameter> parameters);

        object MakeObject();
    }

    /// <summary>
    /// Class to hold the Method information
    /// </summary>
    public class Method
    {
        public string Name;
        public string ReturnType;
        public List<Parameter> Parameters;
    }

    /// <summary>
    /// Class to hold the Parameter information
    /// </summary>
    public class Parameter
    {
        public string Name;
        public string TypeNamespace;
        public string TypeName;
        public object Value;
    }
}
