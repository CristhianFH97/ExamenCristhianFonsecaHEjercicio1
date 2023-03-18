using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenCristhianFonsecaHEjercicio1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int tipoEmpleado =0, cantidadOperarios = 0, cantidadTecnicos = 0, cantidadProfesionales = 0;
            double salarioHora, horasTrabajadas, salarioOrdinario, aumento, salarioBruto, deducciones, salarioNeto;
            double acumuladoNetoOperarios = 0, acumuladoNetoTecnicos = 0, acumuladoNetoProfesionales = 0;
            string cedula, nombreEmpleado, continuar, nombreTipoEmpleado;
            nombreTipoEmpleado = "";
            do
            {
                Console.WriteLine("Ingrese los siguientes datos del empleado:\n");
                Console.Write("Cedula: ");
                cedula = Console.ReadLine();
                Console.Write("Nombre: ");
                nombreEmpleado = Console.ReadLine();
                
                while (tipoEmpleado < 1 || tipoEmpleado > 3)
                {
                    Console.Write("\nTipo de empleado:\n 1: Operario\n 2: Tecnico\n 3: Profesional\n->");
                    if (int.TryParse(Console.ReadLine(), out tipoEmpleado) == false)
                    {
                        tipoEmpleado = 0;
                    }
                    if (tipoEmpleado < 1 || tipoEmpleado > 3)
                    {
                        Console.WriteLine("Error: debes ingresar 1, 2 o 3.");
                    }
                }

                Console.Write("\nSalario por hora: ");
                salarioHora = double.Parse(Console.ReadLine());
                Console.Write("Horas trabajadas: ");
                horasTrabajadas = double.Parse(Console.ReadLine());

                salarioOrdinario = salarioHora * horasTrabajadas;

                switch (tipoEmpleado)
                {
                    case 1: // Operario
                        nombreTipoEmpleado = "Operario";
                        aumento = salarioOrdinario * 0.15;
                        break;
                    case 2: // Técnico
                        nombreTipoEmpleado = "Tecnico";
                        aumento = salarioOrdinario * 0.10;
                        break;
                    case 3: // Profesional
                        nombreTipoEmpleado = "Profesional";
                        aumento = salarioOrdinario * 0.05;
                        break;
                    default:
                        aumento = 0;
                        break;
                }

                salarioBruto = salarioOrdinario + aumento;
                deducciones = salarioBruto * 0.0917;
                salarioNeto = salarioBruto - deducciones;

                Console.WriteLine("\n----------------Resultados del empleado------------");
                Console.WriteLine(" - Cédula: {0} - Nombre: {1}", cedula, nombreEmpleado);
                Console.WriteLine(" - Tipo de empleado: {0}", nombreTipoEmpleado);
                Console.WriteLine(" - Salario por hora: {0:F2}", salarioHora);
                Console.WriteLine(" - Horas trabajadas: {0}", horasTrabajadas);
                Console.WriteLine(" - Salario ordinario: {0:F2}", salarioOrdinario);
                Console.WriteLine(" - Aumento: {0:F2}", aumento);
                Console.WriteLine(" - Salario bruto: {0:F2}", salarioBruto);
                Console.WriteLine(" - Deducción CCSS (9.17%): {0:F2}", deducciones);
                Console.WriteLine(" - Salario neto: {0:F2}", salarioNeto);
                Console.WriteLine("---------------------------------------------------\n");
                

                // Actualizar estadísticas
                switch (tipoEmpleado)
                {
                    case 1: // Operario
                        cantidadOperarios++;
                        acumuladoNetoOperarios += salarioNeto;
                        break;
                    case 2: // Técnico
                        cantidadTecnicos++;
                        acumuladoNetoTecnicos += salarioNeto;
                        break;
                    case 3: // Profesional
                        cantidadProfesionales++;
                        acumuladoNetoProfesionales += salarioNeto;
                        break;
                    default:
                        break;
                }

                Console.Write("¿Desea registrar otro empleado? (s/n): ");
                continuar = Console.ReadLine().ToLower(); // Si la respuesta es "s", volver al inicio del ciclo
                tipoEmpleado = 0;
                Console.WriteLine("\n---------------------------------------------------\n");
            } while (continuar == "s"); // Si la respuesta es "n", mostrar estadísticas y salir del ciclo

            // Calcular estadísticas finales
            Console.WriteLine("------------------Estadisticas Finales-------------");
            

            if (cantidadOperarios > 0)
            {
                double promedioNetoOperarios = acumuladoNetoOperarios / cantidadOperarios;
                Console.WriteLine("\n----- Operarios:\n");
                Console.WriteLine("- Cantidad de empleados operarios: {0}", cantidadOperarios);
                Console.WriteLine("- Acumulado Salario Neto para operarios: {0:F2}", acumuladoNetoOperarios);
                Console.WriteLine("- Promedio Salario Neto para operarios: {0:F2}", promedioNetoOperarios);
            }

            if (cantidadTecnicos > 0)
            {
                double promedioNetoTecnicos = acumuladoNetoTecnicos / cantidadTecnicos;
                Console.WriteLine("\n----- Tecnicos:\n");
                Console.WriteLine("- Cantidad de empleados tecnicos: {0}", cantidadTecnicos);
                Console.WriteLine("- Acumulado Salario Neto para tecnicos: {0:F2}", acumuladoNetoTecnicos);
                Console.WriteLine("- Promedio Salario Neto para tecnicos: {0:F2}", promedioNetoTecnicos);
            }

            if (cantidadProfesionales > 0)
            {
                double promedioNetoProfesionales = acumuladoNetoProfesionales / cantidadProfesionales;
                Console.WriteLine("\n----- Profesionales:\n");
                Console.WriteLine("- Cantidad de empleados profesionales: {0}", cantidadProfesionales);
                Console.WriteLine("- Acumulado Salario Neto para profesionales: {0:F2}", acumuladoNetoProfesionales);
                Console.WriteLine("- Promedio Salario Neto para profesionales: {0:F2}", promedioNetoProfesionales);
            }
            Console.WriteLine("\n------------------Programa Finalizado --------------\n");
            Console.ReadLine();
        }
    }
}
