using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Reflection;


namespace NG_sistema
{
    class SmartControl
    {

        public static Control LoadSmartControl(string assemblyFile, string typeName)

        {
            Form _userControl;
            Assembly _assembly;
            Type _type;

            try
            {
                _assembly = Assembly.Load(assemblyFile);
                _type = _assembly.GetType(typeName);

                if (_type == null)
                {
                    throw new Exception($"No se encontró el tipo '{typeName}'.");
                }

               
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error durante la carga de la DLL o obtención del tipo: {ex.Message}");
            }


            _assembly = Assembly.Load(assemblyFile);
            _type = _assembly.GetType(typeName);

            Type[] argumentType = { typeof(object[]) };

            if (_type == null)
            {
                throw new Exception("El tipo _type es null. Verifica la carga de la DLL y el nombre del tipo.");
            }

            ConstructorInfo ConstructorSmartControl = _type.GetConstructor(argumentType);

            ConstructorSmartControl = _type.GetConstructor(Type.EmptyTypes);
            if (ConstructorSmartControl == null)
                throw new Exception(_type.FullName + " no tiene un constructor publico sin parametros.");

            _userControl = ConstructorSmartControl.Invoke(null) as Form;
            _userControl.AutoScroll = true;
            return _userControl;

        }


    }
}
