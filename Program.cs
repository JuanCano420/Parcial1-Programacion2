// TRABAJO INDIVIDUAL
// JUAN FERNANDO CANO AGUILAR
// UNIVERSIDAD LIBRE

namespace SolucionTaller
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> DatosMemoria = new();
            while (true)
            {
                Console.Write("Escriba la expresión:");
                string input = Console.ReadLine();

                if (input == "SALIR")
                {
                    break;
                }
                else if (input == "MEMORIA")
                {
                    for (int i = 0; i < DatosMemoria.Count; i++)
                    {
                        Console.WriteLine("[" + i + "] " + DatosMemoria[i]);
                    }
                }
                else if (input.StartsWith("[") && input.EndsWith("]"))
                {
                    string numeroTexto = input.Trim('[', ']');
                    if (int.TryParse(numeroTexto, out int numeroReal) && numeroReal >= 0 && numeroReal < DatosMemoria.Count)
                    {
                        string expresion = DatosMemoria[numeroReal];

                        // Evaluar la expresión almacenada
                        List<double> numeros = new();
                        List<char> operadores = new();
                        string numero = "";

                        foreach (char dato in expresion)
                        {
                            if (char.IsDigit(dato) || dato == '.')
                            {
                                numero += dato;
                            }
                            else if (dato == '+' || dato == '-' || dato == '*' || dato == '/')
                            {
                                if (numero != "")
                                {
                                    numeros.Add(double.Parse(numero));
                                    numero = "";
                                }
                                operadores.Add(dato);
                            }
                        }

                        if (numero != "")
                        {
                            numeros.Add(double.Parse(numero));
                        }

                        // Resolver la multiplicación y división
                        for (int i = 0; i < operadores.Count; i++)
                        {
                            double resultado;
                            if (operadores[i] == '*')
                            {
                                resultado = numeros[i] * numeros[i + 1];
                            }
                            else if (operadores[i] == '/')
                            {
                                resultado = numeros[i] / numeros[i + 1];
                            }
                            else
                            {
                                continue;
                            }
                            numeros[i] = resultado;
                            numeros.RemoveAt(i + 1);
                            operadores.RemoveAt(i);
                            i--;
                        }

                        double resultadoFinal = numeros[0];

                        // Resolver la suma y resta
                        for (int i = 0; i < operadores.Count; i++)
                        {
                            if (operadores[i] == '+')
                            {
                                resultadoFinal += numeros[i + 1];
                            }
                            else if (operadores[i] == '-')
                            {
                                resultadoFinal -= numeros[i + 1];
                            }
                        }

                        Console.WriteLine("Resultado: " + resultadoFinal);
                    }
                    else
                    {
                        Console.WriteLine("ERROR: POSICIÓN DE MEMORIA NO TIENE EXPRESIÓN");
                    }
                }
                else
                {
                    DatosMemoria.Add(input);
                    List<double> numeros = new();
                    List<char> operadores = new();
                    string numero = "";

                    foreach (char dato in input)
                    {
                        if (char.IsDigit(dato) || dato == '.')
                        {
                            numero += dato;
                        }
                        else if (dato == '+' || dato == '-' || dato == '*' || dato == '/')
                        {
                            if (numero != "")
                            {
                                numeros.Add(double.Parse(numero));
                                numero = "";
                            }
                            operadores.Add(dato);
                        }
                    }

                    if (numero != "")
                    {
                        numeros.Add(double.Parse(numero));
                    }

                    // Resolver la multiplicación y división
                    for (int i = 0; i < operadores.Count; i++)
                    {
                        double resultados;

                        if (operadores[i] == '*')
                        {
                            resultados = numeros[i] * numeros[i + 1];
                        }
                        else if (operadores[i] == '/')
                        {
                            resultados = numeros[i] / numeros[i + 1];
                        }
                        else
                        {
                            continue;
                        }
                        numeros[i] = resultados;
                        numeros.RemoveAt(i + 1);
                        operadores.RemoveAt(i);
                        i--;
                    }


                    double resultado = numeros[0];

                    // Resolver la suma y resto

                    for (int i = 0; i < operadores.Count; i++)
                    {
                        if (operadores[i] == '+')
                        {
                            resultado += numeros[i + 1];
                        }
                        else if (operadores[i] == '-')
                        {
                            resultado -= numeros[i + 1];
                        }
                    }
                    Console.WriteLine("Resultado:" + resultado);
                }
            }
        }
    }
}
